import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  getStudents,
  addStudent,
  updateStudent,
  deleteStudent,
  searchStudentsByName,
} from "../services/studentService";
import { getAllClasses } from "../services/classService";

function StudentManagement() {
  const [students, setStudents] = useState([]);
  const [classes, setClasses] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [newStudent, setNewStudent] = useState({
    studentname: "",
    classname: "",
    academicperformance: "",
  });
  const navigate = useNavigate();

  useEffect(() => {
    fetchStudents();
    fetchClasses();
  }, []);

  const fetchStudents = async () => {
    const data = await getStudents();
    setStudents(data);
  };

  const fetchClasses = async () => {
    const data = await getAllClasses();
    setClasses(data);
  };

  const handleSearch = async () => {
    if (searchTerm.trim() === "") {
      fetchStudents();
    } else {
      const data = await searchStudentsByName(searchTerm);
      setStudents(data);
    }
  };

  const handleAddStudent = async () => {
    try {
      await addStudent(newStudent);
      fetchStudents();
      setNewStudent({
        studentname: "",
        classname: "",
        academicperformance: "",
      });
    } catch (error) {
      console.error("Error adding student:", error);
    }
  };

  const handleUpdateStudent = (student) => {
    navigate("/update-student", { state: { student } });
  };

  const handleDeleteStudent = async (student) => {
    try {
      await deleteStudent(student);
      fetchStudents();
    } catch (error) {
      console.error("Error deleting student:", error);
    }
  };

  return (
    <div className="container">
      <div className="header">
        <img src="/src/school-logo.jpg" alt="School Logo" />
        <h1>Student Management</h1>
      </div>
      <div className="form-group">
        <input
          type="text"
          placeholder="Search by student name"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      <div className="form-group">
        <input
          type="text"
          placeholder="Student Name"
          value={newStudent.studentname}
          onChange={(e) =>
            setNewStudent({ ...newStudent, studentname: e.target.value })
          }
        />
        <select
          value={newStudent.classname}
          onChange={(e) =>
            setNewStudent({ ...newStudent, classname: e.target.value })
          }
        >
          <option value="">Select Class</option>
          {classes.map((classItem) => (
            <option key={classItem.classname} value={classItem.classname}>
              {classItem.classname}
            </option>
          ))}
        </select>
        <select
          value={newStudent.academicperformance}
          onChange={(e) =>
            setNewStudent({
              ...newStudent,
              academicperformance: e.target.value,
            })
          }
        >
          <option value="">Select Performance</option>
          <option value="Excellent">Excellent</option>
          <option value="Good">Good</option>
          <option value="Average">Average</option>
        </select>
        <button onClick={handleAddStudent}>Add Student</button>
      </div>
      <ul>
        {students.map((student) => (
          <li key={student.studentid}>
            {student.studentname} - {student.classname} -{" "}
            {student.academicperformance}
            <button onClick={() => handleUpdateStudent(student)}>Update</button>
            <button onClick={() => handleDeleteStudent(student)}>Delete</button>
          </li>
        ))}
      </ul>
      <div className="button-group">
        <button onClick={() => navigate(-1)}>Back</button>
      </div>
    </div>
  );
}

export default StudentManagement;
