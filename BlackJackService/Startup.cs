using BlackJackService.Context;
using BlackJackService.Data;
using BlackJackService.Model;
using BlackJackService.Repository;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace BlackJackService
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
            services.AddCors();

            services.AddDbContext<BlackJackContext>(opts => opts.UseSqlServer(Configuration["ConnectionString:BlackJack"]));
            services.AddScoped<ICard, CardRepository>();
            services.AddScoped<IPlayer, PlayerRepository>();
            services.AddScoped<ITransaction, TransactionRepository>();
            services.AddScoped<IGame, GameRepository>();
            services.AddScoped<IResult, ResultRepository>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);            
            services.AddMvc().AddJsonOptions(x => x.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
            services.AddCors(o => o.AddPolicy("AllowSpecificOrigin", builder =>
            {
                builder.AllowAnyOrigin()
                       .AllowAnyMethod()
                       .AllowAnyHeader()
                       .WithOrigins("http://localhost:4200");                
            }));
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
                app.UseHsts();
            }
            app.UseHttpsRedirection();
            app.UseCors("AllowSpecificOrigin");         
            app.UseMvc();
        }
    }
}
