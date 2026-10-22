
# Employee Management System

A full-stack project I am building as a  developer to learn backend and frontend development. The application is designed to help manage employee information through a web interface and a REST API.

## About the Project

I am developing this project to practise C#, ASP.NET Core Web API, Entity Framework Core, SQL Server, and React. I am building it step by step and improving my understanding of how the frontend communicates with the backend.

## Technologies Used

### Backend
- C# and ASP.NET Core Web API
- Entity Framework Core
- SQL Server
- Clean Architecture
- Repository Pattern
- DTOs
- MediatR 
- JWT authentication and role-based authorization
- Swagger for API testing

### Frontend
- React
- JavaScript
- HTML and CSS
- Vite
- React Router
- Fetching API data (integration in progress)

## Main Features

- Employee management API
- Department and role management APIs
- User registration and login
- JWT-based authentication
- Organised backend using separate project layers
- React pages for login, dashboard, and employee management

Some frontend features still use sample data while I work on connecting the UI to the backend API.

## Project Structure

```text
EmployeeManagementSystem/
├── EmployeeManagement.Domain/
├── EmployeeManagement.Application/
├── EmployeeManagement.Infrastructure/
├── EmployeeManagement.API/
├── Frontend/
│   └── employee-management-client/
└── README.md
```

- **Domain:** Contains the main entities and business rules.
- **Application:** Contains application logic, commands, queries, DTOs, and validation.
- **Infrastructure:** Handles database access and repository implementations.
- **API:** Provides HTTP endpoints for the frontend and other clients.
- **Frontend:** Contains the React user interface.

## How to Run the Project

### Backend

1. Install the .NET SDK and SQL Server.
2. Open `EmployeeManagementSystem.slnx` in Visual Studio.
3. Configure the database connection and required JWT settings using local development configuration or User Secrets.
4. Apply any required Entity Framework Core migrations.
5. Run the API project.
6. Open the Swagger page provided by the running API to explore and test endpoints.

### Frontend

1. Open a terminal in `Frontend/employee-management-client`.
2. Install dependencies:

   ```bash
   npm install
   ```

3. Configure the API base URL in a local `.env` file if required:

   ```env
   VITE_API_BASE_URL=https://localhost:7047/api
   ```

   Use the actual API URL shown when you run the backend.

4. Start the frontend:

   ```bash
   npm run dev
   ```

5. Open the local URL displayed in the terminal.

## What I Am Learning

- Building REST APIs with ASP.NET Core
- Applying Clean Architecture
- Working with Entity Framework Core and SQL Server
- Using dependency injection and the Repository Pattern
- Implementing authentication and authorization
- Building user interfaces with React
- Using Git and GitHub to manage project changes
- Connecting a frontend application to a backend API

## Future Improvements

- Complete frontend and backend API integration
- Finish employee create, update, and delete flows in the UI
- Improve error handling and form validation
- Add unit tests
- Improve the user interface and accessibility
- Explore deployment options

## Author

**Divya Patel**

 .NET Developer | Full-Stack Developer
