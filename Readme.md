# CQRS with Clean Architecture

This project implements the Command Query Responsibility Segregation (CQRS) pattern using Clean Architecture principles. CQRS improves scalability and performance by separating read and write operations, while Clean Architecture promotes modularity, maintainability, and testability by organizing code into distinct layers.

## Layers

### Domain Layer

- Contains domain-specific entities (e.g., Order, Product) and defines domain logic.
- Represents core concepts of the problem domain (e.g., order processing, product management).

```csharp
  public class Product
  {
      public int Id { get; set; }
      public string? Name { get; set; }
      public double Price { get; set; }

      public void UpdatePrice(double price)
      {
          this.Price = price;
      }
  }
```

**_Updateprice is domain logic_**

### Application Layer

- Executes application-specific logic and rules related to domain entities.
  Handles incoming requests (e.g., create order, get product details) and orchestrates interactions between layers.

```csharp

public class AddProductHandler : IRequestHandler<AddProductCommand, ProductResponseModel>
{
    private readonly IProductDatabase _productDatabase;

    public AddProductHandler(IProductDatabase productDatabase)
    {
        this._productDatabase = productDatabase;
    }

    public async Task<ProductResponseModel> Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        var product = await _productDatabase.AddProduct(request.Name, request.Price);
        return new ProductResponseModel { Name = product.Name, Price = product.Price };
    }

}

```

**_Addproduct is domain logic_**

### Infrastructure Layer:

#### Data Access Layer:

- Persists data into a database (e.g., SQL Server, MongoDB) using appropriate data access methods.

#### API Layer:

- Exposes endpoints for external interaction (e.g., REST API) to receive commands and queries.

## CQRS Pattern Diagram

## Razor Pages ( UI )

- The UI for adding and getting products is built in razor pages using ASP.NET Web API

## Cookie Based Authentication

- Only authenticated users can able to access or add product
- Cookie will have claim and identity about the user



