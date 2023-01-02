CREATE TABLE [integracion].[PRT_AgentesCausantes](
	[chrIdAgenteCausante] [char](3) NOT NULL,
	[varAgenteCausante] [varchar](200) NOT NULL,
	[chrCodigoSRT] [char](10) NULL,
	[bitHabilitado] [bit] NOT NULL,
	[integracion] char(1) NOT NULL,
	[agentesMaterialesDboId] int NULL
) 
GO

ALTER TABLE [integracion].[PRT_AgentesCausantes] ADD CONSTRAINT [DF_integracion_PRT_AgentesCausantes] DEFAULT (('C')) FOR [integracion]
GO