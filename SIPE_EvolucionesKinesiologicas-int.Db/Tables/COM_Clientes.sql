CREATE TABLE [integracion].[COM_Clientes](
	[intIdCliente] [int] NOT NULL,
	[chrTipoPersona] [char](1) NOT NULL,
	[chrCUITCUILCDI] [char](11) NOT NULL,
	[intIdSituacionIVA] [int] NULL,
	[chrNivelRiesgo] [char](1) NULL,
	[varActividad] [varchar](250) NULL,
	[smiEstablecimientos] [smallint] NULL,
	[datFechaInicioActividad] [datetime] NULL,
	[varIdClienteCRM] [varchar](60) NULL,
	[bitCuentaEspecial] [bit] NOT NULL,
	[varActOtras] [varchar](250) NULL,
	[integracion] [char](1) NOT NULL,
	[empleadorDboId] [int] NULL
)
GO

ALTER TABLE [integracion].[COM_Clientes] ADD CONSTRAINT [DF_integracion_COM_Clientes] DEFAULT (('C')) FOR [integracion]
GO