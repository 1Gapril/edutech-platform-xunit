using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduTechPlatform.Tests
{
    public class FrequenciaServiceTests
    {
        [Theory]
        [InlineData(80, 20, 75.0)] // (60 presenças em 80 aulas = 75%)
        [InlineData(100, 10, 90.0)] // (90 presenças em 100 aulas = 90%)

        public void CalculoPercentualDePresenca(int aulas, int faltas, decimal PercentualEsperado)
        {
            var service = new FrequenciaService();
            int resultado = service.CalculoPercentualDePresenca(aulas,faltas,PercentualEsperado);

            Assert.Equal(PercentualEsperado,resultado);
        }

        [Theory]
        [InlineData(80, 20, true)] // (75% de presença -> Aprovado)
        [InlineData(80, 21, false)] // (Abaixo de 75% -> Reprovado por falta)

        public void AprovacaoPorFrequencia_DeveRetornarValorCorreto(int aulas, int faltas, bool ResultadoEsperado)
        {
            var service = new FrequenciaService();

            bool resultado = service.AprovacaoPorFrequencia(aulas,faltas);

            Assert.Equal(ResultadoEsperado,resultado);
        }
    }
}