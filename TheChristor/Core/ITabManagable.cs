namespace TheChristor.Core {
    internal interface ITabManager {
        Content.Tab ActiveTab { get; }
        void CloseActiveTab();
        void OpenContentToNewTab();

        void SaveActiveTabContentToFile();
        void SaveActiveTabContentToCurrentFile();

        Content.Tab CreateNewTab();
        void ResizeTabs();
    }
}