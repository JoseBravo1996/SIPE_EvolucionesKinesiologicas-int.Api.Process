CREATE TABLE [integracion].[PRT_PrestadoresEmails](
	[intIdPrestadorEmail] [int] NOT NULL,
	[intIdPrestador] [int] NOT NULL,
	[intIdTipoEmailPrestador] [int] NOT NULL,
	[varDescripcion] [nvarchar](80) NOT NULL,
	[varCC] [varchar](300) NULL,
    [integracion] [char](1) NOT NULL
)
GO

ALTER TABLE [integracion].[PRT_PrestadoresEmails] ADD CONSTRAINT [DF_integracion_PRT_PrestadoresEmails] DEFAULT (('C')) FOR [integracion]
GO