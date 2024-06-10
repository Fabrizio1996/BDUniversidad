-- Verificar y eliminar la base de datos si existe
IF DB_ID('universidad') IS NOT NULL
    DROP DATABASE universidad;
GO

-- Crear la base de datos universidad
CREATE DATABASE universidad;
GO

USE universidad;
GO

-- Verificar y eliminar la tabla estudiante si existe
IF OBJECT_ID('dbo.estudiante', 'U') IS NOT NULL
    DROP TABLE dbo.estudiante;
GO

-- Crear la tabla estudiante
CREATE TABLE [dbo].[estudiante] (
    [StudentID]      INT           IDENTITY (1, 1) NOT NULL,
    [cod_est]        NVARCHAR (4)  NOT NULL,
    [nomb_est]       NVARCHAR (40) NULL,
    PRIMARY KEY CLUSTERED ([StudentID] ASC)
);
GO

-- Verificar y eliminar la tabla asignatura si existe
IF OBJECT_ID('dbo.asignatura', 'U') IS NOT NULL
    DROP TABLE dbo.asignatura;
GO

-- Crear la tabla asignatura
CREATE TABLE [dbo].[asignatura] (
    [CourseID]       INT           IDENTITY (1, 1) NOT NULL,
    [cod_asignatura] NVARCHAR (4)  NOT NULL,
    [nomb_asignatura] NVARCHAR (40) NULL,
    [creditos]       INT           NULL,

    PRIMARY KEY CLUSTERED ([CourseID] ASC)
);
GO

-- Verificar y eliminar la tabla matricula si existe
IF OBJECT_ID('dbo.matricula', 'U') IS NOT NULL
    DROP TABLE dbo.matricula;
GO

-- Crear la tabla matricula
CREATE TABLE [dbo].[matricula] (
    [EnrollmentID]   INT           IDENTITY (1, 1) NOT NULL,
    [periodo]        NVARCHAR (6)  NULL,
    [promedio]       INT           NULL,
    [CourseID]       INT           NOT NULL,
    [StudentID]      INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([EnrollmentID] ASC),
    CONSTRAINT [FK_dbo.Enrollment_dbo.Asignatura_CourseID] FOREIGN KEY ([CourseID]) 
        REFERENCES [dbo].[asignatura] ([CourseID]) ON DELETE CASCADE,
    CONSTRAINT [FK_dbo.matricula_dbo.estudiante_StudentID] FOREIGN KEY ([StudentID]) 
        REFERENCES [dbo].[estudiante] ([StudentID]) ON DELETE CASCADE
);
GO

-- Insertar datos en la tabla estudiante
INSERT INTO [dbo].[estudiante] (cod_est, nomb_est) VALUES ('E001', 'Juan');
INSERT INTO [dbo].[estudiante] (cod_est, nomb_est) VALUES ('E002', 'Maria');
INSERT INTO [dbo].[estudiante] (cod_est, nomb_est) VALUES ('E003', 'Luis');
INSERT INTO [dbo].[estudiante] (cod_est, nomb_est) VALUES ('E004', 'Oscar');

-- Insertar datos en la tabla asignatura
INSERT INTO [dbo].[asignatura] (cod_asignatura, nomb_asignatura, creditos) VALUES ('A001', 'Matemáticas', 4);
INSERT INTO [dbo].[asignatura] (cod_asignatura, nomb_asignatura, creditos) VALUES ('A002', 'Física', 3);
INSERT INTO [dbo].[asignatura] (cod_asignatura, nomb_asignatura, creditos) VALUES ('A003', 'Química', 4);
INSERT INTO [dbo].[asignatura] (cod_asignatura, nomb_asignatura, creditos) VALUES ('A004', 'Ecuaciones Diferenciales', 5);

-- Insertar datos en la tabla matricula
INSERT INTO [dbo].[matricula] (periodo, promedio, CourseID, StudentID) VALUES ('202310', 15, 1, 1);
INSERT INTO [dbo].[matricula] (periodo, promedio, CourseID, StudentID) VALUES ('202320', 18, 2, 2);
INSERT INTO [dbo].[matricula] (periodo, promedio, CourseID, StudentID) VALUES ('202110', 20, 3, 3);
INSERT INTO [dbo].[matricula] (periodo, promedio, CourseID, StudentID) VALUES ('202210', 14, 3, 3);
GO

select * from dbo.estudiante
go

select * from dbo.asignatura
go

select * from dbo.matricula
go