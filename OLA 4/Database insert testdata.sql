INSERT INTO Trailer (Location, IsAvailable) VALUES ('Fog, Firskovvej 20, 2800 Kongens Lyngby', 1);
INSERT INTO Trailer (Location, IsAvailable) VALUES ('Fog, Firskovvej 20, 2800 Kongens Lyngby', 1);
INSERT INTO Trailer (Location, IsAvailable) VALUES ('Fog, Firskovvej 20, 2800 Kongens Lyngby', 1);
INSERT INTO Trailer (Location, IsAvailable) VALUES ('Fog, Firskovvej 20, 2800 Kongens Lyngby', 1);
INSERT INTO Trailer (Location, IsAvailable) VALUES ('Bauhaus, Turbinevej 4, 2860 Søborg', 1);
INSERT INTO Trailer (Location, IsAvailable) VALUES ('Bauhaus, Turbinevej 4, 2860 Søborg', 1);
INSERT INTO Trailer (Location, IsAvailable) VALUES ('Bauhaus, Turbinevej 4, 2860 Søborg', 1);

INSERT INTO Rental (TrailerID, StartTime, EndTime, InsurancePurchased, IsLate) VALUES (1, '2024-10-07 08:30:00.000', '2024-10-07 16:30:00.000', 1, 0);
INSERT INTO Rental (TrailerID, StartTime, EndTime, InsurancePurchased, IsLate) VALUES (5, '2024-10-07 09:30:00.000', '2024-10-07 00:30:00.000', 0, 1);

INSERT INTO Payment (RentalID, InsuranceFee, LateFee) VALUES (1, 50, 0);
INSERT INTO Payment (RentalID, InsuranceFee, LateFee) VALUES (2, 0, 25);