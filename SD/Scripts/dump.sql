drop schema if exists 2x2CRM;

create SCHEMA 2x2CRM;

use `2x2CRM`;


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
  `Name` varchar(255) NOT NULL,
  `CompanyId` int(11) DEFAULT NULL,
  `Login` varchar(50) DEFAULT NULL,
  `Password` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `agent_client_Id_fk` (`CompanyId`),
  CONSTRAINT `agent_client_Id_fk` FOREIGN KEY (`CompanyId`) REFERENCES `company` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=10 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `agent`
--

LOCK TABLES `agent` WRITE;
/*!40000 ALTER TABLE `agent` DISABLE KEYS */;
INSERT INTO `agent` VALUES (1,'Paul',1,'b.paul4@gmail.com','P123'),(2,'Vladimur',1,NULL,NULL),(3,'Vadim',1,NULL,NULL),(4,'Alena',1,NULL,NULL),(5,'Sasha',1,NULL,NULL),(6,'Kate',1,NULL,NULL),(7,'Jane',1,NULL,NULL),(8,'Alena',2,NULL,NULL),(9,'Elena',2,NULL,NULL);
/*!40000 ALTER TABLE `agent` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `company`
--

DROP TABLE IF EXISTS `company`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `company` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Name` varchar(255) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=utf8;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `company`
--

LOCK TABLES `company` WRITE;
/*!40000 ALTER TABLE `company` DISABLE KEYS */;
INSERT INTO `company` VALUES (1,'Казначей'),(2,'МК');
/*!40000 ALTER TABLE `company` ENABLE KEYS */;
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
-- Table structure for table `issue`
--

DROP TABLE IF EXISTS `issue`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `issue` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `Topic` varchar(255) CHARACTER SET utf8 NOT NULL,
  `Matter` varchar(255) CHARACTER SET utf8 NOT NULL,
  `CompanyId` int(11) DEFAULT NULL,
  `OwnerId` int(11) DEFAULT NULL,
  `Phone` varchar(50) CHARACTER SET utf8 DEFAULT NULL,
  `Email` varchar(255) CHARACTER SET utf8 DEFAULT NULL,
  `ResponsibleId` int(11) DEFAULT NULL,
  `State` smallint(6) DEFAULT '0',
  PRIMARY KEY (`Id`),
  KEY `request_client_Id_fk` (`CompanyId`),
  KEY `request_Responsible_Id_fk` (`ResponsibleId`),
  KEY `request_owner_Id_fk` (`OwnerId`),
  CONSTRAINT `issue_Responsible_Id_fk` FOREIGN KEY (`ResponsibleId`) REFERENCES `agent` (`Id`),
  CONSTRAINT `issue_client_Id_fk` FOREIGN KEY (`CompanyId`) REFERENCES `company` (`Id`),
  CONSTRAINT `issue_owner_Id_fk` FOREIGN KEY (`OwnerId`) REFERENCES `agent` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issue`
--

LOCK TABLES `issue` WRITE;
/*!40000 ALTER TABLE `issue` DISABLE KEYS */;
INSERT INTO `issue` VALUES (1,'Добавить колонку в отчете','В отчете необходима нвооя колонка с фотографией товара.',2,8,NULL,NULL,1,0),(2,'Сделать новый акт переоценки в другую валюту','Необходимо возможность формировать цены по кросс-курсу',2,8,NULL,NULL,1,0);
/*!40000 ALTER TABLE `issue` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `issue_message`
--

DROP TABLE IF EXISTS `issue_message`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `issue_message` (
  `Id` int(11) NOT NULL AUTO_INCREMENT,
  `IssueId` int(11) DEFAULT NULL,
  `AgentId` int(11) DEFAULT NULL,
  `MessageTime` datetime DEFAULT CURRENT_TIMESTAMP,
  `Body` varchar(1024) CHARACTER SET utf8 DEFAULT NULL,
  PRIMARY KEY (`Id`),
  KEY `request_message_request_Id_fk` (`IssueId`),
  KEY `request_message_agent_Id_fk` (`AgentId`),
  CONSTRAINT `issue_message_request_Id_fk` FOREIGN KEY (`IssueId`) REFERENCES `issue` (`Id`),
  CONSTRAINT `issue_message_agent_Id_fk` FOREIGN KEY (`AgentId`) REFERENCES `agent` (`Id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `issue_message`
--

LOCK TABLES `issue_message` WRITE;
/*!40000 ALTER TABLE `issue_message` DISABLE KEYS */;
INSERT INTO `issue_message` VALUES (1,1,1,'2017-02-24 11:53:30','В какое место необходимо добавит колонку?');
/*!40000 ALTER TABLE `issue_message` ENABLE KEYS */;
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-02-26 16:29:33
