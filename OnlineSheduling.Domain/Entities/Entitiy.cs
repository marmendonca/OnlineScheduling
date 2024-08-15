using System;

namespace OnlineScheduling.Domain.Entities;

public class Entitiy<TId>
{
    public TId Id { get; protected set; }
    public DateTime CreatedAt { get; protected set; }

    public Entitiy()
    {
        CreatedAt = DateTime.Now;
    }
}