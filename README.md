# Movie Management System

## 📌 Introduction

The Movie Management System is a platform that allows users to manage movies, showtimes, screening rooms, and online ticket booking. This project is a **Software Engineering capstone project** at **UIT (University of Information Technology, VNU-HCM)**. The system provides functionalities for both **users** and **administrators** to enhance the movie booking experience and efficiently manage cinemas.

## 🎬 Features

### User Features:
- Browse movies, view details, and check showtimes.
- Select seats and book tickets online.
- Make payments via multiple methods.
- Receive notifications for booking confirmation.

### Admin Features:
- Manage movies, categories, and showtimes.
- Manage theaters, screening rooms, and seating arrangements.
- Oversee ticket sales, revenue reports, and system statistics.

## 🚀 Technologies Used

- **Backend:** ASP.NET Core 8, Entity Framework Core
- **Frontend:** React.js (or any frontend framework if applicable)
- **Database:** SQL Server
- **Realtime:** SignalR
- **Authentication & Authorization:** JWT, ASP.NET Identity
- **Deployment:** Docker, CI/CD

## 📂 Project Structure

```
Movie_Management/
│-- Infrastructure/         # Data access logic layer
│-- Domain/                # Entity and business logic layer
│-- Application/           # Service and use case layer
│-- Presentation/          # API controllers
│-- Migrations/            # Database migration files
│-- Properties/            # Application configurations
│-- Utils/Enums/           # Common enums
│-- bin/ & obj/            # Build files
│-- Dockerfile             # Docker configuration
│-- Program.cs             # Application startup file
│-- appsettings.json       # Application settings
│-- WebApplication1.sln    # Solution file
```

## ⚙️ Installation & Running the Project

### 1️⃣ Requirements

- .NET 8 SDK
- SQL Server
- Node.js (if frontend is included)
- Docker (if running as a container)

### 2️⃣ Setup

```sh
git clone https://github.com/Marethy/Movie_Management.git
cd Movie_Management
dotnet restore
dotnet ef database update
dotnet run
```

If using Docker:

```sh
docker build -t movie_management .
docker run -p 5000:5000 movie_management
```

## 🛠 Key APIs

- **Movies**: CRUD operations for movies, filter by categories
- **Showtimes**: Manage movie schedules per theater
- **Screening Rooms**: Manage seat availability and status
- **Users**: Register, login, book tickets, make payments
- **Admins**: Manage cinemas, movies, showtimes, and financial reports

## 📌 Contributions

All contributions are welcome! Feel free to create a Pull Request or report issues at [Issues](https://github.com/Marethy/Movie_Management/issues).

## 📜 License

This project is licensed under the **MIT** License.

---
✉️ If you have any questions, feel free to contact [Marethy](https://github.com/Marethy)!

