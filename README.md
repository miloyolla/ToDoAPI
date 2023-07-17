# ToDoAPI
A API desenvolvida em .Net Core 6 é um sistema de cadastro e gerenciamento de status de tarefas com cadastro e autenticação de usuário usando JWT.

## Tecnologias Utilizadas
- .Net Core 6
- Entity Framework
- JWT
- Swagger
- HTTP

## Mapeamento dos Endpoints
### Usuário
- `/api/Auth/Cadastrar`: Recebe como entrada Username e Password e retorna uma mensagem de confirmação de cadastro
- `/api/Auth/Login`: Recebe como entrada Username e Password e retorna uma string token gerada com JWT

### Tarefa
- `/api/Tarefa/Cadastrar`: Recebe como entrada Nome, StatusId e UserId da Tarefa e retorna mensagem de confirmação de cadastro 
- `/api/Tarefa/Atualizar`: Recebe como entrada TarefaId, Nome e StatusId da Tarefa e retorna mensagem de confirmação de atualização 
- `/api/Tarefa/BuscarPorId`: Recebe como entrada TarefaId e, caso exista Tarefa com o Id informado, retorna um objeto de Tarefa
 - `/api/Tarefa/BuscarPorNome`: Recebe como entrada uma string e retorna uma lista de Tarefas como Nome igual a string informada 
- `/api/Tarefa/BuscarTarefas`: Retorna todas as tarefas cadastradas
- `/api/Tarefa/BuscarTarefasPendentes`: Retorna todas as tarefas cadastradas com status "Pendente"
- `/api/Tarefa/BuscarTarefasAtrasadas`: Retorna todas as tarefas com status "Atrasada"
- `/api/Tarefa/BuscarTarefasCanceladas`: Retorna todas as tarefas com status "Cancelada"
- `/api/Tarefa/BuscarTarefasRealizadas`: Retorna todas as tarefas com status "Realizada"
- `/api/Tarefa/AtualizarStatus`: Recebe como entrada uma string e retorna mensagem de confirmação de atualização
- `/api/Tarefa/Deletar`: Recebe como entrada tarefaId e retorna mensagem de confirmação de deletado
- `/api/Tarefa/BuscarPorUser`: Recebe como entrada userId e retorna uma lista de tarefas


## Organização do Projeto
API
- Controllers

Domain
- DTO
- Enums
- InputModel
- Interfaces
- Models

Infra
- Context
- Mappings
- Migrations
- Repositories
