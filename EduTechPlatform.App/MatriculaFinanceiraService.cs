namespace EduTechPlatform.App;

/// <summary>
/// Responsável pelo processamento financeiro de mensalidades e regras de rematrícula.
/// </summary>
public class MatriculaFinanceiraService
{
    /// <summary>
    /// Calcula o valor da mensalidade considerando descontos de bolsa e pontualidade:
    /// - Bolsista (eBolsista == true): Desconto fixo de 50% (valorBase * 0.50m), independentemente do dia.
    /// - Não bolsista e pagamento até dia 5 (diaPagamento &lt;= 5): Desconto de 10% por pontualidade (valorBase * 0.90m).
    /// - Não bolsista e pagamento após dia 5 (diaPagamento &gt; 5): Valor integral (valorBase).
    /// </summary>
    /// <param name="valorBase">Valor padrão da mensalidade</param>
    /// <param name="diaPagamento">Dia do mês em que o pagamento foi efetuado</param>
    /// <param name="eBolsista">Indica se o aluno é bolsista</param>
    /// <returns>Valor final da mensalidade calculado</returns>
    public decimal CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)
    {
        if (eBolsista)
        {
            return valorBase * 0.50m;
        }

        if (diaPagamento <= 5)
        {
            return valorBase * 0.90m;
        }

        return valorBase;
    }

    /// <summary>
    /// Avalia se o aluno tem permissão para realizar rematrícula:
    /// Retorna true apenas se não possuir pendência financeira E não estiver com situação "REPROVADO".
    /// </summary>
    /// <param name="possuiPendenciaFinanceira">Indica se há pendências no financeiro</param>
    /// <param name="situacaoAcademica">Situação acadêmica obtida ("APROVADO", "RECUPERACAO", "REPROVADO")</param>
    /// <returns>True se apto a rematricular, caso contrário False</returns>
    public bool PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)
    {
        return !possuiPendenciaFinanceira && !string.Equals(situacaoAcademica, "REPROVADO", StringComparison.OrdinalIgnoreCase);
    }
}
