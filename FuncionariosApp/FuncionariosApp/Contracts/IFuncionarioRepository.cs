using FuncionariosApp.Models;

namespace FuncionariosApp.Contracts;

	public interface IFuncionarioRepository
{
    IEnumerable<Funcionario> ObterTodos();
    Funcionario ObterFuncionario(Guid id);
    void CriarFuncionario(Funcionario funcionario);
}
