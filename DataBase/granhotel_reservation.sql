CREATE DATABASE  IF NOT EXISTS `granhotel` /*!40100 DEFAULT CHARACTER SET utf8mb4 COLLATE utf8mb4_0900_ai_ci */ /*!80016 DEFAULT ENCRYPTION='N' */;
USE `granhotel`;
-- MySQL dump 10.13  Distrib 8.0.32, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: granhotel
-- ------------------------------------------------------
-- Server version	8.0.32

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `reservation`
--

DROP TABLE IF EXISTS `reservation`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `reservation` (
  `reservationId` int NOT NULL,
  `guestId` int DEFAULT NULL,
  `roomId` int DEFAULT NULL,
  `reservationInDate` datetime DEFAULT NULL,
  `reservationOutDate` datetime DEFAULT NULL,
  `reservationStatus` varchar(2) DEFAULT 'N',
  PRIMARY KEY (`reservationId`),
  KEY `guestReservFK_idx` (`guestId`),
  KEY `roomReservFK_idx` (`roomId`),
  CONSTRAINT `guestReservFK` FOREIGN KEY (`guestId`) REFERENCES `guest` (`guestId`) ON DELETE CASCADE ON UPDATE CASCADE,
  CONSTRAINT `roomReservFK` FOREIGN KEY (`roomId`) REFERENCES `room` (`roomId`) ON DELETE CASCADE ON UPDATE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `reservation`
--

LOCK TABLES `reservation` WRITE;
/*!40000 ALTER TABLE `reservation` DISABLE KEYS */;
INSERT INTO `reservation` VALUES (1,1,1,'2023-04-06 00:00:00',NULL,'A'),(2,2,2,'2023-04-05 00:00:00',NULL,'A'),(3,6,3,'2023-04-06 22:50:52','2023-04-07 12:39:57','A'),(4,6,3,'2023-04-06 22:52:47','2023-04-06 22:53:25','A'),(5,7,1,'2023-04-07 15:45:57',NULL,'A'),(6,8,3,'2023-04-07 15:54:31',NULL,'A'),(7,9,1,'2023-04-07 15:56:27',NULL,'A'),(8,2,2,'2023-04-07 15:58:44',NULL,'A'),(9,10,3,'2023-04-07 16:05:42',NULL,'A'),(10,11,1,'2023-04-07 16:06:43',NULL,'A'),(11,2,2,'2023-04-07 16:07:38','2023-04-09 23:07:58','A'),(12,12,3,'2023-04-07 16:10:14','2023-04-09 23:24:24','A'),(13,13,1,'2023-04-08 01:36:23','2023-04-09 23:27:33','A'),(14,2,1,'2023-04-09 23:28:34','2023-04-09 23:36:16','A'),(15,14,3,'2023-04-09 23:29:24','2023-04-09 23:41:34','A'),(16,15,2,'2023-04-09 23:34:19',NULL,'A'),(17,16,1,'2023-04-09 23:36:29','2023-04-09 23:38:28','A'),(18,17,1,'2023-04-09 23:41:14','2023-04-09 23:41:22','A'),(19,17,3,'2023-04-09 23:41:40',NULL,'A'),(20,18,1,'2023-04-09 23:47:12',NULL,'A');
/*!40000 ALTER TABLE `reservation` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2023-04-09 23:54:36
