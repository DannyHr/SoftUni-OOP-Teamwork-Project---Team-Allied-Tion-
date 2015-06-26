namespace RPG.Items
{
    public class Beer : Item
    {
        private int focusRestore = 40;

        public Beer(Position position, string image) : base(position, image)
        {
            this.FocusRestore = focusRestore;
        }

        public int FocusRestore { get; private set; }
    }
}
