# Programming IV: Exercises and Projects

A collection of ASP.NET MVC and Web API exercises developed for **Programming IV** at Universidad de las Américas (UDLA). Each folder is an independent assignment that documents a specific stage of the course: MVC fundamentals, Razor views, Entity Framework 6 Code First with LocalDB, Web API 2 services, and consuming an external API from a server-rendered application.

The legacy projects are built and run with Visual Studio and IIS Express, use Bootstrap for the interface, and keep NuGet dependencies in the classic `packages.config` format. The newer `S2_P4` exercise targets ASP.NET Core and can also be built and launched with the .NET CLI. Most user-facing text, comments, and many identifiers are written in **Spanish** (`Estudiante`, `Nombre`, `Domadores`), matching the language of the course.

---

## Core Topics Covered

- **ASP.NET MVC 5** — controllers, actions, Razor views, routing, layouts and partials
- **ASP.NET Core MVC** — the same MVC concepts on the modern SDK-style project system (`net10.0`)
- **Entity Framework 6 Code First** — `DbContext`, `DbSet`, data annotations, migrations, LocalDB
- **CRUD operations and server-side validation** — `ModelState`, `[Required]`, `[Range]`, anti-forgery tokens, `[Bind]`
- **ASP.NET Web API 2** — REST resources, `IHttpActionResult`, JSON and XML formatting, HelpPage
- **Consuming a third-party API** — `HttpClient` with `async`/`await`, `Task.WhenAll` for parallel requests, TLS 1.2, error handling
- **Bootstrap 5** — responsive tables, cards, form controls, custom CSS layouts
- **Visual Studio / IIS Express workflow** — project properties, ports, NuGet restore with `packages.config`

---

## Repository Structure

```text
Programacion---IV/
├── S1-P4/                          # Week 1 – Static product catalog
│   ├── S1-P4.slnx
│   ├── packages/                   # NuGet restore target (gitignored)
│   └── S1-P4/
│       ├── Controllers/            # Home, Producto
│       ├── Models/                 # Producto
│       ├── Views/                  # Home, Producto, Shared
│       └── Web.config
│
├── S2_P4/                          # Week 2 – Client / comic / game catalogs
│   ├── S2_P4.slnx
│   └── S2_P4/
│       ├── Controllers/            # Home, Cliente, Comics, Videojuegos
│       ├── Models/
│       ├── Views/
│       ├── wwwroot/                # Bootstrap, jQuery, site CSS
│       └── Program.cs
│
├── S3_P4/                          # Week 3 – Student CRUD (EF6 Code First)
│   ├── S3_P4.slnx
│   ├── packages/
│   └── S3_P4/
│       ├── Controllers/            # Home, Estudiantes
│       ├── Migrations/             # Configuration + InitialCreate
│       ├── Models/                 # Estudiante, AppDbContext
│       └── Views/
│
├── S6_P4/                          # Week 6 – Star Wars explorer (SWAPI)
│   ├── S6P4.slnx
│   ├── packages/
│   └── S6P4/
│       ├── Controllers/            # Home, StarWars
│       ├── Models/                 # SWAPI DTOs and view models
│       └── Views/
│           ├── Shared/_LayoutHolo.cshtml
│           └── StarWars/           # Index, Detalle
│
├── S7_P4/                          # Week 7 – Digimon REST API
│   ├── ApiDigimon.slnx
│   ├── packages/
│   └── ApiDigimon/
│       ├── App_Start/              # WebApiConfig, RouteConfig, solicitudes.http
│       ├── Areas/HelpPage/         # Web API HelpPage
│       ├── Controllers/            # Domadores, Digimon
│       ├── Models/                 # Domador, Digimon, DigimonContext
│       └── Web.config
│
├── ExamP1/                         # Midterm exam – Sailor Moon CRUD
│   └── S1_SailorMoon/
│       ├── S1_SailorMoon.slnx
│       ├── packages/
│       └── S1_SailorMoon/
│           ├── Controllers/        # Home, SailorSenshis, Aliadoes
│           ├── Migrations/         # Configuration + Inicial
│           ├── Models/             # SailorSenshi, Aliado, SailorMoonContext
│           └── Views/
│
├── AGENTS.md                       # Working notes for AI agents in this repo
└── README.md
```

Every folder is a **standalone solution** with its own `.slnx` file and its own `packages/` restore target. There is no root solution, no shared library, no test project, and no CI pipeline — each assignment is self-contained and can be opened on its own.

The numbering follows the course weeks. Weeks 4 and 5 are not part of this repository, and `ExamP1` holds the midterm exam (the Sailor Moon CRUD application), so its internal project is named `S1_SailorMoon` rather than after the folder. Two project names are irregular: `S6P4` (no underscore) and `ApiDigimon`.

---

## Exercises

| Folder | Topic | Stack | Database |
| --- | --- | --- | --- |
| `S1-P4` | Product catalog (Week 1) | ASP.NET MVC 5, .NET Framework 4.7.2 | None — in-memory list |
| `S2_P4` | Client / comic / game catalogs (Week 2) | ASP.NET Core MVC, `net10.0` | None — static lists |
| `S3_P4` | Student CRUD (Week 3) | ASP.NET MVC 5, EF6, .NET Framework 4.7.2 | LocalDB `S3_P4` |
| `S6_P4` | Star Wars character explorer (Week 6) | ASP.NET MVC 5, .NET Framework 4.8, `HttpClient` | None — live SWAPI |
| `S7_P4` | Digimon REST API (Week 7) | ASP.NET Web API 2, EF6, .NET Framework 4.8 | LocalDB `DigimonDB` |
| `ExamP1` | Sailor Moon CRUD (midterm exam) | ASP.NET MVC 5, EF6, .NET Framework 4.7.2 | LocalDB `S1_SailorMoon` |

### S1-P4 — Product Catalog (Week 1)

**What it does:**

1. The default route (`{controller}/{action}/{id}`) resolves to `Home/Index`, so the site opens on the standard MVC start page.
2. Requesting `/Producto` invokes `ProductoController.Index`.
3. `Index` builds an in-memory `List<Producto>` with three items: Laptop (850.00), Mouse (20.50) and Teclado (35.00). Nothing is persisted.
4. The action returns `View(productos)`, and `Views/Producto/Index.cshtml` receives `IEnumerable<S1_P4.Models.Producto>`.
5. The view renders a Bootstrap table with the columns **ID**, **Nombre** and **Precio**, formatting the price with `ToString("C")` so it uses the server's currency format.
6. If the list were empty, the view shows the fallback message *"No hay productos disponibles."* instead of an empty table.
7. There is no database, no form, and no mutation: the assignment is a static, read-only catalog.

**How to run it:**

1. Open `S1-P4/S1-P4.slnx` in Visual Studio (use a version that supports the `.slnx` solution format).
2. Allow NuGet restore to recreate the `packages/` folder (it is gitignored).
3. Press **F5**; IIS Express starts the site at <https://localhost:44310>.
4. Navigate to `/Producto` to see the table — the shared layout only links *Inicio*, *Acerca de* and *Contacto*, so the catalog is reached by URL.

### S2_P4 — Multiple Catalogs (Week 2)

**What it does:**

1. This is an SDK-style ASP.NET Core MVC project (`net10.0`) with the conventional `Program.cs` pipeline: controllers with views, HTTPS redirection, and the default route `{controller=Home}/{action=Index}/{id?}`.
2. `ClienteController` holds a `static List<Cliente>` with 11 sample clients (id, name, ID number, address, age, e-mail).
3. `ComicsController` holds a `static List<Comic>` with 11 comics (title, author, publisher, page count, price).
4. `VideojuegosController` holds a `static List<Videojuego>` with 9 games (title, platform, price).
5. Each controller exposes a single `Index` action that passes its list to a Razor view, which renders a Bootstrap table (`table table-striped`).
6. Routes: `/Cliente`, `/Comics` and `/Videojuegos`. As in Week 1, the data lives in memory and the pages are read-only.
7. The three model classes have non-nullable `string` properties and the project enables nullable reference types, so the compiler reports `CS8618` warnings on them. All three are pre-existing and expected.

**How to run it:**

1. From the repository root:

   ```bash
   dotnet run --project S2_P4/S2_P4/S2_P4.csproj
   ```

2. Open <http://localhost:5163> (the first launch profile). The HTTPS profile listens on <https://localhost:7250> and also on port 5163.
3. Browse to `/Cliente`, `/Comics` or `/Videojuegos`. The shared layout links only Home and Privacy, so the catalogs are reached by URL.
4. To verify compilation only:

   ```bash
   dotnet build S2_P4/S2_P4.slnx
   ```

### S3_P4 — Student CRUD (Week 3)

**What it does:**

1. `Models/Estudiante.cs` defines the entity with `estudianteId` (`[Key]`), `nombre` (`[Required]`), `edad` (`[Range(17, 99)]`) and `carrera`.
2. `Models/AppDbContext.cs` derives from `DbContext`, reads the connection string named `AppDbContext`, and exposes `DbSet<Estudiante>`.
3. The migration `202610130034122_InitialCreate` creates `dbo.Estudiantes` with the key as an identity column.
4. `EstudiantesController.Index` queries `db.Estudiantes.ToList()` and renders the list.
5. `Details` returns `400 Bad Request` for a missing id and `404` when the record does not exist.
6. `Create` (GET) shows the form; `Create` (POST) is decorated with `[ValidateAntiForgeryToken]` and `[Bind(Include = "estudianteId,nombre,edad,carrera")]`, checks `ModelState.IsValid`, saves, and redirects to `Index`.
7. `Edit` (GET/POST) uses the same binding and validation pattern, marking the entity as `EntityState.Modified` before saving.
8. `Delete` (GET) shows a confirmation page; `DeleteConfirmed` (POST) removes the row. Both POST actions require an anti-forgery token.
9. The controller implements `Dispose` to release the `DbContext`.

**How to run it:**

1. Open `S3_P4/S3_P4.slnx` in Visual Studio and let NuGet restore finish.
2. Open **Tools → NuGet Package Manager → Package Manager Console**, set the default project to `S3_P4`, and run:

   ```powershell
   Update-Database
   ```

   This applies `InitialCreate` and creates the `S3_P4` database in `(localdb)\MSSQLLocalDB`.
3. Press **F5**; IIS Express starts at <https://localhost:44339>.
4. Navigate to `/Estudiantes` to list, create, edit, view and delete students.

### S6_P4 — Star Wars Character Explorer (Week 6)

**What it does:**

1. The default route is remapped to `StarWars/Index` instead of `Home/Index`, so the explorer is the landing page.
2. `StarWarsController` keeps a single `static readonly HttpClient` pointed at `https://www.swapi.tech/api/`, with a 30-second timeout and a JSON `Accept` header. The static `CrearCliente()` factory forces TLS 1.2, which this endpoint requires on .NET Framework.
3. `Index(string q = null, int pagina = 1)` requests `people/?page={pagina}&limit=10`, ten characters per page.
4. When `q` is supplied, the action calls `people/?name={q}` instead, which returns the matching records directly and disables pagination.
5. For the paginated list, the action collects the returned `uid` values and fetches every character's detail **in parallel** with `Task.WhenAll` rather than awaiting them one by one; each card then shows the character's name and a translated gender chip, and links to the detail page.
6. `HttpRequestException`, `TaskCanceledException` (timeout) and `JsonException` are caught and converted into a readable error message instead of a crash.
7. `Detalle(string id)` loads one character and then makes a second call for its homeworld planet; a missing planet is tolerated as an optional value.
8. The two Star Wars views opt into a custom sci-fi layout (`Views/Shared/_LayoutHolo.cshtml`) with search box, pagination controls, character cards and a detail panel. The rest of the site keeps the default layout.
9. Nothing is stored locally: every page view is a live call to SWAPI, so the app needs outbound internet access.

**How to run it:**

1. Open `S6_P4/S6P4.slnx` in Visual Studio and restore NuGet.
2. Press **F5**; IIS Express starts at <https://localhost:44365> and loads the character list.
3. Use the search field (submitted as `?q=`) or the previous/next pagination links.
4. Example URLs:

   ```text
   https://localhost:44365/StarWars?q=luke
   https://localhost:44365/StarWars/Detalle/1
   ```

5. If the page shows a connection or timeout alert, the cause is network access to `swapi.tech`, not the build.

### S7_P4 — Digimon Web API (Week 7)

**What it does:**

1. This is an ASP.NET Web API 2 project with the standard web host: `Global.asax` registers `WebApiConfig`, MVC routes and bundles.
2. `Models/DigimonContext.cs` derives from `DbContext`, uses the connection string `DigimonConnection`, and exposes `DbSet<Domador> Domadores` and `DbSet<Digimon> Digimones`.
3. `DomadoresController` (`/api/domadores`) implements GET all, GET by id, POST, PUT and DELETE. POST validates `ModelState`, saves, and returns `201 Created` through `CreatedAtRoute`; PUT updates the existing entity's fields; DELETE returns a confirmation message.
4. `DigimonController` (`/api/digimon`) implements the same five operations for the `Digimon` entity (`DigimonId`, `Nombre`, `Etapa`).
5. Missing records return `404 Not Found`; invalid payloads return `400 Bad Request` with the model state.
6. `WebApiConfig` enables both formatters: JSON on `application/json` and XML on `application/xml`, with `UseXmlSerializer = true` so plain XML without namespace prefixes is accepted and produced.
7. The Web API HelpPage is registered as an area and documents every action at `/help`.
8. There are no migrations in this project: EF creates `DigimonDB` on first use. Later model changes are **not** applied to an existing database — drop and recreate it, or add migrations.
9. Ready-to-send requests for every endpoint, in JSON and XML, live in `S7_P4/ApiDigimon/App_Start/solicitudes.http`.

**How to run it:**

1. Open `S7_P4/ApiDigimon.slnx` in Visual Studio and restore NuGet.
2. Press **F5**; IIS Express starts at <https://localhost:44352>.
3. Send a first request to `/api/domadores` — EF creates `DigimonDB` in LocalDB at that point.
4. Open <https://localhost:44352/help> to browse the generated API documentation.
5. Replay the requests from `S7_P4/ApiDigimon/App_Start/solicitudes.http` (GET, POST, PUT, DELETE against `/api/domadores` and `/api/digimon`).

### ExamP1/S1_SailorMoon — Midterm Exam CRUD

**What it does:**

1. `Models/SailorSenshi.cs` defines `Id` (`[Key]`), `Nombre` (`[Required]`), `Planeta`, `NivelPoder` (`[Range(1, 100)]` with a Spanish error message) and `HabilidadEspecial`.
2. `Models/Aliado.cs` defines `Id` (`[Key]`), `NombreAliado` (`[Required]`), `Tipo`, `Edad` (`[Range(1, 10000)]`) and `SailorSenshiId`, which links the ally to a senshi.
3. `Models/SailorMoonContext.cs` reads the connection string `SailorMoonContext` and exposes both `DbSet<SailorSenshi> SailorSenshis` and `DbSet<Aliado> Aliados`.
4. The migration `202610200113167_Inicial` creates `dbo.SailorSenshis` and `dbo.Aliadoes`.
5. `HomeController.Index` opens the context, loads both lists ordered by name, and puts them in `ViewBag.SailorSenshis` and `ViewBag.Aliados`.
6. `Views/Home/Index.cshtml` renders a dashboard with two Bootstrap cards and tables, an empty-state row per table, and *Detalle / Editar / Eliminar* action links. The allies table resolves `SailorSenshiId` to a name, showing *"No asignada"* when the link is broken.
7. `SailorSenshisController` and `AliadoesController` provide full CRUD with GET/POST pairs, `[ValidateAntiForgeryToken]` on every POST, and `[Bind]` whitelists that match each entity's fields.
8. Validation errors are surfaced by the Razor form helpers (`ValidationMessageFor`, `ValidationSummary`), so the range and required rules are enforced server-side.

**How to run it:**

1. Open `ExamP1/S1_SailorMoon/S1_SailorMoon.slnx` in Visual Studio and restore NuGet.
2. In the Package Manager Console, set the default project to `S1_SailorMoon` and run:

   ```powershell
   Update-Database
   ```

   This creates the `S1_SailorMoon` database in LocalDB with both tables.
3. Press **F5**; IIS Express starts at <https://localhost:44382> and shows the dashboard.
4. Use the *Añadir* buttons and the row action links to create, inspect, edit and delete senshis and allies.

---

## Getting Started

### Prerequisites

- **Visual Studio** with the **ASP.NET and web development** workload and support for the `.slnx` solution format
- **.NET Framework 4.7.2 and 4.8 targeting packs** (required by all legacy projects except `S2_P4`)
- **.NET 10 SDK** for `S2_P4`
- **SQL Server LocalDB** for `S3_P4`, `S7_P4` and `ExamP1`
- **Git**
- **Internet access** for `S6_P4`, which calls the live SWAPI endpoint

### Installation

```bash
git clone https://github.com/MathiusEc/Programacion---IV.git
cd Programacion---IV
```

### Opening a Project

Each folder is self-contained, so open one solution at a time:

1. Open the `.slnx` file of the exercise you want to work on in Visual Studio.
2. Wait for NuGet restore to finish — legacy projects need it to recreate `packages/`.
3. Confirm the web project is set as the startup project (right-click → **Set as Startup Project** if needed).
4. Press **F5** and use the IIS Express URL listed for that exercise.

`S2_P4` also runs from the CLI with `dotnet run --project S2_P4/S2_P4/S2_P4.csproj`.

### Building from the Command Line

Legacy (non-SDK) web projects cannot be built with `dotnet build`: it fails with `MSB4019` because `Microsoft.WebApplication.targets` is only available to the full MSBuild that ships with Visual Studio. Use a **Developer PowerShell** and the `msbuild` on `PATH`:

```powershell
msbuild S3_P4/S3_P4.slnx /t:Build /p:Configuration=Debug
```

The SDK-style project builds with the .NET CLI:

```bash
dotnet build S2_P4/S2_P4.slnx
```

### Legacy Project First Build (Roslyn)

All exercises except `S2_P4` target .NET Framework and restore NuGet packages through `packages.config`. On a fresh clone, Visual Studio may restore the packages but fail to copy the Roslyn compiler into `bin\roslyn\`, producing this build error:

```text
Could not find a part of the path ...\bin\roslyn\csc.exe
```

Fix it once per clone:

1. Open the exercise's `.slnx` solution in Visual Studio.
2. Open **Tools → NuGet Package Manager → Package Manager Console**.
3. Run:

   ```powershell
   Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -Reinstall
   ```

4. Rebuild the solution (`Ctrl + Shift + B`) and run it with IIS Express.

This applies to `S1-P4`, `S3_P4`, `S6_P4`, `S7_P4` and `ExamP1`. It does not apply to `S2_P4`. For `S3_P4` and `ExamP1`, run `Update-Database` after the rebuild to create the LocalDB database; `S7_P4` creates its database automatically on the first API request.

### Database Setup

| Project | How the database is created | Connection string |
| --- | --- | --- |
| `S3_P4` | `Update-Database` (migrations) | `AppDbContext` → `S3_P4` |
| `ExamP1` | `Update-Database` (migrations) | `SailorMoonContext` → `S1_SailorMoon` |
| `S7_P4` | Automatic on first EF use (no migrations) | `DigimonConnection` → `DigimonDB` |

For the two migrated projects, open the Package Manager Console, select the web project as default, and run `Update-Database`. For `S7_P4`, just send a request to the API. All connection strings target `(localdb)\MSSQLLocalDB` and are defined in each project's `Web.config`.

---

## Development Workflow

- **One exercise per change.** Work inside a single folder; the projects share no code, so a change in one assignment never belongs in another.
- **Keep Spanish UI text and identifiers.** New labels, messages, and domain names should follow the existing language (`Estudiante`, `Nombre`, `SailorSenshi`).
- **Respect the NuGet workflow.** Legacy projects use `packages.config` plus a per-solution `packages/` folder referenced by relative `HintPath`; `packages/` is gitignored. Restore through Visual Studio. Do **not** run `dotnet add package` on these projects — it converts them to `PackageReference` and breaks the old project system.
- **Add a migration for schema changes** in `S3_P4` and `ExamP1`. Both have `AutomaticMigrationsEnabled = false`, so an un-migrated model change will not reach the database. `S7_P4` has no migrations: drop and recreate `DigimonDB`, or introduce migrations first.
- **Building is the verification step.** There are no automated tests, linters, formatters, or CI in this repository.
- **Keep front-end assets local.** Bootstrap 5 and jQuery are vendored in each project's `Content/`/`Scripts/` (or `wwwroot/lib/` in `S2_P4`); do not replace them with CDN links.
- `S2_P4` has nullable reference types enabled; its `CS8618` warnings on model properties are pre-existing and not regressions.

---

## Academic Information

| | |
| --- | --- |
| **Institution** | Universidad de las Américas (UDLA) |
| **Course** | Programming IV |
| **Author** | MathiusEc |
| **License** | Academic Use Only |

---

<div align="center">

*"I want you to praise me for being alive!"*

**— Nico Robin**

<img src="https://i.pinimg.com/736x/77/ae/6e/77ae6ee3b4095a643d6f419220fa2d16.jpg" alt="Inspiration" width="280">

*Document updated on November 14, 2026*

</div>
