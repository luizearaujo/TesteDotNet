#language: pt-br

Funcionalidade: TesteDotNet.Core2_0
	Como um usuário do sistema
	Quero utilizar as funções do cadastro simples de items

@CenarioTeste
Cenário: Implementar a funcionalidade de ADICIONAR
	Dado que eu acesse a pagina "inicial"
	Quando eu clicar no botão "Novo Item"
	Então eu verei o texto "Adicionar Item"
	Quando no campo "Nome" eu digitar "novoItem"
	E no campo "Descricao" eu digitar "novaDescricao"
	Quando eu selecionar no campo "CategoriaId" o valor "Renda Fixa"
	Quando eu clicar no botão "Salvar"
	Então eu verei o item digitado "novoItem"

@CenarioTeste
Cenário: Implementar a funcionalidade de ALTERAR
	Dado que eu acesse a pagina "inicial"
	Quando eu clicar no botão "Editar" do "Primeiro" item
	Então eu verei o texto "Alterar Item"
	Quando no campo "Nome" eu digitar "novoItem"
	E no campo "Descricao" eu digitar "novaDescricao"
	Quando eu selecionar no campo "CategoriaId" o valor "Tesouro Direto"
	Quando eu clicar no botão "Salvar"
	Então eu verei o item digitado "novoItem"

@CenarioTeste
Cenário: Implementar a funcionalidade de DELETAR
	Dado que eu acesse a pagina "inicial"
	Quando eu clicar no botão "Novo Item"
	Então eu verei o texto "Adicionar Item"
	Quando no campo "Nome" eu digitar "novoItem"
	E no campo "Descricao" eu digitar "novaDescricao"
	Quando eu selecionar no campo "CategoriaId" o valor "Renda Fixa"
	Quando eu clicar no botão "Salvar"
	Então eu verei o item digitado "novoItem"
	Quando eu clicar no botão "Excluir" do "Primeiro" item
	E eu clicar no botão "Sim"
	Então não verei o texto "novoItem"

@CenarioTeste
Cenário: Implementar a funcionalidade de VISUALIZAR
	Dado que eu acesse a pagina "inicial"
	Quando eu clicar no botão "Novo Item"
	Então eu verei o texto "Adicionar Item"
	Quando no campo "Nome" eu digitar "novoItem"
	E no campo "Descricao" eu digitar "novaDescricao"
	Quando eu selecionar no campo "CategoriaId" o valor "Renda Fixa"
	Quando eu clicar no botão "Salvar"
	Então eu verei o item digitado "novoItem"
	Quando eu clicar no botão "Visualizar" do "Primeiro" item
	Então eu verei o item digitado "novoItem"
	Quando eu clicar no botão "Voltar"
	Então eu verei o texto "Itens"

@CenarioTeste
Cenário: Implementar a funcionalidade que 2 items com o mesmo nome são BLOQUEADO
	Dado que eu acesse a pagina "inicial"
	Quando eu clicar no botão "Novo Item"
	Então eu verei o texto "Adicionar Item"
	Quando no campo "Nome" eu digitar "novoItem"
	E no campo "Descricao" eu digitar "novaDescricao"
	Quando eu selecionar no campo "CategoriaId" o valor "Renda Fixa"
	Quando eu clicar no botão "Salvar"
	Então eu verei o item digitado "novoItem"
	Quando eu clicar no botão "Novo Item"
	Quando no campo "Nome" eu digitar "itemAnterior"
	E no campo "Descricao" eu digitar "descricaoAnterior"
	Quando eu selecionar no campo "CategoriaId" o valor "Tesouro Direto"
	Quando eu clicar no botão "Salvar"
	Então eu verei o texto "Já existe um item cadastrado com o mesmo nome"

@CenarioTeste
Cenário: Implementar a funcionalidade de busca por Nome
	Dado que eu acesse a pagina "inicial"
	Quando eu clicar no botão "Novo Item"
	Então eu verei o texto "Adicionar Item"
	Quando no campo "Nome" eu digitar "novoItem"
	E no campo "Descricao" eu digitar "novaDescricao"
	Quando eu selecionar no campo "CategoriaId" o valor "Renda Fixa"
	Quando eu clicar no botão "Salvar"
	Então eu verei o item digitado "novoItem"
	Quando no campo "busca" eu digitar "textoAleatorio"
	E eu clicar na busca
	Então eu não verei o item digitado "itemAnterior"
	Quando no campo "busca" eu digitar "itemAnterior"
	E eu clicar na busca
	Então eu verei o item digitado "itemAnterior"