using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FuncionariosApp.Models;

[Table("Funcionario")]
public class Funcionario
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "Nome é obrigatório")]
    public string? Nome { get; set; }

    [Required(ErrorMessage = "Idade é obrigatório")]
    public int Idade { get; set; }

    [Required(ErrorMessage = "Numero da Conta é obrigatório")]
    public string? NumeroConta { get; set; }
}
