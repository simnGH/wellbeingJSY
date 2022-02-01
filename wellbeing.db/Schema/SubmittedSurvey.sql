CREATE TABLE `submittedSurvey` (
  `SubmittedSurveyId` int(11) NOT NULL AUTO_INCREMENT,
  `UserId` int(11) NOT NULL,
  `SurveyId` int(11) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`SubmittedSurveyId`),
  KEY `UserId` (`UserId`),
  KEY `SurveyId` (`SurveyId`),
  CONSTRAINT `submittedSurvey_ibfk_1` FOREIGN KEY (`UserId`) REFERENCES `user` (`UserId`),
  CONSTRAINT `submittedSurvey_ibfk_2` FOREIGN KEY (`SurveyId`) REFERENCES `survey` (`SurveyId`)
) ENGINE=InnoDB AUTO_INCREMENT=5000 DEFAULT CHARSET=utf8mb4;
