using System.Collections;
using System.Collections.Generic;
using CodingKataRW.Models;
using CodingKataRW.Validation;
using Xunit;

namespace RWKataTestProject
{
    /// <summary>
    /// Tests for the coordinate validator
    /// i.e. valid coordinates are within the arena
    /// </summary>
    public class CoorindateValidationTests
    {
        [Theory]
        [ClassData(typeof(CoordinateValidatorTestData))]
        public void ValidateCoordinatesTest(Coordinates testCoordinates, Coordinates arenaCoordinates, bool isValid)
        {
            // Arrange
            var coordinateValidator = new CoordinateValidator(arenaCoordinates);

            // Act
            var result = coordinateValidator.ValidateCoordinates(testCoordinates);

            // Assert
            Assert.Equal(isValid, result);
        }
    }

    public class CoordinateValidatorTestData : IEnumerable<object[]>
    {
        public IEnumerator<object[]> GetEnumerator()
        {
            yield return new object[] { new Coordinates(1, 2), new Coordinates(5, 5), true };
            yield return new object[] { new Coordinates(0, 0), new Coordinates(5, 5), true };
            yield return new object[] { new Coordinates(6, 2), new Coordinates(5, 5), false };
            yield return new object[] { new Coordinates(2, 6), new Coordinates(5, 5), false };
            yield return new object[] { new Coordinates(6, 6), new Coordinates(5, 5), false };
            yield return new object[] { new Coordinates(-1, -1), new Coordinates(5, 5), false };
            yield return new object[] { new Coordinates(0, 0), new Coordinates(0, 0), true };
            yield return new object[] { new Coordinates(1, 0), new Coordinates(0, 0), false };
            yield return new object[] { new Coordinates(0, 1), new Coordinates(0, 0), false };
            yield return new object[] { new Coordinates(100, 100), new Coordinates(int.MaxValue, int.MaxValue), true };
            yield return new object[] { new Coordinates(int.MaxValue, int.MaxValue), new Coordinates(int.MaxValue, int.MaxValue), true };
            yield return new object[] { new Coordinates(int.MaxValue, int.MaxValue), new Coordinates(int.MinValue, int.MinValue), false };
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
