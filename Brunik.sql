create database obchudek;
use obchudek;
CREATE TABLE Dodavatele (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Jmeno NVARCHAR(100) NOT NULL
);

CREATE TABLE Zakaznici (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Jmeno NVARCHAR(100) NOT NULL
);

CREATE TABLE Produkty (
    Id INT PRIMARY KEY IDENTITY(1,1),
    Nazev NVARCHAR(100) NOT NULL,
    Cena FLOAT NOT NULL
);

CREATE TABLE Objednavky (
    Id INT PRIMARY KEY IDENTITY(1,1),
    DatumObjednani DATETIME NOT NULL,
    ZakaznikId INT NOT NULL,
    FOREIGN KEY (ZakaznikId) REFERENCES Zakaznici(Id)
);

CREATE TABLE PolozkyObjednavky (
    ObjednavkaId INT,
    ProduktId INT,
    Mnozstvi INT NOT NULL,
    PRIMARY KEY (ObjednavkaId, ProduktId),
    FOREIGN KEY (ObjednavkaId) REFERENCES Objednavky(Id),
    FOREIGN KEY (ProduktId) REFERENCES Produkty(Id)
);
