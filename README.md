# Sistema de Gestión de Reservas Aéreas

**Asignatura:** Programación en C# (`cs-`)

---

Aplicación de escritorio desarrollada en C# con Windows Forms para la administración centralizada de operaciones aerocomerciales, integrando persistencia relacional en un servidor MySQL para el procesamiento seguro de vuelos, pasajeros y el control transaccional de reservas en tiempo real.

## Arquitectura del Sistema

El sistema implementa una arquitectura multicapa desacoplada que asegura el aislamiento de la lógica de negocio, el cumplimiento de políticas comerciales y la consistencia de los datos persistidos:

* **Control y Seguridad (Capa de Control):** Gestión del acceso seguro al entorno mediante `Encript.cs`. Implementa criptografía basada en el algoritmo SHA-256 para transformar y validar las credenciales de los operadores contra los registros de la base de datos, evitando el almacenamiento en texto plano.
* **Capa de Datos y Persistencia:** Aislamiento de las consultas y transacciones relacionales mediante clases de acceso dedicadas (`Conexion.cs`, `PasajeroDatos.cs`, `VueloDatos.cs`, `ReservaDatos.cs` y `ReporteDatos.cs`). Esta estructura interactúa directamente con el motor MySQL, garantizando un comportamiento transaccional síncrono que actualiza estados, calcula tarifas base y procesa los puntajes de fidelización sin descuadres en el sistema.
* **Interfaz de Usuario (Vistas):** Inicialización del entorno gráfico controlada por `Program.cs`, desplegando el contenedor principal `FrmPrincipal.cs` previo paso por la autenticación en `FormLogin.cs`. Los flujos operativos se aíslan en componentes modulares *User Controls* (`UC_Vuelos.cs`, `UC_Pasajeros.cs`, `UC_GenerarReserva.cs`, `UC_Consultas.cs` y `UC_ListadoGeneral.cs`) encargados de ejecutar las reglas de negocio en la interfaz, tales como la normalización y validación de formatos de RUT, la captura de excepciones relacionales y la restricción estricta de modificaciones sobre pasajes emitidos en tarifa económica.
