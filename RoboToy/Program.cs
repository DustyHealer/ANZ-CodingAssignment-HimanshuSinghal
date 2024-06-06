using RoboToy.Controller;

namespace RoboToy
{
    internal class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var robot = new ToyController();

                while (true)
                {
                    string line = Console.ReadLine();

                    if (string.IsNullOrEmpty(line))
                    {
                        break;
                    }

                    line = line.ToUpper();
                    string[] input = line.Split(' ');
                    string command = input[0].Trim();

                    switch (command)
                    {
                        case "PLACE":
                            if (string.IsNullOrEmpty(input[1]))
                            {
                                Console.WriteLine("Invalid command format.");
                                continue;
                            }

                            string[] parts = input[1].Trim().Split(',');
                            if (parts.Length != 3)
                            {
                                Console.WriteLine("Invalid command format.");
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
                            Console.WriteLine("Invalid command.");
                            break;
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
