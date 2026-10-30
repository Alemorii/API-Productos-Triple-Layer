# Productos API

Web API RESTful de gestión de productos en .NET, con arquitectura en 3 capas, DTOs, validaciones con Data Annotations y datos en memoria.

Práctico del Bloque 2 (evolución del prototipo de consola del Bloque 1).

## Endpoints

| Método | Ruta | Respuestas |
|---|---|---|
| GET | `/api/productos` | `200` con la lista de productos |
| GET | `/api/productos/{id}` | `200` o `404` |
| POST | `/api/productos` | `201` (`CreatedAtAction`) o `400` |
| PUT | `/api/productos/{id}` | `200`, `404` o `400` |
| DELETE | `/api/productos/{id}` | `204` o `404` |
