namespace OnlineScheduling.Domain.Clients.v1.EfiBank.Charge;

public class ChargeResponse
{
    public string Txid { get; set; }
    public string Status { get; set; }
    public LocationResponse Loc { get; set; }
    public string PixCopiaECola { get; set; }
    public string SolicitacaoPagador { get; set; }
}