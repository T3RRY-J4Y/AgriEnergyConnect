---

# Agri-Energy Connect

**Agri-Energy Connect** is a web application that connects South African farmers with renewable energy providers and employees, allowing seamless management of farmer profiles and agricultural products. This prototype demonstrates role-based access, CRUD functionality, and a responsive, user-friendly interface.

---

## Table of Contents

1. [Features](#features)
2. [System Requirements](#system-requirements)
3. [Setup Instructions](#setup-instructions)
4. [Database Integration](#database-integration)
5. [User Roles](#user-roles)
6. [Functionality](#functionality)
7. [User Interface](#user-interface)
8. [Data Validation & Accuracy](#data-validation--accuracy)
9. [Development Process & Testing](#development-process--testing)
10. [License](#license)

---

## Features

* Role-based authentication (Farmer, Employee)
* Farmer dashboard to add and view personal products
* Employee dashboard to view all farmers and filter products
* CRUD operations for products and farmers
* Responsive and accessible UI for desktops, tablets, and smartphones
* Seeded sample data for demonstration purposes

---

## System Requirements

* [.NET 8 SDK](https://dotnet.microsoft.com/en-us/download/dotnet/8.0)
* Visual Studio 2022 / VS Code
* SQL Server / Azure SQL Database
* Browser: Chrome, Edge, or Firefox

---

## Setup Instructions

1. Clone the repository:

```bash
git clone https://github.com/yourusername/AgriEnergyConnect.git
cd AgriEnergyConnect
```

2. Update the **connection string** in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=tcp:agrienergyconnect.database.windows.net,1433;Initial Catalog=agrienergyconnect;Persist Security Info=False;User ID=YOUR_USERNAME;Password=YOUR_PASSWORD;MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;"
}
```

3. Restore NuGet packages:

```bash
dotnet restore
```

4. Apply migrations to the database:

```bash
dotnet ef database update
```

5. Seed sample data (10 farmers, 2 products each) for testing:

```bash
dotnet run
```

6. Launch the application:

```bash
dotnet run
```

* Navigate to `https://localhost:5001` to access the app

---

## Database Integration

* **Entity Framework Core** is used for database access.
* Tables:

  * `Farmers` - stores farmer information (Name, Location)
  * `Products` - stores product details (Name, Category, ProductionDate, linked to FarmerId)
  * `AspNetUsers` - stores application users with role and FarmerId linkage

---

## User Roles

| Role         | Permissions                                                           |
| ------------ | --------------------------------------------------------------------- |
| **Farmer**   | Add/view products, access personal dashboard                          |
| **Employee** | Add/view farmers, view/filter all products, access employee dashboard |

---

## Functionality

### Farmer Dashboard

* View registered products
* Add new products with name, category, and production date
* Edit or delete own products

### Employee Dashboard

* View all farmers
* Add new farmers
* Filter products by category or date range
* Edit or delete farmer profiles

---

## User Interface

* Built with **Bootstrap 5** for a modern and responsive layout
* Navigation bar is **sticky** for easy access
* Footer is fixed at the bottom for consistent layout
* Background image enhances aesthetics without obstructing content

---

## Data Validation & Accuracy

* Required fields are enforced via data annotations
* Invalid submissions show validation errors in the UI
* Foreign key constraints ensure referential integrity

---

## Development Process & Testing

* Prototype developed iteratively using MVC with EF Core
* Tested CRUD functionality and role-based access
* Responsive design tested on multiple screen sizes
* Seeded data allows functional demonstration without manual entry

---

## Future Enhancements

* Implement file upload for product images
* Add analytics dashboard for product statistics
* Integrate email notifications for product updates

---

## License

This project is **open-source**. Feel free to fork, modify, and use under the MIT License.

---
