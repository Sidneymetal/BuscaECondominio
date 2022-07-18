CREATE TABLE usuarios (
  id INTEGER PRIMARY KEY,
  email VARCHAR(256),
  cpf VARCHAR(256),
  data_nascimento TIMESTAMP,
  nome VARCHAR(256),
  senha VARCHAR(15),
  url_imagem_cadastro VARCHAR,
  data_criacao TIMESTAMP
);
