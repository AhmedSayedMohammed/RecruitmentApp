using RecruitmentApp.Shared.Base;

namespace RecruitmentApp.Models
{
    public enum ApplicationStatus
    {
        Viewd, Accepted, Rejected
    }
    public class JobApplication : BaseEntity
    {
        public int vacancyId { get; set; }
        public Vacancy? Vacancy { get; set; }
        public int applicantId { get; set; }
        public Applicant? Applicant { get; set; }
        public ApplicationStatus Status { get; set; }

    }
}
