# BiteShare

Collaborative food ordering platform — built for Web Applications & Services.

## Tech stack
- **API:** ASP.NET Core Web API
- **Frontend:** Blazor WebAssembly
- **Real-time:** SignalR
- **Data:** EF Core + Azure SQL
- **Hosting:** Azure App Service, GitHub Actions CI/CD

## Team
12 members split across data/auth, three parallel feature streams (Cart, Splitter, Payments), design consistency, QA, DevOps, and PM/docs. See `CONTRIBUTING.md` for how we work day to day.

## Getting started (Week 1 setup)

### 1. Clone and build
```bash
git clone https://github.com/<org>/BiteShare.git
cd BiteShare
dotnet restore
dotnet build
```

### 2. Solution structure
```
BiteShare.Api/       # Web API — controllers, endpoints
BiteShare.Client/     # Blazor WASM frontend
BiteShare.Shared/     # DTOs/models shared by Api + Client
BiteShare.Data/       # EF Core context + migrations
BiteShare.Tests/      # Unit, integration, E2E tests
```

### 3. Run locally
```bash
# API
cd BiteShare.Api
dotnet run

# Client (separate terminal)
cd BiteShare.Client
dotnet run
```
Swagger/OpenAPI docs will be live at the API's `/swagger` endpoint once Phase 1 scaffolding lands.

### 4. Before you branch
- Read `CONTRIBUTING.md` (branching, commit format, PR process)
- Pull latest `main`
- Check Jira for your assigned ticket — every branch maps to one

## Phase 0 checklist (Week 1)
Owner-by-owner setup so nobody's blocked once Phase 1 starts:

- [ ] **Repo & branch protection** — `main` protected, PRs require 2 approvals, feature-branch workflow documented in `CONTRIBUTING.md`
- [ ] **Solution scaffold** — five projects created (`Api`, `Client`, `Shared`, `Data`, `Tests`), builds clean on a fresh clone
- [ ] **Azure setup** (Priscilla) — App Service + Azure SQL provisioned, "Hello World" CI/CD pipeline proven end-to-end before anyone depends on it
- [ ] **Jira board** (Somuah) — backlog with epics for the 4 core features + auth + payments + deployment, tickets sized 1–3 days
- [ ] **Coding standards doc** (Stephanie) — naming conventions, commit format, PR template published
- [ ] **All 12 members added as GitHub collaborators**

## What's next
Once Phase 0 is done, Phase 1 (Data & Auth Layer) starts — EF Core schema design, ASP.NET Identity + JWT, and API scaffolding so the Blazor team can wire up against a live API immediately. See the full execution guide for the phase-by-phase breakdown.

## Key risks to watch early
- **SignalR + Blazor WASM reconnect logic** — prototype in Week 4, not Week 6
- **Schema changes after Week 2** — get the EF Core schema reviewed by the whole team before migrations are written; changes later are expensive
- **Shared code drift** — `BiteShare.Shared` and `OrderHub` are touched by three concurrent streams; flag changes in the team channel before merging
