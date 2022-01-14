using System;
using System.Drawing;
namespace TheChristor.Core.Settings {
    [Serializable]
    public sealed class Configuration : Serializer<Configuration> {
        #region Stream Name
        protected override string StreamName { get; } = "config.xml";
        #endregion
        public Configuration() {
            FontColor = new SerializableColor(221, 221, 224);
            MainColor = new SerializableColor(30, 30, 30);
            SecondaryColor = new SerializableColor(107, 124, 138);
            ColorOfDetails = new SerializableColor(164, 167, 176);
            Size = new Size(1200, 600);
            Location = new Point(100, 200);
        }
        public Configuration(Boolean isDeserialize) : base(isDeserialize) {}
        public SerializableColor MainColor { get; set; } = new SerializableColor(30, 30, 30);
        public SerializableColor FontColor { get; set; } = new SerializableColor(221, 221, 224);
        public SerializableColor SecondaryColor { get; set; } = new SerializableColor(107, 124, 138);
        public SerializableColor ColorOfDetails { get; set; } = new SerializableColor(164, 167, 176);
        public Size Size { get; set; } = new Size(1200, 600);
        public Point Location { get; set; } = new Point(100, 200);

        protected override void SetValuesByDeserializeObject(Configuration deserializedObject) {
            MainColor = deserializedObject.MainColor;
            FontColor = deserializedObject.FontColor;
            SecondaryColor = deserializedObject.SecondaryColor;
            ColorOfDetails = deserializedObject.ColorOfDetails;
            Size = deserializedObject.Size;
            Location = deserializedObject.Location;
        }
    }
}