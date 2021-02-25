# Principais Comandos SQL Server

## Create:

```sql
CREATE DATABASE Loja;

USE Loja;

CREATE TABLE Cliente(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nome VARCHAR(50) NOT NULL,
    Telefone VARCHAR(20) NOT NULL,
    Endereco VARCHAR(70) NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE Produto(
    Id INT IDENTITY(1,1) NOT NULL PRIMARY KEY,
    Nome VARCHAR(30) NOT NULL,
    Descricao VARCHAR(50) NOT NULL,
    Preco FLOAT NOT NULL,
    CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE Venda(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdCliente INT NOT NULL FOREIGN KEY REFERENCES Cliente(Id),
    ValorTotal FLOAT NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
    UpdatedAt DATETIME NULL
);

CREATE TABLE ItemVenda(
    Id INT IDENTITY(1,1) PRIMARY KEY,
    IdProduto INT NOT NULL FOREIGN KEY REFERENCES Produto(Id),
    IdVenda INT NOT NULL FOREIGN KEY REFERENCES Venda(Id),
    Quantidade INT NOT NULL,
    ValorTotal FLOAT NOT NULL,
	CreatedAt DATETIME DEFAULT GETDATE() NOT NULL,
    UpdatedAt DATETIME NULL
);

```

## Insert:

```sql
INSERT INTO Cliente (Nome, Telefone, Endereco)
VALUES ('Marcos da Silva', '17 88958-4823', 'Rua dos Clientes');

INSERT INTO Produto (Nome, Descricao, Preco)
VALUES ('Blusa Feminina', 'cor branca, 100% algodao', 25.5);
INSERT INTO Produto (Nome, Descricao, Preco)
VALUES ('Blusa Masculina', 'cor preta, 100% algodao', 28);

INSERT INTO Venda (IdCliente, ValorTotal) VALUES (1, 51);

INSERT INTO ItemVenda (IdProduto, IdVenda, Quantidade, ValorTotal) VALUES (1, 1, 2, 51);
```

## Select:

```sql
SELECT * FROM Produto;
SELECT Quantidade, ValorTotal FROM ItemVenda;
```

## Update (lembre-se do WHERE!):

```sql
UPDATE Produto
SET Nome = 'Regata Masculina', Preco = 27
WHERE Id = 2;
```

## Delete (lembre-se do WHERE!):

```sql
DELETE FROM Produto WHERE Id = 2;
```

## Comment:

```sql
--Isto é um comentário!
```
