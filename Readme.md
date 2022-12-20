# Notas de estudio

## comando de creacion proyectos

dotnet new sln para crear un proyecto vacio
dotnet new classlib para crear una nueva libreria --name NOMBRELIBRERIA
dotnet add reference app/app.csproj reference lib/lib.csproj add a reference

## Estructura de proyecto

src
--api
--core
----solidcleanarchitecture.clean.domain
--infracture
--Ui
test

## notas

-- es mala idea interactura directamente informacion entre la bases de datos y la api por eso se usan los dtos(data transfer objects)

## pasos para configurar automaper

1 - crear perfiles de mapeo para saber el origen y destino de la informacion -> MappingProfile.cs
2 - crear un servicio para poder instanciar cada vez que se necesite -> applicationServiceRegistration.cs

## Mediatr y CQRS(command query responsability segregation)

Mediatr: ayuda a extraer la logica asociada de la peticion
CQRS: ayuda a separar las peticiones escribir y leer
