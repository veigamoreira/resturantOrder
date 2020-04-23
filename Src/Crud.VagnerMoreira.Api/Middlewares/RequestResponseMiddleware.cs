using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Crud.VagnerMoreira.Application.ViewModels;

namespace Crud.VagnerMoreira.Api.Middlewares
{
    public class RequestResponseMiddleware
    {
        private readonly RequestDelegate _next;

        public RequestResponseMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            try
            {
                var method = context.Request.Method;
                var request = context.Request;
                var originalBodyStream = context.Response.Body;

                using (var responseBody = new MemoryStream())
                {
                    context.Response.Body = responseBody;
                    await _next(context);

                    // Verifica o status code do response
                    context.Response.StatusCode = await ObterStatusCode(context.Response);

                    await responseBody.CopyToAsync(originalBodyStream);
                }
            }
            catch (Exception exception)
            {
                throw new Exception(exception.Message);
            }
        }

        private async Task<int> ObterStatusCode(HttpResponse response)
        {
            response.Body.Seek(0, SeekOrigin.Begin);
            Encoding utf8 = new UTF8Encoding(false);
            string text = await new StreamReader(response.Body, utf8).ReadToEndAsync();
            response.Body.Seek(0, SeekOrigin.Begin);

            // Verificar se teve algum erro de negócio e voltar StatusCode diferente de 200 para o angular
            IList<ErroViewModel> list = new List<ErroViewModel>();

            var responseErros = new { Erros = list };
            if (text.ToLower().Contains("erros"))
            {
                var responseObject = JsonConvert.DeserializeAnonymousType(text, responseErros);
                if (responseObject != null && responseObject.Erros != null && responseObject.Erros.Any())
                {
                    response.StatusCode = responseObject.Erros.First(x => x.Codigo > 0).Codigo;
                }
            }

            return response.StatusCode;
        }
    }
}
