ASP.NET CRUD Operation Project
----------------------------
Overview
This project is a basic ASP.NET MVC application that performs CRUD (Create, Read, Update, Delete) operations on a simple entity "Employee". 
The application uses Entity Framework for database interaction and Bootstrap for user interface styling.

Project Details
--------------
Entity Model
The entity model used in this project is Employee with the following attributes:

ID: int (Primary Key)
Name: string
Email: string
Phone: string
Address: string
Created_At: DateTime

Database Interaction
-------------------
Entity Framework is used to interact with the database. The project follows the  Database-First approach, where the entity model is defined in the code, and the database schema is generated from the model.

CRUD Operations
--------------
The project implements the following CRUD operations:

Create: Allows users to add new tasks.
Read: Displays a list of tasks with details.
Update: Allows users to edit existing tasks.
Delete: Provides the option to delete tasks.

Validation
----------
Basic validation is implemented for input fields.Validation errors are handled gracefully.

User Interface
--------------
The user interface is designed to be simple and intuitive using Bootstrap for styling. 
The application includes navigation links between the list view and create/edit views to ensure a good user flow.

Getting Started (Prerequisites)
-------------------------------
1. Visual Studio 2022
2. SQL Server Management Studio (SSMS) 2022
3. .NET Framework (C#)

Project Structure
-----------------
Controllers: Contains the MVC controllers for handling CRUD operations.
Models: Contains the entity models and database context.
Views: Contains the Razor views for the user interface.

Usage
-----
1. Navigate to the home page to see the list of tasks.
2. Use the navigation links to create, edit, or delete tasks.

========================================================================================================================================================================



