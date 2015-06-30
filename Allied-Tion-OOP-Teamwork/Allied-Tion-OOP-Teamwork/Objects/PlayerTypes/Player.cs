using System;
using System.Collections.Generic;
using Allied_Tion_Monogame_Test.Interfaces;
using Allied_Tion_Monogame_Test.Objects.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test.Objects.PlayerTypes
{
    public abstract class Player : Object, IAttack, ICollect, IDestroyable, IExperienceEarnable, IHeal, IMoveable, ISpeed
    {
        private const int PlayerTopLeftX = 5;
        private const int PlayerTopLeftY = 5;

        private List<Item> inventory;

        protected Player(Texture2D image, int energy, int focus, int speed)
            : base(image, PlayerTopLeftX, PlayerTopLeftY)
        {
            this.Energy = energy;
            this.TotalFocus = focus;
            this.CurrentFocus = focus;
            this.Experience = 0;
            this.CurrentLevel = 1;
            this.inventory = new List<Item>();
            this.Speed = new Point(speed, speed);
        }


        public Point Speed { get; set; }

        public int Energy { get; private set; } // Damage

        public int TotalFocus { get; set; } // Total Health

        public int CurrentFocus { get; set; } // Current Health

        public IEnumerable<Item> Inventory
        {
            get { return this.inventory; }
        }

        public int Experience { get; set; }

        public int CurrentLevel { get; set; }

        public void Attack(IDestroyable enemy)
        {
            enemy.CurrentFocus -= this.Energy;
            //TODO: Check if enemy is dead
            throw new NotImplementedException();
        }

        public void AddItemToInventory(Item itemToAdd)
        {
            this.inventory.Add(itemToAdd);
        }

        public void LevelUp()
        {
            this.CurrentLevel++;
        }

        public void Heal(Beer beer)
        {
            //TODO
            throw new NotImplementedException();
        }

        public void Move(int assignToPositionX, int assignToPositionY)
        {
            base.TopLeftX += assignToPositionX;
            base.TopLeftY += assignToPositionY;
        }

        //private List<Items.Item> inventory;
        //private string name;
        //private int focus;
        //private int energy;

        //public Character(Position position, string image, string name, int focus, int energy, IEnumerable<Items.Item> inventory=null)
        //{
        //    this.Inventory = inventory;
        //    this.Name = name;
        //    this.Focus = focus;
        //    this.Energy = energy;
        //}

        //public IEnumerable<Items.Item> Inventory
        //{
        //    get { return this.inventory; }
        //    private set;
        //}


        //public int Focus
        //{
        //    get { return this.focus; }
        //    internal set;
        //}
        //public int Energy
        //{
        //    get { return this.energy; }
        //    internal set;
        //}

        //public string Name
        //{
        //    get { return this.name; }
        //    set
        //    {
        //        if (string.IsNullOrWhiteSpace(value))
        //        {
        //            throw new ArgumentNullException("name", "Name cannot be empty or null");
        //        }
        //        this.name = value;
        //    }
        //}

        //void Attack(Character enemy,Character student, Destroyable destroy)
        //{
        //    enemy.Focus -= this.Energy;
        //    student.Focus -= enemy.Energy;
        //    destroy = new Destroyable(Destroy); // Check explicitly if the health is <= 0...
        //    Destroy(Focus);
        //}

        //void Heal(Character student, Items.Beer beer)
        //{
        //    if (beer.ItemState == Items.ItemState.Collected)
        //    {
        //        student.Focus += beer.FocusRestore;
        //        this.inventory.Remove(beer);
        //    }

        //}
        //private delegate void Destroyable(int StudentFocus); //Delegate for the Destroy method
        //private void Destroy(int focus)
        //{
        //    this.Focus=focus;
        //    if(focus<=0)
        //    {
        //    //Game Over...
        //    }
        //}

        ////Some levelUp method??
    }
}
