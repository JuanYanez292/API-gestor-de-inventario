# API de Gestor de Inventario

## Descripción
Este proyecto es una API CRUD conectada a SQL Server para gestionar inventarios. Incluye una aplicación cliente en C# con Windows Forms para la interfaz gráfica y una aplicación de terminal en Python.

## Estructura del Proyecto

- **Inventario-API**: Contiene la API.
- **cliente_c#**: Contiene la interfaz gráfica de Windows Forms.
- **cliente_python**: Contiene el archivo de terminal `.py`.
- **db**: Contiene el script SQL para configurar la base de datos.

## Pasos de Instalación

### 1. Configuración de la Base de Datos

- Navega a la carpeta `db` y ejecuta el script SQL proporcionado en tu servidor SQL Server para crear las tablas necesarias.

### 2. Configuración de la API

- Navega a la carpeta `Inventario-API`.
- Abre el archivo `appsettings.json` y modifica la cadena de conexión `Data Source` para que apunte a tu servidor SQL Server.
  
  Ejemplo:
  ```json
  "ConnectionStrings": {
    "DefaultConnection": "Server=TU_SERVIDOR;Database=TU_BASE_DE_DATOS;User Id=TU_USUARIO;Password=TU_CONTRASEÑA;"
  }

### 3. Ejecución de la API
- Ejecuta la API desde la carpeta Inventario-API. La API se establecerá por defecto en http://localhost:5253.


## Imagenes de las aplicaciones
### API
![API-ui.png](https://i.postimg.cc/65FGGfyJ/API-ui.png)
### Aplicacion cliente en c#
![menu](https://i.postimg.cc/xjJfbDH8/c-menu.png)
[![c-get-All.png](https://i.postimg.cc/4nRsXyNM/c-get-All.png)](https://postimg.cc/RJdjRMtQ)
[![c-guardar.png](https://i.postimg.cc/tTVgbLNs/c-guardar.png)](https://postimg.cc/34YhCf6h)
[![c-modificar.png](https://i.postimg.cc/Bn8km4SP/c-modificar.png)](https://postimg.cc/MnS9Tkjz)
[![c-eliminar.png](https://i.postimg.cc/xTZFJhvf/c-eliminar.png)](https://postimg.cc/tYhz8rvw)
### Aplicacion cliente en Python
[![py-menu.png](https://i.postimg.cc/G2sF43Cr/py-menu.png)](https://postimg.cc/phRh7Hr1)
[![py-get-All.png](https://i.postimg.cc/XJF5V2fY/py-get-All.png)](https://postimg.cc/ftzyCfqG)
[![py-guardar.png](https://i.postimg.cc/jSzB7KRH/py-guardar.png)](https://postimg.cc/zyGxssbv)
[![py-modificar.png](https://i.postimg.cc/G3xBqTzV/py-modificar.png)](https://postimg.cc/t77CgTKN)