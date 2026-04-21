* Isso abre o **Preview do Markdown** ao lado do editor.
   - Ctrl + Shift + V

# Fluxo de tratamentos diversos
Idéias de tratamentos diversos
## ✔ Encaminhar ERROS para uma classe de tratamento
    Sim — e isso é o que sistemas profissionais fazem.

    Você pode ter uma classe como:

        ```c#
        public static class LogErros
        {
            public static void Registrar(Exception ex)
            {
                // salvar em arquivo
                // enviar para banco
                // enviar para API de logs
                // enviar para e-mail
                // etc.
            }
        }
        ```

    E no seu catch:

        ```c#
        catch (Exception ex)
        {
            LogErros.Registrar(ex);
            Console.WriteLine("Ocorreu um erro inesperado.");
        }
        ```

## ✔ Encaminhar erros “por baixo dos panos”
    Também é comum.

    Você pode ter:
        um middleware (em APIs)
        um handler global
        um EventLog
        um serviço de telemetria (Application Insights, Serilog, NLog, Seq, etc.)

    Exemplo simples com um método interno:

        ```c#
        catch (Exception ex)
        {
            TratarErroInterno(ex);
            Console.WriteLine("Erro inesperado.");
        }

        void TratarErroInterno(Exception ex)
        {
            // rotina oculta
            // grava log, envia alerta, etc.
        }
        ```

    O usuário nem sabe que isso está acontecendo.

## ✔ Encaminhar erros com códigos personalizados
    Você pode criar sua própria classe de erro:

    ```c#
    public class ErroSistema
    {
        public string Codigo { get; set; }
        public string Mensagem { get; set; }
        public DateTime Data { get; set; }
    }
    ```
    
    E no catch:

    ```c#
    catch (Exception ex)
    {
        var erro = new ErroSistema
        {
            Codigo = "ERR001",
            Mensagem = ex.Message,
            Data = DateTime.Now
        };

        LogErros.Registrar(erro);
    }
    ```
Isso é muito usado em **sistemas corporativos**.

# Testes

## Resumo de Nomenclatura para fixar:
* [Theory]: Atributo para testes parametrizados.
* [InlineData]: Fornece os valores para os parâmetros da Teoria.
* Campo Privado: Armazena o estado interno da classe (segurança).
* Propriedade: A "interface" pública para ler ou escrever nos campos.

    ```c#
    [Theory]
    [InlineData(1000.00, 1000.00)] // Menor que 1500: Sem desconto
    public override...
    private override...
    ```

## xUnit tem outro atributo muito famoso chamado [Theory].

- [Fact]: É usado para um teste que testa uma única condição específica.
- [Theory]: É usado quando você quer testar o mesmo método com vários dados diferentes (ex: testar se a soma funciona para os números 2, 5, 10 e -1 de uma vez só).

