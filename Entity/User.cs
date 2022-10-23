using RecruitmentApp.Shared.Base;

namespace RecruitmentApp.Models
{
    public class User : BaseEntity
    {

        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public bool IsAdmin { get; set; }
    }
}
