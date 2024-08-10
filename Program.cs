using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.EntityFrameworkCore;
using SigmaApplication.CRUDService;
using SigmaApplication.Implementations;
using SigmaApplication.Interfaces;
using SigmaApplication.Models;
using SigmaApplication.RequestHandler;
using SigmaApplication.Utility;
using System.Runtime.Intrinsics.X86;


internal class Program
{
    private static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);


        builder.Services.AddControllers();
        builder.Services.AddControllers()
        .AddJsonOptions(options =>
        {
            options.JsonSerializerOptions.Converters.Add(new TimeOnlyConverter());
        });

        // Register the DbContext with the appropriate database provider
        builder.Services.AddDbContext<SigmaContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
        builder.Services.AddTransient<ICandidateService, CandidateService>();

        builder.Services.AddMediatR(typeof(AddUpdateCandidateHandler).Assembly);
        builder.Services.AddAutoMapper(typeof(Program).Assembly);

        // Register the generic CRUD service
        builder.Services.AddScoped(typeof(IGenericCRUDService<>), typeof(GenericCRUDService<>));
        builder.Services.AddFluentValidation(fv =>
        {
            fv.RegisterValidatorsFromAssemblyContaining<CandidateModel>();
        });
        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();

        app.UseAuthorization();

        app.MapControllers();

        app.Run();
    }
}