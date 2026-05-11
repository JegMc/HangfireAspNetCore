using Hangfire;
using HangfireAspNetCore.Services;
using Microsoft.AspNetCore.Mvc;

namespace HangfireAspNetCore.Controllers;

[Route("api/[controller]")]
[ApiController]
public class JobTestController : ControllerBase
{
    private readonly IJobTestService _jobTestService;
    private readonly IBackgroundJobClient _backgroundJobClient;
    private readonly IRecurringJobManager _recurringJobManager;

    public JobTestController(IJobTestService jobTestService, IBackgroundJobClient backgroundJobClient, IRecurringJobManager recurringJobManager)
    {
        _jobTestService = jobTestService;
        _backgroundJobClient = backgroundJobClient;
        _recurringJobManager = recurringJobManager;
    }

    // Changed to GET so the endpoint can be invoked via browser / simple link
    [HttpGet("/FireAndForgetJob")]
    public ActionResult CreateFireAndForgetJob()
    {
        _backgroundJobClient.Enqueue(() => _jobTestService.FireAndForgetJob());

        return Ok();
    }

    [HttpGet("/DelayedJob")]
    public ActionResult CreateDelayedJob()
    {
        _backgroundJobClient.Schedule(() => _jobTestService.DelayedJob(), TimeSpan.FromSeconds(60));

        return Ok();
    }

    [HttpGet("/RecurringJob")]
    public ActionResult CreateRecurringJob()
    {
        _recurringJobManager.AddOrUpdate("JobId", () => _jobTestService.RecurringJob(), Cron.Minutely);

        return Ok();
    }

    [HttpGet("/ContinuationJob")]
    public ActionResult CreateReccuringJob()
    {
        var parentJobId = _backgroundJobClient.Enqueue(() => _jobTestService.FireAndForgetJob());
        _backgroundJobClient.ContinueJobWith(parentJobId, () => _jobTestService.ContinuationJob());

        return Ok();
    }
}
