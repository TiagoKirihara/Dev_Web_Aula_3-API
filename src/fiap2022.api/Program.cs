using fiap2022.core.Contexts;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerGen(
    s => {
    s.SwaggerDoc("v1", new OpenApiInfo() { Title = "Api FIAP", Version = "V1"
        });
    });

builder.Services.AddControllers(config =>
{    config.RespectBrowserAcceptHeader = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddCors(x => {
    x.AddPolicy("Default", b => {
        b.AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader();
    });

});

var connection = @"Server=(localdb)\mssqllocaldb;Database=FiapDatabase;Trusted_Connection=True;ConnectRetryCount=0";
builder.Services.AddDbContext<DataContext>
    (o => o.UseSqlServer(connection));

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "api"));

app.UseRouting();

app.UseCors("Default");

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
