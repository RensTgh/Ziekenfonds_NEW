BEGIN TRY

BEGIN TRANSACTION

-- Dummy Data for CustomUser/Persoon
--INSERT INTO dbo.Persoon (id, naam, voornaam, straat, huisnummer, gemeente, postcode, geboortedatum, huisdokter, contractNummer, email, isHoofdMonitor, telefoonNummer, rekeningNummer, isActief, AccessFailedCount)
--VALUES 
--('user1', 'Jansen', 'Pieter', 'Dorpsstraat', '12A', 'Utrecht', '1234AB', '1985-05-12', 'Dr. Bakker', 'CN123456', 'pieter.jansen@example.com', 1, '0612345678', 'NL91ABNA0417164300', 1, 0),
--('user2', 'De Vries', 'Anna', 'Kerkstraat', '8', 'Amsterdam', '1012WX', '1990-09-23', 'Dr. Smit', 'CN654321', 'anna.devries@example.com', 0, '0619876543', 'NL02INGB0001234507', 1, 0),
--('user3', 'Bakker', 'Sven', 'Markt', '22B', 'Rotterdam', '3012CW', '1975-03-18', 'Dr. Janssen', 'CN098765', 'sven.bakker@example.com', 0, '0612345679', 'NL02INGB0001234567', 0, 0),
--('user4', 'Kramer', 'Iris', 'Langeweg', '45', 'Den Haag', '2501BG', '1988-06-15', 'Dr. Bos', 'CN567890', 'iris.kramer@example.com', 1, '0619876544', 'NL03RABO0123456789', 1, 0);

INSERT INTO dbo.Persoon (
    Id, Naam, Voornaam, Straat, Huisnummer, Gemeente, Postcode, Geboortedatum, Huisdokter, ContractNummer, 
    Email, isHoofdMonitor, TelefoonNummer, RekeningNummer, IsActief, UserName, NormalizedUserName, 
    NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, 
    PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount
)
VALUES 
('user1', 'Jansen', 'Pieter', 'Dorpsstraat', '12A', 'Utrecht', '1234AB', '1985-05-12', 'Dr. Bakker', 'CN123456',
 'pieter.jansen@example.com', 1, '0612345678', 'NL91ABNA0417164300', 1, 'pieterjansen', 'PIETERJANSEN', 
 'PIETER.JANSEN@EXAMPLE.COM', 1, NULL, NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

('user2', 'De Vries', 'Anna', 'Kerkstraat', '8', 'Amsterdam', '1012WX', '1990-09-23', 'Dr. Smit', 'CN654321',
 'anna.devries@example.com', 0, '0619876543', 'NL02INGB0001234507', 1, 'annadevries', 'ANNADEVRIES', 
 'ANNA.DEVRIES@EXAMPLE.COM', 1, NULL, NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

('user3', 'Bakker', 'Sven', 'Markt', '22B', 'Rotterdam', '3012CW', '1975-03-18', 'Dr. Janssen', 'CN098765',
 'sven.bakker@example.com', 0, '0612345679', 'NL02INGB0001234567', 0, 'svenbakker', 'SVENBAKKER', 
 'SVEN.BAKKER@EXAMPLE.COM', 1, NULL, NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0),

('user4', 'Kramer', 'Iris', 'Langeweg', '45', 'Den Haag', '2501BG', '1988-06-15', 'Dr. Bos', 'CN567890',
 'iris.kramer@example.com', 1, '0619876544', 'NL03RABO0123456789', 1, 'iriskramer', 'IRISKRAMER', 
 'IRIS.KRAMER@EXAMPLE.COM', 1, NULL, NEWID(), NEWID(), NULL, 0, 0, NULL, 0, 0);

-- Dummy Data for Bestemming
SET IDENTITY_INSERT dbo.Bestemming ON;
INSERT INTO dbo.Bestemming (id, code, naam, beschrijving, minLeeftijd, maxLeeftijd)
VALUES
(1, 'ESP2024', 'Barcelona', 'Cultural trip to Barcelona.', 8, 15),
(2, 'ITA2024', 'Rome', 'Exploring the ancient city of Rome.', 10, 18),
(3, 'FRA2024', 'Paris', 'Visit to the Eiffel Tower and Louvre.', 12, 17),
(4, 'GER2024', 'Berlin', 'Historical tour in Berlin.', 14, 20);
SET IDENTITY_INSERT dbo.Bestemming OFF;

-- Dummy Data for Kind
SET IDENTITY_INSERT dbo.Kind ON;
INSERT INTO dbo.Kind (id, persoonId, naam, voornaam, geboortedatum, allergieën, medicatie)
VALUES
(1, 'user1', 'Jansen', 'Lucas', '2010-04-15', 'Pollen', 'Ventolin'),
(2, 'user2', 'De Vries', 'Sophie', '2012-07-20', NULL, NULL),
(3, 'user3', 'Bakker', 'Thomas', '2015-09-10', 'Peanuts', 'EpiPen'),
(4, 'user4', 'Kramer', 'Emma', '2011-12-01', NULL, NULL);
SET IDENTITY_INSERT dbo.Kind OFF;

-- Dummy Data for Groepsreis
SET IDENTITY_INSERT dbo.Groepsreis ON;
INSERT INTO dbo.Groepsreis (id, bestemmingId, begindatum, einddatum, prijs)
VALUES
(1, 1, '2024-07-01', '2024-07-15', 1200.50),
(2, 2, '2024-08-01', '2024-08-10', 950.00),
(3, 3, '2024-06-10', '2024-06-20', 1100.75),
(4, 4, '2024-09-05', '2024-09-15', 1300.00);
SET IDENTITY_INSERT dbo.Groepsreis OFF;

-- Dummy Data for Deelnemer
SET IDENTITY_INSERT dbo.Deelnemer ON;
INSERT INTO dbo.Deelnemer (id, kindId, groepsreisId, opmerking)
VALUES
(1, 1, 1, 'Needs extra assistance during trips'),
(2, 2, 1, 'No special notes'),
(3, 3, 2, 'Requires vegetarian meals'),
(4, 4, 3, 'Allergic to peanuts');
SET IDENTITY_INSERT dbo.Deelnemer OFF;

-- Dummy Data for Foto
SET IDENTITY_INSERT dbo.Foto ON;
INSERT INTO dbo.Foto (id, naam, bestemmingId)
VALUES
(1, 'Sagrada Familia', 1),
(2, 'Colosseum', 2),
(3, 'Eiffel Tower', 3),
(4, 'Brandenburg Gate', 4);
SET IDENTITY_INSERT dbo.Foto OFF;

-- Dummy Data for Activiteit
SET IDENTITY_INSERT dbo.Activiteit ON;
INSERT INTO dbo.Activiteit (id, naam, beschrijving)
VALUES
(1, 'Museum Tour', 'Visit to the National Museum of Art'),
(2, 'City Walk', 'Guided walking tour of the city center'),
(3, 'Cultural Night', 'Experience local culture through music and food'),
(4, 'Boat Ride', 'Relaxing ride on the city’s river');
SET IDENTITY_INSERT dbo.Activiteit OFF;

-- Dummy Data for Programma

INSERT INTO dbo.Programma (activiteitId, groepsreisId)
VALUES
(1, 1),
(2, 2),
(3, 3),
(4, 4);


-- Dummy Data for Monitor
SET IDENTITY_INSERT dbo.Monitors ON;
INSERT INTO dbo.Monitors (id, persoonId, groepsreisId, isHoofdMonitor)
VALUES
(1, 'user1', 1, 1),
(2, 'user2', 2, 0),
(3, 'user3', 3, 1),
(4, 'user4', 4, 0);
SET IDENTITY_INSERT dbo.Monitors OFF;

-- Dummy Data for Onkosten
SET IDENTITY_INSERT dbo.Onkosten ON;
INSERT INTO dbo.Onkosten (id, groepsreisId, titel, omschrijving, bedrag, datum, foto)
VALUES
(1, 1, 'Transport', 'Bus tickets to the airport', 350.75, '2024-06-30', 'bus_tickets.jpg'),
(2, 2, 'Accommodation', 'Hotel rooms in Rome', 800.00, '2024-08-01', 'hotel_receipt.jpg'),
(3, 3, 'Meals', 'Group meals during the trip', 450.00, '2024-06-11', 'meals_receipt.jpg'),
(4, 4, 'Guides', 'Local guides for activities', 200.00, '2024-09-06', 'guide_receipt.jpg');
SET IDENTITY_INSERT dbo.Onkosten OFF;

-- Dummy Data for Opleiding
SET IDENTITY_INSERT dbo.Opleiding ON;
INSERT INTO dbo.Opleiding (id, naam, beschrijving, begindatum, einddatum, aantalPlaatsen, opleidingVereist)
VALUES
(1, 'First Aid Training', 'Basic first aid skills', '2024-05-01', '2024-05-05', 20, NULL),
(2, 'Leadership Training', 'Team management skills', '2024-06-01', '2024-06-10', 15, 1),
(3, 'Conflict Resolution', 'Skills to handle conflicts', '2024-07-15', '2024-07-20', 10, 2),
(4, 'Event Management', 'Organizing large-scale events', '2024-08-05', '2024-08-10', 25, 2);
SET IDENTITY_INSERT dbo.Opleiding OFF;

-- Dummy Data for OpleidingPersoon
SET IDENTITY_INSERT dbo.[Opleiding Persoon] ON;
INSERT INTO dbo.[Opleiding Persoon] (id, opleidingId, persoonId)
VALUES
(1, 1, 'user1'),
(2, 2, 'user2'),
(3, 3, 'user3'),
(4, 4, 'user4');
SET IDENTITY_INSERT dbo.[Opleiding Persoon] OFF;

-- Dummy Data for Review
SET IDENTITY_INSERT dbo.Review ON;
INSERT INTO dbo.Review (id, persoonId, bestemmingId, tekst, score)
VALUES
(1, 'user1', 1, 'Amazing experience in Barcelona!', 5),
(2, 'user2', 2, 'Loved the Colosseum in Rome.', 4),
(3, 'user3', 3, 'Paris was enchanting!', 5),
(4, 'user4', 4, 'Informative and inspiring trip to Berlin.', 4);
SET IDENTITY_INSERT dbo.Review OFF;
COMMIT;

END TRY

BEGIN CATCH
ROLLBACK;
END CATCH