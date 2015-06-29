namespace RPG.Items
{
    public class MemoryUpgrade : Item
    {
        private int maxFocusBonus = 20;
        private bool isCollected = false;

        public MemoryUpgrade(Position position, string image)
            : base(position, image)
        {
            this.MaxFocusBonus = maxFocusBonus;
            this.IsCollected = isCollected;
        }

        public int MaxFocusBonus { get; private set; }
        public bool IsCollected { get; set; }
    }
}
