using Allied_Tion_Monogame_Test.Interfaces;
using Microsoft.Xna.Framework.Graphics;

namespace Allied_Tion_Monogame_Test.Objects.Creatures
{
    public abstract class Creature : Object, IAttack, IDestroyable, IMoveable, IExperienceGiving
    {
        protected Creature(Texture2D image, int topLeftX, int topLeftY, int energy, int focus, int experienceToGive)
            : base(image, topLeftX, topLeftY)
        {
            this.Energy = energy;
            this.TotalFocus = focus;
            this.CurrentFocus = focus;
            this.ExperienceToGive = experienceToGive;
        }

        public int Energy { get; private set; } // Damage

        public int TotalFocus { get; set; }  // Total Health

        public int CurrentFocus { get; set; } // Current Health
        
        public int ExperienceToGive { get; private set; }

        public void Attack(IDestroyable enemy)
        {
            enemy.CurrentFocus -= this.Energy;
        }

        public void Move(int assignToPositionX, int assignToPositionY)
        {
            this.TopLeftX += assignToPositionX;
            this.TopLeftY += assignToPositionY;
        }

        
    }
}
