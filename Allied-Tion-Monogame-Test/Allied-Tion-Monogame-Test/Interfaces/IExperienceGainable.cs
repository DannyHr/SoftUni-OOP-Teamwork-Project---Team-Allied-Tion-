namespace RPG.Interfaces
{
    public interface IExperienceGainable
    {
        public int Experience { get; set; }

        void LevelUp(int experience,int focus, int energy)
        {
            // Increasing Focus, Energy and decreasing experience to 0
            // When levelin up Base experience can be increased
            // Example: from 1 to 2 level - 0/100 experience, from 2-3 level - 0/150 etc.
        }

    }
}
