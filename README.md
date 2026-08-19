# Work Order Management Application

A full-stack work order management application built with **C#, .NET, Blazor, Entity Framework Core, and SQLite**.

The application allows users to create, view, update, filter, and delete work orders through a clean web interface while demonstrating modern .NET application development practices, RESTful API design, database integration, and separation of application responsibilities.

## Features

* Create new work orders
* View existing work orders
* Edit work order information
* Delete work orders with confirmation
* Filter work orders by status
* Filter work orders by site code
* Track work order creation dates
* Display success and error messages to the user
* REST API for work order CRUD operations
* Persistent data storage using SQLite
* Entity Framework Core database integration
* Responsive UI built with Blazor and MudBlazor

## Technology Stack

| Technology            | Purpose                                       |
| --------------------- | --------------------------------------------- |
| C#                    | Primary programming language                  |
| .NET                  | Application framework                         |
| Blazor Server         | Web application UI                            |
| ASP.NET Core          | Backend/API functionality                     |
| Entity Framework Core | Object-relational mapping and database access |
| SQLite                | Relational database                           |
| MudBlazor             | Blazor UI component library                   |
| REST API              | Communication with work order resources       |

## Architecture

The project follows a layered architecture that separates business entities, application models, infrastructure, and the web interface.

```text
WorkOrderApp
│
├── Domain
│   └── Entities
│       └── WorkOrder.cs
│
├── Application
│   ├── DTOs
│   └── Requests
│
├── Infrastructure
│   └── Persistence
│       └── AppDbContext.cs
│
└── Web
    ├── Components / Pages
    ├── API Endpoints
    └── Program.cs
```

### Domain

Contains the core entities used by the application.

The `WorkOrder` entity represents the primary business object managed by the system.

### Application

Contains application-level models such as DTOs and request objects.

This layer helps separate the application's API and UI models from the underlying database entities.

### Infrastructure

Handles persistence and database communication.

`AppDbContext` uses **Entity Framework Core** to map application entities to the SQLite database.

### Web

Contains the Blazor user interface and ASP.NET Core REST API endpoints.

The web application allows users to interact with work orders without directly accessing the database.

## API Endpoints

The application provides RESTful CRUD operations for work orders.

| Method   | Endpoint               | Description                   |
| -------- | ---------------------- | ----------------------------- |
| `GET`    | `/api/workorders`      | Retrieve work orders          |
| `POST`   | `/api/workorders`      | Create a new work order       |
| `PUT`    | `/api/workorders/{id}` | Update an existing work order |
| `DELETE` | `/api/workorders/{id}` | Delete a work order           |

## Getting Started

### Prerequisites

Install the following before running the application:

* [.NET SDK](https://dotnet.microsoft.com/download)
* Git
* A code editor such as Visual Studio, Visual Studio Code, or JetBrains Rider

SQLite is used for the database, so a separate database server is not required.

## Installation

Clone the repository:

```bash
git clone <your-repository-url>
```

Navigate into the project directory:

```bash
cd WorkOrderApp
```

Restore NuGet packages:

```bash
dotnet restore
```

Build the project:

```bash
dotnet build
```

Run the application:

```bash
dotnet run
```

After the application starts, open the localhost address displayed in the terminal.

For example:

```text
https://localhost:xxxx
```

## Database

The application uses **SQLite** for persistent storage and **Entity Framework Core** for database access.

The database context is defined in:

```text
Infrastructure/Persistence/AppDbContext.cs
```

If Entity Framework migrations are configured, the database can be created or updated with:

```bash
dotnet ef database update
```

## Work Order Workflow

A typical workflow is:

1. Open the work order list.
2. View existing work orders.
3. Filter work orders by status or site code.
4. Create a new work order.
5. Edit the work order when information changes.
6. Delete work orders that are no longer needed.
7. Receive confirmation or error feedback after an operation.

## Project Goals

This project was created to strengthen practical experience with modern .NET application development.

Key concepts demonstrated include:

* C# object-oriented programming
* ASP.NET Core
* Blazor development
* RESTful API design
* CRUD operations
* Entity Framework Core
* Relational databases
* SQLite
* Dependency injection
* Asynchronous application development
* Layered application architecture
* Separation of concerns
* Frontend and backend integration

## Example API Request

A work order can be created by sending a `POST` request to:

```text
/api/workorders
```

Example request body:

```json
{
  "title": "Repair loading dock door",
  "description": "Loading dock door is not closing correctly.",
  "status": "Open",
  "siteCode": "ATL01"
}
```

The API creates the work order and returns the newly created resource.

## Future Improvements

Potential enhancements include:

* User authentication and authorization
* Role-based permissions
* Work order priority levels
* Employee or technician assignments
* Work order comments and history
* File and image attachments
* Due dates and scheduling
* Pagination
* Advanced search
* Dashboard and reporting
* Automated testing
* SQL Server or PostgreSQL support
* Docker containerization
* Cloud deployment
* CI/CD pipeline integration

## What I Learned

Building this application provided hands-on experience designing a complete .NET application rather than working with isolated programming exercises.

The project required connecting multiple parts of the .NET ecosystem, including the Blazor interface, ASP.NET Core API endpoints, Entity Framework Core, dependency injection, and a relational database.

It also provided practical troubleshooting experience involving application configuration, database context registration, routing, UI components, HTTP requests, and CRUD operations.

## Author

**Joshua Barnes**

M.S. Computer Science
Software Development | Backend Development | .NET | C# | Python | Data Engineering
