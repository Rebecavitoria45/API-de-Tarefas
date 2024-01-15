using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ApiTarefas.Dto
{
    public record TarefaDto
    {
         public string Titulo { get; set; } = default;
      
         public string Descricao { get; set; } = default;
         public bool Concluida { get; set; } = default;
    }
}