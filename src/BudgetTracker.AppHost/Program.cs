var builder = DistributedApplication.CreateBuilder(args);

var apiService = builder.AddProject<Projects.BudgetTracker_ApiService>("apiservice");

builder.AddProject<Projects.BudgetTracker_Web>("webfrontend")
    .WithReference(apiService);

builder.Build().Run();
