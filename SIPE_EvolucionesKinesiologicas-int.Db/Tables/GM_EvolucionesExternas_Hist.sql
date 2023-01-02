CREATE TABLE [integracion].[GM_EvolucionesExternas_Hist](
	[intIdEvolucionHist] [int] NOT NULL,
	[intIdDenuncia] [int] NULL,
	[varCuil] [char](11) NOT NULL,
	[varCuit] [char](11) NULL,
	[datFechaAccidente] [datetime] NOT NULL,
	[varDescripcionAccidente] [varchar](1000) NOT NULL,
	[intIdNaturalezaLesion] [int] NULL,
	[chrIdAgenteCausante] [char](10) NULL,
	[intIdZonaAfectada] [int] NULL,
	[varDiagnostico] [varchar](50) NULL,
	[varEvolucion] [varchar](max) NULL,
	[datFechaDiagnostico] [datetime] NOT NULL,
	[datFechaProximoControl] [datetime] NULL,
	[intIdTipoSiniestro] [int] NULL,
	[datFechaModificacion] [datetime] NOT NULL,
	[intIdUsuarioModificacion] [int] NOT NULL,
	[intIdSeguimientoMed] [int] NULL,
	[varApellido] [varchar](50) NOT NULL,
	[varNombre] [varchar](50) NOT NULL,
	[varRazonSocial] [varchar](50) NULL,
	[intIdEstado] [int] NOT NULL,
	[varMotivoRechazo] [varchar](500) NULL,
	[intIdMedico] [int] NOT NULL,
	[intIdPrestador] [int] NOT NULL,
	[intIdUsuarioAlta] [int] NOT NULL,
	[intIdEvolucionExterna] [int] NOT NULL,
	[datFechaAlta] [datetime] NOT NULL,
	[bitInternado] [bit] NULL,
	[bitTraslado] [bit] NOT NULL,
	[intIdMotivoRechazo] [int] NULL,
	[datFechaAltaMedica] [datetime] NULL,
    [integracion] [char](1) NOT NULL
)
GO

ALTER TABLE [integracion].[GM_EvolucionesExternas_Hist] ADD CONSTRAINT [DF_integracion_GM_EvolucionesExternas_Hist] DEFAULT (('C')) FOR [integracion]
GO