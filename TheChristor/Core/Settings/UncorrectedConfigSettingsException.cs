using System;
using System.Runtime.Serialization;

namespace TheChristor.Core.Settings {
    internal class UncorrectedConfigSettingsException : Exception {
        public UncorrectedConfigSettingsException() : base() { }
        public UncorrectedConfigSettingsException(String message) : base(message) { }
        public UncorrectedConfigSettingsException(String message, Exception innerException) : base(message, innerException) { }

        protected UncorrectedConfigSettingsException(SerializationInfo info, StreamingContext streamingContext) : base(info, streamingContext) { }

        public override string ToString() {
            return this.Message;
        }
    }
}