using System.ComponentModel;

namespace OnlineScheduling.Domain.Enums;

public enum EfiBankChargeStatus
{
    [Description("Esse status indica que a cobrança foi gerada com sucesso e que está apta para pagamento.")]
    Active = 1,
    [Description("Esse status indica que a cobrança foi gerada com sucesso e está paga.")]
    Concluded = 2,
    [Description("Esse status indica que a cobrança foi gerada com sucesso e foi removida pelo usuário recebedor.")]
    RemovedByUser = 3,
    [Description("Esse status indica que a cobrança foi gerada com sucesso e foi removida pelo PSP.")]
    RemovedByPsp = 4
}