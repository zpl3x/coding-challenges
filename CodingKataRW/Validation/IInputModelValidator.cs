using CodingKataRW.Models.Input;

namespace CodingKataRW.Validation;

/// <summary>
/// Interface for the InputModelValidator class
/// </summary>
public interface IInputModelValidator
{
    /// <summary>
    /// Validates the input model
    /// </summary>
    /// <param name="inputModel">The Input Model</param>
    /// <returns>true for valid input models, false otherwise.</returns>
    bool ValidateInputModel(InputModel inputModel);
}