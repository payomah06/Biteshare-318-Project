# BiteShare

A collaborative food ordering platform that lets a group build a shared cart in real time, split the bill fairly, and track order status together — built for the Web Applications & Services course.

## The problem
Group food orders are chaotic: someone collects orders over text, math gets messy splitting the bill, and nobody knows when the food's actually arriving. BiteShare fixes this with a live shared session — everyone adds their own items to a cart in real time, costs split automatically, and status updates push to everyone at once.

## Core features
- **Session creation & invite links** — a host spins up a session, participants join via link (with a guest/no-account flow)
- **Live collaborative cart** — everyone in a session sees cart adds/removes/updates in real time via SignalR
- **Smart cost splitter with PDF receipts** — subtotal/tax/tip/delivery-fee split (equal or per-item), itemized receipt generated as a PDF
- **Real-time order status tracking** — confirmed → preparing → out for delivery → delivered, pushed live to all participants

## Tech stack
| Layer | Technology |
|---|---|
| API | ASP.NET Core Web API |
| Frontend | Blazor WebAssembly |
| Real-time | SignalR |
| Data | EF Core + Azure SQL |
| Payments | Stripe .NET SDK |
| PDF generation | QuestPDF (or similar) |
| Hosting / CI-CD | Azure App Service, GitHub Actions |
| Testing | bUnit / Playwright, xUnit |

## Solution structure
```
BiteShare.Api/       # Web API — controllers, endpoints, SignalR hub
BiteShare.Client/     # Blazor WASM frontend
BiteShare.Shared/     # DTOs/models shared by Api + Client
BiteShare.Data/       # EF Core context + migrations
BiteShare.Tests/      # Unit, integration, E2E tests
```

## Data model (core entities)
`Session`, `Participant`, `MenuItem`, `CartItem`, `Order`, `Receipt` — schema is locked after full-team review before migrations are written (schema changes later in the project are expensive).

## Getting started

### Prerequisites
- .NET SDK (matching the project's target version)
- SQL Server / Azure SQL access (or local dev DB)
- Git + a GitHub account added as a repo collaborator

### Clone and build
```bash
git clone https://github.com/<org>/BiteShare.git
cd BiteShare
dotnet restore
dotnet build
```

### Run locally
```bash
# API
cd BiteShare.Api
dotnet run

# Client (separate terminal)
cd BiteShare.Client
dotnet run
```
Swagger/OpenAPI docs are live at the API's `/swagger` endpoint once auth + scaffolding land (Phase 1).

### Before you branch
Read `CONTRIBUTING.md` for branching, commit format, and PR process. Every branch maps to a Jira ticket.

## Team & ownership
12-person team split across:
- **Foundations / DevOps** — Priscilla (Azure, CI/CD), Somuah (Jira/backlog), Stephanie (standards, docs)
- **Data & Auth** — Roselyn (schema), Horoya (auth/JWT/guest flow), Kingsella (API scaffolding)
- **Stream A — Collaborative Cart** — Aaron (SignalR hub), Precious (cart UI)
- **Stream B — Cost Splitter & Receipts** — Kingsella + Roselyn
- **Stream C — Order Status & Payments** — Olivia (Stripe), Horoya (status pipeline)
- **Design consistency** — Joseph (component library, nav, role-aware views across all streams)
- **QA** — Obadiah (test automation, bug bash coordination)

## Project timeline (12-week / 6-sprint plan)
| Phase | Weeks | Focus |
|---|---|---|
| 0 — Foundations | 1 | Repo, Azure skeleton, Jira board, standards doc |
| 1 — Data & Auth | 2–3 | EF Core schema, Identity/JWT, API scaffolding |
| 2 — Core Feature Build | 4–7 | Cart, Splitter, Payments (parallel streams) |
| 3 — QA & Hardening | 8–9 | Test automation, bug bash, edge cases |
| 4 — Deployment & Docs | 10–11 | Production CI/CD, final documentation |
| 5 — Demo Prep | 12 | Live demo script, fallback recording |

## Key risks
- **SignalR + Blazor WASM reconnect logic** — the trickiest part of the project; prototype early (Week 4), not late
- **Schema changes after Week 2** — get full-team review before migrations; changes later are costly
- **Shared code drift** — `BiteShare.Shared` and `OrderHub` are touched by three concurrent streams; flag changes in the team channel before merging
- **Scope creep** — with 12 people, the risk isn't manpower, it's each sub-team over-building; Scrum Master and Project Lead actively cut scope

## Contributing
See `CONTRIBUTING.md` for branching strategy, commit conventions, and the PR/review process. All PRs use `.github/PULL_REQUEST_TEMPLATE.md` and require 2 approvals before merging into `main`.
