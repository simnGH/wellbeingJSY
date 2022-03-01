CREATE TABLE `user` (
  `UserId` int NOT NULL AUTO_INCREMENT,
  `EmailAddress` varchar(150) NOT NULL,
  `PasswordHash` varchar(512) NOT NULL,
  `PasswordResetToken` varchar(36) NOT NULL,
  `PasswordResetTokenExpiry` datetime DEFAULT NULL,
  `EmailValidatedAt` datetime DEFAULT NULL,
  `FirstName` varchar(150) DEFAULT NULL,
  `Surname` varchar(150) DEFAULT NULL,
  `Age` int DEFAULT NULL,
  `BodyScore` int DEFAULT 0 NOT NULL,
  `MindScore` int DEFAULT 0 NOT NULL,
  `WealthScore` int DEFAULT 0 NOT NULL,
  `WorkScore` int DEFAULT 0 NOT NULL,
  `CreatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP,
  `UpdatedAt` timestamp NOT NULL DEFAULT CURRENT_TIMESTAMP ON UPDATE CURRENT_TIMESTAMP,
  PRIMARY KEY (`UserId`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;
