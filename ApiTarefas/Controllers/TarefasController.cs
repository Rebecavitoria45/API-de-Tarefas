using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiTarefas.Database;
using ApiTarefas.Dto;
using ApiTarefas.models;
using ApiTarefas.Services;
using Microsoft.AspNetCore.Mvc;

namespace ApiTarefas.Controllers
{
    [ApiController]
    [Route("/tarefas")]
    public class TarefasController : ControllerBase
    {
        public TarefasController(TarefaService servico){
          _servico = servico;
        }
        private TarefaService _servico;
       
        [HttpGet]
        public IActionResult Index(){
            var tarefas = _servico.Lista();
            return StatusCode(200, tarefas);
        }

         [HttpPost("/tarefas/criar")]
         public IActionResult Create([FromBody] TarefaDto tarefaDto)
         {
         try{  var tarefa = _servico.Incluir(tarefaDto);
         return StatusCode(201 );
         }
         catch(Exception){
          return StatusCode(400,"Não foi possivel adicionar a tarefa");
         }
        }

        [HttpPut("{id}")]
         public IActionResult Update([FromRoute] int id,  [FromBody] TarefaDto tarefaDto)
         {
          try{
           var tarefa = _servico.Atualizar(id,tarefaDto);
           return StatusCode(200,tarefa);
          } catch(Exception){
            return StatusCode(400,"Não foi possivel atualizar tarefa");
          }
        }
       
        [HttpGet("{id}")]
         public IActionResult Show([FromRoute] int id)
         {
          try{
          var tarefa=_servico.BuscarPorId(id);
           return StatusCode(200,tarefa);
          }
          catch{
            return StatusCode(404,$"O Id {id} não encontrado");
          }
        }

         [HttpDelete("{id}")]
         public IActionResult Delete([FromRoute] int id)
         {
          try{
          _servico.Excluir(id);
           return StatusCode(204);
          }catch(Exception){
            return StatusCode(400,"Tarefa não encontrada");
          }
        }
    }
}