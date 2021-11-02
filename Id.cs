namespace Shared
{
    public class Id
    {
        private static int _nextNumber = 1;
        public int Number { get; } = 0;
        
        public Id()
        {
            Number = _nextNumber++;
        }
    }
}