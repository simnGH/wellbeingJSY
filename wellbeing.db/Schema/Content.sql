CREATE TABLE `content` (
  `ContentId` int NOT NULL AUTO_INCREMENT,
  `Link` varchar(150) NOT NULL,
  `Title` varchar(512) NOT NULL,
  `Img` varchar(512) NOT NULL,
  `MetricId` int DEFAULT NULL,
  `Relevance` int,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ContentId`),
  KEY `MetricId` (`MetricId`),
  CONSTRAINT `content_ibfk_1` FOREIGN KEY (`MetricId`) REFERENCES `metric` (`MetricId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;