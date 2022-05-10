using CodingKataRW.Models;
using CodingKataRW.Models.Input;
using Action = CodingKataRW.Models.Action;

namespace CodingKataRW.Input
{
    /// <summary>
    /// 
    /// </summary>
    public class InputProcessor
    {
        /// <summary>
        /// A method to process individual robot trajectories
        /// </summary>
        /// <param name="robotStartingPosition">JSON representation of robot starting position</param>
        /// <param name="robotTrajectory">JSON representation of robot trajectory</param>
        /// <returns>The RobotInputData model.</returns>
        /// <exception cref="Exception">Exception thrown if issue processing input strings.</exception>
        public RobotInputData ProcessRobotInputStrings(string robotStartingPosition, string robotTrajectory)
        {
            try
            {
                var processedRobotStartingPosition = ProcessStringRobotStartPosition(robotStartingPosition);
                var processedRobotTrajectory = ProcessStringRobotTrajectory(robotTrajectory);

                var robotInputData = new RobotInputData
                {
                    RobotStartGridPlacement = processedRobotStartingPosition,
                    RobotTrajectory = new Trajectory
                    {
                        ActionSequence = processedRobotTrajectory
                    }
                };

                return robotInputData;

            }
            catch (Exception e)
            {
                Console.WriteLine(e);
                throw new Exception("Problem Processing Input Strings for Robot Input Data.");
            };
        }

        private List<Action> ProcessStringRobotTrajectory(string robotTrajectory)
        {
            var robotTrajectorySequenceStringList = robotTrajectory.Trim().ToCharArray().ToList();
            var result = new List<Action>();

            foreach (var actionString in robotTrajectorySequenceStringList)
            {
                switch (actionString)
                {
                    case 'L':
                        result.Add(Action.L);
                        break;
                    case 'R':
                        result.Add(Action.R);
                        break;
                    case 'M':
                        result.Add(Action.M);
                        break;
                    default:
                        throw new Exception("Error processing Robot Trajectory");
                }
            }

            return result;
        }

        private GridPlacement ProcessStringRobotStartPosition(string robotStartingPosition)
        {
            var splitString = robotStartingPosition.Trim().Split();

            var startingStringCoordinates = splitString.Take(2).Select(i => i.ToString()).ToArray(); ;
            var robotOrientation = splitString[2];

            var processedStartCoordinates = ProcessStringCoordinates(startingStringCoordinates);
            var processedRobotOrientation = ProcessRobotOrentation(robotOrientation);

            var result = new GridPlacement
            {
                Coordinates = processedStartCoordinates,
                Cardinal = processedRobotOrientation
            };

            return result;
        }

        private Cardinal ProcessRobotOrentation(string robotOrientation)
        {
            Cardinal result = Cardinal.N;
            switch (robotOrientation)
            {
                case "N":
                    result = Cardinal.N;
                    break;
                case "E":
                    result = Cardinal.E;
                    break;
                case "S":
                    result = Cardinal.S;
                    break;
                case "W":
                    result = Cardinal.W;
                    break;
                default:
                    throw new Exception("Error processing Robot orientation");
            }

            return result;
        }

        private Coordinates? ProcessStringCoordinates(string[] stringdArenaCoordinates)
        {
            if (stringdArenaCoordinates.Length != 2)
            {
                throw new Exception("Error processing coordinates - not enough coordinates supplied.");
            }

            if (Int32.TryParse(stringdArenaCoordinates[0], out int x)
                && Int32.TryParse(stringdArenaCoordinates[1], out int y))
            {
                return new Coordinates(x, y);
            }

            throw new Exception("Error processing coordinates");

        }

        /// <summary>
        /// A method for translating coordinate strings
        /// into the Coordinate model.
        /// </summary>
        /// <param name="coordinateString">coordinate string.</param>
        /// <returns>The Coordinates model.</returns>
        public Coordinates ProcessArenaCoordinates(string? coordinateString)
        {
            var stringdArenaCoordinates = coordinateString.Trim().Split(' ');

            var processedArenaCoordinates = ProcessStringCoordinates(stringdArenaCoordinates);

            return processedArenaCoordinates;

        }
    }
}
