using System;
using System.Runtime.Serialization;
namespace TheChristor.Core {
    internal class UserDialogIgnoreException : Exception {
        public UserDialogIgnoreException() : base() {}
        public UserDialogIgnoreException(String message) : base(message) {}
        public UserDialogIgnoreException(String message, Exception innerException) : base(message, innerException) {}

        protected UserDialogIgnoreException(SerializationInfo info, StreamingContext streamingContext) : base(info, streamingContext) {}
        public override String ToString() => Message;
    }
}