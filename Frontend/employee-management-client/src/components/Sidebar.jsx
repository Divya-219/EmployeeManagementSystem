import{Link} from "react-router-dom";
function Sidebar()
{
    return (
        <aside className="sidebar">
            <h3>Menu</h3>
            <ul className="sidebar-menu">
                <li><Link to="/dashboard">Dashboard</Link></li>
                <li><Link to="/employees">Employees</Link></li>
                <li><Link to="/departments">Departments</Link></li>
            </ul>  
        </aside>
    );
}
export default Sidebar;