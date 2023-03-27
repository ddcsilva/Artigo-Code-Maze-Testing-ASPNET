using FuncionariosApp.Validations;

namespace FuncionariosApp.Tests.Validations;

public class NumeroContaValidationTests
{
    private readonly NumeroContaValidation _validation;

    public NumeroContaValidationTests()
    {
        _validation = new NumeroContaValidation();
    }

    [Fact]
    public void IsValid_NumeroContaValida_RetornaVerdadeiro()
    {
        Assert.True(_validation.IsValid("123-4543234576-23"));
    }

    [Theory]
    [InlineData("1234-3454565676-23")]
    [InlineData("12-3454565676-23")]
    public void IsValid_ParteInicialNumeroContaErrada_RetornaFalso(string numeroConta)
    {
        Assert.False(_validation.IsValid(numeroConta));
    }

    [Theory]
    [InlineData("123-345456567-23")]
    [InlineData("123-345456567633-23")]
    public void IsValid_ParteMeioNumeroContaErrada_RetornaFalso(string numeroConta)
    {
        Assert.False(_validation.IsValid(numeroConta));
    }

    [Theory]
    [InlineData("123-3434545656-2")]
    [InlineData("123-3454565676-233")]
    public void IsValid_ParteFinalNumeroContaErrada_RetornaFalso(string numeroConta)
    {
        Assert.False(_validation.IsValid(numeroConta));
    }

    [Theory]
    [InlineData("123-345456567633=23")]
    [InlineData("123+345456567633-23")]
    [InlineData("123+345456567633=23")]
    public void IsValid_DelimitadoresInvalidos_LancaArgumentException(string numeroConta)
    {
        Assert.Throws<ArgumentException>(() => _validation.IsValid(numeroConta));
    }
}
