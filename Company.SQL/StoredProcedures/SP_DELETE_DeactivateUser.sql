CREATE PROCEDURE [dbo].[SP_DELETE_DeactivateUser]
    @Id INT
AS
BEGIN
    UPDATE [dbo].[UsuariosTabla]
    SET Active = 0
    WHERE Id = @Id;
END