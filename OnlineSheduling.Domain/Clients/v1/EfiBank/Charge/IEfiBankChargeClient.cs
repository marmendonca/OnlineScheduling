using System.Threading.Tasks;
using Refit;

namespace OnlineScheduling.Domain.Clients.v1.EfiBank.Charge;

public interface IEfiBankChargeClient
{
    [Post("/v2/cob")]
    Task<ChargeResponse> CreateChargeAsync([Authorize("Bearer")] string token, [Body] ChargeRequest customer);
        
    [Get("/v2/cob/{txid}")]
    Task<ChargeResponse> GetChargeAsync([Authorize("Bearer")] string token, string txid);
        
    [Get("/v2/loc/{locationId}/qrcode")]
    Task<QrCodeResponse> GetQrCodeAsync([Authorize("Bearer")] string token, string locationId);
}