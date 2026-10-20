using EduTechPlatform.App;
using Xunit;

namespace EduTechPlatform.Tests;

public class NotaDesempenhoServiceTests
{
    private readonly NotaDesempenhoService _service;

    public NotaDesempenhoServiceTests()
    {
        _service = new NotaDesempenhoService();
    }

    [Theory]
    [InlineData(7.0, 7.0, 7.0, 7.0)]
    [InlineData(10.0, 10.0, 5.0, 8.0)]
    public void CalcularMediaPonderada_DeveRetornarMediaEsperada(decimal nota1, decimal nota2, decimal notaProjeto, decimal esperado)
    {
        // Act
        decimal resultado = _service.CalcularMediaPonderada(nota1, nota2, notaProjeto);

        // Assert
        Assert.Equal(esperado, resultado);
    }

    [Theory]
    [InlineData(8.5, "APROVADO")]
    [InlineData(6.0, "RECUPERACAO")]
    [InlineData(4.2, "REPROVADO")]
    public void ObterSituacaoAcademica_DeveRetornarSituacaoEsperada(decimal mediaFinal, string esperado)
    {
        // Act
        string resultado = _service.ObterSituacaoAcademica(mediaFinal);

        // Assert
        Assert.Equal(esperado, resultado);
    }
}
