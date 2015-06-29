namespace RPG.Interfaces
{
    using RPG.Items;
    using System.Collections.Generic;

    public interface ICollect
    {
        IEnumerable<Item> Inventory { get; }

        void AddItemToInventory(Item item);
    }
}
