namespace RPG.Items
{
    public class Resharper : Item
    {
        private int maxEnergyBonus = 50;
        private bool isCollected = false;

        public Resharper(Position position, string image)
            : base(position, image)
        {
            this.MaxFocusBonus = maxEnergyBonus;
            this.IsCollected = isCollected;
        }

        public int MaxFocusBonus { get; private set; }
        public bool IsCollected { get; set; }
    }
}
