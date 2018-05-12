-- phpMyAdmin SQL Dump
-- version 4.7.0
-- https://www.phpmyadmin.net/
--
-- Host: localhost:8889
-- Generation Time: May 12, 2018 at 09:01 AM
-- Server version: 5.6.34-log
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
-- Database: `band_tracker`
--

-- --------------------------------------------------------

--
-- Table structure for table `bands`
--

CREATE TABLE `bands` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `songs` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bands`
--

INSERT INTO `bands` (`id`, `name`, `songs`) VALUES
(1, 'Pearl Jam', 'Jamming Pearl'),
(2, 'Python Jam', 'Jamming Python'),
(3, 'Ruby Jam', 'Jamming with Ruby'),
(4, 'C# Jam', 'Jamming with C3'),
(5, 'C++ Jam', 'Jamming with C++'),
(6, 'Blue Grass', 'Home of the Brave'),
(7, 'Perl Coding', 'I Love Perl'),
(8, 'Jesse James', 'Steeler Nation');

-- --------------------------------------------------------

--
-- Table structure for table `bands_venues`
--

CREATE TABLE `bands_venues` (
  `id` int(11) NOT NULL,
  `band_id` int(11) NOT NULL,
  `venue_id` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `bands_venues`
--

INSERT INTO `bands_venues` (`id`, `band_id`, `venue_id`) VALUES
(1, 1, 1),
(2, 2, 1),
(3, 3, 1),
(4, 3, 2),
(5, 3, 1),
(6, 5, 1),
(7, 3, 6),
(8, 3, 7),
(9, 6, 8),
(10, 7, 4),
(11, 8, 10),
(12, 7, 11),
(13, 4, 12);

-- --------------------------------------------------------

--
-- Table structure for table `venue`
--

CREATE TABLE `venue` (
  `id` int(11) NOT NULL,
  `name` varchar(255) NOT NULL,
  `locations` varchar(255) NOT NULL,
  `stars` int(11) NOT NULL,
  `hours` varchar(255) NOT NULL,
  `phone` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `venue`
--

INSERT INTO `venue` (`id`, `name`, `locations`, `stars`, `hours`, `phone`) VALUES
(1, 'WithinSodo', '2916 Utah Ave S Seattle WA 98134', 5, '8AM-12PM', '(206)583-7186'),
(2, 'Georgetown Ballroom', '5623 Airport Way S, Seattle, WA 98108', 5, '10AM-10PM', '(206)-763-4999'),
(3, '10 Degrees', '1312 E Union St, Seattle, WA 98122', 5, '8Am-11PM', '(206)123-4567'),
(4, 'Urban Light Studios', '8537 GreenWood Ave N Suite 1, Seattle, WA 98103', 5, '7AM-11PM', '(206)708-7281'),
(5, 'Sodo Park', '3200 1st Ave S, Seattle, WA 98134', 5, '9AM-5PM', '(206)-932-4717'),
(6, 'StubHub Center', '18400 S Avalon Blvd, Carson, CA 90746', 4, '1PM-10PM', ' (310) 630-2000'),
(7, 'Sudo', '4023 Airport Way S, Seattle WA 98103', 5, '8AM-5PM', '4230923432'),
(8, 'West Symphony', '4023 Airport Way S, Seattle WA 98103', 4, '8PM-8AM', '4253508321'),
(9, 'Staples Center', '1111 S Figueroa St, Los Angeles, CA 90015', 5, '9AM-9PM', '(213)742-7100'),
(10, 'The Forum', '3900 W Manchester Blvd, Inglewood, CA 90305', 5, '9AM-9PM', '(310) 330-7300'),
(11, 'Dodger Stadium', '1000 Vin Scully Ave, Los Angeles, CA 90012', 4, '8AM-5PM', '4230923432'),
(12, 'Las Vegas', '1111 S Figueroa St, Los Angeles, CA 90015', 4, '7AM-Noon', '4230923432');

--
-- Indexes for dumped tables
--

--
-- Indexes for table `bands`
--
ALTER TABLE `bands`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `bands_venues`
--
ALTER TABLE `bands_venues`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `venue`
--
ALTER TABLE `venue`
  ADD PRIMARY KEY (`id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `bands`
--
ALTER TABLE `bands`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=9;
--
-- AUTO_INCREMENT for table `bands_venues`
--
ALTER TABLE `bands_venues`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;
--
-- AUTO_INCREMENT for table `venue`
--
ALTER TABLE `venue`
  MODIFY `id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=13;COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
