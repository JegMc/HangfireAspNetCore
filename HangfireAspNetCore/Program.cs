using Hangfire;
using Hangfire.SqlServer;
using Hangfire.Dashboard;
using HangfireAspNetCore.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

// Configure Hangfire BEFORE building the app
builder.Services.AddHangfire(config =>
{
    config.UseSimpleAssemblyNameTypeSerializer()
          .UseRecommendedSerializerSettings()
          .UseSqlServerStorage(builder.Configuration.GetConnectionString("DefaultConnection"));
});

builder.Services.AddScoped<IJobTestService, JobTestService>();

// Start the Hangfire background server
builder.Services.AddHangfireServer();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

// Keep Hangfire Dashboard "Back to site" pointing at your app root.
// Do NOT set this to the FastAPI URL (that breaks the original Back to site behavior).
app.UseHangfireDashboard("/hangfire", new DashboardOptions
{
    AppPath = "/" // site root — restores "Back to site" behavior
});

// Ensure attribute-routed controllers are mapped
app.MapControllers();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();