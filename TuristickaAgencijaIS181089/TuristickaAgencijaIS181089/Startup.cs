using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Stripe;
using TuristickaAgencijaIS181089.Domain;
using TuristickaAgencijaIS181089.Domain.Identity;
using TuristickaAgencijaIS181089.Repository.Data;
using TuristickaAgencijaIS181089.Repository.Implementation;
using TuristickaAgencijaIS181089.Repository.Interfaces;
using TuristickaAgencijaIS181089.Services;
using TuristickaAgencijaIS181089.Services.Implementation;
using TuristickaAgencijaIS181089.Services.Interfaces;

namespace TuristickaAgencijaIS181089
{
    public class Startup
    {
        private EmailSettings emailService;
        public Startup(IConfiguration configuration)
        {
            emailService = new EmailSettings();
            Configuration = configuration;
            Configuration.GetSection("EmailSettings").Bind(emailService);
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        [System.Obsolete]
        public void ConfigureServices(IServiceCollection services)
        {
            StripeConfiguration.SetApiKey(Configuration.GetSection("Stripe")["SecretKey"]);
            services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(
                    Configuration.GetConnectionString("DefaultConnection")));
            services.AddDefaultIdentity<TuristickaAgencijaUser>(options => options.SignIn.RequireConfirmedAccount = true)
                .AddEntityFrameworkStores<ApplicationDbContext>();
           
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped(typeof(IUserRepository), typeof(UserRepository));
            services.AddScoped(typeof(IOrderRepository), typeof(OrderRepository));

            services.AddScoped<EmailSettings>(es => emailService);
            services.AddScoped<IEmailService, EmailService>(email => new EmailService(emailService));
            services.AddScoped<IBackgroundEmailSender, BackgroundEmailSender>();
            services.AddHostedService<ConsumeScopedHostedService>();
            services.Configure<StripeSettings>(Configuration.GetSection("Stripe"));
            services.AddTransient<ILineService, Services.Implementation.LineService>();
            services.AddTransient<IUserService, Services.Implementation.UserService>();
            services.AddTransient<IReservationService, Services.Implementation.ReservationService>();
            services.AddTransient<IDestinationService, Services.Implementation.DestinationService>();
            services.AddTransient<ICompanyService, Services.Implementation.CompanyService>();
            services.AddTransient<IOrderService, Services.Implementation.OrderService>();
            services.AddControllersWithViews().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
          );
            services.AddRazorPages();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseDatabaseErrorPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapRazorPages();
            });
        }
    }
}
