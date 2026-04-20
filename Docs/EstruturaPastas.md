# 📂 Mapa da Arquitetura: Organização por Responsabilidade

O projeto segue um padrão modular para facilitar a manutenção e o crescimento (Escalabilidade).

### 🏗️ 1. Models (Entidades)
Contém os objetos reais do domínio. Responde à pergunta: *"O que o sistema é?"*
- `Funcionario.cs` (Abstrata): Base para tipos de funcionários.
- `Desenvolvedor.cs` / `Gerente.cs`: Especializações (Herança).
- `PrestadorServico.cs`: Entidade externa que também gera despesa.

### 🔌 2. Interfaces (Contratos)
Define comportamentos comuns. Responde à pergunta: *"O que o objeto faz?"*
- `IPagavel.cs`: Garante que qualquer classe que a assine terá o método `CalcularPagamento()`. Permite tratar objetos diferentes (CLT e PJ) na mesma lista financeira.

### 🛠️ 3. Util (Ferramentas)
Contém utilitários genéricos (Helpers) para suporte técnico.
- `InputHelper.cs`: Centraliza validações de `Console` (Nome, Salário, CPF) para evitar repetição de código (DRY - Don't Repeat Yourself).

### 🔬 4. Aula04.Test (Qualidade)
Pasta dedicada ao TDD. Garante que mudanças na estrutura não quebrem a lógica de cálculo.

PROJETO_RAIZ
├── .gitignore          <-- O filtro de lixo
├── Projeto.slnx        <-- A cola que une App e Testes
├── AppContabil/        <-- Seu código principal
│   ├── Program.cs
│   ├── Models/         <-- O que o sistema é (Dados)
│   ├── Services/       <-- O que o sistema faz (Regras/Cálculos)
│   ├── Interfaces/     <-- Os contratos (IPagavel, IValidavel)
│   └── Util/           <-- Suas ferramentas (InputHelper)
└── AppContabil.Test/   <-- Seus testes unitários

