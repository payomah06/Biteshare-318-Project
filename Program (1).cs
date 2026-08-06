using BiteShare.Api.Hubs;
using BiteShare.Data;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// --- Services ---------------------------------------------------------

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSignalR();

builder.Services.AddDbContext<BiteShareDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Default")));

// TODO (Horoya, Phase 1): AddIdentity<...>() + AddAuthentication().AddJwtBearer(...)

var allowedOrigins = builder.Configuration.GetSection("Cors:AllowedOrigins").Get<string[]>() ?? Array.Empty<string>();
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPolicy", policy =>
        policy.WithOrigins(allowedOrigins)
              .AllowAnyHeader()
              .AllowAnyMethod()
              .AllowCredentials()); // required for SignalR
});

var app = builder.Build();

// --- Pipeline -----------------------------------------------------------

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("ClientPolicy");
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();
app.MapHub<OrderHub>("/hubs/order");

app.MapGet("/health", () => Results.Ok(new { status = "healthy" }));

app.Run();
