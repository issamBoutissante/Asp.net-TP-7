
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/04/2021 10:53:06
-- Generated from EDMX file: C:\Users\ISSAM\Desktop\Web Cote Serveur\TP\Asp.net MVC TP 7\Models\VentesModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Ventes];
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

-- Creating table 'Articles'
CREATE TABLE [dbo].[Articles] (
    [Num_Art] int IDENTITY(1,1) NOT NULL,
    [Nom_Art] nvarchar(max)  NOT NULL,
    [PU] decimal(18,0)  NOT NULL
);
GO

-- Creating table 'Clients'
CREATE TABLE [dbo].[Clients] (
    [Num_Clt] int IDENTITY(1,1) NOT NULL,
    [Nom_Clt] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Commandes'
CREATE TABLE [dbo].[Commandes] (
    [Num_Cmd] int IDENTITY(1,1) NOT NULL,
    [Date_Cmd] datetime  NOT NULL,
    [Num_Clt] int  NOT NULL
);
GO

-- Creating table 'LigneCommandes'
CREATE TABLE [dbo].[LigneCommandes] (
    [Qtt] int IDENTITY(1,1) NOT NULL,
    [Num_Cmd] int  NOT NULL,
    [Num_Art] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Num_Art] in table 'Articles'
ALTER TABLE [dbo].[Articles]
ADD CONSTRAINT [PK_Articles]
    PRIMARY KEY CLUSTERED ([Num_Art] ASC);
GO

-- Creating primary key on [Num_Clt] in table 'Clients'
ALTER TABLE [dbo].[Clients]
ADD CONSTRAINT [PK_Clients]
    PRIMARY KEY CLUSTERED ([Num_Clt] ASC);
GO

-- Creating primary key on [Num_Cmd] in table 'Commandes'
ALTER TABLE [dbo].[Commandes]
ADD CONSTRAINT [PK_Commandes]
    PRIMARY KEY CLUSTERED ([Num_Cmd] ASC);
GO

-- Creating primary key on [Num_Cmd], [Num_Art] in table 'LigneCommandes'
ALTER TABLE [dbo].[LigneCommandes]
ADD CONSTRAINT [PK_LigneCommandes]
    PRIMARY KEY CLUSTERED ([Num_Cmd], [Num_Art] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Num_Clt] in table 'Commandes'
ALTER TABLE [dbo].[Commandes]
ADD CONSTRAINT [FK_ClientCommande]
    FOREIGN KEY ([Num_Clt])
    REFERENCES [dbo].[Clients]
        ([Num_Clt])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ClientCommande'
CREATE INDEX [IX_FK_ClientCommande]
ON [dbo].[Commandes]
    ([Num_Clt]);
GO

-- Creating foreign key on [Num_Cmd] in table 'LigneCommandes'
ALTER TABLE [dbo].[LigneCommandes]
ADD CONSTRAINT [FK_CommandeLigneCommande]
    FOREIGN KEY ([Num_Cmd])
    REFERENCES [dbo].[Commandes]
        ([Num_Cmd])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Num_Art] in table 'LigneCommandes'
ALTER TABLE [dbo].[LigneCommandes]
ADD CONSTRAINT [FK_ArticleLigneCommande]
    FOREIGN KEY ([Num_Art])
    REFERENCES [dbo].[Articles]
        ([Num_Art])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ArticleLigneCommande'
CREATE INDEX [IX_FK_ArticleLigneCommande]
ON [dbo].[LigneCommandes]
    ([Num_Art]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------