CREATE TABLE [dbo].[ExplosionMateriales] (
    [Id]               INT            IDENTITY (1, 1) NOT NULL,
    [NombreProd]       NVARCHAR (MAX) NOT NULL,
    [Lote]             NVARCHAR (MAX) NOT NULL,
    [CantidadNeces]    FLOAT (53)     NOT NULL,
    [IdProducto]       NVARCHAR (MAX) NOT NULL,
    [IdPadre]          NVARCHAR (MAX) NOT NULL,
    [FechaExpirac]     DATETIME       NOT NULL,
    [LoteProducto]     NVARCHAR (MAX) NULL,
    [Realizado]        BIT            NULL,
    [RealizadoPor]     NVARCHAR (MAX) NULL,
    [Completo]         BIT            NULL,
    [Faltante]         FLOAT (53)     NULL,
    [FechaExplos]      DATETIME       NULL,
    [FechaAgreAlmacen] DATETIME       NULL,
    [PrinActivo]       BIT            NULL,
    [Potencia]         FLOAT (53)     NULL,
    [CantidadTeor]     FLOAT (53)     NULL,
    [FirmaAlmacen]     NVARCHAR (MAX) NULL
);

