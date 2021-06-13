using NUnit.Framework;

namespace Battleship.UnitTests
{
    public class ShipTests
    {
        [Test]
        public void Should_Sunk_If_Hits_More_Than_Width()
        {
            var ship = new Ship(1);
            ship.Hits = 2;

            Assert.True(ship.IsSunk);
        }

        [Test]
        public void Should_Sunk_If_Hits_Less_Than_Width()
        {
            var ship = new Ship(2);
            ship.Hits = 1;

            Assert.False(ship.IsSunk);
        }
    }
}