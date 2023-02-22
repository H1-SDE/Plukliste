CREATE TABLE Lager (
    ProductID varchar(255) PRIMARY KEY,
    "Description" varchar(MAX),
	Amount int
);

INSERT INTO Lager (ProductID, "Description", Amount)
VALUES 
  ('TX-302587', 'Triax TD 241E stikdås', 72389),
  ('NETGEAR-CM1000', 'NETGEAR DOCSIS 3.1 (CM1000)', 856),
  ('COAX_CABEL_20M', 'Coax kabel rulle 20m', 612),
  ('F-CONN', 'F-connector 8mm', 976),
  ('830012', 'Papkasse 170x105x60', 401);