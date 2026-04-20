# 📓 Notas de Estudo: Arquitetura e POO

### 🧠 Decisões Técnicas
1. **Herança vs Interface**:
   - Usamos **Herança** para `Desenvolvedor` porque ele **é um** `Funcionario`.
   - Usamos **Interface** (`IPagavel`) porque tanto `Funcionario` quanto `PrestadorServico` **devem ser pagos**, embora tenham origens totalmente diferentes.
   
2. **Uso de Static**:
   - O `InputHelper` é uma classe estática porque funciona como uma "ferramenta de balcão": você entra, usa e sai, sem precisar criar (instanciar) um objeto na memória.

### 🚀 Insights para o SeDaConta
- **Desacoplamento**: Ao usar a interface `IPagavel` no `Program.cs`, o "financeiro" não precisa saber detalhes internos de cada classe, apenas chamar o método do contrato.
- **TDD**: Manter os testes verdes durante a refatoração de pastas deu a segurança necessária para mudar a arquitetura sem medo de errar os cálculos.

### ⚠️ Alerta de Namespace
Sempre que mover uma classe de pasta (ex: de `Classes` para `Models`), deve-se atualizar:
1. O `namespace` no topo do arquivo.
2. O `using` nos arquivos que chamam essa classe.