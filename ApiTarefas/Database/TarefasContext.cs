using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTarefas.models;
using Microsoft.EntityFrameworkCore;

namespace ApiTarefas.Database
{
    public class TarefasContext : DbContext
    {
        public TarefasContext(DbContextOptions<TarefasContext>options) : base(options){

        }
        public DbSet<Tarefa> Tarefas{get;set;}
    }
}