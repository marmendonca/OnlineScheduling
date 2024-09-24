using System.Text.Json.Serialization;
using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.ProfessionalServices.Update;

public class UpdateProfessionalServiceCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public int ProfessionalId { get; set; }
    public int ServiceId { get; set; }
}