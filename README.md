# DVLD (Driving & Vehicle License Department) System

## 🚀 Overview
An enterprise-grade management system designed to automate and streamline license issuance and traffic department operations. This project is built using **.NET Core** to ensure high performance, security, and modern development standards, transitioning from legacy frameworks to a more robust, cross-platform runtime.

---

## 🏗️ Architecture: Strict 3-Tier Pattern
The system follows a decoupled **3-Tier Architecture** to maintain a clean separation of concerns (SoC), making the codebase modular, testable, and easy to maintain:



* **Presentation Layer (PL):** A modern, responsive desktop interface built with **.NET Core WinForms**. It handles user interactions and input validation.
* **Business Logic Layer (BLL):** The core of the application that manages business rules, license eligibility logic, and complex workflows.
* **Data Access Layer (DAL):** A high-efficiency layer focused on data operations using **ADO.NET** and **SQL Server**, ensuring decoupled communication between the database and the logic.

---

## 🛠️ Tech Stack
| Category | Technology |
| :--- | :--- |
| **Framework** | .NET Core (Modern Runtime) |
| **Language** | C# |
| **Database** | Microsoft SQL Server |
| **Data Access** | ADO.NET |
| **Configuration** | JSON-based (`appsettings.json`) |

---

## 🌟 Key Engineering Highlights
* **Data Integrity:** Designed with **10+ Normalized tables**, ensuring strict referential integrity and zero data redundancy.
* **Scalability:** Specifically architected to handle complex, real-world workflows such as Local/International licenses, renewals, and replacements (Lost/Damaged).
* **Manual Engineering Excellence:** Developed entirely through manual scaffolding to master architectural patterns. This experience served as the direct inspiration for my **Custom Code Generator** project.

---

## ⚙️ Configuration & Setup

### 1. Database Setup
Execute the SQL script found in the `/database` folder to recreate the schema and initial data:
```sql
-- File: /database/DVLD_DB.sql
