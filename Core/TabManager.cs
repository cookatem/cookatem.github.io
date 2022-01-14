using System;
using System.Collections.Generic;
using System.Drawing;
using TheChristor.Core.Settings;
using System.Windows.Forms;
using TheChristor.Core.Content;

namespace TheChristor.Core {
    internal class TabManager<DataIntermebleT> : ITabManager
            where DataIntermebleT : IDataIntermeble<String>, new() {

        private Tab activeTab;
        private readonly Configuration configuration;
        private readonly Control visualRepresentation;
        private IContentDisplayer<String> displayer;
        public TabManager(Control visualRepresentation, Configuration configuration) {
            this.configuration = configuration;
            this.visualRepresentation = visualRepresentation;
            Tabs = new List<Tab>();
            TabToggle = (sender, eventArgs) => { };
        }

        public Tab ActiveTab {
            get => activeTab;
            protected set {
                if (value is null)
                    throw new ArgumentNullException(nameof(ActiveTab));

                if (ActiveTab != null)
                    ActiveTab.IsActive = false;

                activeTab = value;
                ActiveTab.IsActive = true;
                DisplayActiveTabContent();
            }
        }
        public IList<Tab> Tabs { get; private set; }
        public IContentDisplayer<String> Displayer {
            get => displayer;
            set {
                if (value is null)
                    throw new ArgumentNullException(nameof(Displayer));
                displayer = value;
                DisplayActiveTabContent();
            }
        }
        public EventHandler<TabEventArgs> TabToggle;

        public void CloseActiveTab() {
            if (ActiveTab is null)
                throw new ActiveTabIsNotExistException(nameof(ActiveTab));

            if (Tabs.Count == 0) CreateNewTab();
            else if (Tabs.Count == 1) {
                CloseTab(ActiveTab);
                CreateNewTab();
            }

            else if (Tabs.Count > 1) CloseTab(ActiveTab);
        }

        public void OpenContentToNewTab() {
            if (ActiveTab is null)
                throw new ActiveTabIsNotExistException(nameof(ActiveTab));

            Boolean isEmptyTab = false;
            if (ActiveTab.IsEmpty) {
                TabInfo tabInfo = ActiveTab.Info;
                CloseTab(ActiveTab);
                CreateNewTab();
                ActiveTab.Info = tabInfo;
                DisplayActiveTabContent();
                isEmptyTab = true;
            }
            
            else CreateNewTab();
            if (!ActiveTab.ReceiveContentByReceiver()) {
                if (isEmptyTab) return;
                CloseActiveTab();
            } else DisplayActiveTabContent();
        }

        public void SaveActiveTabContentToFile() {
            if (ActiveTab is null) 
                throw new ActiveTabIsNotExistException(nameof(ActiveTab));

            ActiveTab.SendContentBySender();
        }

        public void SaveActiveTabContentToCurrentFile() { 
            if (ActiveTab is null)
                throw new ActiveTabIsNotExistException(nameof(ActiveTab));

            ActiveTab.SendContentByCurrentSender();
        }

        public void ResizeTabs() {
            Tab currentTab = null;
            foreach (Tab tab in Tabs) {
                tab.Size = new Size(visualRepresentation.Width / Tabs.Count,
                    visualRepresentation.Height);
                currentTab = tab;
            }

            if (currentTab is null) return;
            Int32 currentElementWidth = currentTab.Size.Width;
            if (currentElementWidth == 0) return;
            currentTab.Size = new Size(currentElementWidth +
                (visualRepresentation.Width % currentElementWidth),
                visualRepresentation.Height);
        }

        public Tab CreateNewTab() {
            DataIntermebleT intermer = new DataIntermebleT();
            Tab newTab = new Tab(intermer);
            InitializeTab(newTab);
            newTab.IsActive = true;

            AddTabToCollections(newTab);

            ResizeTabs();
            ActiveTab = newTab;
            return ActiveTab;
        }

        public void DisplayActiveTabContent() {
            if (Displayer is null) return;
            if (ActiveTab is null) throw new ActiveTabIsNotExistException(nameof(ActiveTab));

            Displayer.DisplayContent(ActiveTab.Info.TabContent);
        }

        private void HandTabClickEvent(Object sender, EventArgs eventArgs) {
            if (!(sender is Tab eventTab)) return;
            TabToggle(this, new TabEventArgs(eventTab, ActiveTab));
            ActiveTab = eventTab;
        }

        private void InitializeTab(Tab noninitializedTab) {
            noninitializedTab.Settings = configuration;
            noninitializedTab.Dock = DockStyle.Left;
            noninitializedTab.Text = noninitializedTab.Info.Title;
            noninitializedTab.Click += HandTabClickEvent;
        }

        private void AddTabToCollections(Tab addingTab) {
            Tabs.Add(addingTab);
            visualRepresentation.Controls.Add(addingTab);
        }

        private void RemoveTabFromCollections(Tab removingTab) {
            Tabs.Remove(removingTab);
            visualRepresentation.Controls.Remove(removingTab);
        }

        private void CloseTab(Tab closingTab) {
            closingTab.IsActive = false;
            RemoveTabFromCollections(closingTab);
            ResizeTabs();
            if (Tabs.Count - 1 < 0) return;
            ActiveTab = Tabs[Tabs.Count - 1];
            ActiveTab.IsActive = true;
            DisplayActiveTabContent();
        }
    }
}