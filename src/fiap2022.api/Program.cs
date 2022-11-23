using fiap2022.core.Contexts;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

var connection = @"Server=(localdb)\mssqllocaldb;Database=FiapDatabase;Trusted_Connection=True;ConnectRetryCount=0";
builder.Services.AddDbContext<DataContext>
    (o => o.UseSqlServer(connection));

var app = builder.Build();

app.UseRouting();

app.UseEndpoints(endpoints => endpoints.MapControllers());

app.Run();
