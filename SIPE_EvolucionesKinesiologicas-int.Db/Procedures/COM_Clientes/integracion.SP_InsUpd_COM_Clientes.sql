GO
CREATE PROCEDURE [integracion].[SP_InsUpd_COM_Clientes]
    @pResponseCode  INT = 0 OUTPUT, -- 0 -> OK, 1 -> ERROR
    @pErrorCode  INT = 0 OUTPUT,
    @pErrorMessage  VARCHAR(250) = '' OUTPUT
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

        DECLARE @tableVar TABLE (MergeAction VARCHAR(20), SipeId INT, PiscysId INT);
        DECLARE @updates AS INT, @inserts AS INT;
	
        MERGE [dbo].Empleadores AS Target
        USING (
		        SELECT C.intIdCliente AS intIdCliente,
				        LTRIM(RTRIM(C.chrCUITCUILCDI)) AS CUIT,
				        COALESCE(LTRIM(RTRIM(CFISICA.varApellido)) + ' ' + LTRIM(RTRIM(CFISICA.varNombre)), LTRIM(RTRIM(CJURID.varRazonSocial))) AS RazonSocial,
				        CASE WHEN C.chrTipoPersona = 'F'
						        THEN 1 -- Fisica
						        ELSE 2 -- Juridica
					        END AS PersonaTipoId
		        FROM [integracion].COM_Clientes C
			        LEFT join [integracion].COM_ClientesPFisicas CFISICA ON CFISICA.intIdCliente = C.intIdCliente
			        LEFT join [integracion].COM_ClientesPJuridicas CJURID ON CJURID.intIdCliente = C.intIdCliente
		        WHERE (C.integracion = 'C' OR CFISICA.integracion = 'C' OR CJURID.integracion = 'C')
				        AND (CFISICA.intIdCliente IS NOT NULL OR CJURID.intIdCliente IS NOT NULL)) AS Source
	        ON Target.CUIT = Source.CUIT
        WHEN NOT MATCHED BY Target THEN 
	        INSERT (CUIT, RazonSocial, PersonaTipoId) VALUES (Source.CUIT, LEFT(Source.RazonSocial, 100), Source.PersonaTipoId)
        WHEN MATCHED THEN 
	        UPDATE SET RazonSocial = LEFT(Source.RazonSocial, 100), PersonaTipoId = Source.PersonaTipoId
        OUTPUT $action, inserted.Id, Source.intIdCliente INTO @tableVar;
			
        UPDATE integra 
	        SET empleadorDboId = tmp.SipeId, integracion = 'I'
	        FROM [integracion].COM_Clientes integra
		        INNER JOIN @tableVar tmp ON integra.intIdCliente = tmp.PiscysId
	        WHERE integracion = 'C';
        UPDATE integra 
	        SET empleadorDboId = tmp.SipeId, integracion = 'I'
	        FROM [integracion].COM_ClientesPFisicas integra
		        INNER JOIN @tableVar tmp ON integra.intIdCliente = tmp.PiscysId
	        WHERE integracion = 'C';
        UPDATE integra 
	        SET empleadorDboId = tmp.SipeId, integracion = 'I'
	        FROM [integracion].COM_ClientesPJuridicas integra
		        INNER JOIN @tableVar tmp ON integra.intIdCliente = tmp.PiscysId
	        WHERE integracion = 'C';

        SELECT @updates = SUM(CASE WHEN MergeAction = 'UPDATE' THEN 1 ELSE 0 END) FROM @tableVar;
        SELECT @inserts = SUM(CASE WHEN MergeAction = 'INSERT' THEN 1 ELSE 0 END) FROM @tableVar;

        IF @trancount=1
            COMMIT

        PRINT '[Empleadores] UPDATE: ' + cast(ISNULL(@updates, 0) as varchar);
        PRINT '[Empleadores] INSERT: ' + cast(ISNULL(@inserts, 0) as varchar);

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