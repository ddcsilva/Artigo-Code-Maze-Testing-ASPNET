using FuncionariosApp.Contracts;
using FuncionariosApp.Controllers;
using FuncionariosApp.Models;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace FuncionariosApp.Tests.Controllers;

public class FuncionarioControllerTests
{
    private readonly Mock<IFuncionarioRepository> _mockRepository;
    private readonly FuncionariosController _controller;

    public FuncionarioControllerTests()
    {
        _mockRepository = new Mock<IFuncionarioRepository>();
        _controller = new FuncionariosController(_mockRepository.Object);
    }

    [Fact]
    public void Index_ExecutaAction_RetornaUmaView()
    {
        var resultado = _controller.Index();
        Assert.IsType<ViewResult>(resultado);
    }

    [Fact]
    public void Index_ExecutaAction_RetornaNumeroExatoDeFuncionários()
    {
        _mockRepository.Setup(repository => repository.ObterTodos()).Returns(new List<Funcionario>() { new Funcionario(), new Funcionario() });

        var resultado = _controller.Index();
        var viewResult = Assert.IsType<ViewResult>(resultado);
        var funcionarios = Assert.IsType<List<Funcionario>>(viewResult.Model);

        Assert.Equal(2, funcionarios.Count);
    }

    [Fact]
    public void Create_ExecutaAction_RetornaViewCreate()
    {
        var resultado = _controller.Create();

        Assert.IsType<ViewResult>(resultado);
    }

    [Fact]
    public void Create_ModelStateInvalido_RetornaView()
    {
        _controller.ModelState.AddModelError("Nome", "Nome é obrigaatório");

        var funcionario = new Funcionario { Idade = 25, NumeroConta = "255-8547963214-41" };

        var resultado = _controller.Create(funcionario);

        var viewResult = Assert.IsType<ViewResult>(resultado);
        var testEmployee = Assert.IsType<Funcionario>(viewResult.Model);

        Assert.Equal(funcionario.NumeroConta, testEmployee.NumeroConta);
        Assert.Equal(funcionario.Idade, testEmployee.Idade);
    }

    [Fact]
    public void Create_ModelStateInvalido_CreateFuncionarioNuncaPodeSerExecutado()
    {
        _controller.ModelState.AddModelError("Nome", "Nome é obrigaatório");

        var funcionario = new Funcionario { Idade = 34 };

        _controller.Create(funcionario);

        _mockRepository.Verify(x => x.CriarFuncionario(It.IsAny<Funcionario>()), Times.Never);
    }

    [Fact]
    public void Create_ModelStateValido_CriarFuncionarioComUnicaChamada()
    {
        Funcionario? fun = null;

        _mockRepository.Setup(r => r.CriarFuncionario(It.IsAny<Funcionario>()))
            .Callback<Funcionario>(x => fun = x);

        var funcionario = new Funcionario
        {
            Nome = "Test Employee",
            Idade = 32,
            NumeroConta = "123-5435789603-21"
        };

        _controller.Create(funcionario);
        _mockRepository.Verify(x => x.CriarFuncionario(It.IsAny<Funcionario>()), Times.Once);

        Assert.Equal(fun.Nome, funcionario.Nome);
        Assert.Equal(fun.Idade, funcionario.Idade);
        Assert.Equal(fun.NumeroConta, funcionario.NumeroConta);
    }

    [Fact]
    public void Create_ActionExecutada_RedirecionaParaIndex()
    {
        var funcionario = new Funcionario
        {
            Nome = "Test Employee",
            Idade = 45,
            NumeroConta = "123-4356874310-43"
        };

        var result = _controller.Create(funcionario);
        var redirectToActionResult = Assert.IsType<RedirectToActionResult>(result);

        Assert.Equal("Index", redirectToActionResult.ActionName);
    }
}
