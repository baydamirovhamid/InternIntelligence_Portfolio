using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Portfolio.BusinessLayer.Services.Implementations.Achievement;
using Portfolio.BusinessLayer.Services.Implementations.ContactForm;
using Portfolio.BusinessLayer.Services.Implementations.Mail;
using Portfolio.BusinessLayer.Services.Implementations.Project;
using Portfolio.BusinessLayer.Services.Implementations.Skill;
using Portfolio.BusinessLayer.Services.Implementations.User;
using Portfolio.BusinessLayer.Services.Interfaces.Achievement;
using Portfolio.BusinessLayer.Services.Interfaces.ContactForm;
using Portfolio.BusinessLayer.Services.Interfaces.Mail;
using Portfolio.BusinessLayer.Services.Interfaces.Project;
using Portfolio.BusinessLayer.Services.Interfaces.Skill;
using Portfolio.BusinessLayer.Services.Interfaces.User;
using Portfolio.DataAccessLayer.Contexts;
using Portfolio.DataAccessLayer.Repositories;
using Portfolio.Domain.Entities;

var builder = WebApplication.CreateBuilder(args);



builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped(typeof(IRepository<>), typeof(GenericRepository<>));



builder.Services.AddScoped<IMailService, MailService>();
builder.Services.AddScoped<IAchievementService, AchievementService>();
builder.Services.AddScoped<IProjectService, ProjectService>();
builder.Services.AddScoped<ISkillService, SkillService>();
builder.Services.AddScoped<IContactFormService, ContactFormService>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.Configure<IdentityOptions>(options =>
{
    options.Password.RequireDigit = false;
    options.Password.RequireLowercase = false;
    options.Password.RequireUppercase = false;
    options.Password.RequireNonAlphanumeric = false;

});

builder.Services.AddControllers();


builder.Services.AddIdentity<AppUser, IdentityRole>()
    .AddEntityFrameworkStores<AppDbContext>()
    .AddDefaultTokenProviders();

builder.Services.AddSwaggerGen();
builder.Services.AddEndpointsApiExplorer();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors(options =>
    options.AllowAnyOrigin()
           .AllowAnyMethod()
           .AllowAnyHeader());

app.UseRouting();


app.UseAuthentication();
app.UseAuthorization();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
});
app.UseCookiePolicy();


app.Run();
