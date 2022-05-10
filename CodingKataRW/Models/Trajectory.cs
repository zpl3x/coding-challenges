namespace CodingKataRW.Models
{
    /// <summary>
    /// A class containing all relating to
    /// a robot's Trajectory.
    /// </summary>
    public class Trajectory
    {
        /// <summary>
        /// Gets or Sets the Trajectory
        /// based on a sequence of actions.
        /// </summary>
        public List<Action> ActionSequence { get; set; }
    }
}