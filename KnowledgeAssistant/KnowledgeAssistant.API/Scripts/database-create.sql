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
CREATE TABLE [AIAnalyses] (
    [Id] int NOT NULL IDENTITY,
    [BusinessRecordId] int NOT NULL,
    [Summary] nvarchar(max) NOT NULL,
    [Classification] nvarchar(max) NOT NULL,
    [Recommendations] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_AIAnalyses] PRIMARY KEY ([Id])
);

CREATE TABLE [BusinessRecords] (
    [Id] int NOT NULL IDENTITY,
    [Title] nvarchar(max) NOT NULL,
    [Content] nvarchar(max) NOT NULL,
    [Department] nvarchar(max) NOT NULL,
    [CreatedAt] datetime2 NOT NULL,
    CONSTRAINT [PK_BusinessRecords] PRIMARY KEY ([Id])
);

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260609200020_InitialCreate', N'10.0.9');

COMMIT;
GO

BEGIN TRANSACTION;
ALTER TABLE [AIAnalyses] ADD [CreatedAt] datetime2 NOT NULL DEFAULT '0001-01-01T00:00:00.0000000';

CREATE INDEX [IX_AIAnalyses_BusinessRecordId] ON [AIAnalyses] ([BusinessRecordId]);

ALTER TABLE [AIAnalyses] ADD CONSTRAINT [FK_AIAnalyses_BusinessRecords_BusinessRecordId] FOREIGN KEY ([BusinessRecordId]) REFERENCES [BusinessRecords] ([Id]) ON DELETE CASCADE;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260609211011_AddAIAnalysisCreatedAt', N'10.0.9');

COMMIT;
GO

BEGIN TRANSACTION;
INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260610001953_ConfigureAIAnalysisRelation', N'10.0.9');

COMMIT;
GO

BEGIN TRANSACTION;
DECLARE @var nvarchar(max);
SELECT @var = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BusinessRecords]') AND [c].[name] = N'Title');
IF @var IS NOT NULL EXEC(N'ALTER TABLE [BusinessRecords] DROP CONSTRAINT ' + @var + ';');
ALTER TABLE [BusinessRecords] ALTER COLUMN [Title] nvarchar(100) NOT NULL;

DECLARE @var1 nvarchar(max);
SELECT @var1 = QUOTENAME([d].[name])
FROM [sys].[default_constraints] [d]
INNER JOIN [sys].[columns] [c] ON [d].[parent_column_id] = [c].[column_id] AND [d].[parent_object_id] = [c].[object_id]
WHERE ([d].[parent_object_id] = OBJECT_ID(N'[BusinessRecords]') AND [c].[name] = N'Department');
IF @var1 IS NOT NULL EXEC(N'ALTER TABLE [BusinessRecords] DROP CONSTRAINT ' + @var1 + ';');
ALTER TABLE [BusinessRecords] ALTER COLUMN [Department] nvarchar(50) NOT NULL;

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20260610141149_FinalModelValidationUpdates', N'10.0.9');

COMMIT;
GO

