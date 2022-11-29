CREATE TABLE Patients(
    patient_id int NOT NULL IDENTITY(1,1),
    email varchar(100) UNIQUE,
    name varchar(100) NOT NULL,
    password varchar(MAX) NOT NULL,
    salt varchar(50) NOT NULL
);

CREATE TABLE Employees(
    employee_id int NOT NULL IDENTITY(1,1),
    email varchar(100) UNIQUE,
    name varchar(100) NOT NULL,
    password varchar(MAX) NOT NULL,
    salt varchar(50) NOT NULL
);

CREATE TABLE Claims(
    customer_id int NOT NULL,
    date_submitted date NOT NULL,
    amount float NOT NULL,
    details varchar(MAX) NOT NULL,
    reviewed_by int,
    status varchar(50) NOT NULL,
    FOREIGN KEY(customer_id) REFERENCES Patients(patient_id),
    FOREIGN KEY(reviewed_by) REFERENCES Employees(employee_id)
);
