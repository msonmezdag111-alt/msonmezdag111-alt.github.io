# ByteForge Portfolio API

## 1. Projectbeschrijving

De ByteForge Portfolio API is de backend van de ByteForge-portfolio website. De API is ontwikkeld met ASP.NET Core en maakt het mogelijk om projecten en blogposts te beheren.

De API gebruikt SQL Server voor het opslaan van gegevens en ondersteunt CRUD-functionaliteiten (Create, Read, Update, Delete).

## 2. Gebruikte technologieën

- C#
- .NET 10
- ASP.NET Core Minimal API
- Entity Framework Core 10
- SQL Server
- Swagger / OpenAPI
- Dependency Injection

## 3. Functionaliteiten

De API ondersteunt het beheren van projecten en blogposts.

Voor beide onderdelen zijn de volgende functionaliteiten beschikbaar:

- Alle gegevens ophalen.
- Een specifiek item ophalen op basis van ID.
- Nieuwe items aanmaken.
- Bestaande items aanpassen.
- Items verwijderen.

## 4. Projectstructuur

De belangrijkste mappen en bestanden:

- `Data`: bevat AppDbContext voor de databaseverbinding.
- `DTOs`: bevat de Data Transfer Objects.
- `Endpoints`: bevat de HTTP-endpoints voor projecten en blogposts.
- `Models`: bevat de database-entiteiten.
- `Services`: bevat de CRUD-logica.
- `Migrations`: bevat de Entity Framework Core-databasemigraties.
- `Program.cs`: configureert de applicatie, registreert services en start de Endpoints-klasse.
- `appsettings.json`: bevat de configuratie, waaronder de databaseverbinding.
- `portfoliositeapi.csproj`: bevat de projectinstellingen en NuGet-package dependencies.

## 5. Installatie

### Vereisten

- .NET 10 SDK
- SQL Server
- JetBrains Rider of Visual Studio
- Entity Framework Core CLI

### Repository downloaden

```powershell
git clone <repository-url>
cd portfoliositeapi
```

### Dependencies installeren

```powershell
dotnet restore
```

## 6. Database configureren

De databaseverbinding wordt ingesteld in `appsettings.json`.

Voorbeeld:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ByteForgeDb;Trusted_Connection=True;TrustServerCertificate=True;"
  }
}
```

Pas indien nodig de servernaam aan naar je eigen SQL Server-configuratie.

### Database aanmaken of bijwerken

Voer het volgende commando uit:

```powershell
dotnet ef database update
```

Hiermee worden de bestaande Entity Framework Core-migraties toegepast op de database.

## 7. Applicatie starten

Start de API met:

```powershell
dotnet run
```

De lokale URL wordt weergegeven in de terminal.

## 8. Swagger

Swagger wordt automatisch ingeschakeld wanneer de applicatie in de Development-omgeving draait.

Open de volgende URL in je browser:

```text
https://localhost:<port>/swagger
```

Vervang `<port>` door de poort die in de terminal wordt weergegeven.

Met Swagger kunnen de beschikbare API-endpoints worden bekeken en getest.

## 9. API-endpoints

### Projects

| Methode | Endpoint | Beschrijving |
|---|---|---|
| GET | `/projects` | Alle projecten ophalen |
| GET | `/projects/{id}` | Project ophalen op ID |
| POST | `/projects` | Nieuw project aanmaken |
| PUT | `/projects/{id}` | Project aanpassen |
| DELETE | `/projects/{id}` | Project verwijderen |

### Blogposts

| Methode | Endpoint | Beschrijving |
|---|---|---|
| GET | `/blogposts` | Alle blogposts ophalen |
| GET | `/blogposts/{id}` | Blogpost ophalen op ID |
| POST | `/blogposts` | Nieuwe blogpost aanmaken |
| PUT | `/blogposts/{id}` | Blogpost aanpassen |
| DELETE | `/blogposts/{id}` | Blogpost verwijderen |

## 10. Architectuur

De applicatie maakt gebruik van een scheiding tussen endpoints, services, DTO's en database-entiteiten.

- **Endpoints:** ontvangen HTTP-verzoeken en sturen de juiste responses terug.
- **Services:** voeren de CRUD-operaties uit en communiceren met de database.
- **DTOs:** bepalen welke gegevens worden ontvangen en teruggestuurd door de API.
- **AppDbContext:** verzorgt de communicatie tussen Entity Framework Core en SQL Server.
- **Dependency Injection:** zorgt ervoor dat benodigde services automatisch beschikbaar worden gesteld aan de endpoints.

De services worden geregistreerd in `Program.cs` en via constructor injection beschikbaar gesteld.