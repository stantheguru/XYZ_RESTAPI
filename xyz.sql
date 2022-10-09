-- phpMyAdmin SQL Dump
-- version 4.8.5
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1:3306
-- Generation Time: Oct 09, 2022 at 12:39 PM
-- Server version: 5.7.26
-- PHP Version: 7.2.18

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `xyz`
--

-- --------------------------------------------------------

--
-- Table structure for table `family_bank_payment`
--

DROP TABLE IF EXISTS `family_bank_payment`;
CREATE TABLE IF NOT EXISTS `family_bank_payment` (
  `PaymentID` int(11) NOT NULL,
  `StudentID` int(11) NOT NULL,
  `Amount` float NOT NULL,
  `PaymentDate` datetime NOT NULL,
  `PaymentMethod` varchar(200) NOT NULL,
  `BankChannel` varchar(200) NOT NULL,
  `NotificationChannel` varchar(200) NOT NULL,
  PRIMARY KEY (`PaymentID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `notification`
--

DROP TABLE IF EXISTS `notification`;
CREATE TABLE IF NOT EXISTS `notification` (
  `NotificationID` int(11) NOT NULL AUTO_INCREMENT,
  `StudentID` int(11) NOT NULL,
  `PaymentID` int(11) NOT NULL,
  `NotificationDate` datetime NOT NULL,
  `Status` varchar(200) NOT NULL,
  PRIMARY KEY (`NotificationID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

DROP TABLE IF EXISTS `student`;
CREATE TABLE IF NOT EXISTS `student` (
  `StudentID` int(11) NOT NULL,
  `StudentName` varchar(200) NOT NULL,
  `StudentEmail` varchar(200) NOT NULL,
  `StudentMobile` varchar(200) NOT NULL,
  `Department` varchar(200) NOT NULL,
  `Course` varchar(200) NOT NULL,
  PRIMARY KEY (`StudentID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;

-- --------------------------------------------------------

--
-- Table structure for table `xyz_payment`
--

DROP TABLE IF EXISTS `xyz_payment`;
CREATE TABLE IF NOT EXISTS `xyz_payment` (
  `PaymentID` int(11) NOT NULL,
  `StudentID` int(11) NOT NULL,
  `Amount` float NOT NULL,
  `PaymentDate` datetime NOT NULL,
  `PaymentMethod` varchar(200) NOT NULL,
  `BankChannel` varchar(200) NOT NULL,
  `NotificationChannel` varchar(200) NOT NULL,
  PRIMARY KEY (`PaymentID`)
) ENGINE=MyISAM DEFAULT CHARSET=latin1;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
