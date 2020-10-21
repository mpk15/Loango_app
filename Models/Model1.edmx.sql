
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/18/2020 15:09:15
-- Generated from EDMX file: C:\Users\KATIKA-\source\repos\Loango\Models\Model1.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Livres];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'USERSet'
CREATE TABLE [dbo].[USERSet] (
    [Id_user] int IDENTITY(1,1) NOT NULL,
    [nom_user] nvarchar(max)  NOT NULL,
    [prenom_user] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LIVRESet'
CREATE TABLE [dbo].[LIVRESet] (
    [Id_livre] int IDENTITY(1,1) NOT NULL,
    [titre_livre] nvarchar(max)  NOT NULL,
    [USERId_user] int  NULL
);
GO

-- Creating table 'EMPRUNTSet'
CREATE TABLE [dbo].[EMPRUNTSet] (
    [Id] int IDENTITY(1,1) NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id_user] in table 'USERSet'
ALTER TABLE [dbo].[USERSet]
ADD CONSTRAINT [PK_USERSet]
    PRIMARY KEY CLUSTERED ([Id_user] ASC);
GO

-- Creating primary key on [Id_livre] in table 'LIVRESet'
ALTER TABLE [dbo].[LIVRESet]
ADD CONSTRAINT [PK_LIVRESet]
    PRIMARY KEY CLUSTERED ([Id_livre] ASC);
GO

-- Creating primary key on [Id] in table 'EMPRUNTSet'
ALTER TABLE [dbo].[EMPRUNTSet]
ADD CONSTRAINT [PK_EMPRUNTSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [USERId_user] in table 'LIVRESet'
ALTER TABLE [dbo].[LIVRESet]
ADD CONSTRAINT [FK_USERLIVRE]
    FOREIGN KEY ([USERId_user])
    REFERENCES [dbo].[USERSet]
        ([Id_user])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_USERLIVRE'
CREATE INDEX [IX_FK_USERLIVRE]
ON [dbo].[LIVRESet]
    ([USERId_user]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------