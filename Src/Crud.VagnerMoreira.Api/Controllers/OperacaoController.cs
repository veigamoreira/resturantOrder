using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Net;
using Crud.VagnerMoreira.Application.Interfaces;
using Crud.VagnerMoreira.Application.ViewModels;

namespace Crud.VagnerMoreira.Api.Controllers
{
    // Obs: Sempre "retorno" um Ok e não uso try catch porque criei dois middlewares, um que faz o tratamento do response e o outro de erros (exceptions) da aplicação
    [Route("api/Usuario")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IOperacaoAppService _UsuarioAppService;

        public UsuarioController(IOperacaoAppService UsuarioAppService)
        {
            _UsuarioAppService = UsuarioAppService;
        }

        [HttpPost("adicionar")]
        [ProducesResponseType(typeof(UsuarioAdicionarResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Adicionar(OperacaoRequest request)
        {
            UsuarioAdicionarResponse response = _UsuarioAppService.Adicionar(request);
            return Ok(response);
        }      
    }
}