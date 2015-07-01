using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AlliedTionOOP.Objects.Items;
using AlliedTionOOP.Objects.PlayerTypes;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;

namespace AlliedTionOOP.GUI
{
    public static class InventoryBar
    {
        public static void DrawInventory(Player player, SpriteBatch spriteBatch, ContentManager content)
        {
            Texture2D beer = content.Load<Texture2D>("GUI/Inventory/block-beer");
            Texture2D noBeer = content.Load<Texture2D>("GUI/Inventory/block-nobeer");
            Vector2 beerPosition = new Vector2(400, 650);

            Texture2D redbull = content.Load<Texture2D>("GUI/Inventory/block-redbull");
            Texture2D noRedbull = content.Load<Texture2D>("GUI/Inventory/block-noredbull");
            Vector2 redbullPosition = new Vector2(450, 650);
            
            Texture2D ram = content.Load<Texture2D>("GUI/Inventory/block-ram");
            Texture2D noRam = content.Load<Texture2D>("GUI/Inventory/block-noram");
            Vector2 ramPosition = new Vector2(500, 650);

            Texture2D hdd = content.Load<Texture2D>("GUI/Inventory/block-hdd");
            Texture2D noHdd = content.Load<Texture2D>("GUI/Inventory/block-nohdd");
            Vector2 hddPosition = new Vector2(550, 650);

            Texture2D cpu = content.Load<Texture2D>("GUI/Inventory/block-cpu");
            Texture2D noCpu = content.Load<Texture2D>("GUI/Inventory/block-nocpu");
            Vector2 cpuPosition = new Vector2(600, 650);

            Texture2D book = content.Load<Texture2D>("GUI/Inventory/block-book");
            Texture2D noBook = content.Load<Texture2D>("GUI/Inventory/block-nobook");
            Vector2 bookPosition = new Vector2(700, 650);

            Texture2D resharper = content.Load<Texture2D>("GUI/Inventory/block-resharper");
            Texture2D noResharper = content.Load<Texture2D>("GUI/Inventory/block-noresharper");
            Vector2 resharperPosition = new Vector2(750, 650);

            if (player.Inventory.Any(x => x is Beer))
            {
                spriteBatch.Draw(beer, beerPosition);
            }
            else
            {
                spriteBatch.Draw(noBeer, beerPosition);
            }

            if (player.Inventory.Any(x => x is RedBull))
            {
                spriteBatch.Draw(redbull, redbullPosition);
            }
            else
            {
                spriteBatch.Draw(noRedbull, redbullPosition);
            }

            if (player.Inventory.Any(x => x is MemoryUpgrade))
            {
                spriteBatch.Draw(ram, ramPosition);
            }
            else
            {
                spriteBatch.Draw(noRam, ramPosition);
            }

            if (player.Inventory.Any(x => x is DiskUpgrade))
            {
                spriteBatch.Draw(hdd, hddPosition);
            }
            else
            {
                spriteBatch.Draw(noHdd, hddPosition);
            }

            if (player.Inventory.Any(x => x is ProcessorUpgrade))
            {
                spriteBatch.Draw(cpu, cpuPosition);
            }
            else
            {
                spriteBatch.Draw(noCpu, cpuPosition);
            }

            if (player.Inventory.Any(x => x is NakovBook))
            {
                spriteBatch.Draw(book, bookPosition);
            }
            else
            {
                spriteBatch.Draw(noBook, bookPosition);
            }

            if (player.Inventory.Any(x => x is Resharper))
            {
                spriteBatch.Draw(resharper, resharperPosition);
            }
            else
            {
                spriteBatch.Draw(noResharper, resharperPosition);
            }
        }
    }
}
