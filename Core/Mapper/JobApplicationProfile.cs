using AutoMapper;
using RecruitmentApp.Core.JobApplication.Query.Models;

namespace RecruitmentApp.Core.Mapper
{
    public class JobApplicationProfile : Profile
    {
        public JobApplicationProfile()
        {
            // Commands Data Mappings
            CreateMap<Models.JobApplication, GetAllJobApplicationResponse>().ReverseMap();

            CreateMap<GetAllJobApplicationsParameter, GetAllJobApplicationsQuery>().ReverseMap();

        }
    }
}
