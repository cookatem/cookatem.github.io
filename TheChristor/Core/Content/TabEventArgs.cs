using System;
namespace TheChristor.Core.Content {
    internal class TabEventArgs : EventArgs {
        public Tab SendingTab    { get; set; }
        public Tab LastActiveTab { get; set; }
        public TabEventArgs(Tab sendingTab, Tab lastActiveTab) { 
            SendingTab = sendingTab;
            LastActiveTab = lastActiveTab;
        }
    }
}