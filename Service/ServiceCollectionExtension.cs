using FluentValidation;
using MediatR;
using RecruitmentApp.Service.Abstraction;
using RecruitmentApp.Service.Implementation;
using RecruitmentApp.Shared.Behavior;
using System.Reflection;
namespace RecruitmentApp.Service
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRecruitmentServices(this IServiceCollection services)
        {
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IJobApplicationService, JobApplcationService>();
            services.AddTransient<IVacancyService, VacancyService>();
            return services;
        }
        public static IServiceCollection AddSharedCore(this IServiceCollection services, IConfiguration config)
        {
            // services.Configure<CacheSettings>(config.GetSection(nameof(CacheSettings)));
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
            services.AddValidatorsFromAssembly(typeof(Program).Assembly);
            services.AddAutoMapper(typeof(Program));
            services.AddControllersWithViews();
            return services;
        }
    }
}
