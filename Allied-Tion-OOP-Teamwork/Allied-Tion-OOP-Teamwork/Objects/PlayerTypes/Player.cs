using System;
using System.Collections.Generic;
using Allied_Tion_Monogame_Test.Interfaces;
using Allied_Tion_Monogame_Test.Objects.Creatures;
using Allied_Tion_Monogame_Test.Objects.Items;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test.Objects.PlayerTypes
{
    public abstract class Player : Creature, ICollect, IExperienceEarnable, IHeal, ISpeed
    {
        private const int PlayerTopLeftX = 5;
        private const int PlayerTopLeftY = 5;
        private int levelUpExperience = 150; 

        private List<Item> inventory;

        protected Player(Texture2D image, int energy, int focus, int speed)
            : base(image, PlayerTopLeftX, PlayerTopLeftY, energy, focus, 0)
        {
            this.CurrentEnergy = energy;
            this.TotalEnergy = energy;
            this.TotalFocus = focus;
            this.CurrentFocus = focus;
            this.Experience = 0;
            this.CurrentLevel = 1;
            this.inventory = new List<Item>();
            this.Speed = new Point(speed, speed);
        }

        public Point Speed { get; set; }

        public IEnumerable<Item> Inventory
        {
            get { return this.inventory; }
        }

        public int Experience { get; set; }

        public int CurrentLevel { get; set; }

        public void AddItemToInventory(Item itemToAdd)
        {
            this.inventory.Add(itemToAdd);
        }

        public void LevelUp()
        {
            if (this.Experience >= this.levelUpExperience)
            {
                this.CurrentLevel++;
                this.levelUpExperience += 150;
                this.TotalFocus += 10;
                this.TotalEnergy += 10;
            }
        }

        public void GetFocus(Beer beer)
        {
            this.CurrentFocus = Math.Min(this.TotalFocus, this.CurrentFocus + beer.FocusRestore);
            this.inventory.Remove(beer);
        }

        public void DiskUpgrade(DiskUpgrade disk)
        {
            this.CurrentFocus = Math.Min(this.TotalFocus, this.CurrentFocus + disk.FocusIncrease);
            this.inventory.Remove(disk);
        }

        public void MemoryUpgrade(MemoryUpgrade memory)
        {
            this.CurrentFocus = Math.Min(this.TotalFocus, this.CurrentFocus + memory.FocusIncrease);
            this.inventory.Remove(memory);
        }

        public void NakovBook(NakovBook book)
        {
            this.CurrentFocus = Math.Min(this.TotalFocus, this.CurrentFocus + book.FocusIncrease);
            this.inventory.Remove(book);
        }

        public void GetEnergy(RedBull redbull)
        {
            this.CurrentFocus = Math.Min(this.TotalFocus, this.CurrentFocus + redbull.EnergyRestore);
            this.inventory.Remove(redbull);
        }

        public void Attack(Creature enemy)
        {

            int startFocus = this.CurrentFocus;
            int startEnergy = this.CurrentEnergy;
            this.CurrentEnergy -= enemy.CurrentEnergy;
            this.CurrentFocus -= enemy.CurrentFocus;
            enemy.CurrentFocus -= startFocus;
            enemy.CurrentEnergy -= startEnergy;
            if (enemy.CurrentFocus <= 0 || enemy.CurrentEnergy <= 0)
            {
                this.IsAlive = false;
            }
            this.Experience += enemy.ExperienceToGive;
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
        //    this.energy = energy;
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
        //public int energy
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
        //    enemy.Focus -= this.energy;
        //    student.Focus -= enemy.energy;
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
