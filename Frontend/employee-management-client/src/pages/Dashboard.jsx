
import { Link } from "react-router-dom";

function Dashboard() {
    // Sample data for now
    const totalEmployees = 2;
    const totalDepartments = 3;
    const totalRoles = 4;

    return (
        <div className="dashboard-page">
            <div className="dashboard-header">
                <div>
                    <h1>Dashboard</h1>
                    <p>Welcome back, Admin!</p>
                </div>
            </div>

            {/* Summary cards */}
            <div className="dashboard-cards">
                <div className="dashboard-card">
                    <h3>Total Employees</h3>
                    <p className="dashboard-number">
                        {totalEmployees}
                    </p>
                    <Link to="/employees">View Employees →</Link>
                </div>

                <div className="dashboard-card">
                    <h3>Total Departments</h3>
                    <p className="dashboard-number">
                        {totalDepartments}
                    </p>
                    <Link to="/departments">View Departments →</Link>
                </div>

                <div className="dashboard-card">
                    <h3>Total Roles</h3>
                    <p className="dashboard-number">
                        {totalRoles}
                    </p>
                    <Link to="/roles">View Roles →</Link>
                </div>
            </div>

            {/* Welcome section */}
            <div className="dashboard-welcome">
                <h2>Getting Started</h2>
                <p>
                    Use the Employee Management System to organize
                    employee information and manage your workforce.
                </p>

                <Link
                    to="/employees"
                    className="dashboard-button"
                >
                    Manage Employees
                </Link>
            </div>
        </div>
    );
}

export default Dashboard;
