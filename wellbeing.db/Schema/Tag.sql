CREATE TABLE tag
(
    TagId           INT NOT NULL AUTO_INCREMENT,
    TagName         VARCHAR(150) NOT NULL,

    CreatedAt       TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt       TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (TagId)
);