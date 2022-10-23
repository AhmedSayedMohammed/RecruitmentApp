using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using RecruitmentApp.Core.JobApplication.Command.Models;
using RecruitmentApp.Core.JobApplication.Query.Models;
using RecruitmentApp.Data;
using RecruitmentApp.Models;
using RecruitmentApp.Service.Abstraction;
using RecruitmentApp.Shared.Wrapper;

namespace RecruitmentApp.Core.JobApplication.Handler
{
    public class JobApplicationHandler :
        IRequestHandler<RegisterJobApplicationCommand, Response<string>>,
        IRequestHandler<GetAllJobApplicationsQuery, PagedResponse<IEnumerable<GetAllJobApplicationResponse>>>
    {
        private readonly DataContext _context;
        private readonly IApplicantService _applicantService;
        private readonly IMapper _mapper;

        public JobApplicationHandler(DataContext context,
            IApplicantService applicantService,
            IMapper mapper)
        {
            _mapper = mapper;
            _applicantService = applicantService;
            _context = context;
        }


        public async Task<Response<string>> Handle(RegisterJobApplicationCommand request, CancellationToken cancellationToken)
        {

            // insert applicant if exist update his info and return Id
            Applicant newApplicant = new Applicant { Email = request.Email, Mobile = request.Mobile, Name = request.Name };
            Applicant existApplicant = await _applicantService.InsertOrUpdateApplicant(newApplicant);

            Models.JobApplication currentJobApplication = new Models.JobApplication

            {
                applicantId = existApplicant.Id,
                Status = ApplicationStatus.Viewd,
                vacancyId = request.vacancyId
            };

            _context.JobApplications.Add(currentJobApplication);
            await _context.SaveChangesAsync();

            return new Response<string>("Created Successfully");
        }

        public async Task<PagedResponse<IEnumerable<GetAllJobApplicationResponse>>> Handle(GetAllJobApplicationsQuery request, CancellationToken cancellationToken)
        {
            var validFilter = _mapper.Map<GetAllJobApplicationsParameter>(request);
            float totalCount = _context.JobApplications.Count();
            float totalPages = CalcPages(request.PageSize, totalCount);
            var nextPage = _context.JobApplications.Include(x => x.Applicant)
                .Include(x => x.Vacancy)
                    .OrderBy(b => b.CreatedDate)
                    .Skip((validFilter.PageNumber - 1) * request.PageSize)
                    .Take(validFilter.PageSize)
                    .ToList();
            await _context.SaveChangesAsync();
            var apps = _mapper.Map<IEnumerable<GetAllJobApplicationResponse>>(nextPage);

            return new PagedResponse<IEnumerable<GetAllJobApplicationResponse>>(apps, validFilter.PageNumber, validFilter.PageSize, (int)totalPages, nextPage.Count);

        }

        private static float CalcPages(float pageSize, float totalCount)
        {

            var totalPages = MathF.Ceiling(totalCount / pageSize);
            return totalPages;
        }
    }
}
