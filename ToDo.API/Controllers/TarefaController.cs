using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using ToDo.Domain.DTO;
using ToDo.Domain.Enums;
using ToDo.Domain.InputModel;
using ToDo.Domain.Interfaces;
using ToDo.Domain.Models;

namespace ToDo.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TarefaController : ControllerBase
    {
        private readonly ITarefaRepository _tarefaRepository;

        public TarefaController(ITarefaRepository tarefaRepository)
        {
            _tarefaRepository = tarefaRepository;
        }

        [HttpPost]
        [Route(nameof(TarefaController.Cadastrar))]
        public async Task<dynamic> Cadastrar([FromBody] CadastrarTarefa tarefa)
        {
            try
            {
                if (!String.IsNullOrEmpty(tarefa.Nome))
                {
                    _tarefaRepository.CadastrarTarefa(tarefa.Nome, tarefa.StatusId);
                    return Ok("Cadastro realizado com sucesso!");
                }
                else throw new Exception();

            }
            catch (Exception e)
            {
                return BadRequest("Nome não pode ser nulo.");
            }
        }

        [HttpPut]
        [Route(nameof(TarefaController.Atualizar))]
        public async Task<dynamic> Atualizar([FromBody] AtualizarTarefa tarefa)
        {
            try
            {
                if (!String.IsNullOrEmpty(tarefa.Nome) && tarefa.StatusId != null)
                {
                    var tarefaAtual = _tarefaRepository.GetById(tarefa.Id);

                    if (tarefaAtual == null)
                    {
                        return NotFound("Tarefa não encontrada.");
                    }

                    tarefaAtual.Atualizar(tarefa.Nome, tarefa.StatusId);

                    var result = _tarefaRepository.AtualizarTarefa(tarefaAtual.Id);
                    if (result != null)
                    {
                        return Ok("Atualização realizada com sucesso!");
                    }
                    throw new Exception();
                }

                else throw new Exception();

            }
            catch (Exception e)
            {
                return BadRequest("Os valores não podem ser nulos.");
            }
        }

        [HttpGet]
        [Route(nameof(TarefaController.BuscarPorId))]
        public async Task<dynamic> BuscarPorId(int tarefaId)
        {
            try
            {
                var tarefa = _tarefaRepository.BuscarTarefaPorId(tarefaId);
                if (tarefa != null) return Ok(tarefa);
                throw new Exception();
            }
            catch (Exception e)
            {
                return NotFound("Tarefa não encontrada.");
            }
        }

        [HttpGet]
        [Route(nameof(TarefaController.BuscarPorNome))]
        public async Task<dynamic> BuscarPorNome(string nome)
        {
            try
            {
                if (!String.IsNullOrEmpty(nome)) {
                    var tarefa = _tarefaRepository.BuscarTarefaPorNome(nome);

                    if (tarefa.Count() <= 0)
                    {
                        return NotFound("Tarefa não encontrada.");
                    }
                    return Ok(tarefa);
                }
                throw new Exception();
            }
            catch (Exception e)
            {
                return BadRequest("Nome não pode ser nulo.");
            }
        }

        [HttpGet]
        [Route(nameof(TarefaController.BuscarTarefas))]
        public async Task<dynamic> BuscarTarefas()
        {
            try
            {
                var tarefas = _tarefaRepository.BuscarTarefas();
                if (tarefas.Count() > 0) return Ok(tarefas);
                throw new Exception();
            }
            catch (Exception e)
            {
                return NotFound("Não há tarefas cadastradas.");
            }
        }

        [HttpGet]
        [Route(nameof(TarefaController.BuscarTarefasPendentes))]
        public async Task<dynamic> BuscarTarefasPendentes()
        {
            try
            {
                var tarefas = _tarefaRepository.BuscarTarefasPendentes();
                if (tarefas.Count() > 0) return Ok(tarefas);
                throw new Exception();
            }
            catch (Exception e)
            {
                return NotFound("Não há tarefas pendentes.");
            }
        }

        [HttpGet]
        [Route(nameof(TarefaController.BuscarTarefasAtrasadas))]
        public async Task<dynamic> BuscarTarefasAtrasadas()
        {
            try
            {
                var tarefas = _tarefaRepository.BuscarTarefasAtrasadas();
                if (tarefas.Count() > 0) return Ok(tarefas);
                throw new Exception();
            }
            catch (Exception e)
            {
                return NotFound("Não há tarefas atrasadas.");
            }
        }

        [HttpGet]
        [Route(nameof(TarefaController.BuscarTarefasCanceladas))]
        public async Task<dynamic> BuscarTarefasCanceladas()
        {
            try
            {
                var tarefas = _tarefaRepository.BuscarTarefasCanceladas();
                if (tarefas.Count() > 0) return Ok(tarefas);
                throw new Exception();
            }
            catch (Exception e)
            {
                return NotFound("Não há tarefas atrasadas.");
            }
        }

        [HttpGet]
        [Route(nameof(TarefaController.BuscarTarefasRealizadas))]
        public async Task<dynamic> BuscarTarefasRealizadas()
        {
            try
            {
                var tarefas = _tarefaRepository.BuscarTarefasRealizadas();
                if (tarefas.Count() > 0) return Ok(tarefas);
                throw new Exception();
            }
            catch (Exception e)
            {
                return NotFound("Não há tarefas realizadas.");
            }
        }

        [HttpPut]
        [Route(nameof(TarefaController.AtualizarStatus))]
        public async Task<dynamic> AtualizarStatus([FromBody] AtualizarStatus atualizarStatus)
        {
            try
            {
                if (!String.IsNullOrEmpty(atualizarStatus.Status))
                {
                    var tarefa = _tarefaRepository.GetById(atualizarStatus.tarefaId);

                    if (tarefa == null)
                    {
                        return NotFound("Tarefa não encontrada.");
                    }

                    int novoStatusId = 0;

                    if (atualizarStatus.Status.ToUpper() == "REALIZADA") { novoStatusId = (int)StatusEnum.REALIZADA; }
                    if (atualizarStatus.Status.ToUpper() == "PENDENTE") { novoStatusId = (int)StatusEnum.PENDENTE; }
                    if (atualizarStatus.Status.ToUpper() == "CANCELADA") { novoStatusId = (int)StatusEnum.CANCELADA; }
                    if (atualizarStatus.Status.ToUpper() == "ATRASADA") { novoStatusId = (int)StatusEnum.ATRASADA; }

                    if (novoStatusId == 0)
                    {
                        return NotFound("Status não encontrado.");
                    }

                    tarefa.AtualizarStatus(novoStatusId);

                    var result = _tarefaRepository.AtualizarTarefa(tarefa.Id);
                    if (result != null)
                    {
                        return Ok("Atualização realizada com sucesso!");
                    }                    
                }
                throw new Exception();

            }
            catch (Exception e)
            {
                return BadRequest("Status não pode ser nulo.");
            }
        }
    }
}
