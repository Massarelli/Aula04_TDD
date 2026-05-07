* Isso abre o **Preview do Markdown** ao lado do editor.
   - Ctrl + Shift + V

# 🐙 Guia de Sobrevivência: Git & Versionamento

Este documento lista as boas práticas para evitar conflitos de sincronização entre diferentes computadores.

## O passo a passo para o Git:
    Certifique-se de estar na raiz: A pasta principal vai englobar todos os APPs do projeto.
        Inicialize o repositório: git init
        Crie o arquivo .gitignore: Este passo é fundamental no .NET.
        Execute: dotnet new gitignore
Isso cria um arquivo que diz ao Git para ignorar as pastas bin e obj (que contêm arquivos temporários de compilação).

### 🛡️ O Escudo: .gitignore
Para evitar erros de "definição duplicada" (CS0101), o arquivo `.gitignore` deve impedir o versionamento das pastas de compilação:
- `bin/`
- `obj/`
- `.vscode/`

### 🔄 Sem gitignore???
*Dica importante*: E se eu já tiver feito o Commit sem o gitignore?
Se você já enviou as pastas bin e obj para o GitHub e agora quer removê-las (mas mantê-las no seu computador), o .gitignore sozinho não vai deletá-las de lá. Você precisa rodar estes comandos:

Limpar o cache do Git: git rm -r --cached .

Adicionar tudo de novo: git add . (agora o Git vai ler o .gitignore e ignorar o que deve ser ignorado).

Fazer o commit: git commit -m "Removendo arquivos desnecessários com o novo gitignore"

Enviar: git push

# Pastas de Compilação (Onde ficam os .exe e .dll que o PC gera)
**/bin/
**/obj/
**/TestResults/

## Arquivos de configuração do Usuário (Configurações do seu VS Code)
    # .vscode/
    # .idea/
    *.user

    # Arquivos de Cache e Temporários do Sistema
    .DS_Store
    Thumbs.db

    # Arquivos de Testes (Resultados e logs de cobertura)
    TestResults/

# 🔄 Fluxo de Trabalho (Ritual de Troca de PC)
Sempre que alternar entre o Desktop e o Laptop:
1. **No PC Atual (Saindo):** `git add .` -> `git commit -m "Sincronização"` -> `git push`
2. **No Novo PC (Chegando):** `git pull`
 a. `Não use os aplicativos de nuvem para backup`
3. **Pós-Pull:** Executar `dotnet restore` (reconstrói bibliotecas) `dotnet build` (reconstroi estrutura) e `dotnet test` (testa aplicação) antes de qualquer alteração.

## 🚑 Recuperação de Desastre (OneDrive Conflict)
Se o OneDrive duplicar pastas (ex: `Models-DESKTOP...`):
1. Mova o projeto para um diretório local (ex: `C:\Dev\`).
2. Delete manualmente todas as pastas `bin` e `obj`.
3. Execute `dotnet clean`, `dotnet restore` e `dotnet build`.

# 🛡️ Estratégia de Proteção e Recuperação
1. Por que o Git vence o OneDrive?
OneDrive: Tenta sincronizar arquivos em tempo real. Se você está compilando em um PC, ele pode travar o arquivo para o outro PC, gerando as pastas duplicadas (Models-DESKTOP...).

Git: Você decide quando sincronizar (push/pull). Ele ignora o "lixo" de compilação.

2. O arquivo .gitignore (Essencial)
Sempre que iniciar um projeto, crie um arquivo chamado .gitignore na raiz. Ele diz ao Git para não subir as pastas bin e obj.

Dica: No terminal, você pode usar o comando dotnet new gitignore para criar um automático.

3. Procedimento de Emergência (Caso o projeto "quebre" ao trocar de PC)
Se você abrir o projeto e houver erros de "definição duplicada" ou namespaces não encontrados:

Isolamento: Mova a pasta para fora de diretórios sincronizados por nuvem (ex: use C:\Dev\).

Exclusão de Fantasmas: Delete manualmente as pastas bin e obj de todos os projetos (Aula04 e Aula04.Test).

Reset de Cache: No terminal da pasta raiz, execute:
    dotnet clean
    dotnet restore
    dotnet build

# Guia para Limpar a Casa
Siga estes passos para estabilizar seu ambiente:

Mova o Projeto: Copie a pasta raiz AULA04_TDD para um local local, como C:\Projetos\ESTUDANDO\....

Delete as Duplicatas: Apague essa pasta estranha Models-DESKTOP-HO7UDGJ. Fique apenas com a pasta Models original e limpa.

Limpeza Profunda: Dentro das pastas Aula04 e Aula04.Test, delete manualmente as pastas bin e obj. Elas contêm arquivos temporários de compilação que podem estar guardando referências aos caminhos antigos do OneDrive.

Restaure e Build: No terminal, dentro da pasta do projeto, rode:

dotnet clean (limpa qualquer resquício).

dotnet build (reconstrói as conexões do zero).

