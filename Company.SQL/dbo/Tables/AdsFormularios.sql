CREATE TABLE [dbo].[AdsFormularios] (
    [Id]                  INT            IDENTITY (1, 1) NOT NULL,
    [Formato]             NVARCHAR (MAX) NULL,
    [FecEmis]             DATETIME       NULL,
    [FecVenc]             DATETIME       NULL,
    [NoEmision]           BIGINT         NULL,
    [Estado]              BIT            NULL,
    [EditadoDiligenciado] NVARCHAR (MAX) NULL,
    [oter]                NVARCHAR (MAX) NULL,
    [Edito]               NVARCHAR (MAX) NULL
);

