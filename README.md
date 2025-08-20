# Order Management System

A full-stack order management application built with .NET 9 API and Angular frontend in a single repository.

## 🏗️ Project Structure

```
OrderManagementSystem/
├── OrderManagement.API/         # 🎯 .NET 9 Web API Backend
│   ├── Controllers/             # API endpoints
│   ├── Services/                # Business logic
│   ├── Models/                  # Entity models & DbContext
│   ├── DTOs/                    # Data transfer objects
│   ├── Filters/                 # Custom filters (Cache, Audit, etc.)
│   ├── Middlewares/             # Custom middleware
│   └── README.md                # Backend documentation
├── OrderManagement.Front/       # 🎨 Angular Frontend
│   ├── src/app/home/            # Home components
│   ├── src/app/orders/          # Order management UI
│   ├── src/app/services/        # Angular services
│   └── README.md                # Frontend documentation
├── docs/                        # 📚 Project documentation
├── scripts/                     # 🚀 Deployment & utility scripts
├── SampleData.sql               # 📊 Database sample data
└── README.md                    # This file
```

## 🚀 Technology Stack

### Backend (.NET 9 API)
- **Framework**: ASP.NET Core 9.0
- **Database**: SQL Server with Entity Framework Core
- **Architecture**: Clean Architecture with Repository Pattern
- **Features**:
  - ✅ RESTful API design
  - ✅ Custom filters (Caching, Auditing, Validation)
  - ✅ Global error handling middleware
  - ✅ Memory caching for performance
  - ✅ Comprehensive logging and monitoring
  - ✅ Swagger/OpenAPI documentation

### Frontend (Angular)
- **Framework**: Angular 18+
- **Language**: TypeScript
- **Styling**: SCSS with modern design
- **Features**:
  - ✅ Responsive component architecture
  - ✅ Angular Router for navigation
  - ✅ HTTP services for API communication
  - ✅ Modern UI/UX design
  - ✅ Error handling and loading states

## 🚀 Quick Start

### Prerequisites
- **.NET 9 SDK** - [Download here](https://dotnet.microsoft.com/download)
- **Node.js 18+** - [Download here](https://nodejs.org/)
- **SQL Server** or **SQL Server Express**
- **Angular CLI**: `npm install -g @angular/cli`

### 🔧 Backend Setup
```bash
# Navigate to API project
cd OrderManagement.API

# Restore NuGet packages
dotnet restore

# Update database with migrations
dotnet ef database update

# Run the API (starts on https://localhost:5128)
dotnet run
```

### 🎨 Frontend Setup
```bash
# Navigate to Frontend project
cd OrderManagement.Front

# Install npm dependencies
npm install

# Start development server (starts on http://localhost:4200)
ng serve
```

### 🔄 Run Both Together
```bash
# Terminal 1 - Backend
cd OrderManagement.API && dotnet run

# Terminal 2 - Frontend  
cd OrderManagement.Front && ng serve
```

## 📡 API Endpoints

| Method | Endpoint | Description | Caching |
|--------|----------|-------------|---------|
| `GET` | `/api/orders` | Get all orders | ✅ 60s |
| `GET` | `/api/orders/{id}` | Get order by ID | ✅ 120s |
| `GET` | `/api/orders/recent?days=7` | Get recent orders | ✅ 30s |
| `POST` | `/api/orders` | Create new order | ❌ |

### 📝 Example API Usage
```http
# Get recent orders
GET https://localhost:5128/api/orders/recent?days=7
Accept: application/json

# Create new order
POST https://localhost:5128/api/orders
Content-Type: application/json

{
  "customerId": 1,
  "orderDate": "2025-08-20T10:30:00Z",
  "totalAmount": 299.99,
  "status": "Pending"
}
```

## ⚡ Key Features

### 🎯 Backend Features
- **Custom Filters**: Cache, Audit, Validation, Performance monitoring
- **Memory Caching**: Automatic response caching with configurable TTL
- **Error Handling**: Global exception handling with structured responses
- **Logging**: Comprehensive request/response logging
- **Database**: Entity Framework with migrations and sample data

### 🎨 Frontend Features
- **Modern UI**: Responsive design with SCSS styling
- **Component Architecture**: Modular and reusable components
- **Service Layer**: HTTP services with error handling
- **Routing**: Angular Router with lazy loading
- **Type Safety**: Full TypeScript implementation

## 🗄️ Database Schema

```sql
Orders                    Customers              OrderItems
├── OrderId (PK)         ├── CustomerId (PK)    ├── OrderItemId (PK)
├── CustomerId (FK)      ├── Name               ├── OrderId (FK)
├── OrderDate            ├── Email              ├── ProductId
├── TotalAmount          └── Phone              ├── Quantity
└── Status                                      └── UnitPrice
```

## 🚀 Deployment

### Docker Support
```bash
# Build and run with Docker Compose
docker-compose up --build

# Backend: http://localhost:5000
# Frontend: http://localhost:4200
```

### Manual Deployment
```bash
# Build backend for production
cd OrderManagement.API
dotnet publish -c Release -o ./publish

# Build frontend for production
cd OrderManagement.Front
ng build --prod
```

## 🧪 Testing

### Backend Tests
```bash
cd OrderManagement.API
dotnet test
```

### Frontend Tests
```bash
cd OrderManagement.Front
npm test                    # Unit tests
npm run e2e                 # E2E tests
npm run test:coverage       # Coverage report
```

## 📊 Development Scripts

```bash
# Start both backend and frontend
npm run dev

# Build everything
npm run build

# Run tests
npm run test

# Lint code
npm run lint

# Database migrations
npm run db:migrate
```

## 🤝 Contributing

1. **Fork** the repository
2. **Create** a feature branch: `git checkout -b feature/amazing-feature`
3. **Commit** your changes: `git commit -m 'Add amazing feature'`
4. **Push** to the branch: `git push origin feature/amazing-feature`
5. **Open** a Pull Request

### 📋 Development Guidelines
- Follow **Clean Code** principles
- Write **unit tests** for new features
- Update **documentation** for API changes
- Use **conventional commits** for messages
- Ensure **code coverage** above 80%

## 📄 License

This project is licensed under the **MIT License** - see the [LICENSE](LICENSE) file for details.

## 🔗 Links

- **API Documentation**: [Swagger UI](https://localhost:5128/swagger)
- **Frontend Demo**: [http://localhost:4200](http://localhost:4200)
- **Issue Tracker**: [GitHub Issues](https://github.com/yfarids/OrderManagementSystem/issues)

---

## 📞 Support

For support, email yfarids@example.com or create an issue in this repository.

**Happy Coding! 🎉**
