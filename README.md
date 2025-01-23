# Challenge PPI - Backend

## Descripción
Este proyecto es una solución para un desafío técnico que consiste en crear un sistema backend para gestionar órdenes de inversión en el mercado financiero. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre órdenes de inversión.

## Tecnologías Utilizadas
- **ASP.NET Core**: Framework principal para el desarrollo del backend.
- **Entity Framework Core**: Para la interacción con la base de datos.
- **SQL Server**: Base de datos utilizada.
- **Swagger**: Documentación interactiva de la API.
- **Git**: Control de versiones.

## Funcionalidades
- Crear nuevas órdenes de inversión.
- Consultar órdenes existentes.
- Actualizar el estado de una orden.
- Eliminar órdenes.
- Calcular automáticamente el monto total y aplicar las reglas de negocio.

## Estructura del Proyecto
```
ChallengePPI.Backend/
├── Controllers/
├── Models/
├── Data/
├── Program.cs
├── appsettings.json
```

## Requisitos
- **.NET SDK**: [Descargar aquí](https://dotnet.microsoft.com/download)
- **SQL Server**
- **Visual Studio** o **Visual Studio Code**

## Instalación
1. Clona este repositorio:
   ```bash
   git clone https://github.com/lucasbellesi/ChallengePPI-Backend.git
   cd ChallengePPI-Backend
   ```
2. Configura la base de datos en `appsettings.json`.
3. Aplica las migraciones:
   ```bash
   dotnet ef database update
   ```
4. Ejecuta el proyecto:
   ```bash
   dotnet run
   ```

## Uso
La API estará disponible en `https://localhost:5001`. Puedes usar Swagger para interactuar con los endpoints en `https://localhost:5001/swagger`.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o envía un pull request para proponer cambios.

## Licencia
Este proyecto está bajo la [MIT License](LICENSE).
