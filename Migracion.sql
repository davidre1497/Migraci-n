Create database  ControlMigración

USE ControlMigración;

-- Eliminar la tabla EntradasSalidas si ya existe para eliminar las restricciones de claves externas
IF OBJECT_ID('dbo.EntradasSalidas', 'U') IS NOT NULL
   DROP TABLE dbo.EntradasSalidas;

-- Eliminar la tabla Viajeros si ya existe
IF OBJECT_ID('dbo.Viajeros', 'U') IS NOT NULL
   DROP TABLE dbo.Viajeros;

-- Eliminar la tabla Países si ya existe
IF OBJECT_ID('dbo.Países', 'U') IS NOT NULL
   DROP TABLE dbo.Países;

-- Eliminar la tabla Usuarios si ya existe
IF OBJECT_ID('dbo.Usuarios', 'U') IS NOT NULL
   DROP TABLE dbo.Usuarios;

-- Eliminar la tabla EntradasSalidasViajero si ya existe
IF OBJECT_ID('dbo.EntradasSalidasViajero', 'U') IS NOT NULL
   DROP TABLE dbo.EntradasSalidasViajero;

-- Crear la tabla Viajeros con clave primaria
CREATE TABLE Viajeros (
    IdViajero int PRIMARY KEY,
    Nombre varchar(50),
    Apellido varchar(50),
    FechaNacimiento date,
    Nacionalidad varchar(50)
);

-- Crear la tabla Países con clave primaria
CREATE TABLE Países (
    IdPais int PRIMARY KEY,
    NombrePais varchar(50)
);

-- Crear la tabla EntradasSalidas con clave primaria y claves foráneas
CREATE TABLE EntradasSalidas (
    IdEntradaSalida int PRIMARY KEY,
    IdViajero int,
    IdPais int,
    FechaEntrada date,
    FechaSalida date,
    LugarEntrada varchar(50),
    LugarSalida varchar(50),
    FOREIGN KEY (IdViajero) REFERENCES Viajeros(IdViajero),
    FOREIGN KEY (IdPais) REFERENCES Países(IdPais)
);

-- Crear la tabla EntradasSalidasViajero con clave primaria y claves foráneas
CREATE TABLE EntradasSalidasViajero (
    IdEntradaSalidaViajero int PRIMARY KEY,
    IdViajero int,
    FechaEntrada date,
    FechaSalida date,
    LugarEntrada varchar(50),
    LugarSalida varchar(50),
    FOREIGN KEY (IdViajero) REFERENCES Viajeros(IdViajero)
);

-- Crear la tabla Usuarios con clave primaria
CREATE TABLE Usuarios (
    IdUsuario int PRIMARY KEY,
    NombreUsuario varchar(50),
    Contraseña varchar(50)
);