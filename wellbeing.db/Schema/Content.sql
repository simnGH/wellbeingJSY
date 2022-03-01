CREATE TABLE `content` (
  `ContentId` int(11) NOT NULL AUTO_INCREMENT,
  `Link` varchar(150) NOT NULL,
  `Title` varchar(512) NOT NULL,
  `Img` varchar(512) NOT NULL,
  `MetricId` int(11) NOT NULL,
  `Relevance` int(11) NOT NULL,
  `QuestionId` int(11) DEFAULT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ContentId`),
  KEY `MetricId` (`MetricId`),
  CONSTRAINT `content_ibfk_1` FOREIGN KEY (`MetricId`) REFERENCES `metric` (`MetricId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;