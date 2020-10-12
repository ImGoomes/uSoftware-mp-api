using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using usoftware_mp_lib.Model;
using usoftware_mp_lib.Repository;

namespace uSoftware_mp_api.Controllers
{
    [Route("api/[controller]")]
    public class PromotoresController : Controller
    {
        private PromotoresRepository _promotoresRepository;
        private UsuariosRepository _usuariosRepository;

        public PromotoresController(IConfiguration configuration, PromotoresRepository promotoresRepository, UsuariosRepository usuariosRepository)
        {
            _promotoresRepository = promotoresRepository;
            _usuariosRepository = usuariosRepository;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_promotoresRepository.SelectAll());
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

                var promotor = _promotoresRepository.SelectByID(id);

                return Ok(promotor);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] Usuarios usuarios)
        {
            try
            {
                _usuariosRepository.Insert(usuarios);

                var usuario = _usuariosRepository.LastUser();

                _promotoresRepository.Insert(new Promotores
                {
                    Nome = usuario.Nome,
                    UsuarioID = usuario.ID
                });

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Promotores promotores, int id)
        {
            try
            {
                if (id > 0 && id == promotores.ID)
                    _promotoresRepository.Update(promotores);
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

                _promotoresRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
