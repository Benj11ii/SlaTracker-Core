# SlaTracker-Core ⏱️

Engine/API RESTful desarrollado en **.NET 8** para la gestión, seguimiento y cálculo automatizado de Acuerdos de Nivel de Servicio (SLA) en tickets de soporte corporativo.

## 🚀 Características Técnicas
- **Arquitectura Limpia**: Separación de responsabilidades por capas (Models, Enums, Services, Controllers).
- **Inyección de Dependencias**: Registro desacoplado de servicios de negocio.
- **Cálculo de SLA Dinámico**: Evaluación en tiempo real del estado de cumplimiento (*OnTime*, *NearBreach*, *Breached*).
- **Swagger / OpenAPI Integration**: Documentación interactiva de la API.

## 🛠️ Stack Utilizado
- .NET 8 Web API (C#)
- ASP.NET Core MVC
- Swagger / Swashbuckle

## 📌 Ejecución Local
```bash
dotnet restore
dotnet build
dotnet run
