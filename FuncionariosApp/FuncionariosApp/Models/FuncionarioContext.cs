using Microsoft.EntityFrameworkCore;

namespace FuncionariosApp.Models;

public class FuncionarioContext : DbContext
{
    public FuncionarioContext(DbContextOptions options) : base(options) { }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Funcionario>().HasData
        (
            new Funcionario
            {
                Id = Guid.NewGuid(),
                Nome = "Mark",
                NumeroConta = "123-3452134543-32",
                Idade = 30
            },
            new Funcionario
            {
                Id = Guid.NewGuid(),
                Nome = "Evelin",
                NumeroConta = "123-9384613085-55",
                Idade = 28
            }
        );
    }

    public DbSet<Funcionario>? Funcionarios { get; set; }
}
