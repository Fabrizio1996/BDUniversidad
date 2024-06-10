use universidad
go

-- Procedimientos almacenados para la tabla matricula
CREATE PROCEDURE spListarMatriculas
AS
BEGIN
    SELECT * FROM dbo.matricula;
END;
GO

CREATE PROCEDURE spAgregarMatricula
    @cod_asignatura NVARCHAR(4),
    @cod_est NVARCHAR(4),
    @periodo NVARCHAR(6),
    @promedio INT
AS
BEGIN
    DECLARE @CourseID INT, @StudentID INT;
    
    SELECT @CourseID = CourseID FROM dbo.asignatura WHERE cod_asignatura = @cod_asignatura;
    SELECT @StudentID = StudentID FROM dbo.estudiante WHERE cod_est = @cod_est;

    INSERT INTO dbo.matricula (periodo, promedio, CourseID, StudentID)
    VALUES (@periodo, @promedio, @CourseID, @StudentID);
END;
GO

CREATE PROCEDURE spActualizarMatricula
    @periodo NVARCHAR(6),
    @promedio INT,
    @CourseID INT,
    @StudentID INT
AS
BEGIN
    UPDATE dbo.matricula
    SET promedio = @promedio
    WHERE periodo = @periodo
    AND CourseID = @CourseID
    AND StudentID = @StudentID;
END;
GO

CREATE PROCEDURE spEliminarMatricula
    @periodo NVARCHAR(6)
AS
BEGIN
    DELETE FROM dbo.matricula WHERE periodo = @periodo;
END;
GO

CREATE PROCEDURE spBuscarMatriculasPorEstudiante
    @cod_est NVARCHAR(4)
AS
BEGIN
    SELECT m.*, a.*, e.*
    FROM dbo.matricula m
    INNER JOIN dbo.asignatura a ON m.CourseID = a.CourseID
    INNER JOIN dbo.estudiante e ON m.StudentID = e.StudentID
    WHERE e.cod_est = @cod_est;
END;
GO
