namespace HangfireAspNetCore.Services
{
    public class JobTestService : IJobTestService
    {
        private readonly ILogger _logger;

        public JobTestService(ILogger<JobTestService> logger)
        {
            _logger = logger;
        }

        public void ContinuationJob()
        {
            _logger.LogInformation("Hello, testing from a continuation job!");
        }

        public void DelayedJob()
        {
            _logger.LogInformation("Hello, testing from a delayed job!");
        }

        public void FireAndForgetJob()
        {
            _logger.LogInformation("Hello, testing from a fire and forget job!");
        }

        public void RecurringJob()
        {
            _logger.LogInformation("Hello, testing from a recurring job!");
        }
    }
}
