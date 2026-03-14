CREATE TABLE IF NOT EXISTS `__EFMigrationsHistory` (
    `MigrationId` varchar(150) CHARACTER SET utf8mb4 NOT NULL,
    `ProductVersion` varchar(32) CHARACTER SET utf8mb4 NOT NULL,
    CONSTRAINT `PK___EFMigrationsHistory` PRIMARY KEY (`MigrationId`)
) CHARACTER SET=utf8mb4;

START TRANSACTION;
DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    ALTER DATABASE CHARACTER SET utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    CREATE TABLE `tb_user_roles` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Name` longtext CHARACTER SET utf8mb4 NOT NULL,
        CONSTRAINT `PK_tb_user_roles` PRIMARY KEY (`Id`)
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    CREATE TABLE `tb_users` (
        `UserId` int NOT NULL AUTO_INCREMENT,
        `UserName` varchar(50) CHARACTER SET utf8mb4 NOT NULL,
        `Email` longtext CHARACTER SET utf8mb4 NOT NULL,
        `PasswordHash` varchar(256) CHARACTER SET utf8mb4 NOT NULL,
        `CreatedAt` datetime(6) NOT NULL,
        `IsActive` tinyint(1) NOT NULL DEFAULT TRUE,
        `RoleId` int NOT NULL,
        CONSTRAINT `PK_tb_users` PRIMARY KEY (`UserId`),
        CONSTRAINT `FK_tb_users_tb_user_roles_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `tb_user_roles` (`Id`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    CREATE TABLE `tb_tasks` (
        `Id` int NOT NULL AUTO_INCREMENT,
        `Title` longtext CHARACTER SET utf8mb4 NOT NULL,
        `Description` longtext CHARACTER SET utf8mb4 NULL,
        `Status` int NOT NULL,
        `Priority` int NOT NULL,
        `DueDate` datetime(6) NOT NULL,
        `CreatedAt` datetime(6) NOT NULL,
        `UserId` int NOT NULL,
        CONSTRAINT `PK_tb_tasks` PRIMARY KEY (`Id`),
        CONSTRAINT `FK_tb_tasks_tb_users_UserId` FOREIGN KEY (`UserId`) REFERENCES `tb_users` (`UserId`) ON DELETE CASCADE
    ) CHARACTER SET=utf8mb4;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    INSERT INTO `tb_user_roles` (`Id`, `Name`)
    VALUES (1, 'Admin');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    CREATE INDEX `IX_tb_tasks_UserId` ON `tb_tasks` (`UserId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    CREATE INDEX `IX_tb_users_RoleId` ON `tb_users` (`RoleId`);

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135046_firstdbmigration') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20260314135046_firstdbmigration', '9.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135450_roleDesc') THEN

    ALTER TABLE `tb_user_roles` ADD `Description` longtext CHARACTER SET utf8mb4 NULL;

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135450_roleDesc') THEN

    UPDATE `tb_user_roles` SET `Description` = NULL
    WHERE `Id` = 1;
    SELECT ROW_COUNT();


    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135450_roleDesc') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20260314135450_roleDesc', '9.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135751_rolecreatedDate') THEN

    DELETE FROM `tb_user_roles`
    WHERE `Id` = 1;
    SELECT ROW_COUNT();


    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135751_rolecreatedDate') THEN

    ALTER TABLE `tb_user_roles` ADD `CreatedDate` datetime(6) NOT NULL DEFAULT '0001-01-01 00:00:00';

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314135751_rolecreatedDate') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20260314135751_rolecreatedDate', '9.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314141056_defaultvalues') THEN

    INSERT INTO `tb_user_roles` (`Id`, `CreatedDate`, `Description`, `Name`)
    VALUES (1, TIMESTAMP '2026-03-14 19:40:56', 'Admin for Task Manager', 'Admin'),
    (2, TIMESTAMP '2026-03-14 19:40:56', 'User for Task Manager', 'User');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

DROP PROCEDURE IF EXISTS MigrationsScript;
DELIMITER //
CREATE PROCEDURE MigrationsScript()
BEGIN
    IF NOT EXISTS(SELECT 1 FROM `__EFMigrationsHistory` WHERE `MigrationId` = '20260314141056_defaultvalues') THEN

    INSERT INTO `__EFMigrationsHistory` (`MigrationId`, `ProductVersion`)
    VALUES ('20260314141056_defaultvalues', '9.0.14');

    END IF;
END //
DELIMITER ;
CALL MigrationsScript();
DROP PROCEDURE MigrationsScript;

COMMIT;

