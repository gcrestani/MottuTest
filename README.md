# Mottu

> #### Criar um encurtador de URL
> 
> ●	O desafio proposto consiste no desenvolvimento de um encurtador de URL que deve ser implementado como back-end juntamente com um validador capaz de indicar se o link gerado está funcionando. Esse desenvolvimento é baseado em API`s REST.
> 
> ●	É esperado, através da implementação, que seja possível além de encurtar a URL e ao acessá-la, o número de acessos incremente-se para contagem de acessos.
> 
> ●	Para cada criação de uma URL será necessário disparar um evento que futuramente poderá ser integrado em algum sistema de mensageria, inicialmente você pode disparar esse evento para um cache local ou para alguma fila, se a URL já existir não há necessidade de disparo no evento.
> 
> ●	Todas as informações devem ser salvas em um banco de dados PostGres e desenvolvido em C#


Projeto desenvolvido em .Net Core.
O banco de dados foi criado usando o modelo Code-First, ou seja, foram criados os Models e, a partir deles, as Migrations.
Foi criado um serviço de Seed para popular o banco de dados para teste.

Para rodar esse projeto, você precisa ter instalado o [.Net Core 6.1](https://dotnet.microsoft.com/pt-br/download/dotnet/6.0) e o [Docker Desktop](https://www.docker.com/products/docker-desktop/) em seu sistema operacional.
É recomendavel que, para alterações, você instale um dos seguintes editores:  [Visual Studio](https://visualstudio.microsoft.com/pt-br/vs/)  | [Visual Studio Code](https://code.visualstudio.com/download)

### Rodando a aplicação - API

Inicialmente, inicie um container Docker utilizando o seguinte comando:
    
    
    docker run -p 5432:5432 -v /tmp/database:/var/lib/postgresql/data -e POSTGRES_PASSWORD=U1h0blw47K -d postgres


Antes rodar a API, utilize o comando abaixo no Visual Studio para executar as migrations, com o projeto MottuTest.Api.DataStore.Postgres selecionado:

    Update-database
Após isso inicie o projeto normalmente (F5)

## Construido com:

-   [.Net Core Framework](https://dotnet.microsoft.com/download/dotnet-core)  - Free, cross-platform, open-source framework;
- [PostgreSql](https://www.postgresql.org/) - The world's most popular open source database.

## [](https://github.com/gcrestani/Resolutte#autor)Autor

-   **Guilherme Crestani**  -  [gcrestani](https://github.com/gcrestani/)
