GO
CREATE PROCEDURE [integracion].[SP_InsUpd_PRT_Prestadores]
@pResponseCode  INT=0 OUTPUT, -- 0->OK, 1->ERROR
@pErrorCode  INT=0 OUTPUT,
@pErrorMessage  VARCHAR(250)='' OUTPUT
AS
BEGIN

    DECLARE @trancount BIT = 0,
            @insertados INT = 0,
            @actualizados INT = 0,
            @Rol NVARCHAR(40) = ''

    BEGIN TRY

        IF @@TRANCOUNT=0
        BEGIN
            BEGIN TRANSACTION
            SET @trancount=1
        END

        DECLARE @tableVar TABLE (MergeAction VARCHAR(20), Id NVARCHAR(450), IdPrestador INT, Cuit VARCHAR(20));
        DECLARE @updates AS INT, @inserts AS INT;

        MERGE [dbo].[Usuarios] AS Target
        USING (SELECT   PISCYS.intIdPrestador, 
                        ISNULL(NULLIF(PISCYS.varNombre,''), PISCYS.varRazonSocial) AS varNombre, 
                        ISNULL(NULLIF(PISCYS.varApellido,''),PISCYS.varRazonSocial) AS varApellido, 
                        PISCYS.chrCuit, 
                        PISCYS.varRazonSocial,  
                        PISCYS_MAIL.varDescripcion AS Email
                FROM [integracion].[PRT_Prestadores] PISCYS 
                    INNER JOIN [integracion].[PRT_PrestadoresEmails] PISCYS_MAIL on PISCYS_MAIL.intIdPrestador=PISCYS.intIdPrestador
                WHERE PISCYS.intNroSucursal = 0 
                AND LEN(PISCYS.chrCuit) = 11
                AND PISCYS_MAIL.varDescripcion NOT LIKE '%;%' 
                AND PISCYS.bithabilitado = 1 
                AND (PISCYS.integracion = 'C' OR PISCYS_MAIL.integracion = 'C')
                GROUP BY  PISCYS.intIdPrestador,varNombre, varApellido, chrCuit, varRazonSocial, PISCYS_MAIL.varDescripcion
              ) AS Source
	        ON Target.Cuil = Source.chrCuit
        WHEN NOT MATCHED BY Target THEN 
	        INSERT 
            (
                Id, 
                Nombre,
                Apellido, 
                RazonSocial,
                Email,
                CUIL
            ) 
            VALUES 
            (
                NEWID(), 
                Source.varNombre, 
                Source.varApellido,
                Source.varRazonSocial,
                Source.Email,
                Source.chrCuit
            )
        WHEN MATCHED THEN UPDATE SET 
            Nombre = Source.varNombre,
            Apellido = Source.varApellido, 
            RazonSocial = Source.varRazonSocial,
            Email = Source.Email
        OUTPUT $action, inserted.Id, Source.intIdPrestador, Source.chrCuit INTO @tableVar;

        SELECT @Rol = r.Id FROM dbo.Roles r WHERE r.Nombre = 'Evoluciones'

        INSERT [dbo].[RolesUsuarios] (RolId, UsuarioId)
		SELECT @Rol, u.Id 
		FROM [dbo].[Usuarios] U
		WHERE NOT EXISTS (SELECT *
							FROM RolesUsuarios ru
							WHERE u.Id = ru.UsuarioId);

		PRINT '[RolesUsuarios] INSERT: ' + cast(@@rowcount as varchar)
			
        UPDATE integra SET 
            UsuarioDboId = tmp.Id, 
            integracion = 'I'
        FROM [integracion].[PRT_Prestadores] integra
        INNER JOIN @tableVar tmp 
	        ON integra.chrCuit = tmp.Cuit
        WHERE integracion = 'C' AND intNroSucursal = 0 AND bitHabilitado = 1;

        UPDATE integra SET 
            integracion = 'I'
        FROM [integracion].[PRT_PrestadoresEmails] integra
        INNER JOIN @tableVar tmp 
	        ON integra.intIdPrestador = tmp.IdPrestador
        WHERE integracion = 'C';

        SELECT @updates = SUM(CASE WHEN MergeAction = 'UPDATE' THEN 1 ELSE 0 END) FROM @tableVar;
        SELECT @inserts = SUM(CASE WHEN MergeAction = 'INSERT' THEN 1 ELSE 0 END) FROM @tableVar;

        IF @trancount=1
            COMMIT

        PRINT '[Usuarios] UPDATE: ' + cast(ISNULL(@updates, 0) as varchar);
        PRINT '[Usuarios] INSERT: ' + cast(ISNULL(@inserts, 0) as varchar);


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