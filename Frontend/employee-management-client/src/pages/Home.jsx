import { Link } from "react-router-dom";
function Home() {
    return (
        <div className="home-page">
            <section className="home-hero">
                <div className="home-hero-content">
                    <p className="home-label">
                        EMPLOYEE MANAGEMENT SYSTEM
                    </p>

                    <h1>
                        Manage your team
                        <span> in one place.</span>
                    </h1>

                    <p className="home-description">
                        A simple way to manage employee information,
                        organize your workforce, and keep your
                        employee records in one place.
                    </p>

                    <div className="home-actions">
                        <Link to="/login" className="home-primary-button">
                            Get Started
                        </Link>

                        <Link
                            to="/login"
                            className="home-secondary-button"
                        >
                            Sign In
                        </Link>
                    </div>
                </div>

                <div className="home-preview">
                    <div className="preview-header">
                        <div>
                            <p className="preview-label">WORKSPACE</p>
                            <h2>Team Overview</h2>
                        </div>

                        <span className="preview-status">
                            Active
                        </span>
                    </div>

                    <div className="preview-card">
                        <span>Total Employees</span>
                        <strong>Manage your team</strong>
                        <p>Keep employee records organized.</p>
                    </div>

                    <div className="preview-card">
                        <span>Employee Records</span>
                        <strong>All in one place</strong>
                        <p>Access employee information easily.</p>
                    </div>

                    <div className="preview-card">
                        <span>Workforce Management</span>
                        <strong>Stay organized</strong>
                        <p>Build a clear view of your workforce.</p>
                    </div>
                </div>
            </section>

            <section className="home-features">
                <div className="home-section-heading">
                    <p className="home-label">FEATURES</p>
                    <h2>Everything starts with a better overview</h2>
                    <p>
                        Navigate your employee management tasks
                        through one simple application.
                    </p>
                </div>

                <div className="feature-grid">
                    <article className="feature-card">
                        <div className="feature-icon">01</div>
                        <h3>Employee Records</h3>
                        <p>
                            Add, view, update, and manage employee
                            information.
                        </p>
                    </article>

                    <article className="feature-card">
                        <div className="feature-icon">02</div>
                        <h3>Organized Workforce</h3>
                        <p>
                            Prepare to manage departments and roles
                            in one application.
                        </p>
                    </article>

                    <article className="feature-card">
                        <div className="feature-icon">03</div>
                        <h3>Secure Access</h3>
                        <p>
                            Sign in to access features protected by
                            your account permissions.
                        </p>
                    </article>
                </div>
            </section>

            <footer className="home-footer">
                <p>Employee Management System</p>
                <p>Built with React and ASP.NET Core.</p>
            </footer>
        </div>
    );
}

export default Home;