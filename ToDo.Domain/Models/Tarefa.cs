using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.Models
{
    public class Tarefa
    {
        public int Id { get; private set; }
        public string Nome { get; private set; }
        public int StatusId { get; private set; }

        public Tarefa(string nome, int statusId)
        {
            Nome = nome;
            StatusId = statusId;
        }
    }
}
