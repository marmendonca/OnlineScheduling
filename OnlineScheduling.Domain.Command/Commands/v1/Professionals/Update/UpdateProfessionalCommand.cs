using System.Text.Json.Serialization;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace OnlineScheduling.Domain.Command.Commands.v1.Professionals.Update;

public class UpdateProfessionalCommand : IRequest<Unit>
{
    [JsonIgnore]
    public int Id { get; set; }
    public string Name { get; set; }
}