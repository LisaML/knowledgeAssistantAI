Documento de arquitectura:

Información general

Knowledge Assistant AI es una herramienta web empresarial diseñada para administrar información y enriquecerla con inteligencia artificial.

La solución permite:
- Registrar información empresarial.
- Consultar registros.
- Buscar y filtrar información.
- Editar y eliminar registros.
- Generar resúmenes automáticos.
- Clasificar información con inteligencia artificial.
- Generar recomendaciones.
- Realizar preguntas por medio de un chat.

Arquitectura de la solución:

La arquitectura del proyecto se divide por capas y aplica principios de separación de capas.

-Capa de presentación
Se utilizaron tecnologías como:
    Angular 18
    TypeScript

La capa cuenta con responsabilidades como la interacción con el usuario, formularios de captura y actualización, dashboards, búsquedas y filtros.

Componentes principales:
    Dashboard
    Records
    RecordForm
    Chat

- Capa API
Se utilizaron tecnologías como:
    ASP.NET Core Web API
    Swagger / OpenAPI

La capa cuenta con responsabilidades como exposición de endpoint Rest, validación de entradas, manejo de errores y el versionamiento de la API.

Controladores principales:
    BusinessRecordsController
    AIController

- Capa de negocio
En la capa de negocio se implementaron las reglas de negocio proporcionadas, así como la ejecución de prompts, el procesamiento con inteligencia artificial y las tareas de automatización

Los servicios principales de la capa son:
    GeminiAIService
    AIAnalysisBackgroundService

- Capa de persistencia
Se utilizaron herramientas como:
    Entity Framework Core
    SQL Server

Entidades principales:
    BusinessRecord
    AIAnalysis

Flujo General 
    usuario -> angular -> ASP .NET Core Web API -> 
    -> Entity Framework Core -> SQL Server ->
    -> Gemini API -> respuesta usuario



