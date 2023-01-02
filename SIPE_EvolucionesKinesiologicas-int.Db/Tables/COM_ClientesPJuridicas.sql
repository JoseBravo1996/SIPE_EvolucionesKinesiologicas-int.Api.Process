CREATE TABLE [integracion].[COM_ClientesPJuridicas](
	[intIdCliente] [int] NOT NULL,
	[varRazonSocial] [varchar](80) NULL,
	[datFechaConstitucion] [datetime] NULL,
	[varProtocoloNotarial] [varchar](50) NULL,
	[varNumeroInscripcion] [varchar](50) NULL,
	[intIdRegistro] [int] NULL,
	[varIIBB] [varchar](20) NULL,
	[integracion] [char](1) NOT NULL,
	[empleadorDboId] [int] NULL
)
GO

ALTER TABLE [integracion].[COM_ClientesPJuridicas] ADD CONSTRAINT [DF_integracion_COM_ClientesPJuridicas] DEFAULT (('C')) FOR [integracion]
GO