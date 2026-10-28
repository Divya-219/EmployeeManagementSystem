
import { useState } from "react";
function Roles() {
    const [roles, setRoles] = useState([
        {
            id: 1,
            name: "Software Developer",
            description: "Develops and maintains applications"
        },
        {
            id: 2,
            name: "HR Manager",
            description: "Manages employee-related activities"
        },
        {
            id: 3,
            name: "Accountant",
            description: "Handles financial activities"
        }
    ]);

    const [showForm, setShowForm] = useState(false);
    const [editingId, setEditingId] = useState(null);
    const [name, setName] = useState("");
    const [description, setDescription] = useState("");

    function handleSubmit(event) {
        event.preventDefault();

        const roleName = name.trim();
        const roleDescription = description.trim();

        if (!roleName) {
            return;
        }

        if (editingId !== null) {
            // Update an existing role
            setRoles(previousRoles =>
                previousRoles.map(role =>
                    role.id === editingId
                        ? {
                            ...role,
                            name: roleName,
                            description: roleDescription
                        }
                        : role
                )
            );
        } else {
            // Add a new role
            const newRole = {
                id: Date.now(),
                name: roleName,
                description: roleDescription
            };

            setRoles(previousRoles => [
                ...previousRoles,
                newRole
            ]);
        }

        resetForm();
    }

    function handleEdit(role) {
        setEditingId(role.id);
        setName(role.name);
        setDescription(role.description);
        setShowForm(true);
    }

    function handleDelete(id) {
        const confirmed = window.confirm(
            "Are you sure you want to delete this role?"
        );

        if (!confirmed) {
            return;
        }

        setRoles(previousRoles =>
            previousRoles.filter(role => role.id !== id)
        );
    }

    function resetForm() {
        setName("");
        setDescription("");
        setEditingId(null);
        setShowForm(false);
    }

    return (
        <div className="roles-page">
            <div className="roles-header">
                <div>
                    <h1>Roles</h1>
                    <p>Manage employee job roles.</p>
                </div>

                <button
                    type="button"
                    className="role-add-button"
                    onClick={() => {
                        resetForm();
                        setShowForm(true);
                    }}
                >
                    + Add Role
                </button>
            </div>

            {showForm && (
                <div className="role-form-card">
                    <h2>
                        {editingId !== null
                            ? "Edit Role"
                            : "Add Role"}
                    </h2>

                    <form onSubmit={handleSubmit}>
                        <div className="role-form-group">
                            <label htmlFor="roleName">
                                Role Name
                            </label>

                            <input
                                id="roleName"
                                type="text"
                                placeholder="Enter role name"
                                value={name}
                                onChange={event =>
                                    setName(event.target.value)
                                }
                                required
                            />
                        </div>

                        <div className="role-form-group">
                            <label htmlFor="roleDescription">
                                Description
                            </label>

                            <textarea
                                id="roleDescription"
                                placeholder="Enter role description"
                                value={description}
                                onChange={event =>
                                    setDescription(event.target.value)
                                }
                                rows="3"
                            />
                        </div>

                        <div className="role-form-actions">
                            <button type="submit">
                                {editingId !== null
                                    ? "Save Changes"
                                    : "Add Role"}
                            </button>

                            <button
                                type="button"
                                className="role-cancel-button"
                                onClick={resetForm}
                            >
                                Cancel
                            </button>
                        </div>
                    </form>
                </div>
            )}

            <div className="roles-table-card">
                <h2>Role List</h2>

                <div className="roles-table-wrapper">
                    <table className="roles-table">
                        <thead>
                            <tr>
                                <th>ID</th>
                                <th>Role Name</th>
                                <th>Description</th>
                                <th>Actions</th>
                            </tr>
                        </thead>

                        <tbody>
                            {roles.length === 0 ? (
                                <tr>
                                    <td colSpan="4">
                                        No roles found.
                                    </td>
                                </tr>
                            ) : (
                                roles.map(role => (
                                    <tr key={role.id}>
                                        <td>{role.id}</td>
                                        <td>{role.name}</td>
                                        <td>{role.description || "—"}</td>
                                        <td>
                                            <div className="role-actions">
                                                <button
                                                    type="button"
                                                    className="role-edit-button"
                                                    onClick={() =>
                                                        handleEdit(role)
                                                    }
                                                >
                                                    Edit
                                                </button>

                                                <button
                                                    type="button"
                                                    className="role-delete-button"
                                                    onClick={() =>
                                                        handleDelete(role.id)
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
export default Roles;
