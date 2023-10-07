#tool nuget:?package=NUnit.ConsoleRunner&version=3.4.0

var target = Argument("target", "Default");

var configuration = Argument("Configuration", "Release");

var solutions = GetFiles("./**/*.sln");

var projects = GetFiles("./**/*.csproj").Select(x => x.GetDirectory());

Task("clean")
    .Does(() =>
{
    foreach (var project in projects)
    {
        Information($"Cleaning {project}");

        DotNetCoreClean(project.FullPath);
    }

});
Task("restore")
    .Does(() =>
{
    foreach (var solution in solutions)
    {
        Information($"Restoring : {solution}");
        DotNetCoreRestore(solution.FullPath);
    }
});
Task("build")
    .Description("Build all projects.")
    .Does(() =>
{
    foreach (var project in projects)
    {
        DotNetCoreBuild(project.FullPath, new DotNetCoreBuildSettings()
        {
            Configuration = configuration,
        });
    }
});
Task("test")
    .Description("Execute all unit test projects.")
    .Does(() =>
{
    var projects = GetFiles("./test/**/*.csproj");

    if (projects.Count == 0)
    {
        Information("No test projects found.");
        return;
    }

    var settings = new DotNetCoreTestSettings
    {
        Configuration = configuration,
        NoBuild = true,
    };

    foreach (var project in projects)
    {
        DotNetCoreTest(project.FullPath, settings);
    }
});
Task("Default")
  .IsDependentOn("clean")
  .IsDependentOn("restore")
  .IsDependentOn("build")
  .IsDependentOn("test")
  .Does(() =>
{
    Information("build Complete");
});

RunTarget(target);