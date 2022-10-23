using RecruitmentApp.Models;

namespace RecruitmentApp.Service.Abstraction
{
    public interface IApplicantService
    {
        Task<Applicant> InsertOrUpdateApplicant(Applicant applicant);
        Task<Applicant> GetApplicantByEmail(string email);
        Task<Applicant> GetApplicantById(int email);
    }
}
