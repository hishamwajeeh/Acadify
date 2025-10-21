using Acadify.Core;
using Acadify.Core.Middleware;
using Acadify.Infrastructure;
using Acadify.Infrastructure.Data;
using Acadify.Service;
using Microsoft.AspNetCore.Localization;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using System.Globalization;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddControllers();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

#region Dependency Injection
builder.Services.AddInfrastructureDependencies()
    .AddServiceDependencies()
    .AddCoreDependencies();
#endregion

builder.Services.AddControllersWithViews();
builder.Services.AddLocalization(opt =>
    {
        opt.ResourcesPath = "";
    });

builder.Services.Configure<RequestLocalizationOptions>(option =>
    {
        List<CultureInfo> supportedCultures = new List <CultureInfo>
        {
            new CultureInfo("en-US"),
            new CultureInfo("fr-FR"),
            new CultureInfo("es-ES"),
            new CultureInfo("de-DE"),
            new CultureInfo("it-IT"),
            new CultureInfo("ar-EG")
        }
        ;
        option.DefaultRequestCulture = new RequestCulture("ar-EG");
        option.SupportedCultures = supportedCultures;
        option.SupportedUICultures = supportedCultures;
    }

);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var option = app.Services.GetService<IOptions<RequestLocalizationOptions>>();
app.UseRequestLocalization(option.Value);

app.UseMiddleware<ErrorHandlerMiddleware>();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
