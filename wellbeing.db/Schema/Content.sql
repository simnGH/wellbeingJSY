CREATE TABLE content
(
    ContentId       INT NOT NULL AUTO_INCREMENT,
    Link            VARCHAR(150) NOT NULL,
    Title           VARCHAR(512) NOT NULL,
    Overview        VARCHAR(512) NOT NULL,
    Img             VARCHAR(512) NOT NULL,

    CreatedAt       TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt       TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (ContentId)
);