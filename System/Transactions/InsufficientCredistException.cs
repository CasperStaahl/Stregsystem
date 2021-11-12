namespace Stregsystem.Transactions
{
    [System.Serializable]
    public class InsufficientCredistException : System.Exception
    {
        public InsufficientCredistException() { }
        public InsufficientCredistException(string message) : base(message) { }
        public InsufficientCredistException(string message, System.Exception inner) : base(message, inner) { }
        protected InsufficientCredistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
