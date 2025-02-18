import React, { useEffect } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { logout, getCurrentUser } from "../services/authService";

const Menu = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const username = location.state?.username || "User";

  useEffect(() => {
    const user = getCurrentUser();
    if (!user || (user.role !== "Teacher" && user.role !== "Admin")) {
      navigate("/");
    }
  }, [navigate]);

  const handleNavigateToStudentManagement = () => {
    navigate("/students");
  };

  const handleNavigateToClassManagement = () => {
    navigate("/classes");
  };

  const handleLogout = async () => {
    await logout();
    navigate("/");
  };

  return (
    <div className="container">
      <div className="header">
        <img src="/src/school-logo.jpg" alt="School Logo" />
        <h1>Welcome, {username}</h1>
      </div>
      <div className="button-group">
        <button onClick={handleNavigateToStudentManagement}>
          Quản lý học sinh
        </button>
        <button onClick={handleNavigateToClassManagement}>Quản lý lớp</button>
        <button onClick={handleLogout}>Log Out</button>
      </div>
    </div>
  );
};

export default Menu;
