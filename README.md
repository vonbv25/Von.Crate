

# Crate
This is a simple framework designed to streamline the development of applications using Vertical Slice Architecture in .NET Core. 

**What is Vertical Slice Architecture (VSA)?**

Vertical Slice Architecture is a software architectural pattern that organizes code around features or functionalities rather than traditional layered architectures. Instead of grouping code by layers (e.g., data access, business logic, presentation), VSA encourages developers to organize code by features or use cases. This approach promotes better modularity, testability, and maintainability of your applications.

For more info:
https://code-maze.com/vertical-slice-architecture-aspnet-core/

### CI Builds

master
[![Build status](https://ci.appveyor.com/api/projects/status/8mj84op3ym6342l7/branch/master?svg=true)](https://ci.appveyor.com/project/vonbv25/von-crate/branch/master)

### Getting Started

1. Create new EMPTY ASP.NetCore application - `dotnet new web -n MyApp`
2. Change into the new project location - `cd ./MyApp`
3. Add Crate package 
```
dotnet add package Crate --version 1.0.0
```
4. Modify your Program.cs to use Crate

```csharp
var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCrate();

var app = builder.Build();

app.MapCrate();
app.Run();
```

5. Create a new Feature

```csharp
    public class Product : IRouterCrate, IServiceCrate
    {

        public void AddEndpoint(IEndpointRouteBuilder app)
        {
            app.MapGet("api/name", () => {
                return ProductEndpoint.GetProductName();
            });
            app.MapPost("api/add", (string product) =>
            {
                return ProductEndpoint.AddProduct(product);
            });
        }

        public void AddService(IServiceCollection services)
        {
            //
        }
    }

    public static class ProductEndpoint
    {

        public static string GetProductName()
        {
            return "Crocodile Wallet";
        }

        public static IResult AddProduct(string product)
        {
            return Results.Accepted(product);
        }
    }
```
