using CodingKataRW.Models.Input;
using CodingKataRW.Validation;
using Newtonsoft.Json;
using Xunit;

namespace RWKataTestProject
{
    public class ModelValidationTests
    {

        [Theory]
        [InlineData("{\"ArenaCoordinates\":null,\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":-5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":0,\"Y\":0},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", true)]
        public void ValidateArenaCoordinates(string jsonInputModel, bool isValid)
        {
            // Arrange
            var inputValidator = new InputModelValidator();
            var inputModel = JsonConvert.DeserializeObject<InputModel>(jsonInputModel);

            // Act
            var result = inputValidator.ValidateInputModel(inputModel);

            // Assert
            Assert.NotNull(inputModel);
            Assert.Equal(isValid, result);
        }

        [Theory]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", true)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":6,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":6},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":-1,\"Y\":-6},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}},{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}", false)]
        public void ValidateRobotStartCoordinatesWithinArena(string jsonInputModel, bool isValid)
        {
            // Arrange
            var inputValidator = new InputModelValidator();
            var inputModel = JsonConvert.DeserializeObject<InputModel>(jsonInputModel);

            // Act
            var result = inputValidator.ValidateInputModel(inputModel);

            // Assert
            Assert.NotNull(inputModel);
            Assert.Equal(isValid, result);
        }

        [Theory]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":null}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[]}", false)]
        public void ValidateRobotInputData(string jsonInputModel, bool isValid)
        {
            // Arrange
            var inputValidator = new InputModelValidator();
            var inputModel = JsonConvert.DeserializeObject<InputModel>(jsonInputModel);

            // Act
            var result = inputValidator.ValidateInputModel(inputModel);

            // Assert
            Assert.NotNull(inputModel);
            Assert.Equal(isValid, result);
        }
    }
}
