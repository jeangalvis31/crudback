
# CrudBackend

El siguiente backend se desarrolló como una API con un CRUD para gestionar la información de contacto de personas. Permite crear, leer, actualizar y eliminar registros de contactos a través de los endpoints.




## Tech Stack

**Server:** C#, .Net Core 9


## Estructura

La estructura del proyecto se basa en una arquitectura en 4 capas:

* API: Interfaz externa de la aplicación. Aquí se gestionan las rutas HTTP, validaciones de entrada (DTOs), controladores y helpers que responden al cliente
* Application: Define la lógica de aplicación, , los contratos de repositorio y la unidad de trabajo.
* Domain: Contiene las entidades de negocio y sus interfaces. 
* Persistence: Implementa los detalles de infraestructura (ORM, base de datos, migraciones).



## Flujo

#### 1. Envío de una solicitud HTTP
Se realiza una petición a /api/contacts

#### 2. Capa API
- El controlador recive la petición, los Dtos validan y estructuran los datos entrantes y el mapper transforma el Dto en una entidad.
- Una vez el proceso anterior pasa, el controller crea una instancia de la unidad de trabajo y llama al repositorio a traves de ella, se ejecuta la funcion del crud y posteriormente se guardan los cambios con el saveAsync en caso de ser necesario.

#### 3. Capa Application

- en esta capa la unidad de trabajo implementa la interfaz de la misma que se encuentra en la capa dominio, crea una instancia del repositrio si no ha sido creada y lo expone a traves de una propiedad y gracias al context puede interactuar con la base de datos.

#### 4. Capa Domain

- Esta capa se determina la logica del negocio, se definen las entidades y las interfaces, tanto de las entidades como la de la unidad de trabajo.

#### 5. Capa de persistencia

- Esta capa interactua con la base de datos y se define la clase que hereda del dbcontext, en ella estan los dbsets que representan las tablas en la base de datos
- Tambien se encuentran las configuraciones y aca se determina como las entidades que estan en la capa domain se traducen a tablas de la base de datos
- por ultimo se encuentran las migraciones que son archivos que genera EntityFramework Core que contienen la logica para crear y modificar las tablas de la base de datos y se generan gracias a las EntityFramework Tools

## Authors

- [@jeangalvis31](https://www.github.com/jeangalvis31)

