namespace AlliedTionOOP.Objects.Creatures
{
    public class ExamBoss : Creature
    {
        private const int BossEnergy = 30;
        private const int BossFocus = 30;
        private const int BossExpToGive = 80;

        public ExamBoss(int topLeftX, int topLeftY)
            : base(ExamBossImage, topLeftX, topLeftY, BossEnergy, BossFocus, BossExpToGive)
        {
        }

        
        //private const int BossFocus = Bug.BugFocus + Exception.ExcFocus;
        //private const int BossEnergy = 30;
        //private const string BossImage = ""; // the image of the boss

        //    public ExamBoss(Position position, string name)
        //        : base(position,BossImage, name, BossFocus, BossEnergy)
        //    {
        //    }
    }
}
