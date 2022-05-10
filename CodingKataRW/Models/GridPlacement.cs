namespace CodingKataRW.Models
{
    public class GridPlacement
    {
        /// <summary>
        /// Gets or Sets the Coordinates
        /// </summary>
        public Coordinates Coordinates { get; set; }

        /// <summary>
        /// Gets or Sets the Cardinal direction
        /// north, south, east or west
        /// </summary>
        public Cardinal Cardinal { get; set; }
    }
}