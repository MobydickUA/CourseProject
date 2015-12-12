-- phpMyAdmin SQL Dump
-- version 3.5.1
-- http://www.phpmyadmin.net
--
-- Host: 127.0.0.1
-- Generation Time: Dec 12, 2015 at 04:43 PM
-- Server version: 5.5.25
-- PHP Version: 5.3.13

SET SQL_MODE="NO_AUTO_VALUE_ON_ZERO";
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;

--
-- Database: `household_db`
--

-- --------------------------------------------------------

--
-- Table structure for table `inventory`
--

CREATE TABLE IF NOT EXISTS `inventory` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `type_id` bigint(20) unsigned NOT NULL,
  `date_of_buy` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `price` int(11) DEFAULT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  KEY `fk_inventory` (`type_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=38 ;

--
-- Dumping data for table `inventory`
--

INSERT INTO `inventory` (`ID`, `type_id`, `date_of_buy`, `price`) VALUES
(1, 1, '2013-08-09 21:00:00', 30000),
(2, 2, '2013-07-01 11:41:33', 25000),
(3, 3, '2013-10-31 22:00:00', 32000),
(4, 4, '2014-05-31 21:00:00', 10000),
(5, 5, '2013-12-31 22:00:00', 12000),
(6, 9, '2012-11-30 22:00:00', 8000),
(28, 10, '2015-12-06 16:18:43', 7000),
(31, 14, '2015-12-09 12:45:38', 2000),
(32, 15, '2015-12-09 12:45:51', 5000),
(33, 13, '2015-12-09 12:46:10', 2500),
(34, 12, '2015-12-10 10:48:36', 100000),
(35, 11, '2015-12-10 10:48:55', 500000),
(37, 15, '2015-12-10 10:49:35', 50000);

-- --------------------------------------------------------

--
-- Table structure for table `inventory_types`
--

CREATE TABLE IF NOT EXISTS `inventory_types` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `type` varchar(25) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=16 ;

--
-- Dumping data for table `inventory_types`
--

INSERT INTO `inventory_types` (`ID`, `type`) VALUES
(1, 'Меблі з вітальні'),
(2, 'Меблі зі спальні'),
(3, 'Меблі із кухні'),
(4, 'Телевізор'),
(5, 'Настільніий комп''юте'),
(9, 'Холодильник'),
(10, 'Пральна машина'),
(11, 'Машина'),
(12, 'Байк'),
(13, 'Мобільний телефон'),
(14, 'Кухоний комбайн'),
(15, 'Золоті сережки');

-- --------------------------------------------------------

--
-- Table structure for table `months`
--

CREATE TABLE IF NOT EXISTS `months` (
  `id` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(20) DEFAULT NULL,
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=13 ;

--
-- Dumping data for table `months`
--

INSERT INTO `months` (`id`, `name`) VALUES
(1, 'Січень'),
(2, 'Лютий'),
(3, 'Березень'),
(4, 'Квітень'),
(5, 'Травень'),
(6, 'Липень'),
(7, 'Червень'),
(8, 'Серпень'),
(9, 'Вересень'),
(10, 'Жовтень'),
(11, 'Листопад'),
(12, 'Грудень');

-- --------------------------------------------------------

--
-- Table structure for table `owners`
--

CREATE TABLE IF NOT EXISTS `owners` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(10) NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  UNIQUE KEY `owner_name` (`name`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=6 ;

--
-- Dumping data for table `owners`
--

INSERT INTO `owners` (`ID`, `name`) VALUES
(5, 'Вся родина'),
(4, 'Донька'),
(2, 'Дружина'),
(3, 'Син'),
(1, 'Чоловік');

-- --------------------------------------------------------

--
-- Table structure for table `transactions`
--

CREATE TABLE IF NOT EXISTS `transactions` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `date` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `type` int(11) NOT NULL,
  `Amount` int(10) unsigned NOT NULL,
  `type_id` bigint(20) unsigned NOT NULL,
  PRIMARY KEY (`ID`),
  UNIQUE KEY `ID` (`ID`),
  KEY `type_id` (`type_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=80 ;

--
-- Dumping data for table `transactions`
--

INSERT INTO `transactions` (`ID`, `date`, `type`, `Amount`, `type_id`) VALUES
(1, '2015-11-11 22:00:00', 1, 9000, 4),
(2, '2015-11-13 22:00:00', 0, 400, 1),
(3, '2015-11-01 22:00:00', 1, 7500, 5),
(6, '2015-11-06 22:00:00', 1, 825, 6),
(7, '2015-11-15 22:00:00', 0, 800, 2),
(48, '2015-11-15 22:00:00', 0, 7000, 35),
(53, '2014-01-04 22:00:00', 1, 987, 34),
(57, '2015-11-26 22:00:00', 1, 825, 6),
(58, '2015-12-07 22:00:00', 1, 500, 40),
(59, '2015-04-22 21:00:00', 1, 3000, 41),
(60, '2015-04-15 21:00:00', 0, 900, 38),
(61, '2015-10-21 21:00:00', 0, 1200, 1),
(62, '2015-12-07 22:00:00', 0, 10000, 37),
(63, '2015-12-07 22:00:00', 0, 200, 36),
(65, '2015-04-15 11:44:56', 0, 500000, 45),
(66, '2014-11-20 12:45:13', 0, 100000, 46),
(67, '2015-09-02 11:45:38', 0, 2000, 47),
(68, '2015-05-05 11:45:51', 0, 5000, 48),
(69, '2015-03-17 12:46:10', 0, 2500, 49),
(70, '2014-09-08 21:00:00', 1, 10000, 44),
(71, '2015-08-08 21:00:00', 1, 9000, 4),
(72, '2015-08-07 21:00:00', 1, 7500, 5),
(73, '2015-12-08 22:00:00', 0, 20, 51),
(74, '2015-12-08 22:00:00', 0, 15, 50),
(75, '2012-10-02 21:00:00', 0, 500, 38),
(76, '2012-06-19 21:00:00', 1, 6000, 4),
(77, '2015-12-10 09:23:45', 1, 100000, 53),
(78, '2015-12-09 22:00:00', 0, 5000, 2),
(79, '2015-12-10 10:34:14', 1, 500000, 55);

-- --------------------------------------------------------

--
-- Table structure for table `transaction_types`
--

CREATE TABLE IF NOT EXISTS `transaction_types` (
  `ID` bigint(20) unsigned NOT NULL AUTO_INCREMENT,
  `name` varchar(30) NOT NULL,
  `type` int(11) NOT NULL,
  `owner_id` bigint(20) unsigned NOT NULL,
  UNIQUE KEY `ID` (`ID`),
  UNIQUE KEY `name` (`name`),
  KEY `fk_transaction_types` (`owner_id`)
) ENGINE=InnoDB  DEFAULT CHARSET=utf8 AUTO_INCREMENT=56 ;

--
-- Dumping data for table `transaction_types`
--

INSERT INTO `transaction_types` (`ID`, `name`, `type`, `owner_id`) VALUES
(1, 'Їжа', 0, 5),
(2, 'Нове взуття доньці', 0, 4),
(3, 'Ремонт кухні', 0, 1),
(4, 'ЗП чоловіка', 1, 1),
(5, 'ЗП дружини', 1, 2),
(6, 'Стипендія', 1, 3),
(34, 'Продаж ''Пральна машина''', 1, 5),
(35, 'Купівля ''Пральна машина''', 0, 1),
(36, 'Повернення боргу сусіду', 0, 1),
(37, 'Поїздка на курорт', 0, 5),
(38, 'Нові туфлі жінці', 0, 2),
(39, 'Премія', 1, 2),
(40, 'Лотерея', 1, 4),
(41, 'Підроботка', 1, 1),
(42, 'Здача квартири', 1, 5),
(43, 'Здача макулатури', 1, 4),
(44, 'Подарунок на річницю', 1, 2),
(45, 'Купівля ''Машина''', 0, 1),
(46, 'Купівля ''Байк''', 0, 1),
(47, 'Купівля ''Кухоний комбайн''', 0, 2),
(48, 'Купівля ''Золоті сережки''', 0, 2),
(49, 'Купівля ''Мобільний телефон''', 0, 4),
(50, 'Витрати на проїзд', 0, 4),
(51, 'Шоколадка', 0, 4),
(53, 'Продаж ''Байк''', 1, 5),
(54, 'Моя душа', 0, 2),
(55, 'Продаж ''Машина''', 1, 5);

--
-- Constraints for dumped tables
--

--
-- Constraints for table `inventory`
--
ALTER TABLE `inventory`
  ADD CONSTRAINT `fk_inventory` FOREIGN KEY (`type_id`) REFERENCES `inventory_types` (`ID`);

--
-- Constraints for table `transactions`
--
ALTER TABLE `transactions`
  ADD CONSTRAINT `transactions_ibfk_1` FOREIGN KEY (`type_id`) REFERENCES `transaction_types` (`ID`);

--
-- Constraints for table `transaction_types`
--
ALTER TABLE `transaction_types`
  ADD CONSTRAINT `fk_transaction_types` FOREIGN KEY (`owner_id`) REFERENCES `owners` (`ID`);

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
