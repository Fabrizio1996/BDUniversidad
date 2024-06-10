USE universidad;
GO

-- Procedimientos almacenados para la tabla estudiante
CREATE PROCEDURE spListarEstudiantes
AS
BEGIN
    SELECT * FROM dbo.estudiante;
END;
GO

CREATE PROCEDURE spAgregarEstudiante
    @cod_est NVARCHAR(4),
    @nomb_est NVARCHAR(40)
AS
BEGIN
    INSERT INTO dbo.estudiante (cod_est, nomb_est)
    VALUES (@cod_est, @nomb_est);
END;
GO

CREATE PROCEDURE spActualizarEstudiante
    @cod_est NVARCHAR(4),
    @nomb_est NVARCHAR(40)
AS
BEGIN
    UPDATE dbo.estudiante
    SET nomb_est = @nomb_est
    WHERE cod_est = @cod_est;
END;
GO

CREATE PROCEDURE spEliminarEstudiante
    @cod_est NVARCHAR(4)
AS
BEGIN
    DELETE FROM dbo.matricula WHERE StudentID = (SELECT StudentID FROM dbo.estudiante WHERE cod_est = @cod_est);
    DELETE FROM dbo.estudiante WHERE cod_est = @cod_est;
END;
GO

CREATE PROCEDURE spBuscarEstudiantePorCodigo
    @cod_est NVARCHAR(4)
AS
BEGIN
    SELECT * FROM dbo.estudiante WHERE cod_est = @cod_est;
END;
GO

