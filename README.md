# Demo API .NET + Base de Datos (Clase Introductoria)

Este repositorio contiene una **API desarrollada en .NET (ASP.NET Core Web API)** creada como parte de una clase introductoria.  
El objetivo es aprender **desde cero** cómo conectar una API a una base de datos y generar los modelos automáticamente usando **Entity Framework Core** y **Scaffold (Database First)**.

---

## Objetivo del proyecto

- Entender qué es una API REST  
- Conectar .NET con una base de datos  
- Generar modelos y DbContext usando Scaffold  
- Crear endpoints simples (`GET`)  
- Probar la API usando Swagger  
- Comprender la estructura básica de un proyecto Web API  

> Nota: En esta primera versión se utilizan prácticas simples para facilitar el aprendizaje. Más adelante se aplicarán buenas prácticas y mejoras de arquitectura.

---

## Tecnologías utilizadas

- .NET (ASP.NET Core Web API)  
- Entity Framework Core  
- SQL Server  
- Swagger (OpenAPI)  
- Visual Studio 2022  

---

## Requisitos previos

Antes de ejecutar el proyecto, asegurate de tener instalado:

- Visual Studio 2022  
- .NET SDK  
- SQL Server (Express, Developer o superior)  
- SQL Server Management Studio (SSMS)  

---

## Paquetes NuGet necesarios

Instalar los siguientes paquetes antes de ejecutar Scaffold:

-Install-Package Microsoft.EntityFrameworkCore.SqlServer
-Install-Package Microsoft.EntityFrameworkCore.Tools

---

## Scaffold (Database First)

Ejecutar el siguiente comando en la Package Manager Console para generar los modelos y el DbContext:

Scaffold-DbContext "Server=.;Database=DemoFacturacionDb;Trusted_Connection=True;TrustServerCertificate=True;" Microsoft.EntityFrameworkCore.SqlServer -OutputDir Models -Context AppDbContext

---

## Registro del DbContext

En el archivo Program.cs registrar el contexto:

builder.Services.AddDbContext<AppDbContext>();

---

## Connection String

Configurar la conexión en el archivo `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=.;Database=DemoFacturacionDb;Trusted_Connection=True;TrustServerCertificate=True;"
}


## Base de datos

Se utiliza una base de datos de práctica llamada:

DemoApiDb

CREATE DATABASE DemoApiDb;
GO

USE DemoApiDb;
GO

CREATE TABLE Clientes (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Nombre NVARCHAR(100) NOT NULL,
    Correo NVARCHAR(100) NOT NULL
);
GO

INSERT INTO Clientes (Nombre, Correo)
VALUES 
('Juan Pérez', 'juan.perez@email.com'),
('María López', 'maria.lopez@email.com'),
('Carlos Martínez', 'carlos.martinez@email.com');


SELECT * FROM Clientes

---
