GO
CREATE PROCEDURE [integracion].[SP_InsUpd_PRT_Medicos]
@pResponseCode  INT=0 OUTPUT, -- 0->OK, 1->ERROR
@pErrorCode  INT=0 OUTPUT,
@pErrorMessage  VARCHAR(250)='' OUTPUT
AS
BEGIN

    DECLARE @trancount BIT = 0,
            @insertados INT = 0,
            @actualizados INT = 0

    BEGIN TRY

        IF @@TRANCOUNT=0
        BEGIN
            BEGIN TRANSACTION
            SET @trancount=1
        END

        DECLARE @tableVar TABLE (MergeAction VARCHAR(20), MedicoIdSipe INT, Matricula VARCHAR(50));
        DECLARE @updates AS INT, @inserts AS INT;

        WITH SubMedicosPiscys(Matricula, Nombre, Apellido) AS
        (
            select	rtrim(ltrim( REPLACE(varMatricula, CHAR(9), '') )) varMatricula,
                    MAX(LTRIM(varNombreMedico)),
                    MAX(LTRIM(varApellidoMedico))
            from integracion.GM_Medicos M WITH(NOLOCK)
                INNER JOIN integracion.PRT_PRestadores P WITH(NOLOCK) ON P.intidPREstador = M.intIdPrestador 
            where ISNUMERIC(varMatricula) = 1
                AND chrTipoMatricula = 'MN'
                AND varMatricula NOT IN('9999','9999','9999','9999','9999','99999','99999')
                AND varMatricula NOT LIKE '111%'
                AND varMatricula NOT LIKE '-%'
                AND varMatricula NOT LIKE '%.%'
                AND varMatricula NOT LIKE '0000%'
                AND varMatricula NOT LIKE '2222222%'
                AND LEN(varMatricula) > 3
                AND M.bitBaja = 0
                AND M.integracion = 'C' AND P.integracion = 'I'
            GROUP BY varMatricula, P.chrCuit
        ), MedicosPiscys AS
        (
            select Matricula, MAX(Nombre) Nombre, MAX(Apellido) Apellido
            from SubMedicosPiscys
            GROUP by Matricula
        )
        MERGE [dbo].[Medicos] AS Target
        USING MedicosPiscys AS Source
	        ON Target.NroMatricula = Source.Matricula
        WHEN NOT MATCHED BY Target THEN 
	        INSERT (NroMatricula, MatriculaTipoId, Nombre, Apellido)
            VALUES( rtrim(ltrim( REPLACE(Source.Matricula, CHAR(9), '') )) , 3, Source.Nombre, Source.Apellido)
        WHEN MATCHED THEN UPDATE SET 
            Nombre = Source.Nombre,
            Apellido = Source.Apellido
        OUTPUT $action, inserted.Id, rtrim(ltrim( REPLACE(Source.Matricula, CHAR(9), '') )) INTO @tableVar;

        UPDATE MedicosPiscys
        SET MedicoDboId = tmp.MedicoIdSipe, integracion = 'I'
        FROM [integracion].[GM_Medicos] MedicosPiscys
        INNER JOIN @tableVar tmp 
            ON rtrim(ltrim( REPLACE(MedicosPiscys.varMatricula, CHAR(9), '') )) = tmp.Matricula
        WHERE MedicosPiscys.integracion = 'C';

        SELECT @updates = SUM(CASE WHEN MergeAction = 'UPDATE' THEN 1 ELSE 0 END) FROM @tableVar;
        SELECT @inserts = SUM(CASE WHEN MergeAction = 'INSERT' THEN 1 ELSE 0 END) FROM @tableVar;

        PRINT '[Medicos] UPDATE: ' + cast(ISNULL(@updates, 0) as varchar);
        PRINT '[Medicos] INSERT: ' + cast(ISNULL(@inserts, 0) as varchar);

        INSERT [dbo].[UsuariosMedicos] (UsuarioId, MedicoId, Baja)
		SELECT U.Id, TMP.MedicoIdSipe, 0
		FROM @tableVar TMP
            INNER JOIN integracion.GM_Medicos GM ON rtrim(ltrim( REPLACE(GM.varMatricula, CHAR(9), '') )) = TMP.Matricula
            INNER JOIN integracion.PRT_Prestadores PR ON PR.intIdPrestador=GM.intIdPrestador
            INNER JOIN dbo.Usuarios U ON U.CUIL=PR.chrCuit

		PRINT '[UsuariosMedicos] INSERT: ' + cast(@@rowcount as varchar)

        IF @trancount=1
            COMMIT

    END TRY

    BEGIN CATCH

        IF @trancount=1
            ROLLBACK

        SET @pErrorCode=ERROR_NUMBER()
        SET @pErrorMessage=ERROR_MESSAGE()
 
        SET @pResponseCode=1

    END CATCH

END
GO