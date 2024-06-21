# Auction System

## Overview

The Auction System is a web application that allows users to manage auctions, bids, and payments. It includes user authentication and authorization.

## Prerequisites

- [.NET 6.0 SDK](https://dotnet.microsoft.com/download/dotnet/6.0)
- [SQL Server](https://www.microsoft.com/en-us/sql-server/sql-server-downloads)
- [Docker](https://www.docker.com/products/docker-desktop)

## Getting Started

### Clone the repository

```bash
git remote add origin https://github.com/atobones/AuctionSystem.git
cd auction-system

Accessing the Application
Web Interface
Open your browser and navigate to https://localhost:5001.
You will see the home page with options to manage users, auctions, and payments.
Swagger API Documentation
Open your browser and navigate to https://localhost:5001/swagger.
You will see the Swagger UI, where you can explore and test the API endpoints.
Using the Application
Managing Users
Navigate to https://localhost:5001/Users.
You will see a list of users with options to create, edit, and delete users.
Managing Payments
Navigate to https://localhost:5001/Payments.
You will see a list of payments with options to create, edit, and delete payments.
Managing Auctions
Navigate to https://localhost:5001/Auctions.
You will see a list of auctions with options to create, edit, and delete auctions.
API Endpoints
User Management
POST /api/User - Create a new user.
GET /api/User - Get a list of users.
PUT /api/User/{id} - Update a user.
DELETE /api/User/{id} - Delete a user.
Payment Management
POST /api/Payment - Create a new payment.
GET /api/Payment - Get a list of payments.
PUT /api/Payment/{id} - Update a payment.
DELETE /api/Payment/{id} - Delete a payment.
Auction Management
POST /api/Auction - Create a new auction.
GET /api/Auction - Get a list of auctions.
PUT /api/Auction/{id} - Update an auction.
DELETE /api/Auction/{id} - Delete an auction.
Logging
Logging is enabled in the application and logs will be output to the console. This helps in debugging issues during development and testing.

Troubleshooting
If you encounter any issues, please check the logs for detailed error messages. Common issues include:

Database connection issues: Ensure your connection string in appsettings.json is correct and the SQL Server instance is running.
Missing dependencies: Run dotnet restore to ensure all dependencies are installed.