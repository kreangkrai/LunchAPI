using LunchAPI.Interface;
using LunchAPI.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LunchAPI
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
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);
            services.AddSwaggerGen();

            services.AddScoped<IAuthen, AuthenService>();
            services.AddScoped<ICategory, CategoryService>();
            services.AddScoped<IEmployee, EmployeeService>();
            services.AddScoped<IGroup, GroupService>();
            services.AddScoped<IIngredients, IngredientsService>();
            services.AddScoped<IMenu, MenuService>();
            services.AddScoped<IPlanCloseShop, PlanCloseShopService>();
            services.AddScoped<IPlanOutOfIngredients, PlanOutOfIngredientsService>();
            services.AddScoped<IReserve, ReserveService>();
            services.AddScoped<IShop, ShopService>();
            services.AddScoped<ITopup, TopupService>();
            services.AddScoped<ITransaction, TransactionService>();
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
            app.UseMvc();
            app.UseSwagger();
            app.UseSwaggerUI();
        }
    }
}
