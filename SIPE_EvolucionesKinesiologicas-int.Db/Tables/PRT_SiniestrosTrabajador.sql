CREATE TABLE [integracion].[PRT_SiniestrosTrabajador](
	[intIdSiniestroTrab] [int] NOT NULL,
	[intIdDenuncia] [int] NOT NULL,
	[chrCUIL] [char](11) NOT NULL,
	[varApellido] [varchar](60) NULL,
	[varNombre] [varchar](60) NULL,
	[chrSexo] [char](1) NULL,
	[datFechaNacimiento] [datetime] NULL,
	[chrTipoDocumento] [char](3) NULL,
	[chrNroDocumento] [char](11) NULL,
	[intIdNacionalidad] [int] NULL,
	[intIdEstadoCivil] [int] NULL,
	[intIdTrabajador] [int] NOT NULL,
	[bitTrabajadorNomina] [bit] NULL,
	[intIdTelefono] [int] NULL,
	[intIdDomicilio] [int] NULL,
	[datFechaModiFecNac] [datetime] NULL,
	[datFechaModi] [datetime] NOT NULL,
	[intIdUsuarioModi] [int] NOT NULL,
	[intIdDomicilioAdicional] [int] NULL,
	[varNroCuenta] [varchar](30) NULL,
	[intIdAbogado] [int] NULL,
	[bitAbogadoGratuito] [bit] NULL,
	[integracion] char(1) NOT NULL,
	[trabajadoresDboId] [int] NULL
)
GO


ALTER TABLE [integracion].[PRT_SiniestrosTrabajador] ADD CONSTRAINT [DF_integracion_PRT_SiniestrosTrabajador] DEFAULT (('C')) FOR [integracion]
GO
 
