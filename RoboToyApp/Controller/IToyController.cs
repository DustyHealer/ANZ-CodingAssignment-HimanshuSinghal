namespace RoboToyApp.Controller
{
    public interface IToyController
    {
        /// <summary>
        /// Places the robot toy at (x,y) coordinates facing the direction 'facing'
        /// </summary>
        /// <param name="x">x-coordinate</param>
        /// <param name="y">y-coordinate</param>
        /// <param name="facing">Current Direction</param>
        void Place(int x, int y, string facing);

        /// <summary>
        /// Move the robot one space in the direction it is facing without falling
        /// </summary>
        void Move();

        /// <summary>
        /// Rotates the robot 90 degrees towards left of current direction
        /// </summary>
        void Left();

        /// <summary>
        /// Rotates the robot 90 degrees towards right of current direction
        /// </summary>
        void Right();

        /// <summary>
        /// Report the current coordinates and direction to the console
        /// </summary>
        /// <returns></returns>
        string Report();
    }
}
