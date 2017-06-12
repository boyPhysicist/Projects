
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 06/12/2017 23:51:37
-- Generated from EDMX file: C:\Users\boyph\Source\Repos\Projects\Task4(LastVersion)\Task4.Model\Model1.edmx
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

IF OBJECT_ID(N'[dbo].[FK_ClientEntity1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleSet] DROP CONSTRAINT [FK_ClientEntity1];
GO
IF OBJECT_ID(N'[dbo].[FK_ManagerEntity1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleSet] DROP CONSTRAINT [FK_ManagerEntity1];
GO
IF OBJECT_ID(N'[dbo].[FK_ProductEntity1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[SaleSet] DROP CONSTRAINT [FK_ProductEntity1];
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

-- Creating table 'ClientSet'
CREATE TABLE [dbo].[ClientSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ManagerSet'
CREATE TABLE [dbo].[ManagerSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProductSet'
CREATE TABLE [dbo].[ProductSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Coast] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'SaleSet'
CREATE TABLE [dbo].[SaleSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Date] nvarchar(max)  NOT NULL,
    [Client_Id] int  NOT NULL,
    [Manager_Id] int  NOT NULL,
    [Product_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'ClientSet'
ALTER TABLE [dbo].[ClientSet]
ADD CONSTRAINT [PK_ClientSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ManagerSet'
ALTER TABLE [dbo].[ManagerSet]
ADD CONSTRAINT [PK_ManagerSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProductSet'
ALTER TABLE [dbo].[ProductSet]
ADD CONSTRAINT [PK_ProductSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'SaleSet'
ALTER TABLE [dbo].[SaleSet]
ADD CONSTRAINT [PK_SaleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Client_Id] in table 'SaleSet'
ALTER TABLE [dbo].[SaleSet]
ADD CONSTRAINT [FK_ClientEntity1]
    FOREIGN KEY ([Client_Id])
    REFERENCES [dbo].[ClientSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientEntity1'
CREATE INDEX [IX_FK_ClientEntity1]
ON [dbo].[SaleSet]
    ([Client_Id]);
GO

-- Creating foreign key on [Manager_Id] in table 'SaleSet'
ALTER TABLE [dbo].[SaleSet]
ADD CONSTRAINT [FK_ManagerEntity1]
    FOREIGN KEY ([Manager_Id])
    REFERENCES [dbo].[ManagerSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ManagerEntity1'
CREATE INDEX [IX_FK_ManagerEntity1]
ON [dbo].[SaleSet]
    ([Manager_Id]);
GO

-- Creating foreign key on [Product_Id] in table 'SaleSet'
ALTER TABLE [dbo].[SaleSet]
ADD CONSTRAINT [FK_ProductEntity1]
    FOREIGN KEY ([Product_Id])
    REFERENCES [dbo].[ProductSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ProductEntity1'
CREATE INDEX [IX_FK_ProductEntity1]
ON [dbo].[SaleSet]
    ([Product_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------