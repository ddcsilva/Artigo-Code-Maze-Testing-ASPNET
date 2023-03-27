using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using FuncionariosApp.Models;
using FuncionariosApp.Contracts;
using FuncionariosApp.Validations;

namespace FuncionariosApp.Controllers;

public class FuncionariosController : Controller
{
    private readonly IFuncionarioRepository _funcionarioRepository;
    private readonly NumeroContaValidation _numeroContaValidation;

    public FuncionariosController(IFuncionarioRepository funcionarioRepository)
    {
        _funcionarioRepository = funcionarioRepository;
        _numeroContaValidation = new NumeroContaValidation();
    }

    public IActionResult Index()
    {
        var funcionarios = _funcionarioRepository.ObterTodos();
        return View(funcionarios);
    }

    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create([Bind("Nome,NumeroConta,Idade")] Funcionario funcionario)
    {
        if(!ModelState.IsValid)
        {
            return View(funcionario);
        }

        if(!_numeroContaValidation.IsValid(funcionario.NumeroConta))
        {
            ModelState.AddModelError("NumeroConta", "O Número da Conta está inválido!");
            return View(funcionario);
        }

        _funcionarioRepository.CriarFuncionario(funcionario);
        return RedirectToAction(nameof(Index));
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
