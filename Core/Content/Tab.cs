using System;
using System.Drawing;
using System.Windows.Forms;
using TheChristor.Core.Settings;

namespace TheChristor.Core.Content {
    internal class Tab : Label {
        private Boolean isActive;
        private TabInfo tabInfo;
        private Configuration appSettings;
        private ISendable<String> contentSender;
        private IReceivable<String> contentReceiver;

        public Tab(IDataIntermeble<String> contentIntermeble) =>
            InitializeComponents(contentIntermeble, contentIntermeble);

        public Tab(ISendable<String> contentSender, IReceivable<String> contentReceiver) =>
            InitializeComponents(contentReceiver, contentSender);

        private void InitializeComponents(IReceivable<String> contentReceiver, ISendable<String> contentSender) {
            this.contentSender = contentSender;
            this.contentReceiver = contentReceiver;
            Info = new TabInfo();
            InitializeLabel();
        }

        public TabInfo Info {
            get => tabInfo;
            set {
                if (value is null)
                    throw new ArgumentNullException(nameof(Info));
                tabInfo = value;
                if (contentSender != null) contentSender.Sendername = tabInfo.Filename;
                if (contentReceiver != null) contentReceiver.Receviername = tabInfo.Filename;
                Text = tabInfo.Title;
                tabInfo.IsActive = isActive;
                if (Settings is null) isActive = tabInfo.IsActive;
                else IsActive = isActive;
            }
        }
        public Boolean IsActive {
            get { return isActive; }
            set {
                isActive = value;
                if (Settings is null)
                    throw new NotSupportedException(nameof(Settings));
                if (Info != null) Info.IsActive = value;
                
                ToggleTabStatus();
            }
        }
        public Boolean IsEmpty  
            { get => IsEmptyString(Info.Filename); }
        public Configuration Settings {
            get => appSettings;
            set {
                if (value is null)
                    throw new ArgumentNullException(nameof(Settings));
                appSettings = value;
                IsActive = isActive;
            }
        }

        public Boolean SendContentBySender() {
            try { contentSender.SendContent(Info.TabContent); }
            catch (UserDialogIgnoreException) { return false; }
            Info.Filename = contentSender.Sendername;
            GetTitleByFileName();
            return true;
        }

        public Boolean SendContentByCurrentSender() {
            try { contentSender.SendCurrentContent(Info.TabContent); }
            catch (CurrentFileIsNotExistException) { SendContentBySender(); return false; }
            return true;
        }

        public Boolean ReceiveContentByReceiver() {
            String content;
            try { content = contentReceiver.ReceiveContent(); }
            catch (UserDialogIgnoreException) { return false; }
            Info.Filename = contentReceiver.Receviername;
            Info.TabContent = content;
            GetTitleByFileName();
            return true;
        }


        private void InitializeLabel() {
            #region Tab Settings
            AutoSize = false;
            Font = new Font("Consolas", 10.5f);
            TextAlign = ContentAlignment.MiddleCenter;
            Padding = new Padding(0, 0, 0, 0);
            Margin = new Padding(0, 0, 0, 0);
            #endregion
            this.MouseEnter += (Object sender, EventArgs eventArgs) => {
                if (!(sender is Tab tab) || Settings is null) return;
                LightTab(tab);
            };
            this.MouseLeave += (Object sender, EventArgs eventArgs) => {
                if (!(sender is Tab tab) || Settings is null) return;
                ShadowTab(tab);
            };
            Text = Info?.Title;
            if (Settings != null) IsActive = Info.IsActive;
        }

        private void ToggleTabStatus() {
            if (IsActive) ActiveTab();
            else InactiveTab();
        }

        private void ActiveTab() {
            BackColor = appSettings.MainColor.ToColor();
            ForeColor = appSettings.FontColor.ToColor();
            LightTab(this);
        }

        private void InactiveTab() {
            BackColor = appSettings.ColorOfDetails.ToColor();
            ForeColor = appSettings.MainColor.ToColor();
        }

        private void GetTitleByFileName() {
            Int32 indexOfFileName = Info.Filename.LastIndexOf('\\');
            if (indexOfFileName == -1)
                return;
            Info.Title = Info.Filename.Substring(indexOfFileName + 1);
            Text = Info.Title;
        }

        private static void LightTab(Tab tab) {
            const Int32 LIGHT_DEGREE = 15;
            tab.BackColor = Color.FromArgb(
                tab.BackColor.R >= 255 - LIGHT_DEGREE ? 255 : tab.BackColor.R + LIGHT_DEGREE,
                tab.BackColor.G >= 255 - LIGHT_DEGREE ? 255 : tab.BackColor.G + LIGHT_DEGREE,
                tab.BackColor.B >= 255 - LIGHT_DEGREE ? 255 : tab.BackColor.B + LIGHT_DEGREE);
        }

        private static void ShadowTab(Tab tab) {
            const Int32 SHADOW_DEGREE = 15;
            tab.BackColor = Color.FromArgb(
                tab.BackColor.R <= SHADOW_DEGREE ? 0 : tab.BackColor.R - SHADOW_DEGREE,
                tab.BackColor.G <= SHADOW_DEGREE ? 0 : tab.BackColor.G - SHADOW_DEGREE,
                tab.BackColor.B <= SHADOW_DEGREE ? 0 : tab.BackColor.B - SHADOW_DEGREE);
        }

        private static Boolean IsEmptyString(String text)
            => text == default || text == String.Empty;
    }
}