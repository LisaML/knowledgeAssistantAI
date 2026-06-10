Documento técnico
Tecnologías utilizadas en el proyecto:
backend
-	.NET 10
-	ASP.NET Core Web API
-	Entity Framework Core
Frontend
-	Angular 18
-	TypeScript
Base de datos
-	SQL Server
-	SQL Server Express
Inteligencia artificial
-	Gemini API
Pruebas
-	xUnit
-	Angular Testing Framework
Control de versiones
-	GitHub
-	Git

API REST
La solución expone un API REST versionada mediante el url: /api/v1
Principales controladores:
BusinessRecordsController
Operaciones:
-	GET
-	POST
-	PUT
-	DELETE
-	Búsquedas
-	Filtros
AIController
Operaciones:
-	Análisis automático
-	Preguntas en lenguaje natural

Persistencia
	La aplicación utiliza Entity Framework Core como ORM, la base de datos fue creada mediante migraciones, evitando la creación manual, se incluyen el historial de migraciones, el script de creación, la relación de entidades.
Seguridad
	Se implementaron medidas de seguridad como validaciones de entrada (en backend como required, maxLength y en frontend como validaciones con Angular), la protección de información sensible con el archivo de gitignore.
Automatización
	Esta solución incorpora BackgroundServices con un funcionamiento:
	1 detectar registros sin análisis.
	2 ejecutar automáticamente procesos de IA
	3 generar: resumen, clasificación y recomendación.
Pruebas
	Se implementaron pruebas automatizadas con xUnit validando entidades, reglas de negocio, comportamientos principales, servicios y flujos básicos de usuarios.
