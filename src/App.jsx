import { Route, Routes } from "react-router";
import "./App.css";
import Login from "./pages/login";
import Admin from "./pages/admin";
import AdminUsers from "./pages/admin/AdminUsers";
import AdminRequests from "./pages/admin/AdminRequests";

import User from "./pages/user";
import UserFiles from "./pages/user/UserFiles";
import UserRequests from "./pages/user/UserRequests";

function App() {
  return (
    <Routes>
      <Route path="/" element={<Login />} />
      <Route path="login" element={<Login />} />
      <Route path="admin" element={<Admin />}>
        {/* <Admin /> will be a layout for the entire Admin theme */}
        <Route path="users" element={<AdminUsers />} />
        {/*<AdminUsers /> Using Layout it will display all Users */}
        <Route path="requests" element={<AdminRequests />} />
      </Route>
      <Route path="user" element={<User />}>
        {/* <Admin /> will be a layout for the entire Admin theme */}
        <Route path="files" element={<UserFiles />} />
        {/*<AdminUsers /> Using Layout it will display all Users */}
        <Route path="requests" element={<UserRequests />} />
      </Route>
    </Routes>
  );
}

export default App;
