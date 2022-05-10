using CodingKataRW.Models;
using CodingKataRW.Models.Input;
using CodingKataRW.Models.Ouput;
using CodingKataRW.Validation;
using Newtonsoft.Json;

namespace CodingKataRW.CommandProcessor
{
    /// <summary>
    /// A Class containing methods to process groups of robot data.
    /// </summary>
    public class CommandManager
    {
        private readonly IInputModelValidator _inputModelValidator;

        /// <summary>
        /// Constructor for the class.
        /// </summary>
        /// <param name="inputModelValidator"></param>
        public CommandManager(IInputModelValidator inputModelValidator)
        {
            _inputModelValidator = inputModelValidator;
        }

        /// <summary>
        /// Method to process the input model in the form of a JSON string,
        /// </summary>
        /// <param name="jsonInputModel"></param>
        /// <returns>JSON string representation of the output model.</returns>
        public string ProcessInput(string jsonInputModel)
        {
            
            var inputModel = JsonConvert.DeserializeObject<InputModel>(jsonInputModel);

            var modelIsValid = _inputModelValidator.ValidateInputModel(inputModel);

            if (!modelIsValid!)
            {
                var resultModel = new RobotOutputData()
                {
                    Errors = new List<string> { "Error - model is invalid" }
                };

                var resultString = JsonConvert.SerializeObject(resultModel);

                return resultString;
            }

            var trajectoryProcessor = new TrajectoryProcessor(new CoordinateValidator(inputModel.ArenaCoordinates));

            var outputModel = new List<GridPlacement>();
            foreach (var robotData in inputModel.RobotInputData)
            {
                var result = trajectoryProcessor.ProcessTrajectory(robotData);
                outputModel.Add(result);

            }

            var outputString = JsonConvert.SerializeObject(outputModel);
            return outputString;
        }
    }
}
