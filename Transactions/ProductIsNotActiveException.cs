namespace Stregsystem.Transactions
{
    [System.Serializable]
    public class ProductIsNotActiveException : System.Exception
    {
        public ProductIsNotActiveException() { }
        public ProductIsNotActiveException(string message) : base(message) { }
        public ProductIsNotActiveException(string message, System.Exception inner) : base(message, inner) { }
        protected ProductIsNotActiveException(
            System.Runtime.Serialization.SerializationInfo info,
            System.Runtime.Serialization.StreamingContext context) : base(info, context) { }
    }
}
