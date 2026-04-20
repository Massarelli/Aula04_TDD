# 🐙 Guia de Sobrevivência: Git & Versionamento

Este documento lista as boas práticas para evitar conflitos de sincronização entre diferentes computadores.

### 🛡️ O Escudo: .gitignore
Para evitar erros de "definição duplicada" (CS0101), o arquivo `.gitignore` deve impedir o versionamento das pastas de compilação:
- `bin/`
- `obj/`
- `.vscode/`

### 🔄 Fluxo de Trabalho (Ritual de Troca de PC)
Sempre que alternar entre o Desktop e o Laptop:
1. **No PC Atual (Saindo):** `git add .` -> `git commit -m "Sincronização"` -> `git push`
2. **No Novo PC (Chegando):** `git pull`
3. **Pós-Pull:** Executar `dotnet build` e `dotnet test` antes de qualquer alteração.

### 🚑 Recuperação de Desastre (OneDrive Conflict)
Se o OneDrive duplicar pastas (ex: `Models-DESKTOP...`):
1. Mova o projeto para um diretório local (ex: `C:\Dev\`).
2. Delete manualmente todas as pastas `bin` e `obj`.
3. Execute `dotnet clean` e `dotnet build`.

Na verdade, o fluxo profissional de quem trabalha com TDD e múltiplos computadores é o "Ritual de Chegada":

git pull (para baixar as novidades).

dotnet restore (opcional, mas bom se alguém adicionou bibliotecas novas).

dotnet build (para garantir que o código compila na sua máquina).

dotnet test (para garantir que nada quebrou no processo).

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