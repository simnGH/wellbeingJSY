CREATE TABLE `user` (
  `UserId` int(11) NOT NULL AUTO_INCREMENT,
  `EmailAddress` varchar(150) NOT NULL,
  `PasswordHash` varchar(512) NOT NULL,
  `PasswordResetToken` varchar(36) NOT NULL,
  `PasswordResetTokenExpiry` datetime DEFAULT NULL,
  `EmailValidatedAt` datetime DEFAULT NULL,
  `FirstName` varchar(150) NOT NULL,
  `Surname` varchar(150) NOT NULL,
  `Age` int(11) NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;
