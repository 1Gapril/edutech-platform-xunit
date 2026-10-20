using EduTechPlatform.App;

Console.WriteLine("==================================================");
Console.WriteLine("       EduTechPlatform - Gestão Acadêmica         ");
Console.WriteLine("       Garantia e Qualidade de Software (.NET 10) ");
Console.WriteLine("==================================================");
Console.WriteLine();
Console.WriteLine("Equipe de Desenvolvimento:");
Console.WriteLine(" - Fernando: Backend & Regras de Serviço (Dev 1)");
Console.WriteLine(" - Lucas:    Qualidade & Testes Unitários xUnit (Dev 2)");
Console.WriteLine(" - Luiz:     DevOps, Versionamento & Documentação (Dev 3)");
Console.WriteLine();

// 1. Demonstração NotaDesempenhoService
var notaService = new NotaDesempenhoService();
decimal media = notaService.CalcularMediaPonderada(7.0m, 7.0m, 7.0m);
string situacao = notaService.ObterSituacaoAcademica(media);
Console.WriteLine($"[NotaDesempenhoService] Média: {media:F2} | Situação: {situacao}");

// 2. Demonstração FrequenciaService
var freqService = new FrequenciaService();
double frequencia = freqService.CalcularPorcentagemPresenca(80, 20);
bool aprovadoFreq = freqService.AprovadoPorFrequencia(80, 20);
Console.WriteLine($"[FrequenciaService] Presença: {frequencia:F1}% | Aprovado por Freq: {aprovadoFreq}");

// 3. Demonstração MatriculaFinanceiraService
var finService = new MatriculaFinanceiraService();
decimal valorComDesconto = finService.CalcularValorMensalidade(1000.00m, 4, false);
bool podeRematricular = finService.PodeRealizarRematricula(false, situacao);
Console.WriteLine($"[MatriculaFinanceiraService] Mensalidade: R$ {valorComDesconto:F2} | Rematrícula: {podeRematricular}");

Console.WriteLine();
Console.WriteLine("Execute 'dotnet test' para rodar a suíte completa de testes xUnit.");
