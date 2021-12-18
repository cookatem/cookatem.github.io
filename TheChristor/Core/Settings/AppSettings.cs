using System;
using System.Drawing;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.IO;
using System.Windows.Forms;

namespace TheChristor.Core.Settings {
    internal class AppSettings {
        public readonly Color MainColor;
        public readonly Color FontColor;
        public readonly Color SecondaryColor;
        public readonly Color ColorOfDetails;
        public readonly Image Background;

        public AppSettings(Color mainColor, Color secondaryColor, Color colorOfDetails, Color fontColor, String BackgroundPath) {
            MainColor      = mainColor;
            FontColor      = fontColor;
            SecondaryColor = secondaryColor;
            ColorOfDetails = colorOfDetails;

            try { Background = Image.FromFile(BackgroundPath); }
            catch (FileNotFoundException) {}
        }
    }
}