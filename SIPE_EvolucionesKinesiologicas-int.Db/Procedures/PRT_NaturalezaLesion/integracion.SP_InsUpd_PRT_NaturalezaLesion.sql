GO
CREATE PROCEDURE [integracion].[SP_InsUpd_PRT_NaturalezaLesion]
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
        
        DECLARE @tableVar TABLE (MergeAction VARCHAR(20), Id int, CodigoSRT char(10));
        DECLARE @updates AS INT, @inserts AS INT;
	
        MERGE [dbo].[NaturalezaLesiones] AS Target
        USING (SELECT * FROM [integracion].[PRT_NaturalezaLesion] WHERE integracion = 'C' AND bitHabilitado = 1) AS Source
	        ON Target.Id = Source.NaturalezaLesionDboId
        WHEN NOT MATCHED BY Target THEN 
	        INSERT (Descripcion, Activo) VALUES (Source.varNaturalezaLesion, Source.bitHabilitado)
        WHEN MATCHED THEN 
	        UPDATE SET Descripcion = Source.varNaturalezaLesion, Activo = Source.bitHabilitado
        OUTPUT $action, inserted.Id, Source.chrCodigoSRT INTO @tableVar;
			
        UPDATE NaturalezaLesiones 
        SET NaturalezaLesionDboId = tmp.Id, integracion = 'I'
        FROM [integracion].[PRT_NaturalezaLesion] NaturalezaLesiones
        INNER JOIN @tableVar tmp 
	        ON NaturalezaLesiones.chrCodigoSRT = tmp.CodigoSRT
        WHERE NaturalezaLesiones.integracion = 'C';

        SELECT @updates = SUM(CASE WHEN MergeAction = 'UPDATE' THEN 1 ELSE 0 END) FROM @tableVar;
        SELECT @inserts = SUM(CASE WHEN MergeAction = 'INSERT' THEN 1 ELSE 0 END) FROM @tableVar;

        IF @trancount=1
            COMMIT

        PRINT '[NaturalezaLesiones] UPDATE: ' + cast(ISNULL(@updates, 0) as varchar);
        PRINT '[NaturalezaLesiones] INSERT: ' + cast(ISNULL(@inserts, 0) as varchar);

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