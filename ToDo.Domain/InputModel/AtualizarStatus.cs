using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.InputModel
{
    public class AtualizarStatus
    {

        public int tarefaId { get; set; }
        public string Status { get; set; }
    }
}
