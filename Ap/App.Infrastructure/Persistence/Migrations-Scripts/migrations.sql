IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20210703182036_Init')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20210703182036_Init', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040324_InitLogTables')
BEGIN
    CREATE TABLE [ApiAuditLog] (
        [Id] bigint NOT NULL IDENTITY,
        [Account] nvarchar(64) NULL,
        [Name] nvarchar(32) NULL,
        [SourceIp] varchar(128) NULL,
        [HttpMethod] varchar(16) NULL,
        [RequestPath] varchar(512) NULL,
        [RequestQueryString] nvarchar(max) NULL,
        [RequestHeaders] nvarchar(max) NULL,
        [ResponseStatusCode] int NOT NULL,
        [RequestBody] nvarchar(max) NULL,
        [ResponseBody] nvarchar(max) NULL,
        [TimeElapsed] bigint NOT NULL,
        [HandledId] uniqueidentifier NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GetDate()),
        [Creator] varchar(32) NULL,
        [ModifiedAt] datetime2 NULL DEFAULT (GetDate()),
        [Modifier] varchar(32) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_ApiAuditLog] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'API 系統操作紀錄';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Id';
    SET @description = N'操作人員帳號';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Account';
    SET @description = N'操作人員姓名';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Name';
    SET @description = N'來源 IP';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'SourceIp';
    SET @description = N'請求 Method';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'HttpMethod';
    SET @description = N'請求網址路徑';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestPath';
    SET @description = N'請求網址參數';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestQueryString';
    SET @description = N'請求網址 headers';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestHeaders';
    SET @description = N'回傳 http 狀態碼';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'ResponseStatusCode';
    SET @description = N'請求資料';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestBody';
    SET @description = N'回應資料';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'ResponseBody';
    SET @description = N'執行時間(ms)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'TimeElapsed';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'CreatedAt';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Creator';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'ModifiedAt';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Modifier';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040324_InitLogTables')
BEGIN
    CREATE TABLE [ExceptionLog] (
        [Id] bigint NOT NULL IDENTITY,
        [MachineName] varchar(64) NULL,
        [Message] nvarchar(1024) NULL,
        [Source] nvarchar(1024) NULL,
        [StackTrace] nvarchar(max) NULL,
        [ExtraData] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [CreatedAt] datetime2 NOT NULL DEFAULT (GetDate()),
        [Creator] varchar(32) NULL,
        [ModifiedAt] datetime2 NULL DEFAULT (GetDate()),
        [Modifier] varchar(32) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_ExceptionLog] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'AP 錯誤紀錄';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Id';
    SET @description = N'MachineName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'MachineName';
    SET @description = N'Message';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Message';
    SET @description = N'Source';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Source';
    SET @description = N'StackTrace';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'StackTrace';
    SET @description = N'ExtraData';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'ExtraData';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'CreatedAt';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Creator';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'ModifiedAt';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Modifier';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040324_InitLogTables')
BEGIN
    CREATE INDEX [IX_ApiAuditLog_CreatedAt_Creator_HandledId] ON [ApiAuditLog] ([CreatedAt], [Creator], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040324_InitLogTables')
BEGIN
    CREATE INDEX [IX_ApiAuditLog_HandledId_Account_Name_HttpMethod_SourceIp_RequestPath_ResponseStatusCode] ON [ApiAuditLog] ([HandledId], [Account], [Name], [HttpMethod], [SourceIp], [RequestPath], [ResponseStatusCode]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040324_InitLogTables')
BEGIN
    CREATE INDEX [IX_ExceptionLog_CreatedAt_Creator_HandledId] ON [ExceptionLog] ([CreatedAt], [Creator], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040324_InitLogTables')
BEGIN
    CREATE INDEX [IX_ExceptionLog_MachineName] ON [ExceptionLog] ([MachineName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040324_InitLogTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220910040324_InitLogTables', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_Applications] (
        [ApplicationName] nvarchar(256) NOT NULL,
        [LoweredApplicationName] nvarchar(256) NOT NULL,
        [ApplicationId] uniqueidentifier NOT NULL,
        [Description] nvarchar(256) NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ApplicationName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Applications', 'COLUMN', N'ApplicationName';
    SET @description = N'LoweredApplicationName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Applications', 'COLUMN', N'LoweredApplicationName';
    SET @description = N'ApplicationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Applications', 'COLUMN', N'ApplicationId';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Applications', 'COLUMN', N'Description';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_Membership] (
        [ApplicationId] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [Password] nvarchar(128) NOT NULL,
        [PasswordFormat] int NOT NULL,
        [PasswordSalt] nvarchar(128) NOT NULL,
        [MobilePIN] nvarchar(16) NULL,
        [Email] nvarchar(256) NULL,
        [LoweredEmail] nvarchar(256) NULL,
        [PasswordQuestion] nvarchar(256) NULL,
        [PasswordAnswer] nvarchar(128) NULL,
        [IsApproved] bit NOT NULL,
        [IsLockedOut] bit NOT NULL,
        [CreateDate] datetime NOT NULL,
        [LastLoginDate] datetime NOT NULL,
        [LastPasswordChangedDate] datetime NOT NULL,
        [LastLockoutDate] datetime NOT NULL,
        [FailedPasswordAttemptCount] int NOT NULL,
        [FailedPasswordAttemptWindowStart] datetime NOT NULL,
        [FailedPasswordAnswerAttemptCount] int NOT NULL,
        [FailedPasswordAnswerAttemptWindowStart] datetime NOT NULL,
        [Comment] ntext NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ApplicationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'ApplicationId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'UserId';
    SET @description = N'Password';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'Password';
    SET @description = N'PasswordFormat';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'PasswordFormat';
    SET @description = N'PasswordSalt';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'PasswordSalt';
    SET @description = N'MobilePin';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'MobilePIN';
    SET @description = N'Email';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'Email';
    SET @description = N'LoweredEmail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'LoweredEmail';
    SET @description = N'PasswordQuestion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'PasswordQuestion';
    SET @description = N'PasswordAnswer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'PasswordAnswer';
    SET @description = N'IsApproved';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'IsApproved';
    SET @description = N'IsLockedOut';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'IsLockedOut';
    SET @description = N'CreateDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'CreateDate';
    SET @description = N'LastLoginDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'LastLoginDate';
    SET @description = N'LastPasswordChangedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'LastPasswordChangedDate';
    SET @description = N'LastLockoutDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'LastLockoutDate';
    SET @description = N'FailedPasswordAttemptCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'FailedPasswordAttemptCount';
    SET @description = N'FailedPasswordAttemptWindowStart';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'FailedPasswordAttemptWindowStart';
    SET @description = N'FailedPasswordAnswerAttemptCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'FailedPasswordAnswerAttemptCount';
    SET @description = N'FailedPasswordAnswerAttemptWindowStart';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'FailedPasswordAnswerAttemptWindowStart';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Membership', 'COLUMN', N'Comment';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_Paths] (
        [ApplicationId] uniqueidentifier NOT NULL,
        [PathId] uniqueidentifier NOT NULL,
        [Path] nvarchar(256) NOT NULL,
        [LoweredPath] nvarchar(256) NOT NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ApplicationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Paths', 'COLUMN', N'ApplicationId';
    SET @description = N'PathId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Paths', 'COLUMN', N'PathId';
    SET @description = N'Path';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Paths', 'COLUMN', N'Path';
    SET @description = N'LoweredPath';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Paths', 'COLUMN', N'LoweredPath';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_PersonalizationAllUsers] (
        [PathId] uniqueidentifier NOT NULL,
        [PageSettings] image NOT NULL,
        [LastUpdatedDate] datetime NOT NULL,
        CONSTRAINT [PK__aspnet_P__CD67DC596EC0713C] PRIMARY KEY ([PathId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'PathId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationAllUsers', 'COLUMN', N'PathId';
    SET @description = N'PageSettings';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationAllUsers', 'COLUMN', N'PageSettings';
    SET @description = N'LastUpdatedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationAllUsers', 'COLUMN', N'LastUpdatedDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_PersonalizationPerUser] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [PathId] uniqueidentifier NULL,
        [UserId] uniqueidentifier NULL,
        [PageSettings] image NOT NULL,
        [LastUpdatedDate] datetime NOT NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationPerUser', 'COLUMN', N'Id';
    SET @description = N'PathId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationPerUser', 'COLUMN', N'PathId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationPerUser', 'COLUMN', N'UserId';
    SET @description = N'PageSettings';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationPerUser', 'COLUMN', N'PageSettings';
    SET @description = N'LastUpdatedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_PersonalizationPerUser', 'COLUMN', N'LastUpdatedDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_Profile] (
        [UserId] uniqueidentifier NOT NULL,
        [PropertyNames] ntext NOT NULL,
        [PropertyValuesString] ntext NOT NULL,
        [PropertyValuesBinary] image NOT NULL,
        [LastUpdatedDate] datetime NOT NULL,
        CONSTRAINT [PK__aspnet_P__1788CC4C44CA3770] PRIMARY KEY ([UserId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Profile', 'COLUMN', N'UserId';
    SET @description = N'PropertyNames';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Profile', 'COLUMN', N'PropertyNames';
    SET @description = N'PropertyValuesString';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Profile', 'COLUMN', N'PropertyValuesString';
    SET @description = N'PropertyValuesBinary';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Profile', 'COLUMN', N'PropertyValuesBinary';
    SET @description = N'LastUpdatedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Profile', 'COLUMN', N'LastUpdatedDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_Roles] (
        [ApplicationId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        [RoleName] nvarchar(256) NOT NULL,
        [LoweredRoleName] nvarchar(256) NOT NULL,
        [Description] nvarchar(256) NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ApplicationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Roles', 'COLUMN', N'ApplicationId';
    SET @description = N'RoleId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Roles', 'COLUMN', N'RoleId';
    SET @description = N'RoleName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Roles', 'COLUMN', N'RoleName';
    SET @description = N'LoweredRoleName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Roles', 'COLUMN', N'LoweredRoleName';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Roles', 'COLUMN', N'Description';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_SchemaVersions] (
        [Feature] nvarchar(128) NOT NULL,
        [CompatibleSchemaVersion] nvarchar(128) NOT NULL,
        [IsCurrentVersion] bit NOT NULL,
        CONSTRAINT [PK__aspnet_S__5A1E6BC12180FB33] PRIMARY KEY ([Feature], [CompatibleSchemaVersion])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Feature';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_SchemaVersions', 'COLUMN', N'Feature';
    SET @description = N'CompatibleSchemaVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_SchemaVersions', 'COLUMN', N'CompatibleSchemaVersion';
    SET @description = N'IsCurrentVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_SchemaVersions', 'COLUMN', N'IsCurrentVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_Users] (
        [ApplicationId] uniqueidentifier NOT NULL,
        [UserId] uniqueidentifier NOT NULL,
        [UserName] nvarchar(256) NOT NULL,
        [LoweredUserName] nvarchar(256) NOT NULL,
        [MobileAlias] nvarchar(16) NULL,
        [IsAnonymous] bit NOT NULL,
        [LastActivityDate] datetime NOT NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ApplicationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Users', 'COLUMN', N'ApplicationId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Users', 'COLUMN', N'UserId';
    SET @description = N'UserName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Users', 'COLUMN', N'UserName';
    SET @description = N'LoweredUserName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Users', 'COLUMN', N'LoweredUserName';
    SET @description = N'MobileAlias';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Users', 'COLUMN', N'MobileAlias';
    SET @description = N'IsAnonymous';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Users', 'COLUMN', N'IsAnonymous';
    SET @description = N'LastActivityDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_Users', 'COLUMN', N'LastActivityDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_UsersInRoles] (
        [UserId] uniqueidentifier NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK__aspnet_U__AF2760AD55F4C372] PRIMARY KEY ([UserId], [RoleId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_UsersInRoles', 'COLUMN', N'UserId';
    SET @description = N'RoleId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_UsersInRoles', 'COLUMN', N'RoleId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [aspnet_WebEvent_Events] (
        [EventId] char(32) NOT NULL,
        [EventTimeUtc] datetime NOT NULL,
        [EventTime] datetime NOT NULL,
        [EventType] nvarchar(256) NOT NULL,
        [EventSequence] decimal(19,0) NOT NULL,
        [EventOccurrence] decimal(19,0) NOT NULL,
        [EventCode] int NOT NULL,
        [EventDetailCode] int NOT NULL,
        [Message] nvarchar(1024) NULL,
        [ApplicationPath] nvarchar(256) NULL,
        [ApplicationVirtualPath] nvarchar(256) NULL,
        [MachineName] nvarchar(256) NOT NULL,
        [RequestUrl] nvarchar(1024) NULL,
        [ExceptionType] nvarchar(256) NULL,
        [Details] ntext NULL,
        CONSTRAINT [PK__aspnet_W__7944C810078C1F06] PRIMARY KEY ([EventId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'EventId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventId';
    SET @description = N'EventTimeUtc';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventTimeUtc';
    SET @description = N'EventTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventTime';
    SET @description = N'EventType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventType';
    SET @description = N'EventSequence';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventSequence';
    SET @description = N'EventOccurrence';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventOccurrence';
    SET @description = N'EventCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventCode';
    SET @description = N'EventDetailCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'EventDetailCode';
    SET @description = N'Message';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'Message';
    SET @description = N'ApplicationPath';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'ApplicationPath';
    SET @description = N'ApplicationVirtualPath';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'ApplicationVirtualPath';
    SET @description = N'MachineName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'MachineName';
    SET @description = N'RequestUrl';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'RequestUrl';
    SET @description = N'ExceptionType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'ExceptionType';
    SET @description = N'Details';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'aspnet_WebEvent_Events', 'COLUMN', N'Details';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [ErrCancel] (
        [Idn] varchar(20) NOT NULL,
        CONSTRAINT [PK_ErrCancel] PRIMARY KEY ([Idn])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Idn';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ErrCancel', 'COLUMN', N'Idn';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ACTIVITY] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        [Name] nvarchar(255) NOT NULL,
        [DateStart] datetime NOT NULL,
        [DateEnd] datetime NOT NULL,
        [DateSignUpDue] datetime NOT NULL,
        [FilePath] nvarchar(500) NULL,
        [TargetRole] nvarchar(50) NULL,
        [IsNeedRecruit] bit NOT NULL,
        [IsLunch] bit NOT NULL,
        [IsDinner] bit NOT NULL,
        [Description] nvarchar(max) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_ACTIVITY] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'PortalId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'OrgId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'Name';
    SET @description = N'DateStart';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'DateStart';
    SET @description = N'DateEnd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'DateEnd';
    SET @description = N'DateSignUpDue';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'DateSignUpDue';
    SET @description = N'FilePath';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'FilePath';
    SET @description = N'TargetRole';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'TargetRole';
    SET @description = N'IsNeedRecruit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'IsNeedRecruit';
    SET @description = N'IsLunch';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'IsLunch';
    SET @description = N'IsDinner';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'IsDinner';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'Description';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ACTIVITY_WORK] (
        [Id] int NOT NULL IDENTITY,
        [ActivityId] int NOT NULL,
        [Name] nvarchar(255) NOT NULL,
        [Date] datetime NOT NULL,
        [TimeStart] nvarchar(50) NULL,
        [TimeEnd] nvarchar(50) NULL,
        [MinisterRequired] nvarchar(500) NULL,
        [MaleWanted] int NOT NULL,
        [FemaleWanted] int NOT NULL,
        [IsTeam] bit NOT NULL,
        [IsNeedRecruit] bit NOT NULL,
        [TargetMinisterId] int NULL,
        [TargetRole] nvarchar(50) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_ACTIVITY_WORK] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'Id';
    SET @description = N'ActivityId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'ActivityId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'Name';
    SET @description = N'Date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'Date';
    SET @description = N'TimeStart';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'TimeStart';
    SET @description = N'TimeEnd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'TimeEnd';
    SET @description = N'MinisterRequired';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'MinisterRequired';
    SET @description = N'MaleWanted';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'MaleWanted';
    SET @description = N'FemaleWanted';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'FemaleWanted';
    SET @description = N'IsTeam';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'IsTeam';
    SET @description = N'IsNeedRecruit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'IsNeedRecruit';
    SET @description = N'TargetMinisterId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'TargetMinisterId';
    SET @description = N'TargetRole';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'TargetRole';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ACTIVITY_WORK_SHARE] (
        [WorkId] int NOT NULL,
        [AreaId] int NOT NULL,
        [AreaName] nvarchar(50) NOT NULL,
        [MaleWanted] int NOT NULL,
        [FemaleWanted] int NOT NULL,
        CONSTRAINT [PK_MOD_ACTIVITY_WORK_SHARE_1] PRIMARY KEY ([WorkId], [AreaId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'WorkId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SHARE', 'COLUMN', N'WorkId';
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SHARE', 'COLUMN', N'AreaId';
    SET @description = N'AreaName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SHARE', 'COLUMN', N'AreaName';
    SET @description = N'MaleWanted';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SHARE', 'COLUMN', N'MaleWanted';
    SET @description = N'FemaleWanted';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SHARE', 'COLUMN', N'FemaleWanted';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ACTIVITY_WORK_SIGNUP] (
        [WorkId] int NOT NULL,
        [AreaId] int NOT NULL,
        [GroupId] int NOT NULL,
        [MemberId] int NOT NULL,
        [GroupName] nvarchar(50) NOT NULL,
        [MemberName] nvarchar(255) NOT NULL,
        [Gender] char(1) NOT NULL,
        [TeamNo] int NULL,
        [RealTeamNo] int NULL,
        [Comment] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_ACTIVITY_WORK_SIGNUP] PRIMARY KEY ([WorkId], [AreaId], [GroupId], [MemberId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'WorkId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'WorkId';
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'AreaId';
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'GroupId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'MemberId';
    SET @description = N'GroupName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'GroupName';
    SET @description = N'MemberName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'MemberName';
    SET @description = N'Gender';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'Gender';
    SET @description = N'TeamNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'TeamNo';
    SET @description = N'RealTeamNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'RealTeamNo';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ACTIVITY_WORK_SIGNUP', 'COLUMN', N'Comment';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_AREA] (
        [Id] int NOT NULL IDENTITY,
        [OId] int NULL,
        [OrgId] int NULL,
        [DepId] int NULL,
        [Name] nvarchar(50) NOT NULL,
        [Code] varchar(20) NULL,
        [LeaderId] int NULL,
        [LeaderIDNumber] varchar(20) NOT NULL,
        [Leader2Id] int NULL,
        [Leader2IDNumber] varchar(20) NULL,
        [Leader3Id] int NULL,
        [Leader3IDNumber] varchar(20) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_AREA] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Id';
    SET @description = N'Oid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'OId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'OrgId';
    SET @description = N'DepId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'DepId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Name';
    SET @description = N'Code';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Code';
    SET @description = N'LeaderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'LeaderId';
    SET @description = N'LeaderIdnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'LeaderIDNumber';
    SET @description = N'Leader2Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Leader2Id';
    SET @description = N'Leader2Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Leader2IDNumber';
    SET @description = N'Leader3Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Leader3Id';
    SET @description = N'Leader3Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Leader3IDNumber';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREA', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_AREALEADER] (
        [AreaId] int NOT NULL,
        [MemberId] int NOT NULL,
        CONSTRAINT [PK_MOD_AREALEADER] PRIMARY KEY ([AreaId], [MemberId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREALEADER', 'COLUMN', N'AreaId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREALEADER', 'COLUMN', N'MemberId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_AREASUPERVISOR] (
        [AreaId] int NOT NULL,
        [MemberId] int NOT NULL,
        CONSTRAINT [PK_MOD_AREASUPERVISOR] PRIMARY KEY ([AreaId], [MemberId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREASUPERVISOR', 'COLUMN', N'AreaId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_AREASUPERVISOR', 'COLUMN', N'MemberId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CAMPAIGN] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] nvarchar(50) NOT NULL,
        [CategoryCd] varchar(20) NOT NULL,
        [No] int NOT NULL,
        [DateStart] datetime NOT NULL,
        [DateEnd] datetime NULL,
        [StatusCd] varchar(20) NOT NULL,
        [Comment] nvarchar(max) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_CAMPAIGN] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'Id';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'Name';
    SET @description = N'CategoryCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'CategoryCd';
    SET @description = N'No';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'No';
    SET @description = N'DateStart';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'DateStart';
    SET @description = N'DateEnd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'DateEnd';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CAMPAIGN_MEMBER] (
        [MemberId] int NOT NULL,
        [CampaignId] uniqueidentifier NOT NULL,
        [StatusCd] varchar(20) NULL,
        [IsRollCall] bit NOT NULL,
        [Comment] nvarchar(max) NULL,
        [DateCreate] datetime NULL,
        CONSTRAINT [PK_MOD_CAMPAIGN_MEMBER] PRIMARY KEY ([MemberId], [CampaignId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_MEMBER', 'COLUMN', N'MemberId';
    SET @description = N'CampaignId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_MEMBER', 'COLUMN', N'CampaignId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_MEMBER', 'COLUMN', N'StatusCd';
    SET @description = N'IsRollCall';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_MEMBER', 'COLUMN', N'IsRollCall';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_MEMBER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_MEMBER', 'COLUMN', N'DateCreate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CAMPAIGN_SPDAY] (
        [Id] int NOT NULL IDENTITY,
        [CampaignId] uniqueidentifier NULL,
        [Name] nvarchar(50) NOT NULL,
        [Date] datetime NOT NULL,
        CONSTRAINT [PK_MOD_CAMPAIGN_SPDAY] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_SPDAY', 'COLUMN', N'Id';
    SET @description = N'CampaignId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_SPDAY', 'COLUMN', N'CampaignId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_SPDAY', 'COLUMN', N'Name';
    SET @description = N'Date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAMPAIGN_SPDAY', 'COLUMN', N'Date';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CAREER] (
        [Id] int NOT NULL IDENTITY,
        [Career] nvarchar(50) NULL,
        [Description] nvarchar(max) NULL,
        CONSTRAINT [PK_MOD_CAREER] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAREER', 'COLUMN', N'Id';
    SET @description = N'Career';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAREER', 'COLUMN', N'Career';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CAREER', 'COLUMN', N'Description';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CLASS] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        [CategoryId] int NOT NULL,
        [CategoryCode] varchar(20) NOT NULL,
        [CategoryName] nvarchar(255) NOT NULL,
        [LessionId] int NOT NULL,
        [LessionCode] varchar(20) NOT NULL,
        [LessionName] nvarchar(255) NOT NULL,
        [LessionNo] int NOT NULL,
        [IsPublic] bit NOT NULL,
        [Frequency] int NOT NULL,
        [Capacity] int NOT NULL,
        [Credit] decimal(4,1) NOT NULL,
        [LineCapacity] int NOT NULL,
        [ContactName] nvarchar(50) NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactFax] varchar(20) NULL,
        [Properties] ntext NULL,
        [SignUpDueDate] datetime NOT NULL,
        [DiscountDueDate] datetime NULL,
        [ClassStartDate] datetime NOT NULL,
        [MinTimeSelect] int NOT NULL,
        [Requeryments] nvarchar(max) NULL,
        [IsRequireAllowLession] bit NOT NULL,
        [IsAllowNewCommer] bit NOT NULL,
        [Settings1] ntext NULL,
        [Settings2] ntext NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_CLASS] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'PortalId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'OrgId';
    SET @description = N'CategoryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'CategoryId';
    SET @description = N'CategoryCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'CategoryCode';
    SET @description = N'CategoryName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'CategoryName';
    SET @description = N'LessionId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'LessionId';
    SET @description = N'LessionCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'LessionCode';
    SET @description = N'LessionName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'LessionName';
    SET @description = N'LessionNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'LessionNo';
    SET @description = N'IsPublic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'IsPublic';
    SET @description = N'Frequency';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Frequency';
    SET @description = N'Capacity';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Capacity';
    SET @description = N'Credit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Credit';
    SET @description = N'LineCapacity';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'LineCapacity';
    SET @description = N'ContactName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'ContactName';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactFax';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'ContactFax';
    SET @description = N'Properties';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Properties';
    SET @description = N'SignUpDueDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'SignUpDueDate';
    SET @description = N'DiscountDueDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'DiscountDueDate';
    SET @description = N'ClassStartDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'ClassStartDate';
    SET @description = N'MinTimeSelect';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'MinTimeSelect';
    SET @description = N'Requeryments';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Requeryments';
    SET @description = N'IsRequireAllowLession';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'IsRequireAllowLession';
    SET @description = N'IsAllowNewCommer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'IsAllowNewCommer';
    SET @description = N'Settings1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Settings1';
    SET @description = N'Settings2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Settings2';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CLASS_DAY] (
        [Id] int NOT NULL IDENTITY,
        [ClassTimeId] int NOT NULL,
        [ClassDate] datetime NOT NULL,
        [StartTime] datetime NOT NULL,
        [EndTime] datetime NOT NULL,
        [StatusCd] varchar(20) NOT NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_CLASS_DAY] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'Id';
    SET @description = N'ClassTimeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'ClassTimeId';
    SET @description = N'ClassDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'ClassDate';
    SET @description = N'StartTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'StartTime';
    SET @description = N'EndTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'EndTime';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_DAY', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CLASS_PRICE] (
        [Id] int NOT NULL IDENTITY,
        [ClassId] int NOT NULL,
        [PriceName] nvarchar(50) NOT NULL,
        [Price] money NOT NULL,
        [IsPublic] bit NOT NULL,
        [DueDate] datetime NULL,
        CONSTRAINT [PK_MOD_CLASS_PRICE] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_PRICE', 'COLUMN', N'Id';
    SET @description = N'ClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_PRICE', 'COLUMN', N'ClassId';
    SET @description = N'PriceName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_PRICE', 'COLUMN', N'PriceName';
    SET @description = N'Price';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_PRICE', 'COLUMN', N'Price';
    SET @description = N'IsPublic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_PRICE', 'COLUMN', N'IsPublic';
    SET @description = N'DueDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_PRICE', 'COLUMN', N'DueDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CLASS_TERM] (
        [Id] int NOT NULL IDENTITY,
        [ClassId] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [SortOrder] int NULL,
        CONSTRAINT [PK_MOD_CLASS_TERM] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TERM', 'COLUMN', N'Id';
    SET @description = N'ClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TERM', 'COLUMN', N'ClassId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TERM', 'COLUMN', N'Name';
    SET @description = N'SortOrder';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TERM', 'COLUMN', N'SortOrder';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_CLASS_TIME] (
        [Id] int NOT NULL IDENTITY,
        [ClassId] int NOT NULL,
        [LessionTimeId] int NOT NULL,
        [ClassCode] nvarchar(10) NOT NULL,
        [DayofWeek] int NOT NULL,
        [StartTime] datetime NOT NULL,
        [EndTime] datetime NOT NULL,
        [TeacherName] nvarchar(50) NULL,
        [Place] nvarchar(255) NULL,
        [Capacity] int NOT NULL,
        [SignUpDueDate] datetime NULL,
        [DiscountDueDate] datetime NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_CLASS_TIME] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'Id';
    SET @description = N'ClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'ClassId';
    SET @description = N'LessionTimeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'LessionTimeId';
    SET @description = N'ClassCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'ClassCode';
    SET @description = N'DayofWeek';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'DayofWeek';
    SET @description = N'StartTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'StartTime';
    SET @description = N'EndTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'EndTime';
    SET @description = N'TeacherName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'TeacherName';
    SET @description = N'Place';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'Place';
    SET @description = N'Capacity';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'Capacity';
    SET @description = N'SignUpDueDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'SignUpDueDate';
    SET @description = N'DiscountDueDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'DiscountDueDate';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_CLASS_TIME', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_DEPARTMENT] (
        [Id] int NOT NULL IDENTITY,
        [OId] int NULL,
        [OrgId] int NOT NULL,
        [TypeId] int NULL,
        [Name] nvarchar(50) NOT NULL,
        [LeaderId] int NULL,
        [LeaderIDNumber] varchar(20) NOT NULL,
        [Leader2Id] int NULL,
        [Leader2IDNumber] varchar(20) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_DEPARTMENT] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'Id';
    SET @description = N'Oid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'OId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'OrgId';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'TypeId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'Name';
    SET @description = N'LeaderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'LeaderId';
    SET @description = N'LeaderIdnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'LeaderIDNumber';
    SET @description = N'Leader2Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'Leader2Id';
    SET @description = N'Leader2Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'Leader2IDNumber';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_DEPARTMENT', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_EXPGROUP] (
        [Id] int NOT NULL IDENTITY,
        [OrgId] int NULL,
        [GroupId] int NULL,
        [No] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [AreaName] nvarchar(50) NOT NULL,
        [LeaderId] int NULL,
        [LeaderIDNumber] varchar(20) NOT NULL,
        [Leader2Id] int NULL,
        [Leader2IDNumber] varchar(20) NULL,
        [Leader3Id] int NULL,
        [Leader3IDNumber] varchar(20) NULL,
        [DateStart] datetime NULL,
        [DateEnd] datetime NULL,
        [NewMemCount] int NOT NULL,
        [NewMemStayCount] int NOT NULL,
        [NewMemE1Count] int NOT NULL,
        [TypeId] int NOT NULL,
        [StatusCd] varchar(20) NOT NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_EXPGROUP] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'Id';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'OrgId';
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'GroupId';
    SET @description = N'No';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'No';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'Name';
    SET @description = N'AreaName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'AreaName';
    SET @description = N'LeaderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'LeaderId';
    SET @description = N'LeaderIdnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'LeaderIDNumber';
    SET @description = N'Leader2Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'Leader2Id';
    SET @description = N'Leader2Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'Leader2IDNumber';
    SET @description = N'Leader3Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'Leader3Id';
    SET @description = N'Leader3Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'Leader3IDNumber';
    SET @description = N'DateStart';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'DateStart';
    SET @description = N'DateEnd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'DateEnd';
    SET @description = N'NewMemCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'NewMemCount';
    SET @description = N'NewMemStayCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'NewMemStayCount';
    SET @description = N'NewMemE1count';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'NewMemE1Count';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'TypeId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_EXPGROUP', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_GROUP] (
        [Id] int NOT NULL IDENTITY,
        [OId] int NULL,
        [OrgId] int NULL,
        [DepId] int NULL,
        [AreaId] int NULL,
        [ZoneId] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [LeaderId] int NULL,
        [LeaderIDNumber] varchar(20) NOT NULL,
        [Leader2Id] int NULL,
        [Leader2IDNumber] varchar(20) NULL,
        [Leader3Id] int NULL,
        [Leader3IDNumber] varchar(20) NULL,
        [MeetingDayOfWeek] int NOT NULL,
        [MeetingTime] nvarchar(50) NULL,
        [MeetingAddress] nvarchar(255) NULL,
        [IsExp] bit NOT NULL,
        [IsSearchable] bit NOT NULL,
        [TypeId] int NOT NULL,
        [StatusCd] varchar(20) NOT NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_GROUP] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'Id';
    SET @description = N'Oid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'OId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'OrgId';
    SET @description = N'DepId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'DepId';
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'AreaId';
    SET @description = N'ZoneId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'ZoneId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'Name';
    SET @description = N'LeaderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'LeaderId';
    SET @description = N'LeaderIdnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'LeaderIDNumber';
    SET @description = N'Leader2Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'Leader2Id';
    SET @description = N'Leader2Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'Leader2IDNumber';
    SET @description = N'Leader3Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'Leader3Id';
    SET @description = N'Leader3Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'Leader3IDNumber';
    SET @description = N'MeetingDayOfWeek';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'MeetingDayOfWeek';
    SET @description = N'MeetingTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'MeetingTime';
    SET @description = N'MeetingAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'MeetingAddress';
    SET @description = N'IsExp';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'IsExp';
    SET @description = N'IsSearchable';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'IsSearchable';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'TypeId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUP', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_GROUPLEADER] (
        [GroupId] int NOT NULL,
        [MemberId] int NOT NULL,
        CONSTRAINT [PK_MOD_GROUPLEADER] PRIMARY KEY ([GroupId], [MemberId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUPLEADER', 'COLUMN', N'GroupId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_GROUPLEADER', 'COLUMN', N'MemberId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_LESSION] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        [CategoryId] int NOT NULL,
        [LessionCode] varchar(20) NULL,
        [LessionName] nvarchar(255) NOT NULL,
        [IsPublic] bit NOT NULL,
        [BaseNo] int NOT NULL,
        [BaseNoGranted] int NOT NULL,
        [Frequency] int NOT NULL,
        [Capacity] int NOT NULL,
        [Credit] decimal(4,1) NOT NULL,
        [ContactName] nvarchar(50) NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactFax] varchar(20) NULL,
        [MinTimeSelect] int NOT NULL,
        [Requeryments] nvarchar(max) NULL,
        [IsRequireAllowLession] bit NOT NULL,
        [IsAllowNewCommer] bit NOT NULL,
        [SortOrder] int NOT NULL,
        [Properties] ntext NULL,
        [Settings1] ntext NULL,
        [Settings2] ntext NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_LESSION] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'PortalId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'OrgId';
    SET @description = N'CategoryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'CategoryId';
    SET @description = N'LessionCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'LessionCode';
    SET @description = N'LessionName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'LessionName';
    SET @description = N'IsPublic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'IsPublic';
    SET @description = N'BaseNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'BaseNo';
    SET @description = N'BaseNoGranted';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'BaseNoGranted';
    SET @description = N'Frequency';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Frequency';
    SET @description = N'Capacity';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Capacity';
    SET @description = N'Credit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Credit';
    SET @description = N'ContactName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'ContactName';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactFax';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'ContactFax';
    SET @description = N'MinTimeSelect';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'MinTimeSelect';
    SET @description = N'Requeryments';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Requeryments';
    SET @description = N'IsRequireAllowLession';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'IsRequireAllowLession';
    SET @description = N'IsAllowNewCommer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'IsAllowNewCommer';
    SET @description = N'SortOrder';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'SortOrder';
    SET @description = N'Properties';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Properties';
    SET @description = N'Settings1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Settings1';
    SET @description = N'Settings2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Settings2';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_LESSION_CATEGORY] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [CategoryCode] varchar(20) NULL,
        [CategoryName] nvarchar(255) NOT NULL,
        [IsBase] bit NOT NULL,
        [IsFeatured] bit NOT NULL,
        [IsSeminary] bit NOT NULL,
        [SortOrder] int NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_LESSION_CATEGORY] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'PortalId';
    SET @description = N'CategoryCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'CategoryCode';
    SET @description = N'CategoryName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'CategoryName';
    SET @description = N'IsBase';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'IsBase';
    SET @description = N'IsFeatured';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'IsFeatured';
    SET @description = N'IsSeminary';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'IsSeminary';
    SET @description = N'SortOrder';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'SortOrder';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_CATEGORY', 'COLUMN', N'Comment';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_LESSION_PRICE] (
        [Id] int NOT NULL IDENTITY,
        [LessionId] int NOT NULL,
        [PriceName] nvarchar(50) NOT NULL,
        [Price] money NOT NULL,
        [IsPublic] bit NOT NULL,
        [DaysBeforeDue] int NOT NULL,
        CONSTRAINT [PK_MOD_LESSION_PRICE] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_PRICE', 'COLUMN', N'Id';
    SET @description = N'LessionId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_PRICE', 'COLUMN', N'LessionId';
    SET @description = N'PriceName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_PRICE', 'COLUMN', N'PriceName';
    SET @description = N'Price';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_PRICE', 'COLUMN', N'Price';
    SET @description = N'IsPublic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_PRICE', 'COLUMN', N'IsPublic';
    SET @description = N'DaysBeforeDue';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_PRICE', 'COLUMN', N'DaysBeforeDue';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_LESSION_TIME] (
        [Id] int NOT NULL IDENTITY,
        [LessionId] int NOT NULL,
        [ClassCode] nvarchar(10) NOT NULL,
        [DayofWeek] int NOT NULL,
        [StartTime] datetime NOT NULL,
        [EndTime] datetime NOT NULL,
        [TeacherName] nvarchar(50) NULL,
        [Place] nvarchar(255) NULL,
        [StatusCd] varchar(20) NULL,
        CONSTRAINT [PK_MOD_LESSION_TIME] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'Id';
    SET @description = N'LessionId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'LessionId';
    SET @description = N'ClassCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'ClassCode';
    SET @description = N'DayofWeek';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'DayofWeek';
    SET @description = N'StartTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'StartTime';
    SET @description = N'EndTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'EndTime';
    SET @description = N'TeacherName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'TeacherName';
    SET @description = N'Place';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'Place';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LESSION_TIME', 'COLUMN', N'StatusCd';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_LOG] (
        [Id] int NOT NULL IDENTITY,
        [Key] nvarchar(50) NOT NULL,
        [Content] nvarchar(max) NULL,
        [TypeId] int NOT NULL,
        [Date] datetime NOT NULL,
        CONSTRAINT [PK_MOD_LOG] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LOG', 'COLUMN', N'Id';
    SET @description = N'Key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LOG', 'COLUMN', N'Key';
    SET @description = N'Content';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LOG', 'COLUMN', N'Content';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LOG', 'COLUMN', N'TypeId';
    SET @description = N'Date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_LOG', 'COLUMN', N'Date';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEETING] (
        [GroupId] int NOT NULL,
        [Date] datetime NOT NULL,
        [GroupName] nvarchar(50) NOT NULL,
        [GroupTypeId] int NOT NULL,
        [OrgId] int NOT NULL,
        [DepId] int NOT NULL,
        [AreaId] int NOT NULL,
        [AreaName] nvarchar(50) NOT NULL,
        [ZoneId] int NOT NULL,
        [ZoneName] nvarchar(50) NOT NULL,
        [MeetingTime] nvarchar(50) NULL,
        [NoneGroupAttend] int NOT NULL,
        [NewCommerAttend] int NOT NULL,
        [ChildAttend] int NOT NULL,
        [WorshipNoneGroupAttend] int NOT NULL,
        [AttendComment] nvarchar(max) NULL,
        [AreaComment] nvarchar(max) NULL,
        [ZoneComment] nvarchar(max) NULL,
        [GroupComment] nvarchar(max) NULL,
        [WorshipComment] nvarchar(max) NULL,
        [ExpNo] int NOT NULL,
        [WeekOfExp] int NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_MEETING] PRIMARY KEY ([GroupId], [Date])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'GroupId';
    SET @description = N'Date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'Date';
    SET @description = N'GroupName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'GroupName';
    SET @description = N'GroupTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'GroupTypeId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'OrgId';
    SET @description = N'DepId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'DepId';
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'AreaId';
    SET @description = N'AreaName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'AreaName';
    SET @description = N'ZoneId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'ZoneId';
    SET @description = N'ZoneName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'ZoneName';
    SET @description = N'MeetingTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'MeetingTime';
    SET @description = N'NoneGroupAttend';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'NoneGroupAttend';
    SET @description = N'NewCommerAttend';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'NewCommerAttend';
    SET @description = N'ChildAttend';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'ChildAttend';
    SET @description = N'WorshipNoneGroupAttend';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'WorshipNoneGroupAttend';
    SET @description = N'AttendComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'AttendComment';
    SET @description = N'AreaComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'AreaComment';
    SET @description = N'ZoneComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'ZoneComment';
    SET @description = N'GroupComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'GroupComment';
    SET @description = N'WorshipComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'WorshipComment';
    SET @description = N'ExpNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'ExpNo';
    SET @description = N'WeekOfExp';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'WeekOfExp';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEETING_MEMBER] (
        [GroupId] int NOT NULL,
        [Date] datetime NOT NULL,
        [MemberId] int NOT NULL,
        [MemberName] nvarchar(255) NOT NULL,
        [MemberStatusCd] varchar(20) NULL,
        [MemberRoles] nvarchar(500) NULL,
        [IsAttended] bit NOT NULL,
        [IsWorshipAttended] bit NOT NULL,
        [IsGroupAttendExpected] bit NOT NULL,
        [IsWorshipAttendExpected] bit NOT NULL,
        [IsVisit] bit NOT NULL,
        [IntField1] int NOT NULL,
        [IntField2] int NOT NULL,
        [IntField3] int NOT NULL,
        [Comment] nvarchar(max) NULL,
        CONSTRAINT [PK_MOD_MEETING_MEMBER] PRIMARY KEY ([GroupId], [Date], [MemberId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'GroupId';
    SET @description = N'Date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'Date';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'MemberId';
    SET @description = N'MemberName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'MemberName';
    SET @description = N'MemberStatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'MemberStatusCd';
    SET @description = N'MemberRoles';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'MemberRoles';
    SET @description = N'IsAttended';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IsAttended';
    SET @description = N'IsWorshipAttended';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IsWorshipAttended';
    SET @description = N'IsGroupAttendExpected';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IsGroupAttendExpected';
    SET @description = N'IsWorshipAttendExpected';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IsWorshipAttendExpected';
    SET @description = N'IsVisit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IsVisit';
    SET @description = N'IntField1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IntField1';
    SET @description = N'IntField2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IntField2';
    SET @description = N'IntField3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'IntField3';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEETING_MEMBER', 'COLUMN', N'Comment';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [Name] nvarchar(255) NOT NULL,
        [EngName] nvarchar(255) NULL,
        [UserId] uniqueidentifier NULL,
        [CategoryId] int NULL,
        [Identifier] nvarchar(10) NULL,
        [IDNumber] varchar(20) NULL,
        [Email] nvarchar(255) NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactCellPhone] varchar(20) NULL,
        [ContactCellPhone2] varchar(20) NULL,
        [ContactCity] nvarchar(20) NULL,
        [ContactZipCode] varchar(10) NULL,
        [ContactAddress] nvarchar(255) NULL,
        [HomeAddress] nvarchar(255) NULL,
        [BizPhone] varchar(20) NULL,
        [Fax] varchar(20) NULL,
        [Gender] char(1) NOT NULL,
        [Birthday] datetime NULL,
        [Introducer] nvarchar(255) NULL,
        [IntroducerGroup] nvarchar(255) NULL,
        [RelativeName] nvarchar(255) NULL,
        [RelativeRelation] nvarchar(50) NULL,
        [RelativeCellPhone] varchar(20) NULL,
        [IsHasCommitment] bit NOT NULL,
        [IsBaptize] bit NULL,
        [BaptizeTypeId] int NULL,
        [Baptizeday] datetime NULL,
        [BaptizeOrgName] nvarchar(255) NULL,
        [BaptizeGroup] nvarchar(50) NULL,
        [Baptizer] nvarchar(50) NULL,
        [FirstSermon] datetime NULL,
        [FirstGroupMeeting] datetime NULL,
        [SettleDate] datetime NULL,
        [LastMovedDate] datetime NULL,
        [IsContract] bit NOT NULL,
        [IsGranted] bit NOT NULL,
        [GrantedDate] datetime NULL,
        [IsFromExp] bit NOT NULL,
        [SourceCd] varchar(20) NOT NULL,
        [GroupLeaderDate] datetime NULL,
        [IsAllowLession] bit NOT NULL,
        [Career] nvarchar(50) NULL,
        [CareerComment] nvarchar(max) NULL,
        [Interests] nvarchar(50) NULL,
        [Minister] nvarchar(50) NULL,
        [IsEducation] bit NOT NULL,
        [LevelofEducation] nvarchar(50) NULL,
        [EducationGrade] int NULL,
        [EducationSchool] nvarchar(500) NULL,
        [SchoolTimeCd] varchar(20) NULL,
        [MarriageId] int NULL,
        [Spouse] nvarchar(50) NULL,
        [Child1] nvarchar(50) NULL,
        [Child2] nvarchar(50) NULL,
        [Child3] nvarchar(50) NULL,
        [Child4] nvarchar(50) NULL,
        [Father] nvarchar(50) NULL,
        [Mother] nvarchar(50) NULL,
        [ContactTimes] nvarchar(50) NULL,
        [OrgName] nvarchar(255) NULL,
        [Department] nvarchar(255) NULL,
        [Area] nvarchar(255) NULL,
        [Zone] nvarchar(255) NULL,
        [Group] nvarchar(255) NULL,
        [OrgPriest] nvarchar(255) NULL,
        [OrgTitle] nvarchar(255) NULL,
        [GroupId] int NULL,
        [ZoneId] int NULL,
        [AreaId] int NULL,
        [IsE1] bit NOT NULL,
        [IsE2] bit NOT NULL,
        [IsE3] bit NOT NULL,
        [IsE4] bit NOT NULL,
        [IsReserved] bit NOT NULL,
        [IsTerm] bit NOT NULL,
        [IsGroupAttendExpected] bit NOT NULL,
        [IsWorshipAttendExpected] bit NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] ntext NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_MEMBER] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'PortalId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Name';
    SET @description = N'EngName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'EngName';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'UserId';
    SET @description = N'CategoryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'CategoryId';
    SET @description = N'Identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Identifier';
    SET @description = N'Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IDNumber';
    SET @description = N'Email';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Email';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ContactCellPhone';
    SET @description = N'ContactCellPhone2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ContactCellPhone2';
    SET @description = N'ContactCity';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ContactCity';
    SET @description = N'ContactZipCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ContactZipCode';
    SET @description = N'ContactAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ContactAddress';
    SET @description = N'HomeAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'HomeAddress';
    SET @description = N'BizPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'BizPhone';
    SET @description = N'Fax';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Fax';
    SET @description = N'Gender';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Gender';
    SET @description = N'Birthday';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Birthday';
    SET @description = N'Introducer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Introducer';
    SET @description = N'IntroducerGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IntroducerGroup';
    SET @description = N'RelativeName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'RelativeName';
    SET @description = N'RelativeRelation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'RelativeRelation';
    SET @description = N'RelativeCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'RelativeCellPhone';
    SET @description = N'IsHasCommitment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsHasCommitment';
    SET @description = N'IsBaptize';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsBaptize';
    SET @description = N'BaptizeTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'BaptizeTypeId';
    SET @description = N'Baptizeday';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Baptizeday';
    SET @description = N'BaptizeOrgName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'BaptizeOrgName';
    SET @description = N'BaptizeGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'BaptizeGroup';
    SET @description = N'Baptizer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Baptizer';
    SET @description = N'FirstSermon';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'FirstSermon';
    SET @description = N'FirstGroupMeeting';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'FirstGroupMeeting';
    SET @description = N'SettleDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'SettleDate';
    SET @description = N'LastMovedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'LastMovedDate';
    SET @description = N'IsContract';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsContract';
    SET @description = N'IsGranted';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsGranted';
    SET @description = N'GrantedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'GrantedDate';
    SET @description = N'IsFromExp';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsFromExp';
    SET @description = N'SourceCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'SourceCd';
    SET @description = N'GroupLeaderDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'GroupLeaderDate';
    SET @description = N'IsAllowLession';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsAllowLession';
    SET @description = N'Career';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Career';
    SET @description = N'CareerComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'CareerComment';
    SET @description = N'Interests';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Interests';
    SET @description = N'Minister';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Minister';
    SET @description = N'IsEducation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsEducation';
    SET @description = N'LevelofEducation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'LevelofEducation';
    SET @description = N'EducationGrade';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'EducationGrade';
    SET @description = N'EducationSchool';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'EducationSchool';
    SET @description = N'SchoolTimeCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'SchoolTimeCd';
    SET @description = N'MarriageId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'MarriageId';
    SET @description = N'Spouse';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Spouse';
    SET @description = N'Child1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Child1';
    SET @description = N'Child2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Child2';
    SET @description = N'Child3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Child3';
    SET @description = N'Child4';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Child4';
    SET @description = N'Father';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Father';
    SET @description = N'Mother';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Mother';
    SET @description = N'ContactTimes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ContactTimes';
    SET @description = N'OrgName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'OrgName';
    SET @description = N'Department';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Department';
    SET @description = N'Area';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Area';
    SET @description = N'Zone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Zone';
    SET @description = N'Group';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Group';
    SET @description = N'OrgPriest';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'OrgPriest';
    SET @description = N'OrgTitle';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'OrgTitle';
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'GroupId';
    SET @description = N'ZoneId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'ZoneId';
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'AreaId';
    SET @description = N'IsE1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsE1';
    SET @description = N'IsE2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsE2';
    SET @description = N'IsE3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsE3';
    SET @description = N'IsE4';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsE4';
    SET @description = N'IsReserved';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsReserved';
    SET @description = N'IsTerm';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsTerm';
    SET @description = N'IsGroupAttendExpected';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsGroupAttendExpected';
    SET @description = N'IsWorshipAttendExpected';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsWorshipAttendExpected';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_CLASS] (
        [Id] int NOT NULL IDENTITY,
        [MemberId] int NOT NULL,
        [OrderId] int NULL,
        [OrderIdentifer] varchar(10) NULL,
        [CategoryId] int NOT NULL,
        [CategoryCode] varchar(20) NOT NULL,
        [CategoryName] nvarchar(255) NOT NULL,
        [LessionId] int NOT NULL,
        [LessionCode] varchar(20) NOT NULL,
        [LessionName] nvarchar(255) NOT NULL,
        [ClassId] int NOT NULL,
        [LessionNo] int NOT NULL,
        [PriceName] nvarchar(50) NULL,
        [Price] money NULL,
        [SelectedTimeId] int NULL,
        [Team] nvarchar(50) NULL,
        [Line] int NULL,
        [Position] int NULL,
        [ClassWorkDone] bit NOT NULL,
        [Credit] decimal(4,1) NOT NULL,
        [CreditEarn] decimal(4,1) NOT NULL,
        [Grade] int NOT NULL,
        [RecordStatusCd] varchar(20) NULL,
        [DateRecorded] datetime NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Id';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'MemberId';
    SET @description = N'OrderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'OrderId';
    SET @description = N'OrderIdentifer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'OrderIdentifer';
    SET @description = N'CategoryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'CategoryId';
    SET @description = N'CategoryCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'CategoryCode';
    SET @description = N'CategoryName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'CategoryName';
    SET @description = N'LessionId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'LessionId';
    SET @description = N'LessionCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'LessionCode';
    SET @description = N'LessionName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'LessionName';
    SET @description = N'ClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'ClassId';
    SET @description = N'LessionNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'LessionNo';
    SET @description = N'PriceName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'PriceName';
    SET @description = N'Price';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Price';
    SET @description = N'SelectedTimeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'SelectedTimeId';
    SET @description = N'Team';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Team';
    SET @description = N'Line';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Line';
    SET @description = N'Position';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Position';
    SET @description = N'ClassWorkDone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'ClassWorkDone';
    SET @description = N'Credit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Credit';
    SET @description = N'CreditEarn';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'CreditEarn';
    SET @description = N'Grade';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Grade';
    SET @description = N'RecordStatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'RecordStatusCd';
    SET @description = N'DateRecorded';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'DateRecorded';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_CLASS_DAY] (
        [Id] int NOT NULL IDENTITY,
        [MemberClassId] int NOT NULL,
        [ClassTimeId] int NOT NULL,
        [ClassDayId] int NOT NULL,
        [ClassDate] datetime NOT NULL,
        [StartTime] datetime NOT NULL,
        [EndTime] datetime NOT NULL,
        [CheckIn] bit NOT NULL,
        [CheckInDate] datetime NULL,
        [Comment] nvarchar(500) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_MEMBER_CLASS_DAY] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'Id';
    SET @description = N'MemberClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'MemberClassId';
    SET @description = N'ClassTimeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'ClassTimeId';
    SET @description = N'ClassDayId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'ClassDayId';
    SET @description = N'ClassDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'ClassDate';
    SET @description = N'StartTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'StartTime';
    SET @description = N'EndTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'EndTime';
    SET @description = N'CheckIn';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'CheckIn';
    SET @description = N'CheckInDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'CheckInDate';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_CLASS_DAY_TERM] (
        [Id] int NOT NULL IDENTITY,
        [MemberClassDayId] int NOT NULL,
        [ClassTermId] int NOT NULL,
        [IsDone] bit NOT NULL,
        [Comment] nvarchar(500) NULL,
        CONSTRAINT [PK_MOD_MEMBER_CLASS_DAY_TERM] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY_TERM', 'COLUMN', N'Id';
    SET @description = N'MemberClassDayId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY_TERM', 'COLUMN', N'MemberClassDayId';
    SET @description = N'ClassTermId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY_TERM', 'COLUMN', N'ClassTermId';
    SET @description = N'IsDone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY_TERM', 'COLUMN', N'IsDone';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_DAY_TERM', 'COLUMN', N'Comment';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_CLASS_TIME] (
        [Id] int NOT NULL IDENTITY,
        [MemberClassId] int NOT NULL,
        [OrderId] int NULL,
        [ClassId] int NOT NULL,
        [ClassTimeId] int NOT NULL,
        [ClassCode] nvarchar(10) NOT NULL,
        [SortOrder] int NOT NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_TIME', 'COLUMN', N'Id';
    SET @description = N'MemberClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_TIME', 'COLUMN', N'MemberClassId';
    SET @description = N'OrderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_TIME', 'COLUMN', N'OrderId';
    SET @description = N'ClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_TIME', 'COLUMN', N'ClassId';
    SET @description = N'ClassTimeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_TIME', 'COLUMN', N'ClassTimeId';
    SET @description = N'ClassCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_TIME', 'COLUMN', N'ClassCode';
    SET @description = N'SortOrder';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_CLASS_TIME', 'COLUMN', N'SortOrder';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_IN_TAG] (
        [MemberId] int NOT NULL,
        [TagId] uniqueidentifier NOT NULL,
        CONSTRAINT [PK_MOD_MEMBER_IN_TAG] PRIMARY KEY ([MemberId], [TagId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_IN_TAG', 'COLUMN', N'MemberId';
    SET @description = N'TagId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_IN_TAG', 'COLUMN', N'TagId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_LOG] (
        [Id] bigint NOT NULL IDENTITY,
        [MemberId] int NOT NULL,
        [MemberName] nvarchar(255) NOT NULL,
        [TypeId] int NOT NULL,
        [NewState] nvarchar(max) NOT NULL,
        [OldState] nvarchar(max) NOT NULL,
        [OldGroupId] int NULL,
        [DateUpdate] datetime NULL,
        [UserIdUpdate] uniqueidentifier NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_MEMBER_LOG] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'Id';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'MemberId';
    SET @description = N'MemberName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'MemberName';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'TypeId';
    SET @description = N'NewState';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'NewState';
    SET @description = N'OldState';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'OldState';
    SET @description = N'OldGroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'OldGroupId';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'DateUpdate';
    SET @description = N'UserIdUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'UserIdUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_LOG', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_MINISTER] (
        [MemberId] int NOT NULL,
        [MinisterId] int NOT NULL,
        CONSTRAINT [PK_MOD_MEMBER_MINISTER] PRIMARY KEY ([MemberId], [MinisterId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER', 'COLUMN', N'MemberId';
    SET @description = N'MinisterId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER', 'COLUMN', N'MinisterId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MEMBER_MINISTER_LOG] (
        [MemberId] int NOT NULL,
        [MinisterId] int NOT NULL,
        [DateStart] datetime NOT NULL,
        [DateEnd] datetime NULL,
        [MinisterName] nvarchar(50) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_MEMBER_MINISTER_LOG] PRIMARY KEY ([MemberId], [MinisterId], [DateStart])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER_LOG', 'COLUMN', N'MemberId';
    SET @description = N'MinisterId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER_LOG', 'COLUMN', N'MinisterId';
    SET @description = N'DateStart';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER_LOG', 'COLUMN', N'DateStart';
    SET @description = N'DateEnd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER_LOG', 'COLUMN', N'DateEnd';
    SET @description = N'MinisterName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER_LOG', 'COLUMN', N'MinisterName';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER_LOG', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER_MINISTER_LOG', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MINISTER] (
        [Id] int NOT NULL IDENTITY,
        [MinisterGroupId] int NULL,
        [Name] nvarchar(50) NOT NULL,
        [Description] nvarchar(max) NULL,
        [Roles] nvarchar(max) NULL,
        [SortOrder] int NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_MINISTER] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'Id';
    SET @description = N'MinisterGroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'MinisterGroupId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'Name';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'Description';
    SET @description = N'Roles';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'Roles';
    SET @description = N'SortOrder';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'SortOrder';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_MINISTER_GROUP] (
        [Id] int NOT NULL IDENTITY,
        [OrgId] int NOT NULL,
        [Name] nvarchar(50) NOT NULL,
        [UserId] uniqueidentifier NULL,
        [Description] nvarchar(max) NULL,
        [TypeId] int NOT NULL,
        [SortOrder] int NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_MINISTER_GROUP] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'Id';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'OrgId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'Name';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'UserId';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'Description';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'TypeId';
    SET @description = N'SortOrder';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'SortOrder';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MINISTER_GROUP', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_NEWCOMMER] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        [CampaignId] uniqueidentifier NULL,
        [MemberId] int NULL,
        [AssignAreaId] int NULL,
        [AssignAreaName] nvarchar(50) NULL,
        [AssignZoneId] int NULL,
        [AssignZoneName] nvarchar(50) NULL,
        [AssignGroupId] int NULL,
        [AssignGroupName] nvarchar(50) NULL,
        [AssignUser] nvarchar(255) NULL,
        [DateAssign] datetime NULL,
        [TypeId] int NOT NULL,
        [TagId] uniqueidentifier NULL,
        [Name] nvarchar(255) NOT NULL,
        [DateEntry] datetime NULL,
        [EngName] nvarchar(255) NULL,
        [Email] nvarchar(255) NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactCellPhone] varchar(20) NULL,
        [ContactCity] nvarchar(20) NULL,
        [ContactZipCode] varchar(10) NULL,
        [ContactAddress] nvarchar(255) NULL,
        [Gender] char(1) NOT NULL,
        [Birthday] datetime NULL,
        [MarriageId] int NULL,
        [Career] nvarchar(50) NULL,
        [CareerComment] nvarchar(max) NULL,
        [IsEducation] bit NOT NULL,
        [LevelofEducation] nvarchar(50) NULL,
        [EducationGrade] int NULL,
        [EducationSchool] nvarchar(255) NULL,
        [SchoolTimeCd] varchar(20) NULL,
        [IsHasCommitment] bit NOT NULL,
        [BaptizeTypeId] int NULL,
        [IsAllowLession] bit NOT NULL,
        [Nc_Date] datetime NULL,
        [Nc_ActivityName] nvarchar(255) NULL,
        [Nc_ActivityNo] nvarchar(20) NULL,
        [Nc_ActivityGroup] nvarchar(255) NULL,
        [Nc_Introducer] nvarchar(255) NULL,
        [Nc_IntroducerIsRelated] bit NOT NULL,
        [Nc_IntroducerGroup] nvarchar(255) NULL,
        [Nc_IntroducerPhone] nvarchar(255) NULL,
        [Nc_IntroducerRelationship] nvarchar(255) NULL,
        [Nc_FollowGroup] nvarchar(255) NULL,
        [Nc_IsChristian] bit NOT NULL,
        [Nc_ChristianComeReason] nvarchar(255) NULL,
        [Nc_OrginalChurch] nvarchar(255) NULL,
        [Nc_OrginalChurchLocation] nvarchar(255) NULL,
        [Nc_OrginalChurchPriest] nvarchar(255) NULL,
        [Nc_GroupIntentionId] int NOT NULL,
        [Nc_PreferGroup] nvarchar(255) NULL,
        [Nc_PreferContactTimes] nvarchar(255) NULL,
        [Nc_PreferGroupTimes] nvarchar(255) NULL,
        [Nc_PreferGroupWeekDay] int NULL,
        [Nc_PreferGroupDayTime] datetime NULL,
        [Nc_PreferGroupTypes] nvarchar(500) NULL,
        [Nc_IsReadyForE1] bit NOT NULL,
        [Nc_Suggestions] nvarchar(max) NULL,
        [Nc_Interviewer] nvarchar(50) NULL,
        [Nc_IsFirstTimeCome] bit NOT NULL,
        [Nc_PrayContent] nvarchar(max) NULL,
        [Nc_InterviewContent] nvarchar(max) NULL,
        [Nc_InterviewComment] nvarchar(max) NULL,
        [Nc_InterviewDate] datetime NULL,
        [Nc_Trace1] nvarchar(max) NULL,
        [Nc_Trace2] nvarchar(max) NULL,
        [Nc_Trace3] nvarchar(max) NULL,
        [Nc_Trace4] nvarchar(max) NULL,
        [Nc_TraceComment] nvarchar(max) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] ntext NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_NEWCOMMER] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'PortalId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'OrgId';
    SET @description = N'CampaignId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'CampaignId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'MemberId';
    SET @description = N'AssignAreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'AssignAreaId';
    SET @description = N'AssignAreaName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'AssignAreaName';
    SET @description = N'AssignZoneId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'AssignZoneId';
    SET @description = N'AssignZoneName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'AssignZoneName';
    SET @description = N'AssignGroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'AssignGroupId';
    SET @description = N'AssignGroupName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'AssignGroupName';
    SET @description = N'AssignUser';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'AssignUser';
    SET @description = N'DateAssign';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'DateAssign';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'TypeId';
    SET @description = N'TagId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'TagId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Name';
    SET @description = N'DateEntry';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'DateEntry';
    SET @description = N'EngName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'EngName';
    SET @description = N'Email';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Email';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'ContactCellPhone';
    SET @description = N'ContactCity';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'ContactCity';
    SET @description = N'ContactZipCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'ContactZipCode';
    SET @description = N'ContactAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'ContactAddress';
    SET @description = N'Gender';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Gender';
    SET @description = N'Birthday';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Birthday';
    SET @description = N'MarriageId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'MarriageId';
    SET @description = N'Career';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Career';
    SET @description = N'CareerComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'CareerComment';
    SET @description = N'IsEducation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'IsEducation';
    SET @description = N'LevelofEducation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'LevelofEducation';
    SET @description = N'EducationGrade';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'EducationGrade';
    SET @description = N'EducationSchool';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'EducationSchool';
    SET @description = N'SchoolTimeCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'SchoolTimeCd';
    SET @description = N'IsHasCommitment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'IsHasCommitment';
    SET @description = N'BaptizeTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'BaptizeTypeId';
    SET @description = N'IsAllowLession';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'IsAllowLession';
    SET @description = N'NcDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Date';
    SET @description = N'NcActivityName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_ActivityName';
    SET @description = N'NcActivityNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_ActivityNo';
    SET @description = N'NcActivityGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_ActivityGroup';
    SET @description = N'NcIntroducer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Introducer';
    SET @description = N'NcIntroducerIsRelated';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_IntroducerIsRelated';
    SET @description = N'NcIntroducerGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_IntroducerGroup';
    SET @description = N'NcIntroducerPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_IntroducerPhone';
    SET @description = N'NcIntroducerRelationship';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_IntroducerRelationship';
    SET @description = N'NcFollowGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_FollowGroup';
    SET @description = N'NcIsChristian';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_IsChristian';
    SET @description = N'NcChristianComeReason';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_ChristianComeReason';
    SET @description = N'NcOrginalChurch';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_OrginalChurch';
    SET @description = N'NcOrginalChurchLocation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_OrginalChurchLocation';
    SET @description = N'NcOrginalChurchPriest';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_OrginalChurchPriest';
    SET @description = N'NcGroupIntentionId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_GroupIntentionId';
    SET @description = N'NcPreferGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_PreferGroup';
    SET @description = N'NcPreferContactTimes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_PreferContactTimes';
    SET @description = N'NcPreferGroupTimes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_PreferGroupTimes';
    SET @description = N'NcPreferGroupWeekDay';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_PreferGroupWeekDay';
    SET @description = N'NcPreferGroupDayTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_PreferGroupDayTime';
    SET @description = N'NcPreferGroupTypes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_PreferGroupTypes';
    SET @description = N'NcIsReadyForE1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_IsReadyForE1';
    SET @description = N'NcSuggestions';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Suggestions';
    SET @description = N'NcInterviewer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Interviewer';
    SET @description = N'NcIsFirstTimeCome';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_IsFirstTimeCome';
    SET @description = N'NcPrayContent';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_PrayContent';
    SET @description = N'NcInterviewContent';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_InterviewContent';
    SET @description = N'NcInterviewComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_InterviewComment';
    SET @description = N'NcInterviewDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_InterviewDate';
    SET @description = N'NcTrace1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Trace1';
    SET @description = N'NcTrace2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Trace2';
    SET @description = N'NcTrace3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Trace3';
    SET @description = N'NcTrace4';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_Trace4';
    SET @description = N'NcTraceComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Nc_TraceComment';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWCOMMER', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_NEWS] (
        [Id] int NOT NULL IDENTITY,
        [Subject] nvarchar(250) NULL,
        [Content] ntext NULL,
        [Date] datetime NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_NEWS] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'Id';
    SET @description = N'Subject';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'Subject';
    SET @description = N'Content';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'Content';
    SET @description = N'Date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'Date';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_NEWS', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ORDER] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        [Identifer] varchar(10) NOT NULL,
        [TypeId] int NOT NULL,
        [MemberId] int NOT NULL,
        [OrgName] nvarchar(255) NULL,
        [Department] nvarchar(255) NULL,
        [Area] nvarchar(255) NULL,
        [Zone] nvarchar(255) NULL,
        [Group] nvarchar(255) NULL,
        [GroupId] int NULL,
        [Name] nvarchar(255) NOT NULL,
        [IDNumber] varchar(20) NULL,
        [ContactCellPhone] varchar(20) NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactZipCode] varchar(10) NULL,
        [ContactAddress] nvarchar(255) NULL,
        [ContactEmail] nvarchar(255) NULL,
        [TotalAmount] money NOT NULL,
        [DepositAmount] money NOT NULL,
        [DepositPayee] nvarchar(255) NULL,
        [DepositPayedDate] datetime NULL,
        [RemainingAmount] money NOT NULL,
        [RemainingPayee] nvarchar(255) NULL,
        [RemainingPayedDate] datetime NULL,
        [PaymentMethod] nvarchar(50) NULL,
        [PaymentComment] nvarchar(500) NULL,
        [StudentCd] nvarchar(50) NULL,
        [StudentGrade] int NULL,
        [EmgPhone] varchar(20) NULL,
        [DateTextbook] datetime NULL,
        [TextbookName] nvarchar(50) NULL,
        [Specials] ntext NULL,
        [RecordStatusCd] varchar(20) NULL,
        [DateRecorded] datetime NULL,
        [IsNeedTraffic] bit NOT NULL,
        [IsCouple] bit NOT NULL,
        [Spouse] nvarchar(50) NULL,
        [Mates] nvarchar(500) NULL,
        [RelativeName] nvarchar(255) NULL,
        [RelativeCellPhone] varchar(20) NULL,
        [TranslateId] int NULL,
        [ReceptionDate] datetime NULL,
        [InvoiceNo] nvarchar(20) NULL,
        [UserCancel] nvarchar(255) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(500) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_ORDER] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'PortalId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'OrgId';
    SET @description = N'Identifer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Identifer';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'TypeId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'MemberId';
    SET @description = N'OrgName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'OrgName';
    SET @description = N'Department';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Department';
    SET @description = N'Area';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Area';
    SET @description = N'Zone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Zone';
    SET @description = N'Group';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Group';
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'GroupId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Name';
    SET @description = N'Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'IDNumber';
    SET @description = N'ContactCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'ContactCellPhone';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactZipCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'ContactZipCode';
    SET @description = N'ContactAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'ContactAddress';
    SET @description = N'ContactEmail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'ContactEmail';
    SET @description = N'TotalAmount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'TotalAmount';
    SET @description = N'DepositAmount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'DepositAmount';
    SET @description = N'DepositPayee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'DepositPayee';
    SET @description = N'DepositPayedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'DepositPayedDate';
    SET @description = N'RemainingAmount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'RemainingAmount';
    SET @description = N'RemainingPayee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'RemainingPayee';
    SET @description = N'RemainingPayedDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'RemainingPayedDate';
    SET @description = N'PaymentMethod';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'PaymentMethod';
    SET @description = N'PaymentComment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'PaymentComment';
    SET @description = N'StudentCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'StudentCd';
    SET @description = N'StudentGrade';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'StudentGrade';
    SET @description = N'EmgPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'EmgPhone';
    SET @description = N'DateTextbook';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'DateTextbook';
    SET @description = N'TextbookName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'TextbookName';
    SET @description = N'Specials';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Specials';
    SET @description = N'RecordStatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'RecordStatusCd';
    SET @description = N'DateRecorded';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'DateRecorded';
    SET @description = N'IsNeedTraffic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'IsNeedTraffic';
    SET @description = N'IsCouple';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'IsCouple';
    SET @description = N'Spouse';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Spouse';
    SET @description = N'Mates';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Mates';
    SET @description = N'RelativeName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'RelativeName';
    SET @description = N'RelativeCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'RelativeCellPhone';
    SET @description = N'TranslateId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'TranslateId';
    SET @description = N'ReceptionDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'ReceptionDate';
    SET @description = N'InvoiceNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'InvoiceNo';
    SET @description = N'UserCancel';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'UserCancel';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ORDER_INVOICE] (
        [Id] int NOT NULL IDENTITY,
        [Identifier] varchar(10) NOT NULL,
        [CustomNo] nvarchar(20) NULL,
        [OrderId] int NOT NULL,
        [PriceName] nvarchar(50) NULL,
        [Amount] money NOT NULL,
        [Payee] nvarchar(255) NULL,
        [PaymentMethod] nvarchar(50) NOT NULL,
        [RecordStatusCd] varchar(20) NOT NULL,
        [DateRecorded] datetime NULL,
        [UserRecorded] nvarchar(255) NULL,
        [TypeId] int NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'Id';
    SET @description = N'Identifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'Identifier';
    SET @description = N'CustomNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'CustomNo';
    SET @description = N'OrderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'OrderId';
    SET @description = N'PriceName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'PriceName';
    SET @description = N'Amount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'Amount';
    SET @description = N'Payee';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'Payee';
    SET @description = N'PaymentMethod';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'PaymentMethod';
    SET @description = N'RecordStatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'RecordStatusCd';
    SET @description = N'DateRecorded';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'DateRecorded';
    SET @description = N'UserRecorded';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'UserRecorded';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'TypeId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ORDER_INVOICE', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_PREORDER] (
        [Id] int NOT NULL IDENTITY,
        [OrgId] int NOT NULL,
        [Identifer] varchar(10) NOT NULL,
        [OrderId] int NULL,
        [ClassId] int NOT NULL,
        [ClassTime1] int NOT NULL,
        [ClassTime2] int NULL,
        [ClassTime3] int NULL,
        [GroupId] int NULL,
        [Name] nvarchar(255) NOT NULL,
        [IDNumber] varchar(20) NULL,
        [ContactCellPhone] varchar(20) NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactZipCode] varchar(10) NULL,
        [ContactAddress] nvarchar(255) NULL,
        [ContactEmail] nvarchar(255) NULL,
        [Gender] char(1) NOT NULL,
        [Birthday] datetime NULL,
        [StudentCd] nvarchar(50) NULL,
        [StudentGrade] int NULL,
        [EducationSchool] nvarchar(500) NULL,
        [EmgPhone] varchar(20) NULL,
        [DateTextbook] datetime NULL,
        [TextbookName] nvarchar(50) NULL,
        [Specials] ntext NULL,
        [IsNeedTraffic] bit NOT NULL,
        [Mates] nvarchar(500) NULL,
        [RelativeName] nvarchar(255) NULL,
        [RelativeRelation] nvarchar(50) NULL,
        [RelativeCellPhone] varchar(20) NULL,
        [TranslateId] int NULL,
        [ReceptionDate] datetime NULL,
        [BaptizeTypeId] int NULL,
        [Introducer] nvarchar(255) NULL,
        [IntroducerGroup] nvarchar(255) NULL,
        [IsAllowLession] bit NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(500) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_PREORDER] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Id';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'OrgId';
    SET @description = N'Identifer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Identifer';
    SET @description = N'OrderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'OrderId';
    SET @description = N'ClassId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ClassId';
    SET @description = N'ClassTime1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ClassTime1';
    SET @description = N'ClassTime2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ClassTime2';
    SET @description = N'ClassTime3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ClassTime3';
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'GroupId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Name';
    SET @description = N'Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'IDNumber';
    SET @description = N'ContactCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ContactCellPhone';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactZipCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ContactZipCode';
    SET @description = N'ContactAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ContactAddress';
    SET @description = N'ContactEmail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ContactEmail';
    SET @description = N'Gender';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Gender';
    SET @description = N'Birthday';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Birthday';
    SET @description = N'StudentCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'StudentCd';
    SET @description = N'StudentGrade';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'StudentGrade';
    SET @description = N'EducationSchool';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'EducationSchool';
    SET @description = N'EmgPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'EmgPhone';
    SET @description = N'DateTextbook';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'DateTextbook';
    SET @description = N'TextbookName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'TextbookName';
    SET @description = N'Specials';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Specials';
    SET @description = N'IsNeedTraffic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'IsNeedTraffic';
    SET @description = N'Mates';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Mates';
    SET @description = N'RelativeName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'RelativeName';
    SET @description = N'RelativeRelation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'RelativeRelation';
    SET @description = N'RelativeCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'RelativeCellPhone';
    SET @description = N'TranslateId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'TranslateId';
    SET @description = N'ReceptionDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'ReceptionDate';
    SET @description = N'BaptizeTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'BaptizeTypeId';
    SET @description = N'Introducer';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Introducer';
    SET @description = N'IntroducerGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'IntroducerGroup';
    SET @description = N'IsAllowLession';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'IsAllowLession';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_PREORDER', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ROLLCALL] (
        [Id] int NOT NULL IDENTITY,
        [No] nvarchar(10) NULL,
        [MemberId] int NOT NULL,
        [MemberName] nvarchar(255) NULL,
        [MemberIdentifier] nvarchar(10) NULL,
        [MemberIDNumber] varchar(20) NULL,
        [MemberIsUser] bit NOT NULL,
        [OrgId] int NOT NULL,
        [DepId] int NOT NULL,
        [AreaId] int NOT NULL,
        [AreaName] nvarchar(50) NOT NULL,
        [ZoneId] int NOT NULL,
        [ZoneName] nvarchar(50) NOT NULL,
        [GroupId] int NOT NULL,
        [GroupName] nvarchar(50) NOT NULL,
        [IsAttend] bit NOT NULL,
        [RollCallDate] datetime NOT NULL,
        [CampaignId] uniqueidentifier NULL,
        [CampaignSpdayId] int NULL,
        [ActivityId] int NULL,
        [ActivityWorkId] int NULL,
        [RollCallTypeId] int NOT NULL,
        [IntField1] int NOT NULL,
        [IntField2] int NOT NULL,
        [IntField3] int NOT NULL,
        [IntField4] int NOT NULL,
        [IntField5] int NOT NULL,
        [Comment] nvarchar(500) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_ROLLCALL] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'Id';
    SET @description = N'No';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'No';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'MemberId';
    SET @description = N'MemberName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'MemberName';
    SET @description = N'MemberIdentifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'MemberIdentifier';
    SET @description = N'MemberIdnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'MemberIDNumber';
    SET @description = N'MemberIsUser';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'MemberIsUser';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'OrgId';
    SET @description = N'DepId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'DepId';
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'AreaId';
    SET @description = N'AreaName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'AreaName';
    SET @description = N'ZoneId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'ZoneId';
    SET @description = N'ZoneName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'ZoneName';
    SET @description = N'GroupId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'GroupId';
    SET @description = N'GroupName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'GroupName';
    SET @description = N'IsAttend';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'IsAttend';
    SET @description = N'RollCallDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'RollCallDate';
    SET @description = N'CampaignId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'CampaignId';
    SET @description = N'CampaignSpdayId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'CampaignSpdayId';
    SET @description = N'ActivityId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'ActivityId';
    SET @description = N'ActivityWorkId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'ActivityWorkId';
    SET @description = N'RollCallTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'RollCallTypeId';
    SET @description = N'IntField1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'IntField1';
    SET @description = N'IntField2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'IntField2';
    SET @description = N'IntField3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'IntField3';
    SET @description = N'IntField4';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'IntField4';
    SET @description = N'IntField5';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'IntField5';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ROLLCALL_WORK] (
        [RollCallId] int NOT NULL,
        [ActivityWorkId] int NOT NULL,
        CONSTRAINT [PK_MOD_ROLLCALL_WORK] PRIMARY KEY ([RollCallId], [ActivityWorkId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'RollCallId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL_WORK', 'COLUMN', N'RollCallId';
    SET @description = N'ActivityWorkId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ROLLCALL_WORK', 'COLUMN', N'ActivityWorkId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_STATISTIC_DETAIL] (
        [StatisticId] int NOT NULL,
        [Date] datetime NOT NULL,
        [Value] int NOT NULL,
        CONSTRAINT [PK_MOD_STATISTIC_DETAIL_1] PRIMARY KEY ([StatisticId], [Date])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'StatisticId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTIC_DETAIL', 'COLUMN', N'StatisticId';
    SET @description = N'Date';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTIC_DETAIL', 'COLUMN', N'Date';
    SET @description = N'Value';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTIC_DETAIL', 'COLUMN', N'Value';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_STATISTICS] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        [ParentId] int NULL,
        [Name] nvarchar(255) NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_STATISTICS] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'PortalId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'OrgId';
    SET @description = N'ParentId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'ParentId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'Name';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_STATISTICS', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_TAG] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [PortalId] uniqueidentifier NOT NULL,
        [Name] nvarchar(250) NULL,
        [TagModule] nvarchar(50) NULL,
        [SortOrder] int NOT NULL,
        CONSTRAINT [PK_MOD_TAG] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TAG', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TAG', 'COLUMN', N'PortalId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TAG', 'COLUMN', N'Name';
    SET @description = N'TagModule';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TAG', 'COLUMN', N'TagModule';
    SET @description = N'SortOrder';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TAG', 'COLUMN', N'SortOrder';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_TEACHER] (
        [Id] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        [TeacherName] nvarchar(50) NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactCellPhone] varchar(20) NULL,
        [ContactEmail] nvarchar(255) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_TEACHER] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'Id';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'PortalId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'OrgId';
    SET @description = N'TeacherName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'TeacherName';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'ContactCellPhone';
    SET @description = N'ContactEmail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'ContactEmail';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_TEACHER', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ZONE] (
        [Id] int NOT NULL IDENTITY,
        [OId] int NULL,
        [OrgId] int NULL,
        [DepId] int NULL,
        [AreaId] int NULL,
        [Name] nvarchar(50) NOT NULL,
        [LeaderId] int NULL,
        [LeaderIDNumber] varchar(20) NOT NULL,
        [Leader2Id] int NULL,
        [Leader2IDNumber] varchar(20) NULL,
        [Leader3Id] int NULL,
        [Leader3IDNumber] varchar(20) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_MOD_ZONE] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'Id';
    SET @description = N'Oid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'OId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'OrgId';
    SET @description = N'DepId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'DepId';
    SET @description = N'AreaId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'AreaId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'Name';
    SET @description = N'LeaderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'LeaderId';
    SET @description = N'LeaderIdnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'LeaderIDNumber';
    SET @description = N'Leader2Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'Leader2Id';
    SET @description = N'Leader2Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'Leader2IDNumber';
    SET @description = N'Leader3Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'Leader3Id';
    SET @description = N'Leader3Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'Leader3IDNumber';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONE', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ZONELEADER] (
        [ZoneId] int NOT NULL,
        [MemberId] int NOT NULL,
        CONSTRAINT [PK_MOD_ZONELEADER] PRIMARY KEY ([ZoneId], [MemberId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ZoneId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONELEADER', 'COLUMN', N'ZoneId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONELEADER', 'COLUMN', N'MemberId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [MOD_ZONESUPERVISOR] (
        [ZoneId] int NOT NULL,
        [MemberId] int NOT NULL,
        CONSTRAINT [PK_MOD_ZONESUPERVISOR] PRIMARY KEY ([ZoneId], [MemberId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ZoneId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONESUPERVISOR', 'COLUMN', N'ZoneId';
    SET @description = N'MemberId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_ZONESUPERVISOR', 'COLUMN', N'MemberId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SEC_ROLE] (
        [RoleId] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [RoleName] nvarchar(255) NULL,
        [Description] nvarchar(255) NULL,
        [IsAutoAssignment] bit NOT NULL,
        [IsPublic] bit NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'RoleId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'RoleId';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'PortalId';
    SET @description = N'RoleName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'RoleName';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'Description';
    SET @description = N'IsAutoAssignment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'IsAutoAssignment';
    SET @description = N'IsPublic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'IsPublic';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_ROLE', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SEC_USER] (
        [UserId] int NOT NULL,
        [UserIdentifier] char(10) NULL,
        [Name] nvarchar(255) NOT NULL,
        [IDNumber] varchar(20) NULL,
        [IsSuperAdmin] bit NOT NULL,
        [ContactPhone] varchar(20) NULL,
        [ContactCellPhone] varchar(20) NULL,
        [ContactEmail] nvarchar(255) NULL,
        [ContactAddress] nvarchar(255) NULL,
        [Department] nvarchar(255) NULL,
        [JobTitle] nvarchar(255) NULL,
        [Language] varchar(20) NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'UserId';
    SET @description = N'UserIdentifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'UserIdentifier';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'Name';
    SET @description = N'Idnumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'IDNumber';
    SET @description = N'IsSuperAdmin';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'IsSuperAdmin';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'ContactCellPhone';
    SET @description = N'ContactEmail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'ContactEmail';
    SET @description = N'ContactAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'ContactAddress';
    SET @description = N'Department';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'Department';
    SET @description = N'JobTitle';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'JobTitle';
    SET @description = N'Language';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'Language';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SEC_USER_ROLE] (
        [UserId] int NOT NULL,
        [RoleId] int NOT NULL,
        [StatusCd] varchar(20) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_SEC_USER_ROLE] PRIMARY KEY ([UserId], [RoleId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER_ROLE', 'COLUMN', N'UserId';
    SET @description = N'RoleId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER_ROLE', 'COLUMN', N'RoleId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER_ROLE', 'COLUMN', N'StatusCd';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER_ROLE', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER_ROLE', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER_ROLE', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SEC_USER_ROLE', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_ADMIN_PERMISSION] (
        [AdminPermissoinId] int NOT NULL IDENTITY,
        [PortalId] uniqueidentifier NOT NULL,
        [Definition] varchar(50) NULL,
        [PermissionCd] varchar(50) NOT NULL,
        [UserId] uniqueidentifier NULL,
        [RoleName] nvarchar(256) NULL,
        [IsAllow] bit NOT NULL,
        [IsDeny] bit NOT NULL,
        CONSTRAINT [PK_ADMIN_PERMISSION] PRIMARY KEY ([AdminPermissoinId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'AdminPermissoinId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'AdminPermissoinId';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'PortalId';
    SET @description = N'Definition';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'Definition';
    SET @description = N'PermissionCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'PermissionCd';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'UserId';
    SET @description = N'RoleName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'RoleName';
    SET @description = N'IsAllow';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'IsAllow';
    SET @description = N'IsDeny';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ADMIN_PERMISSION', 'COLUMN', N'IsDeny';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_ORG_USER] (
        [UserId] uniqueidentifier NOT NULL,
        [OrgId] int NOT NULL,
        CONSTRAINT [PK_SYS_ORG_USER] PRIMARY KEY ([UserId], [OrgId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORG_USER', 'COLUMN', N'UserId';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORG_USER', 'COLUMN', N'OrgId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_ORGANIZATION] (
        [OrganizationId] int NOT NULL IDENTITY,
        [OId] int NULL,
        [PortalId] uniqueidentifier NOT NULL,
        [Name] nvarchar(255) NOT NULL,
        [PastorName] nvarchar(50) NULL,
        [PastorId] int NULL,
        [Pastor] nvarchar(50) NOT NULL,
        [Pastorphone] varchar(20) NULL,
        [Phone] varchar(20) NULL,
        [Fax] varchar(20) NULL,
        [Email] nvarchar(255) NULL,
        [Site] nvarchar(255) NULL,
        [Zip] varchar(20) NULL,
        [Address] nvarchar(255) NULL,
        [InvoiceIdentifier] varchar(20) NULL,
        [InvoiceTitle] nvarchar(255) NULL,
        [IsInvoiceTitle] bit NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_SYS_ORGANIZATION] PRIMARY KEY ([OrganizationId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'OrganizationId';
    SET @description = N'Oid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'OId';
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'PortalId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Name';
    SET @description = N'PastorName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'PastorName';
    SET @description = N'PastorId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'PastorId';
    SET @description = N'Pastor';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Pastor';
    SET @description = N'Pastorphone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Pastorphone';
    SET @description = N'Phone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Phone';
    SET @description = N'Fax';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Fax';
    SET @description = N'Email';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Email';
    SET @description = N'Site';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Site';
    SET @description = N'Zip';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Zip';
    SET @description = N'Address';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Address';
    SET @description = N'InvoiceIdentifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'InvoiceIdentifier';
    SET @description = N'InvoiceTitle';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'InvoiceTitle';
    SET @description = N'IsInvoiceTitle';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'IsInvoiceTitle';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_ORGANIZATION', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_PERMISSION] (
        [PermissionId] int NOT NULL IDENTITY,
        [Definition] varchar(50) NOT NULL,
        [PermissionCd] varchar(20) NOT NULL,
        [Description] nvarchar(255) NULL,
        CONSTRAINT [PK_SEC_PERMISSION] PRIMARY KEY ([PermissionId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'PermissionId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PERMISSION', 'COLUMN', N'PermissionId';
    SET @description = N'Definition';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PERMISSION', 'COLUMN', N'Definition';
    SET @description = N'PermissionCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PERMISSION', 'COLUMN', N'PermissionCd';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PERMISSION', 'COLUMN', N'Description';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_PORTAL] (
        [PortalId] uniqueidentifier NOT NULL,
        [PortalName] nvarchar(255) NOT NULL,
        [Description] nvarchar(255) NULL,
        [Email] nvarchar(255) NOT NULL,
        [DefaultLanguage] nvarchar(50) NOT NULL,
        [Theme] nvarchar(50) NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_SYS_PORTAL] PRIMARY KEY ([PortalId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'PortalId';
    SET @description = N'PortalName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'PortalName';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'Description';
    SET @description = N'Email';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'Email';
    SET @description = N'DefaultLanguage';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'DefaultLanguage';
    SET @description = N'Theme';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'Theme';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_PORTAL', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_SEED_IDENTITY] (
        [SeedTable] varchar(50) NOT NULL,
        [SeedCur] int NULL,
        [SeedMax] int NULL,
        [SeedMin] int NULL,
        [ResetTypeCd] varchar(10) NULL,
        [ResetDate] datetime NULL,
        CONSTRAINT [PK_SYS_SEED_IDENTITY] PRIMARY KEY ([SeedTable])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'SeedTable';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SEED_IDENTITY', 'COLUMN', N'SeedTable';
    SET @description = N'SeedCur';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SEED_IDENTITY', 'COLUMN', N'SeedCur';
    SET @description = N'SeedMax';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SEED_IDENTITY', 'COLUMN', N'SeedMax';
    SET @description = N'SeedMin';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SEED_IDENTITY', 'COLUMN', N'SeedMin';
    SET @description = N'ResetTypeCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SEED_IDENTITY', 'COLUMN', N'ResetTypeCd';
    SET @description = N'ResetDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SEED_IDENTITY', 'COLUMN', N'ResetDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_SETTINGS] (
        [SettingName] nvarchar(255) NOT NULL,
        [Value] ntext NULL,
        [IsSensitive] bit NOT NULL,
        [StatusCd] varchar(20) NULL,
        [Comment] nvarchar(255) NULL,
        [DateCreate] datetime NULL,
        [UserCreate] nvarchar(255) NULL,
        [DateUpdate] datetime NULL,
        [UserUpdate] nvarchar(255) NULL,
        CONSTRAINT [PK_SYS_PORTAL_SETTINGS] PRIMARY KEY ([SettingName])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'SettingName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'SettingName';
    SET @description = N'Value';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'Value';
    SET @description = N'IsSensitive';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'IsSensitive';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'Comment';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'DateCreate';
    SET @description = N'UserCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'UserCreate';
    SET @description = N'DateUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'DateUpdate';
    SET @description = N'UserUpdate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SETTINGS', 'COLUMN', N'UserUpdate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    CREATE TABLE [SYS_SMS_RESULT] (
        [BatchId] nvarchar(100) NOT NULL,
        [Credit] money NULL,
        [SendedCount] int NULL,
        [Cost] money NULL,
        [UnSend] int NULL,
        [DateCreate] datetime NULL,
        CONSTRAINT [PK_SYS_SMS_RESULT] PRIMARY KEY ([BatchId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'BatchId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SMS_RESULT', 'COLUMN', N'BatchId';
    SET @description = N'Credit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SMS_RESULT', 'COLUMN', N'Credit';
    SET @description = N'SendedCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SMS_RESULT', 'COLUMN', N'SendedCount';
    SET @description = N'Cost';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SMS_RESULT', 'COLUMN', N'Cost';
    SET @description = N'UnSend';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SMS_RESULT', 'COLUMN', N'UnSend';
    SET @description = N'DateCreate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SYS_SMS_RESULT', 'COLUMN', N'DateCreate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20220910040452_InitOldTables')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20220910040452_InitOldTables', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [ApiAuditLog] (
        [Id] bigint NOT NULL IDENTITY,
        [Account] nvarchar(64) NULL,
        [Name] nvarchar(32) NULL,
        [SourceIp] varchar(128) NULL,
        [HttpMethod] varchar(16) NULL,
        [RequestPath] varchar(512) NULL,
        [RequestQueryString] nvarchar(max) NULL,
        [RequestHeaders] nvarchar(max) NULL,
        [ResponseStatusCode] int NOT NULL,
        [RequestBody] nvarchar(max) NULL,
        [ResponseBody] nvarchar(max) NULL,
        [TimeElapsed] bigint NOT NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_ApiAuditLog] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'API 系統操作紀錄';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Id';
    SET @description = N'操作人員帳號';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Account';
    SET @description = N'操作人員姓名';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'Name';
    SET @description = N'來源 IP';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'SourceIp';
    SET @description = N'請求 Method';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'HttpMethod';
    SET @description = N'請求網址路徑';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestPath';
    SET @description = N'請求網址參數';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestQueryString';
    SET @description = N'請求網址 headers';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestHeaders';
    SET @description = N'回傳 http 狀態碼';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'ResponseStatusCode';
    SET @description = N'請求資料';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RequestBody';
    SET @description = N'回應資料';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'ResponseBody';
    SET @description = N'執行時間(ms)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'TimeElapsed';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ApiAuditLog', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Course] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementId] bigint NOT NULL,
        [PastoralId] bigint NOT NULL,
        [QuestionnaireId] bigint NOT NULL,
        [Year] nvarchar(32) NULL,
        [Name] nvarchar(200) NULL,
        [ClassNum] nvarchar(32) NULL,
        [Season] nvarchar(32) NULL,
        [OpenDate] datetime2 NOT NULL,
        [SignUpDateS] datetime2 NOT NULL,
        [SignUpDateE] datetime2 NOT NULL,
        [DiscountSignUpDate] datetime2 NOT NULL,
        [CourseSignUpType] nvarchar(32) NULL,
        [WishCount] int NOT NULL,
        [NeedRecommend] nvarchar(32) NULL,
        [AcceptNewMember] nvarchar(32) NULL,
        [Description] nvarchar(200) NULL,
        [ClassCount] int NOT NULL,
        [Quota] int NOT NULL,
        [GraduationType] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Course] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'Id';
    SET @description = N'CourseManagementId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'CourseManagementId';
    SET @description = N'PastoralId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'PastoralId';
    SET @description = N'QuestionnaireId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'QuestionnaireId';
    SET @description = N'Year';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'Year';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'Name';
    SET @description = N'ClassNum';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'ClassNum';
    SET @description = N'Season';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'Season';
    SET @description = N'OpenDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'OpenDate';
    SET @description = N'SignUpDateS';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'SignUpDateS';
    SET @description = N'SignUpDateE';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'SignUpDateE';
    SET @description = N'DiscountSignUpDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'DiscountSignUpDate';
    SET @description = N'CourseSignUpType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'CourseSignUpType';
    SET @description = N'WishCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'WishCount';
    SET @description = N'NeedRecommend';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'NeedRecommend';
    SET @description = N'AcceptNewMember';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'AcceptNewMember';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'Description';
    SET @description = N'ClassCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'ClassCount';
    SET @description = N'Quota';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'Quota';
    SET @description = N'GraduationType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'GraduationType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CourseAppendix] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseId] bigint NOT NULL,
        [AppendixType] nvarchar(32) NULL,
        [Path] nvarchar(200) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseAppendix] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'Id';
    SET @description = N'CourseId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'CourseId';
    SET @description = N'AppendixType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'AppendixType';
    SET @description = N'Path';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'Path';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseAppendix', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CourseManagement] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementTypeId] bigint NOT NULL,
        [OrganizationId] bigint NOT NULL,
        [Title] nvarchar(200) NULL,
        [Description] nvarchar(200) NULL,
        [CourseManagementStatus] nvarchar(20) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseManagement] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'Id';
    SET @description = N'CourseManagementTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'CourseManagementTypeId';
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'OrganizationId';
    SET @description = N'Title';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'Title';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'Description';
    SET @description = N'CourseManagementStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'CourseManagementStatus';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CourseManagementAppendix] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementId] bigint NOT NULL,
        [AppendixType] nvarchar(32) NULL,
        [Path] nvarchar(200) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseManagementAppendix] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'Id';
    SET @description = N'CourseManagementId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'CourseManagementId';
    SET @description = N'AppendixType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'AppendixType';
    SET @description = N'Path';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'Path';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementAppendix', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CourseManagementType] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementTypeNo] nvarchar(200) NULL,
        [Name] nvarchar(200) NULL,
        [Remark] nvarchar(200) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseManagementType] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'Id';
    SET @description = N'CourseManagementTypeNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'CourseManagementTypeNo';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'Name';
    SET @description = N'Remark';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'Remark';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementType', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CoursePrice] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseId] bigint NOT NULL,
        [PriceName] nvarchar(200) NULL,
        [Price] int NOT NULL,
        [IsPublic] nvarchar(32) NULL,
        [IsDueDate] nvarchar(32) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CoursePrice] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'Id';
    SET @description = N'CourseId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'CourseId';
    SET @description = N'PriceName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'PriceName';
    SET @description = N'Price';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'Price';
    SET @description = N'IsPublic';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'IsPublic';
    SET @description = N'IsDueDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'IsDueDate';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CourseTimeSchedual] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseId] bigint NOT NULL,
        [SchedualNo] nvarchar(32) NULL,
        [ClassDay] nvarchar(32) NULL,
        [ClassTimeS] nvarchar(32) NULL,
        [ClassTimeE] nvarchar(32) NULL,
        [Place] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseTimeSchedual] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'Id';
    SET @description = N'CourseId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'CourseId';
    SET @description = N'SchedualNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'SchedualNo';
    SET @description = N'ClassDay';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'ClassDay';
    SET @description = N'ClassTimeS';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'ClassTimeS';
    SET @description = N'ClassTimeE';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'ClassTimeE';
    SET @description = N'Place';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'Place';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedual', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CourseTimeSchedualTeacher] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseTimeSchedualId] bigint NOT NULL,
        [SchedualNo] nvarchar(32) NULL,
        [TeacherId] bigint NOT NULL,
        [AttendanceType] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseTimeSchedualTeacher] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'Id';
    SET @description = N'CourseTimeSchedualId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'CourseTimeSchedualId';
    SET @description = N'SchedualNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'SchedualNo';
    SET @description = N'TeacherId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'TeacherId';
    SET @description = N'AttendanceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'AttendanceType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualTeacher', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [CourseTimeSchedualUser] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseTimeSchedualId] bigint NOT NULL,
        [SchedualNo] nvarchar(32) NULL,
        [AttendanceType] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseTimeSchedualUser] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'Id';
    SET @description = N'CourseTimeSchedualId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'CourseTimeSchedualId';
    SET @description = N'SchedualNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'SchedualNo';
    SET @description = N'AttendanceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'AttendanceType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedualUser', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [ExceptionLog] (
        [Id] bigint NOT NULL IDENTITY,
        [MachineName] varchar(64) NULL,
        [Message] nvarchar(1024) NULL,
        [Source] nvarchar(1024) NULL,
        [StackTrace] nvarchar(max) NULL,
        [ExtraData] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_ExceptionLog] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'AP 錯誤紀錄';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Id';
    SET @description = N'MachineName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'MachineName';
    SET @description = N'Message';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Message';
    SET @description = N'Source';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'Source';
    SET @description = N'StackTrace';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'StackTrace';
    SET @description = N'ExtraData';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'ExtraData';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ExceptionLog', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Ministry] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryDefId] bigint NOT NULL,
        [MinistryNo] nvarchar(20) NULL,
        [Name] nvarchar(50) NULL,
        [ChildMinistry] nvarchar(20) NULL,
        [MinistryStatus] nvarchar(20) NULL,
        [Nature] nvarchar(20) NULL,
        [StatusCd] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Ministry] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'Id';
    SET @description = N'MinistryDefId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'MinistryDefId';
    SET @description = N'MinistryNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'MinistryNo';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'Name';
    SET @description = N'ChildMinistry';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'ChildMinistry';
    SET @description = N'MinistryStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'MinistryStatus';
    SET @description = N'Nature';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'Nature';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'Comment';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Ministry', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [MinistryDef] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryDefNo] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [ChildMinistry] nvarchar(max) NULL,
        [MinistryDefStatus] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistryDef] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'Id';
    SET @description = N'MinistryDefNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'MinistryDefNo';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'Name';
    SET @description = N'ChildMinistry';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'ChildMinistry';
    SET @description = N'MinistryDefStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'MinistryDefStatus';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'Comment';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryDef', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [MinistryResp] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryId] bigint NOT NULL,
        [Seq] int NOT NULL,
        [Name] nvarchar(50) NULL,
        [ManageType] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistryResp] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'Id';
    SET @description = N'MinistryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'MinistryId';
    SET @description = N'Seq';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'Seq';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'Name';
    SET @description = N'ManageType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'ManageType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'Comment';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryResp', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [MinistryRespUser] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryRespId] bigint NOT NULL,
        [UserId] bigint NOT NULL,
        [StatusCd] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistryRespUser] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'Id';
    SET @description = N'MinistryRespId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'MinistryRespId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'UserId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'Comment';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [MinistrySchedual] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryId] bigint NOT NULL,
        [Name] nvarchar(50) NULL,
        [CycleType] nvarchar(20) NULL,
        [RepeatTime] nvarchar(20) NULL,
        [RepeatTimeUnit] nvarchar(20) NULL,
        [EndDateType] nvarchar(20) NULL,
        [EndDate] nvarchar(50) NULL,
        [RepeaTimes] nvarchar(50) NULL,
        [StatusCd] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [IsActivated] int NOT NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistrySchedual] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'Id';
    SET @description = N'MinistryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'MinistryId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'Name';
    SET @description = N'CycleType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'CycleType';
    SET @description = N'RepeatTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'RepeatTime';
    SET @description = N'RepeatTimeUnit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'RepeatTimeUnit';
    SET @description = N'EndDateType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'EndDateType';
    SET @description = N'EndDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'EndDate';
    SET @description = N'RepeaTimes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'RepeaTimes';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'Comment';
    SET @description = N'IsActivated';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'IsActivated';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedual', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Organization] (
        [Id] bigint NOT NULL IDENTITY,
        [Oid] bigint NOT NULL,
        [Name] nvarchar(50) NULL,
        [PastorName] nvarchar(50) NULL,
        [PastorId] bigint NOT NULL,
        [Pastor] nvarchar(50) NULL,
        [Pastorphone] nvarchar(50) NULL,
        [Phone] nvarchar(50) NULL,
        [Fax] nvarchar(50) NULL,
        [Email] nvarchar(200) NULL,
        [Site] nvarchar(200) NULL,
        [Zip] nvarchar(200) NULL,
        [Address] nvarchar(255) NULL,
        [InvoiceIdentifier] nvarchar(50) NULL,
        [InvoiceTitle] nvarchar(50) NULL,
        [IsInvoiceTitle] nvarchar(50) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Organization] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Id';
    SET @description = N'Oid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Oid';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Name';
    SET @description = N'PastorName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'PastorName';
    SET @description = N'PastorId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'PastorId';
    SET @description = N'Pastor';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Pastor';
    SET @description = N'Pastorphone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Pastorphone';
    SET @description = N'Phone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Phone';
    SET @description = N'Fax';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Fax';
    SET @description = N'Email';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Email';
    SET @description = N'Site';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Site';
    SET @description = N'Zip';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Zip';
    SET @description = N'Address';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'Address';
    SET @description = N'InvoiceIdentifier';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'InvoiceIdentifier';
    SET @description = N'InvoiceTitle';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'InvoiceTitle';
    SET @description = N'IsInvoiceTitle';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'IsInvoiceTitle';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [OrganizationUser] (
        [UserId] bigint NOT NULL IDENTITY,
        [Id] bigint NOT NULL,
        [OrganizationId] bigint NOT NULL,
        [StatusCd] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_OrganizationUser] PRIMARY KEY ([UserId])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'UserId';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'Id';
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'OrganizationId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'Comment';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'OrganizationUser', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Pastoral] (
        [Id] bigint NOT NULL IDENTITY,
        [UpperPastoralId] bigint NOT NULL,
        [Name] nvarchar(20) NULL,
        [Title] nvarchar(20) NULL,
        [GroupNo] nvarchar(8) NULL,
        [LeaderId] bigint NULL,
        [LeaderIdNumber] nvarchar(max) NULL,
        [Leader2Id] bigint NULL,
        [Leader2IdNumber] nvarchar(max) NULL,
        [Leader3Id] bigint NULL,
        [Leader3IdNumber] nvarchar(max) NULL,
        [SupervisorId] bigint NULL,
        [Oid] bigint NULL,
        [OrgId] bigint NOT NULL,
        [TypeId] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [Comment] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Pastoral] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Id';
    SET @description = N'UpperPastoralId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'UpperPastoralId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Name';
    SET @description = N'Title';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Title';
    SET @description = N'GroupNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'GroupNo';
    SET @description = N'LeaderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'LeaderId';
    SET @description = N'LeaderIdNumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'LeaderIdNumber';
    SET @description = N'Leader2Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Leader2Id';
    SET @description = N'Leader2IdNumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Leader2IdNumber';
    SET @description = N'Leader3Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Leader3Id';
    SET @description = N'Leader3IdNumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Leader3IdNumber';
    SET @description = N'SupervisorId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'SupervisorId';
    SET @description = N'Oid';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Oid';
    SET @description = N'OrgId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'OrgId';
    SET @description = N'TypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'TypeId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'Comment';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Pastoral', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [PastoralMeeting] (
        [Id] bigint NOT NULL IDENTITY,
        [PastoralId] bigint NOT NULL,
        [MeetingDayOfWeek] nvarchar(36) NULL,
        [MeetingTime] nvarchar(36) NULL,
        [MeetingAddress] nvarchar(36) NULL,
        [MeetingDay] nvarchar(36) NULL,
        [IsExp] nvarchar(36) NULL,
        [IsSearchable] nvarchar(36) NULL,
        [MeetType] nvarchar(36) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_PastoralMeeting] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'Id';
    SET @description = N'PastoralId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'PastoralId';
    SET @description = N'MeetingDayOfWeek';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'MeetingDayOfWeek';
    SET @description = N'MeetingTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'MeetingTime';
    SET @description = N'MeetingAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'MeetingAddress';
    SET @description = N'MeetingDay';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'MeetingDay';
    SET @description = N'IsExp';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'IsExp';
    SET @description = N'IsSearchable';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'IsSearchable';
    SET @description = N'MeetType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'MeetType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeeting', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [PastoralMeetingUser] (
        [Id] bigint NOT NULL IDENTITY,
        [PastoralMeetingId] bigint NOT NULL,
        [UserId] bigint NOT NULL,
        [MeetAttendanceType] nvarchar(36) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_PastoralMeetingUser] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'Id';
    SET @description = N'PastoralMeetingId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'PastoralMeetingId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'UserId';
    SET @description = N'MeetAttendanceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'MeetAttendanceType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'PastoralMeetingUser', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Privilege] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [FunctionId] nvarchar(6) NULL,
        [ParentFunctionId] nvarchar(6) NULL,
        [Name] nvarchar(64) NULL,
        [Sort] int NOT NULL,
        [LinkType] varchar(32) NOT NULL,
        [QueryParams] nvarchar(2048) NULL,
        [Icon] nvarchar(64) NULL,
        [Comment] nvarchar(512) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Privilege] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'權限功能';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'Id';
    SET @description = N'功能 ID';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'FunctionId';
    SET @description = N'父層功能 Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'ParentFunctionId';
    SET @description = N'功能名稱';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'Name';
    SET @description = N'排序';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'Sort';
    SET @description = N'功能類型';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'LinkType';
    SET @description = N'QueryParams';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'QueryParams';
    SET @description = N'圖示';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'Icon';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'Comment';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Privilege', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Questionnaire] (
        [Id] bigint NOT NULL IDENTITY,
        [QuestionnaireJoinLocation] nvarchar(200) NULL,
        [QuestionnaireType] nvarchar(32) NULL,
        [Name] nvarchar(200) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Questionnaire] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'Id';
    SET @description = N'QuestionnaireJoinLocation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'QuestionnaireJoinLocation';
    SET @description = N'QuestionnaireType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'QuestionnaireType';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'Name';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [QuestionnaireDetail] (
        [Id] bigint NOT NULL IDENTITY,
        [QuestionnaireId] bigint NOT NULL,
        [UpperQuestionnaireDetailId] bigint NOT NULL,
        [QuestionnaireDetailType] nvarchar(32) NULL,
        [ComponentType] nvarchar(32) NULL,
        [Sequence] nvarchar(32) NULL,
        [Name] nvarchar(500) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_QuestionnaireDetail] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'Id';
    SET @description = N'QuestionnaireId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'QuestionnaireId';
    SET @description = N'UpperQuestionnaireDetailId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'UpperQuestionnaireDetailId';
    SET @description = N'QuestionnaireDetailType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'QuestionnaireDetailType';
    SET @description = N'ComponentType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'ComponentType';
    SET @description = N'Sequence';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'Sequence';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'Name';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Role] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [Name] nvarchar(63) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Role] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'角色';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'Id';
    SET @description = N'角色';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'Name';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Role', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [RolePrivilegeMapping] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [RoleId] uniqueidentifier NOT NULL,
        [PrivilegeId] uniqueidentifier NOT NULL,
        [Enable] bit NOT NULL,
        [ViewGranted] bit NOT NULL,
        [ModifyGranted] bit NOT NULL,
        [DeleteGranted] bit NOT NULL,
        [UploadGranted] bit NOT NULL,
        [DownloadGranted] bit NOT NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_RolePrivilegeMapping] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'角色-功能權限對應';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'Id';
    SET @description = N'角色 Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'RoleId';
    SET @description = N'功能 Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'PrivilegeId';
    SET @description = N'啟用';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'Enable';
    SET @description = N'檢視';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'ViewGranted';
    SET @description = N'新增/編輯';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'ModifyGranted';
    SET @description = N'刪除';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'DeleteGranted';
    SET @description = N'上傳';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'UploadGranted';
    SET @description = N'下載';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'DownloadGranted';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RolePrivilegeMapping', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [RoleUserMapping] (
        [Id] uniqueidentifier NOT NULL DEFAULT (NEWID()),
        [UserId] bigint NOT NULL,
        [RoleId] uniqueidentifier NOT NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_RoleUserMapping] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'帳號-角色 對應';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping';
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'Id';
    SET @description = N'使用者 Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'UserId';
    SET @description = N'角色 Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'RoleId';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'RoleUserMapping', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [SystemConfig] (
        [Id] bigint NOT NULL IDENTITY,
        [Type] nvarchar(max) NULL,
        [Value] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Memo] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_SystemConfig] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'Id';
    SET @description = N'Type';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'Type';
    SET @description = N'Value';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'Value';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'Name';
    SET @description = N'Memo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'Memo';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'SystemConfig', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [Teacher] (
        [Id] bigint NOT NULL IDENTITY,
        [OrganizationId] bigint NOT NULL,
        [TeacherName] nvarchar(50) NULL,
        [ContactPhone] nvarchar(50) NULL,
        [ContactCellPhone] nvarchar(50) NULL,
        [ContactEmail] nvarchar(200) NULL,
        [Comment] nvarchar(200) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_Teacher] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'Id';
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'OrganizationId';
    SET @description = N'TeacherName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'TeacherName';
    SET @description = N'ContactPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'ContactPhone';
    SET @description = N'ContactCellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'ContactCellPhone';
    SET @description = N'ContactEmail';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'ContactEmail';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'Comment';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Teacher', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [User] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] nvarchar(36) NULL,
        [PastoralId] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [UserNo] nvarchar(max) NULL,
        [Password] nvarchar(128) NULL,
        [PasswordSalt] nvarchar(128) NULL,
        [PhoneType] nvarchar(30) NULL,
        [FirstName] nvarchar(20) NULL,
        [LastName] nvarchar(20) NULL,
        [GenderType] nvarchar(30) NULL,
        [LiveCountry] nvarchar(50) NULL,
        [Birthday] nvarchar(max) NULL,
        [IdNumber] nvarchar(25) NULL,
        [CellPhone] nvarchar(50) NULL,
        [LiveCity] nvarchar(50) NULL,
        [LiveZipCode] nvarchar(50) NULL,
        [LiveZipArea] nvarchar(50) NULL,
        [LiveAddress] nvarchar(50) NULL,
        [LiveAddress2] nvarchar(50) NULL,
        [BaptizedType] nvarchar(max) NULL,
        [BaptizedTime] nvarchar(max) NULL,
        [BaptizedPerson] nvarchar(max) NULL,
        [ChurchType] nvarchar(20) NULL,
        [ChurchName] nvarchar(20) NULL,
        [AnotherChurchName] nvarchar(50) NULL,
        [Phone] nvarchar(25) NULL,
        [CellPhone1] nvarchar(25) NULL,
        [CellPhone2] nvarchar(25) NULL,
        [Email1] nvarchar(50) NULL,
        [Email2] nvarchar(50) NULL,
        [InstagramId] nvarchar(25) NULL,
        [LineId] nvarchar(25) NULL,
        [WeChatId] nvarchar(25) NULL,
        [OtherSocialId] nvarchar(25) NULL,
        [IsChurchGroup] nvarchar(20) NULL,
        [ChurchGroupNo] nvarchar(25) NULL,
        [IsJoinChurchGroup] nvarchar(20) NULL,
        [JoinInPersonDate1] nvarchar(20) NULL,
        [JoinInPersonTime1] nvarchar(20) NULL,
        [JoinInPersonLocation1] nvarchar(20) NULL,
        [JoinInPersonDate2] nvarchar(20) NULL,
        [JoinInPersonTime2] nvarchar(20) NULL,
        [JoinInPersonLocation2] nvarchar(20) NULL,
        [JoinInPersonDate3] nvarchar(20) NULL,
        [JoinInPersonTime3] nvarchar(20) NULL,
        [JoinInPersonLocation3] nvarchar(20) NULL,
        [JoinOnlineDate1] nvarchar(20) NULL,
        [JoinOnlineTime1] nvarchar(20) NULL,
        [JoinOnlineDate2] nvarchar(20) NULL,
        [JoinOnlineTime2] nvarchar(20) NULL,
        [JoinOnlineDate3] nvarchar(20) NULL,
        [JoinOnlineTime3] nvarchar(20) NULL,
        [MemberType] nvarchar(20) NULL,
        [EduType] nvarchar(20) NULL,
        [ProfessionType] nvarchar(20) NULL,
        [IsMarried] nvarchar(20) NULL,
        [LastLogin] nvarchar(max) NULL,
        [ParentUserId] bigint NOT NULL,
        [IsOldMember] nvarchar(max) NULL,
        [CountryCode] nvarchar(20) NULL,
        [CellAreaCode1] nvarchar(20) NULL,
        [CellAreaCode2] nvarchar(max) NULL,
        [Account] nvarchar(20) NULL,
        [Roles] nvarchar(20) NULL,
        [IsAdmin] nvarchar(20) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_User] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'UserId';
    SET @description = N'PastoralId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'PastoralId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Name';
    SET @description = N'UserNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'UserNo';
    SET @description = N'Password';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Password';
    SET @description = N'PasswordSalt';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'PasswordSalt';
    SET @description = N'PhoneType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'PhoneType';
    SET @description = N'FirstName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'FirstName';
    SET @description = N'LastName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LastName';
    SET @description = N'GenderType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'GenderType';
    SET @description = N'LiveCountry';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LiveCountry';
    SET @description = N'Birthday';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Birthday';
    SET @description = N'IdNumber';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'IdNumber';
    SET @description = N'CellPhone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CellPhone';
    SET @description = N'LiveCity';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LiveCity';
    SET @description = N'LiveZipCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LiveZipCode';
    SET @description = N'LiveZipArea';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LiveZipArea';
    SET @description = N'LiveAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LiveAddress';
    SET @description = N'LiveAddress2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LiveAddress2';
    SET @description = N'BaptizedType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'BaptizedType';
    SET @description = N'BaptizedTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'BaptizedTime';
    SET @description = N'BaptizedPerson';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'BaptizedPerson';
    SET @description = N'ChurchType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'ChurchType';
    SET @description = N'ChurchName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'ChurchName';
    SET @description = N'AnotherChurchName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'AnotherChurchName';
    SET @description = N'Phone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Phone';
    SET @description = N'CellPhone1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CellPhone1';
    SET @description = N'CellPhone2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CellPhone2';
    SET @description = N'Email1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Email1';
    SET @description = N'Email2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Email2';
    SET @description = N'InstagramId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'InstagramId';
    SET @description = N'LineId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LineId';
    SET @description = N'WeChatId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'WeChatId';
    SET @description = N'OtherSocialId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'OtherSocialId';
    SET @description = N'IsChurchGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'IsChurchGroup';
    SET @description = N'ChurchGroupNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'ChurchGroupNo';
    SET @description = N'IsJoinChurchGroup';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'IsJoinChurchGroup';
    SET @description = N'JoinInPersonDate1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonDate1';
    SET @description = N'JoinInPersonTime1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonTime1';
    SET @description = N'JoinInPersonLocation1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonLocation1';
    SET @description = N'JoinInPersonDate2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonDate2';
    SET @description = N'JoinInPersonTime2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonTime2';
    SET @description = N'JoinInPersonLocation2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonLocation2';
    SET @description = N'JoinInPersonDate3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonDate3';
    SET @description = N'JoinInPersonTime3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonTime3';
    SET @description = N'JoinInPersonLocation3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinInPersonLocation3';
    SET @description = N'JoinOnlineDate1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinOnlineDate1';
    SET @description = N'JoinOnlineTime1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinOnlineTime1';
    SET @description = N'JoinOnlineDate2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinOnlineDate2';
    SET @description = N'JoinOnlineTime2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinOnlineTime2';
    SET @description = N'JoinOnlineDate3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinOnlineDate3';
    SET @description = N'JoinOnlineTime3';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'JoinOnlineTime3';
    SET @description = N'MemberType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'MemberType';
    SET @description = N'EduType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'EduType';
    SET @description = N'ProfessionType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'ProfessionType';
    SET @description = N'IsMarried';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'IsMarried';
    SET @description = N'LastLogin';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LastLogin';
    SET @description = N'ParentUserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'ParentUserId';
    SET @description = N'IsOldMember';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'IsOldMember';
    SET @description = N'CountryCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CountryCode';
    SET @description = N'CellAreaCode1';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CellAreaCode1';
    SET @description = N'CellAreaCode2';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'CellAreaCode2';
    SET @description = N'Account';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Account';
    SET @description = N'Roles';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'Roles';
    SET @description = N'IsAdmin';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'IsAdmin';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [MinistrySchedualDetail] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistrySchedualId] bigint NOT NULL,
        [Name] nvarchar(50) NULL,
        [Description] nvarchar(50) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistrySchedualDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MinistrySchedualDetail_MinistrySchedual_MinistrySchedualId] FOREIGN KEY ([MinistrySchedualId]) REFERENCES [MinistrySchedual] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'Id';
    SET @description = N'MinistrySchedualId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'MinistrySchedualId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'Name';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'Description';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedualDetail', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserBankAccount] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [BankName] nvarchar(max) NULL,
        [BankCode] nvarchar(max) NULL,
        [BranchCode] nvarchar(max) NULL,
        [Account] nvarchar(max) NULL,
        [Memo] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserBankAccount] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserBankAccount_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'UserId';
    SET @description = N'BankName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'BankName';
    SET @description = N'BankCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'BankCode';
    SET @description = N'BranchCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'BranchCode';
    SET @description = N'Account';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'Account';
    SET @description = N'Memo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'Memo';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserBankAccount', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserContract] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [Name] nvarchar(max) NULL,
        [Relative] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Memo] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserContract] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserContract_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'UserId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'Name';
    SET @description = N'Relative';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'Relative';
    SET @description = N'Phone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'Phone';
    SET @description = N'Memo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'Memo';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContract', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserCourse] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [CourseId] nvarchar(max) NULL,
        [AttendanceType] nvarchar(max) NULL,
        [AttendanceDate] nvarchar(max) NULL,
        [Memo] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserCourse] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserCourse_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'UserId';
    SET @description = N'CourseId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'CourseId';
    SET @description = N'AttendanceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'AttendanceType';
    SET @description = N'AttendanceDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'AttendanceDate';
    SET @description = N'Memo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'Memo';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserCourse', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserExpertise] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [Name] nvarchar(max) NULL,
        [Memo] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserExpertise] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserExpertise_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'UserId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'Name';
    SET @description = N'Memo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'Memo';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserExpertise', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserFamily] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [RelativeType] nvarchar(max) NULL,
        [Name] nvarchar(max) NULL,
        [Memo] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserFamily] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserFamily_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'UserId';
    SET @description = N'RelativeType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'RelativeType';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'Name';
    SET @description = N'Memo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'Memo';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserFamily', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserPastoralCare] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [CareType] nvarchar(20) NULL,
        [CareIdentityType] nvarchar(20) NULL,
        [NewArea] nvarchar(200) NULL,
        [OldArea] nvarchar(200) NULL,
        [CareDate] datetime2 NULL,
        [Comment] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserPastoralCare] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserPastoralCare_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'UserId';
    SET @description = N'CareType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'CareType';
    SET @description = N'CareIdentityType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'CareIdentityType';
    SET @description = N'NewArea';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'NewArea';
    SET @description = N'OldArea';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'OldArea';
    SET @description = N'CareDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'CareDate';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'Comment';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserQuestionnaire] (
        [Id] bigint NOT NULL IDENTITY,
        [QuestionnaireId] bigint NOT NULL,
        [UserId] bigint NOT NULL,
        [QuestionnaireWriteType] nvarchar(max) NULL,
        [QuestionnaireGoArea] nvarchar(max) NULL,
        [Satisfaction] nvarchar(max) NULL,
        [Evaluation] nvarchar(max) NULL,
        [WriteQuestionnaireDate] datetime2 NULL,
        [Comment] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserQuestionnaire] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserQuestionnaire_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'Id';
    SET @description = N'QuestionnaireId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'QuestionnaireId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'UserId';
    SET @description = N'QuestionnaireWriteType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'QuestionnaireWriteType';
    SET @description = N'QuestionnaireGoArea';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'QuestionnaireGoArea';
    SET @description = N'Satisfaction';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'Satisfaction';
    SET @description = N'Evaluation';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'Evaluation';
    SET @description = N'WriteQuestionnaireDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'WriteQuestionnaireDate';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'Comment';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserQuestionnaire', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE TABLE [UserSociety] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [Name] nvarchar(30) NULL,
        [Comment] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserSociety] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserSociety_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'UserId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'Name';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'Comment';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserSociety', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_ApiAuditLog_DateCreate_UserCreate_HandledId] ON [ApiAuditLog] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_ApiAuditLog_HandledId_Account_Name_HttpMethod_SourceIp_RequestPath_ResponseStatusCode] ON [ApiAuditLog] ([HandledId], [Account], [Name], [HttpMethod], [SourceIp], [RequestPath], [ResponseStatusCode]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Course_DateCreate_UserCreate_HandledId] ON [Course] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CourseAppendix_DateCreate_UserCreate_HandledId] ON [CourseAppendix] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CourseManagement_DateCreate_UserCreate_HandledId] ON [CourseManagement] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CourseManagementAppendix_DateCreate_UserCreate_HandledId] ON [CourseManagementAppendix] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CourseManagementType_DateCreate_UserCreate_HandledId] ON [CourseManagementType] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CoursePrice_DateCreate_UserCreate_HandledId] ON [CoursePrice] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CourseTimeSchedual_DateCreate_UserCreate_HandledId] ON [CourseTimeSchedual] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CourseTimeSchedualTeacher_DateCreate_UserCreate_HandledId] ON [CourseTimeSchedualTeacher] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_CourseTimeSchedualUser_DateCreate_UserCreate_HandledId] ON [CourseTimeSchedualUser] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_ExceptionLog_DateCreate_UserCreate_HandledId] ON [ExceptionLog] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_ExceptionLog_MachineName] ON [ExceptionLog] ([MachineName]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Ministry_DateCreate_UserCreate_HandledId] ON [Ministry] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_MinistryDef_DateCreate_UserCreate_HandledId] ON [MinistryDef] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_MinistryResp_DateCreate_UserCreate_HandledId] ON [MinistryResp] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_MinistryRespUser_DateCreate_UserCreate_HandledId] ON [MinistryRespUser] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_MinistrySchedual_DateCreate_UserCreate_HandledId] ON [MinistrySchedual] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_MinistrySchedualDetail_DateCreate_UserCreate_HandledId] ON [MinistrySchedualDetail] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_MinistrySchedualDetail_MinistrySchedualId] ON [MinistrySchedualDetail] ([MinistrySchedualId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Organization_DateCreate_UserCreate_HandledId] ON [Organization] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_OrganizationUser_DateCreate_UserCreate_HandledId] ON [OrganizationUser] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Pastoral_DateCreate_UserCreate_HandledId] ON [Pastoral] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_PastoralMeeting_DateCreate_UserCreate_HandledId] ON [PastoralMeeting] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_PastoralMeetingUser_DateCreate_UserCreate_HandledId] ON [PastoralMeetingUser] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Privilege_DateCreate_UserCreate_HandledId] ON [Privilege] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    EXEC(N'CREATE UNIQUE INDEX [IX_Privilege_FunctionId] ON [Privilege] ([FunctionId]) WHERE [FunctionId] IS NOT NULL');
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Privilege_ParentFunctionId_LinkType] ON [Privilege] ([ParentFunctionId], [LinkType]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Questionnaire_DateCreate_UserCreate_HandledId] ON [Questionnaire] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_QuestionnaireDetail_DateCreate_UserCreate_HandledId] ON [QuestionnaireDetail] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Role_DateCreate_UserCreate_HandledId] ON [Role] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_RolePrivilegeMapping_DateCreate_UserCreate_HandledId] ON [RolePrivilegeMapping] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_RolePrivilegeMapping_RoleId_PrivilegeId] ON [RolePrivilegeMapping] ([RoleId], [PrivilegeId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_RoleUserMapping_DateCreate_UserCreate_HandledId] ON [RoleUserMapping] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_RoleUserMapping_UserId_RoleId] ON [RoleUserMapping] ([UserId], [RoleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_SystemConfig_DateCreate_UserCreate_HandledId] ON [SystemConfig] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_Teacher_DateCreate_UserCreate_HandledId] ON [Teacher] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_User_DateCreate_UserCreate_HandledId] ON [User] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserBankAccount_DateCreate_UserCreate_HandledId] ON [UserBankAccount] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserBankAccount_UserId] ON [UserBankAccount] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserContract_DateCreate_UserCreate_HandledId] ON [UserContract] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserContract_UserId] ON [UserContract] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserCourse_DateCreate_UserCreate_HandledId] ON [UserCourse] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserCourse_UserId] ON [UserCourse] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserExpertise_DateCreate_UserCreate_HandledId] ON [UserExpertise] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserExpertise_UserId] ON [UserExpertise] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserFamily_DateCreate_UserCreate_HandledId] ON [UserFamily] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserFamily_UserId] ON [UserFamily] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserPastoralCare_DateCreate_UserCreate_HandledId] ON [UserPastoralCare] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserPastoralCare_UserId] ON [UserPastoralCare] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserQuestionnaire_DateCreate_UserCreate_HandledId] ON [UserQuestionnaire] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserQuestionnaire_UserId] ON [UserQuestionnaire] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserSociety_DateCreate_UserCreate_HandledId] ON [UserSociety] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    CREATE INDEX [IX_UserSociety_UserId] ON [UserSociety] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006061714_InitModels')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221006061714_InitModels', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006070154_AddColumnOfCourse')
BEGIN
    DECLARE @var0 sysname;
    SELECT @var0 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'PastoralId');
    IF @var0 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var0 + '];');
    ALTER TABLE [Course] DROP COLUMN [PastoralId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006070154_AddColumnOfCourse')
BEGIN
    ALTER TABLE [Course] ADD [ClassContext] nvarchar(500) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ClassContext';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'ClassContext';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006070154_AddColumnOfCourse')
BEGIN
    ALTER TABLE [Course] ADD [GraduationQualification] nvarchar(200) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'GraduationQualification';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'GraduationQualification';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006070154_AddColumnOfCourse')
BEGIN
    ALTER TABLE [Course] ADD [OrganizationId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'OrganizationId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006070154_AddColumnOfCourse')
BEGIN
    ALTER TABLE [Course] ADD [SpecialRequiement] nvarchar(200) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'SpecialRequiement';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'SpecialRequiement';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006070154_AddColumnOfCourse')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221006070154_AddColumnOfCourse', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE TABLE [CourseManagementFilter] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementId] bigint NOT NULL,
        [OrganizationId] bigint NOT NULL,
        [CourseSex] nvarchar(32) NULL,
        [AgeUp] int NOT NULL,
        [AgeDown] int NOT NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseManagementFilter] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'Id';
    SET @description = N'CourseManagementId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'CourseManagementId';
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'OrganizationId';
    SET @description = N'CourseSex';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'CourseSex';
    SET @description = N'AgeUp';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'AgeUp';
    SET @description = N'AgeDown';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'AgeDown';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilter', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE TABLE [CourseManagementFilterCourse] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementFilterId] bigint NOT NULL,
        [CourseManagementId] bigint NOT NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseManagementFilterCourse] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'Id';
    SET @description = N'CourseManagementFilterId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'CourseManagementFilterId';
    SET @description = N'CourseManagementId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'CourseManagementId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterCourse', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE TABLE [CourseManagementFilterPastoral] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementFilterId] bigint NOT NULL,
        [PastoralId] bigint NOT NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseManagementFilterPastoral] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'Id';
    SET @description = N'CourseManagementFilterId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'CourseManagementFilterId';
    SET @description = N'PastoralId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'PastoralId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterPastoral', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE TABLE [CourseManagementFilterResp] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseManagementFilterId] bigint NOT NULL,
        [MinistryRespId] bigint NOT NULL,
        [StatusCd] nvarchar(max) NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseManagementFilterResp] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'Id';
    SET @description = N'CourseManagementFilterId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'CourseManagementFilterId';
    SET @description = N'MinistryRespId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'MinistryRespId';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagementFilterResp', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE INDEX [IX_CourseManagementFilter_DateCreate_UserCreate_HandledId] ON [CourseManagementFilter] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE INDEX [IX_CourseManagementFilterCourse_DateCreate_UserCreate_HandledId] ON [CourseManagementFilterCourse] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE INDEX [IX_CourseManagementFilterPastoral_DateCreate_UserCreate_HandledId] ON [CourseManagementFilterPastoral] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    CREATE INDEX [IX_CourseManagementFilterResp_DateCreate_UserCreate_HandledId] ON [CourseManagementFilterResp] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006084638_AddCourseFilterSchema')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221006084638_AddCourseFilterSchema', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104003_ModifyColumnName')
BEGIN
    DECLARE @var1 sysname;
    SELECT @var1 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'SpecialRequiement');
    IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var1 + '];');
    ALTER TABLE [Course] DROP COLUMN [SpecialRequiement];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104003_ModifyColumnName')
BEGIN
    ALTER TABLE [Course] ADD [SpecialRequirement] nvarchar(200) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'SpecialRequirement';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'SpecialRequirement';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104003_ModifyColumnName')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221006104003_ModifyColumnName', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104732_ModifyColumnNameOfCourse')
BEGIN
    DECLARE @var2 sysname;
    SELECT @var2 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'ClassContext');
    IF @var2 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var2 + '];');
    ALTER TABLE [Course] DROP COLUMN [ClassContext];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104732_ModifyColumnNameOfCourse')
BEGIN
    DECLARE @var3 sysname;
    SELECT @var3 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'ClassCount');
    IF @var3 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var3 + '];');
    ALTER TABLE [Course] DROP COLUMN [ClassCount];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104732_ModifyColumnNameOfCourse')
BEGIN
    ALTER TABLE [Course] ADD [CourseContext] nvarchar(500) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseContext';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'CourseContext';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104732_ModifyColumnNameOfCourse')
BEGIN
    ALTER TABLE [Course] ADD [CourseCount] int NOT NULL DEFAULT 0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseCount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'CourseCount';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006104732_ModifyColumnNameOfCourse')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221006104732_ModifyColumnNameOfCourse', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var4 sysname;
    SELECT @var4 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserSociety]') AND [c].[name] = N'StatusCd');
    IF @var4 IS NOT NULL EXEC(N'ALTER TABLE [UserSociety] DROP CONSTRAINT [' + @var4 + '];');
    ALTER TABLE [UserSociety] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var5 sysname;
    SELECT @var5 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserQuestionnaire]') AND [c].[name] = N'StatusCd');
    IF @var5 IS NOT NULL EXEC(N'ALTER TABLE [UserQuestionnaire] DROP CONSTRAINT [' + @var5 + '];');
    ALTER TABLE [UserQuestionnaire] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var6 sysname;
    SELECT @var6 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserPastoralCare]') AND [c].[name] = N'StatusCd');
    IF @var6 IS NOT NULL EXEC(N'ALTER TABLE [UserPastoralCare] DROP CONSTRAINT [' + @var6 + '];');
    ALTER TABLE [UserPastoralCare] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var7 sysname;
    SELECT @var7 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserFamily]') AND [c].[name] = N'StatusCd');
    IF @var7 IS NOT NULL EXEC(N'ALTER TABLE [UserFamily] DROP CONSTRAINT [' + @var7 + '];');
    ALTER TABLE [UserFamily] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var8 sysname;
    SELECT @var8 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserExpertise]') AND [c].[name] = N'StatusCd');
    IF @var8 IS NOT NULL EXEC(N'ALTER TABLE [UserExpertise] DROP CONSTRAINT [' + @var8 + '];');
    ALTER TABLE [UserExpertise] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var9 sysname;
    SELECT @var9 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserCourse]') AND [c].[name] = N'StatusCd');
    IF @var9 IS NOT NULL EXEC(N'ALTER TABLE [UserCourse] DROP CONSTRAINT [' + @var9 + '];');
    ALTER TABLE [UserCourse] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var10 sysname;
    SELECT @var10 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserContract]') AND [c].[name] = N'StatusCd');
    IF @var10 IS NOT NULL EXEC(N'ALTER TABLE [UserContract] DROP CONSTRAINT [' + @var10 + '];');
    ALTER TABLE [UserContract] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var11 sysname;
    SELECT @var11 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'StatusCd');
    IF @var11 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var11 + '];');
    ALTER TABLE [User] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var12 sysname;
    SELECT @var12 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Teacher]') AND [c].[name] = N'StatusCd');
    IF @var12 IS NOT NULL EXEC(N'ALTER TABLE [Teacher] DROP CONSTRAINT [' + @var12 + '];');
    ALTER TABLE [Teacher] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var13 sysname;
    SELECT @var13 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'StatusCd');
    IF @var13 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var13 + '];');
    ALTER TABLE [QuestionnaireDetail] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var14 sysname;
    SELECT @var14 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Questionnaire]') AND [c].[name] = N'StatusCd');
    IF @var14 IS NOT NULL EXEC(N'ALTER TABLE [Questionnaire] DROP CONSTRAINT [' + @var14 + '];');
    ALTER TABLE [Questionnaire] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var15 sysname;
    SELECT @var15 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PastoralMeetingUser]') AND [c].[name] = N'StatusCd');
    IF @var15 IS NOT NULL EXEC(N'ALTER TABLE [PastoralMeetingUser] DROP CONSTRAINT [' + @var15 + '];');
    ALTER TABLE [PastoralMeetingUser] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var16 sysname;
    SELECT @var16 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PastoralMeeting]') AND [c].[name] = N'StatusCd');
    IF @var16 IS NOT NULL EXEC(N'ALTER TABLE [PastoralMeeting] DROP CONSTRAINT [' + @var16 + '];');
    ALTER TABLE [PastoralMeeting] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var17 sysname;
    SELECT @var17 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Pastoral]') AND [c].[name] = N'StatusCd');
    IF @var17 IS NOT NULL EXEC(N'ALTER TABLE [Pastoral] DROP CONSTRAINT [' + @var17 + '];');
    ALTER TABLE [Pastoral] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var18 sysname;
    SELECT @var18 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[OrganizationUser]') AND [c].[name] = N'StatusCd');
    IF @var18 IS NOT NULL EXEC(N'ALTER TABLE [OrganizationUser] DROP CONSTRAINT [' + @var18 + '];');
    ALTER TABLE [OrganizationUser] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    ALTER TABLE [Organization] ADD [StatusCd] nvarchar(max) NULL DEFAULT N'1';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'StatusCd';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var19 sysname;
    SELECT @var19 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistrySchedualDetail]') AND [c].[name] = N'StatusCd');
    IF @var19 IS NOT NULL EXEC(N'ALTER TABLE [MinistrySchedualDetail] DROP CONSTRAINT [' + @var19 + '];');
    ALTER TABLE [MinistrySchedualDetail] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var20 sysname;
    SELECT @var20 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistrySchedual]') AND [c].[name] = N'StatusCd');
    IF @var20 IS NOT NULL EXEC(N'ALTER TABLE [MinistrySchedual] DROP CONSTRAINT [' + @var20 + '];');
    ALTER TABLE [MinistrySchedual] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var21 sysname;
    SELECT @var21 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistryRespUser]') AND [c].[name] = N'StatusCd');
    IF @var21 IS NOT NULL EXEC(N'ALTER TABLE [MinistryRespUser] DROP CONSTRAINT [' + @var21 + '];');
    ALTER TABLE [MinistryRespUser] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var22 sysname;
    SELECT @var22 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistryResp]') AND [c].[name] = N'StatusCd');
    IF @var22 IS NOT NULL EXEC(N'ALTER TABLE [MinistryResp] DROP CONSTRAINT [' + @var22 + '];');
    ALTER TABLE [MinistryResp] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var23 sysname;
    SELECT @var23 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistryDef]') AND [c].[name] = N'StatusCd');
    IF @var23 IS NOT NULL EXEC(N'ALTER TABLE [MinistryDef] DROP CONSTRAINT [' + @var23 + '];');
    ALTER TABLE [MinistryDef] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var24 sysname;
    SELECT @var24 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Ministry]') AND [c].[name] = N'StatusCd');
    IF @var24 IS NOT NULL EXEC(N'ALTER TABLE [Ministry] DROP CONSTRAINT [' + @var24 + '];');
    ALTER TABLE [Ministry] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var25 sysname;
    SELECT @var25 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseTimeSchedualUser]') AND [c].[name] = N'StatusCd');
    IF @var25 IS NOT NULL EXEC(N'ALTER TABLE [CourseTimeSchedualUser] DROP CONSTRAINT [' + @var25 + '];');
    ALTER TABLE [CourseTimeSchedualUser] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var26 sysname;
    SELECT @var26 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseTimeSchedualTeacher]') AND [c].[name] = N'StatusCd');
    IF @var26 IS NOT NULL EXEC(N'ALTER TABLE [CourseTimeSchedualTeacher] DROP CONSTRAINT [' + @var26 + '];');
    ALTER TABLE [CourseTimeSchedualTeacher] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var27 sysname;
    SELECT @var27 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseTimeSchedual]') AND [c].[name] = N'StatusCd');
    IF @var27 IS NOT NULL EXEC(N'ALTER TABLE [CourseTimeSchedual] DROP CONSTRAINT [' + @var27 + '];');
    ALTER TABLE [CourseTimeSchedual] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    ALTER TABLE [CoursePrice] ADD [StatusCd] nvarchar(max) NULL DEFAULT N'1';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CoursePrice', 'COLUMN', N'StatusCd';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var28 sysname;
    SELECT @var28 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagementType]') AND [c].[name] = N'StatusCd');
    IF @var28 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagementType] DROP CONSTRAINT [' + @var28 + '];');
    ALTER TABLE [CourseManagementType] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var29 sysname;
    SELECT @var29 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagementFilterResp]') AND [c].[name] = N'StatusCd');
    IF @var29 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagementFilterResp] DROP CONSTRAINT [' + @var29 + '];');
    ALTER TABLE [CourseManagementFilterResp] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var30 sysname;
    SELECT @var30 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagementFilterPastoral]') AND [c].[name] = N'StatusCd');
    IF @var30 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagementFilterPastoral] DROP CONSTRAINT [' + @var30 + '];');
    ALTER TABLE [CourseManagementFilterPastoral] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var31 sysname;
    SELECT @var31 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagementFilterCourse]') AND [c].[name] = N'StatusCd');
    IF @var31 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagementFilterCourse] DROP CONSTRAINT [' + @var31 + '];');
    ALTER TABLE [CourseManagementFilterCourse] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var32 sysname;
    SELECT @var32 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagementFilter]') AND [c].[name] = N'StatusCd');
    IF @var32 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagementFilter] DROP CONSTRAINT [' + @var32 + '];');
    ALTER TABLE [CourseManagementFilter] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var33 sysname;
    SELECT @var33 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagementAppendix]') AND [c].[name] = N'StatusCd');
    IF @var33 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagementAppendix] DROP CONSTRAINT [' + @var33 + '];');
    ALTER TABLE [CourseManagementAppendix] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var34 sysname;
    SELECT @var34 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagement]') AND [c].[name] = N'StatusCd');
    IF @var34 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagement] DROP CONSTRAINT [' + @var34 + '];');
    ALTER TABLE [CourseManagement] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var35 sysname;
    SELECT @var35 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseAppendix]') AND [c].[name] = N'StatusCd');
    IF @var35 IS NOT NULL EXEC(N'ALTER TABLE [CourseAppendix] DROP CONSTRAINT [' + @var35 + '];');
    ALTER TABLE [CourseAppendix] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    DECLARE @var36 sysname;
    SELECT @var36 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'StatusCd');
    IF @var36 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var36 + '];');
    ALTER TABLE [Course] ADD DEFAULT N'1' FOR [StatusCd];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221006122357_ModifyColumnStatusCDDefault')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221006122357_ModifyColumnStatusCDDefault', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221007041600_AddShoppingCartAndOrder')
BEGIN
    CREATE TABLE [ShoppingCart] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [CourseId] bigint NOT NULL,
        [Count] int NOT NULL,
        [ShoppingCartStatus] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_ShoppingCart] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'UserId';
    SET @description = N'CourseId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'CourseId';
    SET @description = N'Count';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'Count';
    SET @description = N'ShoppingCartStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'ShoppingCartStatus';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingCart', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221007041600_AddShoppingCartAndOrder')
BEGIN
    CREATE TABLE [ShoppingOrder] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [TotalAmount] int NOT NULL,
        [PaymentAmount] int NOT NULL,
        [RefundAmount] int NOT NULL,
        [OrderPayStatus] nvarchar(32) NULL,
        [PaymentTransactionNo] nvarchar(200) NULL,
        [PaymentTransactionDate] datetime2 NOT NULL,
        [PaymentTransactionDescription] nvarchar(200) NULL,
        [PaymentType] nvarchar(32) NULL,
        [RefundTransactionNo] nvarchar(200) NULL,
        [RefundTransactionDate] datetime2 NOT NULL,
        [RefundType] nvarchar(32) NULL,
        [RefundDescription] nvarchar(200) NULL,
        [OrderStatus] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_ShoppingOrder] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'UserId';
    SET @description = N'TotalAmount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'TotalAmount';
    SET @description = N'PaymentAmount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'PaymentAmount';
    SET @description = N'RefundAmount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'RefundAmount';
    SET @description = N'OrderPayStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'OrderPayStatus';
    SET @description = N'PaymentTransactionNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'PaymentTransactionNo';
    SET @description = N'PaymentTransactionDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'PaymentTransactionDate';
    SET @description = N'PaymentTransactionDescription';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'PaymentTransactionDescription';
    SET @description = N'PaymentType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'PaymentType';
    SET @description = N'RefundTransactionNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'RefundTransactionNo';
    SET @description = N'RefundTransactionDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'RefundTransactionDate';
    SET @description = N'RefundType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'RefundType';
    SET @description = N'RefundDescription';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'RefundDescription';
    SET @description = N'OrderStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'OrderStatus';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221007041600_AddShoppingCartAndOrder')
BEGIN
    CREATE TABLE [ShoppingOrderDetail] (
        [Id] bigint NOT NULL IDENTITY,
        [ShoppingOrderId] bigint NOT NULL,
        [CourseId] bigint NOT NULL,
        [Price] int NOT NULL,
        [Count] int NOT NULL,
        [Amount] int NOT NULL,
        [OrderDetailStatus] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_ShoppingOrderDetail] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'Id';
    SET @description = N'ShoppingOrderId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'ShoppingOrderId';
    SET @description = N'CourseId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'CourseId';
    SET @description = N'Price';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'Price';
    SET @description = N'Count';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'Count';
    SET @description = N'Amount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'Amount';
    SET @description = N'OrderDetailStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'OrderDetailStatus';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrderDetail', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221007041600_AddShoppingCartAndOrder')
BEGIN
    CREATE INDEX [IX_ShoppingCart_DateCreate_UserCreate_HandledId] ON [ShoppingCart] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221007041600_AddShoppingCartAndOrder')
BEGIN
    CREATE INDEX [IX_ShoppingOrder_DateCreate_UserCreate_HandledId] ON [ShoppingOrder] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221007041600_AddShoppingCartAndOrder')
BEGIN
    CREATE INDEX [IX_ShoppingOrderDetail_DateCreate_UserCreate_HandledId] ON [ShoppingOrderDetail] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221007041600_AddShoppingCartAndOrder')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221007041600_AddShoppingCartAndOrder', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009113129_ModifyColumnBirthday')
BEGIN
    DECLARE @var37 sysname;
    SELECT @var37 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'PastoralId');
    IF @var37 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var37 + '];');
    ALTER TABLE [User] ALTER COLUMN [PastoralId] bigint NOT NULL;
    ALTER TABLE [User] ADD DEFAULT CAST(0 AS bigint) FOR [PastoralId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009113129_ModifyColumnBirthday')
BEGIN
    DECLARE @var38 sysname;
    SELECT @var38 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'Birthday');
    IF @var38 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var38 + '];');
    ALTER TABLE [User] ALTER COLUMN [Birthday] datetime2 NOT NULL;
    ALTER TABLE [User] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [Birthday];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009113129_ModifyColumnBirthday')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221009113129_ModifyColumnBirthday', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    DROP TABLE [CourseTimeSchedual];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    DROP TABLE [CourseTimeSchedualTeacher];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    DROP TABLE [CourseTimeSchedualUser];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    DROP TABLE [MinistrySchedualDetail];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    DROP TABLE [MinistrySchedual];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE TABLE [CourseTimeSchedule] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseId] bigint NOT NULL,
        [ScheduleNo] nvarchar(32) NULL,
        [ClassDay] nvarchar(32) NULL,
        [ClassTimeS] nvarchar(32) NULL,
        [ClassTimeE] nvarchar(32) NULL,
        [Place] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseTimeSchedule] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'Id';
    SET @description = N'CourseId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'CourseId';
    SET @description = N'ScheduleNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'ScheduleNo';
    SET @description = N'ClassDay';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'ClassDay';
    SET @description = N'ClassTimeS';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'ClassTimeS';
    SET @description = N'ClassTimeE';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'ClassTimeE';
    SET @description = N'Place';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'Place';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeSchedule', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE TABLE [CourseTimeScheduleTeacher] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseTimeScheduleId] bigint NOT NULL,
        [ScheduleNo] nvarchar(32) NULL,
        [TeacherId] bigint NOT NULL,
        [AttendanceType] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseTimeScheduleTeacher] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'Id';
    SET @description = N'CourseTimeScheduleId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'CourseTimeScheduleId';
    SET @description = N'ScheduleNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'ScheduleNo';
    SET @description = N'TeacherId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'TeacherId';
    SET @description = N'AttendanceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'AttendanceType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleTeacher', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE TABLE [CourseTimeScheduleUser] (
        [Id] bigint NOT NULL IDENTITY,
        [CourseTimeScheduleId] bigint NOT NULL,
        [ScheduleNo] nvarchar(32) NULL,
        [AttendanceType] nvarchar(32) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_CourseTimeScheduleUser] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'Id';
    SET @description = N'CourseTimeScheduleId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'CourseTimeScheduleId';
    SET @description = N'ScheduleNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'ScheduleNo';
    SET @description = N'AttendanceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'AttendanceType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseTimeScheduleUser', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE TABLE [MinistrySchedule] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryId] bigint NOT NULL,
        [Name] nvarchar(50) NULL,
        [CycleType] nvarchar(20) NULL,
        [RepeatTime] nvarchar(20) NULL,
        [RepeatTimeUnit] nvarchar(20) NULL,
        [EndDateType] nvarchar(20) NULL,
        [EndDate] nvarchar(50) NULL,
        [RepeaTimes] nvarchar(50) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [Comment] nvarchar(max) NULL,
        [IsActivated] int NOT NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistrySchedule] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'Id';
    SET @description = N'MinistryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'MinistryId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'Name';
    SET @description = N'CycleType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'CycleType';
    SET @description = N'RepeatTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'RepeatTime';
    SET @description = N'RepeatTimeUnit';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'RepeatTimeUnit';
    SET @description = N'EndDateType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'EndDateType';
    SET @description = N'EndDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'EndDate';
    SET @description = N'RepeaTimes';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'RepeaTimes';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'StatusCd';
    SET @description = N'Comment';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'Comment';
    SET @description = N'IsActivated';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'IsActivated';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistrySchedule', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE TABLE [MinistryScheduleDetail] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryScheduleId] bigint NOT NULL,
        [Name] nvarchar(50) NULL,
        [Description] nvarchar(50) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistryScheduleDetail] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_MinistryScheduleDetail_MinistrySchedule_MinistryScheduleId] FOREIGN KEY ([MinistryScheduleId]) REFERENCES [MinistrySchedule] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'Id';
    SET @description = N'MinistryScheduleId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'MinistryScheduleId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'Name';
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'Description';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryScheduleDetail', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE INDEX [IX_CourseTimeSchedule_DateCreate_UserCreate_HandledId] ON [CourseTimeSchedule] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE INDEX [IX_CourseTimeScheduleTeacher_DateCreate_UserCreate_HandledId] ON [CourseTimeScheduleTeacher] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE INDEX [IX_CourseTimeScheduleUser_DateCreate_UserCreate_HandledId] ON [CourseTimeScheduleUser] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE INDEX [IX_MinistrySchedule_DateCreate_UserCreate_HandledId] ON [MinistrySchedule] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE INDEX [IX_MinistryScheduleDetail_DateCreate_UserCreate_HandledId] ON [MinistryScheduleDetail] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    CREATE INDEX [IX_MinistryScheduleDetail_MinistryScheduleId] ON [MinistryScheduleDetail] ([MinistryScheduleId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221009224232_RenameColumnSchedule')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221009224232_RenameColumnSchedule', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010001043_ModifyColumnNameOfOid')
BEGIN
    DECLARE @var39 sysname;
    SELECT @var39 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Organization]') AND [c].[name] = N'Oid');
    IF @var39 IS NOT NULL EXEC(N'ALTER TABLE [Organization] DROP CONSTRAINT [' + @var39 + '];');
    ALTER TABLE [Organization] DROP COLUMN [Oid];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010001043_ModifyColumnNameOfOid')
BEGIN
    ALTER TABLE [Organization] ADD [UpperOrganizationId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'UpperOrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Organization', 'COLUMN', N'UpperOrganizationId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010001043_ModifyColumnNameOfOid')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010001043_ModifyColumnNameOfOid', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010004250_LowIncome')
BEGIN
    ALTER TABLE [User] ADD [LowIncome] nvarchar(max) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'LowIncome';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'User', 'COLUMN', N'LowIncome';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010004250_LowIncome')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010004250_LowIncome', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [CourseClassNum] nvarchar(32) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseClassNum';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'CourseClassNum';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [CourseHomeworkDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseHomeworkDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'CourseHomeworkDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [CourseManagementName] nvarchar(200) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseManagementName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'CourseManagementName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [CourseManagementNo] nvarchar(32) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseManagementNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'CourseManagementNo';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [CourseManagementTypeId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseManagementTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'CourseManagementTypeId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [CourseSeason] nvarchar(20) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseSeason';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'CourseSeason';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [CourseYear] nvarchar(20) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseYear';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'CourseYear';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [PortalId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'PortalId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [CourseManagement] ADD [CourseManagementNo] nvarchar(20) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseManagementNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'CourseManagementNo';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [CourseManagement] ADD [HomewokeDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'HomewokeDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'HomewokeDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    ALTER TABLE [Course] ADD [HomeworkDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'HomeworkDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Course', 'COLUMN', N'HomeworkDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010025305_ModifyColumnOfQui')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010025305_ModifyColumnOfQui', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010051041_QuiOfOrgId')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [OrganizationId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'OrganizationId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010051041_QuiOfOrgId')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010051041_QuiOfOrgId', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var40 sysname;
    SELECT @var40 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'CourseClassNum');
    IF @var40 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var40 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [CourseClassNum];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var41 sysname;
    SELECT @var41 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'CourseHomeworkDate');
    IF @var41 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var41 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [CourseHomeworkDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var42 sysname;
    SELECT @var42 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'CourseManagementName');
    IF @var42 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var42 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [CourseManagementName];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var43 sysname;
    SELECT @var43 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'CourseManagementNo');
    IF @var43 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var43 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [CourseManagementNo];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var44 sysname;
    SELECT @var44 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'CourseManagementTypeId');
    IF @var44 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var44 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [CourseManagementTypeId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var45 sysname;
    SELECT @var45 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'CourseSeason');
    IF @var45 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var45 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [CourseSeason];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var46 sysname;
    SELECT @var46 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'CourseYear');
    IF @var46 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var46 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [CourseYear];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var47 sysname;
    SELECT @var47 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'OrganizationId');
    IF @var47 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var47 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [OrganizationId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    DECLARE @var48 sysname;
    SELECT @var48 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'PortalId');
    IF @var48 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var48 + '];');
    ALTER TABLE [QuestionnaireDetail] DROP COLUMN [PortalId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [CourseClassNum] nvarchar(32) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseClassNum';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'CourseClassNum';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [CourseHomeworkDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseHomeworkDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'CourseHomeworkDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [CourseManagementName] nvarchar(200) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseManagementName';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'CourseManagementName';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [CourseManagementNo] nvarchar(32) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseManagementNo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'CourseManagementNo';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [CourseManagementTypeId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseManagementTypeId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'CourseManagementTypeId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [CourseSeason] nvarchar(20) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseSeason';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'CourseSeason';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [CourseYear] nvarchar(20) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'CourseYear';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'CourseYear';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [OrganizationId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'OrganizationId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'OrganizationId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    ALTER TABLE [Questionnaire] ADD [PortalId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'PortalId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'PortalId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010064101_ModifyColumnToMatser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010064101_ModifyColumnToMatser', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010134109_Add QuestionDescrptionCol')
BEGIN
    ALTER TABLE [Questionnaire] ADD [Description] nvarchar(500) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'Description';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010134109_Add QuestionDescrptionCol')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010134109_Add QuestionDescrptionCol', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010140947_ModifyColumnNameAndType')
BEGIN
    DECLARE @var49 sysname;
    SELECT @var49 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Questionnaire]') AND [c].[name] = N'PortalId');
    IF @var49 IS NOT NULL EXEC(N'ALTER TABLE [Questionnaire] DROP CONSTRAINT [' + @var49 + '];');
    ALTER TABLE [Questionnaire] DROP COLUMN [PortalId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010140947_ModifyColumnNameAndType')
BEGIN
    DECLARE @var50 sysname;
    SELECT @var50 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[QuestionnaireDetail]') AND [c].[name] = N'Sequence');
    IF @var50 IS NOT NULL EXEC(N'ALTER TABLE [QuestionnaireDetail] DROP CONSTRAINT [' + @var50 + '];');
    ALTER TABLE [QuestionnaireDetail] ALTER COLUMN [Sequence] int NOT NULL;
    ALTER TABLE [QuestionnaireDetail] ADD DEFAULT 0 FOR [Sequence];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010140947_ModifyColumnNameAndType')
BEGIN
    ALTER TABLE [QuestionnaireDetail] ADD [Description] nvarchar(500) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Description';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QuestionnaireDetail', 'COLUMN', N'Description';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010140947_ModifyColumnNameAndType')
BEGIN
    ALTER TABLE [Questionnaire] ADD [PastoralId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'PastoralId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'Questionnaire', 'COLUMN', N'PastoralId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010140947_ModifyColumnNameAndType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010140947_ModifyColumnNameAndType', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221010141646_Add QuestionDescrptionCol2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221010141646_Add QuestionDescrptionCol2', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011004916_AddColumnOfOrder')
BEGIN
    ALTER TABLE [ShoppingOrder] ADD [ActuallyAmount] int NOT NULL DEFAULT 0;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ActuallyAmount';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'ActuallyAmount';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011004916_AddColumnOfOrder')
BEGIN
    ALTER TABLE [ShoppingOrder] ADD [Receipt] nvarchar(200) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Receipt';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'Receipt';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011004916_AddColumnOfOrder')
BEGIN
    ALTER TABLE [ShoppingOrder] ADD [ReceivePersonId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ReceivePersonId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'ReceivePersonId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011004916_AddColumnOfOrder')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221011004916_AddColumnOfOrder', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011013558_ModifyColumnName2')
BEGIN
    DECLARE @var51 sysname;
    SELECT @var51 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[ShoppingOrder]') AND [c].[name] = N'ReceivePersonId');
    IF @var51 IS NOT NULL EXEC(N'ALTER TABLE [ShoppingOrder] DROP CONSTRAINT [' + @var51 + '];');
    ALTER TABLE [ShoppingOrder] DROP COLUMN [ReceivePersonId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011013558_ModifyColumnName2')
BEGIN
    ALTER TABLE [ShoppingOrder] ADD [ReceiveUserId] bigint NOT NULL DEFAULT CAST(0 AS bigint);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'ReceiveUserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'ShoppingOrder', 'COLUMN', N'ReceiveUserId';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011013558_ModifyColumnName2')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221011013558_ModifyColumnName2', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011054236_AddQrCode')
BEGIN
    DECLARE @var52 sysname;
    SELECT @var52 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserCourse]') AND [c].[name] = N'CourseId');
    IF @var52 IS NOT NULL EXEC(N'ALTER TABLE [UserCourse] DROP CONSTRAINT [' + @var52 + '];');
    ALTER TABLE [UserCourse] ALTER COLUMN [CourseId] bigint NOT NULL;
    ALTER TABLE [UserCourse] ADD DEFAULT CAST(0 AS bigint) FOR [CourseId];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011054236_AddQrCode')
BEGIN
    DECLARE @var53 sysname;
    SELECT @var53 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserCourse]') AND [c].[name] = N'AttendanceDate');
    IF @var53 IS NOT NULL EXEC(N'ALTER TABLE [UserCourse] DROP CONSTRAINT [' + @var53 + '];');
    ALTER TABLE [UserCourse] ALTER COLUMN [AttendanceDate] datetime2 NOT NULL;
    ALTER TABLE [UserCourse] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [AttendanceDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011054236_AddQrCode')
BEGIN
    CREATE TABLE [QrCode] (
        [Id] bigint NOT NULL IDENTITY,
        [RefferenceType] int NOT NULL,
        [RefferenceId] bigint NOT NULL,
        [UserId] bigint NOT NULL,
        [GenerateCode] nvarchar(500) NULL,
        [RegisterStatus] int NOT NULL,
        [RegisterTime] datetime2 NOT NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_QrCode] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'Id';
    SET @description = N'RefferenceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'RefferenceType';
    SET @description = N'RefferenceId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'RefferenceId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'UserId';
    SET @description = N'GenerateCode';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'GenerateCode';
    SET @description = N'RegisterStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'RegisterStatus';
    SET @description = N'RegisterTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'RegisterTime';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'QrCode', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011054236_AddQrCode')
BEGIN
    CREATE INDEX [IX_QrCode_DateCreate_UserCreate_HandledId] ON [QrCode] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221011054236_AddQrCode')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221011054236_AddQrCode', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    DROP TABLE [UserContract];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    DECLARE @var54 sysname;
    SELECT @var54 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MOD_MEMBER]') AND [c].[name] = N'IsContract');
    IF @var54 IS NOT NULL EXEC(N'ALTER TABLE [MOD_MEMBER] DROP CONSTRAINT [' + @var54 + '];');
    ALTER TABLE [MOD_MEMBER] DROP COLUMN [IsContract];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    ALTER TABLE [MOD_MEMBER] ADD [IsContact] bit NOT NULL DEFAULT CAST(0 AS bit);
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'IsContact';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MOD_MEMBER', 'COLUMN', N'IsContact';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    DECLARE @var55 sysname;
    SELECT @var55 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'OrganizationId');
    IF @var55 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var55 + '];');
    ALTER TABLE [Course] ALTER COLUMN [OrganizationId] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    DECLARE @var56 sysname;
    SELECT @var56 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[Course]') AND [c].[name] = N'CourseManagementId');
    IF @var56 IS NOT NULL EXEC(N'ALTER TABLE [Course] DROP CONSTRAINT [' + @var56 + '];');
    ALTER TABLE [Course] ALTER COLUMN [CourseManagementId] bigint NULL;
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    CREATE TABLE [UserContact] (
        [Id] bigint NOT NULL IDENTITY,
        [UserId] bigint NOT NULL,
        [Name] nvarchar(max) NULL,
        [Relative] nvarchar(max) NULL,
        [Phone] nvarchar(max) NULL,
        [Memo] nvarchar(max) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UserContact] PRIMARY KEY ([Id]),
        CONSTRAINT [FK_UserContact_User_UserId] FOREIGN KEY ([UserId]) REFERENCES [User] ([Id]) ON DELETE CASCADE
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'Id';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'UserId';
    SET @description = N'Name';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'Name';
    SET @description = N'Relative';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'Relative';
    SET @description = N'Phone';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'Phone';
    SET @description = N'Memo';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'Memo';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserContact', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    CREATE INDEX [IX_UserContact_DateCreate_UserCreate_HandledId] ON [UserContact] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    CREATE INDEX [IX_UserContact_UserId] ON [UserContact] ([UserId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012062937_ReNameTableUserContractToContact')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221012062937_ReNameTableUserContractToContact', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012072533_RemoveUserCol')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221012072533_RemoveUserCol', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    DECLARE @var57 sysname;
    SELECT @var57 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'Account');
    IF @var57 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var57 + '];');
    ALTER TABLE [User] DROP COLUMN [Account];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    DECLARE @var58 sysname;
    SELECT @var58 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'IsAdmin');
    IF @var58 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var58 + '];');
    ALTER TABLE [User] DROP COLUMN [IsAdmin];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    DECLARE @var59 sysname;
    SELECT @var59 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[User]') AND [c].[name] = N'Roles');
    IF @var59 IS NOT NULL EXEC(N'ALTER TABLE [User] DROP CONSTRAINT [' + @var59 + '];');
    ALTER TABLE [User] DROP COLUMN [Roles];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    CREATE TABLE [MinistryMeeting] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryId] bigint NOT NULL,
        [MeetingDayOfWeek] nvarchar(36) NULL,
        [MeetingTime] nvarchar(36) NULL,
        [MeetingAddress] nvarchar(36) NULL,
        [MeetingDay] nvarchar(36) NULL,
        [IsExp] nvarchar(36) NULL,
        [IsSearchable] nvarchar(36) NULL,
        [MeetType] nvarchar(36) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistryMeeting] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'Id';
    SET @description = N'MinistryId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'MinistryId';
    SET @description = N'MeetingDayOfWeek';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'MeetingDayOfWeek';
    SET @description = N'MeetingTime';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'MeetingTime';
    SET @description = N'MeetingAddress';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'MeetingAddress';
    SET @description = N'MeetingDay';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'MeetingDay';
    SET @description = N'IsExp';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'IsExp';
    SET @description = N'IsSearchable';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'IsSearchable';
    SET @description = N'MeetType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'MeetType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeeting', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    CREATE TABLE [MinistryMeetingUser] (
        [Id] bigint NOT NULL IDENTITY,
        [MinistryMeetingId] bigint NOT NULL,
        [UserId] bigint NOT NULL,
        [MeetAttendanceType] nvarchar(36) NULL,
        [StatusCd] nvarchar(max) NULL DEFAULT N'1',
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_MinistryMeetingUser] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'Id';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'Id';
    SET @description = N'MinistryMeetingId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'MinistryMeetingId';
    SET @description = N'UserId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'UserId';
    SET @description = N'MeetAttendanceType';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'MeetAttendanceType';
    SET @description = N'StatusCd';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'StatusCd';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryMeetingUser', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    CREATE INDEX [IX_MinistryMeeting_DateCreate_UserCreate_HandledId] ON [MinistryMeeting] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    CREATE INDEX [IX_MinistryMeetingUser_DateCreate_UserCreate_HandledId] ON [MinistryMeetingUser] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221012122440_AddMinistryMeetingAndUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221012122440_AddMinistryMeetingAndUser', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013105152_addColumnOfRespUser')
BEGIN
    ALTER TABLE [MinistryRespUser] ADD [MinistryRespUserStatus] nvarchar(20) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'MinistryRespUserStatus';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'MinistryRespUser', 'COLUMN', N'MinistryRespUserStatus';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013105152_addColumnOfRespUser')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221013105152_addColumnOfRespUser', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013143159_ReNameCol')
BEGIN
    DECLARE @var60 sysname;
    SELECT @var60 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[UserPastoralCare]') AND [c].[name] = N'CareIdentityType');
    IF @var60 IS NOT NULL EXEC(N'ALTER TABLE [UserPastoralCare] DROP CONSTRAINT [' + @var60 + '];');
    ALTER TABLE [UserPastoralCare] DROP COLUMN [CareIdentityType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013143159_ReNameCol')
BEGIN
    ALTER TABLE [UserPastoralCare] ADD [PastoralTitle] nvarchar(50) NULL;
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'PastoralTitle';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UserPastoralCare', 'COLUMN', N'PastoralTitle';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013143159_ReNameCol')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221013143159_ReNameCol', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013234832_ModifyColumnType')
BEGIN
    DECLARE @var61 sysname;
    SELECT @var61 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PastoralMeeting]') AND [c].[name] = N'MeetingDay');
    IF @var61 IS NOT NULL EXEC(N'ALTER TABLE [PastoralMeeting] DROP CONSTRAINT [' + @var61 + '];');
    ALTER TABLE [PastoralMeeting] ALTER COLUMN [MeetingDay] datetime2 NOT NULL;
    ALTER TABLE [PastoralMeeting] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [MeetingDay];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013234832_ModifyColumnType')
BEGIN
    DECLARE @var62 sysname;
    SELECT @var62 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistryMeeting]') AND [c].[name] = N'MeetingDay');
    IF @var62 IS NOT NULL EXEC(N'ALTER TABLE [MinistryMeeting] DROP CONSTRAINT [' + @var62 + '];');
    ALTER TABLE [MinistryMeeting] ALTER COLUMN [MeetingDay] datetime2 NOT NULL;
    ALTER TABLE [MinistryMeeting] ADD DEFAULT '0001-01-01T00:00:00.0000000' FOR [MeetingDay];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221013234832_ModifyColumnType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221013234832_ModifyColumnType', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014025151_ModifyColType')
BEGIN
    DECLARE @var63 sysname;
    SELECT @var63 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[CourseManagement]') AND [c].[name] = N'HomewokeDate');
    IF @var63 IS NOT NULL EXEC(N'ALTER TABLE [CourseManagement] DROP CONSTRAINT [' + @var63 + '];');
    ALTER TABLE [CourseManagement] DROP COLUMN [HomewokeDate];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014025151_ModifyColType')
BEGIN
    DECLARE @var64 sysname;
    SELECT @var64 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[PastoralMeetingUser]') AND [c].[name] = N'MeetAttendanceType');
    IF @var64 IS NOT NULL EXEC(N'ALTER TABLE [PastoralMeetingUser] DROP CONSTRAINT [' + @var64 + '];');
    ALTER TABLE [PastoralMeetingUser] ALTER COLUMN [MeetAttendanceType] int NOT NULL;
    ALTER TABLE [PastoralMeetingUser] ADD DEFAULT 0 FOR [MeetAttendanceType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014025151_ModifyColType')
BEGIN
    DECLARE @var65 sysname;
    SELECT @var65 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistryRespUser]') AND [c].[name] = N'MinistryRespUserStatus');
    IF @var65 IS NOT NULL EXEC(N'ALTER TABLE [MinistryRespUser] DROP CONSTRAINT [' + @var65 + '];');
    ALTER TABLE [MinistryRespUser] ALTER COLUMN [MinistryRespUserStatus] int NOT NULL;
    ALTER TABLE [MinistryRespUser] ADD DEFAULT 0 FOR [MinistryRespUserStatus];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014025151_ModifyColType')
BEGIN
    DECLARE @var66 sysname;
    SELECT @var66 = [d].[name]
    FROM [sys].[default_constraints] [d]
    INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
    WHERE ([d].[parent_object_id] = OBJECT_ID(N'[MinistryMeetingUser]') AND [c].[name] = N'MeetAttendanceType');
    IF @var66 IS NOT NULL EXEC(N'ALTER TABLE [MinistryMeetingUser] DROP CONSTRAINT [' + @var66 + '];');
    ALTER TABLE [MinistryMeetingUser] ALTER COLUMN [MeetAttendanceType] int NOT NULL;
    ALTER TABLE [MinistryMeetingUser] ADD DEFAULT 0 FOR [MeetAttendanceType];
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014025151_ModifyColType')
BEGIN
    ALTER TABLE [CourseManagement] ADD [HomeworkDate] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'HomeworkDate';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'CourseManagement', 'COLUMN', N'HomeworkDate';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014025151_ModifyColType')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221014025151_ModifyColType', N'6.0.8');
END;
GO

COMMIT;
GO

BEGIN TRANSACTION;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014072857_AddUploadFile')
BEGIN
    CREATE TABLE [UploadFile] (
        [Id] bigint NOT NULL IDENTITY,
        [FileKey] uniqueidentifier NOT NULL,
        [OwnerEntity] varchar(32) NULL,
        [Filename] nvarchar(64) NULL,
        [FileExtension] nvarchar(16) NULL,
        [RelativeFilepath] nvarchar(256) NULL,
        [FileSize] bigint NOT NULL,
        [Bound] bit NOT NULL,
        [HandledId] uniqueidentifier NULL,
        [DateCreate] datetime2 NOT NULL DEFAULT (GetDate()),
        [UserCreate] varchar(255) NULL,
        [DateUpdate] datetime2 NULL DEFAULT (GetDate()),
        [UserUpdate] varchar(255) NULL,
        [RowVersion] varbinary(max) NULL,
        CONSTRAINT [PK_UploadFile] PRIMARY KEY ([Id])
    );
    DECLARE @defaultSchema AS sysname;
    SET @defaultSchema = SCHEMA_NAME();
    DECLARE @description AS sql_variant;
    SET @description = N'檔案上傳';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile';
    SET @description = N'';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'Id';
    SET @description = N'供 Owner 綁定 key';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'FileKey';
    SET @description = N'擁有者關聯 table';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'OwnerEntity';
    SET @description = N'檔名';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'Filename';
    SET @description = N'副檔名';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'FileExtension';
    SET @description = N'檔案存放相對路徑';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'RelativeFilepath';
    SET @description = N'檔案大小 (bit)';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'FileSize';
    SET @description = N'是否已綁定';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'Bound';
    SET @description = N'ApiHandledId';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'HandledId';
    SET @description = N'建立日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'DateCreate';
    SET @description = N'建立人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'UserCreate';
    SET @description = N'最後修改日期';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'DateUpdate';
    SET @description = N'最後修改人員';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'UserUpdate';
    SET @description = N'RowVersion';
    EXEC sp_addextendedproperty 'MS_Description', @description, 'SCHEMA', @defaultSchema, 'TABLE', N'UploadFile', 'COLUMN', N'RowVersion';
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014072857_AddUploadFile')
BEGIN
    CREATE INDEX [IX_UploadFile_DateCreate_UserCreate_HandledId] ON [UploadFile] ([DateCreate], [UserCreate], [HandledId]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014072857_AddUploadFile')
BEGIN
    CREATE UNIQUE INDEX [IX_UploadFile_FileKey] ON [UploadFile] ([FileKey]);
END;
GO

IF NOT EXISTS(SELECT * FROM [__EFMigrationsHistory] WHERE [MigrationId] = N'20221014072857_AddUploadFile')
BEGIN
    INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
    VALUES (N'20221014072857_AddUploadFile', N'6.0.8');
END;
GO

COMMIT;
GO

