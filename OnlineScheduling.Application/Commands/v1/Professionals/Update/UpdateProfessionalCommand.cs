using System.Text.Json.Serialization;
using MediatR;

namespace OnlineScheduling.Application.Commands.v1.Professionals.Update;

public class UpdateProfessionalCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
}