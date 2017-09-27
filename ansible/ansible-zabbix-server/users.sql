-- MySQL dump 10.15  Distrib 10.0.29-MariaDB, for debian-linux-gnu (x86_64)
--
-- Host: localhost    Database: localhost
-- ------------------------------------------------------
-- Server version	10.0.29-MariaDB-0ubuntu0.16.04.1

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users` (
  `userid` bigint(20) unsigned NOT NULL,
  `alias` varchar(100) COLLATE utf8_bin NOT NULL DEFAULT '',
  `name` varchar(100) COLLATE utf8_bin NOT NULL DEFAULT '',
  `surname` varchar(100) COLLATE utf8_bin NOT NULL DEFAULT '',
  `passwd` char(32) COLLATE utf8_bin NOT NULL DEFAULT '',
  `url` varchar(255) COLLATE utf8_bin NOT NULL DEFAULT '',
  `autologin` int(11) NOT NULL DEFAULT '0',
  `autologout` int(11) NOT NULL DEFAULT '900',
  `lang` varchar(5) COLLATE utf8_bin NOT NULL DEFAULT 'en_GB',
  `refresh` int(11) NOT NULL DEFAULT '30',
  `type` int(11) NOT NULL DEFAULT '1',
  `theme` varchar(128) COLLATE utf8_bin NOT NULL DEFAULT 'default',
  `attempt_failed` int(11) NOT NULL DEFAULT '0',
  `attempt_ip` varchar(39) COLLATE utf8_bin NOT NULL DEFAULT '',
  `attempt_clock` int(11) NOT NULL DEFAULT '0',
  `rows_per_page` int(11) NOT NULL DEFAULT '50',
  PRIMARY KEY (`userid`),
  UNIQUE KEY `users_1` (`alias`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'Admin','Zabbix','Administrator','9d33f3a3ffc907502d9e37faa623fa5d','',1,0,'en_GB',30,3,'default',2618,'178.159.234.95',1499930825,50),(2,'guest','','','d41d8cd98f00b204e9800998ecf8427e','',0,900,'en_GB',30,1,'default',0,'',0,50),(3,'it','IT','Admin','9d33f3a3ffc907502d9e37faa623fa5d','',1,0,'en_GB',30,3,'default',0,'98.169.64.25',1451966448,50),(4,'mastercard','','','8e66427897f7afe5238935fcd4ecd326','',1,0,'en_US',30,1,'default',0,'',0,50),(5,'zabbixweb','zabbix','web','2267ecd97970066d8c86f7f56b929f3d','',0,0,'en_GB',30,1,'default',0,'',0,50),(6,'slack','slack','alert','9d33f3a3ffc907502d9e37faa623fa5d','',0,0,'en_GB',30,1,'default',0,'',0,50),(7,'sjabri','Sumer','Jabri','fbae0024cfebfa3a1ebc8b20bf8a1ae0','',1,0,'en_US',30,3,'default',0,'98.169.64.141',1444073861,50),(8,'slack2','slack2','alert','9d33f3a3ffc907502d9e37faa623fa5d','',0,0,'en_GB',30,1,'default',0,'',0,50),(9,'apatalay','amol','patalay','07bbf751fcd6f78b2b29ab847674e03a','',1,0,'en_GB',30,3,'default',0,'117.221.63.186',1481274146,50),(11,'wael','wael','abdel-hamid','01b4ef0b10d702b993ef95cd12595f59','',1,0,'en_GB',30,3,'default',0,'',0,50),(12,'pguddeti','Pradeep','Guddetti','bd461f78e673761ccbf6f10ebd42c571','',1,0,'en_GB',30,3,'default',1,'183.82.98.95',1499925613,50),(13,'Crafter','Crafter','Software','857f71807e9c0ef8549939445badb79b','',0,0,'en_GB',30,1,'default',0,'',0,50),(14,'ndufour','Nicolas','Dufour','bd23e3348e22cbb904d5065492180b91','',1,0,'en_GB',30,3,'default',0,'73.33.103.172',1492599132,50),(17,'pbhagavathula','Pavan','Bhagavathula','ca03ade583915bfae31824026512a83c','',1,0,'en_GB',30,3,'default',0,'183.82.98.95',1478155949,50),(19,'karim.debs','Karim','Debs','d82461d699fd3eeebaf2959e614ac577','',1,0,'en_GB',30,1,'default',0,'173.8.11.75',1471872061,50),(20,'pbillakanti','Praveen','Billakanti','809febf9e045d3a69c29b48cbe3bd069','',1,0,'en_GB',30,3,'default',0,'',0,50),(22,'slack2_hmr_usr','Slack2_HMR','','5425647bbd6e5c2acdd73d8c101ed34e','',0,0,'en_GB',30,1,'default',0,'',0,50),(23,'slack_hmr_usr','Slack_HMR','Web','5425647bbd6e5c2acdd73d8c101ed34e','',0,0,'en_GB',30,1,'default',0,'',0,50),(24,'slack2_sargento_usr','Slack2_sargento','','a197e261a1d60d7f2e7103f07d67dbeb','',0,0,'en_GB',30,1,'default',0,'',0,50),(25,'slack2_aft_usr','Slack2_AFT','','1655a438fb2b973488447c2221ff0a7c','',0,0,'en_GB',30,1,'default',0,'',0,50),(26,'slack_aft_usr','Slack_AFT','','2941a3a6926c8f51c76a4ccd21c514b2','',0,0,'en_GB',30,1,'default',0,'',0,50),(27,'slack2_cimit_usr','Slack2_CIMIT','','bfca0e36975d13f5c5c914f279360dc3','',0,0,'en_GB',30,1,'default',0,'',0,50),(28,'slack_cimit_usr','Slack_CIMIT','Web','f261284e9e27ad83a37a79b073d94ba5','',0,0,'en_GB',30,1,'default',0,'',0,50),(29,'slack_isaca_usr','Slack_Isaca','Web','76a92aeac5261b7ea6e9525a3b1a8233','',0,0,'en_GB',30,1,'default',0,'',0,50),(30,'slack2_isaca_usr','Slack2_Isaca','','f68cd75228f0743f105ac7c98510f569','',0,0,'en_GB',30,1,'default',0,'',0,50),(31,'slack_ninesigma_usr','Slack_Ninesigma','Web','5d8106c0f59cdd100a0b75bcd6351a52','',0,0,'en_GB',30,1,'default',0,'',0,50),(32,'slack2_ninesigma_usr','Slack2_Ninesigma','','81e21941dc75150660539e27d491cba6','',0,0,'en_GB',30,1,'default',0,'',0,50),(33,'slack2_up_usr','Slac2_UP','','69bf713e378e44fe7fe4b27903e05f1d','',0,0,'en_GB',30,1,'default',0,'',0,50),(34,'slack_up_usr','Slack_UP','Web','909629a6f5b16d25a84a37efb572d239','',0,0,'en_GB',30,1,'default',0,'',0,50),(35,'slack_telx_usr','Slack_Telx','Web','f0a426d9a5bf1f2b4debbacdfc3d6394','',0,0,'en_GB',30,1,'default',0,'',0,50),(36,'slack2_telx_grp','Slack2_Telx','','e657e7cc3a2ddbe49ab43efd97a93071','',0,0,'en_GB',30,1,'default',0,'',0,50),(37,'slack_craftercloud_usr','Slack_CrafterCloud','Web','4c284736ab347486e203fd3a4510b37b','',0,0,'en_GB',30,1,'default',0,'',0,50),(38,'slack2_craftercloud_usr','Slack2_CrafterCloud','','9afaff11b2f46093ee7b58c68512ef06','',0,0,'en_GB',30,1,'default',0,'',0,50),(39,'slack_sargento_usr','Slack_Sargento','Web','8c93aea549d1c7e81eb1b157c2af9318','',0,0,'en_GB',30,1,'default',0,'',0,50),(41,'dnalanagula','Damodara','Nalanagula','c9249f5f158c77b689609ed45da92fe3','',1,0,'en_GB',30,3,'default',0,'183.82.98.95',1494843008,50),(42,'skondamalla','santosh','kondamalla','536000493c93e788057d61c4c584ce12','',1,0,'en_GB',30,3,'default',0,'',0,50),(43,'tbikbaev','Timur','Bikbaev','457cb51c34a8588a829e70cb87c09f45','',1,0,'en_GB',30,3,'default',0,'35.167.140.40',1500024966,50);
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `users_groups`
--

DROP TABLE IF EXISTS `users_groups`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `users_groups` (
  `id` bigint(20) unsigned NOT NULL,
  `usrgrpid` bigint(20) unsigned NOT NULL,
  `userid` bigint(20) unsigned NOT NULL,
  PRIMARY KEY (`id`),
  UNIQUE KEY `users_groups_1` (`usrgrpid`,`userid`),
  KEY `users_groups_2` (`userid`),
  CONSTRAINT `c_users_groups_1` FOREIGN KEY (`usrgrpid`) REFERENCES `usrgrp` (`usrgrpid`) ON DELETE CASCADE,
  CONSTRAINT `c_users_groups_2` FOREIGN KEY (`userid`) REFERENCES `users` (`userid`) ON DELETE CASCADE
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users_groups`
--

LOCK TABLES `users_groups` WRITE;
/*!40000 ALTER TABLE `users_groups` DISABLE KEYS */;
INSERT INTO `users_groups` VALUES (4,7,1),(5,7,3),(9,7,7),(12,7,9),(14,7,11),(15,7,12),(17,7,14),(20,7,17),(22,7,19),(23,7,20),(44,7,41),(45,7,42),(46,7,43),(2,8,2),(6,13,4),(7,14,5),(8,14,6),(11,15,8),(16,16,13),(25,17,22),(26,18,23),(27,19,24),(28,20,25),(29,21,26),(30,22,27),(31,23,28),(33,24,30),(32,25,29),(35,26,32),(34,27,31),(36,28,33),(37,29,34),(39,30,36),(38,31,35),(41,32,38),(40,33,37),(42,34,39);
/*!40000 ALTER TABLE `users_groups` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `usrgrp`
--

DROP TABLE IF EXISTS `usrgrp`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!40101 SET character_set_client = utf8 */;
CREATE TABLE `usrgrp` (
  `usrgrpid` bigint(20) unsigned NOT NULL,
  `name` varchar(64) COLLATE utf8_bin NOT NULL DEFAULT '',
  `gui_access` int(11) NOT NULL DEFAULT '0',
  `users_status` int(11) NOT NULL DEFAULT '0',
  `debug_mode` int(11) NOT NULL DEFAULT '0',
  PRIMARY KEY (`usrgrpid`),
  UNIQUE KEY `usrgrp_1` (`name`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_bin;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `usrgrp`
--

LOCK TABLES `usrgrp` WRITE;
/*!40000 ALTER TABLE `usrgrp` DISABLE KEYS */;
INSERT INTO `usrgrp` VALUES (7,'Zabbix administrators',0,0,0),(8,'Guests',0,1,0),(9,'Disabled',0,1,0),(11,'Enabled debug mode',0,0,1),(12,'No access to the frontend',2,0,0),(13,'Mastercard',0,0,0),(14,'Slack',0,0,0),(15,'Slack2',0,0,0),(16,'Crafter Software',0,0,0),(17,'slack2_hmr_grp',0,0,0),(18,'slack_hmr_grp',0,0,0),(19,'slack2_sargento_grp',0,0,0),(20,'slack2_aft_grp',0,0,0),(21,'slack_aft_grp',0,0,0),(22,'slack2_cimit_grp',0,0,0),(23,'slack_cimit_grp',0,0,0),(24,'slack2_isaca_grp',0,0,0),(25,'slack_isaca_grp',0,0,0),(26,'slack2_ninesigma_grp',0,0,0),(27,'slack_ninesigma_grp',0,0,0),(28,'slack2_up_grp',0,0,0),(29,'slack_up_grp',0,0,0),(30,'slack2_telx_grp',0,0,0),(31,'slack_telx_grp',0,0,0),(32,'slack2_craftercloud_grp',0,0,0),(33,'slack_craftercloud_grp',0,0,0),(34,'slack_sargento_grp',0,0,0);
/*!40000 ALTER TABLE `usrgrp` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2017-07-17  7:33:34
