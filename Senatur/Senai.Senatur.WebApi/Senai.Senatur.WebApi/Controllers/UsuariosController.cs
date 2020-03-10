using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Senatur.WebApi.Interfaces;
using Senai.Senatur.WebApi.Repositories;

namespace Senai.Senatur.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository _usuariosRepository;

        public UsuariosController()
        {
            _usuariosRepository = new UsuariosRepository();
        }

        [HttpGet("TiposUsuario")]
        public IActionResult GetTiposUsuario()
        { 
            return Ok(_usuariosRepository.ListarComTiposUsuario());
        }


    }
}