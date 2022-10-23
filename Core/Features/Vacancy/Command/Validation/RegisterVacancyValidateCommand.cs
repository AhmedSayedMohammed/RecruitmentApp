using FluentValidation;
using RecruitmentApp.Core.Vacancy.Command.Models;
using RecruitmentApp.Service.Abstraction;


namespace RecruitmentApp.Core.Vacancy.Command.Validation
{
    public class RegisterVacancyValidateCommand : AbstractValidator<RegisterVacancyCommand>
    {
        private readonly IVacancyService _vacancyService;
        private readonly IVacancyService _jobApplcationService;


        #region Constructor(s)
        public RegisterVacancyValidateCommand(IVacancyService vacancyService, IVacancyService jobApplcationService)
        {
            _jobApplcationService = jobApplcationService;
            _vacancyService = vacancyService;
            ApplyValidationRules();
        }
        #endregion

        #region Basic Validation Methods
        private void ApplyValidationRules()
        {

        }
        #endregion
        #region Custom Validation Methods


        #endregion
    }
}
