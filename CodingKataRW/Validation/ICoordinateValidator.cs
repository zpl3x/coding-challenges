using CodingKataRW.Models;

namespace CodingKataRW.Validation;

/// <summary>
/// Interface for Coordinate validator class.
/// </summary>
public interface ICoordinateValidator
{
    /// <summary>
    /// Validates the Coordinate model
    /// relative to (0,0) and Arena coordinates.
    /// </summary>
    /// <param name="coordinates"></param>
    /// <returns>true if within range, false otherwise</returns>
    bool ValidateCoordinates(Coordinates coordinates);
}