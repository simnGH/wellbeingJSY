CREATE TABLE user
(
    UserId                    INT NOT NULL AUTO_INCREMENT,
    EmailAddress              VARCHAR(150) NOT NULL,
    PasswordHash              VARCHAR(512) NOT NULL,
    PasswordResetToken        VARCHAR(36) NOT NULL,
    PasswordResetTokenExpiry  DATETIME NULL,
    EmailValidatedAt          DATETIME NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (UserId)
) ENGINE=innodb;
