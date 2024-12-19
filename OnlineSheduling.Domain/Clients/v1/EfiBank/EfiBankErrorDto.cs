using System.Collections.Generic;

namespace OnlineScheduling.Domain.Clients.v1.EfiBank;

public class EfiBankErrorDto
{
    public string Nome { get; set; }
    public string Mensagem { get; set; }
    public List<EfiBankErrorItemDto> Erros { get; set; }
}