Documento Operativo
Objetivo
Este documento describe los pasos necesarios para ejecutar la solución Knowledge Assistant AI.
Requisitos
Backend
•	.NET 10 SDK
•	SQL Server Express o SQL Server LocalDB
Frontend
•	Node.js
•	Angular CLI

Clonar el Repositorio
git clone < https://github.com/LisaML/knowledgeAssistantAI.git>

Configuración del Backend
Ingresar al proyecto:
cd KnowledgeAssistant.API
Restaurar dependencias:
dotnet restore

Configuración de la Base de Datos
Aplicar migraciones:
dotnet ef database update
Opcionalmente puede utilizarse el script:
Scripts/database-create.sql

Configuración de la Inteligencia Artificial
La llave de acceso a Gemini se almacena en:
appsettings.Development.json
Ejemplo:
{
  "Gemini": {
    "ApiKey": "API_KEY"
  }
}
Este archivo se encuentra excluido del repositorio mediante:
.gitignore

Ejecución del Backend
dotnet run
La API estará disponible en:
http://localhost:5020
Swagger:
http://localhost:5020/swagger

Configuración del Frontend
Ingresar al proyecto:
cd knowledgeAssistantUI
Instalar dependencias:
npm install

Ejecución del Frontend
ng serve
La aplicación estará disponible en:
http://localhost:4200

Ejecución de Pruebas
Backend
dotnet test

Frontend
ng test

Automatización
La solución incluye un BackgroundService.
Su función consiste en:
	Detectar registros sin análisis.
	Ejecutar automáticamente procesos de Inteligencia Artificial.
	Generar:
	Resumen.
	Clasificación.
	Recomendaciones.
Los resultados son almacenados en SQL Server.

Componentes Principales
La aplicación está compuesta por:
Dashboard
Visualización general de información.
Records
Administración de registros empresariales.
RecordForm
Captura y edición de información.
Chat
Consultas en lenguaje natural.

Servicios Principales
Backend
•	GeminiAIService
•	AIAnalysisBackgroundService
Frontend
•	BusinessRecordService
•	AiService
