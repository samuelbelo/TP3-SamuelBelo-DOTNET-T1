CREATE TABLE Pessoa(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(250) NOT NULL,
	DataNascimento DATE NOT NULL 
);
SELECT * FROM Pessoa
INSERT INTO Pessoa (Nome, DataNascimento) VALUES ('Samuel Belo', '2016-05-01');
--DROP TABLE Pessoa