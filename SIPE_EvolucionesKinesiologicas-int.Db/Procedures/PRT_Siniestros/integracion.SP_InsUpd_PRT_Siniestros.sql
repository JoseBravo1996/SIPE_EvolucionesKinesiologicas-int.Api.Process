GO
CREATE PROCEDURE [integracion].[SP_InsUpd_PRT_Siniestros]
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

        DECLARE @tableVar TABLE (MergeAction VARCHAR(20), Id int, codOrigen int);
        DECLARE @updates AS INT, @inserts AS INT;

        MERGE [dbo].[Siniestros] AS Target
        USING (SELECT 
                    --DATOS DE SINIESTROS
                    S.intIdDelegacionOrigen as [NroDelegacion],
                    S.intNroSiniestro as [NroSiniestro],
                    S.intIdDenuncia as [NroDenuncia],
                    s.varDescripcionAccidente as [Descripcion] ,
                    S.datFechaAccidente [FechaAccidente],
                    S.intIdEstadoSiniestro as [SiniestroEstadoId],
                    S.intIdTipoSiniestro as[SiniestroTipoId] ,
                    S.intIdZonaAfectada as [ZonaAfectadaId],
                    AC.AgentesMaterialesDboId as [AgenteMaterialId],
                    NL.NaturalezaLesionDboId as [NaturalezaLesionId],
                    --DATOS DEL GAS
                    U.varNombreCompleto as [ApellidoNombreGAS],
                    U.varEmail as [MailGAS],
                    --DATOS DEL TRABAJADOR
                    TRA.Id as [TrabajadorId],
                    --DATOS DEL CLIENTE
                    EMP.Id as [EmpleadorId], --EMPLEADOR
                    NL.bitHabilitado
                FROM [integracion].[PRT_Siniestros] S
                    INNER JOIN [integracion].[PRT_SiniestrosTrabajador] ST on ST.intIdDenuncia=S.intIdDenuncia
                    INNER JOIN [integracion].[GEN_Usuarios] U on U.intIdUsuario=S.intIdGestorAsistencial
                    INNER JOIN [integracion].[COM_Clientes] C on C.intIdCliente=S.intIdCliente
                    INNER JOIN [Integracion].[PRT_AgentesCausantes] AC on S.chrIdAgenteCausante = AC.chrIdAgenteCausante
                    INNER JOIN [dbo].[Trabajadores] TRA on TRA.CUIL=ST.chrCUIL
                    INNER JOIN [dbo].[Empleadores] EMP on EMP.CUIT=C.chrCUITCUILCDI
                    INNER JOIN [integracion].[PRT_NaturalezaLesion] NL on NL.intIdNaturalezaLesion = S.intIdNaturalezaLesion
                WHERE S.integracion = 'C'
                AND S.intIdDelegacionOrigen IS NOT NULL
                AND S.intNroSiniestro IS NOT NULL
                AND S.intIdEstadoSiniestro IS NOT NULL
                AND S.intIdTipoSiniestro IS NOT NULL
                AND S.intIdZonaAfectada IS NOT NULL
                AND S.intIdNaturalezaLesion IS NOT NULL
                AND S.varDescripcionAccidente IS NOT NULL
                AND S.intIdDenuncia IS NOT NULL
                AND S.datFechaAccidente IS NOT NULL
                AND AC.AgentesMaterialesDboId IS NOT NULL
                AND NL.bitHabilitado = 1
              ) AS Source
	        ON Target.NroDenuncia = Source.NroDenuncia
        WHEN NOT MATCHED BY Target THEN 
	        INSERT 
            (
                DelegacionOrigen, 
                NroSiniestro, 
                NroDenuncia,
                Descripcion,
                FechaAccidente,
                SiniestroEstadoId,
                SiniestroTipoId,
                ZonaAfectadaId,
                AgenteMaterialId,
                NaturalezaLesionId,
                ApellidoNombreGAS,
                MailGAS,
                TrabajadorId,
                EmpleadorId
            ) 
            VALUES 
            (
                Source.NroDelegacion,
                Source.NroSiniestro, 
                Source.NroDenuncia, 
                Source.Descripcion,
                Source.FechaAccidente,
                Source.SiniestroEstadoId,
                Source.SiniestroTipoId,
                Source.ZonaAfectadaId,
                Source.AgenteMaterialId,
                Source.NaturalezaLesionId,
                Source.ApellidoNombreGAS,
                Source.MailGAS,
                Source.TrabajadorId,
                Source.EmpleadorId
            )
        WHEN MATCHED THEN UPDATE SET 
            Descripcion = Source.Descripcion, 
            NroSiniestro = Source.NroSiniestro,
			DelegacionOrigen = Source.NroDelegacion,
            FechaAccidente = Source.FechaAccidente,
            SiniestroEstadoId =  Source.SiniestroEstadoId,
            SiniestroTipoId = Source.SiniestroTipoId,
            ZonaAfectadaId = Source.ZonaAfectadaId,
            AgenteMaterialId = Source.AgenteMaterialId,
            NaturalezaLesionId = Source.NaturalezaLesionId,
            ApellidoNombreGAS = Source.ApellidoNombreGAS,
            MailGAS = Source.MailGAS,
            TrabajadorId = Source.TrabajadorId,
            EmpleadorId = Source.EmpleadorId
        OUTPUT $action, inserted.Id, Source.NroDenuncia INTO @tableVar;
			
        UPDATE integra SET 
            SiniestroDboId = tmp.Id, 
            integracion = 'I'
        FROM [integracion].[PRT_Siniestros] integra
        INNER JOIN @tableVar tmp 
	        ON integra.intIdDenuncia = tmp.codOrigen
        WHERE integracion = 'C';

        SELECT @updates = SUM(CASE WHEN MergeAction = 'UPDATE' THEN 1 ELSE 0 END) FROM @tableVar;
        SELECT @inserts = SUM(CASE WHEN MergeAction = 'INSERT' THEN 1 ELSE 0 END) FROM @tableVar;

        IF @trancount=1
            COMMIT

        PRINT '[Siniestros] UPDATE: ' + cast(ISNULL(@updates, 0) as varchar);
        PRINT '[Siniestros] INSERT: ' + cast(ISNULL(@inserts, 0) as varchar);


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