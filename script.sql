CREATE DATABASE sistema_cinema;
USE sistema_cinema;

CREATE TABLE filmes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    titulo VARCHAR(100) NOT NULL,
    genero VARCHAR(50) NOT NULL,
    duracao INT NOT NULL
);

CREATE TABLE sessoes (
    id INT AUTO_INCREMENT PRIMARY KEY,
    filme_id INT NOT NULL,
    horario VARCHAR(20) NOT NULL,
    capacidade INT NOT NULL,
    ingressos_vendidos INT DEFAULT 0,
    FOREIGN KEY (filme_id) REFERENCES filmes (id)
);

CREATE TABLE ingressos (
    id INT AUTO_INCREMENT PRIMARY KEY,
    sessao_id INT NOT NULL,
    quantidade INT NOT NULL,
    valor_total DECIMAL(10,2) NOT NULL,
    FOREIGN KEY (sessao_id) REFERENCES sessoes (id)
);
