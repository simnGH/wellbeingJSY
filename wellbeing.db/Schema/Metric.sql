CREATE TABLE metric
(
    MetricId                  INT NOT NULL AUTO_INCREMENT,
    MetricName                VARCHAR(100) NOT NULL,

    CreatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP,
    UpdatedAt                 TIMESTAMP NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
    
    PRIMARY KEY (MetricId)
) ENGINE=innodb;
