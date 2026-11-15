
-- Crear la base de datos
CREATE DATABASE BarberiaDB;
GO

-- Seleccionar la base de datos
USE BarberiaDB;
GO

-- Crear la tabla de clientes
CREATE TABLE Clientes
(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Telefono NVARCHAR(20) NOT NULL,
    Servicio NVARCHAR(100) NOT NULL,
    Barbero NVARCHAR(100) NOT NULL
);
GO
