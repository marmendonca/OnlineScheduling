using System;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OnlineScheduling.Domain.Clients.v1.EfiBank;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Auth;
using OnlineScheduling.Domain.Clients.v1.EfiBank.Charge;
using OnlineScheduling.Domain.Contracts.Services.v1;
using OnlineScheduling.Domain.Dtos;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Enums;
using OnlineScheduling.Domain.Exceptions;
using OnlineScheduling.Domain.Settings;
using Refit;

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
                Original = value.ToString("F2", CultureInfo.InvariantCulture)
            },
            Chave = _settings.RandomKey,
            SolicitacaoPagador = solicitationPayment
        };

        ChargeResponse response;
        
        try
        {
            response = await chargeClient.CreateChargeAsync(token, chargeRequest);
        }
        catch (ApiException ex)
        {
            if (string.IsNullOrEmpty(ex?.Content))
                throw new InfraException("Não foi possível criar a cobrança para o agendamento.");
            
            throw new InfraException(GetErrorMessage(ex.Content));
        }
        
        if (response is null || GetEfiBankChargeStatus(response.Status) != EfiBankChargeStatus.Active)
            throw new InfraException("Não foi possível criar a cobrança para o agendamento.");
        
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
    
    public async Task<bool> CheckPaymentIsDoneAsync(string txId)
    {
        var token = await GetTokenAsync();

        var response = await chargeClient.GetChargeAsync(token, txId);

        return response is not null && GetEfiBankChargeStatus(response.Status) == EfiBankChargeStatus.Concluded;
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
            "ATIVA" => EfiBankChargeStatus.Active,
            "CONCLUIDA" => EfiBankChargeStatus.Concluded,
            "REMOVIDA_PELO_USUARIO_RECEBEDOR" => EfiBankChargeStatus.RemovedByUser,
            "REMOVIDA_PELO_PSP" => EfiBankChargeStatus.RemovedByPsp,
            _ => EfiBankChargeStatus.RemovedByUser
        };
    }
    
    private static string GetErrorMessage(string content)
    {
        var error = JsonConvert.DeserializeObject<EfiBankErrorDto>(content);
        
        var pathErrors = error.Erros?.Select(x => x.Caminho);
        var messageErrors = error.Erros?.Select(x => x.Mensagem);
        
        return $"Erro ao criar cobrança. Mensagem: {error.Mensagem} - Caminho: {(pathErrors?.Any() == true ? string.Join("| ", pathErrors) : "")} - Erros: {(messageErrors?.Any() == true ? string.Join("| ", messageErrors) : "")}";
    }
}