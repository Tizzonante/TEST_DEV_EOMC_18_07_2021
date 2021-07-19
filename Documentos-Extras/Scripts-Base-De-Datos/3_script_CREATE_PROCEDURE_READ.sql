USE TOKA
GO
CREATE PROC dbo.sp_ReadPersonaFisica
(@option INT, @idPersona INT = 0)
AS
BEGIN
IF @option=1

	SELECT IdPersonaFisica 
		  ,FechaRegistro
		  ,FechaActualizacion
		  ,Nombre
		  ,ApellidoPaterno
		  ,ApellidoMaterno
		  ,RFC
		  ,FechaNacimiento
		  ,UsuarioAgrega
		  ,Activo
	  FROM dbo.Tb_PersonasFisicas WHERE Activo=1

ELSE
  SELECT IdPersonaFisica 
      ,FechaRegistro
      ,FechaActualizacion
      ,Nombre
      ,ApellidoPaterno
      ,ApellidoMaterno
      ,RFC
      ,FechaNacimiento
      ,UsuarioAgrega
      ,Activo
  FROM dbo.Tb_PersonasFisicas 
  WHERE IdPersonaFisica=@idPersona AND Activo=1

END;
GO

