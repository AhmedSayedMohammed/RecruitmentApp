using FluentValidation;
using RecruitmentApp.Core.JobApplication.Command.Models;
using RecruitmentApp.Service.Abstraction;


namespace RecruitmentApp.Core.JobApplication.Command.Validation
{
    public class RegisterJobApplicationValidateCommand : AbstractValidator<RegisterJobApplicationCommand>
    {
        private readonly IVacancyService _vacancyService;
        private readonly IJobApplicationService _jobApplcationService;
        private readonly IApplicantService _applicantService;


        #region Constructor(s)
        public RegisterJobApplicationValidateCommand(
            IVacancyService vacancyService,
            IJobApplicationService jobApplcationService,
            IApplicantService applicantService
            )
        {
            _applicantService = applicantService;
            _jobApplcationService = jobApplcationService;
            _vacancyService = vacancyService;
            ApplyValidationRules();

        }
        #endregion

        #region Basic Validation Methods
        private void ApplyValidationRules()
        {
            RuleFor(d => d.Email)
                .NotEmpty()
                .NotNull().WithMessage("{PropertyName} is required and can't be null.");
            RuleFor(d => d.Mobile)
               .NotEmpty()
               .NotNull().WithMessage("{PropertyName} is required and can't be null.");

            RuleFor(d => d.Name)
             .NotEmpty()
             .NotNull().WithMessage("{PropertyName} is required and can't be null.");

            RuleFor(d => d).Must(d => ValidateVacancy(d)).WithMessage("This vacancy is not valid");

        }
        #endregion
        bool ValidateVacancy(RegisterJobApplicationCommand jobApplication)
        {
            var vac = _vacancyService.GetByIdAsync(jobApplication.vacancyId).Result;
            var applicant = _applicantService.GetApplicantByEmail(jobApplication.Email).Result;
            var appsForCurrentVacancy = _jobApplcationService.GetJobApplicationsByVacancy(jobApplication.vacancyId).Result;

            if (vac.Status == RecruitmentApp.Models.VacancyStatus.Closed)
            {
                throw new ValidationException("this vacancy is closed");
            }
            else if (vac.ValidFrom > DateTime.UtcNow)
            {
                throw new ValidationException("this vacancy ha not started yet");
            }
            else if (vac.ValidTo < DateTime.UtcNow)
            {
                throw new ValidationException("this vacancy is outdated");
            }
            else if (vac.MaxApplication <= appsForCurrentVacancy.Count)
            {
                throw new ValidationException("sorry we don't accept more applications");
            }
            else if (applicant != null && appsForCurrentVacancy.Any(x => x.applicantId == applicant.Id))
            {
                throw new ValidationException("You already applied");

            }

            return true;

        }
        #region Custom Validation Methods


        #endregion
    }
}
