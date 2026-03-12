# BankingTransactionSystem
A .NET console-based application that simulates an ATM-style banking system. The system supports **customer transactions** and **administrator account management**, using a **MySQL database** and **Docker for local development**.
---

## Project Structure

```
scripts/
└── create_database.sql        # SQL script to create database schema

src/
├── Data/
│   ├── AccountRepository.cs   # Database access layer
│   └── DatabaseConfig.cs      # Database connection configuration
│
├── Models/
│   └── Account.cs             # Account domain model
│
├── Services/
│   ├── AuthService.cs         # Authentication logic
│   ├── TransactionServices.cs # Deposit / withdraw / balance logic
│   └── AdminServices.cs       # Admin account management
│
├── UI/
│   ├── ConsoleUtils.cs        # Console helper utilities
│   └── MenuHandler.cs         # Menu and user interaction
│
└── Program.cs                 # Application entry point
```

---

## Features

### Customer
- Withdraw cash
- Deposit cash
- Display account balance

### Administrator
- Create new account
- Delete existing account
- Update account information
- Search for account

---

## Prerequisites

- .NET SDK
- Docker (optional, for database container)
- MySQL

---

## Running the Application

### Run with .NET

```
dotnet run
```

### Run with Docker

The repository includes a `docker-compose.yml` file to run the database.

```
docker compose up
```

---

## Database

The SQL script for creating the database is located at:

```
scripts/create_database.sql
```

Run this script before starting the application if the database has not been created.

---

## Author

**Nirmala Tamang**
