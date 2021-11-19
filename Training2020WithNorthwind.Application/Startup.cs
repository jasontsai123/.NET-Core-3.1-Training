using CoreProfiler.Web;
using GST.Library.Middleware.HttpOverrides;
using GST.Library.Middleware.HttpOverrides.Builder;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using Training2020WithNorthwind.Application.Infrastructure.DependencyInjection;
using Training2020WithNorthwind.Application.Infrastructure.Middlewares;
using Training2020WithNorthwind.Application.Infrastructure.OutputWrapper.Filters;
using ForwardedHeadersOptions = GST.Library.Middleware.HttpOverrides.Builder.ForwardedHeadersOptions;

namespace Training2020WithNorthwind.Application
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
            // HealthCheck
            services.AddHealthChecks()
                .AddSqlServer(Configuration["ConnectionStrings:NorthwindConnection"]);

            services.AddControllersWithViews();
            // IHttpContextAccessor
            services.AddHttpContextAccessor();
            services.AddControllers(options =>
                {
                    options.Filters.Add(new CustomActionResultFilter());
                    options.Filters.Add(new CustomExceptionFilter());
                    options.Filters.Add(new ValidateExceptionFilter());
                })
                .AddControllersAsServices()// �sĶ���ˬd���S���|���UDI
                .AddJsonOptions(options => options.JsonSerializerOptions.IgnoreNullValues = true);
            services.AddHttpClient();
            //DI
            services.AddDependencyInjection();
            // Register the Swagger generator, defining 1 or more Swagger documents
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            //RequestFilterMiddleware
            app.UseRequestFilter();
            // �p�G�n�ۤv���w IP �զW��M������|�A�i�H�ΥH�U���覡 app.UseRequestFilter(new[] { "127.0.0.1" }, new[] {
            // "Home" });

            //Coreprofiler
            app.UseCoreProfiler(true);

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production
                // scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            // �p�G�A���M�׬O��b Docker Container �̰���A���i��|�줣���ڪ��Τ�� IP �N�n�[�J�H�U���]�w���e�A�H���o Headers �̪�
            // X-Forwarded-For ���e�M X-Real-IP
            app.UseGSTForwardedHeaders(new ForwardedHeadersOptions
            {
                ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XRealIp,
                ForceXForxardedOrRealIp = true,
            });

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            /*
            app.Use(async (context, next) =>
            {
                EvertrustAsyncContext.CorrelationId = Guid.NewGuid();
                EvertrustAsyncContext.Domain = "Training2020WithNorthwind";
                EvertrustAsyncContext.Version = "1.0.0";

                await next.Invoke();
            });
            */

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller=Home}/{action=Index}/{id?}");
                // HealthCheck
                endpoints.MapHealthChecks("/health");
            });

            // Enable middleware to serve generated Swagger as a JSON endpoint.
            app.UseSwagger();
            // Enable middleware to serve swagger-ui (HTML, JS, CSS, etc.), specifying the Swagger
            // JSON endpoint.
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
            });
        }
    }
}