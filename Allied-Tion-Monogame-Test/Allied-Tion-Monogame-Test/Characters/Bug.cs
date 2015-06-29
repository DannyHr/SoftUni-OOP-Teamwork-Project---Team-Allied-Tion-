namespace RPG.Characters
{
    public class Bug : Character
    {
        internal const int BugFocus = 30;
        private const int BugEnergy = 30;
        private const string Bygimage = ""; //the image of the bug

        public Bug(Position position, string name)
            : base(position, Bygimage,name, BugFocus, BugEnergy)
        {
        }
    }
}
