namespace Stregsystem
{
    [System.Serializable]
    public class ProductDoesNotExistException : System.Exception
    {
        public ProductDoesNotExistException() { }
        public ProductDoesNotExistException(string message) : base(message) { }
        public ProductDoesNotExistException(string message, System.Exception inner) : base(message, inner) { }
        protected ProductDoesNotExistException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}