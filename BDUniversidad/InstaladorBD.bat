@echo off
:: Pregunta al usuario si desea proceder con la instalación
echo Deseas instalar la base de datos? (Y/N)
set /p respuesta=

:: Si la respuesta es 'N', cancela la instalación
if /I "%respuesta%"=="N" (
    echo Instalacion cancelada.
    pause
    exit /b
)

:: Si la respuesta es 'Y', pregunta si está usando SQL Server Express o SQL Server
if /I "%respuesta%"=="Y" (
    echo Estas usando SQL Server Express? (Y/N)
    set /p answer=

    :: Configura la instancia según la respuesta del usuario
    if /I "%answer%"=="Y" (
        set instancia=localhost\SQLEXPRESS
    ) else (
        set instancia=localhost
    )

    :: Procede con la instalación de la base de datos
    sqlcmd -S%instancia% -E -i "BDUniversidad.sql"
    sqlcmd -S%instancia% -E -i "PA_estudiante.sql"
    sqlcmd -S%instancia% -E -i "PA_asignatura.sql"
    sqlcmd -S%instancia% -E -i "PA_matricula.sql"
    echo Base de datos instalada correctamente
)

pause
