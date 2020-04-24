using Crud.VagnerMoreira.Application.Interfaces;
using Crud.VagnerMoreira.Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace Crud.VagnerMoreira.Api.Controllers
{
    // Obs: Sempre "retorno" um Ok e não uso try catch porque criei dois middlewares, um que faz o tratamento do response e o outro de erros (exceptions) da aplicação
    [Route("api/")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IOperacaoAppService _OrderAppService;

        public UsuarioController(IOperacaoAppService OrderAppService)
        {
            _OrderAppService = OrderAppService;
        }

        [HttpPost("order")]
        [ProducesResponseType(typeof(OrderResponse), (int)HttpStatusCode.OK)]
        [ProducesResponseType((int)HttpStatusCode.BadRequest)]
        public IActionResult Order(OrderRequestViewModel order)
        {
            var response = _OrderAppService.Order(order.Order);
            return Ok(response);
        }
    }
}