using API.Interfaces;
using API.Services;
using Azure.Communication.Email;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

builder.Services.AddOpenApi();

builder.Services.AddSingleton(_ => new EmailClient(builder.Configuration["ACS:ConnectionString"]));

builder.Services.AddScoped<IConfirmationService, ConfirmationService>();

var app = builder.Build();

app.MapOpenApi();

app.UseHttpsRedirection();
app.UseCors("CorsPolicy");

app.UseAuthorization();

app.MapControllers();

app.Run();
