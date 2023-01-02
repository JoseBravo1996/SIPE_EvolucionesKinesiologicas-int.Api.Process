CREATE TABLE [integracion].[COM_ClientesPFisicas](
	[intIdCliente] [int] NOT NULL,
	[varNombre] [varchar](60) NULL,
	[varApellido] [varchar](60) NULL,
	[chrTipoDocumento] [char](3) NULL,
	[chrNroDocumento] [char](11) NULL,
	[chrSexo] [char](1) NULL,
	[datFechaNacimiento] [datetime] NULL,
	[varLugarNacimiento] [varchar](50) NULL,
	[chrCIUO] [char](4) NULL,
	[intIdEstadoCivil] [int] NULL,
	[intIdNacionalidad] [int] NULL,
	[varOcupacion] [varchar](100) NULL,
	[integracion] [char](1) NOT NULL,
	[empleadorDboId] [int] NULL
)
GO

ALTER TABLE [integracion].[COM_ClientesPFisicas] ADD CONSTRAINT [DF_integracion_COM_ClientesPFisicas] DEFAULT (('C')) FOR [integracion]
GO