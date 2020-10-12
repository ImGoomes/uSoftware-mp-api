using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using usoftware_mp_lib.Model;
using usoftware_mp_lib.Repository;

namespace uSoftware_mp_api.Controllers
{
    [Route("api/[controller]")]
    public class CidadaosController : Controller
    {
        private CidadaosRepository _cidadaosRepository;
        private UsuariosRepository _usuariosRepository;

        public CidadaosController(IConfiguration configuration, CidadaosRepository cidadaosRepository, UsuariosRepository usuariosRepository)
        {
            _cidadaosRepository = cidadaosRepository;
            _usuariosRepository = usuariosRepository;
        }

        [Authorize("Bearer")]
        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_cidadaosRepository.SelectAll());
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

                var cidadao = _cidadaosRepository.SelectByID(id);

                return Ok(cidadao);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost]
        public IActionResult Post([FromBody] Cidadaos cidadaos)
        {
            try
            {
                _usuariosRepository.Insert(new Usuarios
                {
                    Nome = cidadaos.Nome,
                    Login = cidadaos.Cpf,
                    Senha = cidadaos.Cpf.Substring(0, 4),
                    Ativo = true
                });

                var usuario = _usuariosRepository.LastUser();

                // Insere com usuário id
                cidadaos.UsuarioID = usuario.ID;
                _cidadaosRepository.Insert(cidadaos);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPut("{id}")]
        public IActionResult Put([FromBody] Cidadaos cidadaos, int id)
        {
            try
            {
                if (id > 0 && id == cidadaos.ID)
                    _cidadaosRepository.Update(cidadaos);
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

                _cidadaosRepository.Delete(id);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

    }
}
