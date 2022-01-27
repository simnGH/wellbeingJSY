CREATE TABLE submittedQuestion
(
    SubmittedQuestionId       INT NOT NULL AUTO_INCREMENT,
    UserId                    INT NOT NULL,
    SurveyId                  INT NOT NULL,
    QuestionId                INT NOT NULL,
    Score                     INT NOT NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (SubmittedQuestionId),
    FOREIGN KEY (UserId) REFERENCES user(UserId),
    FOREIGN KEY (SurveyId) REFERENCES survey(SurveyId),
    FOREIGN KEY (QuestionId) REFERENCES question(QuestionId)
) ENGINE=innodb AUTO_INCREMENT=6000;