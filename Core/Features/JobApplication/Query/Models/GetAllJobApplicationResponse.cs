using RecruitmentApp.Models;

namespace RecruitmentApp.Core.JobApplication.Query.Models
{
    public class GetAllJobApplicationResponse
    {

        public int Id { get; set; }
        public ApplicationStatus Status { get; set; }
        public Applicant? Applicant { get; set; }
        public RecruitmentApp.Models.Vacancy? Vacancy { get; set; }
    }
}
