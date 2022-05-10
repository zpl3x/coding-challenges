// See https://aka.ms/new-console-template for more information

using CodingKataRW.CommandProcessor;
using CodingKataRW.Input;
using CodingKataRW.Models;
using CodingKataRW.Models.Input;
using CodingKataRW.Validation;
using Newtonsoft.Json;

var inputModel = GetInputModel();
var inputModelJsonString = JsonConvert.SerializeObject(inputModel);

// client would probably send json string over the wire here
// processing here client-side for brevity to demonstrate principle of operation

var inputValidator = new InputModelValidator();
var commandManager = new CommandManager(inputValidator);
var result = commandManager.ProcessInput(inputModelJsonString);

WriteOutputModelToConsole();

Console.ReadLine();

InputModel GetInputModel()
{
    var inputModel = new InputModel
    {
        RobotInputData = new List<RobotInputData>()
    };

    var inputProcessor = new InputProcessor();

    Console.WriteLine("Enter two arena coordinates (e.g. 5 5) : ");
    var arenaCoordinates = Console.ReadLine();

    var processedArenaCoordinates = inputProcessor.ProcessArenaCoordinates(arenaCoordinates);
    inputModel.ArenaCoordinates = processedArenaCoordinates;

    var terminateInput = "Y";

    while (terminateInput == "Y")
    {
        Console.WriteLine("Enter robot starting position (e.g. 1 2 N) : ");
        var robotStartingPosition = Console.ReadLine();

        Console.WriteLine("Enter robot trajectory (e.g. LMLMLMLMM) : ");
        var robotTrajectory = Console.ReadLine();

        Console.WriteLine("Add more robots ? (Y/N)");
        terminateInput = Console.ReadLine();

        try
        {
            var robotInputData = inputProcessor.ProcessRobotInputStrings(robotStartingPosition, robotTrajectory);

            inputModel.RobotInputData.Add(robotInputData);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
        }
    }

    return inputModel;
}

void WriteOutputModelToConsole()
{
    var outputModel = JsonConvert.DeserializeObject<List<GridPlacement>>(result);

    if (outputModel != null)
    {
        foreach (var gridPlacement in outputModel)
        {
            Console.WriteLine($"{gridPlacement.Coordinates.X} " +
                              $"{gridPlacement.Coordinates.Y} " +
                              $"{gridPlacement.Cardinal}");
        }
    }
}
