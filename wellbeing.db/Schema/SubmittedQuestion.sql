CREATE TABLE `submittedQuestion` (
  `SubmittedQuestionId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `SurveyId` int(11) NOT NULL,
  `QuestionId` int(11) NOT NULL,
  `Score` int(11) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`SubmittedQuestionId`),
  KEY `UserId` (`UserId`),
  KEY `SurveyId` (`SurveyId`),
  KEY `QuestionId` (`QuestionId`),
  CONSTRAINT `submittedQuestion_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `submittedQuestion_ibfk_2` FOREIGN KEY (`SurveyId`) REFERENCES `survey` (`SurveyId`),
  CONSTRAINT `submittedQuestion_ibfk_3` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`QuestionId`)
) ENGINE=InnoDB AUTO_INCREMENT=6000 DEFAULT CHARSET=utf8mb4;