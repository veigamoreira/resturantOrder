using AutoMapper;
using Microsoft.Extensions.DependencyInjection;
using System.Data;
using System.Data.SqlClient;
using Crud.VagnerMoreira.Application.AppServices;
using Crud.VagnerMoreira.Application.AutoMapper;
using Crud.VagnerMoreira.Application.Interfaces;
using Crud.VagnerMoreira.Data.Dapper.Repositories;
using Crud.VagnerMoreira.Domain.Interfaces.Repositories;
using Crud.VagnerMoreira.Domain.Interfaces.Services;
using Crud.VagnerMoreira.Domain.Services;
using Crud.VagnerMoreira.Domain.Validacoes;

namespace Crud.VagnerMoreira.Infra.CrossCutting.IoC
{
    public class BootStrapper
    {
        public static void RegisterServices(IServiceCollection services)
        {
            // Repository - Aqui gosto de usar variavel de ambiente ou keyvault do azure para proteger a conexão com o banco de dados
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<IDbConnection>(x => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teste_webmotors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            services.AddTransient<IOperacaoRepository, OperacaoRepository>();

            // Validação
            services.AddTransient<OperacaoValidacao>();

            // Service
            services.AddTransient<IOperacaoService, OperacaoService>();

            // AppService
            services.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            services.AddTransient<IMapper>(x => new Mapper(x.GetRequiredService<IConfigurationProvider>(), x.GetService));
            services.AddTransient<IOperacaoAppService, OperacaoAppService>();
        }
    }
}