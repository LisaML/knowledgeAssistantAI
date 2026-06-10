# Knowledge Assistant AI

## Resumen Ejecutivo

Knowledge Assistant AI es una plataforma web desarrollada para la gestión de información empresarial y su enriquecimiento mediante Inteligencia Artificial.

La solución permite registrar documentos, notas y registros empresariales para posteriormente generar resúmenes automáticos, clasificaciones, recomendaciones y responder preguntas en lenguaje natural utilizando Google Gemini.

---

# Arquitectura de la Solución

La aplicación implementa una arquitectura por capas.

## Frontend

* Angular 18
* TypeScript

Responsabilidades:

* Dashboard principal.
* Formularios de captura y edición.
* Búsquedas y filtros.
* Pantallas de Inteligencia Artificial.

---

## Backend

* .NET 10
* ASP.NET Core Web API

Responsabilidades:

* API REST.
* Validaciones.
* Reglas de negocio.
* Integración con IA.
* Automatización.

---

## Persistencia

* SQL Server
* Entity Framework Core

Entidades principales:

* BusinessRecord
* AIAnalysis

---

## Inteligencia Artificial

Proveedor utilizado:

* Google Gemini

Capacidades implementadas:

* Resumen inteligente.
* Clasificación automática.
* Recomendaciones.
* Preguntas en lenguaje natural.

---

# Tecnologías Utilizadas

## Backend

* .NET 10
* ASP.NET Core Web API
* Entity Framework Core

## Frontend

* Angular 18
* TypeScript

## Base de Datos

* SQL Server
* SQL Server Express / LocalDB

## Inteligencia Artificial

* Google Gemini API

## Pruebas

* xUnit
* Angular Testing Framework



---

# Instalación

## Backend

Restaurar paquetes:

```bash
dotnet restore
```

Aplicar migraciones:

```bash
dotnet ef database update
```

Ejecutar:

```bash
dotnet run
```

Swagger:

```text
http://localhost:5020/swagger
```

---

## Frontend

Instalar dependencias:

```bash
npm install
```

Ejecutar:

```bash
ng serve
```

Aplicación:

```text
http://localhost:4200
```

---

# Integración con Inteligencia Artificial

La solución utiliza Google Gemini para analizar la información almacenada.

Las capacidades implementadas son:

### Resumen Inteligente

Generación automática de resúmenes.

### Clasificación Automática

Clasificación de registros empresariales.

### Recomendaciones

Generación de sugerencias basadas en el contenido.

### Preguntas en Lenguaje Natural

Consulta de información almacenada utilizando preguntas en lenguaje natural.


# Evidencias

Las evidencias del funcionamiento se encuentran en la carpeta:

```text
Documentation\Evidencias
```


# Documentación

La documentación técnica se encuentra en:

```text
documentation
```

* Architecture.md
* Technical.md
* Operational.md
* AI.md
* Testing.md

---

# Autor

Lisa Montoya

