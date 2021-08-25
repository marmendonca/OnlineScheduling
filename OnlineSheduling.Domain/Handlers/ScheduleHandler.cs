using OnlineScheduling.Domain.Commands;
using OnlineScheduling.Domain.Commands.Contracts;
using OnlineScheduling.Domain.Entities;
using OnlineScheduling.Domain.Handlers.Contracts;
using OnlineScheduling.Domain.Repositories;
using OnlineScheduling.Domain.Validator;
using System;
using OnlineScheduling.Domain.Enums;

namespace OnlineScheduling.Domain.Handlers
{
    public class ScheduleHandler : IHandler<CreateScheduleCommand>, IHandler<UpdateScheduleCommand>, IHandler<DeleteScheduleCommand>
    {
        private readonly IScheduleRepository _scheduleRepository;
        private readonly ICustumerRepository _custumerRepository;
        private readonly IServiceScheduleRepository _serviceSheduleRepository;

        public ScheduleHandler(IScheduleRepository sheduleRepository, ICustumerRepository custumerRepository, IServiceScheduleRepository serviceSheduleRepository)
        {
            _scheduleRepository = sheduleRepository;
            _custumerRepository = custumerRepository;
            _serviceSheduleRepository = serviceSheduleRepository;
        }

        public IGenericCommandResult Handle(CreateScheduleCommand command)
        {
            var custumer = _custumerRepository.IsExists(command.Phone);
            if (custumer == null)
            {
                custumer = new Custumer(command.FullName, command.Phone);
                if (Validations.CustumerValidate(custumer) == false)
                    return new GenericCommandResult("Não foi possivel criar o agendamento!", false);

                _custumerRepository.Save(custumer);
            }

            var serviceShedule = _serviceSheduleRepository.IsExist(command.ServiceName);
            if (serviceShedule == null)
               return new GenericCommandResult("Não foi possivel criar o agendamento!", false);
            

            var schedule = _scheduleRepository.IsExists(command.ScheduleHour, command.ScheduleDate);
            if (schedule != null)
                return new GenericCommandResult("Já existe agendamento no horário solicitado!", true);

            schedule = new Schedule(command.ScheduleDate, command.ScheduleHour, command.ScheduleStatus, serviceShedule, custumer);
            if (Validations.ScheduleValidate(schedule) == false)
                return new GenericCommandResult("Não foi possivel criar o agendamento!", false);

            _scheduleRepository.Save(schedule);

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

            var shedule = new Schedule(command.ScheduleDate, command.ScheduleHour, command.ScheduleStatus, serviceShedule, custumer);
            if (Validations.ScheduleValidate(shedule) == false)
                return new GenericCommandResult("Não foi possivel atualizar o agendamento!", false);

            _scheduleRepository.Update(shedule);

            return new GenericCommandResult("Agendamento atualizado!", true);
        }

        public IGenericCommandResult Handle(DeleteScheduleCommand command)
        {
            var schedule = _scheduleRepository.GetById(command.ScheduleId);
            schedule.DeletionDate = DateTime.Now;
            schedule.SheduleStatus = ScheduleEnum.Canceled;

            _scheduleRepository.Delete(schedule);

            return new GenericCommandResult("Agendamento excluido!", true);
        }
    }
}
