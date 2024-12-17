# Library Management System

The **Library Management System** is designed to help libraries efficiently manage book checkouts, returns, and penalties for late returns. The system provides different functionalities for librarians and members, allowing librarians to manage books, members, and reservations, while members can browse available books, view their borrowing history, and manage their account.

This system is built with the goal of simplifying library operations, enhancing user experience, and ensuring smooth book tracking and management.

[Watch the demo video](https://youtu.be/LIz7pvUHpk8)


## Table of Contents

- [Project Overview](#project-overview)
- [Project Features](#project-features)
- [Technologies Used](#technologies-used)
- [System Design](#system-design)
- [Installation Instructions](#installation-instructions)


## Overview

This system is built using **ASP.NET Core MVC**, **Entity Framework Core**, and **ASP.NET Identity**. It follows a Code-First approach, allowing the database schema to evolve easily through migrations.

The system employs the Repository Pattern to abstract data access, ensuring a clean separation of concerns and maintainable code. Dependency Injection is used to manage dependencies, promoting loose coupling and enhancing testability.

ASP.NET Identity handles user authentication and authorization, ensuring secure login and role-based access for librarians and members. This architecture ensures a scalable, secure, and maintainable solution for managing library operations.


## Project Features

### 1. Common Tabs for Both Librarian and Member

#### **Home**
- **Librarian**: Displays quick stats such as:
  - Total books
  - Pending reservations
  - Total members
  - Books borrowed today
- **Member**: Welcomes the member with:
  - Highlighted available books
  - Library announcements or news

#### **Books**
- **Librarian**: 
  - Manage books (add, edit, delete, mark as unavailable).
  - Search, filter, and sort books by title, author, category, etc.
  - View which member has borrowed a book.
- **Member**:
  - View available books with details like title, author, genre, and availability.
  - Search and filter books by category.

### 2. Tabs for Librarian

These tabs are visible to librarians after they log in:

#### **Reservations**
- View, approve, or reject book reservation requests.
- Search or filter reservations by member name or book title.
- View reservation history.

#### **Borrowed Books**
- View books currently borrowed by members.
- Track due dates and overdue status.
- Send reminders for overdue books.

#### **Manage Members**
- Add, update, or deactivate members.
- View member borrowing history.
- Search for members by name, email, or membership ID.

#### **Reports**
- Generate reports such as:
  - Most borrowed books.
  - Member borrowing frequency.
  - Monthly borrowing trends.
  - Overdue books.

### 3. Tabs for Member

These tabs are visible to members after they log in:

#### **My Account**
- View personal details (name, email, membership ID).
- Check borrowing history (past and current borrowed books).
- View current reservations and their statuses.

#### **Available Books**
- Browse available books for borrowing.
- Search or filter by author, genre, or availability.
- View book details.

#### **Library Rules**
- View library rules and guidelines for borrowing, returning, and reservations.

### 4. Login Behavior

The system uses a **single login page** to determine the user role based on credentials:

- **Librarian Login**: Redirects to the librarian's dashboard with full access to management features.
- **Member Login**: Redirects to a member dashboard with limited access.


## Technologies Used

- **Frontend**: HTML, CSS, JavaScript 
- **Backend**: ASP.Net 
- **Database**: Microsoft SQL Server
- **Authentication**: ASP.NET Identity
- **Styling**: Bootstrap


## System Design
The system follows the **Model-View-Controller (MVC)** architecture:
- **Model:** Represents the data (entities such as Product, Order).
- **View:** Handles the presentation layer (HTML, CSS).
- **Controller:** Manages request handling and business logic.


## Installation Instructions

Follow these steps to set up the project locally:

### Prerequisites

- **Visual Studio** (v2019 or higher) with ASP.NET MVC support
- **SQL Server** (or SQL Server Express)
- **.NET Core SDK** (for building and running the application)

### Steps to Run the Project

1. Clone the repository:
   ```bash
   git clone https://github.com/yourusername/library-management-system.git
   ```

2. Open the solution in **Visual Studio**:
   - Double-click the `.sln` file to open the project in Visual Studio.

3. Set up the database:
   - Create a new SQL Server database or use an existing one.
   - Update the connection string in `Web.config` with your database details:
     ```xml
     <connectionStrings>
         <add name="LibraryDBContext" connectionString="Server=your_server;Database=LibraryDB;Trusted_Connection=True;" providerName="System.Data.SqlClient" />
     </connectionStrings>
     ```

4. Build the project:
   - In Visual Studio, click **Build** > **Build Solution**.

5. Run the project:
   - Press **F5** or click **Start** to run the application.

6. The application will be available at `http://localhost:port`.
