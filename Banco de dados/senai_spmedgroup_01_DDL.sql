CREATE DATABASE SPMedicalGroup;
GO

USE SPMedicalGroup;
GO

CREATE TABLE clinicas
(
	idClinica			INT PRIMARY KEY IDENTITY,
	razaoSocial			VARCHAR(100) NOT NULL,
	nomeClinica			VARCHAR(100) NOT NULL,
	endereco			VARCHAR(255) UNIQUE NOT NULL,
	cnpj				CHAR(14) UNIQUE NOT NULL,

);
GO

CREATE TABLE especialidades
(
	idEspecialidade		INT PRIMARY KEY IDENTITY,
	nome				VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE situacoes
(
	idSituacao			INT PRIMARY KEY IDENTITY,
	descricao			VARCHAR(100) NOT NULL
);
GO

CREATE TABLE tiposUsuarios
(
	idTipo				INT PRIMARY KEY IDENTITY,
	tituloTipo			VARCHAR(100) UNIQUE NOT NULL
);
GO

CREATE TABLE usuarios
(
	idUsuario			INT PRIMARY KEY IDENTITY,
	idTipo				INT FOREIGN KEY REFERENCES tiposUsuarios(idTipo),
	nome				VARCHAR(255) NOT NULL,
	email				VARCHAR(255) UNIQUE NOT NULL,
	dataNascimento		DATE NOT NULL
);
GO

CREATE TABLE pacientes
(
	idPaciente			INT PRIMARY KEY IDENTITY,
	idUsuario			INT FOREIGN KEY REFERENCES usuarios(idUsuario),
	telefone			BIGINT,
	rg					CHAR(9) UNIQUE NOT NULL,
	cpf					CHAR(11) UNIQUE NOT NULL,
	endereco			VARCHAR(100) NOT NULL
);
GO

CREATE TABLE medicos
(
	idUsuario			INT FOREIGN KEY REFERENCES usuarios(idUsuario),
	idMedico			INT PRIMARY KEY IDENTITY,
	crm					VARCHAR(255)UNIQUE NOT NULL,
	idEspecialidade		INT FOREIGN KEY REFERENCES especialidades(idEspecialidade),
	idClinica			INT FOREIGN KEY REFERENCES clinicas(idClinica)
);
GO

CREATE TABLE consultas
(
	idConsulta			INT PRIMARY KEY IDENTITY,
	idPaciente			INT FOREIGN KEY REFERENCES pacientes(idPaciente),
	idMedico			INT FOREIGN KEY REFERENCES medicos(idMedico),
	dataConsulta		SMALLDATETIME NOT NULL,
	idSituacao			INT FOREIGN KEY REFERENCES situacoes(idSituacao) DEFAULT (1)
);
GO

ALTER TABLE clinicas
ADD horarioAbertura TIME;

ALTER TABLE clinicas
ADD horarioFechamento TIME;

ALTER TABLE usuarios
ADD senha VARCHAR(20);
-- Não coloquei not null porque não permitiu, e esqueci de colocar