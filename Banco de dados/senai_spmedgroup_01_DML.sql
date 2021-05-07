USE SPMEDICALGROUP;

--VALORES TRANSFERIDOS PELA IMPORTAÇÃO DE DADOS

-- Inserindo horario de abertura e de fechamento na tabela clinicas
UPDATE clinicas
SET horarioAbertura = '09:00:00', horarioFechamento = '18:00:00'
WHERE idClinica = 1;

-- Atualizando as consultas não-atualizadas
UPDATE consultas
SET idSituacao = 2
WHERE idConsulta = 6;

UPDATE consultas
SET idSituacao = 2
WHERE idConsulta = 7;

-- Corrigindo a data de nascimento da Helena Strada
UPDATE usuarios
SET dataNascimento = '1978/02/20'
WHERE idUsuario = 3;

--Inserção dos dados na coluna senha, de usuarios, devido ao acrescimento da coluna pelo ALTER TABLE
UPDATE usuarios
SET senha = 'r123456'
WHERE idUsuario = 1;

UPDATE usuarios
SET senha = 'rp12345'
WHERE idUsuario = 2;

UPDATE usuarios
SET senha = 'h123456'
WHERE idUsuario = 3;

UPDATE usuarios
SET senha = 'l123456'
WHERE idUsuario = 4;

UPDATE usuarios
SET senha = 'a123456'
WHERE idUsuario = 5;

UPDATE usuarios
SET senha = 'f123456'
WHERE idUsuario = 6;

UPDATE usuarios
SET senha = 'h123456'
WHERE idUsuario = 7;

UPDATE usuarios
SET senha = 'j123456'
WHERE idUsuario = 8;

UPDATE usuarios
SET senha = 'b123456'
WHERE idUsuario = 9;

UPDATE usuarios
SET senha = 'm123456'
WHERE idUsuario = 10;

UPDATE usuarios
SET senha = 'fs123456'
WHERE idUsuario = 11;

-- Criando uma nova consulta
INSERT INTO consultas(idPaciente, idMedico, dataConsulta)
VALUES				 (4, 2, '20/03/2021 13:00')

-- Criando um novo usuario
INSERT INTO usuarios(idTipo, nome, email, dataNascimento, senha)
VALUES				(2, 'Robert Sena', 'robert.sena@spmedicalgroup.com.br', '1989/02/20', 'rs12345');

-- Criando um novo medico
INSERT INTO medicos(idUsuario, crm, idEspecialidade, idClinica)
VALUES			   (12, '59467SP', 2, 1)

-- Corrigimos o email da amd
UPDATE usuarios
SET email = 'fernanda.strada@adm.com.br'
WHERE idUsuario = 11;