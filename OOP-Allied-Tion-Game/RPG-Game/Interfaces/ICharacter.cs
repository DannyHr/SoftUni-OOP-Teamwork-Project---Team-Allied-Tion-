namespace RPG.Interfaces
{
    public interface ICharacter : IAttack, IDestroyable, IHeal, ICollect, IExperienceGainable
    {
        Position Position { get; }

        string Name { get; }


    }
}
