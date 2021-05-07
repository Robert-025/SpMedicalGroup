USE SPMedicalGroup;

-- Criando função para ver a quantidade de médicos em uma especialidade
CREATE FUNCTION medicosEspecialidades(@nomeEspecialidade VARCHAR(100))
RETURNS INT 
BEGIN
	-- Declaramos uma variável e seu tipo
	DECLARE @quantidadeMedicos AS INT;

	--Selecionamos a variável e colocamos a informação nela
	SELECT  @quantidadeMedicos = (SELECT COUNT (U.nome)
							 FROM usuarios U
							 INNER JOIN medicos M
							 ON U.idUsuario = M.idUsuario
							 INNER JOIN especialidades E
							 ON M.idEspecialidade = E.idEspecialidade
							 WHERE E.nome = @nomeEspecialidade)
							 -- Colocamos o valor achado na variável
								RETURN @quantidadeMedicos
END
GO

-- Validação da função
SELECT QuantidadeMedicos = dbo.medicosEspecialidades('anestesiologia');

-- Criando stored procedure pedindo o nome de um paciente
CREATE PROCEDURE calcularIdade (@nomeUsuario VARCHAR(500))
AS

	-- Criamos um SELECT para pedir usar o nome e a data de nascimento do usuario
	SELECT nome, CONVERT(VARCHAR, dataNascimento, 103) [dataNascimento], 
	DATEDIFF(YEAR, U.dataNascimento, GETDATE()) [idadeAtual]
	FROM usuarios U
	WHERE nome = @nomeUsuario;

-- EXEC: Usado para executar uma procedure
EXEC calcularIdade @nomeUsuario = 'Alexandre';

-- Procedure calcula usando o ano, independente se a data do nascimento não chegou ainda