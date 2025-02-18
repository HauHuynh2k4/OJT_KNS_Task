import React, { useState, useEffect } from "react";
import { useNavigate, useLocation } from "react-router-dom";
import { updateStudent } from "../services/studentService";
import { getAllClasses } from "../services/classService";

const UpdateStudent = () => {
  const navigate = useNavigate();
  const location = useLocation();
  const student = location.state?.student || {};

  const [studentData, setStudentData] = useState({
    studentid: student.studentid || "",
    studentname: student.studentname || "",
    classname: student.classname || "",
    academicperformance: student.academicperformance || "",
  });

  const [classes, setClasses] = useState([]);

  useEffect(() => {
    fetchClasses();
  }, []);

  const fetchClasses = async () => {
    const data = await getAllClasses();
    setClasses(data);
  };

  const handleUpdate = async (e) => {
    e.preventDefault();
    try {
      await updateStudent(studentData);
      navigate("/students");
    } catch (error) {
      console.error("Error updating student:", error);
    }
  };

  const handleNavigateBack = () => {
    navigate(-1); // Quay lại trang trước đó
  };

  return (
    <div className="container">
      <div className="header">
        <img src="/src/school-logo.jpg" alt="School Logo" />
        <h1>Update Student Information</h1>
      </div>
      <form onSubmit={handleUpdate}>
        <div className="form-group">
          <label htmlFor="studentname">Student Name:</label>
          <input
            type="text"
            id="studentname"
            value={studentData.studentname}
            onChange={(e) =>
              setStudentData({ ...studentData, studentname: e.target.value })
            }
            required
          />
        </div>
        <div className="form-group">
          <label htmlFor="classname">Class Name:</label>
          <select
            id="classname"
            value={studentData.classname}
            onChange={(e) =>
              setStudentData({ ...studentData, classname: e.target.value })
            }
            required
          >
            <option value="">Select Class</option>
            {classes.map((classItem) => (
              <option key={classItem.classname} value={classItem.classname}>
                {classItem.classname}
              </option>
            ))}
          </select>
        </div>
        <div className="form-group">
          <label htmlFor="academicperformance">Academic Performance:</label>
          <select
            id="academicperformance"
            value={studentData.academicperformance}
            onChange={(e) =>
              setStudentData({
                ...studentData,
                academicperformance: e.target.value,
              })
            }
            required
          >
            <option value="">Select Performance</option>
            <option value="Excellent">Excellent</option>
            <option value="Good">Good</option>
            <option value="Average">Average</option>
          </select>
        </div>
        <div className="button-group">
          <button type="submit">Update Student</button>
          <button type="button" onClick={handleNavigateBack}>
            Back
          </button>
        </div>
      </form>
    </div>
  );
};

export default UpdateStudent;
