using RPG.Characters;
namespace RPG.Interfaces
{
    public interface IAttack
    {
        void Attack(Character enemy);

        int Damage { get; }
    }
}
