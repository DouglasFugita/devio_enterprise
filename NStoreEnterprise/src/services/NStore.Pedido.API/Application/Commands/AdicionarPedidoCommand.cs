using FluentValidation;
using NStore.Core.Messages;
using NStore.Pedidos.API.Application.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Pedidos.API.Application.Commands
{
    public class AdicionarPedidoCommand : Command
    {
        public Guid ClienteId { get; set; }
        public decimal ValorTotal { get; set; }
        public List<PedidoItemDTO> PedidoItems { get; set; }
        
        public string VoucherCodigo { get; set; }
        public bool VoucherUtilizado { get; set; }
        public decimal Desconto { get; set; }

        public EnderecoDTO Endereco { get; set; }

        public string NumeroCartao { get; set; }
        public string NomeCartao { get; set; }
        public string ExpiracaoCartao { get; set; }
        public string CvvCartao { get; set; }

        public override bool EhValido()
        {
            ValidationResult = new AdicionarPedidoValidation().Validate(this);
            return ValidationResult.IsValid;
        }

        public class AdicionarPedidoValidation: AbstractValidator<AdicionarPedidoCommand>
        {
            public AdicionarPedidoValidation()
            {
                RuleFor(p => p.ClienteId)
                    .NotEqual(Guid.Empty).WithMessage("Id do cliente invalido");

                RuleFor(p => p.PedidoItems.Count())
                    .GreaterThan(0).WithMessage("O pedido precisa ter no minimo 1 item");

                RuleFor(p => p.ValorTotal)
                    .GreaterThan(0).WithMessage("Valor do pedido invalido");

                RuleFor(p => p.NumeroCartao)
                    .CreditCard().WithMessage("Numero do cartao invalido");

                RuleFor(p => p.NomeCartao)
                    .NotNull().WithMessage("Nome do portador do cartao requerido");

                RuleFor(p => p.CvvCartao.Length)
                    .GreaterThan(2)
                    .LessThan(5)
                    .WithMessage("O CVV do cartao precisa ter 3 ou 4 numeros");

                RuleFor(p => p.ExpiracaoCartao)
                    .NotNull()
                    .WithMessage("Data expiracao do cartao requerida");
            }
        }
    }
}
