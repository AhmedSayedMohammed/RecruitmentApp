using RecruitmentApp.Models;

namespace RecruitmentApp.Service.Abstraction
{
    public interface IJobApplicationService
    {
        Task<List<JobApplication>> GetJobApplicationsByVacancy(int id);
        Task<JobApplication> GetApplicantVacancyJobApplication(int vacancyId, int applicantId);
    }
}
