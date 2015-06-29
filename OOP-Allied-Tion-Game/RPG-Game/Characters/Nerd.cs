using System;

namespace RPG.Characters
{
    public class Nerd : Character
    {
        private const int focus = 140;
        private const int energy = 60;
        public Nerd(Position position, string image, string name, int focus, int energy)
            : base(position, image, name, focus, energy)
        {
            this.Focus = focus;
            this.Focus = focus;
        }
        public int Focus { get; set; }
        public int Energy { get; set; }
    }
}
