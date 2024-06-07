using RoboToyApp.Controller;

namespace RoboToyApp.nUnitTests
{
    public class ToyControllerTests
    {
        private IToyController _toyController;

        [SetUp]
        public void Setup()
        {
            // Initialize
            _toyController = new ToyController();
        }

        [Test]
        public void ToyController_IsInitiallyNotPlaced()
        {
            // Act
            var result = _toyController.Report();

            // Assert
            Assert.That(result.Equals("Robot is not placed on the table."));
        }

        [Test]
        public void ToyController_Place_ValidPosition_SetsProperties()
        {
            // Act
            _toyController.Place(1, 2, "EAST");
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("1"));
            Assert.That(output[1].Equals("2"));
            Assert.That(output[2].Equals("EAST"));
        }

        [Test]
        public void ToyController_Place_InvalidPosition_DoesntChangeState()
        {
            // Act
            _toyController.Place(-1, 3, "WEST"); // -1 is not a valid position
            var result = _toyController.Report();

            // Assert
            Assert.That(result.Equals("Robot is not placed on the table."));
        }

        [Test]
        public void ToyController_Place_InvalidDirection_DoesntChangeState()
        {
            // Act
            _toyController.Place(1, 3, "INVALID"); // -1 is not a valid position
            var result = _toyController.Report();

            // Assert
            Assert.That(result.Equals("Robot is not placed on the table."));
        }

        [Test]
        public void ToyController_Move_NotPlaced_DoesNothing()
        {
            // Act
            _toyController.Move();
            var result = _toyController.Report();

            // Assert
            Assert.That(result.Equals("Robot is not placed on the table."));
        }

        [Test]
        public void ToyController_Move_North_UpdatesY()
        {
            // Act
            _toyController.Place(0, 0, "NORTH");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("0")); // Unchanged X value
            Assert.That(output[1].Equals("1")); // Updates the Y value
            Assert.That(output[2].Equals("NORTH"));
        }

        [Test]
        public void ToyController_Move_East_UpdatesX()
        {
            // Act
            _toyController.Place(0, 0, "EAST");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("1")); // Updates the X value
            Assert.That(output[1].Equals("0")); // Unchanged Y value
            Assert.That(output[2].Equals("EAST"));
        }

        [Test]
        public void ToyController_Move_South_UpdatesY()
        {
            // Act
            _toyController.Place(0, 1, "SOUTH");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("0")); // Unchanged X value
            Assert.That(output[1].Equals("0")); // Updates the Y value
            Assert.That(output[2].Equals("SOUTH"));
        }

        [Test]
        public void ToyController_Move_West_UpdatesX()
        {
            // Act
            _toyController.Place(1, 0, "WEST");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("0")); // Updates the X value
            Assert.That(output[1].Equals("0")); // Unchanged Y value
            Assert.That(output[2].Equals("WEST"));
        }

        [Test]
        public void ToyController_Move_WontFallOffTable_North()
        {
            // Act
            _toyController.Place(0, 4, "NORTH");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("0")); // Unchanged X value
            Assert.That(output[1].Equals("4")); // Unchanged Y value
            Assert.That(output[2].Equals("NORTH"));
        }

        [Test]
        public void ToyController_Move_WontFallOffTable_East()
        {
            // Act
            _toyController.Place(4, 0, "EAST");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("4")); // Unchanged X value
            Assert.That(output[1].Equals("0")); // Unchanged Y value
            Assert.That(output[2].Equals("EAST"));
        }

        [Test]
        public void ToyController_Move_WontFallOffTable_South()
        {
            // Act
            _toyController.Place(3, 0, "SOUTH");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("3")); // Unchanged X value
            Assert.That(output[1].Equals("0")); // Unchanged Y value
            Assert.That(output[2].Equals("SOUTH"));
        }

        [Test]
        public void ToyController_Move_WontFallOffTable_West()
        {
            // Act
            _toyController.Place(0, 3, "WEST");
            _toyController.Move();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("0")); // Unchanged X value
            Assert.That(output[1].Equals("3")); // Unchanged Y value
            Assert.That(output[2].Equals("WEST"));
        }

        [Test]
        public void Left_RobotNotPlaced_DoesNotRotate()
        {
            // Act
            _toyController.Left();
            var result = _toyController.Report();
            
            // Assert
            Assert.That(result.Equals("Robot is not placed on the table."));
        }

        [Test]
        public void Left_RobotPlacedFacingNorth_RotatesToWest()
        {
            // Act
            _toyController.Place(2, 2, "NORTH");
            _toyController.Left();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("2")); // Unchanged X value
            Assert.That(output[1].Equals("2")); // Unchanged Y value
            Assert.That(output[2].Equals("WEST")); // Direction Updated
        }

        [Test]
        public void Right_RobotNotPlaced_DoesNotRotate()
        {
            // Act
            _toyController.Right();
            var result = _toyController.Report();

            // Assert
            Assert.That(result.Equals("Robot is not placed on the table."));
        }

        [Test]
        public void Right_RobotPlacedFacingNorth_RotatesToEast()
        {
            // Act
            _toyController.Place(2, 2, "NORTH");
            _toyController.Right();
            var result = _toyController.Report();

            string[] output = result.Split(',');

            // Assert
            Assert.That(output.Length.Equals(3));
            Assert.That(output[0].Equals("2")); // Unchanged X value
            Assert.That(output[1].Equals("2")); // Unchanged Y value
            Assert.That(output[2].Equals("EAST"));
        }
    }
}