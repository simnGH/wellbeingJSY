CREATE TABLE `answer` (
  `AnswerId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `QuestionId` int(11) NOT NULL,
  `Score` int(11) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`AnswerId`),
  KEY `UserId` (`UserId`),
  KEY `QuestionId` (`QuestionId`),
  CONSTRAINT `answer_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `answer_ibfk_2` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`QuestionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;