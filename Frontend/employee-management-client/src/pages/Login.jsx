import{useState} from 'react';
import { loginUser } from "../services/authService";
import { useNavigate } from "react-router-dom";

function Login() 
{
    const[email,setEmail]=useState('');
    const[password,setPassword]=useState('');
    const [error, setError] = useState("");
    const [loading, setLoading] = useState(false);

    const navigate = useNavigate();

    const handleSubmit = async (event) => {
        event.preventDefault();

        setError("");
        setLoading(true);

        try {
            const data = await loginUser(email, password);

            if (!data.token) {
                throw new Error("Login response did not contain a token.");
            }

            localStorage.setItem("token", data.token);

            navigate("/dashboard");
        } catch (error) {
            setError(
                error.response?.data?.message ||
                error.message ||
                "Login failed. Please check your email and password."
            );
        } finally {
            setLoading(false);
        }
    };

    return (
        <div className="login-page">
            <div className="login-card">
                <h1>Employee Management System</h1>
                <h2>Login</h2>
                <p className="login-subtitle">
                    Sign in to your account
                </p>

                {error && (
                    <p className="login-error" role="alert">
                        {error}
                    </p>
                )}

                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="email">Email</label>
                        <input
                            id="email"
                            type="email"
                            placeholder="Enter your email"
                            value={email}
                            onChange={(event) =>
                                setEmail(event.target.value)
                            }
                            required
                        />
                    </div>

                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input
                            id="password"
                            type="password"
                            placeholder="Enter your password"
                            value={password}
                            onChange={(event) =>
                                setPassword(event.target.value)
                            }
                            required
                        />
                    </div>

                    <button type="submit" disabled={loading}>
                        {loading ? "Logging in..." : "Login"}
                    </button>
                </form>
            </div>
        </div>
    );
}

export default Login;
