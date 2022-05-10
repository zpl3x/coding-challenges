using CodingKataRW.CommandProcessor;
using CodingKataRW.Models;
using CodingKataRW.Models.Input;
using CodingKataRW.Validation;
using Moq;
using Newtonsoft.Json;
using Xunit;

namespace RWKataTestProject
{
    /// <summary>
    /// Tests for the Trajectory processor and
    /// trajectory validation.
    /// </summary>
    public class TrajectoryProcessorTests
    {
        [Theory]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}}]}", true)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[3,0,1,0,1,0,1,0,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[-2,0,1,0,1,0,1,0,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[0,0,1,0,11,0,1,0,0]}}]}", false)]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[]}}]}", true)]
        public void TrajectoryValidatorTests(string jsonInputModel, bool isValid)
        {
            // Arrange
            var inputValidator = new InputModelValidator();
            var inputModel = JsonConvert.DeserializeObject<InputModel>(jsonInputModel);

            // Act
            var valid = inputValidator.ValidateInputModel(inputModel);

            // Assert
            Assert.Equal(valid, isValid);
        }

        [Theory]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":1,\"Y\":2},\"Cardinal\":0},\"RobotTrajectory\":{\"ActionSequence\":[1,0,1,0,1,0,1,0,0]}}]}",
            "{\"Coordinates\":{\"X\":1,\"Y\":3},\"Cardinal\":0}")]
        [InlineData("{\"ArenaCoordinates\":{\"X\":5,\"Y\":5},\"RobotInputData\":[{\"RobotStartGridPlacement\":{\"Coordinates\":{\"X\":3,\"Y\":3},\"Cardinal\":1},\"RobotTrajectory\":{\"ActionSequence\":[0,0,2,0,0,2,0,2,2,0]}}]}",
            "{\"Coordinates\":{\"X\":5,\"Y\":1},\"Cardinal\":1}")]
        public void ProcessTrajectory(string jsonInputModel, string jsonOutputModel)
        {
            // Arrange
            var inputValidator = new InputModelValidator();
            var inputModel = JsonConvert.DeserializeObject<InputModel>(jsonInputModel);

            var mockCoordinateValidator = new Mock<ICoordinateValidator>();
            mockCoordinateValidator.Setup(x => x.ValidateCoordinates(It.IsAny<Coordinates>())).Returns(true);

            var trajectoryProcessor = new TrajectoryProcessor(mockCoordinateValidator.Object);
            var robotInputData = inputModel.RobotInputData[0];

            GridPlacement result = null;
            var jsonResult = "";

            // Act
            var valid = inputValidator.ValidateInputModel(inputModel);

            if (valid)
            {
                result = trajectoryProcessor.ProcessTrajectory(robotInputData);
                jsonResult = JsonConvert.SerializeObject(result);
            }

            // Assert
            Assert.NotNull(inputModel);
            Assert.NotNull(result);
            Assert.Equal(jsonOutputModel, jsonResult);
        }
    }
}
