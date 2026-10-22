
import { Link } from "react-router-dom";

function Home() {
    return (
        <div className="home-page">
            <nav className="home-navbar">
                <div className="home-brand">
                    <div className="brand-icon">E</div>
                    <div>
                        <h2>Employee Management System</h2>
                        <p>Workforce Management</p>
                    </div>
                </div>

                <Link to="/login" className="home-login-link">
                    Login →
                </Link>
            </nav>

            <main className="home-main">
                <section className="home-hero">
                    <span className="home-label">WELCOME</span>

                    <h1>
                        Manage your employees
                        <br />
                        <span>with ease.</span>
                    </h1>

                    <p>
                        A simple application to organize employee records,
                        departments, and roles in one place.
                    </p>

                    <Link to="/login" className="home-primary-button">
                        Get Started →
                    </Link>
                </section>

                <section className="home-features">
                    <h2>Manage your workforce</h2>

                    <div className="home-feature-grid">
                        <article className="home-feature-card">
                            <div className="feature-icon">01</div>
                            <h3>Employees</h3>
                            <p>
                                Add, view, update, and manage employee
                                information.
                            </p>
                        </article>

                        <article className="home-feature-card">
                            <div className="feature-icon">02</div>
                            <h3>Departments</h3>
                            <p>
                                Organize employees by department and
                                keep team information clear.
                            </p>
                        </article>
                    </div>
                </section>
            </main>

            <footer className="home-footer">
                Built with React and ASP.NET Core
            </footer>
        </div>
    );
}

export default Home;

