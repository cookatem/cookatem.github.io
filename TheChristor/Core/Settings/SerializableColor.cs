using System;
using System.Drawing;
namespace TheChristor.Core {
    [Serializable]
    public struct SerializableColor {
        public Int32 Red   { get; set; }
        public Int32 Green { get; set; }
        public Int32 Blue  { get; set; }
        public SerializableColor(Int32 red, Int32 green, Int32 blue) {
            Red = red;
            Green = green;
            Blue = blue;
        }

        public Color ToColor() => Color.FromArgb(Red, Green, Blue);
    }
}