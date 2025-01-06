Project Name: Financial Application
====================================
Description: This project creates an environment in which a person can manage the finances of a personal or small business. This utilizes .Net Core, Entity Framework Core, Angular Typescript, and PostgreSQL with a monolithic architecture. This project was created with the goal of learning full stack development as thoroughly as possible with an emphasis on learning the architecture of apps, how data passes through them, and how they scale. This project is continuously updated and improved.
------------------
Installation
------------------
Provide installation instructions.

Prerequisites
.NET Core 8 or later
Node.js 14 or later
Angular CLI
PostgreSQL 12 or later
Entity Framework Core

Backend (.NET Core)
Clone the repository: git clone https://github.com/grayson-spec/FinancialApplicaton
Navigate to the backend directory: cd backend
Restore NuGet packages: dotnet restore
Build the project: dotnet build
Run the migrations: dotnet ef database update
Start the API: dotnet run

Frontend (Angular)
Navigate to the frontend directory: cd frontend
Install dependencies: npm install
Start the Angular development server: ng serve
Database (PostgreSQL)
Create a new PostgreSQL database
Update the appsettings.json file with your database connection string
Environment Variables

ASPNETCORE_ENVIRONMENT: Set to Development or Production
DATABASE_URL: Set to your PostgreSQL database connection string
-----

