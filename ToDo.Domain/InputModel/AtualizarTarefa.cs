﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToDo.Domain.InputModel
{
    public class AtualizarTarefa
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int StatusId { get; set; }
    }
}
