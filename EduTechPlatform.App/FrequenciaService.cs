namespace EduTechPlatform.App;

/// <summary>
/// Responsável pelo controle de frequência e validação de presença mínima.
/// </summary>
public class FrequenciaService
{
    /// <summary>
    /// Retorna o percentual de presença:
    /// ((aulasTotais - faltas) / (double)aulasTotais) * 100
    /// </summary>
    /// <param name="aulasTotais">Quantidade total de aulas ministradas</param>
    /// <param name="faltas">Quantidade de faltas do aluno</param>
    /// <returns>Percentual de presença calculado em double</returns>
    public double CalcularPorcentagemPresenca(int aulasTotais, int faltas)
    {
        if (aulasTotais <= 0)
        {
            throw new ArgumentException("O total de aulas deve ser superior a zero.", nameof(aulasTotais));
        }

        return ((aulasTotais - faltas) / (double)aulasTotais) * 100.0;
    }

    /// <summary>
    /// Valida se o aluno possui no mínimo 75% de presença para ser aprovado por frequência.
    /// </summary>
    /// <param name="aulasTotais">Quantidade total de aulas ministradas</param>
    /// <param name="faltas">Quantidade de faltas do aluno</param>
    /// <returns>True se presença >= 75.0%, caso contrário False</returns>
    public bool AprovadoPorFrequencia(int aulasTotais, int faltas)
    {
        double presenca = CalcularPorcentagemPresenca(aulasTotais, faltas);
        return presenca >= 75.0;
    }
}
