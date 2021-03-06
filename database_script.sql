


DROP DATABASE Ayubo_drive;

DROP TABLE Hire;
DROP TABLE Package;
DROP TABLE Rent;
DROP TABLE Customer;
DROP TABLE Driver;
DROP TABLE Vehicle;
DROP TABLE VehicleType;
DROP TABLE VehicleRate;




CREATE DATABASE Ayubo_drive;





CREATE TABLE VehicleType(
V_Type_Id INT NOT NULL,
V_Type_Name VARCHAR(50),
V_Rate INT,
CONSTRAINT PK_VehicleType PRIMARY KEY (V_Type_Id),
);

INSERT INTO VehicleType VALUES (121,'Small car',100);
INSERT INTO VehicleType VALUES (122,'Sedan car',200);
INSERT INTO VehicleType VALUES (123,'SUV',300);
INSERT INTO VehicleType VALUES (124,'Jeep',400);
INSERT INTO VehicleType VALUES (125,'7-Seater van',500);
INSERT INTO VehicleType VALUES (126,'Commuter van',600);





CREATE TABLE Vehicle(
V_Id INT NOT NULL,
V_Type_ID INT,
CONSTRAINT Pk_Vehicle PRIMARY KEY (V_ID, V_Type_Id)
);

INSERT INTO Vehicle VALUES (1111,121);
INSERT INTO Vehicle VALUES (1112,121);
INSERT INTO Vehicle VALUES (1113,121);
INSERT INTO Vehicle VALUES (1114,121);



CREATE TABLE Driver(
D_Id INT IDENTITY (1,1) NOT NULL,
D_Name VARCHAR(50),
D_Rate_Per_Hr INT,
D_Password VARCHAR(50),
CONSTRAINT Pk_Driver PRIMARY KEY (D_Id)
);

INSERT INTO Driver VALUES (1,'Amal',100,123);
INSERT INTO Driver VALUES (2,'Nimal',100,123);
INSERT INTO Driver VALUES (3,'Kamal',100,123);





CREATE TABLE Customer(
C_Id  INT IDENTITY(1,1) NOT NULL,
C_Name VARCHAR(50),
C_Address VARCHAR(50),
C_Email VARCHAR(50),
C_Contact_No INT,
C_Password Varchar(50),
CONSTRAINT Pk_Customer PRIMARY KEY (C_Id),
);

INSERT INTO Customer VALUES (1,'Sithumini','Colombo','sithu@gmail.com',0711111111,123);
INSERT INTO Customer VALUES (2,'Ayesha','Gampaha','ayesha@gmail.com',0712222222,123);






CREATE TABLE Rent(
R_Id INT NOT NULL,
V_Type_Id int,
D_Id INT,
C_Id INT,
CONSTRAINT PK_Rent PRIMARY KEY (R_Id),
CONSTRAINT Fk_Rent FOREIGN KEY (V_Type_Id) REFERENCES VehicleType(V_Type_Id), FOREIGN KEY (D_Id) REFERENCES Driver(D_Id), FOREIGN KEY (C_Id) REFERENCES Customer(C_Id)
);
INSERT INTO Rent VALUES (400,121,1,1);
INSERT INTO Rent VALUES (401,121,1,1);
INSERT INTO Rent VALUES (402,121,1,1);



CREATE TABLE Package(
P_Id INT NOT NULL,
P_Name VARCHAR(50),
Max_Km INT,
Max_Hr INT,
Extra_Km_Rate INT,
Extra_Hr_Rate INT,
Cost INT,
Vehicle_Night_Park_Rate_Per_Night INT,
Driver_Overnight_Rate_Per_Night INT
CONSTRAINT Pk_Package PRIMARY KEY (P_Id)
);

INSERT INTO Package VALUES (200,'Airport drop',50,20,100,100,500,200,200);
INSERT INTO Package VALUES (201,'Airport pickup',50,20,100,100,500,200,200);
INSERT INTO Package VALUES (202,'100km per day',100,20,100,100,500,200,200);
INSERT INTO Package VALUES (203,'200km per day',200,20,100,100,500,200,200);


CREATE TABLE Hire(
Hire_Id INT NOT NULL,
D_Id INT,
C_Id INT,
V_Id INT,
V_Type_Id INT,
P_Id INT,
CONSTRAINT Pk_Hire PRIMARY KEY (Hire_Id),
CONSTRAINT Fk_D_Id FOREIGN KEY (D_Id) REFERENCES Driver(D_Id), 
CONSTRAINT FK_C_Id FOREIGN KEY (C_ID) REFERENCES Customer(C_Id), 
CONSTRAINT FK_V_Id FOREIGN KEY (V_Id,V_Type_Id) REFERENCES Vehicle(V_Id,V_Type_Id), 
CONSTRAINT FK_P_Id FOREIGN KEY (P_Id) REFERENCES Package (P_Id)
);

INSERT INTO Hire VALUES (221,1,1,1111,121,200);
INSERT INTO Hire VALUES (222,1,1,1111,121,200);
INSERT INTO Hire VALUES (223,1,1,1111,121,200);
INSERT INTO Hire VALUES (224,1,1,1111,121,200);




CREATE TABLE Job(
J_Id INT IDENTITY (1,1) NOT NULL,
C_Id INT,
C_Name VARCHAR(50),
Hire_Or_Rent Varchar(50),
Cost VARCHAR(50),
V_Type Varchar(50),
D_Name Varchar(50),
Duration Varchar(50),
CONSTRAINT Pk_Job PRIMARY KEY (J_Id),
CONSTRAINT Fk_Job FOREIGN KEY (C_Id) REFERENCES Customer(C_Id), 
);

INSERT INTO Job VALUES (1,'Sithumini','Hire',500,'Small car','Amal','2 days');