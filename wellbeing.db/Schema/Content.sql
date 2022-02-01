CREATE TABLE `content` (
  `ContentId` int(11) NOT NULL AUTO_INCREMENT,
  `Link` varchar(150) NOT NULL,
  `Title` varchar(512) NOT NULL,
  `Overview` varchar(512) NOT NULL,
  `Img` varchar(512) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`ContentId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;