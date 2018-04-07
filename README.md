# TesteDotNet

O **.NET Core 2.0** foi o framework escolhido para demonstrar minhas habilidades, o banco de dados utilizado foi **MDF**. É só baixar a solução e executar.

As funcionalidades implementadas nesse teste estão informadas e comentadas abaixo:

- [X] Implementar a funcionalidade de adicionar item;
- [X] Implementar a funcionalidade de alterar um item existente;
- [X] Implementar a funcionalidade de deletar um item;
- [X] Implementar a funcionalidade de visualizar;
- [X] Implementar as funcionalidades dos botões de salvar, cancelar e voltar;
- [X] Implementar a funcionalidade de não permitir o cadastro de mais de um item com o mesmo nome;
- [X] Implementar a confirmação antes da exclusão de um item (pode ser um confirm do JavaScript);
    - Foi utilizado o modal do bootstrap;
- [X] Implementar a busca de itens por nome;
- [X] Implementar busca por nome, código, categoria e data (tudo no mesmo campo de busca);
- [X] Implementar um ou mais design patterns:
    - DI - Dependency Injection;
    - BDD - Behavior Driven Development:
 
Para implementar o **BDD** foi criado um [documento](NetCore2/TesteDotNet.Core2.0-BDD/Features/TesteDotNet.Core2_0.feature) utilizando a formatação **gherkin** com as especificação das funcionalidades, este documento no ciclo de desenvolvimento serve tanto como especificação e como guia para a criação dos cenários de teste, por isso esse documento ficou dentro do projeto de teste;

Recorte da primeira parte do documento:

```gherkin
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
```

- [X] Implementar Testes ~~de Unidade e/ou~~ Integração **(+ Regressão UI)**:
    - Para trabalhar com o teste guiado por **BDD**, foi utilizado o framework **SpecFlow**, o teste não se restringiu a somente a integração, mas sim um **teste de regrassão de UI**, para isso foi utilizado em conjunto o **Selenium WebDriver**

Com o arquivo criado para implementar o BDD, foi programados os [steps](NetCore2/TesteDotNet.Core2.0-BDD/Steps.cs) dos cenários. 

Depois a ferramenta SpecFlow gerar a lista dos testes para ser executado de dentro do Visual Studio como um teste qualquer.

![Lista de testes](images/itens.PNG?raw=true "Lista de testes")

Cada step do teste gera um **screenshot de evidência** e salva na pasta [**ResultadosTesteBDD**](NetCore2/ResultadosTesteBDD)

Obs: Para executar os **testes de regressão** na máquina é necessário que pelo menos **uma vez tenha startado** a aplicação do projeto principal, depois é só mandar executar os testes e acompanhar o selenium interagindo com o chrome ou olhar as evidências sendo gravadas na pasta local **TesteDotNet/NetCore2/ResultadosTesteBDD**
