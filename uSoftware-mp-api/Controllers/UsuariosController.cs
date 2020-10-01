using System;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using usoftware_mp_lib.Repository;
using usoftware_mp_lib.Model;
using Microsoft.Extensions.Configuration;

namespace uSoftware_mp_api.Controllers
{
    [Route("api/[controller]")]
    public class UsuariosController : Controller
    {
        private UsuariosRepository _usuariosRepository;

        public UsuariosController(IConfiguration configuration, UsuariosRepository usuariosRepository)
        {
            _usuariosRepository = usuariosRepository;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_usuariosRepository.SelectAll());
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

                return Ok(_usuariosRepository.SelectByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] Usuarios usuario)
        {
            try
            {
                _usuariosRepository.Insert(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Usuarios usuario, int id)
        {
            try
            {
                if (id > 0 && id == usuario.ID)
                    _usuariosRepository.Update(usuario);
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

                _usuariosRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
