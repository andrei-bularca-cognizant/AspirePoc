using Microsoft.Extensions.Hosting;

var builder = DistributedApplication.CreateBuilder(args);

builder.AddAzureFunctionsProject<Projects.GetTime_FunctionApp>("gettime-functionapp");

#pragma warning disable ASPIREHOSTINGPYTHON001
var pythonappMain = builder.AddPythonApp("PythonFunction", "../PythonFunction", "main.py")
       .WithHttpEndpoint(env: "PORT")
       .WithExternalHttpEndpoints()
       .WithOtlpExporter();
var pythonappAzFunction = builder.AddPythonApp("PythonAzFunction", "../PythonAzFunction", "function_app.py")
       .WithHttpEndpoint(env: "PORT")
       .WithExternalHttpEndpoints()
       .WithOtlpExporter();
#pragma warning restore ASPIREHOSTINGPYTHON001

if (builder.ExecutionContext.IsRunMode && builder.Environment.IsDevelopment())
{
    pythonappMain.WithEnvironment("DEBUG", "True");
    pythonappAzFunction.WithEnvironment("DEBUG", "True");
}

builder.Build().Run();
