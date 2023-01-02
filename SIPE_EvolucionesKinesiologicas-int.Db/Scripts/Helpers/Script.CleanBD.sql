/*
 Plantilla de script de limpieza de tablas de la BD							
--------------------------------------------------------------------------------------
 Este archivo contiene instrucciones de SQL que se ejecutarán antes del script de compilación	
 Use la sintaxis de SQLCMD para incluir un archivo en el script anterior a la implementación			
 Ejemplo:      :r .\miArchivo.sql								
 Use la sintaxis de SQLCMD para hacer referencia a una variable en el script anterior a la implementación		
 Ejemplo:      :setvar TableName miTabla							
               SELECT * FROM [$(TableName)]					
--------------------------------------------------------------------------------------*/

IF (OBJECT_ID('integracion.COM_Clientes', 'U') IS NOT NULL)
    DROP TABLE integracion.COM_Clientes;

IF (OBJECT_ID('integracion.GM_EvolucionesExternas_Hist', 'U') IS NOT NULL)
    DROP TABLE integracion.GM_EvolucionesExternas_Hist;

IF (OBJECT_ID('integracion.GM_Medicos', 'U') IS NOT NULL)
    DROP TABLE integracion.GM_Medicos;

IF (OBJECT_ID('integracion.PRT_AgentesCausantes', 'U') IS NOT NULL)
    DROP TABLE integracion.PRT_AgentesCausantes;

IF (OBJECT_ID('integracion.PRT_NaturalezaLesion', 'U') IS NOT NULL)
    DROP TABLE integracion.PRT_NaturalezaLesion;

IF (OBJECT_ID('integracion.PRT_Prestadores', 'U') IS NOT NULL)
    DROP TABLE integracion.PRT_Prestadores;

IF (OBJECT_ID('integracion.PRT_Siniestros', 'U') IS NOT NULL)
    DROP TABLE integracion.PRT_Siniestros;

IF (OBJECT_ID('integracion.PRT_SiniestrosTrabajador', 'U') IS NOT NULL)
    DROP TABLE integracion.PRT_SiniestrosTrabajador;

IF (OBJECT_ID('integracion.COM_ClientesPFisicas', 'U') IS NOT NULL)
    DROP TABLE integracion.COM_ClientesPFisicas;

IF (OBJECT_ID('integracion.COM_ClientesPJuridicas', 'U') IS NOT NULL)
    DROP TABLE integracion.COM_ClientesPJuridicas;

IF (OBJECT_ID('integracion.GEN_Usuarios', 'U') IS NOT NULL)
    DROP TABLE integracion.GEN_Usuarios;

IF (OBJECT_ID('integracion.GEN_Trabajadores', 'U') IS NOT NULL)
    DROP TABLE integracion.GEN_Trabajadores;

IF (OBJECT_ID('integracion.GM_EvolucionesExternas_Hist_Intermedia', 'U') IS NOT NULL)
    DROP TABLE integracion.GM_EvolucionesExternas_Hist_Intermedia;

IF (OBJECT_ID('integracion.PRT_PrestadoresEmails', 'U') IS NOT NULL)
    DROP TABLE integracion.PRT_PrestadoresEmails;
