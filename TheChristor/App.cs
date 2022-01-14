using System;
using TheChristor.Core;
using TheChristor.Core.Settings;
using System.Windows.Forms;
using TheChristor.Core.Content;

namespace TheChristor {
    public partial class App : Form, IContentDisplayer<String> {
        private readonly Configuration configuration;
        private readonly DeserializingTabManager<FileDialoger> tabManager;

        public App() {
            InitializeComponent();
            configuration = new Configuration(true);
            InitializeVisual();
            tabManager = new DeserializingTabManager<FileDialoger>(TabsGroup, configuration) {
                Displayer = this
            };

            Size = configuration.Size;
            StartPosition = FormStartPosition.Manual;
            Location = configuration.Location;
            this.Closing += (sender, eventArgs) => {
                configuration.Size = Size;
                configuration.Location = Location;
                configuration.SerializeSelf();
                tabManager.SerializeTabs();
            };
        }

        public void DisplayContent(String displayingContent) => TextField.Text = displayingContent;

        private void InitializeVisual() {
            TextField.BackColor = configuration.MainColor.ToColor();
            TextField.ForeColor = configuration.FontColor.ToColor();
            LocationField.ForeColor = configuration.FontColor.ToColor();
            TabsGroup.BackColor = configuration.MainColor.ToColor();
            MoreInfoPanel.BackColor = configuration.SecondaryColor.ToColor();
        }

        private void CloseContent(Object sender, EventArgs eventArgs) => tabManager.CloseActiveTab();

        private void AppSizeChanged(Object sender, EventArgs eventArgs) => tabManager.ResizeTabs();

        private void NewEmptyFile(Object sender, EventArgs e) => tabManager.CreateNewTab();

        private void TextFieldUpdate(Object sender, EventArgs eventArgs) => tabManager.ActiveTab.Info.TabContent = TextField.Text;

        private void OpenContentFromFile(Object sender, EventArgs eventArgs) => tabManager.OpenContentToNewTab();

        private void SaveContentToCurrentFile(Object sender, EventArgs eventArgs) => tabManager.SaveActiveTabContentToFile();

        private void SaveContentToFile(Object sender, EventArgs eventArgs) => tabManager.SaveActiveTabContentToCurrentFile();


        private void RightClick(Object sender, MouseEventArgs eventArgs) {
            if (eventArgs.Button == MouseButtons.Right)
                TextField.ContextMenuStrip = this.FieldContextMenu;
        }

        private void CopyContent(Object sender, EventArgs eventArgs) => TextField.Copy();

        private void PasteContent(Object sender, EventArgs eventArgs) => TextField.Paste();

        private void CutContent(Object sender, EventArgs eventArgs) => TextField.Cut();

        private void SelectAllContent(Object sender, EventArgs eventArgs) => TextField.SelectAll();
    }
}