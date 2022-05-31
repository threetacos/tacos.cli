// dotnet tool install --global --add-source ./nupkg tacos.cli

using Spectre.Console;
using System.CommandLine;

var shellOption = new Option<string>(name: "--shell", description: "Choose either hard or soft", getDefaultValue: () => "hard");

var rootCommand = new RootCommand("A taco CLI tool to show how to make CLI tacos.");

var newCommand = new Command("new", "Create a new taco.")
{
    shellOption
};

rootCommand.Add(newCommand);

newCommand.SetHandler((string shell) =>
{
    DoAThing(shell);
}, shellOption);

AnsiConsole.Write(
    new FigletText("Taco CLI")
    .Color(Color.SandyBrown));

return await rootCommand.InvokeAsync(args);

static void DoAThing(string shell)
{
    Console.WriteLine($"You chose a {shell} taco.");
}