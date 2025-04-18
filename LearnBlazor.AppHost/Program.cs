var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.LearnBlazor_ApiService>("apiservice");

builder.AddProject<Projects.LearnBlazor_Web>("webfrontend")
    .WithExternalHttpEndpoints()
    .WithReference(apiService)
    .WaitFor(apiService);

builder.Build().Run();
