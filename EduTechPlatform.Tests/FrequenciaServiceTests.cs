using EduTechPlatform.App;
using Xunit;

namespace EduTechPlatform.Tests;

public class FrequenciaServiceTests
{
    private readonly FrequenciaService _service;

    public FrequenciaServiceTests()
    {
        _service = new FrequenciaService();
    }

    [Theory]
    [InlineData(80, 20, 75.0)]
    [InlineData(100, 10, 90.0)]
    public void CalcularPorcentagemPresenca_DeveRetornarPercentualEsperado(int aulasTotais, int faltas, double esperado)
    {
        // Act
        double resultado = _service.CalcularPorcentagemPresenca(aulasTotais, faltas);

        // Assert
        Assert.Equal(esperado, resultado, 2);
    }

    [Theory]
    [InlineData(80, 20, true)]
    [InlineData(80, 21, false)]
    public void AprovadoPorFrequencia_DeveValidarPresencaMinima(int aulasTotais, int faltas, bool esperado)
    {
        // Act
        bool resultado = _service.AprovadoPorFrequencia(aulasTotais, faltas);

        // Assert
        Assert.Equal(esperado, resultado);
    }
}
