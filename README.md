# 📱 Mobile Billing API

A RESTful API system for a telecom provider to manage mobile subscriber usage, billing, and payments. The project is built using service-oriented architecture principles in **.NET**, and includes JWT-based authentication, Swagger documentation, and cloud-ready deployment.

---

## 🔧 Features

- Add and track mobile phone/internet usage
- Calculate subscriber bills with tiered pricing
- Query bill summary and detailed breakdown
- Mark bills as paid (with partial payment handling)
- JWT Authentication & Swagger UI
- Paging support for detailed queries

---

## 🚀 Endpoints Overview

| Endpoint              | Method | Auth | Description                               |
|-----------------------|--------|------|-------------------------------------------|
| `/api/v1/usage`       | POST   | ✅   | Add 10 mins of phone or 1MB internet      |
| `/api/v1/bill/calc`   | POST   | ✅   | Calculate monthly bill                    |
| `/api/v1/bill`        | GET    | ❌   | Query bill summary                        |
| `/api/v1/bill/detail` | GET    | ✅   | Query detailed bill (with paging)         |
| `/api/v1/bill/pay`    | POST   | ❌   | Mark bill as paid                         |

---

## 💸 Billing Logic

- **Phone**:
  - First **1000 minutes free**
  - Every additional **1000 mins = $10**

- **Internet**:
  - First **20GB = $50**
  - Every additional **10GB = $10**

---

## 🧩 Design & Assumptions

- Built with **.NET**
- Follows clean architecture: Controller ➝ Service ➝ DTO
- All business logic handled via service layer
- Assumes subscriber data is already present
- Payments are mocked (no real processing)
- Uses Swagger for documentation and JWT for protected endpoints

---

## 📘 Swagger Docs

Swagger UI available at:  
`Not ready yet`

---

## 🌐 Deployment

Hosted on:  
➡️ `Not ready yet`

---

## 🎥 Demo Video

▶️ `Not ready yet`

---

## 📚 Author

**Alp YUKSEL**  

---
