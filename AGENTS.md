# AGENTS.md

Assignments for UDLA's "Programación IV" class. Each top-level folder is a standalone ASP.NET app with its own `.slnx`; there is no root solution, shared library, test project, linter, formatter, or CI. Treat each folder as an independent assignment and do not refactor across them.

## Projects

| Path | What it is | Stack | Local URL |
| --- | --- | --- | --- |
| `S1-P4` | Static product list | ASP.NET MVC 5, .NET Framework 4.7.2 | https://localhost:44310 |
| `S2_P4` | Static Cliente/Comic/Videojuego lists | ASP.NET Core MVC, `net10.0` | http://localhost:5163 / https://localhost:7250 |
| `S3_P4` | Estudiantes CRUD | MVC 5, EF6, migrations | https://localhost:44339 |
| `S6_P4` | Star Wars browser (live `swapi.tech`) | MVC 5, .NET Framework 4.8 | https://localhost:44365 |
| `S7_P4/ApiDigimon` | Digimon + Domadores REST API | Web API 2, EF6 | https://localhost:44352 |
| `ExamP1/S1_SailorMoon` | Sailor Moon CRUD | MVC 5, EF6, migrations | https://localhost:44382 |

The app project usually sits one level below the solution folder; note the irregular project names `S6P4` and `ApiDigimon`.

## Build

`S2_P4` is the only SDK-style project:

```powershell
dotnet build S2_P4\S2_P4.slnx
dotnet run --project S2_P4\S2_P4\S2_P4.csproj
```

Everything else is a non-SDK .NET Framework web app. `dotnet build` fails with `MSB4019` (missing `Microsoft.WebApplication.targets`); use the full MSBuild from the installed Visual Studio at `D:\IDEs\VisualStudio`:

```powershell
& "D:\IDEs\VisualStudio\MSBuild\Current\Bin\MSBuild.exe" "S3_P4\S3_P4.slnx" /t:Build /p:Configuration=Debug
```

`msbuild` is not on `PATH`. Run legacy apps through Visual Studio/IIS Express; the URLs above are their project ports.

Building is the only verification step. `S2_P4` has nullable enabled and its non-annotated model properties produce pre-existing CS8618 warnings; do not treat those as regressions.

## Dependencies and databases

- Legacy projects use `packages.config` plus per-solution `packages/` folders referenced by relative `HintPath`. `packages/` is gitignored; let Visual Studio restore it after cloning. Do not run `dotnet add package` on these projects: it switches them to `PackageReference` and breaks the old project system.
- EF6 connects to LocalDB `(localdb)\MSSQLLocalDB`. Connection strings are in each `Web.config`: `S3_P4` → `AppDbContext` / `S3_P4`, `ExamP1` → `SailorMoonContext` / `S1_SailorMoon`, `S7_P4` → `DigimonConnection` / `DigimonDB`.
- `S7_P4` has no migrations, so EF creates `DigimonDB` on first use and later model changes are not applied to an existing database (drop/recreate it or add migrations).
- `S6_P4` needs outbound HTTPS access to `https://www.swapi.tech/api/` and forces TLS 1.2; failures there are usually network/API failures, not build problems.

### EF6 migrations

`S3_P4` and `ExamP1` use Code First migrations with `AutomaticMigrationsEnabled = false`. After building, run the bundled EF6 CLI from the repo root:

```powershell
& ".\S3_P4\packages\EntityFramework.6.5.2\tools\net45\win-x86\ef6.exe" database update `
    --project-dir ".\S3_P4\S3_P4" --assembly ".\S3_P4\S3_P4\bin\S3_P4.dll" --config ".\S3_P4\S3_P4\Web.config"
```

Replace `database update` with `migrations add <Name>` for new migrations. Use the equivalent package/assembly/config paths under `ExamP1\S1_SailorMoon` for that project.

## Conventions

- UI text, comments, and many identifiers are Spanish (`Estudiante`, `Nombre`, `Domadores`). Keep new user-facing strings in Spanish.
- Bootstrap 5 and jQuery are vendored in each project's `Content/`/`Scripts/`; do not replace them with CDN links.
- `S7_P4` API request examples live in `S7_P4/ApiDigimon/App_Start/solicitudes.http`; its Web API HelpPage is at `/help`.
