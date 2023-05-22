using CoodeshTechChallenge.Application.Contracts;
using CoodeshTechChallenge.Application.Services;
using CoodeshTechChallenge.Domain;
using CoodeshTechChallenge.Persistence.Context;
using CoodeshTechChallenge.Persistence.Contracts;
using CoodeshTechChallenge.Persistence.Persistence;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace CoodeshTechChallenge.API
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            this.Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod());
            });

            string connection = Configuration.GetConnectionString("Default")!;

            services.AddDbContext<IDataContext, DataContext>(options =>
            {
                options.UseSqlServer(connection);
            });

            services.AddControllers();
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();

            services.AddScoped<ITransactionService, TransactionService>();

            services.AddScoped<IDynamicPersistence<Transaction>, DynamicPersistence<Transaction>>();
            services.AddScoped<IStaticPersistence<Transaction>, StaticPersistence<Transaction>>();
            services.AddScoped<IStaticPersistence<Type>, StaticPersistence<Type>>();
            services.AddScoped<IStaticPersistence<Product>, StaticPersistence<Product>>();
            services.AddScoped<IStaticPersistence<Seller>, StaticPersistence<Seller>>();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment environment)
        {
            app.UseCors(options => options.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

            if (environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();
            app.UseRouting();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
