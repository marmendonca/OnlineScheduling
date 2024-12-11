using System;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Auth;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Charge;
using OnlineScheduling.Domain.Contracts.Services.v1;
using OnlineScheduling.Domain.Dtos;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;
using OnlineScheduling.Domain.Exceptions;
using OnlineScheduling.Domain.Settings;

namespace OnlineScheduling.Infra.Services.v1;

public class EfiBankService(
    IOptions<EfiBankSettings> options,
    IEfiBankAuthClient authClient,
    IEfiBankChargeClient chargeClient) : IEfiBankService
{
    private readonly EfiBankSettings _settings = options.Value;
        
    public async Task<ChargeDto> CreateImmediateChargeAsync(Customer customer, decimal value)
    {
        var solicitationPayment = Guid.NewGuid().ToString();

        var token = await GetTokenAsync();

        var chargeRequest = new ChargeRequest()
        {
            Calendario = new CalendarRequest
            {
                Expiracao = 3600
            },
            Devedor = new CustomerRequest()
            {
                Cpf = customer.Cpf,
                Nome = customer.Name
            },
            Valor = new ValueRequest()
            {
                Original = value
            },
            Chave = _settings.RandomKey,
            SolicitacaoPagador = solicitationPayment
        };

        var response = await chargeClient.CreateChargeAsync(token, chargeRequest);
        if (response is null || GetEfiBankChargeStatus(response.Status) != EfiBankChargeStatus.Active)
            throw new InfraException("Não foi possível criar a cobrança para agendamento.");
        
        var qrCodeResponse = await chargeClient.GetQrCodeAsync(token, response.Loc.Id.ToString());

        return new ChargeDto()
        {
            SolicitationPaymentId = solicitationPayment,
            ImageQrCode = qrCodeResponse.ImagemQrCode,
            TxId = response.Txid,
            LinkQrCode = qrCodeResponse.LinkVisualizacao,
            LocationId = response.Loc.Id,
            PixCopyAndPaste = response.PixCopiaECola,
            Status = GetEfiBankChargeStatus(response.Status)
        };
    }

    private async Task<string> GetTokenAsync()
    {
        var response = await authClient.LoginAsync(new LoginRequest());
            
        if (response is null || string.IsNullOrWhiteSpace(response.access_token))
            throw new InfraException("Não foi possível obter o token de autenticação para o EfiPay.");
            
        return response.access_token;
    }
    
    private static EfiBankChargeStatus GetEfiBankChargeStatus(string originalStatus)
    {
        return originalStatus switch
        {
            "PENDING" => EfiBankChargeStatus.Active,
            "CONCLUIDA" => EfiBankChargeStatus.Concluded,
            "REMOVIDA_PELO_USUARIO_RECEBEDOR" => EfiBankChargeStatus.RemovedByUser,
            "REMOVIDA_PELO_PSP" => EfiBankChargeStatus.RemovedByPsp,
            _ => EfiBankChargeStatus.RemovedByUser
        };
    }
}