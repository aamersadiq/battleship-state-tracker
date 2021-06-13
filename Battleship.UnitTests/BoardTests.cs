using NUnit.Framework;

namespace Battleship.UnitTests
{
    public class BoardTests
    {
        // ****** Add Ship Tests *******
        [Test]
        public void Should_Not_Add_Ship_If_Length_Less_Than_1()
        {
            var board = new Board();

            var result = board.AddShip(new Coordinates(1, 1), 0, Orientation.Horiztontal);

            Assert.False(result);
        }

        [Test]
        public void Should_Not_Add_Ship_If_Coordinates_Not_In_Range()
        {
            var board = new Board();

            var result = board.AddShip(new Coordinates(0, 12), 1, Orientation.Horiztontal);

            Assert.False(result);
        }

        [Test]
        public void Should_Not_Add_Ship_If_Goes_Out_Of_Board()
        {
            var board = new Board();

            var result = board.AddShip(new Coordinates(1, 1), 12, Orientation.Horiztontal);

            Assert.False(result);
        }

        [Test]
        public void Should_Add_Ship_Horizontaly()
        {
            var board = new Board();

            var result = board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);

            Assert.True(result);
        }

        [Test]
        public void Should_Add_Ship_Verticaly()
        {
            var board = new Board();

            var result = board.AddShip(new Coordinates(1, 1), 5, Orientation.Vertical);

            Assert.True(result);
        }

        [Test]
        public void Should_Add_Multiple_Ships()
        {
            var board = new Board();

            var ship1Result = board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);
            var ship2Result = board.AddShip(new Coordinates(3, 4), 6, Orientation.Vertical);

            Assert.True(ship1Result);
            Assert.True(ship2Result);
        }


        [Test]
        public void Should_Not_Add_Ship_If_There_Is_Already_Ship()
        {
            var board = new Board();
            board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);

            var result = board.AddShip(new Coordinates(1, 5), 2, Orientation.Horiztontal);

            Assert.False(result);
        }

        // ****** Take Attack Tests *******
        [Test]
        public void Should_Return_Miss_If_Target_Is_Out_Of_Range()
        {
            var board = new Board();
            board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);

            var result = board.TakeAttack(new Coordinates(15, 15));

            Assert.That(result == AttachResult.Miss);
        }

        [Test]
        public void Should_Return_Hit_If_There_Is_Ship()
        {
            var board = new Board();
            board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);

            var result = board.TakeAttack(new Coordinates(1, 3));

            Assert.That(result == AttachResult.Hit);
        }

        [Test]
        public void Should_Not_All_Lost_If_Ship_Is_Partially_Hit()
        {
            var board = new Board();
            board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);
            board.TakeAttack(new Coordinates(1, 1));
            board.TakeAttack(new Coordinates(1, 2));
            board.TakeAttack(new Coordinates(1, 5));

            var result = board.IsAllShipsSunk;

            Assert.False(result);
        }

        [Test]
        public void Should_All_Lost_If_Ship_Is_Completely_Hit()
        {
            var board = new Board();
            board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal);
            board.TakeAttack(new Coordinates(1, 1));
            board.TakeAttack(new Coordinates(1, 2));
            board.TakeAttack(new Coordinates(1, 3));
            board.TakeAttack(new Coordinates(1, 4));
            board.TakeAttack(new Coordinates(1, 5));

            var result = board.IsAllShipsSunk;

            Assert.True(result);
        }

        [Test]
        public void Should_All_Lost_If_Multiple_Ships_Are_Completely_Hit()
        {
            var board = new Board();
            board.AddShip(new Coordinates(1, 1), 5, Orientation.Horiztontal); // Ship 1
            board.AddShip(new Coordinates(3, 4), 6, Orientation.Vertical); // Ship 2
            board.AddShip(new Coordinates(6, 7), 3, Orientation.Horiztontal); // Ship 3
            // Ship 1 Hit
            board.TakeAttack(new Coordinates(1, 1));
            board.TakeAttack(new Coordinates(1, 2));
            board.TakeAttack(new Coordinates(1, 3));
            board.TakeAttack(new Coordinates(1, 4));
            board.TakeAttack(new Coordinates(1, 5));
            // Ship 2 Hit
            board.TakeAttack(new Coordinates(3, 4));
            board.TakeAttack(new Coordinates(4, 4));
            board.TakeAttack(new Coordinates(5, 4));
            board.TakeAttack(new Coordinates(6, 4));
            board.TakeAttack(new Coordinates(7, 4));
            board.TakeAttack(new Coordinates(8, 4));
            // Ship 3 Hit
            board.TakeAttack(new Coordinates(6, 7));
            board.TakeAttack(new Coordinates(6, 8));
            board.TakeAttack(new Coordinates(6, 9));

            var result = board.IsAllShipsSunk;

            Assert.True(result);
        }

    }
}