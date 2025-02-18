import axios from "axios";

const API_URL = "/api/Student"; // Use relative path

export const getStudents = async () => {
  const response = await axios.get(
    `${API_URL}/GetStudentByStudentName?StudentName=${""}`
  );
  return response.data;
};

export const addStudent = async (studentData) => {
  try {
    const response = await axios.post(`${API_URL}/AddNewStudent`, studentData);
    return response.data;
  } catch (error) {
    console.error("Error adding student:", error);
    throw error;
  }
};

export const updateStudent = async (studentData) => {
  try {
    const response = await axios.post(
      `${API_URL}/UpdateStudentInfo`,
      studentData
    );
    return response.data;
  } catch (error) {
    console.error("Error updating student:", error);
    throw error;
  }
};

export const deleteStudent = async (studentData) => {
  try {
    const response = await axios.delete(`${API_URL}/DeleteStudent`, {
      data: studentData,
    });
    return response.data;
  } catch (error) {
    console.error("Error deleting student:", error);
    throw error;
  }
};

export const searchStudentsByName = async (studentName) => {
  const response = await axios.get(
    `${API_URL}/GetStudentByStudentName?StudentName=${studentName}`
  );
  return response.data;
};
