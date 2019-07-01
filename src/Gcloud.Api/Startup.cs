using Gcloud.Api.Business;
using Gcloud.Api.Business.Contracts;
using Gcloud.Api.Repository;
using Gcloud.Api.Repository.Contract;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Gcloud.Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            var cs = Configuration.GetConnectionString("DefaultConnection");

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserBusiness, UserBusiness>();

            services.AddDbContext<Repository.Context.MAppContext>(options => options.UseSqlServer(cs));
            
            // Não precisa mais utilizar o addentityframeworksqlserver, a nao ser que utilize o serviceprovider
            // services.AddEntityFrameworkSqlServer()
            //     .AddDbContext<Repository.Context.AppContext>(options => options.UseSqlServer(cs));

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            UpdateDatabase(app);

            app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void UpdateDatabase(IApplicationBuilder app)
        {
            using (var sp = app.ApplicationServices.GetRequiredService<IServiceScopeFactory>().CreateScope())
            {
                using (var ctx = sp.ServiceProvider.GetRequiredService<Repository.Context.MAppContext>())
                    ctx.Database.Migrate();
            }
        }
    }
}
