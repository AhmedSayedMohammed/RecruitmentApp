using RecruitmentApp.Data;
using RecruitmentApp.Models;
using RecruitmentApp.Service.Abstraction;

namespace RecruitmentApp.Service.Implementation
{
    public class JobApplcationService : IJobApplicationService
    {
        private readonly DataContext _context;

        public JobApplcationService(DataContext context)
        {
            _context = context;
        }

        public async Task<JobApplication> GetApplicantVacancyJobApplication(int vacancyId, int applicantId)
        {
            var app = _context.JobApplications.Where(x => x.vacancyId == vacancyId && x.applicantId == applicantId).FirstOrDefault();
            await _context.SaveChangesAsync();
            return app;
        }

        public async Task<List<JobApplication>> GetJobApplicationsByVacancy(int id)
        {
            var apps = _context.JobApplications.Where(x => x.vacancyId == id);
            await _context.SaveChangesAsync();
            return apps.ToList();
        }
    }
}
