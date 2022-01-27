CREATE TABLE contentTag
(
    ContentTagId           INT NOT NULL AUTO_INCREMENT,
    ContentId              INT NOT NULL,
    TagId                  INT NOT NULL,
    Relevance              INT NOT NULL,
    
    PRIMARY KEY (ContentTagId),
    FOREIGN KEY (ContentId) REFERENCES content(ContentId),
    FOREIGN KEY (TagId) REFERENCES tag(TagId)

);