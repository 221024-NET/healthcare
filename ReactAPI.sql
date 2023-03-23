CREATE DATABASE P2;

CREATE TABLE Patients(
    patient_id int NOT NULL IDENTITY(1,1),
    email varchar(100) UNIQUE,
    name varchar(100) NOT NULL,
    password varchar(100) NOT NULL,
    PRIMARY KEY(patient_id)
);

DROP TABLE Patients;

CREATE TABLE Employees(
    employee_id int NOT NULL IDENTITY(1,1),
    email varchar(100) UNIQUE,
    name varchar(100) NOT NULL,
    password varchar(100) NOT NULL,
    PRIMARY KEY(employee_id)
);

Drop table Employees;

CREATE TABLE Claims(
    id int NOT NULL IDENTITY(1,1),
    customer_id int NOT NULL,
    date_submitted date NOT NULL,
    amount float NOT NULL,
    details varchar(MAX) NOT NULL,
    reviewed_by int,
    status varchar(50) NOT NULL,
    FOREIGN KEY(customer_id) REFERENCES Patients(patient_id),
    FOREIGN KEY(reviewed_by) REFERENCES Employees(employee_id)
);

DROP TABLE Claims;

SELECT * FROM Claims;

INSERT INTO Patients(email, name, password) VALUES
    ('patient@patient.com', 'patient', 'patient');
INSERT INTO Employees(email, name, password) VALUES
    ('employee@employee.com', 'employee', 'employee');