USE SPMedicalGroup;

-- Criando fun��o para ver a quantidade de m�dicos em uma especialidade
CREATE FUNCTION medicosEspecialidades(@nomeEspecialidade VARCHAR(100))
RETURNS INT 
BEGIN
	-- Declaramos uma vari�vel e seu tipo
	DECLARE @quantidadeMedicos AS INT;

	--Selecionamos a vari�vel e colocamos a informa��o nela
	SELECT  @quantidadeMedicos = (SELECT COUNT (U.nome)
							 FROM usuarios U
							 INNER JOIN medicos M
							 ON U.idUsuario = M.idUsuario
							 INNER JOIN especialidades E
							 ON M.idEspecialidade = E.idEspecialidade
							 WHERE E.nome = @nomeEspecialidade)
							 -- Colocamos o valor achado na vari�vel
								RETURN @quantidadeMedicos
END
GO

-- Valida��o da fun��o
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

-- Procedure calcula usando o ano, independente se a data do nascimento n�o chegou ainda