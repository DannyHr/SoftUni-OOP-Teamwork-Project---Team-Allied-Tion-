namespace RPG.Items
{
    using RPG.Interfaces;

    public abstract class Item : GameObject, ISkin
    {
        protected Item(Position position, string image) : base(position) // image ne e string!
        {
            this.ItemState = ItemState.Available;
            this.Image = image;
        }

        public ItemState ItemState { get; set; }

        public string Image { get; set; }
    }
}
