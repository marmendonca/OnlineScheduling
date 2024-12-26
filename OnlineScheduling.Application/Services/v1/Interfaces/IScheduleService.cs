namespace OnlineScheduling.Application.Services.v1.Interfaces
{
    public interface IScheduleService
    {
        Task CompleteScheduleAsync(int id);
        Task ChangeToPendingPaymentAsync(int id);
    }
}