# EduTechPlatform – Testes Automatizados com xUnit

Plataforma acadêmica fictícia (**EduTechPlatform**) desenvolvida em C# / .NET 10, com foco em **regras de negócio testáveis** e uma suíte de **testes unitários com xUnit**.

---

## 📌 Visão Geral

A **EduTechPlatform** simula o núcleo de um sistema educacional online. Ela concentra três regras de negócio fundamentais da vida acadêmica:

1. **Desempenho acadêmico**: cálculo e classificação de notas.
2. **Frequência**: controle de presença e aprovação por assiduidade.
3. **Matrícula e financeiro**: cálculo de mensalidades, descontos e situação financeira da matrícula.

Cada regra está isolada em uma classe de serviço independente, o que facilita a manutenção e permite testes unitários rápidos, sem dependência de banco de dados ou serviços externos.

---
## 👥 Equipe

| Integrante | Função | GitHub |
|------------|--------|--------|
| Nome do Desenvolvedor 1 | Desenvolvedor 1 – Serviços de domínio | [@vivoeasy100](https://github.com/usuario1) |
| Nome do Desenvolvedor 2 | Desenvolvedor 2 – Testes automatizados | [@LuchMiranda](https://github.com/usuario2) |
| Nome do Desenvolvedor 3 | Desenvolvedor 3 – Documentação e DevOps / Versionamento | [@1Gapril](https://github.com/1Gapril) |

## ⚙️ Requisitos do Ambiente

| Requisito | Versão |
|-----------|--------|
| [.NET SDK](https://dotnet.microsoft.com/download) | **10.0** ou superior |
| Git | Qualquer versão recente |
| Editor (opcional) | Visual Studio 2022+, VS Code ou JetBrains Rider |

Para verificar a instalação do SDK:

```bash
dotnet --version
```

A saída deve começar com `10.`.

---

## 🧩 Classes de Serviço

### `NotaDesempenhoService`
Responsável pelas regras de **avaliação do desempenho acadêmico**. Calcula a média das notas do aluno, valida se os valores informados estão dentro do intervalo permitido e classifica o resultado (por exemplo: aprovado, recuperação ou reprovado) de acordo com as faixas de nota definidas.

### `FrequenciaService`
Responsável pelo **controle de assiduidade**. Calcula o percentual de presença a partir do total de aulas e do número de faltas, e determina se o aluno atinge a frequência mínima exigida para aprovação. Também trata entradas inválidas (como faltas maiores que o total de aulas).

### `MatriculaFinanceiraService`
Responsável pelas **regras financeiras da matrícula**. Calcula o valor final da mensalidade aplicando descontos (por exemplo, pagamento antecipado ou condições especiais), define multas/juros em caso de atraso e valida a situação financeira do aluno para que a matrícula seja efetivada.

> 📝 *As regras exatas (faixas de nota, frequência mínima, percentuais de desconto etc.) estão implementadas no código-fonte de cada serviço e são validadas pelos testes.*

---

## 🚀 Guia de Execução (CLI)

Clone o repositório e acesse a pasta do projeto:

```bash
git clone https://github.com/1Gapril/edutech-platform-xunit.git
cd edutech-platform-xunit
```

### 1. Restaurar dependências

```bash
dotnet restore
```

### 2. Compilar a solução

```bash
dotnet build
```

Para compilar sem repetir a restauração:

```bash
dotnet build --no-restore
```

### 3. Executar os testes

```bash
dotnet test
```

Com saída detalhada (lista cada teste executado):

```bash
dotnet test --logger "console;verbosity=detailed"
```

Para executar apenas os testes de uma classe específica:

```bash
dotnet test --filter "FullyQualifiedName~NotaDesempenhoServiceTests"
```

### Resumo rápido

```bash
dotnet restore && dotnet build --no-restore && dotnet test --no-build
```

---

## 🧪 Cobertura dos Testes Parametrizados

Os testes utilizam o **xUnit** e priorizam testes parametrizados para validar várias situações com o mínimo de código repetido.

- **`[Fact]`**: teste de um único cenário fixo.
- **`[Theory]`**: teste executado várias vezes com conjuntos de dados diferentes.
- **`[InlineData]`**: fornece cada conjunto de valores (entrada e resultado esperado) para um `[Theory]`.

Exemplo do padrão adotado:

```csharp
[Theory]
[InlineData(10.0, 10.0, "Aprovado")]
[InlineData(6.0, 6.0, "Aprovado")]
[InlineData(5.0, 5.0, "Recuperação")]
[InlineData(2.0, 3.0, "Reprovado")]
public void Classificar_DeveRetornarSituacaoCorreta(double n1, double n2, string esperado)
{
    // Arrange
    var service = new NotaDesempenhoService();

    // Act
    var resultado = service.Classificar(n1, n2);

    // Assert
    Assert.Equal(esperado, resultado);
}
```

### O que os testes cobrem

| Serviço | Cenários validados com `[Theory]` + `[InlineData]` |
|---------|------------------------------------------------------|
| `NotaDesempenhoService` | Cálculo de média, classificação por faixa de nota, **valores-limite** (fronteiras entre aprovado/recuperação/reprovado) e notas inválidas |
| `FrequenciaService` | Percentual de presença, limite mínimo de frequência, zero faltas, faltas acima do total de aulas |
| `MatriculaFinanceiraService` | Mensalidade com e sem desconto, cálculo de multa/juros por atraso, situação financeira regular × inadimplente |

Os testes combinam **valores típicos**, **valores-limite** e **entradas inválidas**, garantindo que as regras do sistema se comportem corretamente em todos os cenários relevantes.

---

## 📁 Estrutura Sugerida do Repositório

```
edutech-platform-xunit/
├── src/
│   └── EduTechPlatform/
│       ├── NotaDesempenhoService.cs
│       ├── FrequenciaService.cs
│       └── MatriculaFinanceiraService.cs
├── tests/
│   └── EduTechPlatform.Tests/
│       ├── NotaDesempenhoServiceTests.cs
│       ├── FrequenciaServiceTests.cs
│       └── MatriculaFinanceiraServiceTests.cs
├── .gitignore
├── LICENSE
└── README.md
```

---

## 📄 Licença

Este projeto está licenciado sob a **Licença MIT**. Consulte o arquivo [LICENSE](LICENSE) para mais detalhes.
