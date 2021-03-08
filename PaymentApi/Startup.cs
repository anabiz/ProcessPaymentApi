using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PaymentApi.Data;
using Microsoft.EntityFrameworkCore;
using PaymentApi.Interfaces;
using PaymentApi.Services;
using Microsoft.OpenApi.Models;

namespace PaymentApi
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
            services.AddHttpClient< IPaypalService, PaypalService>( c => {
                c.BaseAddress = new Uri("https://api.flutterwave.com/v3/charges?type=card");
            });
            // AddTransientHttpErrorPolicy();
            //services.AddHttpClient<IPaypalService, PaypalService>();


            services.AddScoped<IPaypalService, PaypalService>();

            services.AddScoped<ICheapPaymentGateway, CheapPaymentGateway>();

            services.AddScoped<IPaymentRepository, PaymentRepository>();

            services.AddScoped<IPaymentStatusRepository, PaymentStatusRepository>();

            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();

            services.AddScoped<IPremiumPaymentService, PremiumPaymentService>();

            services.AddScoped<IExpensivePaymentGateway, ExpensivePaymentGateway>();

            services.AddDbContextPool<PaymentContext>(options => options.UseSqlite(Configuration.GetConnectionString("DbConn")));

            services.AddMvc();

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Payment Processor Api",
                    Description = "ASP.NET Core Web Api for Processing Payment"
                });

            });            

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment processor Api V1");
                c.RoutePrefix = string.Empty;
            });

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
