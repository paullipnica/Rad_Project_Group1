-- Drop the Database if it exists
USE MASTER;
DROP DATABASE IF EXISTS BowValleyShowroom;

-- Create the Database
CREATE DATABASE BowValleyShowroom;
USE BowValleyShowroom;

-- 1. Users Table (Updated)
CREATE TABLE Users (
    user_id INT IDENTITY(1,1) PRIMARY KEY,
    firstname NVARCHAR(50) NOT NULL,
    lastname NVARCHAR(50) NOT NULL,
    username NVARCHAR(50) NOT NULL UNIQUE,
    password NVARCHAR(255) NOT NULL,
    role NVARCHAR(20) NOT NULL CHECK (role IN ('Customer', 'Salesman', 'Admin')),
    email NVARCHAR(320) NOT NULL UNIQUE,
    phone NVARCHAR(20) NOT NULL UNIQUE,
);


-- 2. Vehicles Table (Updated)
CREATE TABLE Vehicles (
    vin_number NVARCHAR(17) PRIMARY KEY,  -- VIN number with 17 characters
    make NVARCHAR(50) NOT NULL,
    model NVARCHAR(50) NOT NULL,
    year INT NOT NULL,
    mileage DECIMAL(10, 2),  -- Mileage field added
    body_style NVARCHAR(50),  -- Body style field added
    price DECIMAL(10, 2) NOT NULL,
    features NVARCHAR(MAX) NOT NULL,
    available BIT NOT NULL DEFAULT 1,
    stock_quantity INT DEFAULT 0
);



-- 3. Test_Drives Table (Updated)
CREATE TABLE Test_Drives (
    test_drive_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_username NVARCHAR(50) NOT NULL,  -- Changed to customer_username
    vin_number NVARCHAR(17) NOT NULL,  -- Changed to vehicle_vin_number
    schedule_date DATE NOT NULL,
    schedule_time TIME NOT NULL,
    status NVARCHAR(20) NOT NULL CHECK (status IN ('Pending', 'Completed', 'Cancelled')),
    drive_type NVARCHAR(20) CHECK (drive_type IN ('In-person', 'Virtual')),
    FOREIGN KEY (customer_username) REFERENCES Users(username),
    FOREIGN KEY (vin_number) REFERENCES Vehicles(vin_number)
);


-- 4. Transactions Table (Updated)
CREATE TABLE Transactions (
    transaction_id INT IDENTITY(1,1) PRIMARY KEY,
    customer_username NVARCHAR(50) NOT NULL,  -- Changed to customer_username
    vin_number NVARCHAR(17) NOT NULL,  -- Changed to vehicle_vin_number
    payment_method NVARCHAR(20) NOT NULL CHECK (payment_method IN ('Full Payment', 'Installment')),
    installment_plan INT DEFAULT NULL,
    interest_rate DECIMAL(5, 2) DEFAULT NULL,
    total_cost DECIMAL(10, 2) NOT NULL,
    transaction_date DATETIME DEFAULT GETDATE(),
    transaction_status NVARCHAR(20) DEFAULT 'Pending' CHECK (transaction_status IN ('Pending', 'Completed', 'Cancelled')),
    FOREIGN KEY (customer_username) REFERENCES Users(username),
    FOREIGN KEY (vin_number) REFERENCES Vehicles(vin_number)
);


-- 5. Test_Drive_History Table (Updated)
CREATE TABLE Test_Drive_History (
    history_id INT IDENTITY(1,1) PRIMARY KEY,
    vin_number NVARCHAR(17) NOT NULL,  -- Changed to vehicle_vin_number
    customer_username NVARCHAR(50) NOT NULL,  -- Changed to customer_username
    drive_date DATE NOT NULL,
    feedback NVARCHAR(MAX) NULL,
    FOREIGN KEY (vin_number) REFERENCES Vehicles(vin_number),
    FOREIGN KEY (customer_username) REFERENCES Users(username)
);


-- 1. Users Table (Modified for usernames)
INSERT INTO Users (firstname, lastname, username, password, role, email, phone)
VALUES
('Michael', 'Brown', 'mike_brown', 'hashed_password5', 'Customer', 'michael.brown@example.com', '5551234567'),
('Emily', 'Davis', 'emily_davis', 'hashed_password6', 'Customer', 'emily.davis@example.com', '5552345678'),
('Jessica', 'Wilson', 'jessica_wilson', 'hashed_password7', 'Customer', 'jessica.wilson@example.com', '5553456789'),
('Daniel', 'Taylor', 'daniel_taylor', 'hashed_password8', 'Customer', 'daniel.taylor@example.com', '5554567890'),
('Sophia', 'Martinez', 'sophia_martinez', 'hashed_password9', 'Customer', 'sophia.martinez@example.com', '5555678901'),
('James', 'Anderson', 'james_anderson', 'hashed_password10', 'Salesman', 'james.anderson@example.com', '5556789012'),
('Olivia', 'Thomas', 'olivia_thomas', 'hashed_password11', 'Salesman', 'olivia.thomas@example.com', '5557890123'),
('Lucas', 'Moore', 'lucas_moore', 'hashed_password12', 'Salesman', 'lucas.moore@example.com', '5558901234'),
('Ava', 'Jackson', 'ava_jackson', 'hashed_password13', 'Salesman', 'ava.jackson@example.com', '5559012345'),
('Ethan', 'Harris', 'ethan_harris', 'hashed_password14', 'Admin', 'ethan.harris@example.com', '5551239876'),
('Emma', 'Clark', 'emma_clark', 'hashed_password15', 'Admin', 'emma.clark@example.com', '5552348765'),
('David', 'Lee', 'david_lee', 'hashed_password16', 'Admin', 'david.lee@example.com', '5553457654'),
('John', 'Doe', 'salesman1', 'hashed_password3', 'Salesman', 'salesman1@example.com', '0987654321'),
('Jane', 'Doe', 'salesman2', 'hashed_password4', 'Salesman', 'salesman2@example.com', '0987654322'),
('John', 'Doe', 'john_doe', 'hashed_password1', 'Customer', 'john@example.com', '1234567890'),
('Jane', 'Doe', 'jane_doe', 'hashed_password2', 'Customer', 'jane@example.com', '1234567891'),
('Mark', 'Smith', 'customer1', 'hashed_password6', 'Customer', 'customer1@example.com', '2222222222'),
('Lisa', 'Brown', 'customer2', 'hashed_password7', 'Customer', 'customer2@example.com', '3333333333'),
('Tom', 'White', 'customer3', 'hashed_password8', 'Customer', 'customer3@example.com', '4444444444'),
('Jensen', 'Castro', 'admincastro', 'password', 'Salesman', 'castro@example.com', '4114444444'),
('Paul', 'Lipnica', 'adminlipnica', 'password', 'Salesman', 'gebrekidan@example.com', '4441231211'),
('Helen', 'Gebrekidan', 'adminGebrekidan', 'password', 'Salesman', 'lipnica@example.com', '4441231212');


-- 2. Vehicles Table (Modified for VIN numbers)
INSERT INTO Vehicles (vin_number, make, model, year, mileage, body_style, price, features, available, stock_quantity)
VALUES
('1G1ZT58N694136753', 'Chevrolet', 'Impala', 2023, 15000, 'Sedan', 22000.00, 'Bluetooth, Cruise Control, Airbags', 1, 12),
('2HGEJ6684WH107132', 'Toyota', 'Camry', 2022, 12000, 'Sedan', 24000.00, 'Leather Seats, Sunroof, Navigation', 1, 7),
('1FTEX1E81JKF10783', 'Ford', 'F-150', 2021, 30000, 'Truck', 35000.00, '4WD, Bluetooth, Rear Camera', 1, 6),
('1HGCM66557A123498', 'Honda', 'Accord', 2023, 18000, 'Sedan', 26000.00, 'Airbags, Rear Camera, Sunroof', 1, 8),
('3VWDP7AJ8CM036215', 'Volkswagen', 'Jetta', 2022, 17000, 'Sedan', 21000.00, 'Cruise Control, Bluetooth', 1, 5),
('5TDZK3DCXKS876543', 'Toyota', 'Highlander', 2023, 10000, 'SUV', 38000.00, '4WD, Navigation, Heated Seats', 1, 9),
('1J4GW58S9VC550004', 'Jeep', 'Grand Cherokee', 2022, 25000, 'SUV', 36000.00, 'Off-road Package, Navigation', 1, 4),
('4T1BK46K97U568912', 'Toyota', 'Avalon', 2023, 13000, 'Sedan', 32000.00, 'Sunroof, Heated Seats, Navigation', 1, 3),
('1GNFK16K7RJ123456', 'Chevrolet', 'Suburban', 2021, 40000, 'SUV', 44000.00, 'Leather Seats, Navigation, DVD Player', 1, 2),
('5J6RE4H37AL123457', 'Honda', 'CR-V', 2023, 15000, 'SUV', 30000.00, '4WD, Bluetooth, Heated Seats', 1, 11),
('1HGBH41JXMN109186', 'Toyota', 'Corolla', 2023, 25000.00, 'Sedan', 25000.00, 'Airbags, Bluetooth, Cruise Control', 1, 10),
('1HGCM82633A123456', 'Honda', 'Civic', 2022, 22000.00, 'Sedan', 22000.00, 'Airbags, Sunroof, Apple CarPlay', 1, 5),
('1FAFP404X1F123456', 'Ford', 'Focus', 2021, 20000.00, 'Hatchback', 20000.00, 'Bluetooth, Rear Camera, ABS', 1, 3),
('1G1ZD5ST0HF123456', 'Chevrolet', 'Malibu', 2023, 24000.00, 'Sedan', 24000.00, 'Cruise Control, Apple CarPlay', 1, 7),
('1N4AL3AP9EC123456', 'Nissan', 'Altima', 2022, 23000.00, 'Sedan', 23000.00, 'Airbags, Android Auto', 1, 8),
('5NPD84LF8JH123456', 'Hyundai', 'Elantra', 2023, 21000.00, 'Sedan', 21000.00, 'Airbags, Rear Camera', 1, 6),
('WBA3A9C5XFK123456', 'BMW', '3 Series', 2021, 35000.00, 'Sedan', 35000.00, 'Leather Seats, Navigation, Sunroof', 1, 2),
('WAUZ2AF22HN123456', 'Audi', 'A4', 2022, 40000.00, 'Sedan', 40000.00, 'Navigation, Sunroof, Rear Camera', 1, 4),
('KNDJP3A56L7045678', 'Kia', 'Soul', 2023, 19000.00, 'SUV', 19000.00, 'Bluetooth, Airbags', 1, 9),
('5YJ3E1EA7KF123456', 'Tesla', 'Model 3', 2023, 50000.00, 'Sedan', 50000.00, 'Autopilot, Electric, Navigation', 1, 3);


-- 3. Test_Drives Table (Modified for usernames and VIN numbers)
INSERT INTO Test_Drives (customer_username, vin_number, schedule_date, schedule_time, status, drive_type)
VALUES
('mike_brown', '1G1ZT58N694136753', '2024-12-01', '09:00:00', 'Pending', 'In-person'),
('emily_davis', '2HGEJ6684WH107132', '2024-12-01', '10:30:00', 'Completed', 'Virtual'),
('jessica_wilson', '1FTEX1E81JKF10783', '2024-12-02', '11:00:00', 'Pending', 'In-person'),
('daniel_taylor', '1HGCM66557A123498', '2024-12-02', '14:00:00', 'Cancelled', 'Virtual'),
('sophia_martinez', '3VWDP7AJ8CM036215', '2024-12-03', '13:00:00', 'Completed', 'In-person'),
('john_doe', '5TDZK3DCXKS876543', '2024-12-04', '15:00:00', 'Pending', 'In-person'),
('jane_doe', '1J4GW58S9VC550004', '2024-12-05', '12:30:00', 'Completed', 'Virtual'),
('customer1', '4T1BK46K97U568912', '2024-12-06', '14:30:00', 'Pending', 'In-person'),
('customer2', '1GNFK16K7RJ123456', '2024-12-07', '16:00:00', 'Cancelled', 'Virtual'),
('customer3', '5J6RE4H37AL123457', '2024-12-08', '10:00:00', 'Pending', 'In-person'),
('john_doe', '1HGBH41JXMN109186', '2024-12-01', '10:00:00', 'Pending', 'In-person'),
('jane_doe', '1HGCM82633A123456', '2024-12-02', '11:00:00', 'Pending', 'In-person'),
('john_doe', '1FAFP404X1F123456', '2024-12-03', '12:00:00', 'Completed', 'In-person'),
('customer1', '1G1ZD5ST0HF123456', '2024-12-04', '13:00:00', 'Cancelled', 'Virtual'),
('customer2', '1N4AL3AP9EC123456', '2024-12-05', '14:00:00', 'Pending', 'In-person'),
('customer3', '5NPD84LF8JH123456', '2024-12-06', '15:00:00', 'Pending', 'In-person'),
('salesman1', 'WBA3A9C5XFK123456', '2024-12-07', '16:00:00', 'Completed', 'Virtual'),
('salesman2', 'WAUZ2AF22HN123456', '2024-12-08', '17:00:00', 'Pending', 'In-person'),
('customer1', 'KNDJP3A56L7045678', '2024-12-09', '18:00:00', 'Cancelled', 'Virtual'),
('customer2', '5YJ3E1EA7KF123456', '2024-12-10', '19:00:00', 'Pending', 'In-person');

-- 4. Transactions Table (Modified for usernames and VIN numbers)
INSERT INTO Transactions (customer_username, vin_number, payment_method, installment_plan, interest_rate, total_cost)
VALUES
('mike_brown', '1G1ZT58N694136753', 'Installment', 12, 3.2, 22000.00),
('emily_davis', '2HGEJ6684WH107132', 'Full Payment', NULL, NULL, 24000.00),
('jessica_wilson', '1FTEX1E81JKF10783', 'Installment', 24, 4.5, 35000.00),
('daniel_taylor', '1HGCM66557A123498', 'Installment', 36, 5.0, 26000.00),
('sophia_martinez', '3VWDP7AJ8CM036215', 'Full Payment', NULL, NULL, 21000.00),
('john_doe', '5TDZK3DCXKS876543', 'Installment', 48, 3.8, 38000.00),
('jane_doe', '1J4GW58S9VC550004', 'Full Payment', NULL, NULL, 36000.00),
('customer1', '4T1BK46K97U568912', 'Installment', 24, 4.1, 32000.00),
('customer2', '1GNFK16K7RJ123456', 'Full Payment', NULL, NULL, 44000.00),
('customer3', '5J6RE4H37AL123457', 'Installment', 12, 3.6, 30000.00),
('john_doe', '1HGBH41JXMN109186', 'Full Payment', NULL, NULL, 25000.00),
('jane_doe', '1HGCM82633A123456', 'Installment', 12, 3.5, 24000.00),
('john_doe', '1FAFP404X1F123456', 'Full Payment', NULL, NULL, 20000.00),
('customer1', '1G1ZD5ST0HF123456', 'Installment', 24, 4.0, 23000.00),
('customer2', '1N4AL3AP9EC123456', 'Full Payment', NULL, NULL, 22000.00),
('customer3', '5NPD84LF8JH123456', 'Installment', 36, 5.5, 21000.00),
('salesman1', 'WBA3A9C5XFK123456', 'Installment', 18, 3.0, 35000.00),
('salesman2', 'WAUZ2AF22HN123456', 'Full Payment', NULL, NULL, 40000.00),
('customer1', 'KNDJP3A56L7045678', 'Installment', 12, 4.5, 19000.00),
('customer2', '5YJ3E1EA7KF123456', 'Full Payment', NULL, NULL, 50000.00);

-- 5. Test_Drive_History Table (Modified for usernames and VIN numbers)
INSERT INTO Test_Drive_History (vin_number, customer_username, drive_date, feedback)
VALUES
('1G1ZT58N694136753', 'mike_brown', '2024-12-01', 'Good car, considering buying.'),
('2HGEJ6684WH107132', 'emily_davis', '2024-12-01', 'Smooth drive, great features.'),
('1FTEX1E81JKF10783', 'jessica_wilson', '2024-12-02', 'Loved the truck, perfect for work.'),
('1HGCM66557A123498', 'daniel_taylor', '2024-12-02', 'Cancelled due to schedule conflict.'),
('3VWDP7AJ8CM036215', 'sophia_martinez', '2024-12-03', 'Compact and efficient, ideal for city.'),
('5TDZK3DCXKS876543', 'john_doe', '2024-12-04', 'Impressive SUV, family-friendly.'),
('1J4GW58S9VC550004', 'jane_doe', '2024-12-05', 'Great off-road features, loved it.'),
('4T1BK46K97U568912', 'customer1', '2024-12-06', 'Comfortable and spacious interior.'),
('1GNFK16K7RJ123456', 'customer2', '2024-12-07', 'Large vehicle, not what I need.'),
('5J6RE4H37AL123457', 'customer3', '2024-12-08', 'Perfect fit for my needs.'),
('1HGBH41JXMN109186', 'john_doe', '2024-12-01', 'Great experience, would buy.'),
('1HGCM82633A123456', 'jane_doe', '2024-12-02', 'Loved the car, considering purchasing it.'),
('1FAFP404X1F123456', 'john_doe', '2024-12-03', 'Decided not to purchase.'),
('1G1ZD5ST0HF123456', 'customer1', '2024-12-04', 'Test drive cancelled.'),
('1N4AL3AP9EC123456', 'customer2', '2024-12-05', 'Loved it, but it’s too expensive.'),
('5NPD84LF8JH123456', 'customer3', '2024-12-06', 'Great car, might buy later.'),
('WBA3A9C5XFK123456', 'salesman1', '2024-12-07', 'Test drive was good, very informative.'),
('WAUZ2AF22HN123456', 'salesman2', '2024-12-08', 'Car was great.'),
('KNDJP3A56L7045678', 'customer1', '2024-12-09', 'Test drive cancelled.'),
('5YJ3E1EA7KF123456', 'customer2', '2024-12-10', 'Amazing drive, I am in!');


-- Normalization issues so run the codes below 
ALTER TABLE Test_Drives DROP CONSTRAINT FK__Test_Driv__vin_n__4316F928;
ALTER TABLE Transactions DROP CONSTRAINT FK__Transacti__vin_n__4CA06362;
ALTER TABLE Test_Drive_History DROP CONSTRAINT FK__Test_Driv__vin_n__4F7CD00D; -- Replace with the actual name

ALTER TABLE Test_Drives
ADD CONSTRAINT FK_Test_Drives_Vehicles
FOREIGN KEY (vin_number)
REFERENCES Vehicles(vin_number)
ON DELETE CASCADE;

ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Vehicles
FOREIGN KEY (vin_number)
REFERENCES Vehicles(vin_number)
ON DELETE CASCADE;

ALTER TABLE Test_Drive_History
ADD CONSTRAINT FK_Test_Drive_History_Vehicles
FOREIGN KEY (vin_number)
REFERENCES Vehicles(vin_number)
ON DELETE CASCADE;


-- Normalization issues so run the codes below 
ALTER TABLE Test_Drives DROP CONSTRAINT FK__Test_Driv__custo__4222D4EF;
ALTER TABLE Transactions DROP CONSTRAINT FK__Transacti__custo__4BAC3F29;
ALTER TABLE Test_Drive_History DROP CONSTRAINT FK__Test_Driv__custo__5070F446;

ALTER TABLE Test_Drives
ADD CONSTRAINT FK_Test_Drives_Users
FOREIGN KEY (customer_username)
REFERENCES Users(username)
ON DELETE CASCADE;

ALTER TABLE Transactions
ADD CONSTRAINT FK_Transactions_Users
FOREIGN KEY (customer_username)
REFERENCES Users(username)
ON DELETE CASCADE;

ALTER TABLE Test_Drive_History
ADD CONSTRAINT FK_Test_Drive_History_Users
FOREIGN KEY (customer_username)
REFERENCES Users(username)
ON DELETE CASCADE;

--To test our CRUD methods
Select * FROM Vehicles
Select * FROM Users
Select* From Test_Drives
Select * From Transactions


