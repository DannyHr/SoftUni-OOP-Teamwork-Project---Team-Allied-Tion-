namespace RPG.Characters
{
    public class ExamBoss : Character
    {
        private const int BossFocus = Bug.BugFocus + Exception.ExcFocus;
        private const int BossEnergy = 30;
        private const string BossImage = ""; // the image of the boss

            public ExamBoss(Position position, string name)
                : base(position,BossImage, name, BossFocus, BossEnergy)
            {
            }
    }
}
