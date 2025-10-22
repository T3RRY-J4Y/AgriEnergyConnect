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
10. [SQL Scripts](#sql-scripts)
11. [Admin Credentials](#admin-credentials)
12. [Future Enhancements](#future-enhancements)
13. [License](#license)

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

1. Open the `AgriEnergyConnect` folder in Visual Studio 2022.
2. Then open the `.sln` solution file in Visual Studio 2022.

3. Launch the application:

```bash
dotnet run
```

* Navigate to `https://localhost:5001` to access the app.

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

## SQL Scripts

### Create Tables

```sql
CREATE TABLE Farmers (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Location NVARCHAR(100) NOT NULL
);

CREATE TABLE Products (
    Id INT IDENTITY(1,1) PRIMARY KEY,
    Name NVARCHAR(100) NOT NULL,
    Category NVARCHAR(100) NOT NULL,
    ProductionDate DATE NOT NULL,
    FarmerId INT NOT NULL,
    CONSTRAINT FK_Products_Farmers FOREIGN KEY (FarmerId) REFERENCES Farmers(Id) ON DELETE CASCADE
);
```

### Seed Sample Data

```sql
INSERT INTO Farmers (Name, Location) VALUES
('Xikombiso Dlamini', 'Pretoria'),
('Rihlatlho Mavhungu', 'Johannesburg'),
('Tiyani Phiri', 'Nelspruit'),
('Lufuno Shongwe', 'Polokwane'),
('Nyiko Tshabalala', 'Soweto'),
('Rendani Mokoena', 'Tzaneen'),
('Khensani Ndlovu', 'Mbombela'),
('Tsakani Hlabangana', 'Thohoyandou'),
('Vutomi Ramabulana', 'Polokwane'),
('Mandla Maphosa', 'Pretoria');

INSERT INTO Products (Name, Category, ProductionDate, FarmerId) VALUES
('Maize', 'Grain', GETDATE(), 1),
('Vegetables', 'Produce', GETDATE(), 1),
('Wheat', 'Grain', GETDATE(), 2),
('Tomatoes', 'Produce', GETDATE(), 2),
('Sunflowers', 'Grain', GETDATE(), 3),
('Cabbage', 'Produce', GETDATE(), 3),
('Sorghum', 'Grain', GETDATE(), 4),
('Carrots', 'Produce', GETDATE(), 4),
('Barley', 'Grain', GETDATE(), 5),
('Onions', 'Produce', GETDATE(), 5),
('Millet', 'Grain', GETDATE(), 6),
('Spinach', 'Produce', GETDATE(), 6),
('Oats', 'Grain', GETDATE(), 7),
('Peppers', 'Produce', GETDATE(), 7),
('Rye', 'Grain', GETDATE(), 8),
('Pumpkins', 'Produce', GETDATE(), 8),
('Quinoa', 'Grain', GETDATE(), 9),
('Greenbeans', 'Produce', GETDATE(), 9),
('Rice', 'Grain', GETDATE(), 10),
('Lettuce', 'Produce', GETDATE(), 10);
```

---

## Admin Credentials

For testing purposes, you can log in with the default **Employee/Admin** account:

* **Email:** [admin@agrienergyconnect.com](mailto:admin@agrienergyconnect.com)
* **Password:** Admin123!

> Note: Change these credentials if deploying to production for security.

---

## Future Enhancements

* Implement file upload for product images
* Add analytics dashboard for product statistics
* Integrate email notifications for product updates

---

## License

This project is **open-source**. Feel free to fork, modify, and use under the MIT License.

---

If you want, I can **also create a zipped folder structure guide** for submission so that someone can open the `.sln` and run it immediately without any setup issues.

Do you want me to do that?
