using OnlineSheduling.Domain.Commands;
using OnlineSheduling.Domain.Commands.Contracts;
using OnlineScheduling.Domain.Entities;
using OnlineSheduling.Domain.Handlers.Contracts;
using OnlineScheduling.Domain.Repositories;
using OnlineScheduling.Domain.Validator;
using System;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Handlers
{
    public class ScheduleHandler : IHandler<CreateScheduleCommand>
    {
        private readonly IScheduleRepository _sheduleRepository;
        private readonly ICustumerRepository _custumerRepository;
        private readonly IServiceScheduleRepository _serviceSheduleRepository;

        public ScheduleHandler(IScheduleRepository sheduleRepository, ICustumerRepository custumerRepository, IServiceScheduleRepository serviceSheduleRepository)
        {
            _sheduleRepository = sheduleRepository;
            _custumerRepository = custumerRepository;
            _serviceSheduleRepository = serviceSheduleRepository;
        }

        public IGenericCommandResult Handle(CreateScheduleCommand command)
        {
            var custumer = new Custumer(command.FullName, command.Phone);
            if (Validations.CustumerValidate(custumer) == false)
                return new GenericCommandResult("Não foi possivel criar o agendamento!", false);

            _custumerRepository.Save(custumer);

            var serviceShedule = new ServiceSchedule(command.ServiceName, command.ServiceValue, command.ServiceMinimumTime);
            if (Validations.ServiceScheduleValidate(serviceShedule) == false)
                return new GenericCommandResult("Não foi possivel criar o agendamento!", false);

            _serviceSheduleRepository.Save(serviceShedule);

            var shedule = new Schedule(command.ScheduleDate, command.ScheduleHour, command.ScheduleStatus, serviceShedule.Id, custumer.Id);
            if (Validations.ScheduleValidate(shedule) ==  false)
                return new GenericCommandResult("Não foi possivel criar o agendamento!", false);

            _sheduleRepository.Save(shedule);

            return new GenericCommandResult("Agendamento criado!", true);
        }

        public IGenericCommandResult Handle(UpdateScheduleCommand command)
        {
            var custumer = new Custumer(command.FullName, command.Phone);
            if (Validations.CustumerValidate(custumer) == false)
                return new GenericCommandResult("Não foi possivel atualizar o agendamento!", false);

            _custumerRepository.Update(custumer);

            var serviceShedule = new ServiceSchedule(command.ServiceName, command.ServiceValue, command.ServiceMinimumTime);
            if (Validations.ServiceScheduleValidate(serviceShedule) == false)
                return new GenericCommandResult("Não foi possivel atualizar o agendamento!", false);

            _serviceSheduleRepository.Update(serviceShedule);

            var shedule = new Schedule(command.ScheduleDate, command.ScheduleHour, command.ScheduleStatus, serviceShedule.Id, custumer.Id);
            if (Validations.ScheduleValidate(shedule) == false)
                return new GenericCommandResult("Não foi possivel atualizar o agendamento!", false);

            _sheduleRepository.Update(shedule);

            return new GenericCommandResult("Agendamento atualizado!", true);
        }

        public IGenericCommandResult Handle(DeleteScheduleCommand command)
        {
            var schedule = _sheduleRepository.GetById(command.ScheduleId);
            schedule.DeletionDate = DateTime.Now;
            schedule.SheduleStatus = ScheduleEnum.Canceled;

            _sheduleRepository.Delete(schedule);

            return new GenericCommandResult("Agendamento excluido!", true);
        }
    }
}
