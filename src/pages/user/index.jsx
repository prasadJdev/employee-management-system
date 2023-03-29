import React from "react";
import Dashboard from "../../components/dashboard";
import ContentElement from "./components-users/ContentElement";
import theme from "./utils/UsersTheme";
export default function index() {
  return <Dashboard theme ={theme} ContentElement={ContentElement}/>;
}
