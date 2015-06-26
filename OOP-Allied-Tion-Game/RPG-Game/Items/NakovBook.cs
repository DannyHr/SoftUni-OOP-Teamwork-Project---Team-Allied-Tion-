namespace RPG.Items
{
    public class NakovBook : Item
    {
        private int maxFocusBonus = 50;
        private bool isCollected = false;

        public NakovBook(Position position, string image)
            : base(position, image)
        {
            this.MaxFocusBonus = maxFocusBonus;
            this.IsCollected = isCollected;
        }

        public int MaxFocusBonus { get; private set; }
        public bool IsCollected { get; set; }
    }
}
