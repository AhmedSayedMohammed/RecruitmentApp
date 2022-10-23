using RecruitmentApp.Shared.Filter;

namespace RecruitmentApp.Core.JobApplication.Query.Models
{
    public class GetAllJobApplicationsParameter : RequestParameter
    {
        public string SearchingWord { get; set; } = "";
    }
}
