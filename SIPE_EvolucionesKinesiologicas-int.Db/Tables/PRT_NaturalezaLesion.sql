CREATE TABLE [integracion].[PRT_NaturalezaLesion](
	[intIdNaturalezaLesion] [int] NOT NULL,
	[varNaturalezaLesion] [varchar](60) NOT NULL,
	[chrCodigoSRT] [char](10) NULL,
	[bitHabilitado] [bit] NOT NULL,
    [integracion] char(1) NOT NULL,
    [NaturalezaLesionDboId] [int] NULL
)
GO

ALTER TABLE [integracion].[PRT_NaturalezaLesion] ADD CONSTRAINT [DF_integracion_PRT_NaturalezaLesion] DEFAULT (('C')) FOR [integracion]
GO