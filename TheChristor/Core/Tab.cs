using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheChristor.Core.Settings;

namespace TheChristor.Core {
    internal class Tab : Label, IComparable<Tab> {
        public String  Title      { get; private set; }
        public String  FileName   { get; private set; }
        public String  TabContent { get; set; }
        public Boolean IsActive {
            get { return isActiveTab; }
            set { 
                isActiveTab = value;
                if (appSettings is null)
                    throw new ArgumentNullException();

                ToggleTabStatus();
            }
        }

        private AppSettings appSettings;
        private ISendable<String> contentSender;
        private IReceivable<String> contentReceiver;
        private Boolean isActiveTab;

        public Tab(IIntermeble<String> aContentIntermer) {
            InitializeComponents(aContentIntermer, aContentIntermer);
        }

        public Tab(ISendable<String> aContentSaver, IReceivable<String> aContentOpener) {
            InitializeComponents(aContentOpener, aContentSaver);
        }

        private void InitializeComponents(IReceivable<String> aReceiver, ISendable<String> aSender) {
            #region
            Title = "nameless.txt";
            #endregion
            isActiveTab     = false;
            contentSender   = aSender;
            contentReceiver = aReceiver;
            FileName        = default;
            TabContent      = default;
        }

        public void SaveContentBySender() {
            try { contentSender.SendContent(TabContent); } 
            catch (ArgumentNullException) { return; }

            FileName = contentSender.SenderName;
            SetTitleByFileName();
        }

        public void SaveCurrentContentBySender() {
            try { contentSender.SendCurrentContent(TabContent); }
            catch (CurrentFileIsNotExistException) { SaveContentBySender(); }
        }

        public void SetContentByReceiver() {
            String content;
            content = contentReceiver.ReceiveContent();

            FileName = contentReceiver.RecevierName;
            TabContent = content;
            SetTitleByFileName();
        }

        public void InitializeLabel(AppSettings aSettings) {
            appSettings = aSettings;

            AutoSize = false;
            Font = new Font("Consolas", 10.5f);
            TextAlign = ContentAlignment.MiddleCenter;

            Text = Title;
            IsActive = isActiveTab;
            Padding = new Padding(0, 0, 0, 0);
            Margin  = new Padding(0, 0, 0, 0);
        }

        public int CompareTo(Tab comparingElement) {
           if (comparingElement is null) return -1;

           if (this.TabContent.Length < comparingElement.TabContent.Length) return -1;
           if (this.TabContent.Length > comparingElement.TabContent.Length) return 1;

           if (this.IsActive == comparingElement.IsActive) return 0;
           return -1;
        }

        private void ToggleTabStatus() {
            if (IsActive) ActiveTab();
            else InactiveTab();
        }

        private void ActiveTab() {
            BackColor = appSettings.MainColor;
            ForeColor = appSettings.FontColor;
        }

        private void InactiveTab() {
            BackColor = appSettings.ColorOfDetails;
            ForeColor = appSettings.MainColor;
        }

        private void SetTitleByFileName() {
            Int32 indexOfFileName = FileName.LastIndexOf('\\');
            if (indexOfFileName == -1) return;
            Title = FileName.Substring(indexOfFileName + 1);
            Text = Title;
        }
    }
}