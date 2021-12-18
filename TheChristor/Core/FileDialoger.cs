using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TheChristor.Core {
    internal class FileDialoger : IIntermeble<String> {
        public String SenderName   { get; private set; }
        public String RecevierName { get; private set; }
        private readonly SaveFileDialog contentSaver;
        private readonly OpenFileDialog contentOpener;

        public FileDialoger() {
            SenderName    = default;
            RecevierName  = default;
            contentSaver  = new SaveFileDialog();
            contentOpener = new OpenFileDialog();

            SetFiltersOnContentCarrier();
        }

        public void SendContent(String savingData) {
            if (contentSaver.ShowDialog() == DialogResult.Cancel)
                throw new ArgumentNullException();

            SenderName = contentSaver.FileName;
            File.WriteAllText(SenderName, savingData);
        }

        public void SendCurrentContent(String savingData) {
            if (RecevierName != default) {
                File.WriteAllText(RecevierName, savingData);
                return;
            }

            if (SenderName   != default) {
                File.WriteAllText(SenderName, savingData);
                return;
            }

            throw new CurrentFileIsNotExistException();
        }

        public String ReceiveContent() {
            if (contentOpener.ShowDialog() == DialogResult.Cancel)
                throw new ArgumentNullException();

            RecevierName = contentOpener.FileName;
            return File.ReadAllText(RecevierName);
        }

        private void SetFiltersOnContentCarrier() {
            const String COMMON_FILTER =
                "Все файлы (*.*) | *.*|" +
                "Python files (*.py)|*.py|" +
                "Javascript files (*.js)|*.js|" +
                "C++ files (*.cpp)|*.cpp|" +
                "C# files (*.cs)|*.cs|" +
                "Text files (*.txt)|*.txt";

            contentSaver.Filter  = COMMON_FILTER;
            contentOpener.Filter = COMMON_FILTER;
        }
    }
}