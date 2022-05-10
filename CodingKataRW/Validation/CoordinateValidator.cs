using CodingKataRW.Models;

namespace CodingKataRW.Validation
{
    /// <summary>
    /// Class containing all things related to coordinate validation.
    /// </summary>
    public class CoordinateValidator : ICoordinateValidator
    {
        private readonly Coordinates _arenaCoordinates;

        /// <summary>
        /// Constructor for coordinate validation.
        /// (Start of arena is always (0,0)).
        /// </summary>
        /// <param name="arenaCoordinates">The max x, y values for the arena.</param>
        public CoordinateValidator(Coordinates arenaCoordinates)
        {
            _arenaCoordinates = arenaCoordinates;
        }
        /// <summary>
        /// A method to validate coordinates relative to the defined arena.
        /// </summary>
        /// <param name="coordinates"></param>
        /// <returns>True for coordinates within range of the arena, false otherwise.</returns>
        public bool ValidateCoordinates(Coordinates coordinates)
        {
            var withinMax = coordinates.X <= _arenaCoordinates.X && coordinates.Y <= _arenaCoordinates.Y;
            var withinMin = coordinates.X >= 0 && coordinates.Y >= 0;

            return withinMax && withinMin;
        }
    }
}
