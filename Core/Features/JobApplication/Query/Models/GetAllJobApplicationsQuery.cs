using MediatR;
using RecruitmentApp.Shared.Wrapper;

namespace RecruitmentApp.Core.JobApplication.Query.Models
{
    public class GetAllJobApplicationsQuery : IRequest<PagedResponse<IEnumerable<GetAllJobApplicationResponse>>>
    {
        #region Vars / Props

        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }

        #endregion
        public GetAllJobApplicationsQuery(int pageNumber = 1, int pageSize = 10, string searchString = "")
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
        }
    }
}
