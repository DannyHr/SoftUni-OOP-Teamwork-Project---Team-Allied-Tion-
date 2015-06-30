namespace Allied_Tion_Monogame_Test.Interfaces
{
    public interface IAttack
    {
        void Attack(IDestroyable enemy);

        int CurrentEnergy { get; }
    }
}
