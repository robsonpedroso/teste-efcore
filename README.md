# Teste de utilização do EFCore

Projeto de teste de utilização com o EF core

## Introdução

Essas instruções fornecerão uma cópia do projeto em execução na sua máquina local para fins de desenvolvimento e teste.
Consulte implantação para obter notas sobre como implantar o projeto em um sistema ativo.

### Prerequisitos

O que você precisa para baixar, rodar e disponibilizar.

* Visual Studio com o dotnet core 6.0 instalado
* SQL Server
* Criar o banco de dados local **TesteEFCore** ou outro de sua preferência lembrando de alterar a conection string
* Alterar a connection string para o banco - caso haja necessidade

### Instalação

Após a execução do pre requisitos, segue um passo a passo de como rodar localmente.

Clonar o repositório

```bash
git clone git@github.com:robsonpedroso/teste-efcore.git
```

Abra a solução com o Visual Studio e compile.
Sete o Projeto default como a API e execute (F5).


Chame a URL abaixo pelo navegador para verificar se esta ok.

```
https://localhost:7198
```

## Diretórios

1. `src` - Contém o código fonte do projeto
1.1. `api` - Projeto da API
1.2. `core` - Estrutura padrão do DDD contendo os projetos `Application`, `Domain` e `Infra`

### Padrão de Tecnologia utilizado

Utilizamos o padrão do DDD mais simplificado para trabalhar com os projetos.

- O retorno da API foi modificado para melhor retornar os valores removendo os nulos e brancos, ajustando a cultura entre outras alterações que podem ser encontradas no ***Program.cs***
- O padrão de conversão do json é `SnakeCaseNamingStrategy`.
- Esta ativo o Gzip como compactação da API.


## Autores

* **Robson Pedroso** - *Projeto inicial* - [RobsonPedroso](https://github.com/robsonpedroso)

## License

[MIT](https://github.com/robsonpedroso/teste-efcore/blob/main/LICENSE)
