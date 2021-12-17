# Teste de utiliza��o do EFCore

Projeto de teste de utiliza��o com o EF core

## Introdu��o

Essas instru��es fornecer�o uma c�pia do projeto em execu��o na sua m�quina local para fins de desenvolvimento e teste.
Consulte implanta��o para obter notas sobre como implantar o projeto em um sistema ativo.

### Prerequisitos

O que voc� precisa para baixar, rodar e disponibilizar.

* Visual Studio com o dotnet core 6.0 instalado
* SQL Server
* Criar o banco de dados local **TesteEFCore** ou outro de sua prefer�ncia lembrando de alterar a conection string
* Alterar a connection string para o banco - caso haja necessidade

### Instala��o

Ap�s a execu��o do pre requisitos, segue um passo a passo de como rodar localmente.

Clonar o reposit�rio

```bash
git clone git@github.com:robsonpedroso/teste-efcore.git
```

Abra a solu��o com o Visual Studio e compile.
Sete o Projeto default como a API e execute (F5).


Chame a URL abaixo pelo navegador para verificar se esta ok.

```
https://localhost:7198
```

## Diret�rios

1. `src` - Cont�m o c�digo fonte do projeto
1.1. `api` - Projeto da API
1.2. `core` - Estrutura padr�o do DDD contendo os projetos `Application`, `Domain` e `Infra`

### Padr�o de Tecnologia utilizado

Utilizamos o padr�o do DDD mais simplificado para trabalhar com os projetos.

- O retorno da API foi modificado para melhor retornar os valores removendo os nulos e brancos, ajustando a cultura entre outras altera��es que podem ser encontradas no ***Program.cs***
- O padr�o de convers�o do json � `SnakeCaseNamingStrategy`.
- Esta ativo o Gzip como compacta��o da API.


## Autores

* **Robson Pedroso** - *Projeto inicial* - [RobsonPedroso](https://github.com/robsonpedroso)

## License

[MIT](https://github.com/robsonpedroso/teste-efcore/blob/main/LICENSE)
