using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Com.MrIT.Common.Configuration;
using Com.MrIT.DataRepository;
using Com.MrIT.DBEntities;
using Com.MrIT.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Microsoft.Extensions.Hosting;

namespace Com.MrIT.Application
{
    public class Startup
    {

        private const string enUSCulture = "en-US";
        private const string myCulture = "my";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.Configure<AppSettings>(Configuration.GetSection("AppSettings"));

            services.AddDistributedMemoryCache();
            services.AddMvc().AddSessionStateTempDataProvider();
            services.AddSession(options =>
            {
                // Set a short timeout for easy testing.
                options.IdleTimeout = TimeSpan.FromHours(10);
                options.Cookie.HttpOnly = true;
            });

                    

            services.AddControllers().AddJsonOptions(opts => opts.JsonSerializerOptions.PropertyNamingPolicy = null);

            services.AddRazorPages()
             .AddRazorRuntimeCompilation();

            services.AddMvc();

            services.AddHttpContextAccessor();
            services.TryAddSingleton<IActionContextAccessor, ActionContextAccessor>();

            RegisterForDependencyInjection(services);

            var sqlConnectionString = Configuration.GetConnectionString("DefaultConnection");

            // TODO: Update in each application
            services.AddDbContext<DataContext>(options =>
                    options.UseMySql(
                    sqlConnectionString,
                    b => b.MigrationsAssembly("MrIT") 
                )
            );

            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });

           
            services.AddLocalization(options => options.ResourcesPath = "Resources");

            services.AddMvc()
                .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                .AddDataAnnotationsLocalization();

            services.Configure<RequestLocalizationOptions>(options =>
            {
                var supportedCultures = new[]
                {
                    new CultureInfo(enUSCulture),
                    new CultureInfo(myCulture)
                    };

                options.DefaultRequestCulture = new RequestCulture(culture: myCulture, uiCulture: myCulture);
                options.SupportedCultures = supportedCultures;
                options.SupportedUICultures = supportedCultures;

                options.AddInitialRequestCultureProvider(new CustomRequestCultureProvider(async context =>
                {
                    // My custom request culture logic
                    return new ProviderCultureResult(enUSCulture);
                }));
            });

        }

        private void RegisterForDependencyInjection(IServiceCollection services)
        {
            //// Register for repository classes
            services.AddScoped<IAnnualIncomeRangeRepository, AnnualIncomeRangeRepository>();
            services.AddScoped<IApplicationPaymentRepository, ApplicationPaymentRepository>();
            services.AddScoped<IApplicationPaymentRepository, ApplicationPaymentRepository>();
            services.AddScoped<IApplicationRepository, ApplicationRepository>();
            services.AddScoped<IApplicationTypeRepository, ApplicationTypeRepository>();
            services.AddScoped<IEmailLogRepository, EmailLogRepository>();
            services.AddScoped<IEmailTemplateRepository, EmailTemplateRepository>();
            services.AddScoped<IEmployeeRangeRepository, EmployeeRangeRepository>();
            services.AddScoped<IEnterpriseAttachmentRepository, EnterpriseAttachmentRepository>();
            services.AddScoped<IEnterpriseBarrierRepository, EnterpriseBarrierRepository>();
            services.AddScoped<IEnterpriseCategoryRepository, EnterpriseCategoryRepository>();
            services.AddScoped<IEnterpriseImproveSurveyRepository, EnterpriseImproveSurveyRepository>();
            services.AddScoped<IEnterprisePermitRepository, EnterprisePermitRepository>();
            services.AddScoped<IEnterpriseProfileRepository, EnterpriseProfileRepository>();
            services.AddScoped<IEnterpriseRepository, EnterpriseRepository>();
            services.AddScoped<IErrorLogRepository, ErrorLogRepository>();
            services.AddScoped<IForeignBusinessConnectionRepository, ForeignBusinessConnectionRepository>();
            services.AddScoped<IImproveSurveyTypeRepository, ImproveSurveyTypeRepository>();
            services.AddScoped<IIsoTypeRepository, IsoTypeRepository>();
            services.AddScoped<ILoginLogRepository, LoginLogRepository>();
            services.AddScoped<INrcFirstRepository, NrcFirstRepository>();
            services.AddScoped<INrcSecondRepository, NrcSecondRepository>();
            services.AddScoped<INrcThirdRepository, NrcThirdRepository>();
            services.AddScoped<IOwnerTypeRepository, OwnerTypeRepository>();
            services.AddScoped<IPermitTypeRepository, PermitTypeRepository>();
            services.AddScoped<ISectorRepository, SectorRepository>();
            services.AddScoped<IStateRegionRepository, StateRegionRepository>();
            services.AddScoped<ISubAgencyPermissionRepository, SubAgencyPermissionRepository>();
            services.AddScoped<ISubAgencyRepository, SubAgencyRepository>();
            services.AddScoped<ISysUserRepository, SysUserRepository>();
            services.AddScoped<ITownshipRepository, TownshipRepository>();
            services.AddScoped<IUserOtpRepository, UserOtpRepository>();
            services.AddScoped<IWorkflowAssignmentRepository, WorkflowAssignmentRepository>();
            services.AddScoped<IWorkflowAssignmentApproverRepository, WorkflowAssignmentApproverRepository>();


            //// Register for logic classes
            services.AddScoped<ICommonService, CommonService>();
            services.AddScoped<IEmailService, EmailService>();
            services.AddScoped<IMrUserService, MrUserService>();

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            var supportedCultures = new[] { enUSCulture , myCulture };
            var localizationOptions = new RequestLocalizationOptions().SetDefaultCulture(supportedCultures[0])
                .AddSupportedCultures(supportedCultures)
                .AddSupportedUICultures(supportedCultures);

            app.UseRequestLocalization(localizationOptions);

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();
            app.UseSession();

            app.UseForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.All,
                RequireHeaderSymmetry = false,
                ForwardLimit = null
            });

           

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
