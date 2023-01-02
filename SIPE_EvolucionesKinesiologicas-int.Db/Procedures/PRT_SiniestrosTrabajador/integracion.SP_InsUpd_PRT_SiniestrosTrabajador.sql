GO
CREATE PROCEDURE [integracion].[SP_InsUpd_PRT_SiniestrosTrabajador]
@pResponseCode  INT=0 OUTPUT,
@pErrorCode  INT=0 OUTPUT,
@pErrorMessage  VARCHAR(250)='' OUTPUT
AS
BEGIN

    DECLARE @trancount BIT = 0

    BEGIN TRY

        IF @@TRANCOUNT=0
        BEGIN
            BEGIN TRANSACTION
            SET @trancount=1
        END
			
			DECLARE @tableVar TABLE (MergeAction VARCHAR(20), insertId int, codOrigen varchar(20));
			DECLARE @updates AS INT, @inserts AS INT;

			WITH 
			PiscysSiniestroTrabajadores AS 
			(
				SELECT chrNroDocumento NroDocumento, dt.Id DocumentoTipoId, chrCUIL CUIL, varNombre Nombre, varApellido Apellido, chrSexo Sexo, bitTrabajadorNomina EsNominado
				FROM (
					SELECT 
						ROW_NUMBER() OVER (PARTITION BY chrCUIL ORDER BY datFechaModi desc, chrCUIL) Seleccion,
						TRIM(chrNroDocumento) chrNroDocumento,
						TRIM(chrTipoDocumento) chrTipoDocumento,
						TRIM(chrCUIL) chrCUIL,
						varNombre,
						varApellido,
						chrSexo,
						bitTrabajadorNomina
					FROM [integracion].[PRT_SiniestrosTrabajador]
					where integracion = 'C'
						AND LEN(TRIM(chrCUIL)) = 11
						AND ISNUMERIC(TRIM(chrNroDocumento)) = 1
						AND NOT TRIM(chrNroDocumento) IN ('00000000', '0')
						AND LEN(TRIM(chrNroDocumento)) < 9
						AND LEN(TRIM(varNombre)) > 1
						AND LEN(TRIM(varApellido)) > 1
						AND LEN(TRIM(chrSexo)) = 1	
				) t
				LEFT JOIN [dbo].[DocumentoTipos] dt ON dt.Codigo = TRIM(chrTipoDocumento)
				WHERE t.Seleccion = 1
			)
			MERGE [dbo].[Trabajadores] AS Target
			USING PiscysSiniestroTrabajadores AS Source
				ON Target.CUIL = Source.CUIL
			WHEN NOT MATCHED BY Target THEN 
				INSERT (NroDocumento, CUIL, DocumentoTipoId, Nombre, Apellido, Sexo, EsNominado) 
				VALUES (Source.NroDocumento, Source.CUIL, Source.DocumentoTipoId, Source.Nombre, Source.Apellido, Source.Sexo, Source.EsNominado)
			WHEN MATCHED THEN 
				UPDATE SET Nombre = Source.Nombre, Apellido = Source.Apellido, Sexo = Source.Sexo
			OUTPUT $action, inserted.Id, TRIM(Source.CUIL) INTO @tableVar;

			UPDATE PiscysSiniestrosTrabajadores 
			SET trabajadoresDboId = tmp.insertId, integracion = 'I'
			FROM [integracion].[PRT_SiniestrosTrabajador] PiscysSiniestrosTrabajadores
			INNER JOIN @tableVar tmp 
				ON PiscysSiniestrosTrabajadores.chrCUIL = tmp.codOrigen
			WHERE integracion = 'C';

			SELECT @updates = SUM(CASE WHEN MergeAction = 'UPDATE' THEN 1 ELSE 0 END) FROM @tableVar;
			SELECT @inserts = SUM(CASE WHEN MergeAction = 'INSERT' THEN 1 ELSE 0 END) FROM @tableVar;

        IF @trancount=1
            COMMIT

        PRINT '[Trabajadores] UPDATE: ' + cast(ISNULL(@updates, 0) as varchar);
        PRINT '[Trabajadores] INSERT: ' + cast(ISNULL(@inserts, 0) as varchar);

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