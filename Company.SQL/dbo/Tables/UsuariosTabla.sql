CREATE TABLE [dbo].[UsuariosTabla] (
    [Id]                INT            IDENTITY (1, 1) NOT NULL,
    [Usuario]           NVARCHAR (MAX) NOT NULL,
    [Clave]             NVARCHAR (MAX) NOT NULL,
    [TipoUsr]           NVARCHAR (50)  NOT NULL,
    [Active]            BIT            NOT NULL,
    [Nombre]            NVARCHAR (MAX) NOT NULL,
    [Img]               NVARCHAR (MAX) NOT NULL,
    [Other]             NVARCHAR (MAX) NOT NULL,
    [PermissionsChecks] NVARCHAR (MAX) NULL
);



