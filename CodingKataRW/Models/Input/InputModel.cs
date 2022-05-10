namespace CodingKataRW.Models.Input
{
    public class InputModel
    {
        /// <summary>
        /// Gets or Sets the upper-right
        /// coordinates of the arena.
        /// </summary>
        public Coordinates ArenaCoordinates { get; set; }

        /// <summary>
        /// Gets or Sets the data related to the
        /// Robot's starting position and trajectory.
        /// </summary>
        public List<RobotInputData> RobotInputData { get; set; }
    }
}
