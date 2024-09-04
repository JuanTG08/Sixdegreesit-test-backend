# Backend API - Usuarios
Este proyecto es una API desarrollada en .NET 8 que expone un servicio para la gestión de usuarios. Permite realizar operaciones como la consulta de usuarios almacenados en una base de datos SQL Server.

## Tecnologías utilizadas
- **.NET 8**
- **Dapper** - Micro ORM para el acceso a datos.
- **SQL Server** - Base de datos relacional.
- **C#** - Lenguaje de programación.
- **Swagger** - Para la documentación y prueba de la API.

## Configuración del Proyecto
### Clonar el repositorio
Primero, clona el repositorio desde GitHub:
```bash
git clone https://github.com/tuusuario/turepositorio.git
cd turepositorio
```
### Configuración de la base de datos
1. Asegúrate de tener una instancia de SQL Server en ejecución.
2. Crea la base de datos y la tabla `Usuario` con el siguiente script SQL:
```sql
CREATE DATABASE PruebaSD;
USE PruebaSD;
CREATE TABLE Usuario (
	usuID numeric(18, 0) primary key not null IDENTITY(1,1),
	nombre varchar(100) null,
	apellido varchar(100) null
);
```
### Variables de entorno
Las cadenas de conexión y otras configuraciones están almacenadas en el archivo `appsettings.json`. Aquí se define la cadena de conexión a la base de datos y los orígenes permitidos para CORS.
`appsettings.json`
```json
{
	"Logging": {
		"LogLevel": {
		"Default": "Information",
		"Microsoft.AspNetCore": "Warning"
		}
	  },
	"AllowedHosts": "*",
	"Cors": "http://localhost:4200",
	"ConnectionStrings": {
		"DefaultConnection": "TU-CADENA-DE-CONEXION"
	}
}
```
### Ejecución del proyecto
Para ejecutar el proyecto, utiliza el siguiente comando en la raíz del proyecto:
```bash
dotnet run
```
El servidor se ejecutará en `https://localhost:5001` o `http://localhost:5000`.

### Endpoints
La API expone los siguientes endpoints:
- **GET** `/Usuarios`  - Obtiene el listado de usuarios

### Swagger
El proyecto incluye soporte para Swagger. Una vez que el proyecto esté en ejecución, puedes acceder a la documentación interactiva en:
```bash
https://localhost:5001/swagger
```
### Estructura del proyecto
- **Controllers:** Controladores de la API.
- **Servicios:** Lógica de negocio y manejo de datos.
- **AccesoDatos:** Capas de acceso a datos usando Dapper.
- **Entidades:** Definiciones de las entidades utilizadas en el proyecto.

### Ejemplo de respuesta
```json
{
  "code": 200,
  "message": "Listado de usuarios",
  "data": [
    {
      "usuID": 1,
      "nombre": "Juan",
      "apellido": "Pérez"
    }
  ]
}
```