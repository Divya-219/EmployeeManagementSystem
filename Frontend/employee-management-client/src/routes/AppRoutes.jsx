import {BrowserRouter, Routes, Route} from 'react-router-dom';
import Home from "../pages/Home";
import Login from '../pages/Login';
import Dashboard from '../pages/Dashboard';
import Employees from '../pages/Employees';
import Departments from "../pages/Departments";
import Roles from "../pages/Roles";
import Layout from '../components/Layout';

function AppRoutes() {

    return(
        <BrowserRouter>
    <Routes>
        <Route path="/" element={<Home />} />
        <Route path="/login" element={<Login />} />
        <Route path="/dashboard" element={ <Layout><Dashboard /></Layout> } />
        <Route path="/employees" element={<Layout><Employees /></Layout>} />
        <Route path="/departments" element={<Layout><Departments /></Layout>} />
        <Route path="/roles" element={<Layout><Roles /></Layout>} />
    </Routes>
        </BrowserRouter>
    );
}
export default AppRoutes;