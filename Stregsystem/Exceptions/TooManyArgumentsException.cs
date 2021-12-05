namespace Stregsystem
{
    [System.Serializable]
    public class TooManyArgumentsException : System.Exception
    {
        public TooManyArgumentsException() { }
        public TooManyArgumentsException(string message) : base(message) { }
        public TooManyArgumentsException(string message, System.Exception inner) : base(message, inner) { }
        protected TooManyArgumentsException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}