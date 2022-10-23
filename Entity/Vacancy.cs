using RecruitmentApp.Shared.Base;
using System.ComponentModel.DataAnnotations;

namespace RecruitmentApp.Models
{
    public enum VacancyStatus
    {
        Opened, Closed
    }
    public class Vacancy : BaseEntity
    {

        [StringLength(50)]
        [Required]
        public string? Name { get; set; }
        public string? Responsibilities { get; set; }
        public string? Skills { get; set; }
        [StringLength(100)]
        public string? JobCategory { get; set; }
        [Required]
        public DateTime ValidFrom { get; set; }
        [Required]
        public DateTime ValidTo { get; set; }
        public VacancyStatus Status { get; set; }
        public int MaxApplication { get; set; }
        public int userId { get; set; }
        public User? User { get; set; }
    }
}
