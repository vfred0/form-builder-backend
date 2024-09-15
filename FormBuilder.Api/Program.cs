using FormBuilder.Api;
using FormBuilder.Persistence;
using FormBuilder.Repositories.FormStructure;
using FormBuilder.Repositories.Input;
using FormBuilder.Services.FormStructure;
using FormBuilder.Services.Input;
using FormBuilder.Services.Profiles;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");
    options.UseNpgsql(connectionString, b => b.MigrationsAssembly("FormBuilder.Persistence"));
});

builder.Services.AddTransient<IFormStructureService, FormStructureService>();
builder.Services.AddTransient<IInputService, InputService>();

builder.Services.AddTransient<IFormStructureRepository, FormStructureRepository>();
builder.Services.AddTransient<IInputRepository, InputRepository>();

//builder.Services.AddTransient<IFormStructureInputRepository, FormStructureInputRepository>();

builder.Services.AddAutoMapper(config =>
{
    config.AddProfile<FormStructureProfile>();
    config.AddProfile<InputProfile>();
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
const string corsPolicyName = "AllowAll";
builder.Services.AddCors(options =>
{
    options.AddPolicy(corsPolicyName, corsPolicyBuilder =>
    {
        corsPolicyBuilder.AllowAnyOrigin()
            .AllowAnyHeader()
            .AllowAnyMethod();
    });
});
builder.Services.AddHttpContextAccessor();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseRouting();
app.UseCors(corsPolicyName);
app.MigrateDatabase();
app.MapControllers();
app.Run();