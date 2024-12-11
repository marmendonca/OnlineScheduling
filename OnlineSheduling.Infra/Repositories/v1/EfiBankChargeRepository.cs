using System;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Infra.Repositories.v1;

public sealed class EfiBankChargeRepository(DataContext context)
    : BaseRepository<EfiBankCharge, Guid>(context), IEfiBankChargeRepository;