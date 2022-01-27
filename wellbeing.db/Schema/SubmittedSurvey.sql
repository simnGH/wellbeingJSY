CREATE TABLE submittedSurvey
(
    SubmittedSurveyId         INT NOT NULL AUTO_INCREMENT,
    UserId                    INT NOT NULL,
    SurveyId                  INT NOT NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (SubmittedSurveyId),
    FOREIGN KEY (UserId) REFERENCES user(UserId),
    FOREIGN KEY (SurveyId) REFERENCES survey(SurveyId)
) ENGINE=innodb AUTO_INCREMENT=5000;
