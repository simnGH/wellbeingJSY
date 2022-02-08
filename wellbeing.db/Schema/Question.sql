CREATE TABLE question
(
    QuestionId                INT NOT NULL AUTO_INCREMENT,
    QuestionText              VARCHAR(500) NOT NULL,
    MetricId                  INT NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (QuestionId),
    FOREIGN KEY (MetricId) REFERENCES metric(MetricId)
) ENGINE=innodb AUTO_INCREMENT=3000;
