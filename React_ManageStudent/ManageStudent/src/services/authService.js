import axios from "axios";

const API_URL = "/api/Account"; // Use relative path

export const login = async (usernameOrEmail, password) => {
  const response = await axios.post(`${API_URL}/Login`, {
    usernameOrEmail,
    password,
  });
  return response.data;
};

export const register = async (userData) => {
  const response = await axios.post(`${API_URL}/Register`, userData);
  return response.data;
};

export const logout = async () => {
  await axios.post(`${API_URL}/Logout`);
  localStorage.removeItem("user");
};

export const getCurrentUser = () => {
  return JSON.parse(localStorage.getItem("user"));
};
