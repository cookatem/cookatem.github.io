using System;
using System.Runtime.Serialization;
namespace TheChristor.Core {
    internal class CurrentFileIsNotExistException : Exception {
        public CurrentFileIsNotExistException() : base() {}
        public CurrentFileIsNotExistException(String message) : base(message) {}
        public CurrentFileIsNotExistException(String message, Exception innerException) : base(message, innerException) {}

        protected CurrentFileIsNotExistException(SerializationInfo info, StreamingContext streamingContext) : base(info, streamingContext) {}
        public override string ToString() => Message;
    }
}