namespace Stregsystem.Shared
{
    public class Id<T> 
    {
        private static int _nextNumber = 1;
        public int Number { get; } = 0;

        public Id()
        {
            Number = _nextNumber++;
        }
    }
}