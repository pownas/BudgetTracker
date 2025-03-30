var builder = DistributedApplication.CreateBuilder(args);

builder.AddProject<Projects.BudgetTracker_Blazor>("budgettracker-blazor");

builder.Build().Run();
