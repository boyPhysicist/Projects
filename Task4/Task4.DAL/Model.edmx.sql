
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2017 01:43:24
-- Generated from EDMX file: C:\Users\boyph\Source\Repos\Projects\Task4\Task4.DAL\Model.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SalesDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ClientSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleSet] DROP CONSTRAINT [FK_ClientSale];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleSet] DROP CONSTRAINT [FK_ManagerSale];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductSale]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleSet] DROP CONSTRAINT [FK_ProductSale];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ClientSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ClientSet];
GO
IF OBJECT_ID(N'[dbo].[ManagerSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ManagerSet];
GO
IF OBJECT_ID(N'[dbo].[ProductSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProductSet];
GO
IF OBJECT_ID(N'[dbo].[SaleSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[SaleSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ClientSets'
CREATE TABLE [dbo].[ClientSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ManagerSets'
CREATE TABLE [dbo].[ManagerSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductSets'
CREATE TABLE [dbo].[ProductSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Cost] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SaleSets'
CREATE TABLE [dbo].[SaleSets] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Data] nvarchar(max)  NOT NULL,
    [Manager_Id] int  NOT NULL,
    [Product_Id] int  NOT NULL,
    [Client_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClientSets'
ALTER TABLE [dbo].[ClientSets]
ADD CONSTRAINT [PK_ClientSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManagerSets'
ALTER TABLE [dbo].[ManagerSets]
ADD CONSTRAINT [PK_ManagerSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSets'
ALTER TABLE [dbo].[ProductSets]
ADD CONSTRAINT [PK_ProductSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SaleSets'
ALTER TABLE [dbo].[SaleSets]
ADD CONSTRAINT [PK_SaleSets]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Client_Id] in table 'SaleSets'
ALTER TABLE [dbo].[SaleSets]
ADD CONSTRAINT [FK_ClientSale]
    FOREIGN KEY ([Client_Id])
    REFERENCES [dbo].[ClientSets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientSale'
CREATE INDEX [IX_FK_ClientSale]
ON [dbo].[SaleSets]
    ([Client_Id]);
GO

-- Creating foreign key on [Manager_Id] in table 'SaleSets'
ALTER TABLE [dbo].[SaleSets]
ADD CONSTRAINT [FK_ManagerSale]
    FOREIGN KEY ([Manager_Id])
    REFERENCES [dbo].[ManagerSets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerSale'
CREATE INDEX [IX_FK_ManagerSale]
ON [dbo].[SaleSets]
    ([Manager_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'SaleSets'
ALTER TABLE [dbo].[SaleSets]
ADD CONSTRAINT [FK_ProductSale]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[ProductSets]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductSale'
CREATE INDEX [IX_FK_ProductSale]
ON [dbo].[SaleSets]
    ([Product_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------