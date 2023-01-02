CREATE TABLE [integracion].[GEN_Usuarios](
	[intIdUsuario] [int] NOT NULL,
	[intIdDelegacion] [int] NULL,
	[intTipo] [int] NOT NULL,
	[varNombreCompleto] [varchar](200) NULL,
	[varEmail] [varchar](100) NULL,
	[intIdEmpresa] [int] NOT NULL,
    [integracion] [char](1) NOT NULL
) 
GO

ALTER TABLE [integracion].[GEN_Usuarios] ADD CONSTRAINT [DF_integracion_GEN_Usuarios] DEFAULT (('C')) FOR [integracion]
GO