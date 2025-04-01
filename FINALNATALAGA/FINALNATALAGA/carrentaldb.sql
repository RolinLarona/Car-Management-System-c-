-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Mar 31, 2025 at 03:07 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `carrentaldb`
--

-- --------------------------------------------------------

--
-- Table structure for table `customers`
--

CREATE TABLE `customers` (
  `CustomerID` int(11) NOT NULL,
  `Name` varchar(50) NOT NULL,
  `Email` varchar(100) NOT NULL,
  `Phone` varchar(15) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

-- --------------------------------------------------------

--
-- Table structure for table `rentals`
--

CREATE TABLE `rentals` (
  `RentalID` int(11) NOT NULL,
  `CustomerID` int(11) DEFAULT NULL,
  `VehicleID` int(11) DEFAULT NULL,
  `RentalDate` date NOT NULL DEFAULT current_timestamp(),
  `ReturnDate` datetime DEFAULT NULL,
  `ActualReturnDate` date DEFAULT NULL,
  `TotalFee` decimal(10,2) DEFAULT NULL,
  `RentDate` datetime DEFAULT NULL,
  `CustomerName` varchar(100) DEFAULT NULL,
  `CustomerEmail` varchar(100) DEFAULT NULL,
  `TotalCost` decimal(10,2) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `rentals`
--

INSERT INTO `rentals` (`RentalID`, `CustomerID`, `VehicleID`, `RentalDate`, `ReturnDate`, `ActualReturnDate`, `TotalFee`, `RentDate`, `CustomerName`, `CustomerEmail`, `TotalCost`) VALUES
(28, NULL, 1, '2025-03-31', '2025-03-31 12:36:15', NULL, NULL, '2025-03-31 12:21:34', 'Roli', 'abanorolin@gmail.com', 3000.00),
(29, NULL, 3, '2025-03-31', '2025-03-31 12:35:12', NULL, NULL, '2025-03-31 12:27:54', 'ROLIN', 'abanorolin@gmail.com', 2000.00),
(30, NULL, 1, '2025-03-31', '2025-03-31 12:42:57', NULL, NULL, '2025-03-31 12:39:49', 'andyssa', 'abano.rolin.ge2019@gmail.com', 3000.00),
(31, NULL, 1, '2025-03-31', '2025-03-31 12:52:12', NULL, NULL, '2025-03-31 12:51:31', 'ROlin', 'abanorolin@gmail.com', 3000.00),
(32, NULL, 1, '2025-03-31', '2025-03-31 13:14:29', NULL, NULL, '2025-03-31 13:09:41', 'Rolin', 'abanorolin@gmail.com', 3000.00),
(33, NULL, 1, '2025-03-31', '2025-03-31 13:23:28', NULL, NULL, '2025-03-31 13:15:25', 'Rolin', 'abanorolin@gmail.com', 1500.00),
(34, NULL, 1, '2025-03-31', '2025-03-31 13:45:27', NULL, NULL, '2025-03-31 13:24:03', 'Rolin', 'abanorolin@gmail.com', 3000.00),
(35, NULL, 2, '2025-03-31', '2025-03-31 13:45:48', NULL, NULL, '2025-03-31 13:44:10', 'Rolin', 'abanorolin@gmail.com', 2500.00),
(36, NULL, 1, '2025-03-31', '2025-03-31 13:56:10', NULL, NULL, '2025-03-31 13:50:47', 'qwe', '12', 1500.00),
(37, NULL, 1, '2025-03-31', '2025-03-31 13:57:26', NULL, NULL, '2025-03-31 13:56:56', 'Rolin', 'abanorolin@gmail.com', 3000.00),
(38, NULL, 1, '2025-03-31', '2025-04-22 14:07:17', '2025-04-25', NULL, '2025-03-31 14:07:17', 'Rolin', 'abanorolin@gmail.com', 36000.00),
(39, NULL, 1, '2025-03-31', '2025-04-02 14:11:07', '2025-04-03', NULL, '2025-03-31 14:11:07', 'jarehm', 'abanorolin@gmail.com', 3000.00),
(40, NULL, 1, '2025-03-31', '2025-04-01 14:12:33', '2025-04-03', NULL, '2025-03-31 14:12:33', 'qweqrtrtr', 'abanorolin@gmail.com', 3000.00),
(41, NULL, 1, '2025-03-31', '2025-04-01 14:57:59', NULL, NULL, '2025-03-31 14:57:59', 'gab', 'gab@gmail.com', 1500.00),
(42, NULL, 2, '2025-03-31', '2025-04-02 15:07:44', '2025-04-04', NULL, '2025-03-31 15:07:44', 'jonas', 'abanorolin@gmail.com', 7500.00);

-- --------------------------------------------------------

--
-- Table structure for table `reservations`
--

CREATE TABLE `reservations` (
  `ReservationID` int(11) NOT NULL,
  `VehicleID` int(11) NOT NULL,
  `ReservationDate` datetime NOT NULL,
  `CustomerName` varchar(100) NOT NULL,
  `PickupDate` date DEFAULT NULL,
  `ReturnDate` date DEFAULT NULL,
  `TotalCost` decimal(10,2) DEFAULT NULL,
  `CustomerEmail` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `reservations`
--

INSERT INTO `reservations` (`ReservationID`, `VehicleID`, `ReservationDate`, `CustomerName`, `PickupDate`, `ReturnDate`, `TotalCost`, `CustomerEmail`) VALUES
(6, 1, '2025-03-27 20:14:24', 'Rolin', '2025-05-11', '2025-10-11', 229500.00, ''),
(7, 2, '2025-03-27 22:32:39', 'Rolin', '2025-05-11', '2025-05-15', 10000.00, ''),
(8, 5, '2025-03-31 12:33:46', 'Mhaxxine', '2025-05-11', '2025-05-20', 6300.00, 'andyssa26papasin@gmail.com'),
(9, 2, '2025-03-31 15:10:21', 'jonas', '2020-05-11', '2020-05-21', 25000.00, 'abanorolin@yahoo.com');

-- --------------------------------------------------------

--
-- Table structure for table `users`
--

CREATE TABLE `users` (
  `UserID` int(11) NOT NULL,
  `Username` varchar(50) NOT NULL,
  `Password` varchar(100) NOT NULL,
  `Role` varchar(20) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `users`
--

INSERT INTO `users` (`UserID`, `Username`, `Password`, `Role`) VALUES
(1, 'admin', 'admin', 'Admin');

-- --------------------------------------------------------

--
-- Table structure for table `vehicles`
--

CREATE TABLE `vehicles` (
  `VehicleID` int(11) NOT NULL,
  `Type` varchar(20) NOT NULL,
  `Model` varchar(50) NOT NULL,
  `PricePerDay` decimal(10,2) NOT NULL,
  `Status` varchar(20) DEFAULT 'Available',
  `Available` tinyint(1) DEFAULT 1
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `vehicles`
--

INSERT INTO `vehicles` (`VehicleID`, `Type`, `Model`, `PricePerDay`, `Status`, `Available`) VALUES
(1, 'Car', 'Toyota Vios', 1500.00, 'Available', 0),
(2, 'Van', 'Hyundai Starex', 2500.00, 'Available', 0),
(3, 'Van', 'Nissan Escapade', 1000.00, 'Available', 1),
(5, 'Car', 'Toyota Vios', 700.00, 'Available', 1),
(6, 'Car', 'Honda Civic', 700.00, 'Available', 1),
(7, 'Car', 'Mitsubishi Mirage', 700.00, 'Available', 1),
(8, 'Car', 'Toyota Wigo', 700.00, 'Available', 1);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `customers`
--
ALTER TABLE `customers`
  ADD PRIMARY KEY (`CustomerID`),
  ADD UNIQUE KEY `Email` (`Email`);

--
-- Indexes for table `rentals`
--
ALTER TABLE `rentals`
  ADD PRIMARY KEY (`RentalID`),
  ADD KEY `CustomerID` (`CustomerID`),
  ADD KEY `VehicleID` (`VehicleID`);

--
-- Indexes for table `reservations`
--
ALTER TABLE `reservations`
  ADD PRIMARY KEY (`ReservationID`),
  ADD KEY `VehicleID` (`VehicleID`);

--
-- Indexes for table `users`
--
ALTER TABLE `users`
  ADD PRIMARY KEY (`UserID`),
  ADD UNIQUE KEY `Username` (`Username`);

--
-- Indexes for table `vehicles`
--
ALTER TABLE `vehicles`
  ADD PRIMARY KEY (`VehicleID`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `customers`
--
ALTER TABLE `customers`
  MODIFY `CustomerID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `rentals`
--
ALTER TABLE `rentals`
  MODIFY `RentalID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=43;

--
-- AUTO_INCREMENT for table `reservations`
--
ALTER TABLE `reservations`
  MODIFY `ReservationID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=10;

--
-- AUTO_INCREMENT for table `users`
--
ALTER TABLE `users`
  MODIFY `UserID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `vehicles`
--
ALTER TABLE `vehicles`
  MODIFY `VehicleID` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=11;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `rentals`
--
ALTER TABLE `rentals`
  ADD CONSTRAINT `rentals_ibfk_1` FOREIGN KEY (`CustomerID`) REFERENCES `customers` (`CustomerID`),
  ADD CONSTRAINT `rentals_ibfk_2` FOREIGN KEY (`VehicleID`) REFERENCES `vehicles` (`VehicleID`);

--
-- Constraints for table `reservations`
--
ALTER TABLE `reservations`
  ADD CONSTRAINT `reservations_ibfk_1` FOREIGN KEY (`VehicleID`) REFERENCES `vehicles` (`VehicleID`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
