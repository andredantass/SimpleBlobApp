Este Projeto foi feito utilizando os conceitos de SOLID, assim como uma arquitetura de camada utilizando as melhores praticas 
do Clean Architecture. As Tecnologias e conceitos utilizados para a criação dessa API foram:

Entity Framework
Repository Pattern
Code First Concept
Microsoft.AspNet.WebSocket 
ClaimIdentity

Siga os passos para rodar a aplicação. 
Tanto o Client que consome o WebSocket quanto o API foram desenvolvidos no Visual Studio 2022 e estão na 
mesma solution, para facilitar no momento de roda-los.

Pre-requisito
______________________________________________________________

Instalar a ultima versao do Dotnet EF

1 - Abrir menu View, Other Window, click em Package Manager Console

dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet tool install --global dotnet-ef

2 - Ter instalado o SqlServer com acesso a localhost (caso a instância do sqlserver localhost
tenha outro nome, devera ser alterado nas connections strings, tanto do SimpleBlogDbContext.cs na camada SimpleBlogApp.Infra.Data quando para o 
appsettings.development do camada de API)


Executar Migrations
______________________________________________________________

1 - Abrir menu View, Other Window, click em Package Manager Console
2 - Dar o comando "dir" e logo apos entrar na camada da Migration com o comando cd SimpleBlogApp.Infra.Data
3 - No console que abrir escolher o Default Project como SimpleBlogApp.Infra.Data no combobox
4 - Executar o comando
	dotnet ef database update (Este comando irá criar as duas entidades necessárias no sql server)


Importar Regression Test do Postman
______________________________________________________________

Para fazer o papel do client consumindo os endpoints da api eu utilizei o Postman. E criei um environment de test com chamadas para os endpoints.
O arquivo do Postman esta dentro do diretorio SimpleBlogApp\SimpleBlogApp\PostmanRegressionTest.
Este arquivo devera ser importado para o Postman local, seguindo os seguintes passos.

1 - Abrir Postman
2 - Clicar no botão Importar
3 - Selecionar o arquivo SimpleBlogApp.postman_collection que esta na pasta SimpleBlogApp\SimpleBlogApp\PostmanRegressionTest
4 - Todos as chamadas para os endpoints da API estarâo dis

Executando Projeto para teste
______________________________________________________________

1 - Ambos projetam devem rodar juntos, tanto a camada SimpleBlogApp.API e WSClientSimpleBlog

2 - Clicar com o botao direito do mouse na solution e clicar em Propriedades

3 - Selecionar "Varios projetos de instalacao"

4 - Escolher SimpleBlogApp.API = Iniciar  e  WSClientSimpleBlog = Iniciar

5 - Clicar Ok

6 - Executar a Aplicacao no Visual Studio

Ambos os projetos irão rodar em paralelo, verificar se a Api rodara na porta https://localhost:44348/,
caso na maquina aonde sera feito o teste essa porta estiver ocupada devera alterar no arquivo
de configuracao

Executando Endpoints e WebSocket Client
______________________________________________________________

Dentro da pasta do projeto você irá encontrar um outro documento, chamado: RegrasExecucao_WebSocket_Postman. 
Siga as intruções desse documento para executar o projeto Postman e consumir os endpoints da API.
