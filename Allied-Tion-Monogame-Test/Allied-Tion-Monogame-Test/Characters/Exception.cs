namespace RPG.Characters
{
    public class Exception : Character
    {
            internal const int ExcFocus = 30;
            private const int ExcEnergy = 30;
            private const char ExcSym = 'E';

            public Exception(Position position, string name)
                : base(position,ExcSym, name, ExcFocus, ExcEnergy)
            {
            }
        }
    }
