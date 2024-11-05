using GroupStageSimulator.Application.Handlers;
using GroupStageSimulator.Application.Services;
using GroupStageSimulator.Infrastructure;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
// repos
services.AddSingleton<IMatchRepository, MockMatchRepository>();
services.AddSingleton<ITeamRepository, MockTeamRepository>();
services.AddSingleton<IRoundRepository, MockRoundRepository>();
//services
services.AddScoped<IMatchService, MatchService>();
services.AddScoped<ITeamService, TeamService>();
services.AddScoped<IRoundService, RoundService>();
// handlers
services.AddTransient<ICreateTeamsHandler, CreateTeamsHandler>();
services.AddTransient<ICreateRoundsHandler, CreateRoundsHandler>();
services.AddTransient<ICreateRoundsHandler, CreateRoundsHandler>();
services.AddTransient<IPositionHandler, PositionHandler>();
services.AddTransient<IPlayMatchesHandler, PlayMatchesHandler>();

var serviceProvider = services.BuildServiceProvider();

// Application code using the DI container
Console.WriteLine("Welcome to the Group stage simulator.");

var createTeamsHandler = serviceProvider.GetService<ICreateTeamsHandler>();
var createRoundsHandler = serviceProvider.GetService<ICreateRoundsHandler>();
var playMatchesHandler = serviceProvider.GetService<IPlayMatchesHandler>();
var positionHandler = serviceProvider.GetService<IPositionHandler>();

createTeamsHandler.Handle();

createRoundsHandler.Handle();

playMatchesHandler.Handle();

positionHandler.Handle();