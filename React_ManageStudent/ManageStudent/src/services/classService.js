import axios from "axios";

const API_URL = "/api/Class"; // Use relative path

export const getClasses = async () => {
  const response = await axios.get(`${API_URL}/GetAllClasses`);
  return response.data;
};

export const searchClassesByName = async (className) => {
  const response = await axios.get(
    `${API_URL}/SearchClassesByClassName?className=${className}`
  );
  return response.data;
};

export const addClass = async (classData) => {
  try {
    const response = await axios.post(`${API_URL}/AddNewClass`, classData);
    return response.data;
  } catch (error) {
    console.error("Error adding class:", error);
    throw error;
  }
};

export const deleteClass = async (className) => {
  try {
    const response = await axios.delete(`${API_URL}/DeleteClass`, {
      params: { className },
    });
    return response.data;
  } catch (error) {
    console.error("Error deleting class:", error);
    throw error;
  }
};

export const getAllClasses = async () => {
  const response = await axios.get(`${API_URL}/GetAllClasses`);
  return response.data;
};
