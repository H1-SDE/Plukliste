--DROP TABLE [Lager].[dbo].[Ordre];DROP TABLE [Lager].[dbo].[Plukliste];DROP TABLE [Lager].[dbo].[Kunde]; DROP TABLE [Lager].[dbo].[Lager]; DROP TABLE [Lager].[dbo].[Options]

if not exists (select * from sysobjects where name='Lager' and xtype='U')
CREATE TABLE Lager (
    [ProductID] varchar(255) PRIMARY KEY,
    [Description] varchar(MAX),
	[Amount] int
);

if not exists (select * from sysobjects where name='Kunde' and xtype='U')
CREATE TABLE Kunde (
	[KundeID] int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Navn] varchar(255),
	[Adresse] varchar(255)
);

if not exists (select * from sysobjects where name='Plukliste' and xtype='U')
CREATE TABLE Plukliste (
	[FakturaNummer] int NOT NULL PRIMARY KEY,
	[KundeID] int FOREIGN KEY REFERENCES Kunde(KundeID),
	[Forsendelse] varchar(255),
	[Label] BIT,
	[Print] varchar(63)
);

if not exists (select * from sysobjects where name='Ordre' and xtype='U')
CREATE TABLE Ordre (
	[OrdreID] int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[ProductID] varchar(255) FOREIGN KEY REFERENCES Lager(ProductID),
	[FakturaNummer] int FOREIGN KEY REFERENCES Plukliste(FakturaNummer),
	[Antal] int
);

if not exists (select * from sysobjects where name='Options' and xtype='U')
CREATE TABLE [Options] (
	[Key] int NOT NULL IDENTITY(1, 1) PRIMARY KEY,
	[Carriers] varchar(255)  NOT NULL,
	[Print] varchar(255) NOT NULL
);