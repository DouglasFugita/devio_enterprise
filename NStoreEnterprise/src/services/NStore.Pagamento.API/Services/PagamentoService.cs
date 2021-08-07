using FluentValidation.Results;
using NStore.Core.Messages.Integration;
using NStore.Pagamentos.API.Facade;
using NStore.Pagamentos.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NStore.Pagamentos.API.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoFacade _pagamentoFacade;
        private readonly IPagamentoRepository _pagamentoRepository;

        public PagamentoService(IPagamentoFacade pagamentoFacade, IPagamentoRepository pagamentoRepository)
        {
            _pagamentoFacade = pagamentoFacade;
            _pagamentoRepository = pagamentoRepository;
        }

        public async Task<ResponseMessage> AutorizarPagamento(Pagamento pagamento)
        {
            var transacao = await _pagamentoFacade.AutorizarPagamento(pagamento);
            var validationResult = new ValidationResult();

            if (transacao.Status != StatusTransacao.Autorizado)
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento", "" +
                    "Pagamento recusado, entre em contato com a sua operadora de cartao"));

                return new ResponseMessage(validationResult);
            }

            pagamento.AdicionarTransacao(transacao);
            _pagamentoRepository.AdicionarPagamento(pagamento);

            if (!await _pagamentoRepository.UnitOfWork.Commit())
            {
                validationResult.Errors.Add(new ValidationFailure("Pagamento", "Houve um erro ao realizar o pagamento"));

                // TODO: Comunicar com o gateway para realizar o estorno
                //_pagamentoFacade.EstornarPagamento(transacao.NSU);

                return new ResponseMessage(validationResult);
            }

            return new ResponseMessage(validationResult);
        }
    }
}
