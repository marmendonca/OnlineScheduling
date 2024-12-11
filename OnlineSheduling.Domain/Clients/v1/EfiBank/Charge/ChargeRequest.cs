namespace OnlineScheduling.Domain.Clients.v1.EfiBank.Charge;

public class ChargeRequest
{
    public CalendarRequest Calendario { get; set; }
    public CustomerRequest Devedor { get; set; }
    public ValueRequest Valor { get; set; }
    public string Chave { get; set; }
    public string SolicitacaoPagador { get; set; }
}