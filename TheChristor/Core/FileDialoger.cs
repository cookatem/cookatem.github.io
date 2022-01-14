using System;
using System.IO;
using System.Windows.Forms;
using TheChristor.Core.Content;

namespace TheChristor.Core {
    internal class FileDialoger : IDataIntermeble<String> {
        public String Sendername   { get; set; }
        public String Receviername { get; set; }
        private readonly SaveFileDialog contentSaver;
        private readonly OpenFileDialog contentOpener;

        public FileDialoger() {
            Sendername    = String.Empty;
            Receviername  = String.Empty;
            contentSaver  = new SaveFileDialog();
            contentOpener = new OpenFileDialog();

            SetFiltersOnContentCarrier();
        }

        public void SendContent(String sendingData) {
            if (contentSaver.ShowDialog() == DialogResult.Cancel)
                throw new UserDialogIgnoreException();

            Sendername = contentSaver.FileName;
            File.WriteAllText(Sendername, sendingData);
        }

        public void SendCurrentContent(String sendingData) {
            if (!IsEmptyString(Sendername)  ) {
                try { File.WriteAllText(Sendername, sendingData); } catch (DirectoryNotFoundException) {
                    using (StreamWriter writer = File.CreateText(Sendername))
                        writer.Write(sendingData);
                }

                return;
            }
            if (!IsEmptyString(Receviername)) {
                try { File.WriteAllText(Receviername, sendingData); }
                catch (DirectoryNotFoundException) {
                    using (StreamWriter writer = File.CreateText(Receviername))
                        writer.Write(sendingData);
                }

                return;
            }

            throw new CurrentFileIsNotExistException();
        }

        public String ReceiveContent() {
            if (contentOpener.ShowDialog() == DialogResult.Cancel)
                throw new UserDialogIgnoreException();

            Receviername = contentOpener.FileName;
            return File.ReadAllText(Receviername);
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

        private static Boolean IsEmptyString(String text) => text == String.Empty || text == default;
    }
}