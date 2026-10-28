
import { useState } from "react";

function Departments() {
    const [departments, setDepartments] = useState([
        { id: 1, name: "IT", description: "Information Technology" },
        { id: 2, name: "Human Resources", description: "Employee management" },
        { id: 3, name: "Finance", description: "Financial operations" }
    ]);

    const [showForm, setShowForm] = useState(false);
    const [editingId, setEditingId] = useState(null);
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");

    function handleSubmit(event) {
        event.preventDefault();
        const departmentName = name.trim();
        const departmentDescription = description.trim();

        if (!departmentName) {
            return;
        }

        if (editingId !== null) {
            // Update an existing department
            setDepartments(previousDepartments => previousDepartments.map(department =>
                    department.id === editingId
                        ? {
                            ...department,
                            name: departmentName,
                            description: departmentDescription
                        }
                        : department
                )
            );
        } else {
            // Add a new department
            const newDepartment = {
                id: Date.now(),
                name: departmentName,
                description: departmentDescription
            };

            setDepartments(previousDepartments => [ ...previousDepartments,
                newDepartment
            ]);
        }

        resetForm();
    }

    function handleEdit(department) {
        setEditingId(department.id);
        setName(department.name);
        setDescription(department.description);
        setShowForm(true);
    }

    function handleDelete(id) {
        const confirmed = window.confirm(
            "Are you sure you want to delete this department?"
        );

        if (!confirmed) {
            return;
        }

        setDepartments(previousDepartments =>
            previousDepartments.filter(department =>
                department.id !== id
            )
        );
    }

    function resetForm() {
        setName("");
        setDescription("");
        setEditingId(null);
        setShowForm(false);
    }

    return (
        <div className="departments-page">
            <div className="departments-header">
                <div>
                    <h1>Departments</h1>
                    <p>Manage your company departments.</p>
                </div>

                <button
                    type="button"
                    className="department-add-button"
                    onClick={() => {
                        resetForm();
                        setShowForm(true);
                    }}
                >
                    + Add Department
                </button>
            </div>

            {showForm && (
                <div className="department-form-card">
                    <h2>
                        {editingId !== null
                            ? "Edit Department"
                            : "Add Department"}
                    </h2>

                    <form onSubmit={handleSubmit}>
                        <div className="department-form-group">
                            <label htmlFor="departmentName">
                                Department Name
                            </label>

                            <input
                                id="departmentName"
                                type="text"
                                placeholder="Enter department name"
                                value={name}
                                onChange={event =>
                                    setName(event.target.value)
                                }
                                required
                            />
                        </div>

                        <div className="department-form-group">
                            <label htmlFor="departmentDescription">
                                Description
                            </label>

                            <textarea
                                id="departmentDescription"
                                placeholder="Enter department description"
                                value={description}
                                onChange={event =>
                                    setDescription(event.target.value)
                                }
                                rows="3"
                            />
                        </div>

                        <div className="department-form-actions">
                            <button type="submit">
                                {editingId !== null
                                    ? "Save Changes"
                                    : "Add Department"}
                            </button>

                            <button
                                type="button"
                                className="department-cancel-button"
                                onClick={resetForm}
                            >
                                Cancel
                            </button>
                        </div>
                    </form>
                </div>
            )}

            <div className="departments-table-card">
                <h2>Department List</h2>

                <div className="departments-table-wrapper">
                    <table className="departments-table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Department Name</th>
                                <th>Description</th>
                                <th>Actions</th>
                            </tr>
                        </thead>

                        <tbody>
                            {departments.length === 0 ? (
                                <tr>
                                    <td colSpan="4">
                                        No departments found.
                                    </td>
                                </tr>
                            ) : (
                                departments.map(department => (
                                    <tr key={department.id}>
                                        <td>{department.id}</td>
                                        <td>{department.name}</td>
                                        <td>{department.description || "—"}</td>
                                        <td>
                                            <div className="department-actions">
                                                <button
                                                    type="button"
                                                    className="department-edit-button"
                                                    onClick={() =>
                                                        handleEdit(department)
                                                    }
                                                >
                                                    Edit
                                                </button>

                                                <button
                                                    type="button"
                                                    className="department-delete-button"
                                                    onClick={() =>
                                                        handleDelete(department.id)
                                                    }
                                                >
                                                    Delete
                                                </button>
                                            </div>
                                        </td>
                                    </tr>
                                ))
                            )}
                        </tbody>
                    </table>
                </div>
            </div>
        </div>
    );
}

export default Departments;

