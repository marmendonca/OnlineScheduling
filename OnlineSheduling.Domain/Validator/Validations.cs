using OnlineScheduling.Domain.Entities;

namespace OnlineScheduling.Domain.Validator
{
    public static class Validations
    {
        public static bool CustumerValidate(Custumer custumer)
        {
            var custumerValidator = new CustumerValidator();
            var modelState = custumerValidator.Validate(custumer);

            if (!modelState.IsValid)
                return false;

            return true;
        }

        public static bool ScheduleValidate(Schedule schedule)
        {
            var scheduleValidator = new ScheduleValidator();
            var modelState = scheduleValidator.Validate(schedule);

            if (!modelState.IsValid)
                return false;

            return true;
        }

        public static bool ServiceScheduleValidate(ServiceSchedule serviceSchedule)
        {
            var serviceScheduleValidator = new ServiceScheduleValidator();
            var modelState = serviceScheduleValidator.Validate(serviceSchedule);

            if (!modelState.IsValid)
                return false;

            return true;
        }
    }
}
