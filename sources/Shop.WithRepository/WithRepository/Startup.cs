using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Shop.WithRepository.Application.UseCases.PresentShelf;
using Shop.WithRepository.Domain.DataAccess;

namespace Shop.WithRepository
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddRazorPages();

            AddInMemoryDataAccess(services);
            //AddSqLiteDataAccess(services);

            services.AddMediatR(typeof(PresentShelfRequest).Assembly);
        }

        private static void AddInMemoryDataAccess(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, Shop.WithRepository.DataAccess.EntityFramework.UnitOfWork>();
            services.AddTransient<Shop.WithRepository.DataAccess.EntityFramework.RepositoryPatternDbContext>();
        }

        private static void AddSqLiteDataAccess(IServiceCollection services)
        {
            services.AddTransient<IUnitOfWork, Shop.WithRepository.DataAccess.InMemory.UnitOfWork>();
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
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}