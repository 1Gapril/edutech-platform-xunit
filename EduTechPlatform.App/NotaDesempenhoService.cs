namespace EduTechPlatform.App;

/// <summary>
/// Responsável pelo cálculo de notas e determinação da situação acadêmica do aluno.
/// </summary>
public class NotaDesempenhoService
{
    /// <summary>
    /// Calcula a média ponderada com os seguintes pesos:
    /// Nota 1 (peso 3), Nota 2 (peso 3), Nota Projeto (peso 4).
    /// Fórmula: ((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10
    /// </summary>
    /// <param name="nota1">Primeira nota avaliativa (peso 3)</param>
    /// <param name="nota2">Segunda nota avaliativa (peso 3)</param>
    /// <param name="notaProjeto">Nota do projeto prático (peso 4)</param>
    /// <returns>Média ponderada calculada</returns>
    public decimal CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)
    {
        return ((nota1 * 3m) + (nota2 * 3m) + (notaProjeto * 4m)) / 10m;
    }

    /// <summary>
    /// Determina a situação acadêmica do estudante com base na média final:
    /// - mediaFinal >= 7.0m: "APROVADO"
    /// - mediaFinal entre 5.0m e 6.99m: "RECUPERACAO"
    /// - mediaFinal < 5.0m: "REPROVADO"
    /// </summary>
    /// <param name="mediaFinal">Média final obtida pelo aluno</param>
    /// <returns>"APROVADO", "RECUPERACAO" ou "REPROVADO"</returns>
    public string ObterSituacaoAcademica(decimal mediaFinal)
    {
        if (mediaFinal >= 7.0m)
        {
            return "APROVADO";
        }

        if (mediaFinal >= 5.0m)
        {
            return "RECUPERACAO";
        }

        return "REPROVADO";
    }
}
