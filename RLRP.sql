-- --------------------------------------------------------
-- Host:                         localhost
-- Server version:               10.4.11-MariaDB - mariadb.org binary distribution
-- Server OS:                    Win64
-- HeidiSQL Version:             11.0.0.5919
-- --------------------------------------------------------

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET NAMES utf8 */;
/*!50503 SET NAMES utf8mb4 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;


-- Dumping database structure for launcher
CREATE DATABASE IF NOT EXISTS `launcher` /*!40100 DEFAULT CHARACTER SET utf8mb4 */;
USE `launcher`;

-- Dumping structure for table launcher.loginlauncher_users
CREATE TABLE IF NOT EXISTS `loginlauncher_users` (
  `username` varchar(50) NOT NULL DEFAULT '',
  `password` varchar(50) DEFAULT 'DefaultPass',
  `externalip` varchar(50) DEFAULT '127.0.0.1',
  `IsAdmin` bit(1) DEFAULT b'0',
  `IsAllowed` bit(1) DEFAULT b'0',
  `discordid` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`username`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

-- Dumping data for table launcher.loginlauncher_users: ~1 rows (approximately)
DELETE FROM `loginlauncher_users`;
/*!40000 ALTER TABLE `loginlauncher_users` DISABLE KEYS */;
INSERT INTO `loginlauncher_users` (`username`, `password`, `externalip`, `IsAdmin`, `IsAllowed`, `discordid`) VALUES
	('KOSTA', 'cracked', '127.0.0.1', b'0', b'0', '241793558737190913'),
	('test', 'hs', '127.0.0.1', b'0', b'0', '00');
/*!40000 ALTER TABLE `loginlauncher_users` ENABLE KEYS */;

/*!40101 SET SQL_MODE=IFNULL(@OLD_SQL_MODE, '') */;
/*!40014 SET FOREIGN_KEY_CHECKS=IF(@OLD_FOREIGN_KEY_CHECKS IS NULL, 1, @OLD_FOREIGN_KEY_CHECKS) */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
