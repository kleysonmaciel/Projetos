-- Criando o Banco de Dados
CREATE DATABASE ProdutoDB;

-- Usar o Banco de Dados criado

USE ProdutoDB;

-- Tabela de Usuários

CREATE TABLE Usuario(
Id INT AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(50) NOT NULL,
Sobrenome VARCHAR(50) NOT NULL,
Email VARCHAR(100) NOT NULL UNIQUE,
CPF VARCHAR(11) NOT NULL UNIQUE,
SenhaHash VARCHAR(255) NOT NULL
);

-- Tabela de Produtos

CREATE TABLE Produto(
Id INT AUTO_INCREMENT PRIMARY KEY,
Nome VARCHAR(255) NOT NULL,
Descricao TEXT,
Preco DECIMAL(10, 2) NOT NULL,
QuantidadeEmEstoque INT NOT NULL,
ImagemUrl VARCHAR(255) INT NULL
);

-- Tabela de Vendas

CREATE TABLE Venda(
Id INT AUTO_INCREMENT PRIMARY KEY,
UsuarioId INT,
ProdutoId INT,
Quantidade INT NOT NULL,
DataVenda TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY (UsuarioId) REFERENCES Usuario(Id),
FOREIGN KEY (ProdutoId) REFERENCES Produto(Id)
);