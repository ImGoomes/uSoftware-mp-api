using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using usoftware_mp_lib.Model;
using usoftware_mp_lib.Repository;

namespace uSoftware_mp_api.Controllers
{
    [Route("api/[controller]")]
    public class AtendimentosController : Controller
    {
        private AtendimentosRepository _atendimentosRepository;
        private SituacaoRepository _situacaoRepository;

        public AtendimentosController(IConfiguration configuration, AtendimentosRepository atendimentosRepository, SituacaoRepository situacaoRepository)
        {
            _atendimentosRepository = atendimentosRepository;
            _situacaoRepository = situacaoRepository;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var atendimentos = _atendimentosRepository.SelectList();

                foreach (var item in atendimentos)
                {
                    item.situacoes = (System.Collections.Generic.List<Situacao>)_situacaoRepository.SelectByAtendimento(item.ID);

                }

                return Ok(atendimentos);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Informe o id");

                var atendimento = _atendimentosRepository.SelectDetail(id);
                atendimento.situacoes = (System.Collections.Generic.List<Situacao>)_situacaoRepository.SelectByAtendimento(atendimento.ID);

                return Ok(atendimento);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] Atendimentos atendimentos)
        {
            try
            {
                var random = new Random();
                atendimentos.Protocolo = String.Concat("P-", random.Next(100000, 999999).ToString());
                _atendimentosRepository.Insert(atendimentos);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Atendimentos atendimentos, int id)
        {
            try
            {
                if (id > 0 && id == atendimentos.ID)
                {
                    _atendimentosRepository.Update(atendimentos);
                    foreach (var item in atendimentos.situacoes)
                    {
                        _situacaoRepository.UpdateByAtendimento(item);
                    }
                }
                else
                {
                    return BadRequest("Informe o id");
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (id <= 0)
                    return BadRequest("Informe o id");

                _atendimentosRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut("AtualizaStatus/{id}")]
        public IActionResult AtualizaStatus([FromBody] Atendimentos atendimentos, int id)
        {
            try
            {
                if (id > 0 && id == atendimentos.ID)
                {
                    var atendimento = _atendimentosRepository.SelectByID(atendimentos.ID);
                    atendimento.Status = atendimentos.Status;
                    atendimento.Etapa = atendimentos.Etapa;
                    _atendimentosRepository.Update(atendimento);
                }
                else
                {
                    return BadRequest("Informe o id");
                }
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
