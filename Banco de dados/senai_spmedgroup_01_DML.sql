USE SPMedicalGroup2;

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
VALUES				 (4, 2, '20/03/2021 13:00');

-- Criando um novo usuario
INSERT INTO usuarios(idTipo, nome, email, dataNascimento, senha)
VALUES				(2, 'Robert Sena', 'robert.sena@spmedicalgroup.com.br', '1989/02/20', 'rs12345');

-- Criando um novo medico
INSERT INTO medicos(idUsuario, crm, idEspecialidade, idClinica)
VALUES			   (12, '59467SP', 2, 1);

-- Corrigimos o email da amd
UPDATE usuarios
SET email = 'fernanda.strada@adm.com.br'
WHERE idUsuario = 11;

-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------
-----------------------------------------------------------------------------------------------------------------------------

INSERT INTO clinicas(razaoSocial, nomeClinica, endereco, cnpj, horarioAbertura, horarioFechamento)
VALUES				('SP Medical Groups', 'Clinica Possarle', 'Av. Barão Limeira, 532, São Paulo, SP', '86400902000130', '09:00:00', '18:00:00');

INSERT INTO especialidades(nome)
VALUES					  ('Acupuntura'),
						  ('Anestesiologia'),
						  ('Angiologia'),
						  ('Cardiologia'),
						  ('Cirurgia cardiovascular'),
						  ('Cirurgia da mao'),
						  ('Cirurgia do aparelho digestivo'),
						  ('Cirurgia geral'),
						  ('Cirurgia pediatrica'),
						  ('Cirurgia plastica'),
						  ('Cirurgia toracica'),
						  ('Cirurgia vascular'),
						  ('Dermatologia'),
						  ('Radioterapia'),
						  ('Urologia'),
						  ('Pediatria'),
						  ('Psiquiatria');

INSERT INTO situacoes(descricao)
VALUES				 ('Agendada'),
					 ('Realizada'),
					 ('Cancelada');

INSERT INTO tiposUsuarios(tituloTipo)
VALUES					 ('Administrador'),
						 ('Médico'),
						 ('Paciente');

INSERT INTO usuarios(idTipo, nome, dataNascimento, email)
VALUES				(2, 'Ricardo Lemos', '20/10/1976', 'ricardo.lemos@spmedicalgroup.com.br'),
					(2, 'Roberto Possarle', '11/01/1987', 'roberto.possarle@spmedicalgroup.com.br'),
					(2, 'Helena Strada', '20/02/1978', 'helena.strada@spmedicalgroup.com.br'),
					(3, 'Ligia', '13/10/1983', 'ligia@gmail.com'),
					(3, 'Alexandre', '23/01/2001', 'alexandre@gmail.com'),
					(3, 'Fernando', '10/10/1978', 'fernando@gmail.com'),
					(3, 'Henrique', '13/10/1985', 'henrique@gmail.com'),
					(3, 'João', '27/08/1975', 'joao@hotmail.com'),
					(3, 'Bruno', '21/03/1972', 'bruno@gmail.com'),
					(3, 'Mariana', '05/03/2018', 'mariana@outlook.com'),
					(1, 'Fernanda Strada', '24/03/1982', 'fernanda.strada@adm.com.br');

INSERT INTO pacientes(idUsuario, telefone, rg, cpf, endereco)
VALUES				 (4, 1134567654, '435225435', '94839859000', 'Rua Estado de Israel 240, São Paulo, Estado de São Paulo, 04022-000'),
					 (5, 11987656543, '326543457', '73556944057', 'Av. Paulista, 1578 - Bela Vista, São Paulo - SP, 01310-200'),
					 (6, 11972084453, '546365253', '16839338002', 'Av. Ibirapuera - Indianópolis, 2927,  São Paulo - SP, 04029-200'),
					 (7, 1134566543, '543663625', '14332654765', 'R. Vitória, 120 - Vila Sao Jorge, Barueri - SP, 06402-030'),
					 (8, 1176566377, '325444447', '91305348010', 'R. Ver. Geraldo de Camargo, 66 - Santa Luzia, Ribeirão Pires - SP, 09405-380'),
					 (9, 11954368769, '545662667', '79799299004', 'Alameda dos Arapanés, 945 - Indianópolis, São Paulo - SP, 04524-001');

INSERT INTO pacientes(idUsuario, rg, cpf, endereco)
VALUES				(10, '545662668', '13771913039', 'R Sao Antonio, 232 - Vila Universal, Barueri - SP, 06407-140');


INSERT INTO medicos(idUsuario, crm, idEspecialidade, idClinica)
VALUES			   (1, '54356SP', 2, 1),
				   (2, '53452SP', 17, 1),
				   (3, '65463SP', 16, 1);


INSERT INTO consultas(idPaciente, idMedico, dataConsulta, idSituacao)
VALUES				 (7, 3, '20/02/2020 15:00:00', 2),
					 (2, 2, '06/01/2020  10:00:00', 3),
					 (3, 2, '07/02/2020  11:00:00', 2),
					 (2, 2, '06/02/2018  10:00:00', 2),
					 (4, 1, '07/02/2019  11:00:00', 3),
					 (7, 3, '08/03/2020  15:00:00', 1),
					 (4, 1, '09/03/2020  11:00:00', 1);