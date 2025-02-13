# Basic CRUD with Categories in ASP.NET and Razor Pages

## Description

A simple CRUD project for managing categories using **ASP.NET Core** and **Razor Pages**.

## Features

- Add categories
- Edit categories
- Delete categories
- Display category list

## Technologies

- **ASP.NET Core**
- **Entity Framework Core**
- **Razor Pages**
- **SQLite (or another database)**

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/user/repo.git
   cd repo
   ```
2. Prepare the database:
   ```sh
   dotnet ef database update
   ```
3. Run the application:
   ```sh
   dotnet run
   ```

## Project Structure

```
/repo
│-- Views/
│   ├── Category/
│   │   ├── Index.cshtml
│   │   ├── Create.cshtml
│   │   ├── Edit.cshtml
│   │   ├── Delete.cshtml
│-- Data/
│   ├── ApplicationDbContext.cs
│-- Models/
│   ├── Category.cs
│-- Program.cs
│-- Startup.cs
```

## Example Model

```csharp
public class Category
{
   [Key]
   public int Id { get; set; }
   [Required]
   public string Name { get; set; }
   [DisplayName ("Display Order")]
   [Range (1, 100, ErrorMessage = "Display order must be number between 1 and 100.")]
   public int DisplayOrder { get; set; }
   public DateTime CreatedDateTime { get; set; } = DateTime.Now;
      
}
```

## License

MIT

