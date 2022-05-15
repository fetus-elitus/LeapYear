using Data.DataContext;
using Microsoft.EntityFrameworkCore;
using Services.Injection;
using Services;
using Microsoft.AspNetCore.Identity;
using Models.EntityModels;
using LeapYear.Middleware;

var builder = WebApplication.CreateBuilder(args);
var connectionString = builder.Configuration.GetConnectionString("PeopleDatabase:SqlServer");;

builder.Services.AddDbContext<PersonContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddIdentity<AppUser, IdentityRole>(
    options => {
        options.SignIn.RequireConfirmedAccount = true;
        options.Password.RequireUppercase = false;
        options.Password.RequireNonAlphanumeric = false;
    })
    .AddEntityFrameworkStores<PersonContext>().AddDefaultUI().AddDefaultTokenProviders();


// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddProjectService();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
    app.UseBrowserLink();

}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;

app.UseAuthorization();

app.MapRazorPages();
app.UseFirefoxRedirection();

app.Run();
