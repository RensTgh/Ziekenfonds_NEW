using ZiekenFonds.Web.Services;
using ZiekenFonds.Web.Services.Bestemming;
using ZiekenFonds.Web.Services.Deelnemers;
using ZiekenFonds.Web.Services.Monitor;
using ZiekenFonds.Web.Services.Opleiding;
using ZiekenFonds.Web.Services.Review;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Register Services here
builder.Services.AddScoped<IActiviteitenService, ActiviteitenService>();
// In Startup.cs -> ConfigureServices method
builder.Services.AddScoped<IMonitorService, MonitorService>();
builder.Services.AddScoped<IDeelnemerService, DeelnemerService>();
builder.Services.AddScoped<IOpleidingServices, OpleidingService>();
builder.Services.AddScoped<IFotoService, FotoService>();
builder.Services.AddScoped<IReviewServices, ReviewServices>();
builder.Services.AddScoped<IBestemmingService, BestemmingService>();

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

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();