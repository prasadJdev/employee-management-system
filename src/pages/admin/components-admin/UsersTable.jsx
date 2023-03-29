import React from "react";
import SortingSelectingTabel from "../../../components/tabels/SortingSelectingTabel";
import { rows } from "../utils/Users";

export default function UsersTable() {
  return <SortingSelectingTabel rows={rows} />;
}
