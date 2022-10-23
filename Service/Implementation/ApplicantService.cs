using RecruitmentApp.Data;
using RecruitmentApp.Models;
using RecruitmentApp.Service.Abstraction;

namespace RecruitmentApp.Service.Implementation
{
    public class ApplicantService : IApplicantService
    {
        private readonly DataContext _context;

        public ApplicantService(DataContext context)
        {
            _context = context;
        }

        public async Task<Applicant> GetApplicantByEmail(string email)
        {
            var applicant = _context.Applicants.Where(x => x.Email == email).FirstOrDefault();
            await _context.SaveChangesAsync();
            return applicant;
        }

        public async Task<Applicant> GetApplicantById(int id)
        {
            var applicant = _context.Applicants.Find(id);
            await _context.SaveChangesAsync();
            return applicant;
        }

        public async Task<Applicant> InsertOrUpdateApplicant(Applicant applicant)
        {
            var currApp = _context.Applicants.Where(x => x.Email == applicant.Email).FirstOrDefault();
            if (currApp == null)
            {
                var res = _context.Applicants.Add(applicant);
                await _context.SaveChangesAsync();
                return applicant;
            }
            else
            {
                currApp.Name = applicant.Name;
                currApp.Email = applicant.Email;
                currApp.Mobile = applicant.Mobile;
                _context.Applicants.Update(currApp);
                await _context.SaveChangesAsync();
                return currApp;
            }
        }
    }
}
