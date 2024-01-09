CREATE TABLE [dbo].[ProcesoOrdenesProduccion] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [Orden_Produccion] NVARCHAR (MAX) NULL,
    [LotePrd]          NVARCHAR (MAX) NOT NULL,
    [FechaVenc]        NVARCHAR (MAX) NULL,
    [Estado]           INT            NULL,
    [Nombre]           NVARCHAR (MAX) NULL,
    [RutArch]          NVARCHAR (MAX) NULL,
    [Usuario]          NVARCHAR (MAX) NULL,
    [Other]            NVARCHAR (MAX) NULL
);

