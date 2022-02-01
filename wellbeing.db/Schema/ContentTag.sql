CREATE TABLE `contentTag` (
  `ContentTagId` int(11) NOT NULL AUTO_INCREMENT,
  `ContentId` int(11) NOT NULL,
  `TagId` int(11) NOT NULL,
  `Relevance` int(11) NOT NULL,
  PRIMARY KEY (`ContentTagId`),
  KEY `ContentId` (`ContentId`),
  KEY `TagId` (`TagId`),
  CONSTRAINT `contentTag_ibfk_1` FOREIGN KEY (`ContentId`) REFERENCES `content` (`ContentId`),
  CONSTRAINT `contentTag_ibfk_2` FOREIGN KEY (`TagId`) REFERENCES `tag` (`TagId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;