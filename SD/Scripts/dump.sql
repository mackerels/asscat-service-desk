use `2x2crm`;

-- MySQL dump 10.13  Distrib 5.7.17, for Win64 (x86_64)
--
-- Host: 127.0.0.1    Database: 2x2crm
-- ------------------------------------------------------
-- Server version	5.6.17

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `agent`
--

DROP TABLE IF EXISTS `agent`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `agent` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8 NOT NULL,
  `ClientId` int(11) DEFAULT NULL,
  `Login` text,
  `Password` text,
  PRIMARY KEY (`Id`),
  KEY `agent_client_Id_fk` (`ClientId`),
  CONSTRAINT `agent_client_Id_fk` FOREIGN KEY (`ClientId`) REFERENCES `client` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agent`
--

LOCK TABLES `agent` WRITE;
/*!40000 ALTER TABLE `agent` DISABLE KEYS */;
INSERT INTO `agent` VALUES (1,'Павел',1,'b.paul4@gmail.com','P123'),(2,'Владимир',1,NULL,NULL),(3,'Вадим',1,NULL,NULL),(4,'Алена',1,NULL,NULL),(5,'Саша',1,NULL,NULL),(6,'Катя',1,NULL,NULL),(7,'Женя',1,NULL,NULL),(8,'Алена',2,NULL,NULL),(9,'Елена',2,NULL,NULL);
/*!40000 ALTER TABLE `agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `client`
--

DROP TABLE IF EXISTS `client`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `client` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `client`
--

LOCK TABLES `client` WRITE;
/*!40000 ALTER TABLE `client` DISABLE KEYS */;
INSERT INTO `client` VALUES (1,'Казначей'),(2,'МК');
/*!40000 ALTER TABLE `client` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `emails`
--

DROP TABLE IF EXISTS `emails`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `emails` (
  `id` int(11) NOT NULL,
  `AgentId` int(11) DEFAULT NULL,
  `email` varchar(255) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`),
  KEY `emails_agent_Id_fk` (`AgentId`),
  CONSTRAINT `emails_agent_Id_fk` FOREIGN KEY (`AgentId`) REFERENCES `agent` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `emails`
--

LOCK TABLES `emails` WRITE;
/*!40000 ALTER TABLE `emails` DISABLE KEYS */;
/*!40000 ALTER TABLE `emails` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `phones`
--

DROP TABLE IF EXISTS `phones`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `phones` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `AgentId` int(11) DEFAULT NULL,
  `Phone` varchar(255) CHARACTER SET utf8 NOT NULL,
  PRIMARY KEY (`id`),
  KEY `phones_agent_Id_fk` (`AgentId`),
  CONSTRAINT `phones_agent_Id_fk` FOREIGN KEY (`AgentId`) REFERENCES `agent` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `phones`
--

LOCK TABLES `phones` WRITE;
/*!40000 ALTER TABLE `phones` DISABLE KEYS */;
/*!40000 ALTER TABLE `phones` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request`
--

DROP TABLE IF EXISTS `request`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Theme` varchar(255) CHARACTER SET utf8 NOT NULL,
  `Matter` varchar(255) CHARACTER SET utf8 NOT NULL,
  `ClientId` int(11) DEFAULT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `Phone` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `ResponsibleId` int(11) DEFAULT NULL,
  `State` smallint(6) DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `request_client_Id_fk` (`ClientId`),
  KEY `request_Responsible_Id_fk` (`ResponsibleId`),
  KEY `request_owner_Id_fk` (`OwnerId`),
  CONSTRAINT `request_client_Id_fk` FOREIGN KEY (`ClientId`) REFERENCES `client` (`Id`),
  CONSTRAINT `request_owner_Id_fk` FOREIGN KEY (`OwnerId`) REFERENCES `agent` (`Id`),
  CONSTRAINT `request_Responsible_Id_fk` FOREIGN KEY (`ResponsibleId`) REFERENCES `agent` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request`
--

LOCK TABLES `request` WRITE;
/*!40000 ALTER TABLE `request` DISABLE KEYS */;
INSERT INTO `request` VALUES (1,'Добавить колонку в отчете','В отчете необходима нвооя колонка с фотографией товара.',2,8,NULL,NULL,1,0),(2,'Сделать новый акт переоценки в другую валюту','Необходимо возможность формировать цены по кросс-курсу',2,8,NULL,NULL,1,0);
/*!40000 ALTER TABLE `request` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `request_message`
--

DROP TABLE IF EXISTS `request_message`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `request_message` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `RequestId` int(11) DEFAULT NULL,
  `AgentId` int(11) DEFAULT NULL,
  `MessageTime` datetime DEFAULT CURRENT_TIMESTAMP,
  `Body` varchar(1024) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `request_message_request_Id_fk` (`RequestId`),
  KEY `request_message_agent_Id_fk` (`AgentId`),
  CONSTRAINT `request_message_agent_Id_fk` FOREIGN KEY (`AgentId`) REFERENCES `agent` (`Id`),
  CONSTRAINT `request_message_request_Id_fk` FOREIGN KEY (`RequestId`) REFERENCES `request` (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `request_message`
--

LOCK TABLES `request_message` WRITE;
/*!40000 ALTER TABLE `request_message` DISABLE KEYS */;
/*!40000 ALTER TABLE `request_message` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-24 11:48:14
