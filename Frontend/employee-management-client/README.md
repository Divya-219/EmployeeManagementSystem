# Employee Management System - Frontend

This is the frontend application for the Employee Management System.

The frontend is built with React and Vite and communicates with an ASP.NET Core Web API backend.

## Technologies Used

- React
- Vite
- JavaScript
- React Router
- HTML
- CSS
- REST API
- JWT Authentication
- Git / GitHub

## Project Structure

```text
employee-management-client/
├── public/
├── src/
│   ├── components/
│   │   ├── Layout.jsx
│   │   ├── Navbar.jsx
│   │   └── Sidebar.jsx
│   ├── pages/
│   │   ├── Home.jsx
│   │   ├── Login.jsx
│   │   ├── Dashboard.jsx
│   │   └── Employees.jsx
│   ├── routes/
│   │   └── AppRoutes.jsx
│   ├── services/
│   │   └── authService.js
│   ├── App.jsx
│   ├── main.jsx
│   └── index.css
├── .env.example
├── package.json
└── README.md

## Run the Application

Start the development server:

```bash
npm run dev
```

Open the local URL shown in your terminal, usually:

http://localhost:5173