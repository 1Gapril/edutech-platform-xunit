using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EduTechPlatform.Tests
{
    public class NotaDesempenhoServiceTests
    {
        [Theory]
    [InlineData(7.0, 7.0, 7.0, 7.0)]
    [InlineData(10.0, 10.0, 5.0, 8.0)] // ( (30 + 30 + 20) / 10 = 8.0 )
        public void ValidarMediaPonderada_DeveRetornarMediaCorreta(decimal nota1, decimal nota2, decimal notaProjeto,decimal Media, decimal resultado_esperado)
        {
            var service = new NotaDesempenhoService();

            decimal resultado = service.ValidarMediaPonderada(nota1,nota2,notaProjeto);
           
           Assert.Equal(resultado_esperado,resultado);
        }
        [Theory]
        [InlineData(8.5, "APROVADO")]
        [InlineData(6.0, "RECUPERACAO")]
        [InlineData(4.2, "REPROVADO")]
        public void ValidarSituacaoAcademica_DeveRetornarSituacaoComBaseNaNota(decimal mediaFinal, string resultado_esperado)
        {
            var service = new NotaDesempenhoServiceTests();

            string resultado = service.ValidarSituacaoAcademica(mediaFinal);

            Assert.Equal(resultado_esperado,resultado)
        }
}