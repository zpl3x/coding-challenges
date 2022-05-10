using CodingKataRW.Models;
using CodingKataRW.Models.Input;
using CodingKataRW.Validation;
using Action = CodingKataRW.Models.Action;

namespace CodingKataRW.CommandProcessor
{
    public class TrajectoryProcessor : ITrajectoryProcessor
    {
        private readonly ICoordinateValidator _coordinateValidator;
        
        /// <summary>
        /// Constructor for the Trajectory Processor.
        /// </summary>
        /// <param name="coordinateValidator">Validation interface for coordinates.</param>
        public TrajectoryProcessor(ICoordinateValidator coordinateValidator)
        {
            _coordinateValidator = coordinateValidator;
        }

        /// <summary>
        /// Processes the Robots trajectory based on initial placement.
        /// Moves to coordinates outside of the arena are ignored.
        /// </summary>
        /// <param name="gridPlacement">Initial placement on the arena grid.</param>
        /// <param name="trajectory">Seuqyence of Actions.</param>
        /// <returns>Updated Grid Placement (direction and coordinates)</returns>
        //public GridPlacement ProcessTrajectory(GridPlacement gridPlacement, Trajectory trajectory)
        public GridPlacement ProcessTrajectory(RobotInputData robotInputData)
        {
            GridPlacement updatedGridPlacement = null;

            foreach (var action in robotInputData.RobotTrajectory.ActionSequence)
            {
                updatedGridPlacement = ProcessAction(robotInputData.RobotStartGridPlacement, action);
            }

            return updatedGridPlacement;
        }

        private GridPlacement ProcessAction(GridPlacement gridPlacement, Action action)
        {
            GridPlacement newGridPlacement = gridPlacement;

            switch (action)
            {
                case Action.L:
                    newGridPlacement.Cardinal = (Cardinal)((int)(gridPlacement.Cardinal + 3) % 4);
                    break;

                case Action.R:
                    newGridPlacement.Cardinal = (Cardinal)((int)(gridPlacement.Cardinal + 1) % 4);
                    break;

                case Action.M:
                    newGridPlacement.Coordinates = ProcessMove(gridPlacement);
                    break;
                default:
                    throw new Exception("Error Processing Trajectory Action.");
            }

            return newGridPlacement;
        }

        private Coordinates ProcessMove(GridPlacement gridPlacement)
        {
            Coordinates newCoordinates = new Coordinates();

            switch (gridPlacement.Cardinal)
            {
                case Cardinal.N:
                    newCoordinates.X = gridPlacement.Coordinates.X;
                    newCoordinates.Y = gridPlacement.Coordinates.Y + 1;
                    break;

                case Cardinal.E:
                    newCoordinates.X = gridPlacement.Coordinates.X + 1;
                    newCoordinates.Y = gridPlacement.Coordinates.Y;
                    break;

                case Cardinal.S:
                    newCoordinates.X = gridPlacement.Coordinates.X;
                    newCoordinates.Y = gridPlacement.Coordinates.Y - 1;
                    break;
                case Cardinal.W:
                    newCoordinates.X = gridPlacement.Coordinates.X - 1;
                    newCoordinates.Y = gridPlacement.Coordinates.Y;
                    break;
            }

            // ignore invalid new coordinates outside of the arena
            var newCoordinatesAreValid = _coordinateValidator.ValidateCoordinates(newCoordinates);

            return newCoordinatesAreValid ? newCoordinates : gridPlacement.Coordinates;
        }
    }
}
