using ConsentApp.Data;
using Microsoft.EntityFrameworkCore;

var b = WebApplication.CreateBuilder(args);

b.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
b.Services.AddEndpointsApiExplorer();
b.Services.AddSwaggerGen();

// EF
b.Services
    .AddDbContext<ApplicationDbContext>(o =>
    {
        // migration bundles don't like null connection strings (yet)
        // https://github.com/dotnet/efcore/issues/26869
        // so if no connection string is set we register without one for now.
        // if running migrations, `--connection` should be set on the command line
        // in real environments, connection string should be set via config
        // all other cases will error when db access is attempted.
        var connectionString = b.Configuration.GetConnectionString("Default");
        if (string.IsNullOrWhiteSpace(connectionString))
            o.UseNpgsql();
        else
            o.UseNpgsql(connectionString,
                o => o.EnableRetryOnFailure());
    });

var app = b.Build();

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
