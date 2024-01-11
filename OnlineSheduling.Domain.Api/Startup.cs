using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OnlineScheduling.Api.Extensions;
using OnlineScheduling.Domain.Command.Commands.v1.Customer;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;
using OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;
using OnlineScheduling.Infra.Context;

namespace OnlineSheduling.Domain.Api;

public class Startup
{
    public Startup(IConfiguration configuration)
    {
        Configuration = configuration;
    }

    public IConfiguration Configuration { get; }

    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();

        //services.AddDbContext<DataContext>(opt => opt.UseInMemoryDatabase("Database"));
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(Configuration.GetSection("DefaultConnection").Value)
        );

        services.AddMediatR(config => config.RegisterServicesFromAssemblies(typeof(CreateScheduleCommand).Assembly, typeof(GetScheduleByIdQuery).Assembly));

        services.AddAutoMapper(typeof(CustomerCommandProfile), typeof(GetScheduleByIdQueryProfile));

        services.AddRepositories<DataContext>();

        services.AddCors();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineSheduling.Domain.Api", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        if (env.IsDevelopment())
        {
            app.UseDeveloperExceptionPage();
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineSheduling.Domain.Api v1"));
        }

        app.UseHttpsRedirection();

        app.UseRouting();

        app.UseAuthorization();

        app.UseCors(x => x.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());

        app.UseEndpoints(endpoints =>
        {
            endpoints.MapControllers();
        });
    }
}