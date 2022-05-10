using System.Collections.Generic;
using CodingKataRW.Models;
using CodingKataRW.Models.Input;
using CodingKataRW.Models.Ouput;
using Newtonsoft.Json;
using Xunit;

namespace RWKataTestProject
{
    /// <summary>
    /// Tests to demonstrate the essence of the above requirements
    /// are captured by the model and then expressed as JSON.
    /// </summary>
    public class ModelTests
    {
        [Fact]
        public void GenerateTestInputDataForModel()
        {
            var inputModel = new InputModel
            {
                ArenaCoordinates = new Coordinates
                {
                    X = 5,
                    Y = 5
                },

                RobotInputData = new List<RobotInputData>
                {
                    new RobotInputData()
                    {
                        RobotStartGridPlacement = new GridPlacement
                        {
                            Coordinates = new Coordinates(1, 2),
                            Cardinal = Cardinal.N
                        },
                        RobotTrajectory = new Trajectory
                        {
                            ActionSequence = new List<Action>
                            {
                                Action.L,
                                Action.M,
                                Action.L,
                                Action.M,
                                Action.L,
                                Action.M,
                                Action.L,
                                Action.M,
                                Action.M
                            }
                        }
                    },
                        new RobotInputData()
                        {
                            RobotStartGridPlacement = new GridPlacement
                            {
                                Coordinates = new Coordinates(3, 3),
                                Cardinal = Cardinal.E
                            },
                            RobotTrajectory = new Trajectory
                            {
                                ActionSequence = new List<Action>
                                {
                                    Action.M,
                                    Action.M,
                                    Action.R,
                                    Action.M,
                                    Action.M,
                                    Action.R,
                                    Action.M,
                                    Action.R,
                                    Action.R,
                                    Action.M
                                }
                            }
                        },
                }
            };

            var jsonString = JsonConvert.SerializeObject(inputModel);
            Assert.NotNull(jsonString);

        }

        [Fact]
        public void GenerateExpectedTestOutputDataFromModel()
        {
            var outputModel = new RobotOutputData
            {
                RobotEndPlacementList = new List<GridPlacement>
                {
                    new()
                    {
                        Cardinal = Cardinal.N,
                        Coordinates = new Coordinates(1, 3)
                    },
                    new()
                    {
                        Cardinal = Cardinal.E,
                        Coordinates = new Coordinates(5, 1)
                    }
                }
            };

            var jsonString = JsonConvert.SerializeObject(outputModel);
            Assert.NotNull(jsonString);
        }
    }
}