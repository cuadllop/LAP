
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 01/17/2017 10:38:48
-- Generated from EDMX file: C:\Users\jmcuadrado\documents\visual studio 2013\Projects\LAP\LAP\Models\Models.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [LAP_DDBB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_UserLoanRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoanRequests] DROP CONSTRAINT [FK_UserLoanRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_LoanTypeLoanRequest]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[LoanRequests] DROP CONSTRAINT [FK_LoanTypeLoanRequest];
GO
IF OBJECT_ID(N'[dbo].[FK_LoanRequestFormFields]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[FormFields] DROP CONSTRAINT [FK_LoanRequestFormFields];
GO
IF OBJECT_ID(N'[dbo].[FK_UserRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Users] DROP CONSTRAINT [FK_UserRole];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[LoanTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoanTypes];
GO
IF OBJECT_ID(N'[dbo].[LoanRequests]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LoanRequests];
GO
IF OBJECT_ID(N'[dbo].[Users]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Users];
GO
IF OBJECT_ID(N'[dbo].[Roles]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Roles];
GO
IF OBJECT_ID(N'[dbo].[ScoreEngines]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ScoreEngines];
GO
IF OBJECT_ID(N'[dbo].[SystemConfigurations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SystemConfigurations];
GO
IF OBJECT_ID(N'[dbo].[FormFields]', 'U') IS NOT NULL
    DROP TABLE [dbo].[FormFields];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'LoanTypes'
CREATE TABLE [dbo].[LoanTypes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [AdditionalFields] nvarchar(max)  NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Fields] nvarchar(max)  NULL
);
GO

-- Creating table 'LoanRequests'
CREATE TABLE [dbo].[LoanRequests] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [SubmitDate] datetime  NOT NULL,
    [Status] int  NOT NULL,
    [LoanTypeId] int  NOT NULL,
    [Score] decimal(18,0)  NULL,
    [Amount] decimal(18,0)  NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- Creating table 'Users'
CREATE TABLE [dbo].[Users] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Email] nvarchar(max)  NOT NULL,
    [Role_Id] int  NOT NULL
);
GO

-- Creating table 'Roles'
CREATE TABLE [dbo].[Roles] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ScoreEngines'
CREATE TABLE [dbo].[ScoreEngines] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [LibName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SystemConfigurations'
CREATE TABLE [dbo].[SystemConfigurations] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Value] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'FormFields'
CREATE TABLE [dbo].[FormFields] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Text] nvarchar(max)  NOT NULL,
    [LoanRequestId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'LoanTypes'
ALTER TABLE [dbo].[LoanTypes]
ADD CONSTRAINT [PK_LoanTypes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LoanRequests'
ALTER TABLE [dbo].[LoanRequests]
ADD CONSTRAINT [PK_LoanRequests]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [PK_Users]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Roles'
ALTER TABLE [dbo].[Roles]
ADD CONSTRAINT [PK_Roles]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ScoreEngines'
ALTER TABLE [dbo].[ScoreEngines]
ADD CONSTRAINT [PK_ScoreEngines]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SystemConfigurations'
ALTER TABLE [dbo].[SystemConfigurations]
ADD CONSTRAINT [PK_SystemConfigurations]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'FormFields'
ALTER TABLE [dbo].[FormFields]
ADD CONSTRAINT [PK_FormFields]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [User_Id] in table 'LoanRequests'
ALTER TABLE [dbo].[LoanRequests]
ADD CONSTRAINT [FK_UserLoanRequest]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[Users]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_UserLoanRequest'
CREATE INDEX [IX_FK_UserLoanRequest]
ON [dbo].[LoanRequests]
    ([User_Id]);
GO

-- Creating foreign key on [LoanTypeId] in table 'LoanRequests'
ALTER TABLE [dbo].[LoanRequests]
ADD CONSTRAINT [FK_LoanTypeLoanRequest]
    FOREIGN KEY ([LoanTypeId])
    REFERENCES [dbo].[LoanTypes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoanTypeLoanRequest'
CREATE INDEX [IX_FK_LoanTypeLoanRequest]
ON [dbo].[LoanRequests]
    ([LoanTypeId]);
GO

-- Creating foreign key on [LoanRequestId] in table 'FormFields'
ALTER TABLE [dbo].[FormFields]
ADD CONSTRAINT [FK_LoanRequestFormFields]
    FOREIGN KEY ([LoanRequestId])
    REFERENCES [dbo].[LoanRequests]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_LoanRequestFormFields'
CREATE INDEX [IX_FK_LoanRequestFormFields]
ON [dbo].[FormFields]
    ([LoanRequestId]);
GO

-- Creating foreign key on [Role_Id] in table 'Users'
ALTER TABLE [dbo].[Users]
ADD CONSTRAINT [FK_RoleUser]
    FOREIGN KEY ([Role_Id])
    REFERENCES [dbo].[Roles]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_RoleUser'
CREATE INDEX [IX_FK_RoleUser]
ON [dbo].[Users]
    ([Role_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------