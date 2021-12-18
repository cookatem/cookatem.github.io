using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using TheChristor.Core.Settings;
using System.Windows.Forms;

namespace TheChristor.Core {
    internal class TabManager : ITabManagable<String> {
        private Tab activeTab;
        private readonly AppSettings settings;
        private readonly Panel tabManagerPanel;

        private readonly List<Tab> tabsElements;
        private readonly IContentDisplayable<String> displayer;

        public TabManager(Panel aTabGroup, AppSettings aSettings, IContentDisplayable<String> aDisplayer) {
            displayer = aDisplayer;
            settings = aSettings;
            tabManagerPanel = aTabGroup;

            tabsElements = new List<Tab>();
            InitializeNewTab();
        }

        public void CloseActiveTab() {
            activeTab.IsActive = false;
            tabManagerPanel.Controls.Remove(activeTab);
            tabsElements.Remove(activeTab);

            ResizeTabs();

            try {
                activeTab = tabsElements[tabsElements.Count - 1];
                activeTab.IsActive = true;
                displayer.DisplayContent(activeTab.TabContent);
            } catch (ArgumentOutOfRangeException) { InitializeNewTab(); }
        }

        public void OpenContentToNewTab() {
            Tab lastActiveTab = activeTab;
            if (lastActiveTab.FileName != default) {
                InitializeNewTab();
                ResizeTabs();
            }

            try { activeTab.SetContentByReceiver(); }
            catch (ArgumentException) {
                if (lastActiveTab.FileName == default) return;
                CloseActiveTab();
                ResizeTabs();
                return;
            }

            displayer.DisplayContent(activeTab.TabContent);
        }

        public void SaveActiveTabContentToFile() {
            activeTab.SaveContentBySender();
        }

        public void SaveActiveTabContentToCurrentFile() {
            activeTab.SaveCurrentContentBySender();
        }

        public void SetContentToActiveTab(String content) {
            activeTab.TabContent = content;
        }
        
        public void ResizeTabs() {
            Tab currentTab = null;
            foreach (Tab tab in tabsElements) {
                tab.Size = new Size(tabManagerPanel.Width / tabsElements.Count,
                    tabManagerPanel.Height);
                currentTab = tab;
            }

            if (currentTab is null) return;
            Int32 currentElementWidth = currentTab.Size.Width;
            if (currentElementWidth == 0) return;
            currentTab.Size = new Size(currentElementWidth + 
                (tabManagerPanel.Width % currentElementWidth),
                tabManagerPanel.Height);
        }

        public void InitializeNewTab() {
            IIntermeble<String> intermer = new FileDialoger();
            Tab newTab = new Tab(intermer);
            newTab.InitializeLabel(settings);
            newTab.Dock = DockStyle.Left;
            newTab.IsActive = true;
            newTab.Text = newTab.Title;
            newTab.Click += new EventHandler(this.TabOnclickEvent);

            tabsElements.Add(newTab);
            ResizeTabs();
            tabManagerPanel.Controls.Add(newTab);

            if (!(activeTab is null))
                activeTab.IsActive = false;

            activeTab = newTab;
            displayer.DisplayContent(activeTab.TabContent);
        }

        private void TabOnclickEvent(Object sender, EventArgs eventArgs) {
            if (!(sender is Tab eventTab)) return;

            activeTab.IsActive = false;
            activeTab = eventTab;
            activeTab.IsActive = true;
            displayer.DisplayContent(activeTab.TabContent);
        }
    }
}