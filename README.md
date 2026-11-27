# PackIT

PackIT is a learning project built with ASP.NET Core Web API. It focuses on applying software architecture principles and design patterns through a practical application.

## Purpose

The main goal of this project was to gain practical experience with:

- **Clean Architecture** – Organizing the application into independent layers with clear responsibilities.
- **CQRS** – Separating command and query operations.
- **Domain-Driven Design (DDD)** – Applying domain modeling concepts and encapsulating business rules.
- **Design Patterns** – Exploring and applying different design patterns to solve common software design problems.

## Tech Stack

- C#
- .NET 10
- ASP.NET Core Web API
- Entity Framework Core
- PostgreSQL
- xUnit

## Project Structure

The solution is organized into the following projects:

- `PackIT.API` – API endpoints and application entry point.
- `PackIT.Application` – Application logic and use cases.
- `PackIT.Domain` – Domain entities, value objects, domain events, and business rules.
- `PackIT.Infrastructure` – Data access and infrastructure implementations.
- `PackIT.Shared.Abstractions` – Shared contracts and abstractions.
- `PackIT.Shared` – Shared implementations and components.

## Disclaimer

This is an educational project, not a production-ready application. Its primary purpose is to explore and practice software architecture, domain modeling, and design patterns in a real-world-style application.
