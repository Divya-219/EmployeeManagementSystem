import { Link } from "react-router-dom";

function Navbar() {
    return (
        <nav className="navbar">
            <h2>Employee Management System</h2>

            <div className="navbar-right">
                <Link to="/" className="navbar-home-link">
                    Home
                </Link>

                <span>Admin</span>

                <button type="button">
                    Logout
                </button>
            </div>
        </nav>
    );
}

export default Navbar;