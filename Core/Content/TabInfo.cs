using System;
namespace TheChristor.Core.Content {
    [Serializable]
    public sealed class TabInfo {
        public Boolean IsActive  { get; set; }
        public String Title      { get; set; }
        public String Filename   { get; set; }
        public String TabContent { get; set; }

        public TabInfo() {
            #region nameless.txt
            Title = "nameless.txt";
            #endregion
            IsActive   = false;
            Filename   = String.Empty;
            TabContent = String.Empty;
        }

        public override String ToString() => IsActive.ToString() 
            + Title.ToString()
            + Filename.ToString()
            + TabContent.ToString();
    }
}