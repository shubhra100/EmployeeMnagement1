# 🏢 Employee Management System (Full Stack Project)

## 📖 Project Overview

The Employee Management System is a Full Stack Web Application developed to manage employees, attendance, and leave requests efficiently.

The system provides secure backend APIs built with ASP.NET Core Web API and a responsive frontend interface for managing operations in real-time.

This project demonstrates end-to-end development including database design, API development, business logic implementation, and frontend integration.

---

## 🚀 Features

### 👨‍💼 Employee Management
- Add new employees
- Update employee details
- Delete employees
- View employee list
- Unique email validation

### 🗓 Attendance Management
- Mark daily attendance
- Prevent duplicate attendance
- View attendance records
- Attendance summary dashboard

### 📝 Leave Management
- Apply for leave
- Approve or reject leave
- Leave status tracking (Pending / Approved / Rejected)
- View leave history per employee

### 📊 Dashboard
- Total Employees
- Total Present Today
- Total Absent Today
- Total Pending Leaves

---

## 🛠 Tech Stack

### 🔹 Backend
- .NET 10 (ASP.NET Core Web API)
- Entity Framework Core (Database First)
- SQL Server
- Swagger (API Testing)
- CORS Enabled

### 🔹 Frontend
- HTML / CSS / Bootstrap
- JavaScript / Angular (if applicable)
- REST API Integration

---

## 🏗 Architecture

The project follows a layered architecture:
Presentation Layer (Frontend)
↓
API Layer (Controllers)
↓
Business Logic
↓
Data Access Layer (EF Core)
↓
SQL Server Database


---

## 🗄 Database Design

### Employees
- Id (Primary Key)
- FullName
- Email (Unique)
- Department
- Salary
- UserId (Foreign Key)

### Attendance
- Id (Primary Key)
- EmployeeId (Foreign Key)
- AttendanceDate
- IsPresent
- Unique(EmployeeId + AttendanceDate)

### LeaveRequests
- Id (Primary Key)
- EmployeeId (Foreign Key)
- StartDate
- EndDate
- Reason
- Status (Pending / Approved / Rejected)
- AppliedOn

---
