using CodingKataRW.CommandProcessor;
using CodingKataRW.Models.Input;
using CodingKataRW.Validation;
using Newtonsoft.Json;
using Xunit;

namespace RWKataTestProject
{
    public class CommandManagerTests
    {
        [Theory]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}",
            "[{\"Coordinates\":{\"X\":1,\"Y\":3},\"Cardinal\":0},{\"Coordinates\":{\"X\":5,\"Y\":1},\"Cardinal\":1}]")]
        public void ProcessInputModel(string jsonInputModel, string jsonOutputModel)
        {
            // Arrange
            var inputValidator = new InputModelValidator();
            var inputModel = JsonConvert.DeserializeObject<InputModel>(jsonInputModel);

            var commandManager = new CommandManager(inputValidator);

            var result = "";

            // Act
            var valid = inputValidator.ValidateInputModel(inputModel);

            if (valid)
            {
                result = commandManager.ProcessInput(jsonInputModel);
            }

            // Assert
            Assert.NotNull(inputModel);
            Assert.True(valid);
            Assert.Equal(jsonOutputModel, result);
        }
    }
}
