# Challenge PPI - Backend

## Descripción
Este proyecto es una solución para un desafío técnico que consiste en crear un sistema backend para gestionar órdenes de inversión en el mercado financiero. La API permite realizar operaciones CRUD (Crear, Leer, Actualizar, Eliminar) sobre órdenes de inversión.

## Tecnologías Utilizadas
- **ASP.NET Core**: Framework principal para el desarrollo del backend.
- **Entity Framework Core**: Para la interacción con la base de datos.
- **SQLite**: Base de datos utilizada.
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
- **SQLite**
- **Visual Studio Code**

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
La API estará disponible en `https://localhost:5001`.

## **Instrucciones para construir y ejecutar con Docker**

### 1. Publicar la aplicación
Primero, publica la aplicación en modo Release:

```bash
dotnet publish -c Release -o out
```

Esto generará los archivos necesarios en el directorio out.

### 2. Construir la imagen Docker

Ejecuta el siguiente comando para construir la imagen Docker:

```bash
docker build -t challengeppibackend-app .
```

### 3. Ejecutar el contenedor

Inicia el contenedor y mapea el puerto 8080 del contenedor al puerto 5000 de tu máquina:

```bash
docker run -p 5000:8080 challengeppibackend-app
```

El servidor estará disponible en http://localhost:5000.

## Probar la API

### 1. Crear una orden

Crea una nueva orden enviando una solicitud POST al endpoint /api/orders.

Ejemplo:

```bash
curl -X POST http://localhost:5000/api/orders \
-H "Content-Type: application/json" \
-d '{
    "accountId": 1,
    "assetName": "Apple",
    "quantity": 10,
    "price": 177.97,
    "operation": "Buy",
    "status": 0
}'
```

Respuesta esperada (201 Created):

```bash
{
    "id": 1,
    "accountId": 1,
    "assetName": "Apple",
    "quantity": 10,
    "price": 177.97,
    "totalAmount": 1779.7,
    "operation": "Buy",
    "status": 0
}
```

### 2. Obtener todas las órdenes

Obtén todas las órdenes enviando una solicitud GET al endpoint /api/orders.

Ejemplo:
```bash
curl -X GET http://localhost:5000/api/orders
```

Respuesta esperada (200 OK):

```bash
[
    {
        "id": 1,
        "accountId": 1,
        "assetName": "Apple",
        "quantity": 10,
        "price": 177.97,
        "totalAmount": 1779.7,
        "operation": "Buy",
        "status": 0
    }
]
```

### 3. Obtener una orden por ID

Obtén una orden específica enviando una solicitud GET al endpoint /api/orders/{id}.

Ejemplo:
```bash
curl -X GET http://localhost:5000/api/orders/1
```

Respuesta esperada (200 OK):

```bash
{
    "id": 1,
    "accountId": 1,
    "assetName": "Apple",
    "quantity": 10,
    "price": 177.97,
    "totalAmount": 1779.7,
    "operation": "Buy",
    "status": 0
}
```

### 4. Actualizar una orden

Actualiza una orden existente enviando una solicitud PUT al endpoint /api/orders/{id}.

Ejemplo:
```bash
curl -X PUT http://localhost:5000/api/orders/1 \
-H "Content-Type: application/json" \
-d '{
    "accountId": 1,
    "assetName": "Apple",
    "quantity": 15,
    "price": 177.97,
    "operation": "Buy",
    "status": 1
}'
```

Respuesta esperada (204 No Content):

### 5. Eliminar una orden

Elimina una orden específica enviando una solicitud DELETE al endpoint /api/orders/{id}.

Ejemplo:
```bash
curl -X DELETE http://localhost:5000/api/orders/1
```

- Respuesta esperada (204 No Content):

## Notas

- Si encuentras errores al iniciar el contenedor Docker, asegúrate de que las migraciones se hayan aplicado correctamente.

- Los datos iniciales de la tabla Assets se generan automáticamente al iniciar la aplicación.

## Contribuciones
Las contribuciones son bienvenidas. Por favor, abre un issue o envía un pull request para proponer cambios.

## Licencia
Este proyecto está bajo la [MIT License](LICENSE).
