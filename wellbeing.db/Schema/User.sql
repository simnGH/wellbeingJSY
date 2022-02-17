CREATE TABLE user
(
    UserId                    INT NOT NULL AUTO_INCREMENT,
    EmailAddress              VARCHAR(150) NOT NULL,
    PasswordHash              VARCHAR(512) NOT NULL,
    PasswordResetToken        VARCHAR(36) NOT NULL,
    PasswordResetTokenExpiry  DATETIME NULL,
    EmailValidatedAt          DATETIME NULL,
    FirstName                 VARCHAR(150) NULL,
    LastName                  VARCHAR(150) NULL,
    Age                       INT NULL,
    MindScore                 INT NOT NULL,
    BodyScore                 INT NOT NULL,
    WealthScore               INT NOT NULL, 
    WorkScore                 INT NOT NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (UserId)
) ENGINE=innodb;
