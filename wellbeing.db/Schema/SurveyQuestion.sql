CREATE TABLE `surveyQuestion` (
  `SurveyQuestionId` int(11) NOT NULL AUTO_INCREMENT,
  `SurveyId` int(11) NOT NULL,
  `QuestionId` int(11) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`SurveyQuestionId`),
  KEY `SurveyId` (`SurveyId`),
  KEY `QuestionId` (`QuestionId`),
  CONSTRAINT `surveyQuestion_ibfk_1` FOREIGN KEY (`SurveyId`) REFERENCES `survey` (`SurveyId`),
  CONSTRAINT `surveyQuestion_ibfk_2` FOREIGN KEY (`QuestionId`) REFERENCES `question` (`QuestionId`)
) ENGINE=InnoDB AUTO_INCREMENT=4000 DEFAULT CHARSET=utf8mb4;
