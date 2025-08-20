# OrderManagement API

A robust .NET 9 Web API for order management system with advanced features.

## 🚀 Features

- **RESTful API Design** - Clean, intuitive endpoints
- **Entity Framework Core** - Database operations with SQL Server
- **Custom Filters** - Caching, Auditing, Validation, Performance monitoring
- **Error Handling** - Global exception handling middleware
- **Memory Caching** - High-performance response caching
- **Logging** - Comprehensive logging and monitoring
- **Clean Architecture** - Separation of concerns with Repository pattern

## 📋 API Endpoints

### Orders
- `GET /api/orders` - Get all orders
- `GET /api/orders/{id}` - Get order by ID
- `GET /api/orders/recent?days=7` - Get recent orders (cached)
- `POST /api/orders` - Create new order

## 🛠 Tech Stack

- **.NET 9** - Latest .NET framework
- **ASP.NET Core** - Web API framework
- **Entity Framework Core** - ORM
- **SQL Server** - Database
- **AutoMapper** - Object mapping
- **Serilog** - Structured logging

## 🏗 Architecture

```
Controllers/          # API endpoints
├── OrderController.cs

Services/            # Business logic
├── IOrderService.cs
└── OrderService.cs

Models/              # Entity models
├── Order.cs
├── Customer.cs
├── OrderItem.cs
└── AppDbContext.cs

DTOs/                # Data transfer objects
├── OrderDto.cs
└── CreateOrderDto.cs

Filters/             # Custom filters
├── CacheResourceFilter.cs
├── AuditFilter.cs
└── ValidateModelFilter.cs

Middlewares/         # Custom middleware
└── ErrorHandlingMiddleware.cs
```

## 🚀 Getting Started

### Prerequisites
- .NET 9 SDK
- SQL Server or SQL Server Express

### Installation
```bash
# Clone the repository
git clone https://github.com/yfarids/OrderManagement-API.git
cd OrderManagement-API

# Restore packages
dotnet restore

# Update database
dotnet ef database update

# Run the application
dotnet run
```

### Configuration
Update `appsettings.json` with your database connection:
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost\\SQLEXPRESS01;Database=orderDB;Trusted_Connection=True;Encrypt=False;"
  }
}
```

## 📝 Usage Examples

### Create Order
```http
POST /api/orders
Content-Type: application/json

{
  "customerId": 1,
  "orderDate": "2025-08-20T10:30:00Z",
  "totalAmount": 299.99,
  "status": "Pending"
}
```

### Get Orders with Caching
```http
GET /api/orders/recent?days=7
X-API-Key: your-api-key
```

## 🔧 Custom Filters

### Cache Filter
```csharp
[CacheResourceFilter(300)] // Cache for 5 minutes
public async Task<ActionResult> GetOrders() { }
```

### Audit Filter
```csharp
[AuditFilter] // Logs all requests
public async Task<ActionResult> CreateOrder() { }
```

## 📊 Performance Features

- **Memory Caching** - Automatic response caching
- **Performance Monitoring** - Request timing and logging
- **Rate Limiting** - Configurable request throttling
- **Error Handling** - Graceful error responses

## 🤝 Contributing

1. Fork the repository
2. Create a feature branch
3. Make your changes
4. Add tests
5. Submit a pull request

## 📄 License

This project is licensed under the MIT License.
