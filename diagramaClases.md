# Diagrama de clases

```mermaid
classDiagram
    class Pagina {
        +MostrarArticulo(string _id) Articulo
        +Buscar(string query) ArrayList~Articulo~
    }

    class Articulo {
        -string? _id
        -string titulo
        -ArrayList~string~ categorias
        -string contenido
        -string imagen
    }

    class Admin {
        -string clave
        +CrearArticulo(string titulo, string contenido, string imagen) string
        +ModificarArticulo(string _id, string titulo, string contenido, string imagen) void
        +EliminarArticulo(string _id) void 
    }

    class Repositorio {
        -string claveAdmin
        +Get(string _id) Articulo
        +GetAll() ArrayList~Articulo~
        +GetCategoria(string categoria) ArrayList~Articulo~
        +Buscar(string query) ArrayList~Articulo~
        +Agregar(Articulo articulo) _id
        +Modificar(string _id, Articulo articulo) void
        +Eliminar(string _id) void

    }

    Pagina ..> Repositorio
    Pagina ..|> Articulo
    Repositorio "1"-->"*" Articulo : articulos
    Admin ..> Repositorio
    Admin ..|> Articulo

```

## Este es un renglón nuevo

Test cambio
Test cambio2
