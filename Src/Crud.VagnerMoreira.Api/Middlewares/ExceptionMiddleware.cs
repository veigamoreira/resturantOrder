using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Net;
using Crud.VagnerMoreira.Application.ViewModels;

namespace Crud.VagnerMoreira.Api.Middlewares
{
    public static class ExceptionMiddleware
    {
        public static void ConfigureExceptionHandler(this IApplicationBuilder app)
        {
            app.UseExceptionHandler(appError =>
            {
                appError.Run(async context =>
                {
                    context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;
                    context.Response.ContentType = "application/json";

                    // Faço o tratamento de erros e adiciono o erro no objeto do response que será capturado pelo middleware de RequestResponse
                    var contextFeature = context.Features.Get<IExceptionHandlerFeature>();
                    var response = new { erros = new List<ErroViewModel>(0) };
                    if (contextFeature != null)
                    {
                        response.erros.Add(new ErroViewModel { Codigo = 500, Descricao = "Erro inesperado no servidor - " + contextFeature.Error.Message });
                    }
                    await context.Response.WriteAsync(JsonConvert.SerializeObject(response));
                });
            });
        }
    }
}
