CREATE TABLE `answer` (
  `AnswerId` int NOT NULL AUTO_INCREMENT,
  `UserId` int NOT NULL,
  `QuestionId` int NOT NULL,
  `Score` varchar(512) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`AnswerId`),
  CONSTRAINT `user_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `question_ibfk_2` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`QuestionId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;