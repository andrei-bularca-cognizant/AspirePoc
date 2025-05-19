using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.Functions.Worker;
using Microsoft.Extensions.Logging;

namespace GetTime_FunctionApp;

public class GetTimeFunction
{
    private readonly ILogger<GetTimeFunction> _logger;

    public GetTimeFunction(ILogger<GetTimeFunction> logger)
    {
        _logger = logger;
    }

    [Function("GetTime-Function")]
    public IActionResult Run([HttpTrigger(AuthorizationLevel.Function, "get", "post")] HttpRequest req)
    {
        _logger.LogInformation("C# HTTP trigger function processed a request.");
        _logger.LogInformation($"Current UTC Time: {DateTime.UtcNow}");
        return new OkObjectResult("Welcome to Azure Functions!");
    }
}