DROP TABLE IF EXISTS enrollment;
DROP TABLE IF EXISTS section;
DROP TABLE IF EXISTS semester;
DROP TABLE IF EXISTS course;
DROP TABLE IF EXISTS program;
DROP TABLE IF EXISTS student;

CREATE TABLE student (
    id INT AUTO_INCREMENT PRIMARY KEY,
    firstname VARCHAR(100),
    lastname VARCHAR(100),
    student_id VARCHAR(50),
    birthdate DATE
);

CREATE TABLE program (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100)
);

CREATE TABLE course (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100),
    code VARCHAR(50),
    program_id INT,
    FOREIGN KEY (program_id) REFERENCES program(id)
);

CREATE TABLE semester (
    id INT AUTO_INCREMENT PRIMARY KEY,
    name VARCHAR(100),
    start_date DATE,
    end_date DATE
);
CREATE TABLE section (
    id INT AUTO_INCREMENT PRIMARY KEY,
    course_id INT,
    semester_id INT,
    days_offered VARCHAR(50),
    time_offered TIME,
    FOREIGN KEY (course_id) REFERENCES course(id),
    FOREIGN KEY (semester_id) REFERENCES semester(id)
);

CREATE TABLE enrollment (
    id INT AUTO_INCREMENT PRIMARY KEY,
    student_id INT,
    section_id INT,
    FOREIGN KEY (student_id) REFERENCES student(id),
    FOREIGN KEY (section_id) REFERENCES section(id)
);