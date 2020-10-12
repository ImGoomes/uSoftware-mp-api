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

        public AtendimentosController(IConfiguration configuration, AtendimentosRepository atendimentosRepository)
        {
            _atendimentosRepository = atendimentosRepository;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_atendimentosRepository.SelectList());
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

                var cidadao = _atendimentosRepository.SelectDetail(id);

                return Ok(cidadao);
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
                    _atendimentosRepository.Update(atendimentos);
                else
                    return BadRequest("Informe o id");

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

    }
}
