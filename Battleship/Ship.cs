using System;

namespace Battleship
{
    public class Ship
    {
        public Guid Id { get; set; }
        public int Hits { get; set; }
        public int Length { get; set; }
        public Ship(int length)
        {
            Id = Guid.NewGuid();
            Length = length;
        }
        public bool IsSunk
        {
            get
            {
                return Hits >= Length;
            }
        }
    }
}
