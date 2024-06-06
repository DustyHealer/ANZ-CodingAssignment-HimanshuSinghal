using RoboToy.Controller;

namespace RoboToy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Console.WriteLine("=======================================");
                Console.WriteLine("       Welcome to Toy Robot Simulator  ");
                Console.WriteLine("=======================================");
                Console.WriteLine();
                Console.WriteLine("This application simulates a toy robot moving on a 5x5 square tabletop.");
                Console.WriteLine("The following commands are available:");
                Console.WriteLine("  - PLACE X,Y,F  : Place the robot at position (X,Y) facing direction F (NORTH, SOUTH, EAST, or WEST)");
                Console.WriteLine("  - MOVE         : Move the robot one unit forward in the direction it is currently facing");
                Console.WriteLine("  - LEFT         : Rotate the robot 90 degrees to the left");
                Console.WriteLine("  - RIGHT        : Rotate the robot 90 degrees to the right");
                Console.WriteLine("  - REPORT       : Announce the current position and direction of the robot");
                Console.WriteLine();
                Console.WriteLine("The robot will not fall off the table. Any move that would result in falling is ignored.");
                Console.WriteLine("The origin (0,0) is at the SOUTH WEST corner of the table.");
                Console.WriteLine();
                Console.WriteLine("Type your commands below. Type 'Exit' to close the application.");
                Console.WriteLine("=======================================");
                Console.WriteLine();
                var robot = new ToyController();

                while (true)
                {
                    string line = Console.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        Console.WriteLine("Invalid command. Try Again.");
                        continue;
                    }

                    line = line.ToUpper();
                    string[] input = line.Split(' ');
                    string command = input[0].Trim();

                    if (!string.IsNullOrEmpty(command) && command.Equals("EXIT"))
                    {
                        Console.WriteLine("Exiting Application...");
                        break;
                    }

                    switch (command)
                    {
                        case "PLACE":
                            if (string.IsNullOrEmpty(input[1]))
                            {
                                Console.WriteLine("Invalid command format. Try again.");
                                continue;
                            }

                            string[] parts = input[1].Trim().Split(',');
                            if (parts.Length != 3)
                            {
                                Console.WriteLine("Invalid command format. Try again.");
                                continue;
                            }

                            int x = int.Parse(parts[0].Trim());
                            int y = int.Parse(parts[1].Trim());
                            ToyController.Direction facing = (ToyController.Direction)Enum.Parse(typeof(ToyController.Direction), parts[2].Trim());
                            robot.Place(x, y, facing);
                            break;
                        case "MOVE":
                            robot.Move();
                            break;
                        case "LEFT":
                            robot.Left();
                            break;
                        case "RIGHT":
                            robot.Right();
                            break;
                        case "REPORT":
                            Console.WriteLine(robot.Report());
                            break;
                        default:
                            Console.WriteLine("Invalid command. Try again.");
                            continue;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception Occurred: {e.Message}, Exiting...");
            }
        }
    }
}
