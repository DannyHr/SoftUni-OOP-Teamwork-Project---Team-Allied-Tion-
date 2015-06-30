using Allied_Tion_Monogame_Test.Interfaces;

namespace Allied_Tion_Monogame_Test.Objects.Items
{
    public class Beer : Item, IFocusRestorable
    {
        private const int FocusRestoreValue = 40;

        public Beer(int topLeftX, int topLeftY)
            : base(BeerImage, topLeftX, topLeftY)
        {
            this.FocusRestore = FocusRestoreValue;
        }

        public int FocusRestore { get; private set; }

        //private int focusRestore = 40;

        //public Beer(Position position, string image)
        //    : base(position, image)
        //{
        //    this.FocusRestore = focusRestore;
        //}

        //public int FocusRestore { get; private set; }
    }
}
