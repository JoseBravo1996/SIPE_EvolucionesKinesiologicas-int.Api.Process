GO
CREATE PROCEDURE [integracion].[SP_InsUpd_PRT_AgentesCausantes]
@pResponseCode  INT=0 OUTPUT, -- 0->OK, 1->ERROR
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
	
        MERGE [dbo].[AgentesMateriales] AS Target
        USING (SELECT * FROM [integracion].[PRT_AgentesCausantes] WHERE integracion = 'C' AND bitHabilitado = 1) AS Source
	        ON Target.Id = Source.agentesMaterialesDboId
        WHEN NOT MATCHED BY Target THEN 
	        INSERT (Descripcion, Activo) VALUES (Source.varAgenteCausante, Source.bitHabilitado)
        WHEN MATCHED THEN 
	        UPDATE SET Descripcion = Source.varAgenteCausante, Activo = bitHabilitado
        OUTPUT $action, inserted.Id, Source.chrIdAgenteCausante INTO @tableVar;
			
        UPDATE AgentesCausantes 
        SET agentesMaterialesDboId = tmp.insertId, integracion = 'I'
        FROM [integracion].[PRT_AgentesCausantes] AgentesCausantes
        INNER JOIN @tableVar tmp 
	        ON AgentesCausantes.chrIdAgenteCausante = tmp.codOrigen
        WHERE AgentesCausantes.integracion = 'C';

        SELECT @updates = SUM(CASE WHEN MergeAction = 'UPDATE' THEN 1 ELSE 0 END) FROM @tableVar;
        SELECT @inserts = SUM(CASE WHEN MergeAction = 'INSERT' THEN 1 ELSE 0 END) FROM @tableVar;

        IF @trancount=1
            COMMIT

        PRINT '[AgentesMateriales] UPDATE: ' + cast(ISNULL(@updates, 0) as varchar);
        PRINT '[AgentesMateriales] INSERT: ' + cast(ISNULL(@inserts, 0) as varchar);

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