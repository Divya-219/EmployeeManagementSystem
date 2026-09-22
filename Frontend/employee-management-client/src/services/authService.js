const API_URL = import.meta.env.VITE_API_BASE_URL;

console.log("API URL:", API_URL);

export async function loginUser(email, password) {
    const response = await fetch(`${API_URL}/auth/login`, {
        method: "POST",
        headers: {
            "Content-Type": "application/json"
        },
        body: JSON.stringify({
            email: email,
            password: password
        })
    });

    if (!response.ok) {
        throw new Error(`Login failed: ${response.status}`);
    }

    const data = await response.json();

    return data;
}