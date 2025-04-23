# Mobile Billing API
A RESTful API system for a mobile service provider's billing operations. The API enables managing subscriber usage data, calculating bills based on usage patterns, querying bill information, and processing payments. Built with .NET 8, PostgreSQL, and includes JWT-based authentication, Swagger documentation, the system follows service-oriented design principles to ensure modularity, maintainability, and reliability.
---
## Features
- Add and track mobile phone/internet usage
- Calculate subscriber bills with tiered pricing
- Query bill summary and detailed breakdown
- Mark bills as paid (with partial payment handling)
- JWT Authentication & Swagger UI
- Paging support for detailed queries
---
## Endpoints Overview
| Endpoint                    | Method | Auth | Description                                           |
|-----------------------------|--------|------|-------------------------------------------------------|
| /api/v1/usages/add        | POST   | ✅   | Adds 10 mins of phone call or 1MB of internet         |
| /api/v1/bills/calculate   | POST   | ✅   | Calculates bill for given subscriber and month        |
| /api/v1/bills             | POST   | ❌   | Returns total bill with paid status                   |
| /api/v1/bills/detailed    | POST   | ✅   | Returns detailed bill information including paging    |
| /api/v1/bills/pay         | POST   | ❌   | Processes bill payment                                |
---
## Data Model (ER Diagram)
![ER Diagram](https://github.com/4lpY/Mobile-Billing-API/blob/main/public/mobile-billing-api-erd.jpg?raw=true)
---
## Billing Logic
- Phone:
  - First 1000 minutes free
  - Every additional 1000 mins = $10
- Internet:
  - First 20GB = $50
  - Every additional 10GB = $10
---
## Design & Assumptions
### Architecture Design
The system follows a service-oriented architecture with clear separation of concerns:
- API Layer: Handles HTTP requests/responses and input validation
- Service Layer: Implements business logic and processes
- Repository Layer: Manages data access operations
- DTOs (Data Transfer Objects): For clean data transformation between layers
- Entity Models: Representing database structure
### General Concerns & Assumptions
- Built with .NET 8
- Assumes subscriber data is already present
- Payments are mocked (no real processing)
- Uses Swagger for documentation and JWT for protected endpoints
- All amounts are in USD
- Usage and billing calculations are simplified for demonstration purposes
- Months are represented as a number (1 - 12)
- Usage types (i.e. phone & internet) are determined as 0 for Phone, 1 for Internet
---
## Swagger Docs
Interactive API documentation is available through Swagger UI.
Swagger UI available at:  
Not ready yet
---
## Deployment
The API is deployed at Azure App Service, providing reliable cloud hosting.
Hosted on:  
➡️ Not ready yet
---
## Demo Video
▶️ Not ready yet
---
## Author
Y. Alp YUKSEL - 21070001037  
---
