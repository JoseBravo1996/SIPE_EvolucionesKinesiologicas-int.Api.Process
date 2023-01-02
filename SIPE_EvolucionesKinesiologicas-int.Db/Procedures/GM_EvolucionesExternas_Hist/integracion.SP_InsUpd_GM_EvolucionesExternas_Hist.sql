GO
CREATE PROCEDURE [integracion].[SP_InsUpd_GM_EvolucionesExternas_Hist]
@pResponseCode  INT=0 OUTPUT, -- 0->OK, 1->ERROR
@pErrorCode  INT=0 OUTPUT,
@pErrorMessage  VARCHAR(250)='' OUTPUT
AS
BEGIN

    DECLARE @trancount BIT = 0,
            @actualizados INT = 0

    BEGIN TRY

        IF @@TRANCOUNT=0
        BEGIN
            BEGIN TRANSACTION
            SET @trancount=1
        END

        DECLARE @updates AS INT;

        UPDATE EM
        SET  EM.EvolucionEstadoId = EH.intIdEstado
            ,EM.RechazoMotivoId   = EH.intIdMotivoRechazo
            ,EM.ObservacionesRechazo = EH.varMotivoRechazo
        FROM dbo.EvolucionesMedicas EM
            INNER JOIN [integracion].[GM_EvolucionesExternas_Intermedia] EHI ON EHI.EvolucionMedicaDboId = EM.Id
            INNER JOIN [integracion].[GM_EvolucionesExternas_Hist] EH ON EH.intIdEvolucionHist = EHI.intIdEvolucionExterna
        WHERE EH.integracion = 'C';

        SET @actualizados = cast(@@rowcount as varchar)

        IF @actualizados > 0

            UPDATE EH
            SET integracion = 'I'
            FROM [integracion].[GM_EvolucionesExternas_Hist] EH
                INNER JOIN [integracion].[GM_EvolucionesExternas_Intermedia] EHI 
                    ON EHI.intIdEvolucionExterna = EH.intIdEvolucionExterna
                INNER JOIN [dbo].[EvolucionesMedicas] EM 
                    ON EM.Id = EHI.EvolucionMedicaDboId
            WHERE EH.integracion = 'C';


		PRINT '[EvolucionesMedicas] UPDATE: ' + cast(@actualizados as varchar)
			
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