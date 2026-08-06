# BiteShare

BiteShare is a collaborative group-ordering app: a host opens a session, participants join and build a shared cart in real time, the host submits the order, payment is captured per participant, and everyone gets live status updates through to delivery.

## Tech stack

| Layer | Tech |
|---|---|
| API | ASP.NET Core Web API (minimal API / controllers) |
| Client | Blazor WebAssembly |
| Shared | Common DTOs/models used by API and Client |
| Data | EF Core + Azure SQL |
| Real-time | SignalR (`OrderHub`) |
| Auth | ASP.NET Core Identity + JWT, plus anonymous guest-participant tokens |
| Payments | Stripe .NET SDK |
| Hosting | Azure App Service, deployed via GitHub Actions |

## Solution layout

```
BiteShare.sln
src/
  BiteShare.Api/       ASP.NET Core Web API, controllers, SignalR hub
  BiteShare.Client/    Blazor WebAssembly front end
  BiteShare.Shared/    DTOs and models shared by Api and Client
  BiteShare.Data/      EF Core DbContext + migrations
tests/
  BiteShare.Tests/     Unit + integration tests
```

## Getting started

```bash
git clone <repo-url>
cd BiteShare
dotnet restore
dotnet build
```

Run the API:

```bash
dotnet run --project src/BiteShare.Api
```

Run the Blazor client (in a second terminal):

```bash
dotnet run --project src/BiteShare.Client
```

Apply EF Core migrations (once the schema is in place):

```bash
dotnet ef database update --project src/BiteShare.Data --startup-project src/BiteShare.Api
```

Run tests:

```bash
dotnet test
```

## Configuration

The API reads connection strings and secrets from `appsettings.json` for local defaults and user-secrets / Azure App Configuration for anything sensitive (SQL connection string, JWT signing key, Stripe keys). Never commit real secrets — see `.gitignore`.

```bash
dotnet user-secrets init --project src/BiteShare.Api
dotnet user-secrets set "ConnectionStrings:Default" "<your-local-connection-string>" --project src/BiteShare.Api
dotnet user-secrets set "Stripe:SecretKey" "<your-test-key>" --project src/BiteShare.Api
```

## Team & roles

See `CONTRIBUTING.md` for coding standards, branching, and PR process, and the project execution guide for the full phase-by-phase plan and role assignments.

## Core domain model

`Session → Participant → CartItem → Order → Receipt`, with `MenuItem` as the catalog a session's cart draws from. Schema lives in `BiteShare.Data`.

## CI/CD

GitHub Actions (`.github/workflows/azure-deploy.yml`) builds, tests, and deploys to Azure App Service on merge to `main`.
