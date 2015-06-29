namespace RPG.Interfaces
{
    public interface IDestroyable
    {
        IDestroyable(int health)
        {
            this.Health = health;
            //game over if the health is <= 0
            // ...
        }
        int Health { get; private set; }
    }
}
