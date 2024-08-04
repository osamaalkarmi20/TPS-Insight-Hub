using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using TPS_Insight_Hub;
using TPS_Insight_Hub.Models;
using TPS_Insight_Hub.Models.Interface;
using TPS_Insight_Hub.Models.Repository;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddTransient<IUser, IdentityUserService>();

builder.Services.AddScoped<IAuthorRepository, AuthorRepository>();
builder.Services.AddScoped<IBookRepository, BookRepository>();

builder.Services.AddDbContext<HubDbContext>(opts => {
    opts.UseSqlServer(
    builder.Configuration["ConnectionStrings:HubConnection"]);
});
builder.Services.AddIdentity<ApplicationUser, IdentityRole>(options =>
{
    options.User.RequireUniqueEmail = true;

}).AddEntityFrameworkStores<HubDbContext>();

builder.Services.ConfigureApplicationCookie(options =>
{
    options.LoginPath = "/User/Authenticate";
    options.AccessDeniedPath = "/User/AccessDenied";
});
builder.Services.AddAuthentication();
builder.Services.AddAuthorization();
builder.Services.AddLogging();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
