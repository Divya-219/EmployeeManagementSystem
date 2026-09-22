import{useState} from 'react';
import { loginUser } from "../services/authService";

function Login() 
{
    const[email,setEmail]=useState('');
    const[password,setPassword]=useState('');
   const handleSubmit = async (event) => {
    event.preventDefault();

    try {
        const data = await loginUser(email, password);

        localStorage.setItem("token", data.token);

        console.log("login successful");
    } catch (error) {
        console.error("Login failed:", error);
    }
    };
    return (
        <div className="login-page">
            <div className="login-card">
                <h1>Employee Management System</h1>
                <h2>Login</h2>
                <p className="login-subtitle">Sign in to your account</p>
                <form onSubmit={handleSubmit}>
                    <div className="form-group">
                        <label htmlFor="email">Email</label>
                        <input type="email" placeholder="Enter your email" value={email}
                        onChange={(event)=>setEmail(event.target.value)} required/>
                        </div>
                    <div className="form-group">
                        <label htmlFor="password">Password</label>
                        <input type="password" placeholder="Enter your password" value={password}
                        onChange={(event)=>setPassword(event.target.value)} required/>
                    </div>
                    <button type="submit">Login</button>
                </form>
            </div>

            </div>
    )
}
export default Login;
