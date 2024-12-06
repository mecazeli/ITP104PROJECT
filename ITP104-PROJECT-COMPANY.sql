-- CREATE DATABASE company;
-- use company;
-- CREATE TABLE department(
--      departmentId INT PRIMARY KEY AUTO_INCREMENT,
--      departmentName VARCHAR(100),
--      description VARCHAR(150)
-- ); 

-- CREATE TABLE employee(
-- 	employeeId INT PRIMARY KEY AUTO_INCREMENT,
--     employeeName VARCHAR(100),
--     age INT,
--     gender ENUM('Male','Female','Prefer Not To Say','Other'),
--     address VARCHAR(150),
--     email VARCHAR(100),
--     position VARCHAR(100),
--     datehired DATE,
--     salary DECIMAL(10,2),
--     departmentId INT,
--     FOREIGN KEY(departmentId) REFERENCES department(departmentId) 
--             ON DELETE CASCADE
--             ON UPDATE CASCADE
-- );

-- CREATE TABLE project(
--    projectId INT PRIMARY KEY AUTO_INCREMENT,
--    projectName VARCHAR(50),
--    startDate DATE,
--    endDate DATE,
--    status ENUM('Pending','In Progress','Completed'),
--    departmentId INT,
--     FOREIGN KEY(departmentId) REFERENCES department(departmentId) 
--             ON DELETE CASCADE
--             ON UPDATE CASCADE
-- );

-- CREATE TABLE task(
--    taskId INT PRIMARY KEY AUTO_INCREMENT,
--    taskName VARCHAR(100),
--    deadline DATE,
--    projectId INT,
--    employeeId INT,
--    FOREIGN KEY(projectId) REFERENCES project(projectId) 
--             ON DELETE CASCADE
--             ON UPDATE CASCADE,
--     FOREIGN KEY(employeeId) REFERENCES employee(employeeId) 
--             ON DELETE CASCADE
--             ON UPDATE CASCADE
-- );


-- INSERT INTO department(departmentName,description) VALUES 
--      ("IT Department", "Oversees technology, cybersecurity, and digital operations, ensuring seamless innovation in Velvaire's beauty solutions.");


-- INSERT INTO employee(employeeName,age,gender,address,email,position,datehired,salary,departmentId)
--       VALUES
--        ('Liezel T. Paciente',25,'Female','123 Main St.Santa Rosa,Laguna','liezelpaciente123@gmail.com','Software Engineer','2023-01-15',60000.00,1);
--        
-- INSERT INTO project(projectName, startDate, endDate, status, departmentId)
-- VALUES 
--     ('Project A', '2024-01-01', '2024-12-31', 'In Progress', 1),
--     ('Project B', '2024-02-01', '2024-06-30', 'Pending', 1),
--     ('Project C', '2024-03-01', '2024-09-30', 'Completed', 1); 
-- INSERT INTO task(taskName, deadline, projectId, employeeId)
-- VALUES
--     ('Task 1: Initial Research', '2024-12-15', 1, 1);
 
       
SELECT * FROM department;
SELECT * FROM employee;
SELECT * FROM project;
SELECT * FROM task;