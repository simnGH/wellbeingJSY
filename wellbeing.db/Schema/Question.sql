CREATE TABLE `question` (
  `QuestionId` int NOT NULL AUTO_INCREMENT,
  `QuestionText` varchar(500) NOT NULL,
  `MetricId` int NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`QuestionId`),
  KEY `MetricId` (`MetricId`),
  CONSTRAINT `question_ibfk_1` FOREIGN KEY (`MetricId`) REFERENCES `metric` (`MetricId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
