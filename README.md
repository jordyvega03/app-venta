¡Con gusto! Aquí tienes un **README.md profesional** para tu backend, adaptado a tu proyecto de “app-venta”, listo para copiar, pegar y modificar a tu gusto.

---

````markdown
# app-venta

Sistema de gestión integral para tienda de **Dulces Típicos y Churrascos** (API REST .NET 9 + SQL Server).

## 🚀 Descripción

Este backend implementa un sistema de administración y venta para una tienda de productos típicos y churrascos, permitiendo:

- Gestión de churrascos y dulces típicos con modalidades avanzadas (plato, combo, etc.)
- CRUD completo de productos, inventario, combos y guarniciones.
- Endpoints RESTful agrupados por entidad.
- Relaciones profesionales entre entidades usando Entity Framework Core.
- Documentación interactiva con Swagger.

## 🧑‍💻 Tecnologías

- **.NET 9 Minimal APIs**
- **SQL Server** (soportado en contenedor Docker)
- **Entity Framework Core**
- **Swagger/OpenAPI** para documentación y pruebas
- **JetBrains Rider** (opcional Visual Studio/VSCode)

## 📦 Instalación

### 1. Clona el repositorio

```bash
git clone https://github.com/jordyvega03/app-venta.git
cd app-venta/app-venta
````

### 2. Configura la base de datos (opcional: en Docker)

```yaml
# docker-compose.yaml (extracto)
services:
  sqlserver:
    image: mcr.microsoft.com/mssql/server:2022-latest
    environment:
      - ACCEPT_EULA=Y
      - SA_PASSWORD=Admin1234
    ports:
      - 1433:1433
    volumes:
      - ./data:/var/opt/mssql
```

> **Reemplaza la contraseña si usas otra en tu string de conexión.**

Inicia el contenedor:

```bash
docker compose up -d
```

### 3. Crea tu base de datos y configura la cadena de conexión

* Por defecto, el proyecto busca una cadena llamada `DefaultConnection` en `appsettings.json` o en el entorno.
* Ejemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost,1433;Database=app_db;User Id=sa;Password=Admin1234;TrustServerCertificate=True;"
}
```

### 4. Restaura y ejecuta migraciones

```bash
dotnet tool restore
dotnet ef database update
```

### 5. Ejecuta la API

```bash
dotnet run
```

Por defecto:

* **Swagger:** [http://localhost:5000/swagger](http://localhost:5000/swagger)

---

## 📚 Endpoints principales

* `/api/churrascos` - Gestión de churrascos (CRUD)
* `/api/guarniciones` - Gestión de guarniciones (CRUD)
* `/api/dulces` - Gestión de dulces típicos (CRUD)
* `/api/combos` - Gestión de combos (CRUD)
* `/api/inventario` - Gestión de inventario (CRUD)

Todos los endpoints están **agrupados y documentados en Swagger**.

---

## 🗃️ Modelo de Base de Datos

<img width="1736" height="2176" alt="Image" src="https://github.com/user-attachments/assets/bd1c19fc-ba70-4a1f-a001-8d8817582bf9" />

### **Entidades Principales**

* **Churrasco:**

  * Id, Nombre, Precio, TipoCarne, Termino, Tamaño, Porciones
  * Relación: muchos-a-muchos con Guarniciones (`ChurrascoGuarnicion`)

* **Guarnicion:**

  * Id, Nombre

* **DulceTipico:**

  * Id, Nombre, TipoDulce, Empaque, CantidadEnCaja

* **Combo:**

  * Id, Nombre, TipoCombo, Observaciones
  * Relación: muchos-a-muchos con Churrascos (`ComboChurrasco`) y Dulces (`ComboDulce`)

* **Inventario:**

  * Id, NombreIngrediente, TipoIngrediente, Cantidad, Unidad

#### **Tablas de relación**

* `ChurrascoGuarnicion`
* `ComboChurrasco`
* `ComboDulce`

*Puedes agregar un diagrama visual aquí cuando lo tengas listo.*

---

## 🧪 Pruebas rápidas (ejemplo JSON para POST)

**Agregar churrasco:**

```json
{
  "nombre": "Churrasco Familiar",
  "precio": 175.00,
  "tipo": "Plato",
  "tipoCarne": "Puyazo",
  "termino": "Medio",
  "tamaño": "Familiar",
  "porciones": 5,
  "churrascoGuarniciones": [
    { "guarnicionId": 1, "cantidad": 2 }
  ]
}
```

**Agregar dulce típico:**

```json
{
  "nombre": "Caja de Canillitas",
  "precio": 40.00,
  "tipo": "Dulce Típico",
  "tipoDulce": "Canillitas de leche",
  "empaque": "Caja",
  "cantidadEnCaja": 12
}
```

---

## 📝 Notas adicionales

* El proyecto incluye `.gitignore` para Rider, Visual Studio y binarios de compilación.
* Puedes extender la lógica de combos y relaciones según tus necesidades.
* El modelo de datos está listo para crecer (agrega más atributos o entidades si el negocio lo requiere).

---

## 📬 Contacto

¿Dudas o mejoras?
Abre un [issue](https://github.com/jordyvega03/app-venta/issues) o haz un pull request.

---

**¡Listo para producción y para que tus compañeros desarrolladores lo usen!** 🚀

```

---

¿Quieres agregar **imagen de diagrama ER**?  
¿O necesitas una sección especial para “pruebas desde Postman” o para ejemplos de queries SQL?  
¡Solo dime y lo adapto!
```
