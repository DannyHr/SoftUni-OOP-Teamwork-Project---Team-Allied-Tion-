namespace RPG.Items
{
    public class RedBull : Item
    {
        private int energyRestore = 40;

        public RedBull(Position position, string image) : base(position, image)
        {
            this.EnergyRestore = energyRestore;
        }

        public int EnergyRestore { get; private set; }
    }
}
