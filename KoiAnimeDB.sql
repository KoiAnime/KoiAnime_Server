/*
SQLyog Ultimate
MySQL - 5.7.21-log : Database - koianime
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
/*Table structure for table `account` */

CREATE TABLE `account` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `email` varchar(255) NOT NULL,
  `account_start_date` datetime NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `account_viewed_title` */

CREATE TABLE `account_viewed_title` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_account` int(11) NOT NULL,
  `id_title` int(11) NOT NULL,
  PRIMARY KEY (`id`,`id_account`,`id_title`),
  KEY `account_id_viewed_title_fk` (`id_account`),
  KEY `title_id_viewed_title_fk` (`id_title`),
  CONSTRAINT `account_id_viewed_title_fk` FOREIGN KEY (`id_account`) REFERENCES `account` (`id`),
  CONSTRAINT `title_id_viewed_title_fk` FOREIGN KEY (`id_title`) REFERENCES `title` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `account_viewed_title_episode` */

CREATE TABLE `account_viewed_title_episode` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `account_viewed_titles_id` int(11) DEFAULT NULL,
  `account_viewed_titles_episode_id` int(11) DEFAULT NULL,
  PRIMARY KEY (`id`),
  KEY `account_viewed_title_episode_id_fk` (`account_viewed_titles_episode_id`),
  KEY `account_viewed_title_id_fk` (`account_viewed_titles_id`),
  CONSTRAINT `account_viewed_title_episode_id_fk` FOREIGN KEY (`account_viewed_titles_episode_id`) REFERENCES `title_espisode` (`id`),
  CONSTRAINT `account_viewed_title_id_fk` FOREIGN KEY (`account_viewed_titles_id`) REFERENCES `account_viewed_title` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `title` */

CREATE TABLE `title` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `title_name` varchar(255) NOT NULL,
  `title_description` varchar(255) NOT NULL,
  `title_category` int(2) NOT NULL,
  `title_start_time` datetime NOT NULL,
  `title_number_chapters` int(11) NOT NULL,
  `title_state` int(1) NOT NULL,
  `title_views` int(11) NOT NULL,
  `title_cover_img` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `title_category` (`title_category`),
  CONSTRAINT `title_ibfk_1` FOREIGN KEY (`title_category`) REFERENCES `title_category` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `title_category` */

CREATE TABLE `title_category` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `category_name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=2 DEFAULT CHARSET=utf8;

/*Table structure for table `title_espisode` */

CREATE TABLE `title_espisode` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `id_title` int(11) NOT NULL,
  `id_season` int(2) NOT NULL,
  `number_episode` int(4) NOT NULL,
  `episode_link` varchar(255) NOT NULL,
  PRIMARY KEY (`id`),
  KEY `season_id_episode_fk` (`id_season`),
  KEY `title_id_episode_fk` (`id_title`),
  CONSTRAINT `season_id_episode_fk` FOREIGN KEY (`id_season`) REFERENCES `title_season` (`id`),
  CONSTRAINT `title_id_episode_fk` FOREIGN KEY (`id_title`) REFERENCES `title` (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*Table structure for table `title_season` */

CREATE TABLE `title_season` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `season_number` int(3) NOT NULL,
  `season_name` varchar(255) NOT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
