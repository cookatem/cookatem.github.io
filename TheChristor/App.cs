using System;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using TheChristor.Core;
using TheChristor.Core.Settings;
using System.Windows.Forms;

namespace TheChristor {
    public partial class App : Form, IContentDisplayable<String> {
        private AppSettings settings;
        private readonly ITabManagable<String> tabManager;

        public App() {
            InitializeComponent();
            InitializeVisualApp();
            tabManager = new TabManager(TabsGroup, settings, this);
        }

        public void DisplayContent(String displayingContent) {
            TextField.Text = displayingContent;
        }


        private void InitializeVisualApp() {
            settings = new AppSettings (
                Color.FromArgb(30, 30, 30),
                Color.FromArgb(107, 124, 138),
                Color.FromArgb(164, 167, 176),
                Color.FromArgb(221, 221, 224),
                @"media/background.jpg"
            );
            
            TextField.BackColor = settings.MainColor;
            TextField.ForeColor = settings.FontColor;

            LocationField.ForeColor = settings.FontColor;
            TabsGroup.BackColor     = settings.SecondaryColor;
            MoreInfoPanel.BackColor = settings.SecondaryColor;
        }

        private void CopyContent(Object sender, EventArgs eventArgs) {
            TextField.Copy();
        }

        private void PasteContent(Object sender, EventArgs eventArgs) {
            TextField.Paste();
        }

        private void CutContent(Object sender, EventArgs eventArgs) {
            TextField.Cut();
        }

        private void SelectAllContent(Object sender, EventArgs eventArgs) {
            TextField.SelectAll();
        }

        private void RightClick(Object sender, MouseEventArgs eventArgs) {
            if (eventArgs.Button == MouseButtons.Right)
                TextField.ContextMenuStrip = this.FieldContextMenu;
        }


        private void TextFieldUpdate(Object sender, EventArgs eventArgs) {
            tabManager.SetContentToActiveTab(TextField.Text);
        }

        private void OpenContentFromFile(Object sender, EventArgs eventArgs) {
            tabManager.OpenContentToNewTab();
        }

        private void SaveContentToFile(Object sender, EventArgs eventArgs) {
            tabManager.SaveActiveTabContentToFile();
        }

        private void SaveContentToCurrentFile(Object sender, EventArgs eventArgs) {
            tabManager.SaveActiveTabContentToCurrentFile();
        }

        private void CloseContent(object sender, EventArgs eventArgs) {
            tabManager.CloseActiveTab();
        }

        private void AppSizeChanged(Object sender, EventArgs eventArgs) {
            tabManager.ResizeTabs();
        }

        private void NewEmptyFile(Object sender, EventArgs e) {
            tabManager.InitializeNewTab();
        }
    }
}