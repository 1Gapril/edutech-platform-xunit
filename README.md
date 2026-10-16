# 🎓 EduTechPlatform

> **Garantia e Gestão da Qualidade de Software**  
> **Professor:** Daniel Henrique Matos de Paiva  
> **Instituição:** Ânima Educação  

[![.NET 10](https://img.shields.io/badge/.NET-10.0-512BD4?logo=dotnet&logoColor=white)](https://dotnet.microsoft.com/)
[![xUnit](https://img.shields.io/badge/Testing-xUnit%202.9-512BD4)](https://xunit.net/)
[![License: MIT](https://img.shields.io/badge/License-MIT-yellow.svg)](LICENSE)
[![Tests Passing](https://img.shields.io/badge/Tests-15%20Passed-brightgreen)](EduTechPlatform.Tests)

---

## 📌 1. Visão Geral da Plataforma

A **EduTechPlatform** é uma solução modular desenvolvida em **.NET 10 (C#)** voltada à gestão de regras acadêmicas e financeiras em ambientes de ensino superior e técnico. A plataforma centraliza e automatiza três domínios críticos:

1. **Desempenho Acadêmico:** Avaliação de notas por média ponderada e classificação de status acadêmico.
2. **Frequência Escolar:** Monitoramento de faltas, cálculo de assiduidade e validação de presença mínima regulamentar.
3. **Gestão Financeira & Matrícula:** Concessão automatizada de descontos em mensalidades (bolsa e pontualidade) e liberação de rematrícula com base na regularidade financeira e acadêmica.

---

## 👥 2. Divisão da Atividade em Equipe (3 Integrantes)

A lista de exercícios foi dividida igualmente entre os 3 integrantes do grupo, garantindo que cada participante assumisse a responsabilidade de um perfil técnico do projeto:

| Integrante | Papel no Projeto | Foco Principal | Tarefas Executadas |
| :--- | :--- | :--- | :--- |
| **Fernando** | **Desenvolvedor 1** | Regras de Serviço (Dev Backend / Core) | • Criação e organização da estrutura base da solução .NET 10.<br>• Implementação de `NotaDesempenhoService.cs`.<br>• Implementação de `FrequenciaService.cs`.<br>• Implementação de `MatriculaFinanceiraService.cs`. |
| **Lucas** | **Desenvolvedor 2** | Qualidade e Testes (QA / Testes Unitários) | • Criação e configuração do projeto `EduTechPlatform.Tests`.<br>• Implementação da suíte `NotaDesempenhoServiceTests.cs`.<br>• Implementação da suíte `FrequenciaServiceTests.cs`.<br>• Implementação da suíte `MatriculaFinanceiraServiceTests.cs`.<br>• Validação de 100% dos cenários de teste via `dotnet test`. |
| **Luiz** | **Desenvolvedor 3** | DevOps, Versionamento & Documentação | • Configuração do repositório Git público no GitHub.<br>• Elaboração do arquivo `.gitignore` específico para .NET 10.<br>• Configuração da Licença MIT.<br>• Elaboração da documentação técnica e instruções CLI no `README.md`. |

---

## 🏛️ 3. Estrutura da Solução

```text
edutech/
│
├── EduTechPlatform.slnx                     # Arquivo de Solução (.NET 10)
├── 26.gqs_lista_net.pdf                     # Especificação oficial da atividade
├── LICENSE                                  # Licença MIT do projeto
├── .gitignore                               # Regras de exclusão Git para .NET 10
├── README.md                                # Documentação técnica principal
│
├── EduTechPlatform.App/                     # Projeto Console / Regras de Negócio Core
│   ├── EduTechPlatform.App.csproj
│   ├── Program.cs                           # Ponto de entrada e demonstração dos serviços
│   ├── NotaDesempenhoService.cs             # Regras de notas e médias
│   ├── FrequenciaService.cs                 # Regras de frequência e assiduidade
│   └── MatriculaFinanceiraService.cs        # Regras de descontos e rematrícula
│
└── EduTechPlatform.Tests/                   # Projeto de Testes Unitários xUnit
    ├── EduTechPlatform.Tests.csproj         # Referencia EduTechPlatform.App
    ├── NotaDesempenhoServiceTests.cs        # Suíte de testes para NotaDesempenhoService
    ├── FrequenciaServiceTests.cs            # Suíte de testes para FrequenciaService
    └── MatriculaFinanceiraServiceTests.cs   # Suíte de testes para MatriculaFinanceiraService
```

---

## ⚙️ 4. Descrição das Classes de Serviço (Desenvolvedor 1 - Fernando)

### 4.1. `NotaDesempenhoService.cs`
Localizada em `EduTechPlatform.App`, encapsula o cálculo do rendimento acadêmico:
- **`CalcularMediaPonderada(decimal nota1, decimal nota2, decimal notaProjeto)`**:
  - **Pesos:** Nota 1 (peso 3), Nota 2 (peso 3), Nota Projeto (peso 4).
  - **Fórmula:** `((nota1 * 3) + (nota2 * 3) + (notaProjeto * 4)) / 10`.
- **`ObterSituacaoAcademica(decimal mediaFinal)`**:
  - `mediaFinal >= 7.0m`: Retorna `"APROVADO"`.
  - `mediaFinal >= 5.0m && < 7.0m` (5.0m a 6.99m): Retorna `"RECUPERACAO"`.
  - `mediaFinal < 5.0m`: Retorna `"REPROVADO"`.

### 4.2. `FrequenciaService.cs`
Localizada em `EduTechPlatform.App`, monitora a frequência do estudante:
- **`CalcularPorcentagemPresenca(int aulasTotais, int faltas)`**:
  - **Fórmula:** `((aulasTotais - faltas) / (double)aulasTotais) * 100`.
- **`AprovadoPorFrequencia(int aulasTotais, int faltas)`**:
  - Valida se a assiduidade é maior ou igual a **75%** (`true`). Caso contrário, retorna `false`.

### 4.3. `MatriculaFinanceiraService.cs`
Localizada em `EduTechPlatform.App`, administra as políticas financeiras e elegibilidade de matrícula:
- **`CalcularValorMensalidade(decimal valorBase, int diaPagamento, bool eBolsista)`**:
  - `eBolsista == true`: Desconto fixo de **50%** (`valorBase * 0.50m`), independentemente do dia de pagamento.
  - `eBolsista == false && diaPagamento <= 5`: Desconto de pontualidade de **10%** (`valorBase * 0.90m`).
  - `eBolsista == false && diaPagamento > 5`: Sem desconto, valor integral (`valorBase`).
- **`PodeRealizarRematricula(bool possuiPendenciaFinanceira, string situacaoAcademica)`**:
  - Permite a rematrícula (`true`) **apenas se** `possuiPendenciaFinanceira == false` **E** `situacaoAcademica != "REPROVADO"`.

---

## 🧪 5. Qualidade e Testes Unitários Parametrizados (Desenvolvedor 2 - Lucas)

A qualidade da aplicação foi assegurada por meio do framework **xUnit**, utilizando o poder dos testes parametrizados com **`[Theory]`** e **`[InlineData]`**.

### 5.1. Por que utilizar `[Theory]` e `[InlineData]`?
Ao contrário de um teste simples decorado com `[Fact]` (que testa um único cenário rígido), os testes com `[Theory]` representam suítes orientadas a dados (*data-driven tests*):
1. **Redução de Código Duplicado:** O mesmo algoritmo de teste é executado múltiplas vezes com diferentes entradas e saídas esperadas.
2. **Cobertura Abrangente de Casos de Borda:** Permite testar facilmente limites de equivalência (ex.: dia 4 vs dia 10, notas limítrofes, 75% exatos vs 74%).
3. **Relatórios Claros no Test Runner:** Cada linha de `[InlineData]` é tratada como um teste individual na saída do runner, indicando com precisão o cenário testado.

### 5.2. Mapeamento de Cenários de Teste

#### `NotaDesempenhoServiceTests.cs`
- **Média Ponderada:**
  - `[InlineData(7.0, 7.0, 7.0, 7.0)]`
  - `[InlineData(10.0, 10.0, 5.0, 8.0)]`
- **Situação Acadêmica:**
  - `[InlineData(8.5, "APROVADO")]`
  - `[InlineData(6.0, "RECUPERACAO")]`
  - `[InlineData(4.2, "REPROVADO")]`

#### `FrequenciaServiceTests.cs`
- **Cálculo de Percentual:**
  - `[InlineData(80, 20, 75.0)]` (60 presenças em 80 aulas = 75%)
  - `[InlineData(100, 10, 90.0)]` (90 presenças em 100 aulas = 90%)
- **Aprovação por Frequência:**
  - `[InlineData(80, 20, true)]` (75% presença -> Aprovado)
  - `[InlineData(80, 21, false)]` (Abaixo de 75% -> Reprovado)

#### `MatriculaFinanceiraServiceTests.cs`
- **Cálculo de Mensalidade:**
  - `[InlineData(1000.00, 10, true, 500.00)]` (Bolsista -> 50% de desconto)
  - `[InlineData(1000.00, 4, false, 900.00)]` (Não bolsista até dia 5 -> 10% de desconto)
  - `[InlineData(1000.00, 10, false, 1000.00)]` (Não bolsista após dia 5 -> Sem desconto)
- **Elegibilidade para Rematrícula:**
  - `[InlineData(false, "APROVADO", true)]` (Sem pendência + Aprovado -> Permite)
  - `[InlineData(true, "APROVADO", false)]` (Com pendência + Aprovado -> Bloqueia)
  - `[InlineData(false, "REPROVADO", false)]` (Sem pendência + Reprovado -> Bloqueia)

---

## 🚀 6. Guia de Execução dos Comandos CLI (Desenvolvedor 3 - Luiz)

### Requisitos do Ambiente
- **.NET 10 SDK** (v10.0.100 ou superior) instalado. Verifique com:
  ```bash
  dotnet --version
  ```

### Passo a Passo de Execução

#### 1. Restaurar Dependências
Baixa os pacotes necessários especificados nos arquivos de projeto:
```bash
dotnet restore
```

#### 2. Compilar a Solução
Compila todos os projetos da solução sem executar:
```bash
dotnet build
```

#### 3. Executar os Testes Unitários
Executa todos os testes das três suítes e exibe o relatório:
```bash
dotnet test
```

Para uma saída detalhada exibindo individualmente cada caso de `[InlineData]`:
```bash
dotnet test --logger "console;verbosity=detailed"
```

#### 4. Executar a Aplicação Console
Executa a demonstração em terminal da plataforma:
```bash
dotnet run --project EduTechPlatform.App
```

---

## 👨‍💻 7. Contribuidores (Contributors 3)

| Contribuidor | Função | Responsabilidade |
| :---: | :---: | :--- |
| **Fernando** | Dev 1 | **Regras de Negócio e Serviços Core** (`EduTechPlatform.App`) |
| **Lucas** | Dev 2 | **Qualidade de Software e Testes Unitários** (`EduTechPlatform.Tests`) |
| **Luiz** | Dev 3 | **DevOps, Versionamento Git e Documentação Técnica** (`README / .gitignore`) |

---

## 📄 8. Licença

Este projeto está sob a licença [MIT](LICENSE). Consulte o arquivo de licença para obter mais detalhes.
