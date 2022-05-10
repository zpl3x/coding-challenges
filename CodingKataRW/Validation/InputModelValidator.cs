using CodingKataRW.Models;
using CodingKataRW.Models.Input;
using Action = CodingKataRW.Models.Action;

namespace CodingKataRW.Validation
{
    /// <summary>
    /// Class for all things Input Model Validation related.
    /// </summary>
    public class InputModelValidator : IInputModelValidator
    {
        /// <summary>
        /// Method to validate the input model, which describes
        /// arena parameters, starting position & orientation and
        /// trajectory for one or more robots.
        /// </summary>
        /// <param name="inputModel">The input model.</param>
        /// <returns>True is model is valid, False otherwise.</returns>
        public bool ValidateInputModel(InputModel inputModel)
        {
            var valid = ValidateArenaCoordinates(inputModel.ArenaCoordinates);
            if (!valid!)
            {
                return false;
            }

            valid = ValidateRobotInputData(inputModel);
            
            return valid;
        }

        private bool ValidateRobotInputData(InputModel inputModel)
        {
            var coordinateValidator = new CoordinateValidator(inputModel.ArenaCoordinates);
            
            if (inputModel.RobotInputData == null)
            {
                return false;
            }

            if (!inputModel.RobotInputData.Any())
            {
                return false;
            }

            foreach (var robotData in inputModel.RobotInputData)
            {
                var coordinatesValid = coordinateValidator.ValidateCoordinates(robotData.RobotStartGridPlacement.Coordinates);
                if (!coordinatesValid)
                {
                    return false;
                }

                var trajectoryValid = ValidateTrajectory(robotData.RobotTrajectory);
                if (!trajectoryValid)
                {
                    return false;
                }
            }

            return true;
        }

        private bool ValidateTrajectory(Trajectory robotDataRobotTrajectory)
        {
            return robotDataRobotTrajectory.ActionSequence.Cast<int>().All(action => ValidateEnum<Action>(action));
        }

        private bool ValidateEnum<TEnum>(int enumValue)
        {
            var isValid = Enum.IsDefined(typeof(TEnum), enumValue);
            
            return isValid;
        }
        private bool ValidateArenaCoordinates(Coordinates inputModelArenaCoordinates)
        {
            if (inputModelArenaCoordinates == null)
            {
                return false;
            }

            if (inputModelArenaCoordinates.X <= 0)
            {
                return false;
            }

            if (inputModelArenaCoordinates.Y <= 0)
            {
                return false;
            }

            return true;
        }
    }
}
