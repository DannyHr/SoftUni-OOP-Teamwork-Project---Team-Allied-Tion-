namespace RPG.Characters.PlayerTypes
{
    public class PartyAnimal : Character
    {
        private const int focus = 60;
        private const int energy = 140;
        public PartyAnimal(Position position, string image, string name, int focus, int energy)
            : base(position, image, name, focus, energy)
        {
            this.Focus = focus;
            this.Focus = focus;
        }
        public int Focus { get; set; }
        public int Energy { get; set; }
    }
}
