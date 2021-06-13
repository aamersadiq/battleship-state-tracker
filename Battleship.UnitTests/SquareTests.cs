using NUnit.Framework;

namespace Battleship.UnitTests
{
    public class SquareTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_Return_Miss_When_No_Ship()
        {
            var square = new Square(new Coordinates(1, 3));

            var result = square.Attack();

            Assert.True(result == AttachResult.Miss);
        }

        [Test]
        public void Should_Return_Hit_When_Ship()
        {
            var square = new Square(new Coordinates(1, 3));
            square.Ship = new Ship(2);

            var result = square.Attack();

            Assert.True(result == AttachResult.Hit);
        }

        [Test]
        public void Should_Incremet_ShipHit_When_Hit()
        {
            var square = new Square(new Coordinates(1, 3));
            square.Ship = new Ship(1);

            square.Attack();

            Assert.True(square.Ship.Hits == 1);
        }
    }
}