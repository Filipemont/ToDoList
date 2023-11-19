# ToDoList -Web API com ASP.NET Core, .NET 6, Entity Framework e SQL Server

Esta é uma Web API desenvolvida utilizando o ASP.NET Core com .NET 6, Entity Framework Core para mapeamento objeto-relacional e SQL Server como banco de dados. O método utilizado para a criação do banco de dados é o Code-First, o que significa que o banco de dados é gerado automaticamente com base nos modelos de entidade definidos no código.

#Pré-requisitos
.NET 6 SDK: Certifique-se de ter o .NET 6 SDK instalado. Você pode baixá-lo em dotnet.microsoft.com.

SQL Server: Certifique-se de ter uma instância do SQL Server disponível. Você pode instalar o SQL Server Express gratuitamente ou usar uma instância existente.

#Configuração do Banco de Dados
Abra o arquivo appsettings.json na raiz do projeto.
No bloco "ConnectionStrings", atualize a string de conexão (DefaultConnection) com os detalhes do seu servidor SQL.
json
Copy code
"ConnectionStrings": {
  "DefaultConnection": "Server=<NOME_DO_SERVIDOR>;Database=<NOME_DO_BANCO_DE_DADOS>;User Id=<USUARIO>;Password=<SENHA>;"
},

#Migrações do Banco de Dados
Para criar o banco de dados e aplicar as migrações iniciais, abra um terminal na pasta do projeto e execute os seguintes comandos:

dotnet ef migrations add Inicial
dotnet ef database update
Isso criará o banco de dados com base nos modelos de entidade definidos no código.

#Executando a Aplicação
Para iniciar a aplicação, execute o seguinte comando na pasta do projeto:

dotnet run

#Exemplos de Endpoints
A seguir estão alguns exemplos de endpoints disponíveis:

GET /api/exemplo: Retorna todos os exemplos.
GET /api/exemplo/{id}: Retorna um exemplo específico com o ID fornecido.
POST /api/exemplo: Cria um novo exemplo. Envie os dados no corpo da solicitação.
PUT /api/exemplo/{id}: Atualiza um exemplo existente com o ID fornecido. Envie os dados atualizados no corpo da solicitação.
DELETE /api/exemplo/{id}: Exclui um exemplo com o ID fornecido.
Contribuindo
Sinta-se à vontade para contribuir com melhorias ou correções de bugs. Basta criar uma issue ou enviar um pull request.

Espero que esta Web API seja útil e fácil de usar. Se você tiver alguma dúvida ou sugestão, não hesite em entrar em contato. Agradecemos sua contribuição!
