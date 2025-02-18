import { useState } from "react";
import reactLogo from "./assets/react.svg";
import viteLogo from "/vite.svg";
import "./App.css";
import { BrowserRouter as Router, Route, Routes } from "react-router-dom";
import Login from "./components/Login";
import Register from "./components/Register";
import StudentManagement from "./components/StudentManagement";
import ClassManagement from "./components/ClassManagement";
import Menu from "./components/Menu";
import UpdateStudent from "./components/UpdateStudent";

function App() {
  return (
    <Router>
      <Routes>
        <Route path="/" element={<Login />} />
        <Route path="/register" element={<Register />} />
        <Route path="/menu" element={<Menu />} />
        <Route path="/students" element={<StudentManagement />} />
        <Route path="/classes" element={<ClassManagement />} />
        <Route path="/update-student" element={<UpdateStudent />} />
      </Routes>
    </Router>
  );
}

export default App;
