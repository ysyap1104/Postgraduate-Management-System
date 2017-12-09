-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Oct 04, 2017 at 09:24 AM
-- Server version: 10.1.25-MariaDB
-- PHP Version: 7.1.7

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `managementsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `academic_staff`
--

CREATE TABLE `academic_staff` (
  `Staff_ID` varchar(10) NOT NULL,
  `Staff_Password` varchar(100) NOT NULL,
  `Staff_Lname` varchar(100) NOT NULL,
  `Staff_Fname` varchar(100) NOT NULL,
  `Staff_IC` varchar(14) NOT NULL,
  `Staff_Gender` varchar(100) NOT NULL,
  `Staff_Address` varchar(100) NOT NULL,
  `Staff_Contact_No` varchar(100) NOT NULL,
  `Staff_Room` varchar(100) NOT NULL,
  `Staff_ConsultationDay` varchar(20) NOT NULL,
  `Staff_ConsultationTime` varchar(20) NOT NULL,
  `Staff_Email` varchar(100) NOT NULL,
  `Staff_Salary` double NOT NULL,
  `Date_Add` date NOT NULL,
  `Admin_ID` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `academic_staff`
--

INSERT INTO `academic_staff` (`Staff_ID`, `Staff_Password`, `Staff_Lname`, `Staff_Fname`, `Staff_IC`, `Staff_Gender`, `Staff_Address`, `Staff_Contact_No`, `Staff_Room`, `Staff_ConsultationDay`, `Staff_ConsultationTime`, `Staff_Email`, `Staff_Salary`, `Date_Add`, `Admin_ID`) VALUES
('L0', '123', 'Ng', 'Wee Fon', '971104818884', 'Male', 'No, 34 Jalan PU1/3', '0192828444', 'R001', 'Monday', '9 A.M. - 11 A.M.', 'wee@gmail.com', 5000, '0000-00-00', 'A1'),
('L1', '123', 'John', 'cena', '971004149999', 'Male', 'No34, Jalan Pu1/3', '0182828444', 'R002', 'Monday', '9 A.M. - 11 A.M.', 'cena@gmail.com', 5000, '0000-00-00', 'A1'),
('L2', '123', 'Jeff', 'Fon', '987456321456', 'Femalee', 'No.44, Jalan 3/8', '1236547896', 'R003', 'Tuesday', '9 A.M. - 11 A.M.', 'jeff@gmail.com', 5000, '0000-00-00', 'A1');

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `Admin_ID` varchar(10) NOT NULL,
  `Admin_Password` varchar(100) NOT NULL,
  `Admin_Department` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`Admin_ID`, `Admin_Password`, `Admin_Department`) VALUES
('A1', '123', 'Admin Department');

-- --------------------------------------------------------

--
-- Table structure for table `announcement`
--

CREATE TABLE `announcement` (
  `Announcement_ID` varchar(10) NOT NULL,
  `Admin_ID` varchar(10) NOT NULL,
  `Announcement_Details` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `announcement`
--

INSERT INTO `announcement` (`Announcement_ID`, `Admin_ID`, `Announcement_Details`) VALUES
('A1', 'A1', 'Dear MMU students, this Monday is a public holiday.'),
('A2', 'A1', 'Dear MMU students, this Tuesday is a public holiday.'),
('A3', 'A1', 'Testing Announcement');

-- --------------------------------------------------------

--
-- Table structure for table `class`
--

CREATE TABLE `class` (
  `Class_ID` varchar(10) NOT NULL,
  `Subject_ID` varchar(10) NOT NULL,
  `Day` varchar(100) NOT NULL,
  `Time` varchar(100) NOT NULL,
  `Venue` varchar(100) NOT NULL,
  `Class_Size` int(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `class`
--

INSERT INTO `class` (`Class_ID`, `Subject_ID`, `Day`, `Time`, `Venue`, `Class_Size`) VALUES
('TT01', 'BBB1101', 'Monday', '11 am - 13 pm', 'QR1001', 50),
('TT01', 'CCA1102', 'Tuesday', '09 am - 11 am', 'QR2003', 50),
('TT01', 'TCP1101', 'Monday', '09 am - 11 am', 'QR1001', 50),
('TT01', 'TCP2201', 'Thursday', '09 am - 11 am', 'QR2003', 50),
('TT01', 'TSE1101', 'Friday', '09 am - 11 am', 'QR3004', 30),
('TT01', 'TTT1101', 'Monday', '14 pm - 16 pm', 'QR1001', 50),
('TT02', 'BBB1101', 'Tuesday', '11 am - 13 pm', 'QR1001', 50),
('TT02', 'TCP1101', 'Tuesday', '09 am - 11 am', 'QR1001', 50),
('TT02', 'TCP2201', 'Thursday', '11 am - 13 pm', 'QR2003', 50),
('TT03', 'TCP1101', 'Wednesday', '09 am - 11 am', 'QR1001', 50);

-- --------------------------------------------------------

--
-- Table structure for table `colloquium`
--

CREATE TABLE `colloquium` (
  `Colloquium_ID` varchar(10) NOT NULL,
  `Colloquium_Venue` varchar(10) NOT NULL,
  `Colloquium_Date` varchar(100) NOT NULL,
  `Colloquium_Time` varchar(100) NOT NULL,
  `Project_ID` varchar(10) NOT NULL,
  `Student_ID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `colloquium`
--

INSERT INTO `colloquium` (`Colloquium_ID`, `Colloquium_Venue`, `Colloquium_Date`, `Colloquium_Time`, `Project_ID`, `Student_ID`) VALUES
('C0', 'Grand Hall', '3/10/2017', '09 am - 11 am', 'P0', 'S1'),
('C1', 'Exam Hall', '3/10/2017', '09 am - 11 am', 'P0', NULL),
('C2', 'Exam Hall', '21/10/2017', '14 pm - 16 pm', 'P1', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `coursework`
--

CREATE TABLE `coursework` (
  `Student_ID` varchar(10) NOT NULL,
  `Course_Major` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `coursework`
--

INSERT INTO `coursework` (`Student_ID`, `Course_Major`) VALUES
('S0', 'Database'),
('S2', 'Major in Software Engin');

-- --------------------------------------------------------

--
-- Table structure for table `enrollment`
--

CREATE TABLE `enrollment` (
  `Student_ID` varchar(10) NOT NULL,
  `Subject_ID` varchar(10) NOT NULL,
  `Class_ID` varchar(10) NOT NULL,
  `Date` date NOT NULL,
  `Enroll_Time` time NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `enrollment`
--

INSERT INTO `enrollment` (`Student_ID`, `Subject_ID`, `Class_ID`, `Date`, `Enroll_Time`) VALUES
('S0', 'TCP1101', 'TT01', '2017-10-04', '11:24:47'),
('S0', 'TCP2201', 'TT02', '2017-10-04', '11:24:48'),
('S0', 'TSE1101', 'TT01', '2017-10-04', '11:24:48'),
('S2', 'CCA1102', 'TT01', '2017-10-04', '12:37:21'),
('S3', 'TTT1101', 'TT01', '2017-10-04', '13:39:33');

-- --------------------------------------------------------

--
-- Table structure for table `programme`
--

CREATE TABLE `programme` (
  `Programme_ID` varchar(10) NOT NULL,
  `Programme_Name` varchar(100) NOT NULL,
  `Programme_Type` varchar(100) NOT NULL,
  `Programme_Fee` double NOT NULL,
  `Admin_ID` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `programme`
--

INSERT INTO `programme` (`Programme_ID`, `Programme_Name`, `Programme_Type`, `Programme_Fee`, `Admin_ID`) VALUES
('P0', 'Master of IT', 'Coursework', 3000, 'A1'),
('P1', 'Master of Business', 'Coursework', 3000, 'A1'),
('P2', 'Master of Engineering', 'Research', 21000, 'A1'),
('P3', 'Master in AI', 'Coursework', 1500, 'A1');

-- --------------------------------------------------------

--
-- Table structure for table `project`
--

CREATE TABLE `project` (
  `Project_ID` varchar(10) NOT NULL,
  `Project_Title` varchar(100) NOT NULL,
  `Project_Description` varchar(100) NOT NULL,
  `Programme_ID` varchar(10) NOT NULL,
  `Staff_ID` varchar(10) NOT NULL,
  `Student_ID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `project`
--

INSERT INTO `project` (`Project_ID`, `Project_Title`, `Project_Description`, `Programme_ID`, `Staff_ID`, `Student_ID`) VALUES
('P0', 'Research in AI', 'Developing Artificial Intelligent', 'P0', 'L1', 'S1'),
('P1', 'AI Movement', 'Predict the Movement of AI', 'P3', 'L2', 'S2');

-- --------------------------------------------------------

--
-- Table structure for table `research`
--

CREATE TABLE `research` (
  `Student_ID` varchar(10) NOT NULL,
  `Field_Research` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `research`
--

INSERT INTO `research` (`Student_ID`, `Field_Research`) VALUES
('S1', 'Network'),
('S3', 'Music');

-- --------------------------------------------------------

--
-- Table structure for table `student`
--

CREATE TABLE `student` (
  `Student_ID` varchar(10) NOT NULL,
  `Stu_Password` varchar(100) NOT NULL,
  `Stu_Lname` varchar(100) NOT NULL,
  `Stu_Fname` varchar(100) NOT NULL,
  `Stu_IC` varchar(14) NOT NULL,
  `Stu_Gender` varchar(100) NOT NULL,
  `Stu_Address` varchar(100) NOT NULL,
  `Stu_Contact_No` varchar(100) NOT NULL,
  `Stu_Email` varchar(100) NOT NULL,
  `Stu_OutStandingFee` double NOT NULL,
  `Date_Add` date NOT NULL,
  `Stu_Type` varchar(100) NOT NULL,
  `Admin_ID` varchar(10) NOT NULL,
  `Programme_ID` varchar(10) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `student`
--

INSERT INTO `student` (`Student_ID`, `Stu_Password`, `Stu_Lname`, `Stu_Fname`, `Stu_IC`, `Stu_Gender`, `Stu_Address`, `Stu_Contact_No`, `Stu_Email`, `Stu_OutStandingFee`, `Date_Add`, `Stu_Type`, `Admin_ID`, `Programme_ID`) VALUES
('S0', '123', 'Tan', 'Kah Jun', '961108146187', 'Male', 'No 34, Jalan Pu1/3', '0172129966', 'jeff@gmail.com', 2500, '0000-00-00', 'Coursework', 'A1', 'P0'),
('S1', '123', 'Yap', 'Yung Seng', '971102441919', 'Female', 'No 34 Jalan Pu1/3', '018222999', 'yap@gmail.com', 0, '0000-00-00', 'Research', 'A1', 'P0'),
('S2', '123', 'Jeff', 'Toh', '970236541256', 'Male', 'No.50, Jalan 9/9', '0123456789', 'jefftoh@hotmail.com', -100, '0000-00-00', 'Coursework', 'A1', 'P3'),
('S3', '123', 'JJ', 'Lim', '971104102929', 'Female', 'MMU', '010192930', 'ysy121312', 22000, '0000-00-00', 'Research', 'A1', 'P2');

-- --------------------------------------------------------

--
-- Table structure for table `subject`
--

CREATE TABLE `subject` (
  `Subject_ID` varchar(10) NOT NULL,
  `Subject_Name` varchar(100) NOT NULL,
  `Subject_Credit_Hour` int(11) NOT NULL,
  `Subject_Fee` double NOT NULL,
  `Programme_ID` varchar(10) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `subject`
--

INSERT INTO `subject` (`Subject_ID`, `Subject_Name`, `Subject_Credit_Hour`, `Subject_Fee`, `Programme_ID`) VALUES
('BBB1101', 'Accounting', 4, 1500, 'P1'),
('BBB1201', 'Finance', 4, 1500, 'P1'),
('CCA1102', 'AI', 4, 1500, 'P3'),
('TCP1101', 'OOPD', 4, 1000, 'P0'),
('TCP2201', 'OOAD', 4, 1000, 'P0'),
('TSE1101', 'SE', 4, 1000, 'P0'),
('TTT1101', 'Calculus', 4, 1000, 'P2');

-- --------------------------------------------------------

--
-- Table structure for table `transaction`
--

CREATE TABLE `transaction` (
  `Transaction_ID` varchar(10) NOT NULL,
  `Student_ID` varchar(10) NOT NULL,
  `Admin_ID` varchar(10) NOT NULL,
  `Transaction_Date` date NOT NULL,
  `Transaction_Time` time NOT NULL,
  `Reference_ID` varchar(100) NOT NULL,
  `Amount` double NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

--
-- Dumping data for table `transaction`
--

INSERT INTO `transaction` (`Transaction_ID`, `Student_ID`, `Admin_ID`, `Transaction_Date`, `Transaction_Time`, `Reference_ID`, `Amount`) VALUES
('T0', 'S0', 'A1', '2017-10-04', '11:29:05', '600', 500),
('T1', 'S2', 'A1', '2017-10-04', '12:39:13', '123456789999', 1500),
('T2', 'S2', 'A1', '2017-10-04', '13:56:05', '', 100);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `academic_staff`
--
ALTER TABLE `academic_staff`
  ADD PRIMARY KEY (`Staff_ID`),
  ADD KEY `Admin_ID` (`Admin_ID`);

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`Admin_ID`);

--
-- Indexes for table `announcement`
--
ALTER TABLE `announcement`
  ADD PRIMARY KEY (`Announcement_ID`,`Admin_ID`),
  ADD KEY `Admin_ID` (`Admin_ID`);

--
-- Indexes for table `class`
--
ALTER TABLE `class`
  ADD PRIMARY KEY (`Class_ID`,`Subject_ID`),
  ADD UNIQUE KEY `Day` (`Day`,`Time`,`Venue`),
  ADD KEY `Subject_ID` (`Subject_ID`);

--
-- Indexes for table `colloquium`
--
ALTER TABLE `colloquium`
  ADD PRIMARY KEY (`Colloquium_ID`),
  ADD UNIQUE KEY `Colloquium_Venue` (`Colloquium_Venue`,`Colloquium_Date`,`Colloquium_Time`),
  ADD KEY `Project_ID` (`Project_ID`),
  ADD KEY `Student_ID` (`Student_ID`);

--
-- Indexes for table `coursework`
--
ALTER TABLE `coursework`
  ADD PRIMARY KEY (`Student_ID`);

--
-- Indexes for table `enrollment`
--
ALTER TABLE `enrollment`
  ADD PRIMARY KEY (`Student_ID`,`Subject_ID`,`Class_ID`),
  ADD KEY `Subject_ID` (`Subject_ID`),
  ADD KEY `Class_ID` (`Class_ID`);

--
-- Indexes for table `programme`
--
ALTER TABLE `programme`
  ADD PRIMARY KEY (`Programme_ID`),
  ADD KEY `Admin_ID` (`Admin_ID`);

--
-- Indexes for table `project`
--
ALTER TABLE `project`
  ADD PRIMARY KEY (`Project_ID`),
  ADD UNIQUE KEY `Student_ID` (`Student_ID`),
  ADD KEY `Programme_ID` (`Programme_ID`),
  ADD KEY `Staff_ID` (`Staff_ID`);

--
-- Indexes for table `research`
--
ALTER TABLE `research`
  ADD PRIMARY KEY (`Student_ID`);

--
-- Indexes for table `student`
--
ALTER TABLE `student`
  ADD PRIMARY KEY (`Student_ID`),
  ADD KEY `Admin_ID` (`Admin_ID`),
  ADD KEY `Programme_ID` (`Programme_ID`);

--
-- Indexes for table `subject`
--
ALTER TABLE `subject`
  ADD PRIMARY KEY (`Subject_ID`),
  ADD KEY `Programme_ID` (`Programme_ID`);

--
-- Indexes for table `transaction`
--
ALTER TABLE `transaction`
  ADD PRIMARY KEY (`Transaction_ID`,`Student_ID`,`Admin_ID`),
  ADD UNIQUE KEY `Reference_ID` (`Reference_ID`),
  ADD KEY `Student_ID` (`Student_ID`),
  ADD KEY `Admin_ID` (`Admin_ID`);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `academic_staff`
--
ALTER TABLE `academic_staff`
  ADD CONSTRAINT `academic_staff_ibfk_1` FOREIGN KEY (`Admin_ID`) REFERENCES `admin` (`Admin_ID`);

--
-- Constraints for table `announcement`
--
ALTER TABLE `announcement`
  ADD CONSTRAINT `announcement_ibfk_1` FOREIGN KEY (`Admin_ID`) REFERENCES `admin` (`Admin_ID`);

--
-- Constraints for table `class`
--
ALTER TABLE `class`
  ADD CONSTRAINT `class_ibfk_1` FOREIGN KEY (`Subject_ID`) REFERENCES `subject` (`Subject_ID`);

--
-- Constraints for table `colloquium`
--
ALTER TABLE `colloquium`
  ADD CONSTRAINT `colloquium_ibfk_1` FOREIGN KEY (`Project_ID`) REFERENCES `project` (`Project_ID`),
  ADD CONSTRAINT `colloquium_ibfk_2` FOREIGN KEY (`Student_ID`) REFERENCES `research` (`Student_ID`);

--
-- Constraints for table `coursework`
--
ALTER TABLE `coursework`
  ADD CONSTRAINT `coursework_ibfk_1` FOREIGN KEY (`Student_ID`) REFERENCES `student` (`Student_ID`);

--
-- Constraints for table `enrollment`
--
ALTER TABLE `enrollment`
  ADD CONSTRAINT `enrollment_ibfk_1` FOREIGN KEY (`Student_ID`) REFERENCES `student` (`Student_ID`),
  ADD CONSTRAINT `enrollment_ibfk_2` FOREIGN KEY (`Subject_ID`) REFERENCES `subject` (`Subject_ID`),
  ADD CONSTRAINT `enrollment_ibfk_3` FOREIGN KEY (`Class_ID`) REFERENCES `class` (`Class_ID`);

--
-- Constraints for table `programme`
--
ALTER TABLE `programme`
  ADD CONSTRAINT `programme_ibfk_1` FOREIGN KEY (`Admin_ID`) REFERENCES `admin` (`Admin_ID`);

--
-- Constraints for table `project`
--
ALTER TABLE `project`
  ADD CONSTRAINT `project_ibfk_1` FOREIGN KEY (`Programme_ID`) REFERENCES `programme` (`Programme_ID`),
  ADD CONSTRAINT `project_ibfk_2` FOREIGN KEY (`Student_ID`) REFERENCES `student` (`Student_ID`),
  ADD CONSTRAINT `project_ibfk_3` FOREIGN KEY (`Staff_ID`) REFERENCES `academic_staff` (`Staff_ID`);

--
-- Constraints for table `research`
--
ALTER TABLE `research`
  ADD CONSTRAINT `research_ibfk_1` FOREIGN KEY (`Student_ID`) REFERENCES `student` (`Student_ID`);

--
-- Constraints for table `student`
--
ALTER TABLE `student`
  ADD CONSTRAINT `student_ibfk_1` FOREIGN KEY (`Admin_ID`) REFERENCES `admin` (`Admin_ID`),
  ADD CONSTRAINT `student_ibfk_2` FOREIGN KEY (`Programme_ID`) REFERENCES `programme` (`Programme_ID`);

--
-- Constraints for table `subject`
--
ALTER TABLE `subject`
  ADD CONSTRAINT `subject_ibfk_1` FOREIGN KEY (`Programme_ID`) REFERENCES `programme` (`Programme_ID`);

--
-- Constraints for table `transaction`
--
ALTER TABLE `transaction`
  ADD CONSTRAINT `transaction_ibfk_1` FOREIGN KEY (`Student_ID`) REFERENCES `student` (`Student_ID`),
  ADD CONSTRAINT `transaction_ibfk_2` FOREIGN KEY (`Admin_ID`) REFERENCES `admin` (`Admin_ID`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
