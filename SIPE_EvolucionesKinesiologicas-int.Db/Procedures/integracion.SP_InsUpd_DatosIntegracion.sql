GO
CREATE PROCEDURE [integracion].[SP_InsUpd_DatosIntegracion]
AS
BEGIN
       SET NOCOUNT ON;

	   DECLARE @EX_ERROR_MESSAGE nvarchar(MAX), 
	   		   @EX_ERROR_CODE INT, 
	   		   @STATE INT, 
			   @SEVERITY INT,
			   @ResponseCode  INT=0

       BEGIN TRAN
            BEGIN TRY

		    -- =========================================================================== --
            -- 1 - PRT_AgentesCausantes
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_PRT_AgentesCausantes] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT

		    IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_PRT_AgentesCausantes] falló', 16, 1)

			-- =========================================================================== --
            -- 2 - PRT_NaturalezaLesion
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_PRT_NaturalezaLesion] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT

		    IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_PRT_NaturalezaLesion] falló', 16, 1)

            -- =========================================================================== --
            -- 3 - PRT_SiniestrosTrabajador
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_PRT_SiniestrosTrabajador] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT

		    IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_PRT_SiniestrosTrabajador] falló', 16, 1)


            -- =========================================================================== --
            -- 4 - COM_Clientes
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_COM_Clientes] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT

		    IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_COM_Clientes] falló', 16, 1)

		-- =========================================================================== --
            -- 5 - PRT_Prestadores
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_PRT_Prestadores] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT

		    IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_PRT_Prestadores] falló', 16, 1)
        
            -- =========================================================================== --
            -- 6 - PRT_Siniestros
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_PRT_Siniestros] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT

		    IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_PRT_Siniestros] falló', 16, 1)

			-- =========================================================================== --
            -- 7 - GM_Medicos
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_PRT_Medicos] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT

		    IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_PRT_Medicos] falló', 16, 1)

			-- =========================================================================== --
            -- 8 - GM_EvolucionesExternas_Hist
            -- =========================================================================== --
		    EXEC [integracion].[SP_InsUpd_GM_EvolucionesExternas_Hist] 
				    @pResponseCode = @ResponseCode OUTPUT, 
				    @pErrorCode = @EX_ERROR_CODE OUTPUT,
				    @pErrorMessage = @EX_ERROR_MESSAGE OUTPUT
			
			IF @ResponseCode = 1
			    RAISERROR('[integracion].[SP_InsUpd_GM_EvolucionesExternas_Hist] falló', 16, 1)


            COMMIT TRANSACTION
       END TRY
       BEGIN CATCH 
           if @@error <> 0 AND @@trancount > 0 
           BEGIN 
           
               SELECT @EX_ERROR_MESSAGE = 
               'Un Error ha Ocurrido:' + char(13) + char(10) 
               + 'Msg ' + cast(ISNULL(@EX_ERROR_CODE, -1) as nvarchar(20) ) 
               + ', Level ' + cast(ISNULL(ERROR_SEVERITY(), -1) as nvarchar(20) ) 
               + ', State ' + cast(ISNULL(ERROR_STATE(), -1) as nvarchar(20) ) 
               + ', Line ' + cast(ISNULL(ERROR_LINE(), -1) as nvarchar(20) ) + char(13) + char(10) 
               + ISNULL(@EX_ERROR_MESSAGE, ' without message') + char(13) + char(10), 
               @SEVERITY = ERROR_SEVERITY(), 
               @STATE = ERROR_STATE() 
               RAISERROR(@EX_ERROR_MESSAGE, @SEVERITY, @STATE) 
           END 
           ROLLBACK TRANSACTION 
           PRINT 'Se Produjo un error y los cambio fueron cancelados' 
       END CATCH
END
GO