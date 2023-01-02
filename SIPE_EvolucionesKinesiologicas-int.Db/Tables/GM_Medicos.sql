CREATE TABLE [integracion].[GM_Medicos](
	[intIdMedico] [int] NOT NULL,
	[intIdPrestador] [int] NOT NULL,
	[varNombreMedico] [varchar](50) NOT NULL,
	[varApellidoMedico] [varchar](50) NOT NULL,
	[chrTipoMatricula] [char](5) NULL,
	[varMatricula] [varchar](50) NULL,
	[bitBaja] [bit] NULL,
	[datFechaBaja] [datetime] NULL,
    [integracion] [char](1) NOT NULL,
    [MedicoDboId] [int] NULL
) 
GO

ALTER TABLE [integracion].[GM_Medicos] ADD CONSTRAINT [DF_integracion_GEN_Medicos] DEFAULT (('C')) FOR [integracion]
GO