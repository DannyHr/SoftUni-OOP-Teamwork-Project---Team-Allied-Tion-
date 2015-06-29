using System;

namespace RPG.Characters
{
    public class NormalStudent : Character
    {
        private const int focus = 100;
        private const int energy = 100;
        public NormalStudent(Position position, string image, string name, int focus, int energy)
            : base(position, image, name, focus, energy)
        {
            this.Focus = focus;
            this.Focus = focus;
        }
        public int Focus { get; set; }
        public int Energy { get; set; }
    }
}
