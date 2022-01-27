CREATE TABLE surveyQuestion
(
    SurveyQuestionId          INT NOT NULL AUTO_INCREMENT,
    SurveyId                  INT NOT NULL,
    QuestionId                INT NOT NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (SurveyQuestionId),
    FOREIGN KEY (SurveyId) REFERENCES survey(SurveyId),
    FOREIGN KEY (QuestionId) REFERENCES question(QuestionId)
) ENGINE=innodb AUTO_INCREMENT=4000;
