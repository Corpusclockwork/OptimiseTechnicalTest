var builder = DistributedApplication.CreateBuilder(args);

var db = builder.AddConnectionString("sql");

var server = builder.AddProject<Projects.OptimiseTechnicalTest_Server>("server")
    .WithHttpHealthCheck("/health")
    .WithReference(db)
    .WithExternalHttpEndpoints();

var webfrontend = builder.AddViteApp("webfrontend", "../frontend")
    .WithReference(server)
    .WaitFor(server);

server.PublishWithContainerFiles(webfrontend, "wwwroot");

builder.Build().Run();
