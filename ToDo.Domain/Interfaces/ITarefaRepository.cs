using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDo.Domain.DTO;
using ToDo.Domain.Models;

namespace ToDo.Domain.Interfaces
{
    public interface ITarefaRepository: IBaseRepository<Tarefa>
    {
        TarefaDTO CadastrarTarefa(string nome, int statusId);
        TarefaDTO AtualizarTarefa(int tarefaId);
        TarefaDTO BuscarTarefaPorId(int tarefaId);
        IEnumerable<TarefaDTO> BuscarTarefaPorNome(string tarefaNome);
        IEnumerable<TarefaDTO> BuscarTarefas();
        IEnumerable<TarefaDTO> BuscarTarefasPendentes();
        IEnumerable<TarefaDTO> BuscarTarefasAtrasadas();
        IEnumerable<TarefaDTO> BuscarTarefasCanceladas();
        IEnumerable<TarefaDTO> BuscarTarefasRealizadas();
    }
}
