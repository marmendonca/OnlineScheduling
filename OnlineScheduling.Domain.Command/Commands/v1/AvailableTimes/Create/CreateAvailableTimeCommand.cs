using MediatR;

namespace OnlineScheduling.Domain.Command.Commands.v1.AvailableTimes.Create
{
    public sealed class CreateAvailableTimeCommand : IRequest<Unit>
    {
        public int? ProfessionalId { get; set; }
        public TimeSpan StartTime { get; set; }
        public TimeSpan EndTime { get; set; }
        public int Interval { get; set; }
        public bool Active { get; set; } = true;
    }
}