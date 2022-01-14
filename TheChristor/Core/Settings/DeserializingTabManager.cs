using System;
using System.Windows.Forms;
using TheChristor.Core.Content;
namespace TheChristor.Core.Settings {
    internal class DeserializingTabManager<DataIntermebleT> : TabManager<DataIntermebleT>
        where DataIntermebleT : IDataIntermeble<String>, new() {
        public readonly TabSerializer tabSerializer;
        public DeserializingTabManager(Control visualRepresentation, Configuration configuration)
            : base(visualRepresentation, configuration) {

            tabSerializer = new TabSerializer(true);
            DeserializeTabs();
        }

        public void SerializeTabs() {
            if (tabSerializer is null)
                throw new InvalidOperationException(nameof(tabSerializer));

            tabSerializer.Tabs.Clear();
            foreach (Tab tab in Tabs) 
                tabSerializer.Tabs.Add(tab.Info);

            tabSerializer.SerializeSelf();
        }

        private void DeserializeTabs() {
            if (tabSerializer is null)
                throw new InvalidOperationException(nameof(tabSerializer));

            Tab activeTab = null;
            Tab currentTab = null;
            foreach (TabInfo tabInfo in tabSerializer.Tabs) {
                currentTab = CreateNewTab();
                if (activeTab != null) {
                    ActiveTab = activeTab;
                    tabInfo.IsActive = false;
                } 
                
                else if (activeTab is null && tabInfo.IsActive) {
                    activeTab = ActiveTab;
                    tabInfo.IsActive = false;
                }

                currentTab.Info = tabInfo;
            }

            if (currentTab is null) CreateNewTab();
            else if (activeTab is null) {
                currentTab.Info.IsActive = true;
                ActiveTab = currentTab;
                DisplayActiveTabContent();
            }
        }
    }
}