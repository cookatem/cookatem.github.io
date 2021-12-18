using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChristor.Core {
    internal interface ITabManagable<Type> {
        void CloseActiveTab();
        void OpenContentToNewTab();

        void SaveActiveTabContentToFile();
        void SaveActiveTabContentToCurrentFile();

        void SetContentToActiveTab(Type content);

        void InitializeNewTab();
        void ResizeTabs();
    }
}