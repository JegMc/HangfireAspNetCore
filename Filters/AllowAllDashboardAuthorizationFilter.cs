using Hangfire.Dashboard;
using Microsoft.Extensions.Configuration;

public class AllowAllDashboardAuthorizationFilter : IDashboardAuthorizationFilter
{
    private readonly IConfiguration _configuration;

    public AllowAllDashboardAuthorizationFilter(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public bool Authorize(DashboardContext context) => true;

    public void ConfigureConnectionString()
    {
        var connectionString = _configuration.GetConnectionString("DefaultConnection");
        // Apply the connection string as needed
    }
}