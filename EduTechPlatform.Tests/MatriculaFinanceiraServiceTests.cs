using EduTechPlatform.App;
using Xunit;

namespace EduTechPlatform.Tests;

public class MatriculaFinanceiraServiceTests
{
    private readonly MatriculaFinanceiraService _service;

    public MatriculaFinanceiraServiceTests()
    {
        _service = new MatriculaFinanceiraService();
    }

    [Theory]
    [InlineData(1000.00, 10, true, 500.00)]
    [InlineData(1000.00, 4, false, 900.00)]
    [InlineData(1000.00, 10, false, 1000.00)]
    public void CalcularValorMensalidade_DeveCalcularValorEsperado(decimal valorBase, int diaPagamento, bool eBolsista, decimal esperado)
    {
        // Act
        decimal resultado = _service.CalcularValorMensalidade(valorBase, diaPagamento, eBolsista);

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(false, "APROVADO", true)]
    [InlineData(true, "APROVADO", false)]
    [InlineData(false, "REPROVADO", false)]
    public void PodeRealizarRematricula_DeveValidarElegibilidade(bool possuiPendenciaFinanceira, string situacaoAcademica, bool esperado)
    {
        // Act
        bool resultado = _service.PodeRealizarRematricula(possuiPendenciaFinanceira, situacaoAcademica);

        // Assert
        Assert.Equal(esperado, resultado);
    }
}
