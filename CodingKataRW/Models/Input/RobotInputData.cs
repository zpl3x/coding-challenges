namespace CodingKataRW.Models.Input
{
    public class RobotInputData
    {
        /// <summary>
        /// Gets or Sets a Robot's
        /// Starting Grid Position
        /// </summary>
        public GridPlacement RobotStartGridPlacement { get; set; }

        /// <summary>
        /// Get or Sets A Robot's Trajectory
        /// </summary>
        public Trajectory RobotTrajectory { get; set; }
    }
}