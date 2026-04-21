# 🚀 Estudo de .NET: Domínio de Fundamentos e TDD

Este repositório faz parte da minha jornada de aprendizado em .NET, focando na base sólida de Programação Orientada a Objetos (POO) e no fluxo de desenvolvimento orientado a testes (TDD).

## 📌 Sobre o Projeto

O objetivo deste módulo é consolidar conceitos essenciais como Namespaces, Classes, Métodos, Atributos e a correta estruturação de soluções com múltiplos projetos.

### 🧠 Conceitos Aplicados:
* **Paradigmas:** Transição do Procedural para o Orientado a Objetos.
* **Encapsulamento:** Uso de modificadores de acesso (`private`, `public`) e métodos de acesso.
* **Gestão de Memória:** Compreensão de instâncias e ciclo de vida de objetos no Heap.
* **Organização Profissional:** Estrutura de Solução (`.slnx`) com separação de responsabilidades.

---

## 🏗️ Estrutura da Solução

O projeto está organizado seguindo as convenções de mercado, separando o código de produção dos testes automatizados:

Aula04_TDD/
├── Aula04/              # Projeto Console (Código de Produção)
│   ├── Classes/         # Entidades e Modelos
│   └── Program.cs       # Ponto de entrada da aplicação
├── Aula04.Test/         # Projeto de Testes (xUnit)
│   └── PessoaTests.cs   # Testes unitários da classe Pessoa
└── Aula04_TDD.slnx      # Arquivo de Solução moderno

🧪 Fluxo TDD (Test Driven Development)
    Neste projeto, aplico o ciclo Red-Green-Refactor:
        Red: Escrever um teste que falha para uma funcionalidade inexistente.
        Green: Implementar o código mínimo para o teste passar.
        Refactor: Melhorar o código mantendo a segurança dos testes.

🛠️ Como Executar
Pré-requisitos
.NET SDK (Versão 8 ou superior recomendada)

Git
Comandos Principais
Para rodar a aplicação principal:

Bash
dotnet run --project Aula04/Aula04.csproj
Para executar os testes unitários:

Bash
dotnet test
📝 Notas de Estudo
    Namespace: Organização lógica para evitar colisão de nomes.
    Instância: Criação de um objeto real em memória a partir de um molde (Classe).
    Git Bash: Utilizado para padronização de comandos e melhor integração com o ambiente de desenvolvimento Linux/Unix dentro do Windows.

---
⭐ Desenvolvido durante os estudos de .NET e POO.

### Dicas para o visual ficar "bacana":

1.  **Emojis:** Usei alguns para dar leitura visual, mas sem exagero para manter o tom profissional.
2.  **Blocos de Código:** Isso facilita muito para quem for baixar seu projeto e quiser testar rápido.
3.  **Estrutura de Pastas:** Colocar o desenho da árvore de pastas ajuda a entender a arquitetura logo de cara.



Para visualizar como está ficando no VS Code enquanto você edita, aperte `Ctrl + Shift + V`. 

O que achou dessa estrutura? Se quiser adicionar uma seção específica sobre o `Dictionary` que fizemos n