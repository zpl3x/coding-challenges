Summary of Approach Taken
=========================
* Based on the use case provided (see copy below), first a model was built to capture the required behaviour described.
* Unit tests were then written (TDD) to build validator classes to validate the possible states within this model.
* Processor classes were then written to produce the required output from the input model.
* A simple console application was then written to demonstrate real-time interaction with the above.

Please note that unit tests are not exhaustive and do not provide 100 coverage of the entire application.
JSON was chosen as a typical message format that could be used between any client and server applications.

Logging was not added due to time constraints, but this could be added in the future.

Some information was not provided in the initial description - for example what action to take if a robot's
trajectory results in it moving out of the arena. In such an event, any move which would place a robot outside
the boundary of the arena is ignored.


Robot Wars
==========

Using either C# or F# and a TDD approach, spent no more than two hours on your solution. There should be an emphasis on [clean coding principles](Assets/Clean-Code-V2.4.pdf).

## Requirements

A fleet of hand built robots are due to engage in battle for the annual “Robot Wars” competition. Each robot will be placed within a rectangular battle arena 
and will navigate their way around the arena using a built in computer system.
 
A robot’s location and heading is represented by a combination of x and y co-ordinates and a letter representing one of the four cardinal compass points. 
The arena is divided up into a grid to simplify navigation. An example position might be 0, 0, N which means the robot is in the bottom left corner and facing North.
 
In order to control a robot, the competition organisers have provided a console for sending a simple string of letters to the on-board navigation system. 
The possible letters are ‘L’, ‘R’ and ‘M’. ‘L’ and ‘R’ make the robot spin 90 degrees to the left or right respectively without moving from its current spot 
while ‘M’ means move forward one grid point and maintain the same heading. Assume that the square directly North from (x, y) is (x, y+1).
 
## Input

The first line of input is the upper-right coordinates of the arena, the lower-left coordinates are assumed to be (0, 0).
 
The rest of the input is information pertaining to the robots that have been deployed. Each robot has two lines of input - the first gives the robot’s position 
and the second is a series of instructions telling the robot how to move within the arena.
 
The position is made up of two integers and a letter separated by spaces, corresponding to the x and y coordinates and the robot’s orientation. Each robot will 
finish moving sequentially, which means that the second robot won’t start to move until the first one has finished moving.
 
## Output

The output for each robot should be its final coordinates and heading.
 
## Test input

```
5 5
1 2 N
LMLMLMLMM
3 3 E
MMRMMRMRRM
```
 
## Expected output

```
1 3 N
5 1 E
```