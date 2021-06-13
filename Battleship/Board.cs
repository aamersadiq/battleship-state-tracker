using System.Collections.Generic;
using System.Linq;

namespace Battleship
{
    public class Board
    {
        private const int BoardSize = 10;
        public List<Square> Squares { get; set; }
        public List<Ship> Ships { get; set; }
        public Board()
        {
            Squares = new List<Square>();
            for (int i = 1; i <= 10; i++)
            {
                for (int j = 1; j <= 10; j++)
                {
                    Squares.Add(new Square(new Coordinates(i, j)));
                }
            }

            Ships = new List<Ship>();
        }

        public bool AddShip(Coordinates coordinates, int length, Orientation orientation)
        {
            if (length < 1)
            {
                return false;
            }
            if (coordinates.Row < 1 || coordinates.Row > BoardSize
                || coordinates.Column < 1 || coordinates.Column > BoardSize)
            {
                return false;
            }

            int startRow = coordinates.Row, startColumn = coordinates.Column;
            int endRow = startRow, endColumn = startColumn;
            switch (orientation)
            {
                case Orientation.Horiztontal:
                    endColumn = endColumn + (length - 1);
                    break;
                case Orientation.Vertical:
                    endRow = endRow + (length - 1);
                    break;
                default:
                    return false;
            }

            if (endRow > BoardSize || endColumn > BoardSize)
            {
                return false;
            }

            var shipSquares = Squares.FindAll(x => x.Coordinates.Row >= startRow
                                 && x.Coordinates.Column >= startColumn
                                 && x.Coordinates.Row <= endRow
                                 && x.Coordinates.Column <= endColumn).ToList();

            if (shipSquares.Any(x => !x.IsEmpty))
            {
                return false;
            }

            var ship = new Ship(length);
            Ships.Add(ship);
            shipSquares.ForEach(ss => ss.Ship = ship);
            return true;
        }

        public AttachResult TakeAttack(Coordinates target)
        {
            var square = Squares.Find(s => s.Coordinates.Row == target.Row && s.Coordinates.Column == target.Column);
            return (square != null) ? square.Attack() : AttachResult.Miss;
        }

        public bool IsAllShipsSunk
        {
            get
            {
                return Ships.TrueForAll(s => s.IsSunk);
            }
        }
    }
}
