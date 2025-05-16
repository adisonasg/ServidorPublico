ServidorPublico.API
API RESTful para gerenciamento de servidores públicos, permitindo operações de criação, atualização, inativação e listagem de servidores vinculados a órgãos e lotações.

Tecnologias Utilizadas:

.NET 8
ASP.NET Core Web API
Entity Framework Core
MediatR
SQL Lite
Swagger (Swashbuckle)



Instruções de Build e Execução Local:

Clone o repositório:

git clone https://github.com/seu-usuario/ServidorPublico.API.git
cd ServidorPublico.API

Configure a string de conexão:
Atualize o arquivo appsettings.json com a string de conexão do seu banco de dados SQL Server:

{
  "ConnectionStrings": {
    "DefaultConnection": "Server=localhost;Database=ServidorPublicoDB;Trusted_Connection=True;"
  }
}

Restaure as dependências e compile o projeto:

dotnet restore
dotnet build

Aplique as migrações e atualize o banco de dados:

dotnet ef database update

Execute a aplicação:

dotnet run

Acesse a documentação Swagger:

Abra o navegador e vá para https://localhost:5001/swagger para visualizar e testar os endpoints da API.



Endpoints Disponíveis
.Criar Servidor:

Endpoint: POST /api/servidores
Descrição: Cria um novo servidor.
Payload de Exemplo:

{
  "nome": "João Silva",
  "telefone": "61999999999",
  "email": "joao.silva@example.com",
  "sala": "101",
  "orgaoId": 1,
  "lotacaoId": "d290f1ee-6c54-4b01-90e6-d701748f0851"
}

.Atualizar Servidor
Endpoint: PUT /api/servidores/{id}
Descrição: Atualiza os dados de um servidor existente.
Payload de Exemplo:

{
  "nome": "João da Silva",
  "telefone": "61988888888",
  "email": "joao.dasilva@example.com",
  "sala": "102",
  "orgaoId": 2,
  "lotacaoId": "a3bb189e-8bf9-3888-9912-ace4e6543002"
}

.Inativar Servidor
Endpoint: DELETE /api/servidores/{id}
Descrição: Inativa um servidor, marcando-o como inativo.

.Listar Servidores Ativos
Endpoint: GET /api/servidores
Descrição: Retorna uma lista de todos os servidores ativos.


Tratamento de Erros
A API implementa um middleware de tratamento de exceções que retorna respostas padronizadas com base no tipo de erro:

400 Bad Request: Erros de validação ou dados inválidos.
404 Not Found: Recurso não encontrado.
500 Internal Server Error: Erros inesperados no servidor.

As respostas de erro seguem o padrão Problem Details, facilitando a interpretação e o tratamento por clientes.

Testes:
Não concluídos


Licença
Este projeto está licenciado sob a MIT License.

