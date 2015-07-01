using AlliedTionOOP.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace AlliedTionOOP.Objects.Creatures
{
    public abstract class Creature : Object, IDestroyable, IMoveable, IExperienceGiving
    {
        private bool isAlive;

        protected Creature(Texture2D image, int topLeftX, int topLeftY, int energy, int focus, int experienceToGive)
            : base(image, topLeftX, topLeftY)
        {
            this.CurrentEnergy = energy;
            this.TotalEnergy = energy;
            this.TotalFocus = focus;
            this.CurrentFocus = focus;
            this.ExperienceToGive = experienceToGive;
            this.IsAlive = true;
        }

        public bool IsAlive
        {
            get { return CurrentFocus > 0; }
            set { this.isAlive = value; }
        }

        public int TotalEnergy { get; set; } // Total Damage

        public int CurrentEnergy { get; set; } // Damage

        public int TotalFocus { get; set; }  // Total Health

        public int CurrentFocus { get; set; } // Current Health
        
        public int ExperienceToGive { get; private set; }

        public void Move(int assignToPositionX, int assignToPositionY)
        {
            this.TopLeftX += assignToPositionX;
            this.TopLeftY += assignToPositionY;
        }
    }
}
