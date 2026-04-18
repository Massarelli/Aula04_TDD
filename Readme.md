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



```text
Aula04_TDD/
├── Aula04/              # Projeto Console (Código de Produção)
│   ├── Classes/         # Entidades e Modelos
│   └── Program.cs       # Ponto de entrada da aplicação
├── Aula04.Test/         # Projeto de Testes (xUnit)
│   └── PessoaTests.cs   # Testes unitários da classe Pessoa
└── Aula04_TDD.slnx      # Arquivo de Solução moderno