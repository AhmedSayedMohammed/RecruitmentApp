using MediatR;
using RecruitmentApp.Shared.Wrapper;

namespace RecruitmentApp.Core.JobApplication.Command.Models
{
    public class RegisterJobApplicationCommand : IRequest<Response<string>>
    {
        public int vacancyId { get; set; }
        public string? Name { get; set; }
        public string? Email { get; set; }
        public string? Mobile { get; set; }

    }
}
