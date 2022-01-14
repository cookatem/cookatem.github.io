using System;
using System.Runtime.Serialization;
namespace TheChristor.Core.Content {
    internal class ActiveTabIsNotExistException : Exception {
        public ActiveTabIsNotExistException() : base() {}
        public ActiveTabIsNotExistException(String message) : base(message) {}
        public ActiveTabIsNotExistException(String message, Exception innerException) : base(message, innerException) {}

        protected ActiveTabIsNotExistException(SerializationInfo info, StreamingContext streamingContext) : base(info, streamingContext) {}
        public override String ToString() => Message;
    }
}