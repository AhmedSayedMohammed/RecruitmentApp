using RecruitmentApp.Shared.Base;

namespace RecruitmentApp.Models
{
    public class Applicant : BaseEntity
    {
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }
    }
}
