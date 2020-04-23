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
    public class UsuarioUnitTest
    {
        private readonly IServiceCollection _serviceCollection;
        private readonly ServiceProvider _services;
        private IOperacaoAppService _UsuarioAppService;
        private readonly Mock<IOperacaoRepository> _UsuarioRepositoryMock;
        private readonly Faker _faker;

        public UsuarioUnitTest()
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
        public void DeveEfetuarUmLancamento()
        {
            _UsuarioAppService = _services.GetService<IOperacaoAppService>();
            OperacaoRequest request = new OperacaoRequest
            {
                ContaOrigem = _faker.Finance.Account(),
                ContaDestino = _faker.Finance.Account(),
               Valor =  _faker.Finance.Amount()
            };

            UsuarioAdicionarResponse response = _UsuarioAppService.Adicionar(request);

            Assert.Contains(response.Erros, x => x.Descricao == "Conta é obrigatório" && x.Codigo == 400);
        }

        [Fact]
        public void Deve_Adicionar_Quando_Todos_Os_Campos_Estao_Preenchidos()
        {
            _UsuarioAppService = _services.GetService<IOperacaoAppService>();
            OperacaoRequest request = new OperacaoRequest
            {
                
            };

            _UsuarioRepositoryMock.Setup(r => r.Adicionar(It.IsAny<Lancamento>())).Returns(_faker.Random.Number(1, 100));
            UsuarioAdicionarResponse response = _UsuarioAppService.Adicionar(request);

            Assert.True(response.Id > 0);
            Assert.True(!response.Erros.Any());
        }

        // TODO:: Incluir outros testes
    }
}