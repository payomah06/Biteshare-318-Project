# Contributing to BiteShare

This doc covers how our team of 12 works in this repo day to day. Read it before your first PR.

## Repo structure
- `BiteShare.Api` — ASP.NET Core Web API
- `BiteShare.Client` — Blazor WASM frontend
- `BiteShare.Shared` — DTOs/models used by both API and Client
- `BiteShare.Data` — EF Core context + migrations
- `BiteShare.Tests` — unit/integration/E2E tests

## Branching
- `main` is protected — no direct pushes, ever.
- One branch per Jira ticket, branched off latest `main`:
  ```
  feature/BS-123-signalr-cart-hub
  bugfix/BS-145-split-rounding-error
  chore/BS-101-ef-migrations
  ```
- Pull `main` daily, especially if you're touching `BiteShare.Shared` or `OrderHub` — three streams (Cart, Splitter, Payments) all depend on these and drift fast.

## Workflow
1. `git pull origin main`
2. `git checkout -b feature/BS-XXX-short-desc`
3. Commit in small, logical chunks (see commit format below)
4. `git push -u origin feature/BS-XXX-short-desc`
5. Open a PR into `main` using the PR template — link the Jira ticket
6. Request **2 reviewers** (required before merge)
7. If your change touches `BiteShare.Shared` or `OrderHub`, post a heads-up in the team channel *before* merging
8. Address feedback, wait for CI to pass, then squash-merge
9. Delete the branch after merge

## Commit message format
```
BS-123: short summary of the change

Optional longer description if the change needs context.
```
- Present tense, concise summary line (~50 chars)
- Always reference the ticket number

## Code review expectations
- 2 approvals minimum before merge
- Reviewers check: does it work, does it follow naming conventions, does it touch shared code safely, are tests included where relevant
- Don't rubber-stamp — with 12 people, review is the main defense against silent bugs (especially in the splitter logic)

## Testing
- New business logic (especially cost-splitting) needs unit tests
- API changes should have integration test coverage where practical
- CI (GitHub Actions) runs build + tests on every PR — must pass before merge

## Naming conventions
- C# classes/methods: PascalCase
- Private fields: `_camelCase`
- Razor components: PascalCase, one component per file
- Branches/tickets: always prefixed with the Jira ticket ID (`BS-XXX`)

## Scope discipline
With 12 people and 6 sprints, the biggest risk is over-building individual features. If a change grows beyond its ticket's scope, split it into a new ticket rather than expanding the PR.
