# HangfireAspNetCore

A practice ASP.NET Core MVC project built to learn how to use Hangfire for background job processing in a .NET web application.

This project demonstrates how to configure Hangfire with SQL Server, run a Hangfire background server, use the Hangfire Dashboard, and trigger different types of background jobs through controller endpoints.

## Tutorial Reference

This project was created while following this Hangfire tutorial:

[Hangfire ASP.NET Core Tutorial](https://www.youtube.com/watch?v=UGVVpvBYUaI)

## Features

- ASP.NET Core MVC application
- Hangfire background job processing
- SQL Server storage for Hangfire jobs
- Hangfire Dashboard available at `/hangfire`
- Fire-and-forget background job example
- Delayed background job example
- Recurring background job example
- Continuation background job example
- Service layer used to organize job logic

## Tech Stack

- C#
- ASP.NET Core MVC
- .NET 8
- Hangfire
- Hangfire.AspNetCore
- Hangfire.SqlServer
- SQL Server / SQL Server Express
- Visual Studio

## Project Structure

```text
HangfireAspNetCore/
├── HangfireAspNetCore.sln
├── .gitignore
└── HangfireAspNetCore/
    ├── Controllers/
    │   ├── HomeController.cs
    │   └── JobTestController.cs
    ├── Models/
    ├── Properties/
    ├── Services/
    │   ├── IJobTestService.cs
    │   └── JobTestService.cs
    ├── Views/
    ├── wwwroot/
    ├── Program.cs
    ├── appsettings.json
    └── HangfireAspNetCore.csproj
```

## Background Job Endpoints

The project includes several endpoints for testing Hangfire jobs.

| Endpoint | Method | Description |
|---|---:|---|
| `/FireAndForgetJob` | GET | Creates a fire-and-forget background job that runs immediately |
| `/DelayedJob` | GET | Creates a background job that runs after a delay |
| `/RecurringJob` | GET | Creates a recurring background job |
| `/ContinuationJob` | GET | Creates a continuation job that runs after another job completes |

## Hangfire Dashboard

After running the application, the Hangfire Dashboard can be viewed at:

```text
/hangfire
```

The dashboard can be used to monitor jobs, recurring jobs, retries, succeeded jobs, failed jobs, and processing status.

## Getting Started

### Prerequisites

Make sure you have the following installed:

- Visual Studio
- .NET 8 SDK
- SQL Server or SQL Server Express

## Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/JegMc/HangfireAspNetCore.git
```

### 2. Navigate into the repository

```bash
cd HangfireAspNetCore
```

### 3. Update the database connection string

Open:

```text
HangfireAspNetCore/appsettings.json
```

Update the `DefaultConnection` value so it matches your local SQL Server setup.

Example:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=YOUR_SERVER_NAME\\SQLEXPRESS;Database=HangfireApplication;Trusted_Connection=True;TrustServerCertificate=True"
}
```

### 4. Restore dependencies

```bash
dotnet restore
```

### 5. Run the application

```bash
dotnet run --project HangfireAspNetCore/HangfireAspNetCore.csproj
```

### 6. Open the app in your browser

Once the application starts, open the local URL shown in the terminal.

Then visit:

```text
/hangfire
```

to view the Hangfire Dashboard.

## Notes

This is a learning project and is not intended for production use. 
