import { useEffect, useState } from "react";
import { useNavigate } from "react-router-dom";
import {
  getClasses,
  searchClassesByName,
  addClass,
  deleteClass,
} from "../services/classService";

function ClassManagement() {
  const [classes, setClasses] = useState([]);
  const [searchTerm, setSearchTerm] = useState("");
  const [newClass, setNewClass] = useState({
    classname: "",
    studentcount: 0,
  });
  const navigate = useNavigate();

  useEffect(() => {
    fetchClasses();
  }, []);

  const fetchClasses = async () => {
    const data = await getClasses();
    setClasses(data);
  };

  const handleSearch = async () => {
    if (searchTerm.trim() === "") {
      fetchClasses();
    } else {
      const data = await searchClassesByName(searchTerm);
      setClasses(data);
    }
  };

  const handleAddClass = async () => {
    try {
      await addClass(newClass);
      fetchClasses();
      setNewClass({ classname: "", studentcount: 0 });
    } catch (error) {
      console.error("Error adding class:", error);
    }
  };

  const handleDeleteClass = async (className) => {
    try {
      await deleteClass(className);
      fetchClasses();
    } catch (error) {
      console.error("Error deleting class:", error);
    }
  };

  const handleNavigateBack = () => {
    navigate(-1); // Quay lại trang trước đó
  };

  return (
    <div className="container">
      <div className="header">
        <img src="/src/school-logo.jpg" alt="School Logo" />
        <h1>Class Management</h1>
      </div>
      <div className="form-group">
        <input
          type="text"
          placeholder="Search by class name"
          value={searchTerm}
          onChange={(e) => setSearchTerm(e.target.value)}
        />
        <button onClick={handleSearch}>Search</button>
      </div>
      <div className="form-group">
        <input
          type="text"
          placeholder="Class Name"
          value={newClass.classname}
          onChange={(e) =>
            setNewClass({ ...newClass, classname: e.target.value })
          }
        />
        <input
          type="number"
          placeholder="Student Count"
          value={newClass.studentcount}
          onChange={(e) =>
            setNewClass({ ...newClass, studentcount: e.target.value })
          }
        />
        <button onClick={handleAddClass}>Add Class</button>
      </div>
      <ul>
        {classes.map((classItem) => (
          <li key={classItem.classname}>
            {classItem.classname} - {classItem.studentcount}
            <button onClick={() => handleDeleteClass(classItem.classname)}>
              Delete
            </button>
          </li>
        ))}
      </ul>
      <div className="button-group">
        <button onClick={handleNavigateBack}>Back</button>
      </div>
    </div>
  );
}

export default ClassManagement;
