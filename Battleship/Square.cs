namespace Battleship
{
    public class Square
    {
        public Coordinates Coordinates { get; set; }
        public Ship Ship { get; set; }

        public Square(Coordinates coordinates)
        {
            Coordinates = coordinates;
        }

        public AttachResult Attack()
        {
            if (IsEmpty)
            {
                return AttachResult.Miss;
            }

            Ship.Hits++;
            return AttachResult.Hit;
        }

        public bool IsEmpty
        {
            get
            {
                return Ship == null;
            }
        }
    }
}
