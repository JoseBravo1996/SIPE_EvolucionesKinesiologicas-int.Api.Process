CREATE TABLE [integracion].[PRT_Prestadores](
	[intIdPrestador] [int] NOT NULL,
	[varRazonSocial] [varchar](60) NULL,
	[varNombre] [varchar](50) NULL,
	[varApellido] [varchar](60) NULL,
	[varFantasia] [varchar](60) NULL,
	[chrCuit] [char](11) NOT NULL,
	[intNroSucursal] [int] NOT NULL,
	[intIdTipoPrestador] [int] NULL,
	[intIdTipoConvenio] [int] NULL,
	[intIdDelegacion] [int] NULL,
	[intDiasVencFactura] [int] NULL,
	[intIdCondContractual] [int] NULL,
	[bitHabilitado] [bit] NULL,
	[bitHabTrans] [bit] NULL,
	[intIdEmail] [int] NULL,
	[varWeb] [varchar](200) NULL,
	[varObservaciones] [varchar](200) NULL,
	[bitCtrolRespInscr] [bit] NULL,
	[bitCtrolGanancias] [bit] NULL,
	[bitCtrolIngrBruto] [bit] NULL,
	[bitCtrolMonotributista] [bit] NULL,
	[bitCtrolExentoGan] [char](10) NULL,
	[bitCtrolExentoIngBr] [bit] NULL,
	[bitCtrolInsRNPSSS] [bit] NULL,
	[bitCtrolHabMinist] [bit] NULL,
	[bitCtrolAcredFirma] [bit] NULL,
	[bitCtrolCVMatr] [bit] NULL,
	[bitCtrolTitEsp] [bit] NULL,
	[bitCtrolPolizaMP] [bit] NULL,
	[bitCtrolPolizaTT] [bit] NULL,
	[bitCtrolHabMovil] [bit] NULL,
	[bitCtrolHabRemis] [bit] NULL,
	[bitCtrolCedulaVerde] [bit] NULL,
	[bitCtrolRegCond] [bit] NULL,
	[bitInformaSRT] [bit] NULL,
	[intIdDomicilio] [int] NULL,
	[intIdTelefono] [int] NULL,
	[intIdFax] [int] NULL,
	[intIdEspecialidad] [int] NULL,
	[intIdComplejidad] [int] NULL,
	[bitHabilitadoRSV] [bit] NULL,
	[bitLiquidaCentral] [bit] NOT NULL,
	[intIdEspecialidadJDE] [int] NULL,
	[intIdSituacionIVA] [int] NULL,
	[intIdEmailAutorizacion] [int] NULL,
	[bitLiquidaControllers] [bit] NULL,
    [integracion] [char](1) NOT NULL,
    [UsuarioDboId] [NVARCHAR](450) NULL
)
GO

ALTER TABLE [integracion].[PRT_Prestadores] ADD CONSTRAINT [DF_integracion_PRT_Prestadores] DEFAULT (('C')) FOR [integracion]
GO