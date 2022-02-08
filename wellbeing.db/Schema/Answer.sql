CREATE TABLE answer
(
    AnswerId                  INT NOT NULL AUTO_INCREMENT,
    UserId                    INT NOT NULL,
    QuestionId                INT NOT NULL,
    Score                     INT NOT NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (AnswerId),
    FOREIGN KEY (UserId) REFERENCES user(UserId),
    FOREIGN KEY (QuestionId) REFERENCES question(QuestionId)
) ENGINE=innodb;