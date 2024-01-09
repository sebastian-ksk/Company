CREATE TABLE [dbo].[Cuali_Caunti_Produccion] (
    [Id]                 INT            IDENTITY (1, 1) NOT NULL,
    [IdPadre]            NVARCHAR (MAX) NULL,
    [IdProducto]         NVARCHAR (MAX) NULL,
    [Nombre]             NVARCHAR (MAX) NULL,
    [cualiCuantitativa]  FLOAT (53)     NULL,
    [ValorLLenado]       FLOAT (53)     NULL,
    [PrincipioActivo]    BIT            NULL,
    [VidaUtil]           INT            NULL,
    [Editar]             NVARCHAR (MAX) NULL,
    [FechaRegistroSanit] NVARCHAR (MAX) NULL,
    [ValorExceso]        INT            NULL,
    [TamañoLote]         BIGINT         NULL,
    [CantidadEnvase]     BIGINT         NULL,
    [CodProcess]         VARCHAR (MAX)  NULL,
    [Nivel]              BIGINT         NULL,
    [FileRegSan]         NVARCHAR (MAX) NULL,
    [RutaProceso]        NCHAR (10)     NULL
);

