# Introduction

This repository is for the NUH Consent app.

This currently consists of a .NET web application backend that interacts with a PostgreSQL database.

## Getting Started

## Prerequisites

1. **.NET SDK** `7.x`
   - The backend API is .NET7
1. Docker

## Database setup

The application stack interacts with a PostgreSQL Server database, and uses code-first migrations for managing the database schema.

The repository contains a `docker-compose` for the database, so just run `docker-compose up -d` to start it running.

When setting up a new environment, or running a newer version of the codebase if there have been schema changes, you need to run migrations against your database server.

The easiest way is using the dotnet cli:

1. If you haven't already, install the local Entity Framework tooling

- Anywhere in the repo: `dotnet tool restore`

1. Navigate to the same directory as `ConsentApp.csproj`
1. Run migrations:

- `dotnet ef database update`
- The above runs against the default local server, using the connection string in `appsettings.Development.json`
- You can specify a connection string with the `--connection "<connection string>"` option

## 📁 Repository contents

Areas within this repo include:

- Application Source Code
  - .NET7 backend API
  - Shared Data class library

## App Configuration

Notes on configuration values that can be provided, and their defaults.

The backend app can be configured in any standard way an ASP.NET Core application can. Typically from the Azure Portal (Environment variables) or an `appsettings.json`.
