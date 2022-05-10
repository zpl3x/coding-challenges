namespace CodingKataRW.Models
{
    /// <summary>
    /// Class for representing the
    /// coordinates in the Arena.
    /// </summary>
    public class Coordinates
    {
        private int _y;
        private int _x;

        /// <summary>
        /// Parameterless constructor.
        /// </summary>
        public Coordinates()
        {
        }

        /// <summary>
        /// Parameterised constructor.
        /// </summary>
        /// <param name="x">X coordinate</param>
        /// <param name="y">y coordinate</param>
        public Coordinates(int x, int y)
        {
            _x = x;
            _y = y;
        }

        /// <summary>
        /// Gets or Sets the X coordinate
        /// </summary>
        public int X
        {
            get => _x;
            set => _x = value;
        }

        /// <summary>
        /// Gets  the Y coordinate
        /// </summary>
        public int Y
        {
            get => _y;
            set => _y = value;
        }
    }
}
