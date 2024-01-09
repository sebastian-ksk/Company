CREATE TABLE [dbo].[FormatoProtFabric] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Orden_Produccion] NVARCHAR (MAX) NULL,
    [FechaReg]         NVARCHAR (MAX) NULL,
    [Estado]           INT            NULL,
    [FechaDilig]       DATETIME       NULL,
    [Lote]             NVARCHAR (MAX) NULL,
    [Nombre]           NVARCHAR (MAX) NULL,
    [Usuario]          NVARCHAR (MAX) NULL,
    [OrdenProc]        NVARCHAR (MAX) NULL,
    [RutaArch]         NVARCHAR (MAX) NULL
);

