# ConsoleSelenium41

Repositório estruturado em C# (.NET 10) para a atividade de automação de testes web utilizando Selenium WebDriver e MSTest, desenvolvido para a disciplina de Garantia e Qualidade de Software.

## Estrutura da Solution

A solução está dividida em dois projetos:
1. **ConsoleSelenium**: Projeto principal do tipo Console Application (.NET 10) que centraliza classes auxiliares de automação.
2. **ConsoleSelenium.Tests**: Projeto de testes unitários utilizando MSTest, Selenium WebDriver e Selenium Support para validação dos cenários.

## Pré-requisitos

- .NET 10 SDK ou superior
- Google Chrome instalado
- ChromeDriver compatível com a versão do navegador

## Cenários de Teste Implementados

- **Exercício 1**: Cadastro completo preenchendo campos de texto, senha, textarea, validação de campo readonly e submissão do formulário.
- **Exercício 2**: Manipulação de dropdowns utilizando a classe `SelectElement` e preenchimento de campos com `datalist`.
- **Exercício 3**: Validação de estado inicial de checkboxes, alternância de checkboxes e botões de rádio, além de interação com color pickers.

## Executando os Testes

No terminal, na pasta raiz da Solution, execute:

```bash
dotnet test