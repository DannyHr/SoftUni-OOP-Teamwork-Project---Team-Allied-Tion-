using System.Collections.Generic;
using Allied_Tion_Monogame_Test.Objects.Items;

namespace Allied_Tion_Monogame_Test.Interfaces
{
    public interface ICollect
    {
        IEnumerable<Item> Inventory { get; }

        void AddItemToInventory(Item item);
    }
}
