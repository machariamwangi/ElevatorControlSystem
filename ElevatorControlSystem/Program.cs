using ElevatorControlSystem.Interfaces;
using ElevatorControlSystem.Services;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

ServiceProvider serviceProvider = new ServiceCollection()
    .AddLogging((loggingBuilder) => loggingBuilder
        .SetMinimumLevel(LogLevel.Trace)
        .AddConsole()
        )
    .BuildServiceProvider();

using IHost host = Host.CreateDefaultBuilder(args)
    .ConfigureServices(services =>
    {
        services.AddSingleton<IElevatorSimulatorService, ElevatorSimulatorService>();
    })
.Build();
Console.WriteLine("DI registered");

try
{
    var elevatorSimulator = host.Services.GetRequiredService<IElevatorSimulatorService>();

    // Example usage
    elevatorSimulator.CallElevator(5, 3, 250);
    elevatorSimulator.CallElevator(3, 2, 100);

    // Show elevator status
    elevatorSimulator.ShowElevatorStatus();

    Console.ReadLine();
}
catch (Exception ex)
{

    Console.WriteLine($"Error occurred {ex.Message} and Inner Ex {ex.InnerException}");
}


