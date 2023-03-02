DELETE FROM [Lager].[dbo].[Ordre];
DELETE FROM [Lager].[dbo].[Plukliste];
DELETE FROM [Lager].[dbo].[Kunde];
DELETE FROM [Lager].[dbo].[Lager];

DBCC CHECKIDENT ([Kunde], RESEED, 0);
DBCC CHECKIDENT ([Ordre], RESEED, 0);

INSERT INTO Kunde ([Navn], [Adresse]) VALUES 
  ('Philip Guldborg', 'JyllandOgAlbertslund 69'),
  ('Nima B', 'Øhavevej 4'),
  ('Navn3', 'Adresse 3');

INSERT INTO Lager ([ProductID], [Description], [Amount]) VALUES 
  ('TX-302587', 'Triax TD 241E stikdås', 72389),
  ('NETGEAR-CM1000', 'NETGEAR DOCSIS 3.1 (CM1000)', 856),
  ('COAX_CABEL_20M', 'Coax kabel rulle 20m', 612),
  ('F-CONN', 'F-connector 8mm', 976),
  ('#830012', 'Papkasse 170x105x60', 401);

INSERT INTO Plukliste ([FakturaNummer], [KundeID], [Forsendelse], [Label], [Print]) VALUES 
  ('2521523', 1, 'Post Nord', 0, 'PRINT-OPGRADE'),
  ('9468350', 2, 'GLS', 1, 'PRINT-OPSIGELSE');

INSERT INTO Ordre ([ProductID], [Antal], [FakturaNummer]) VALUES 
  ('TX-302587', 1, '2521523'),
  ('NETGEAR-CM1000', 5, '2521523'),
  ('COAX_CABEL_20M', 3, '9468350'),
  ('F-CONN', 2, '2521523'),
  ('#830012', 7, '9468350');

INSERT INTO [Options] ([Carriers], [Print]) VALUES 
  ('GLS', 'PRINT-OPGRADE'),
  ('Post Nord', 'PRINT-OPSIGELSE'),
  ('DAO', 'PRINT-WELCOME');

SELECT * FROM [Lager].[dbo].[Lager];
SELECT * FROM [Lager].[dbo].[Ordre];
SELECT * FROM [Lager].[dbo].[Plukliste];
SELECT * FROM [Lager].[dbo].[Kunde];