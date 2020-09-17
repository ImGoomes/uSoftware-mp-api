    using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using uSoftware_mp_api.Auth;
using usoftware_mp_lib.Model;
using usoftware_mp_lib.Repository;

namespace uSoftware_mp_api.Controllers
{
    [Route("api/[controller]")]
    public class PromotoriasController : Controller
    {
        private PromotoriasRepository _promotoriasRepository;


        public PromotoriasController(IConfiguration configuration, PromotoriasRepository promotoriasRepository)
        {
            _promotoriasRepository = promotoriasRepository;
        }

        [Authorize("Bearer")]
        [HttpGet("Promotorias")]
        public IActionResult GetAll()
        {
            try
            {
                return Ok(_promotoriasRepository.SelectAll());
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpGet("Promotorias/{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                return Ok(_promotoriasRepository.SelectByID(id));
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [Authorize("Bearer")]
        [HttpPost("Promotorias")]
        public IActionResult Post([FromBody]Promotorias promotorias)
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
        [HttpPut("Promotorias/{id}")]
        public IActionResult Put([FromBody] Promotorias promotorias, int id)
        {
            try
            {
                if(id > 0 && id == promotorias.ID)
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
        [HttpDelete("Promotorias/{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
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
