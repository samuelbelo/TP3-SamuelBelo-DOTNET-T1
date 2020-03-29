CREATE TABLE Pessoa(
	Id INT IDENTITY(1,1) PRIMARY KEY,
	Nome VARCHAR(250) NOT NULL,
	DataNascimento DATE NOT NULL 
);
SELECT * FROM Pessoa
INSERT INTO Pessoa (Nome, DataNascimento) 
OUTPUT INSERTED.Id 
VALUES ('Samuel Belo', '2016-05-01'), 
('Aluno da Silva', '2016-05-01'), 
('Professor Felipe', '2016-05-01'), 
('Mariana Soares', '2016-05-01'), 
('Samuel Santos', '2016-05-01');
--DROP TABLE Pessoa
