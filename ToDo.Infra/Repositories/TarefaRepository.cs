using ToDo.Domain.DTO;
using ToDo.Domain.Enums;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;
using ToDo.Infra.Context;

namespace ToDo.Infra.Repositories
{
    public class TarefaRepository : BaseRepository<Tarefa>, ITarefaRepository
    {
        public TarefaRepository(ToDoContext context) : base(context)
        {
        }


        public TarefaDTO CadastrarTarefa(string nome, int statusId, int userId)
        {
            var tarefa = new Tarefa(nome, statusId, userId);
            Add(tarefa);
            SaveChanges();

            return Db.Tarefas.Where(t => t.Id == tarefa.Id).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            }).FirstOrDefault(); ;
        }


        public TarefaDTO AtualizarTarefa(int tarefaId)
        {
            SaveChanges();

            return Db.Tarefas.Where(t => t.Id == tarefaId).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            }).FirstOrDefault();

        }

        public TarefaDTO BuscarTarefaPorId(int tarefaId)
        {
            return Db.Tarefas.Where(t => t.Id == tarefaId).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            }).FirstOrDefault();
        }

        public IEnumerable<TarefaDTO> BuscarTarefaPorNome(string tarefaNome)
        {
            return Db.Tarefas.Where(t => t.Nome == tarefaNome).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            });
        }

        public IEnumerable<TarefaDTO> BuscarTarefas()
        {
            return Db.Tarefas.Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            });
        }

        public IEnumerable<TarefaDTO> BuscarTarefasPendentes()
        {
            return Db.Tarefas.Where(t => t.StatusId == (int)StatusEnum.PENDENTE).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            });
        }

        public IEnumerable<TarefaDTO> BuscarTarefasAtrasadas()
        {
            return Db.Tarefas.Where(t => t.StatusId == (int)StatusEnum.ATRASADA).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            });
        }

        public IEnumerable<TarefaDTO> BuscarTarefasCanceladas()
        {
            return Db.Tarefas.Where(t => t.StatusId == (int)StatusEnum.CANCELADA).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            });
        }
        public IEnumerable<TarefaDTO> BuscarTarefasRealizadas()
        {
            return Db.Tarefas.Where(t => t.StatusId == (int)StatusEnum.REALIZADA).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            });
        }

        public void DeletarTarefa(int tarefaId)
        {
            Remove(tarefaId);
            SaveChanges();
        }

        public IEnumerable<TarefaDTO> BuscarTarefaPorUser(int userId)
        {
            return Db.Tarefas.Where(t => t.UserId == userId).Select(t => new TarefaDTO
            {
                Id = t.Id,
                Nome = t.Nome,
                StatusId = t.StatusId,
                UserId = t.UserId
            });
        }
    }
}
