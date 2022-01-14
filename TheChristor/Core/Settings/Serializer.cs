using System;
using System.IO;
using System.Xml.Serialization;

namespace TheChristor.Core.Settings {
    [Serializable]
    public abstract class Serializer<Type> {
        protected abstract String StreamName { get; }
        public Serializer() {}
        public Serializer(Boolean isDeserialize) {
            if (isDeserialize) {
                try { DeserializeSelf(); }
                catch (InvalidOperationException) { SerializeSelf(); }
            }
        }
        public void SerializeSelf() {
            XmlSerializer serializer = new XmlSerializer(typeof(Type));
            try { File.WriteAllText(StreamName, String.Empty); } catch {}
            using (FileStream stream = new FileStream(StreamName, FileMode.OpenOrCreate)) 
                serializer.Serialize(stream, this);
        }

        protected void DeserializeSelf() {
            XmlSerializer deserializer = new XmlSerializer(typeof(Type));
            using (FileStream stream = new FileStream(StreamName, FileMode.OpenOrCreate)) {
                Type deserializedObject = (Type)deserializer.Deserialize(stream);
                SetValuesByDeserializeObject(deserializedObject);
            }
        }

        protected abstract void SetValuesByDeserializeObject(Type deserializedObject);
    }
}