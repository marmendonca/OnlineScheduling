using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.OpenApi.Models;
using OnlineScheduling.Api.Extensions;
using OnlineScheduling.Domain.Command.Commands.Mappers;
using OnlineScheduling.Domain.Command.Commands.v1.Schedules.Create;
using OnlineScheduling.Domain.ExceptionHandler;
using OnlineScheduling.Domain.Query.Queries.v1.Schedules.GetById;
using OnlineScheduling.Domain.Settings;
using OnlineScheduling.Infra.Context;

namespace OnlineScheduling.Api;

public class Startup(IConfiguration configuration)
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddControllers();
        services.AddProblemDetails();
        services.AddExceptionHandler<ApiExceptionHandler>();

        var connectionString = configuration.GetSection("DefaultConnection").Value;
        
        services.AddDbContext<DataContext>(options =>
            options.UseSqlServer(connectionString)
        );

        services.AddDapper(connectionString);
        
        services.AddServices();
        services.AddClients(configuration);
        
        services.AddMediatR(config => config
            .RegisterServicesFromAssemblies(typeof(CreateScheduleCommand).Assembly, typeof(GetScheduleByIdQuery).Assembly));

        services.AddAutoMapper(typeof(CustomerProfile));

        services.AddRepositories<DataContext>();
        
        services.AddValidatorsFromAssemblyContaining<CreateScheduleCommandValidator>();
        
        services.AddFluentValidationAutoValidation().AddFluentValidationClientsideAdapters();

        services.Configure<EfiBankSettings>(configuration.GetSection("EfiBankCredentials"));

        services.AddCors();

        services.AddSwaggerGen(c =>
        {
            c.SwaggerDoc("v1", new OpenApiInfo { Title = "OnlineSheduling.Api", Version = "v1" });
        });
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
    {
        app.UseExceptionHandler();
        
        if (env.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "OnlineSheduling.Api v1"));
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