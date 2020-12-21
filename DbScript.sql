CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) NOT NULL,
    `ProductVersion` varchar(32) NOT NULL,
    PRIMARY KEY (`MigrationId`)
);

CREATE TABLE `Orders` (
    `Id` varbinary(16) NOT NULL,
    `OrderNumber` int NOT NULL,
    `CounterpartyName` text NULL,
    `OrderDate` datetime NOT NULL,
    `AuthorId` varbinary(16) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Products` (
    `Id` varbinary(16) NOT NULL,
    `ProductNumber` int NOT NULL,
    `Name` text NULL,
    `Price` decimal(18, 2) NOT NULL,
    `Count` int NOT NULL,
    `OrderId` varbinary(16) NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Products_Orders_OrderId` FOREIGN KEY (`OrderId`) REFERENCES `Orders` (`Id`) ON DELETE SET NULL
);

CREATE TABLE `Subdivisions` (
    `Id` varbinary(16) NOT NULL,
    `Name` text NULL,
    `ManagerId` varbinary(16) NULL,
    PRIMARY KEY (`Id`)
);

CREATE TABLE `Employees` (
    `Id` varbinary(16) NOT NULL,
    `LastName` text NULL,
    `FirstName` text NULL,
    `Patronymic` text NULL,
    `DateOfBirth` datetime NOT NULL,
    `Gender` int NOT NULL,
    `SubdivisionId` varbinary(16) NULL,
    PRIMARY KEY (`Id`),
    CONSTRAINT `FK_Employees_Subdivisions_SubdivisionId` FOREIGN KEY (`SubdivisionId`) REFERENCES `Subdivisions` (`Id`) ON DELETE SET NULL
);

CREATE INDEX `IX_Employees_SubdivisionId` ON `Employees` (`SubdivisionId`);

CREATE INDEX `IX_Orders_AuthorId` ON `Orders` (`AuthorId`);

CREATE INDEX `IX_Products_OrderId` ON `Products` (`OrderId`);

CREATE INDEX `IX_Subdivisions_ManagerId` ON `Subdivisions` (`ManagerId`);

ALTER TABLE `Orders` ADD CONSTRAINT `FK_Orders_Employees_AuthorId` FOREIGN KEY (`AuthorId`) REFERENCES `Employees` (`Id`) ON DELETE SET NULL;

ALTER TABLE `Subdivisions` ADD CONSTRAINT `FK_Subdivisions_Employees_ManagerId` FOREIGN KEY (`ManagerId`) REFERENCES `Employees` (`Id`) ON DELETE SET NULL;

INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
VALUES ('20201221223322_InitialMigration', '3.1.1');

