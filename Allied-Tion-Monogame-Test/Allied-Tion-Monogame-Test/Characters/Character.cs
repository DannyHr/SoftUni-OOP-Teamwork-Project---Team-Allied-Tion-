namespace RPG.Characters
{
    using System;
    using RPG.Interfaces;
    using System.Collections.Generic;

    public abstract class Character : GameObject, ICharacter
    {
        private List<Items.Item> inventory;
        private string name;
        private int focus;
        private int energy;

        public Character(Position position, string image, string name, int focus, int energy, IEnumerable<Items.Item> inventory=null)
        {
            this.Inventory = inventory;
            this.Name = name;
            this.Focus = focus;
            this.Energy = energy;
        }

        public IEnumerable<Items.Item> Inventory
        {
            get { return this.inventory; }
            private set;
        }


        public int Focus
        {
            get { return this.Focus; }
            internal set;
        }
        public int Energy
        {
            get { return this.Energy; }
            internal set;
        }

        public string Name
        {
            get { return this.name; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                {
                    throw new ArgumentNullException("name", "Name cannot be empty or null");
                }
                this.name = value;
            }
        }

        void Attack(Character enemy,Character student, Destroyable destroy)
        {
            enemy.Focus -= this.Energy;
            student.Focus -= enemy.Energy;
            destroy = new Destroyable(Destroy); // Check explicitly if the health is <= 0...
            Destroy(Focus);
        }

        void Heal(Character student, Items.Beer beer)
        {
            if (beer.ItemState == Items.ItemState.Collected)
            {
                student.Focus += beer.FocusRestore;
                this.inventory.Remove(beer);
            }
            
        }
        private delegate void Destroyable(int StudentFocus); //Delegate for the Destroy method
        private void Destroy(int focus)
        {
            this.Focus=focus;
            if(focus<=0)
            {
            //Game Over...
            }
        }
        
        //Some levelUp method??

    }
}
