namespace AlliedTionOOP.Interfaces
{
    public interface IAttack
    {
        void Attack(IDestroyable enemy);

        int CurrentEnergy { get; }
    }
}
