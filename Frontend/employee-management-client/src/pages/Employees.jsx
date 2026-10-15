import {useState} from "react";
function Employees(){
    
    const[employees, setEmployees]=useState([
    {
        id: 1,
        name: "John Smith",
        email: "john@example.com",
        phone: "555-1234",
        status: "Active"
    },
    {
        id: 2,
        name: "Mary Johnson",
        email: "mary@example.com",
        phone: "555-5678",
        status: "Active"
    }
]);
const [showForm, setShowForm] = useState(false);
const [firstName, setFirstName] = useState("");
const [lastName, setLastName] = useState("");
const [email, setEmail] = useState("");
const [phone, setPhone] = useState("");
const [editingId, setEditingId] = useState(null);

{showForm && (
    <div className="employee-form">
        <h2>{editingId !== null ? "Edit Employee" : "Add New Employee"}</h2>
        <p>Your employee form will go here.</p>

        <button
            type="button"
            onClick={() => setShowForm(false)}
        >
            Cancel
        </button>
    </div>
)}
    function handleDelete(id)
    {
        const updatedEmployees=employees.filter((employee)=>employee.id!==id);
        setEmployees(updatedEmployees);
    }
function handleAddEmployee() {
    if (
        firstName.trim() === "" ||
        lastName.trim() === "" ||
        email.trim() === ""
    ) {
        alert("Please enter first name, last name, and email.");
        return;
    }

    if (editingId !== null) {
        const updatedEmployees = employees.map((employee) => {
            if (employee.id === editingId) {
                return {
                    ...employee,
                    name: `${firstName.trim()} ${lastName.trim()}`,
                    email: email.trim(),
                    phone: phone.trim()
                };
            }

            return employee;
        });

        setEmployees(updatedEmployees);
    } else {
        let newId = 1;

        if (employees.length > 0) {
            const highestId = Math.max(
                ...employees.map((employee) => employee.id)
            );

            newId = highestId + 1;
        }

        const newEmployee = {
            id: newId,
            name: `${firstName.trim()} ${lastName.trim()}`,
            email: email.trim(),
            phone: phone.trim(),
            status: "Active"
        };

        setEmployees([...employees, newEmployee]);
    }

    setFirstName("");
    setLastName("");
    setEmail("");
    setPhone("");
    setEditingId(null);
    setShowForm(false);
}
function handleEdit(employee) {
    setEditingId(employee.id);

    const nameParts = employee.name.split(" ");

    setFirstName(nameParts[0]);
    setLastName(nameParts.slice(1).join(" "));
    setEmail(employee.email);
    setPhone(employee.phone);

    setShowForm(true);
}

    return(
        <div className="employees-page">
            <div className="page-header"> 
            <div>
            <h1>Employees</h1>
            <p>Manage your employees here.</p>
            </div>
            <button className="add-employee-button" onClick={() => setShowForm(true)}>
                Add Employee
            </button>
        </div>
        {showForm && (
    <div className="employee-form">
       <h2>{editingId !== null ? "Edit Employee" : "Add New Employee"}</h2>

        <div className="form-group">
            <label htmlFor="firstName">First Name</label>
            <input
                id="firstName"
                type="text"
                value={firstName}
                onChange={(event) => setFirstName(event.target.value)}
                placeholder="Enter first name"
            />
        </div>

        <div className="form-group">
            <label htmlFor="lastName">Last Name</label>
            <input
                id="lastName"
                type="text"
                value={lastName}
                onChange={(event) => setLastName(event.target.value)}
                placeholder="Enter last name"
            />
        </div>

        <div className="form-group">
            <label htmlFor="email">Email</label>
            <input
                id="email"
                type="email"
                value={email}
                onChange={(event) => setEmail(event.target.value)}
                placeholder="Enter email"
            />
        </div>

        <div className="form-group">
            <label htmlFor="phone">Phone</label>
            <input
                id="phone"
                type="tel"
                value={phone}
                onChange={(event) => setPhone(event.target.value)}
                placeholder="Enter phone number"
            />
        </div>

       <button
    type="button"
    onClick={handleAddEmployee}
>
    Save Employee
</button>

        <button
            type="button"
            onClick={() => setShowForm(false)}
        >
            Cancel
        </button>
    </div>
)}

        <div className="employee-table-container">
            <table className="employee-table">
                <thead>
                    <tr>
                        <th>ID</th>
                        <th>Name</th>
                        <th>Email</th>
                        <th>Phone</th>
                        <th>Status</th>
                        <th>Actions</th>
                    </tr>
                </thead>
                <tbody>

    {employees.map((employee) => (
        <tr key={employee.id}>

            <td>{employee.id}</td>

            <td>{employee.name}</td>

            <td>{employee.email}</td>

            <td>{employee.phone}</td>

            <td>{employee.status}</td>

           <td className="employee-actions">
   <button
    className="edit-button"
    onClick={() => handleEdit(employee)}
>
    Edit
</button>

    <button className="delete-button" onClick={() => handleDelete(employee.id)}>
        Delete
    </button>
</td>
        </tr>
    ))}

</tbody>
            </table>
        </div>
        </div>
    );
}
export default Employees;