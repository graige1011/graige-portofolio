# Graige Portfolio API

Backend voor mijn persoonlijke portfoliosite, gemaakt voor WPFW Opdracht 3.

De API beheert projecten en blogposts en gebruikt ASP.NET Core Web API, Entity Framework Core en SQL Server.

## Technologie

- .NET 10
- ASP.NET Core Web API
- Controllers
- Entity Framework Core
- SQL Server
- Swagger UI
- DTO's
- Dependency Injection

## API-stijl

Voor deze opdracht heb ik gekozen voor **Controllers**.

Ik heb hiervoor gekozen omdat Controllers een duidelijke scheiding geven tussen HTTP-afhandeling en de rest van de applicatie. De Controllers ontvangen requests en geven HTTP-responses terug, terwijl de Services de applicatielogica en databasehandelingen uitvoeren.

Een alternatief is Minimal API. Daarbij worden routes bijvoorbeeld met `MapGet`, `MapPost`, `MapPut` en `MapDelete` geregistreerd.

## Codestructuur

De backend is verdeeld in verschillende onderdelen:

```text
GraigePortfolioApi/
├── Controllers/
│   ├── ProjectsController.cs
│   └── BlogpostsController.cs
│
├── Services/
│   ├── ProjectService.cs
│   └── BlogpostService.cs
│
├── Data/
│   └── AppDbContext.cs
│
├── Models/
│   ├── Project.cs
│   └── Blogpost.cs
│
├── DTOs/
│   ├── ProjectCreateDto.cs
│   ├── ProjectUpdateDto.cs
│   ├── ProjectDto.cs
│   ├── BlogpostCreateDto.cs
│   ├── BlogpostUpdateDto.cs
│   └── BlogpostDto.cs
│
├── Migrations/
├── Program.cs
└── appsettings.json
```

### Controllers

De Controllers verwerken HTTP-requests zoals GET, POST, PUT en DELETE.

### Services

De Services bevatten de logica voor projecten en blogposts en communiceren met de database via `AppDbContext`.

### Data

`AppDbContext` vormt de verbinding tussen Entity Framework Core en SQL Server.

### Models

De Models zijn de entiteiten die in de database worden opgeslagen.

### DTOs

DTO's bepalen welke gegevens de API ontvangt en terugstuurt. Hierdoor worden de EF Core-entiteiten niet rechtstreeks via de API gebruikt.

## Database

De applicatie gebruikt **SQL Server LocalDB**.

De connection string staat in `appsettings.json`.

Voorbeeld:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=(localdb)\\MSSQLLocalDB;Database=GraigePortfolioDb;Trusted_Connection=True;TrustServerCertificate=True"
}
```

De database heet:

```text
GraigePortfolioDb
```

De database bevat tabellen voor:

- Projects
- Blogposts

## Database aanmaken

Ik gebruik **EF Core Migrations** om de database aan te maken.

Voer vanuit de map `GraigePortfolioApi` uit:

```bash
dotnet ef migrations add InitialCreate
```

Daarna:

```bash
dotnet ef database update
```

Hiermee wordt de SQL Server-database aangemaakt op basis van de Models en `AppDbContext`.

## Applicatie starten

Open een terminal in:

```text
backend/GraigePortfolioApi
```

Voer daarna uit:

```bash
dotnet run
```

De terminal toont vervolgens het lokale adres van de API, bijvoorbeeld:

```text
http://localhost:5249
```

Swagger UI is dan beschikbaar via:

```text
http://localhost:5249/swagger
```

## API-endpoints

### Projects

```text
GET    /api/Projects
GET    /api/Projects/{id}
POST   /api/Projects
PUT    /api/Projects/{id}
DELETE /api/Projects/{id}
```

### Blogposts

```text
GET    /api/Blogposts
GET    /api/Blogposts/{id}
POST   /api/Blogposts
PUT    /api/Blogposts/{id}
DELETE /api/Blogposts/{id}
```

## Persistentie

Projecten en blogposts worden opgeslagen in SQL Server.

Ik heb getest dat gegevens na het stoppen en opnieuw starten van de applicatie nog steeds beschikbaar zijn. Hierdoor weet ik dat de gegevens niet alleen tijdelijk in het geheugen worden opgeslagen.

## Swagger

Swagger UI wordt gebruikt om alle endpoints te testen.

Voor zowel Projects als Blogposts heb ik getest:

- POST om een item aan te maken
- GET om alle items op te vragen
- GET op id
- PUT om een item te wijzigen
- opnieuw GET om de wijziging te controleren
- applicatie opnieuw starten en controleren dat het item nog bestaat
- DELETE om het item te verwijderen
- GET op het verwijderde id geeft daarna 404 Not Found