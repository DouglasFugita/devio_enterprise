# Enterprise Core

Projeto baseado no conteudo abordado no curso ASP.NET Core Enterprise Applications, que pode ser encontrado em: https://desenvolvedor.io/curso-online-asp-net-core-enterprise-applications

## SQLServer - Docker
Foi utilizado o docker-compose para subir uma instancia SQL Server
Arquivos salvos em: \\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes

## RabbitMQ - Docker
A utilizacao do docker-compose tambem habilita o RabbitMQ em suas portas standard:
- 5672 (AMQP listener)
- 15672 (Management UI)

## Assuntos abordados neste projeto
Conceitos
- DDD
- CQRS

Dados
- EntityFrameworkCore
- Dapper

Caching
- Redis

API
- Swagger
- Refit
- Polly

Servico de Identidade
- Asp.net Identity
- JWT

CQRS
- Mediatr

Mensageria
- RabbitMQ
- EasyNetQ

Validacao
- FluentValidation



## Questoes levantas
- Utilizacao de um unico BD para todos os servicos
- Modelo em camadas divididos em pastas logicas por serem APIs simples
- Acoplamento por conta do DomainObjects no Core
- Secret do Identity exposto no appsettings
- Utilizacao de IServiceProvider.CreateScope para utilizacao de classe injetada por dependencia Scoped em BackgroundService Singleton (Service Locator)

## Melhorias futuras
- [ ] Implementar outros recursos do Identity (2FA, Recuperacao de senha)
- [ ] API pra controle de estoque
- [ ] Controle de identidade com KeyCloak
- [ ] Utilizar AMQP Client Library ao inves de EasyNetQ
- [ ] Implementar REDIS para API Carrinho
- [ ] Implementar Ocelot como API Gateway
