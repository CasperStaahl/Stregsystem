namespace Stregsystem
{
    [System.Serializable]
    public class UserDoesNotExistException : System.Exception
    {
        public UserDoesNotExistException() { }
        public UserDoesNotExistException(string message) : base(message) { }
        public UserDoesNotExistException(string message, System.Exception inner) : base(message, inner) { }
        protected UserDoesNotExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}