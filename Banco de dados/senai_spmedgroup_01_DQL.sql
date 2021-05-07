USE SPMedicalGroup;

-- Seleciona todas as cl�nicas
SELECT * FROM clinicas;

--Seleciona todas as consultas
SELECT * FROM consultas;

-- Seleciona todas as especialidades
SELECT * FROM especialidades;

-- Seleciona todos os m�dicos
SELECT * FROM medicos;

-- Seleciona todos os pacientes
SELECT * FROM pacientes;

-- Seleciona todas as situa��es
SELECT * FROM situacoes;

-- Seleciona todos os Tipos de Usuarios
SELECT * FROM tiposUsuarios;

-- Seleciona todos os usu�rios
SELECT * FROM usuarios;

-- Mostra os Usu�rios com seus tipos
SELECT nome, tituloTipo [tipoUsuario], email, dataNascimento
FROM usuarios U
INNER JOIN tiposUsuarios TU
ON U.idTipo = TU.idTipo

-- Mostra os m�dicos, seus crm, suas especialidaes e a clinica para qual trabalha 
SELECT tituloTipo [tipoUsuario], U.nome, email, crm, E.nome [especialidade], nomeClinica [cl�nica]
FROM usuarios U
INNER JOIN tiposUsuarios TU
ON U.idTipo = TU.idTipo
INNER JOIN medicos M
ON U.idUsuario = M.idMedico
INNER JOIN especialidades E
ON M.idEspecialidade = E.idEspecialidade
INNER JOIN clinicas C
ON M.idClinica = C.idClinica;

-- Mostra os pacientes, seus cpf's, telefone e endere�o
SELECT nome, email, dataNascimento, telefone, cpf, endereco
FROM usuarios U
INNER JOIN pacientes P
ON U.idUsuario = P.idUsuario;

-- Mostrando todas as consultas depois de uma certa data
SELECT U.nome [paciente], dataNascimento, telefone, 
cpf, dataConsulta, crm,  E.nome [tipoConsulta], descricao
FROM pacientes P
INNER JOIN usuarios U
ON P.idUsuario = U.idUsuario
INNER JOIN consultas C
ON P.idPaciente = C.idPaciente
INNER JOIN situacoes S
ON C.idSituacao = S.idSituacao
INNER JOIN medicos M
ON C.idMedico = M.idMedico
INNER JOIN especialidades E
ON M.idEspecialidade = E.idEspecialidade
WHERE C.dataConsulta > '2021/01/01';

-- Convertendo a data de nascimento no select para DD/MM/AAAA
SELECT nome, email, CONVERT(VARCHAR, dataNascimento, 103) [dataNascimento] FROM usuarios