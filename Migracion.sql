Create database  ControlMigraci�n

USE ControlMigraci�n;

-- Eliminar la tabla EntradasSalidas si ya existe para eliminar las restricciones de claves externas
IF OBJECT_ID('dbo.EntradasSalidas', 'U') IS NOT NULL
   DROP TABLE dbo.EntradasSalidas;

-- Eliminar la tabla Viajeros si ya existe
IF OBJECT_ID('dbo.Viajeros', 'U') IS NOT NULL
   DROP TABLE dbo.Viajeros;

-- Eliminar la tabla Pa�ses si ya existe
IF OBJECT_ID('dbo.Pa�ses', 'U') IS NOT NULL
   DROP TABLE dbo.Pa�ses;

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

-- Crear la tabla Pa�ses con clave primaria
CREATE TABLE Pa�ses (
    IdPais int PRIMARY KEY,
    NombrePais varchar(50)
);

-- Crear la tabla EntradasSalidas con clave primaria y claves for�neas
CREATE TABLE EntradasSalidas (
    IdEntradaSalida int PRIMARY KEY,
    IdViajero int,
    IdPais int,
    FechaEntrada date,
    FechaSalida date,
    LugarEntrada varchar(50),
    LugarSalida varchar(50),
    FOREIGN KEY (IdViajero) REFERENCES Viajeros(IdViajero),
    FOREIGN KEY (IdPais) REFERENCES Pa�ses(IdPais)
);

-- Crear la tabla EntradasSalidasViajero con clave primaria y claves for�neas
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
    Contrase�a varchar(50)
);