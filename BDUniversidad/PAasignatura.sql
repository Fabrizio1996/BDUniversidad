USE universidad;
GO

-- Procedimientos almacenados para la tabla asignatura
CREATE PROCEDURE spListarAsignaturas
AS
BEGIN
    SELECT * FROM dbo.asignatura;
END;
GO

CREATE PROCEDURE spAgregarAsignatura
    @cod_asignatura NVARCHAR(4),
    @nomb_asignatura NVARCHAR(40),
    @creditos INT
AS
BEGIN
    INSERT INTO dbo.asignatura (cod_asignatura, nomb_asignatura, creditos)
    VALUES (@cod_asignatura, @nomb_asignatura, @creditos);
END;
GO

CREATE PROCEDURE spActualizarAsignatura
    @cod_asignatura NVARCHAR(4),
    @nomb_asignatura NVARCHAR(40),
    @creditos INT
AS
BEGIN
    UPDATE dbo.asignatura
    SET nomb_asignatura = @nomb_asignatura, creditos = @creditos
    WHERE cod_asignatura = @cod_asignatura;
END;
GO

CREATE PROCEDURE spEliminarAsignatura
    @cod_asignatura NVARCHAR(4)
AS
BEGIN
    DELETE FROM dbo.matricula WHERE CourseID = (SELECT CourseID FROM dbo.asignatura WHERE cod_asignatura = @cod_asignatura);
    DELETE FROM dbo.asignatura WHERE cod_asignatura = @cod_asignatura;
END;
GO

CREATE PROCEDURE spBuscarAsignaturaPorCodigo
    @cod_asignatura NVARCHAR(4)
AS
BEGIN
    SELECT * FROM dbo.asignatura WHERE cod_asignatura = @cod_asignatura;
END;
GO

