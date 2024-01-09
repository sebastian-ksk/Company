-- =============================================
-- Author:		<Author,,Name>
-- Create date: <Create Date,,>
-- Description:	<Description,,>
-- =============================================
CREATE PROCEDURE [dbo].[SP_GET_Users] 
	
AS
BEGIN
	-- SET NOCOUNT ON added to prevent extra result sets from
	-- interfering with SELECT statements.
	SET NOCOUNT ON;

    SELECT TOP (1000) [Id]
      ,[Usuario]
      ,[Clave]
      ,[TipoUsr]
      ,[Estado]
      ,[Nombre]
      ,[Img]
      ,[Other]
      ,[PermissionsChecks]
   FROM [AdsProduccion].[dbo].[UsuariosTabla]
END
