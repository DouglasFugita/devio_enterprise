# Enterprise Core

Projeto baseado no conteudo abordado no curso ASP.NET Core Enterprise Applications, que pode ser encontrado em: https://desenvolvedor.io/curso-online-asp-net-core-enterprise-applications

## SQLServer - Docker
Foi utilizado o docker-compose para subir uma instancia SQL Server
Arquivos salvos em: \\wsl$\docker-desktop-data\version-pack-data\community\docker\volumes

## Assuntos abordados neste projeto
Conceitos
- DDD
- CQRS

Dados
- EntityFrameworkCore
- Dapper

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

Validacao
- FluentValidation



## Questoes levantas
- Utilizacao de um unico BD para todos os servicos
- Modelo em camadas em APIs simples (Catalogo)
- Acoplamento por conta do DomainObjects no Core
- Secret do Identity exposto no appsettings

## Melhorias futuras
- [ ] Implantacao de recursos outros recursos do Identity (2FA, Recuperacao de senha)
- [ ] API pra controle de estoque
- [ ] Controle de identidade com KeyCloak
