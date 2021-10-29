
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/14/2019 08:52:35
-- Generated from EDMX file: D:\Dev\programmare_con_csharp8\Capitolo 16\ModelFirst\CarModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [CarDb];
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

-- Creating table 'CarSet'
CREATE TABLE [dbo].[CarSet] (
    [IdCar] int IDENTITY(1,1) NOT NULL,
    [Targa] nvarchar(max)  NULL,
    [Modello] nvarchar(max)  NOT NULL,
    [PersonIdPerson] int  NOT NULL
);
GO

-- Creating table 'PersonSet'
CREATE TABLE [dbo].[PersonSet] (
    [IdPerson] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [IdCar] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [PK_CarSet]
    PRIMARY KEY CLUSTERED ([IdCar] ASC);
GO

-- Creating primary key on [IdPerson] in table 'PersonSet'
ALTER TABLE [dbo].[PersonSet]
ADD CONSTRAINT [PK_PersonSet]
    PRIMARY KEY CLUSTERED ([IdPerson] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [PersonIdPerson] in table 'CarSet'
ALTER TABLE [dbo].[CarSet]
ADD CONSTRAINT [FK_PersonCar]
    FOREIGN KEY ([PersonIdPerson])
    REFERENCES [dbo].[PersonSet]
        ([IdPerson])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PersonCar'
CREATE INDEX [IX_FK_PersonCar]
ON [dbo].[CarSet]
    ([PersonIdPerson]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------