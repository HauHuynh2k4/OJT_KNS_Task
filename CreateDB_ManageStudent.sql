-- Tạo bảng Account với Username và Email là khóa chính
CREATE TABLE Account (
    Username VARCHAR(50) NOT NULL,       -- Tên tài khoản
    Password VARCHAR(255) NOT NULL,      -- Mật khẩu
    Email VARCHAR(100) NOT NULL,         -- Gmail
    Role VARCHAR(20) NOT NULL,           -- Vai trò (Admin, Teacher, Student)
    PRIMARY KEY (Username, Email)        -- Khóa chính là cặp Username và Email
);

-- Tạo bảng Class với ClassName là khóa chính
CREATE TABLE Class (
    ClassName VARCHAR(50) PRIMARY KEY,   -- Tên lớp (Khóa chính)
    StudentCount INT DEFAULT 0           -- Số lượng học sinh
);

-- Tạo bảng Student liên kết với Class bằng ClassName
CREATE TABLE Student (
    StudentID SERIAL PRIMARY KEY,        -- Khóa chính tự động tăng
    StudentName VARCHAR(100) NOT NULL,   -- Tên học sinh
    ClassName VARCHAR(50) REFERENCES Class(ClassName) ON DELETE CASCADE, -- Khóa ngoại
    AcademicPerformance VARCHAR(20)     -- Học lực (Giỏi, Khá, Trung bình, ...)
);
INSERT INTO Account (Username, Password, Email, Role) VALUES
('admin', 'admin123', 'admin@gmail.com', 'Admin'),
('teacher01', 'teacher123', 'teacher@gmail.com', 'Teacher'),
('student01', 'student123', 'student@gmail.com', 'Student');
INSERT INTO Class (ClassName, StudentCount) VALUES
('Class 10A', 3),
('Class 10B', 2),
('Class 10C', 2),
('Class 10D', 1);
INSERT INTO Student (StudentName, ClassName, AcademicPerformance) VALUES
('Nguyen Van An', 'Class 10A', 'Excellent'),
('Tran Thi Ba', 'Class 10A', 'Good'),
('Le Van Cá', 'Class 10A', 'Average'),
('Pham Thi Dao', 'Class 10B', 'Good'),
('Hoang Van Em', 'Class 10B', 'Excellent'),
('Le Van Con', 'Class 10C', 'Average'),
('Pham Thi Diễm', 'Class 10C', 'Good'),
('Hoang Van Én', 'Class 10D', 'Excellent');
