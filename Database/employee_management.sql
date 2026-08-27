-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Aug 23, 2026 at 10:31 PM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.0.30

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `employee_management`
--

-- --------------------------------------------------------

--
-- Table structure for table `admin`
--

CREATE TABLE `admin` (
  `admin_id` int(11) NOT NULL,
  `username` varchar(100) NOT NULL,
  `password` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `admin`
--

INSERT INTO `admin` (`admin_id`, `username`, `password`) VALUES
(1, 'admin', 'admin123');

-- --------------------------------------------------------

--
-- Table structure for table `attendance`
--

CREATE TABLE `attendance` (
  `attentence_id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `date` date NOT NULL,
  `checkIn` time NOT NULL,
  `checkOut` time NOT NULL,
  `status` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `attendance`
--

INSERT INTO `attendance` (`attentence_id`, `emp_id`, `date`, `checkIn`, `checkOut`, `status`) VALUES
(1, 1, '2026-08-02', '09:00:00', '18:00:00', 'Present'),
(2, 2, '2026-08-13', '09:30:00', '18:59:00', 'Late'),
(3, 3, '2026-08-15', '09:29:00', '18:30:00', 'Absent');

-- --------------------------------------------------------

--
-- Table structure for table `departments`
--

CREATE TABLE `departments` (
  `Dep_id` int(11) NOT NULL,
  `Dep_name` varchar(200) NOT NULL,
  `department_head_id` int(11) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `departments`
--

INSERT INTO `departments` (`Dep_id`, `Dep_name`, `department_head_id`) VALUES
(1, 'HR', NULL),
(2, 'IT', NULL),
(3, 'Software Developer', NULL),
(4, 'Marketing', NULL),
(5, 'Finance', NULL);

-- --------------------------------------------------------

--
-- Table structure for table `designations`
--

CREATE TABLE `designations` (
  `designation_id` int(11) NOT NULL,
  `title` varchar(200) NOT NULL,
  `department_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `designations`
--

INSERT INTO `designations` (`designation_id`, `title`, `department_id`) VALUES
(1, 'Software Engineer', 1),
(2, 'HR Executive', 2),
(3, 'Accountant', 3);

-- --------------------------------------------------------

--
-- Table structure for table `employees`
--

CREATE TABLE `employees` (
  `emp_id` int(11) NOT NULL,
  `emp_name` varchar(200) NOT NULL,
  `emp_email` varchar(200) NOT NULL,
  `phone` varchar(100) NOT NULL,
  `Dep_id` int(11) NOT NULL,
  `designation` varchar(100) NOT NULL,
  `joiningDate` date NOT NULL,
  `salary` decimal(10,2) NOT NULL,
  `password` varchar(255) NOT NULL,
  `status` varchar(20) NOT NULL DEFAULT 'Active',
  `reporting_manager_id` int(11) DEFAULT NULL,
  `employee_code` varchar(20) DEFAULT NULL,
  `gender` varchar(10) DEFAULT NULL,
  `date_of_birth` date DEFAULT NULL,
  `cnic` varchar(20) DEFAULT NULL,
  `address` varchar(255) DEFAULT NULL,
  `emergency_contact` varchar(50) DEFAULT NULL,
  `employment_type` varchar(30) NOT NULL DEFAULT 'Full-time'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employees`
--

INSERT INTO `employees` (`emp_id`, `emp_name`, `emp_email`, `phone`, `Dep_id`, `designation`, `joiningDate`, `salary`, `password`, `status`, `reporting_manager_id`, `employee_code`, `gender`, `date_of_birth`, `cnic`, `address`, `emergency_contact`, `employment_type`) VALUES
(1, 'Ali Khan', 'ali123@gmail.com', '03001234567', 1, 'Software Developer', '2026-08-01', 50000.00, 'ali123', 'Deactivated', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Full-time'),
(2, 'Zara Hassan', 'Zara123@gmail.com', '03007654321', 2, ' HR Executive', '2026-08-04', 60000.00, 'zara123', 'Active', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Full-time'),
(3, 'test user', 'test@gmail.com', '03001112222', 3, 'HR', '2026-08-06', 60000.00, 'test123', 'Active', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Full-time'),
(4, 'farkhunda', 'farkhunda12@gmail.com', '03010025103', 2, 'IT', '2026-08-01', 50000.00, 'farkhunda123', 'Active', NULL, NULL, NULL, NULL, NULL, NULL, NULL, 'Full-time'),
(5, 'rabia', 'rabia11@gmail.com', '02452179283', 3, 'Software Engineer', '2026-08-20', 60000.00, 'rabia123', 'Active', 2, NULL, NULL, NULL, NULL, NULL, NULL, 'Full-time'),
(6, 'Hassan', 'hassan05@gmail.com', '03787427678', 1, 'HR Executive', '2026-08-22', 45000.00, 'hassan123', 'Active', 5, 'EMP-001', 'Male', '1990-06-12', '45302-45362822-2', 'xyz Gulshan e hadeed', 'Bilal 023289829', 'Part-time');

-- --------------------------------------------------------

--
-- Table structure for table `employee_status_history`
--

CREATE TABLE `employee_status_history` (
  `history_id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `old_status` varchar(100) NOT NULL,
  `new_status` varchar(100) NOT NULL,
  `changed_by` varchar(200) NOT NULL,
  `changed_date` datetime NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `employee_status_history`
--

INSERT INTO `employee_status_history` (`history_id`, `emp_id`, `old_status`, `new_status`, `changed_by`, `changed_date`) VALUES
(1, 1, 'Active', 'Deactivated', 'admin', '2026-08-20 11:02:06');

-- --------------------------------------------------------

--
-- Table structure for table `leaves`
--

CREATE TABLE `leaves` (
  `leave_id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `leave_type` varchar(200) NOT NULL,
  `start_date` date NOT NULL,
  `end_date` date NOT NULL,
  `reason` varchar(255) NOT NULL,
  `status` varchar(20) NOT NULL,
  `approved_by` varchar(100) DEFAULT NULL,
  `approved_date` datetime DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `leaves`
--

INSERT INTO `leaves` (`leave_id`, `emp_id`, `leave_type`, `start_date`, `end_date`, `reason`, `status`, `approved_by`, `approved_date`) VALUES
(1, 2, 'Sick Leave', '2026-08-10', '2026-08-14', 'Fever', 'Approved', '', NULL),
(2, 1, 'Sick Leave', '2026-08-10', '2026-08-14', 'Fever', 'Approved', '', NULL),
(3, 3, 'Casual Leave', '2026-08-06', '2026-08-12', 'Personal work', 'Rejected', '', NULL),
(4, 3, 'Casual Leave', '2026-08-07', '2026-08-13', 'Personal work', 'Approved', '', NULL),
(5, 3, 'Sick Leave', '2026-08-03', '2026-08-14', 'Fever', 'Approved', '', NULL),
(6, 4, 'Sick Leave', '2026-08-20', '2026-08-25', 'fever', 'Approved', 'admin', '2026-08-20 11:22:04'),
(7, 4, 'Casual Leave', '2026-08-20', '2026-08-28', 'work', 'Rejected', 'admin', '2026-08-20 11:22:09');

-- --------------------------------------------------------

--
-- Table structure for table `payroll`
--

CREATE TABLE `payroll` (
  `payroll_id` int(11) NOT NULL,
  `emp_id` int(11) NOT NULL,
  `month` varchar(100) NOT NULL,
  `basic_salary` decimal(10,2) NOT NULL,
  `deduction` decimal(10,2) NOT NULL,
  `net_salary` decimal(10,2) NOT NULL,
  `allowances` decimal(10,2) NOT NULL DEFAULT 0.00,
  `gross_salary` decimal(10,2) NOT NULL DEFAULT 0.00,
  `payment_status` varchar(20) NOT NULL DEFAULT 'Pending'
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `payroll`
--

INSERT INTO `payroll` (`payroll_id`, `emp_id`, `month`, `basic_salary`, `deduction`, `net_salary`, `allowances`, `gross_salary`, `payment_status`) VALUES
(1, 1, 'August 2026', 50000.00, 2000.00, 48000.00, 0.00, 0.00, 'Paid'),
(2, 3, 'september 2026', 60000.00, 5000.00, 55000.00, 0.00, 0.00, 'Paid'),
(3, 3, 'August 2026', 50000.00, 1000.00, 49000.00, 0.00, 0.00, 'Paid'),
(4, 2, 'september 2026', 45000.00, 1500.00, 46500.00, 3000.00, 48000.00, 'Pending');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `admin`
--
ALTER TABLE `admin`
  ADD PRIMARY KEY (`admin_id`);

--
-- Indexes for table `attendance`
--
ALTER TABLE `attendance`
  ADD PRIMARY KEY (`attentence_id`),
  ADD KEY `emp_id` (`emp_id`);

--
-- Indexes for table `departments`
--
ALTER TABLE `departments`
  ADD PRIMARY KEY (`Dep_id`),
  ADD KEY `department_head_id` (`department_head_id`);

--
-- Indexes for table `designations`
--
ALTER TABLE `designations`
  ADD PRIMARY KEY (`designation_id`),
  ADD KEY `department_id` (`department_id`);

--
-- Indexes for table `employees`
--
ALTER TABLE `employees`
  ADD PRIMARY KEY (`emp_id`),
  ADD KEY `Dep_id` (`Dep_id`),
  ADD KEY `reporting_manager_id` (`reporting_manager_id`);

--
-- Indexes for table `employee_status_history`
--
ALTER TABLE `employee_status_history`
  ADD PRIMARY KEY (`history_id`),
  ADD KEY `emp_id` (`emp_id`);

--
-- Indexes for table `leaves`
--
ALTER TABLE `leaves`
  ADD PRIMARY KEY (`leave_id`),
  ADD KEY `emp_id` (`emp_id`);

--
-- Indexes for table `payroll`
--
ALTER TABLE `payroll`
  ADD PRIMARY KEY (`payroll_id`),
  ADD KEY `emp_id` (`emp_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `admin`
--
ALTER TABLE `admin`
  MODIFY `admin_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `attendance`
--
ALTER TABLE `attendance`
  MODIFY `attentence_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `departments`
--
ALTER TABLE `departments`
  MODIFY `Dep_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=6;

--
-- AUTO_INCREMENT for table `designations`
--
ALTER TABLE `designations`
  MODIFY `designation_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT for table `employees`
--
ALTER TABLE `employees`
  MODIFY `emp_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=7;

--
-- AUTO_INCREMENT for table `employee_status_history`
--
ALTER TABLE `employee_status_history`
  MODIFY `history_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=2;

--
-- AUTO_INCREMENT for table `leaves`
--
ALTER TABLE `leaves`
  MODIFY `leave_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=8;

--
-- AUTO_INCREMENT for table `payroll`
--
ALTER TABLE `payroll`
  MODIFY `payroll_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `attendance`
--
ALTER TABLE `attendance`
  ADD CONSTRAINT `attendance_ibfk_1` FOREIGN KEY (`emp_id`) REFERENCES `employees` (`emp_id`);

--
-- Constraints for table `departments`
--
ALTER TABLE `departments`
  ADD CONSTRAINT `departments_ibfk_1` FOREIGN KEY (`department_head_id`) REFERENCES `departments` (`Dep_id`);

--
-- Constraints for table `designations`
--
ALTER TABLE `designations`
  ADD CONSTRAINT `designations_ibfk_1` FOREIGN KEY (`department_id`) REFERENCES `departments` (`Dep_id`);

--
-- Constraints for table `employees`
--
ALTER TABLE `employees`
  ADD CONSTRAINT `employees_ibfk_1` FOREIGN KEY (`Dep_id`) REFERENCES `departments` (`Dep_id`),
  ADD CONSTRAINT `employees_ibfk_2` FOREIGN KEY (`reporting_manager_id`) REFERENCES `employees` (`emp_id`);

--
-- Constraints for table `employee_status_history`
--
ALTER TABLE `employee_status_history`
  ADD CONSTRAINT `employee_status_history_ibfk_1` FOREIGN KEY (`emp_id`) REFERENCES `employees` (`emp_id`);

--
-- Constraints for table `leaves`
--
ALTER TABLE `leaves`
  ADD CONSTRAINT `leaves_ibfk_1` FOREIGN KEY (`emp_id`) REFERENCES `employees` (`emp_id`);

--
-- Constraints for table `payroll`
--
ALTER TABLE `payroll`
  ADD CONSTRAINT `payroll_ibfk_1` FOREIGN KEY (`emp_id`) REFERENCES `employees` (`emp_id`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
