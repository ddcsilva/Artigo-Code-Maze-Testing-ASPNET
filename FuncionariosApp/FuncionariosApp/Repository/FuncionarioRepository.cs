using FuncionariosApp.Contracts;
using FuncionariosApp.Models;

namespace FuncionariosApp.Repository;

public class FuncionarioRepository : IFuncionarioRepository
{
    private readonly FuncionarioContext _context;

    public FuncionarioRepository(FuncionarioContext context)
    {
        _context = context;
    }

    public IEnumerable<Funcionario> ObterTodos()
    {
        return _context.Funcionarios.ToList();
    }

    public Funcionario ObterFuncionario(Guid id)
    {
        return _context.Funcionarios.SingleOrDefault(e => e.Id.Equals(id));
    }

    public void CriarFuncionario(Funcionario funcionario)
    {
        _context.Add(funcionario);
        _context.SaveChanges();
    }
}
