using OnlineScheduling.Application.Services.v1.Interfaces;
using OnlineScheduling.Domain.Contracts.Repositories.v1;
using OnlineScheduling.Domain.Exceptions;

namespace OnlineScheduling.Application.Services.v1
{
    public class ScheduleService(IScheduleRepository scheduleRepository) : IScheduleService
    {
        public async Task CompleteScheduleAsync(int id)
        {
            var schedule = await scheduleRepository.GetByIdAsync(id) 
                           ?? throw new DomainException("Agendamento não encontrado");
            
            schedule.Complete();
            
            await scheduleRepository.UpdateAsync(schedule);
        }
        
        public async Task ChangeToPendingPaymentAsync(int id)
        {
            var schedule = await scheduleRepository.GetByIdAsync(id) 
                           ?? throw new DomainException("Agendamento não encontrado");
            
            schedule.ChangeToPendingPayment();
            
            await scheduleRepository.UpdateAsync(schedule);
        }
    }
}