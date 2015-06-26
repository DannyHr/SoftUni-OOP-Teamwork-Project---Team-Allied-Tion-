namespace RPG
{
    using System;
    using Interfaces;
    using Exceptions;

    public abstract class GameObject : IMoveable
    {
        private Position position;

        protected GameObject(Position position)
        {
            this.Position = position;
        }

        public Position Position
        {
            get
            {
                return this.position;
            }
            set
            {
                if (value.X < 0 || value.Y < 0)
                {
                    throw new ObjectOutOfMapException("Specified object position is outside the map.");
                }
                this.position = value;
            }
        }

        public virtual void Move()
        {
        }
    }
}
