# Clone the Git solution to the local machine
Go to the folder on your local machine where you want to copy the code and execute the below command:
>> git clone https://github.com/DustyHealer/ANZ-CodingAssignment-HimanshuSinghal.git

# How to run the RoboToy app?
1. After cloning the app in your local folder. Inside the root folder, please navigate to the Executable Folder.
2. Double click on the RoboToyApp.exe file to run the app.
3. The console will open with the below instructions:

This application simulates a toy robot moving on a 5x5 square tabletop.
The following commands are available:
  - PLACE X,Y,F  : Place the robot at position (X,Y) facing direction F (NORTH, SOUTH, EAST, or WEST)
  - MOVE         : Move the robot one unit forward in the direction it is currently facing
  - LEFT         : Rotate the robot 90 degrees to the left
  - RIGHT        : Rotate the robot 90 degrees to the right
  - REPORT       : Announce the current position and direction of the robot

The robot will not fall off the table. Any move that would result in falling is ignored.
The origin (0,0) is at the SOUTH WEST corner of the table.


# How to run test cases?
1. Pre requisites: Visual Studio should be installed with .net framework on local machine. 
2. Go to the root folder where you executed the git clone.
4. Double Click RoboToy.sln file. Open with visual studio.
5. Right click on the "Solution 'RoboToy'". Then click Build Solution.
6. Open Test Explorer and you will be able to see all the test cases. Right click on the test case and click run.
