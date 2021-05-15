using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using TSKApp.BLL;
using TSKApp.BLL.Implementations;
using TSKApp.BLL.Interfaces;
using TSKApp.DAL;
using TSKApp.DAL.Data;
using TSKApp.DAL.Models;

[assembly: HostingStartup(typeof(TSKApp.Areas.Identity.IdentityHostingStartup))]
namespace TSKApp.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<TSKDbContext>(options =>
                    options.UseNpgsql(
                        context.Configuration.GetConnectionString("TSKDbContextConnection")));


                services.AddDefaultIdentity<AppUser>(options => {
                    options.Password.RequireDigit = true;
                    options.Password.RequiredLength = 5;
                    options.Password.RequireUppercase = true;
                    options.User.RequireUniqueEmail = true;
                    options.SignIn.RequireConfirmedAccount = false;
                })
                    .AddRoles<IdentityRole>()
                    .AddEntityFrameworkStores<TSKDbContext>();

                //repositories connetction
                services.AddTransient<IAnswersRepository, AnswersRepository>();
                services.AddTransient<ITestsRepository, TestsRepository>();
                services.AddTransient<IQuestionsRepository, QuestionsRepository>();
                services.AddTransient<IUsersRepository, UsersRepository>();
                services.AddTransient<ICorrectAnswerRepository, CorrectAnswerRepository>();
                services.AddTransient<IUserTestAccessRepository, UserTestAccessRepository>();
                services.AddTransient<IStatisticRepository, StatisticRepository>();

                //datamanager
                services.AddScoped<DataManager>();
            });
        }
    }
}