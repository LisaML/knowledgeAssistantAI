Documento de pruebas

El objetivo de las pruebas fue verificar el correcto funcionamiento de los componentes principales de las soluciones, las reglas de negocio y validaciones implementadas.
Pruebas de backend
Se desarrollaron utilizando xUnit en donde se verificaron los siguientes escenarios:
-	Validación de BusinessRecord
Se cubrieron los casos de registro válido, y registro sin título. Con el objetivo de comprobar validaciones implementadas.
-	Validación de AskRequest: se cubrieron los casos de solicitud válida y solicitud sin pregunta. Garantizando la correcta validación de las consultas del usuario.
Resultados
Ejecución: Dotnet test
Resultado: total de pruebas 5, pruebas exitosas 5

Pruebas frontend
Se realizaron pruebas utilizando Angular Testing Framework verificando:
-	App: la creación del componente.
-	Dashboard: la carga del dashboard principal.
-	Records: se validó la creación del componente encargado de visualizar registros.
-	RecordForm: validando la creación del formulario.
-	Chat: se verifica el componente utilizando preguntas en lenguaje natural.
-	BusinessRecordService: se verificó la creación del servicio que consume el API
Resultados
Ejecución: ng test
Resultados: total de pruebas 7, pruebas exitosas 7


Se prioritizó la validación de los componentes críticos del sistema, se buscó garantizar la estabilidad.
