using Microsoft.EntityFrameworkCore;
using TesteTecFullstackAngular.Api.Infra;
using TesteTecFullstackAngular.Api.Infra.ORM;

var builder = WebApplication.CreateBuilder(args);

// Configuracoes de dependencias default
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Configuracoes de conexao com banco de dados
builder.Services.AddDbContext<DefaultContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("DefaultConnection"),
        b => b.MigrationsAssembly("TesteTecFullstackAngular.Api")
    )
);

// Dependencias no projeto
builder.AddDependencies();

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

// aplica as migrations no startup da Api
using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<DefaultContext>();
    await db.Database.MigrateAsync();
}

app.Run();
