
BiteShare
BiteShare is a collaborative food ordering platform that solves a common problem in group dining: coordinating a single order among multiple people across different restaurants. Instead of informal chat threads, spreadsheets, or separate orders, BiteShare gives a group a shared, real-time ordering session with automatic cost splitting.

Built for the Web Applications & Services course project — Team 4.

Features
Session Creation & Invitation — hosts create an order session, set a restaurant and deadline, and share a join link; participants join without mandatory sign-up.
Live Collaborative Cart — each participant builds their own sub-order, with real-time updates via SignalR so everyone sees the group cart grow instantly.
Smart Cost Splitter — auto-calculates each person's share (subtotal, tax, tip, delivery fee) and generates an itemized PDF receipt.
Order Status Tracking — hosts submit the consolidated order; participants get live push notifications at each stage (confirmed, preparing, out for delivery, delivered).
Tech Stack
Layer	Technology	Purpose
Frontend	Blazor WebAssembly (.NET 8)	SPA client-side UI
Backend API	ASP.NET Core 8 Web API	RESTful endpoints
Real-Time	SignalR (ASP.NET Core)	Live order & notification push
Data Access	EF Core 8 + SQL Server	ORM & relational data
Auth	ASP.NET Core Identity + JWT	User sessions & role claims
Payments	Stripe .NET SDK	Secure payment processing
Hosting	Azure App Service + Azure SQL	Cloud deployment & CI/CD
Project Structure
BiteShare.sln
├── BiteShare.Api/       # ASP.NET Core Web API
├── BiteShare.Client/    # Blazor WebAssembly front-end
├── BiteShare.Shared/    # DTOs/models shared between API and client
├── BiteShare.Data/      # EF Core DbContext, entities, migrations
└── BiteShare.Tests/     # Unit and integration tests
Getting Started
Prerequisites
.NET 8 SDK
SQL Server (LocalDB is fine for local development)
An IDE (Visual Studio, Rider, or VS Code with the C# extension)
Setup
bash
git clone https://github.com/<org>/BiteShare.git
cd BiteShare
dotnet restore
Update the connection string in BiteShare.Api/appsettings.Development.json, then apply migrations:

bash
cd BiteShare.Api
dotnet ef database update
Run the API and client:

bash
dotnet run --project BiteShare.Api
dotnet run --project BiteShare.Client
Branching & Workflow
main is protected — no direct pushes. All work goes through a pull request with at least 2 approvals.
Branch naming:
feature/<short-description> — new functionality (e.g. feature/cart-signalr)
fix/<short-description> — bug fixes (e.g. fix/receipt-rounding)
chore/<short-description> — tooling, config, non-feature work (e.g. chore/ci-pipeline)
Keep commits small and messages descriptive.
Team — Team 4
Name	Role
Emmanuel Grant Boamah	Project Lead & Backend Architect
Kingsella Gyan	ASP.NET Core API Developer
Precious Ayomah	Blazor UI Developer
Joseph Gyimah	Frontend/UX Designer
Aaron Tetteh	SignalR / Real-Time Integration
Roselyn Sakyi	Database & EF Core Engineer
Horoya Razak	Authentication & Security
Olivia Kwateng	Payment Integration Developer
Obadiah Donkor	QA & Test Automation
Priscilla Akuokor	DevOps & Azure Deployment
Stephanie Apenteng	Documentation & API Design
Somuah Kofi Anim	Business Analyst & Scrum Master
License
Course project — for academic use.

Content is user-generated and unverified.
