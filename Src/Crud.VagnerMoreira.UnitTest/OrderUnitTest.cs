using AutoMapper;
using Bogus;
using Microsoft.Extensions.DependencyInjection;
using Moq;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using Crud.VagnerMoreira.Application.AppServices;
using Crud.VagnerMoreira.Application.AutoMapper;
using Crud.VagnerMoreira.Application.Interfaces;
using Crud.VagnerMoreira.Application.ViewModels;
using Crud.VagnerMoreira.Data.Dapper.Repositories;
using Crud.VagnerMoreira.Domain.Interfaces.Repositories;
using Crud.VagnerMoreira.Domain.Interfaces.Services;
using Crud.VagnerMoreira.Domain.Models;
using Crud.VagnerMoreira.Domain.Services;
using Crud.VagnerMoreira.Domain.Validacoes;
using Xunit;

namespace Crud.VagnerMoreira.UnitTest
{
    public class OrderUnitTest
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly ServiceProvider _services;
        private IOperacaoAppService _UsuarioAppService;
        private readonly Mock<IOperacaoRepository> _UsuarioRepositoryMock;
        private readonly Faker _faker;

        public OrderUnitTest()
        {
            // Faker
            _faker = new Faker();

            // Mock
            _UsuarioRepositoryMock = new Mock<IOperacaoRepository>();

            // IoC
            _serviceCollection = new ServiceCollection();
            _serviceCollection.AddSingleton(_UsuarioRepositoryMock.Object);
            _serviceCollection.AddTransient<IUnitOfWork, UnitOfWork>();
            _serviceCollection.AddTransient<IDbConnection>(x => new SqlConnection(@"Data Source=(localdb)\MSSQLLocalDB;Initial Catalog=teste_webmotors;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"));
            _serviceCollection.AddTransient<OperacaoValidacao>();
            _serviceCollection.AddTransient<IOperacaoService, OperacaoService>();
            _serviceCollection.AddSingleton<IConfigurationProvider>(AutoMapperConfiguration.RegisterMappings());
            _serviceCollection.AddTransient<IMapper>(x => new Mapper(x.GetRequiredService<IConfigurationProvider>(), x.GetService));
            _serviceCollection.AddTransient<IOperacaoAppService, OperacaoAppService>();
            _services = _serviceCollection.BuildServiceProvider();
        }

        [Fact]
        public void DeveEfetuarUmaOrder()
        {
            _UsuarioAppService = _services.GetService<IOperacaoAppService>();
            Order request = new Order
            {
                OrderRequest = "morning, 1, 2, 3"
            };

            var response = _UsuarioAppService.Order(request.OrderRequest);

           Assert.True(response.Erros == null || response.Erros.Count == 0);
        }

        [Fact]
        public void NãoDeveEfetuar()
        {

            _UsuarioAppService = _services.GetService<IOperacaoAppService>();
            Order request = new Order
            {
            };

            var response = _UsuarioAppService.Order(request.OrderRequest);

            Assert.True(response.Erros.Count > 0);
        }
    }
}