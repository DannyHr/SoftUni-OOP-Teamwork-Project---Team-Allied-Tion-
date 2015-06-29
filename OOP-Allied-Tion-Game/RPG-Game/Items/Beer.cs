namespace RPG.Items
{
    public class Beer : Item
    {
        private const int focusRestore = 40;

        public Beer(Position position, string image) : base(position, image)
        {
            this.FocusRestore = focusRestore;
        }

        public int FocusRestore { get;  set; }
    }
}
