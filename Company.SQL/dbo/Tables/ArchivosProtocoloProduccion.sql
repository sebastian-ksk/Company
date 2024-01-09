CREATE TABLE [dbo].[ArchivosProtocoloProduccion] (
    [Id]             INT            IDENTITY (1, 1) NOT NULL,
    [NombreProducto] NVARCHAR (MAX) NULL,
    [CodProducto]    NVARCHAR (MAX) NULL,
    [CodProtocolo]   NVARCHAR (MAX) NULL,
    [RutaArch]       NVARCHAR (MAX) NULL,
    [FechVenc]       DATETIME       NULL,
    [FechaElav]      DATETIME       NULL,
    [Estado]         BIT            NULL,
    [Formato]        NVARCHAR (MAX) NULL,
    [Usuario]        NVARCHAR (MAX) NULL,
    [NumeroEdic]     BIGINT         NULL
);

