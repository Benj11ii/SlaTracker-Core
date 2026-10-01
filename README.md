# SlaTracker-Core 

Engine/API RESTful desarrollado en **.NET 8** para la gestión, seguimiento y cálculo automatizado de Acuerdos de Nivel de Servicio (SLA) en tickets de soporte e incidentes operativos.

---

## Arquitectura del Proyecto

El proyecto implementa principios de **Clean Architecture** y **SOLID**, separando las responsabilidades en capas desacopladas:

```text
SlaTracker-Core/
├── Controllers/
│   └── v1/
│       └── TicketsController.cs   # Endpoints RESTful con versionamiento
├── Services/
│   └── ISlaService.cs             # Lógica de negocio e inyección de dependencias
├── Models/
│   └── Ticket.cs                  # Entidad de dominio
├── Enums/
│   └── SlaStatus.cs               # Estados de cumplimiento de SLA
└── Program.cs                     # Configuración de servicios y Middleware HTTP

Reglas de Negocio (SLA Calculation)
El motor evalúa dinámicamente el porcentaje de tiempo transcurrido respecto al objetivo (TargetHours):
| Porcentaje Transcurrido | Estado SLA (SlaStatus) | Descripción |
|---|---|---|
| < 80% | OnTime | En plazo sin riesgo. |
| 80% - 99% | NearBreach | Riesgo crítico de incumplimiento (alerta activa). |
| ≥ 100% | Breached | SLA incumplido. |
API Endpoints & Ejemplos
1. Crear un Ticket
 * URL: POST /api/v1/tickets
 * Content-Type: application/json
Body Request:
{
  "title": "Caída Servidor de BD",
  "description": "Latencia crítica en cluster principal",
  "targetHours": 8
}

Response (201 Created):
{
  "id": "e3b8a1c4-8f2e-4a9b-9c1d-123456789abc",
  "title": "Caída Servidor de BD",
  "slaStatus": "OnTime"
}

2. Listar y Evaluar Tickets
 * URL: GET /api/v1/tickets
 * Response (200 OK):
[
  {
    "id": "e3b8a1c4-8f2e-4a9b-9c1d-123456789abc",
    "title": "Caída Servidor de BD",
    "description": "Latencia crítica en cluster principal",
    "createdAt": "2026-10-01T09:00:00Z",
    "targetHours": 8,
    "slaStatus": "NearBreach"
  }
]

Tech Stack & Patrones
 * Lenguaje/Framework: C# / .NET 8 (Web API)
 * Documentación: Swagger / OpenAPI 3.0
 * Patrones: Dependency Injection (Scoped), Repository-like pattern, Clean Layering.
 Ejecución Local
# Restaurar dependencias y compilar
dotnet build

# Iniciar API en servidor local
dotnet run --urls "http://localhost:5000"

# Documentación interactiva (Swagger UI)
http://localhost:5000/swagger

