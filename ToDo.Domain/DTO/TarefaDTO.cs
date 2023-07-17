using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.DTO
{
    public class TarefaDTO
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int StatusId { get; set; }
        public int UserId { get; set; }
    }
}
