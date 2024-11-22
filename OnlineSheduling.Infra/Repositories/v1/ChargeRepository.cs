using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public class ChargeRepository(DataContext context)
    : BaseRepository<Charge, int>(context), IChargeRepository;