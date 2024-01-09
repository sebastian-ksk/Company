﻿CREATE TABLE [dbo].[Proceso_Ord_RotLimp_Liber_Pesada_DISP] (
    [Id]                     INT            IDENTITY (1, 1) NOT NULL,
    [Orden_Produccion]       NVARCHAR (MAX) NULL,
    [LotePrd]                NVARCHAR (MAX) NULL,
    [Estado]                 INT            NULL,
    [Nombre]                 NVARCHAR (MAX) NULL,
    [Usuario]                NVARCHAR (MAX) NULL,
    [TamanoLote]             BIGINT         NULL,
    [DataRP01302]            NVARCHAR (MAX) NULL,
    [FechRealizRP01302]      DATETIME       NULL,
    [FechVerfRP01302]        DATETIME       NULL,
    [RealizadoRP01302]       NVARCHAR (MAX) NULL,
    [Arch1RP1302]            NVARCHAR (MAX) NULL,
    [PresentacionRP091]      NVARCHAR (MAX) NULL,
    [FechaDespeje]           DATETIME       NULL,
    [FirmaDespeje]           NVARCHAR (MAX) NULL,
    [AutorizaRP091]          NVARCHAR (MAX) NULL,
    [FechaAutorizaRP091]     DATETIME       NULL,
    [ChecksRP091]            NVARCHAR (MAX) NULL,
    [Arch1RP09101]           NVARCHAR (MAX) NULL,
    [TablaDosRP091]          NVARCHAR (MAX) NULL,
    [ObservacionesRP091]     NVARCHAR (MAX) NULL,
    [DespejeRealizadoRP091]  NVARCHAR (MAX) NULL,
    [Arch1TarjetaPesada]     NVARCHAR (MAX) NULL,
    [DataTarjPesada]         NVARCHAR (MAX) NULL,
    [FirmaTarjPesada]        NVARCHAR (MAX) NULL,
    [RealizaTarjPesada]      NVARCHAR (MAX) NULL,
    [FechaRealTarjPesada]    DATETIME       NULL,
    [FechaFecVerfTarjPesada] DATETIME       NULL,
    [ProductoAntesRP013]     NVARCHAR (MAX) NULL,
    [ProductoAntesRP091]     NVARCHAR (MAX) NULL,
    [ProductoAntesTarjpes]   NVARCHAR (MAX) NULL,
    [PerfilActual]           NVARCHAR (MAX) NULL,
    [UltModif]               DATETIME       NULL
);

