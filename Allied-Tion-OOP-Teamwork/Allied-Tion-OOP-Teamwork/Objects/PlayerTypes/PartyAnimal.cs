namespace Allied_Tion_Monogame_Test.Objects.PlayerTypes
{
    public class PartyAnimal : Player
    {
        private const int PartyFocus = 60;
        private const int PartyEnergy = 140;
        private const int PartySpeed = 3;

        public PartyAnimal()
            : base(PlayerPartySkin, PartyEnergy, PartyFocus, PartySpeed)
        {
        }


        //private const int focus = 60;
        //private const int energy = 140;
        //public PartyAnimal(Position position, string image, string name, int focus, int energy)
        //    : base(position, image, name, focus, energy)
        //{
        //    this.Focus = focus;
        //    this.Focus = focus;
        //}
        //public int Focus { get; set; }
        //public int Energy { get; set; }
    }
}
