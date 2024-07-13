-- Criando o Banco de Dados
CREATE DATABASE produtoDB;

-- Usar o Banco de Dados criado

USE produtoDB;

-- Tabela de Usuários

CREATE TABLE usuario(
id INT AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR(50) NOT NULL,
sobrenome VARCHAR(50) NOT NULL,
email VARCHAR(100) NOT NULL UNIQUE,
cpf VARCHAR(11) NOT NULL UNIQUE,
senhahash VARCHAR(255) NOT NULL
);

-- Tabela de Produtos

CREATE TABLE produto(
id INT AUTO_INCREMENT PRIMARY KEY,
nome VARCHAR(255) NOT NULL,
descricao TEXT,
preco DECIMAL(10, 2) NOT NULL,
quantidade_estoque INT NOT NULL,
imagem_url VARCHAR(255) INT NULL
);

-- Tabela de Vendas

CREATE TABLE Venda(
id INT AUTO_INCREMENT PRIMARY KEY,
usuario_id INT,
produto_id INT,
quantidade INT NOT NULL,
data_venda TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
FOREIGN KEY (usuario_id) REFERENCES usuario(id),
FOREIGN KEY (produto_id) REFERENCES produto(id)
);