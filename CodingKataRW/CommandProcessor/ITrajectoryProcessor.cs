using CodingKataRW.Models;
using CodingKataRW.Models.Input;

namespace CodingKataRW.CommandProcessor;

/// <summary>
/// Interface for the TrajectoryProcessor class
/// </summary>
public interface ITrajectoryProcessor
{ 
    GridPlacement ProcessTrajectory(RobotInputData robotInputData);
}