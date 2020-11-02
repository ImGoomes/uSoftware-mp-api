using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using usoftware_mp_lib.Model;
using usoftware_mp_lib.Repository;

namespace uSoftware_mp_api.Controllers
{
    [Route("api/[controller]")]
    public class PromotoriasController : Controller
    {
        private PromotoriasRepository _promotoriasRepository;
        private OpnioesRepository _opnioesRepository;

        public PromotoriasController(IConfiguration configuration, PromotoriasRepository promotoriasRepository, OpnioesRepository opnioesRepository)
        {
            _promotoriasRepository = promotoriasRepository;
            _opnioesRepository = opnioesRepository;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var promotorias = _promotoriasRepository.SelectList();
                foreach (var item in promotorias)
                {
                    item.Opinioes = (System.Collections.Generic.List<Opnioes>)_opnioesRepository.SelectByPromotoriaID(item.ID);

                }
                return Ok(promotorias);
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

                var promotoria =  _promotoriasRepository.SelectByID(id);
                promotoria.Opinioes = (System.Collections.Generic.List<Opnioes>)_opnioesRepository.SelectByPromotoriaID(promotoria.ID);

                return Ok(promotoria);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] Promotorias promotorias)
        {
            try
            {
                _promotoriasRepository.Insert(promotorias);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Promotorias promotorias, int id)
        {
            try
            {
                if (id > 0 && id == promotorias.ID)
                    _promotoriasRepository.Update(promotorias);
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

                _promotoriasRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
