using AutoMapper;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using OnionArchitecture.Services.Core.Application.Mapping;
using OnionArchitecture.Services.Core.Application.Repositories;
using OnionArchitecture.Services.Core.Application.Services;
using OnionArchitecture.Services.Core.Application.UnitOfWorks;
using OnionArchitecture.Services.Core.Application.Validations;
using OnionArchitecture.Services.Infrastructure.Persistence;
using OnionArchitecture.Services.Infrastructure.Persistence.Repositories;
using OnionArchitecture.Services.Infrastructure.Persistence.Services;
using OnionArchitecture.Services.Infrastructure.Persistence.UnitOfWorks;
using OnionArchitecture.Services.Presentation.API.Filters;
using OnionArchitecture.Services.Presentation.API.Middlewares;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;

namespace OnionArchitecture.Services.Presentation.API
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

            services.AddControllers(options =>  options.Filters.Add(new ValidaterFilterAttribute()) ).AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<BookDtoValidator>());

            services.Configure<ApiBehaviorOptions>(options =>
            {
                options.SuppressModelStateInvalidFilter = true;
            });

            services.AddScoped(typeof(NotFoundFilter<>));
            services.AddAutoMapper(typeof(MapProfile));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped(typeof(IService<>), typeof(Service<>));
            services.AddScoped<IBookRepository,BookRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<ICategoryService, CategoryService>();

            services.AddDbContext<AppDbContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("SqlConnection"), configure =>
            {
                //configure.MigrationsAssembly("OnionArchitecture.Services.Infrastructure.Persistence");
                configure.MigrationsAssembly(Assembly.GetAssembly(typeof(AppDbContext)).GetName().Name); // tip güvenli hali
            }));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();
            app.UseCustomException();
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
