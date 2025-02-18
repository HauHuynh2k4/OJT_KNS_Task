import React, { useState } from "react";
import { useNavigate } from "react-router-dom";
import { register } from "../services/authService";

const Register = () => {
  const [username, setUsername] = useState("");
  const [email, setEmail] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const navigate = useNavigate();

  const handleRegister = async (e) => {
    e.preventDefault();
    setError("");

    try {
      const account = await register({ username, email, password });
      console.log("Registration successful:", account);

      if (account.role === "Teacher" || account.role === "Admin") {
        navigate("/menu", { state: { username: account.username } });
      } else if (account.role === "Student") {
        navigate("/students");
      }
    } catch (err) {
      console.error("Registration error:", err);
      setError("Registration failed");
    }
  };

  const handleNavigateBack = () => {
    navigate(-1); // Quay lại trang trước đó
  };

  return (
    <div className="container">
      <div className="header">
        <img src="/src/school-logo.jpg" alt="School Logo" />
        <h1>Register</h1>
      </div>
      {error && <p className="error">{error}</p>}
      <form onSubmit={handleRegister}>
        <div className="form-group">
          <label htmlFor="username">Username:</label>
          <input
            type="text"
            id="username"
            value={username}
            onChange={(e) => setUsername(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="email">Email:</label>
          <input
            type="email"
            id="email"
            value={email}
            onChange={(e) => setEmail(e.target.value)}
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="password">Password:</label>
          <input
            type="password"
            id="password"
            value={password}
            onChange={(e) => setPassword(e.target.value)}
            required
          />
        </div>
        <div className="button-group">
          <button type="submit">Register</button>
          <button type="button" onClick={handleNavigateBack}>
            Back
          </button>
        </div>
      </form>
    </div>
  );
};

export default Register;
