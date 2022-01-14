using System;
namespace TheChristor.Core.Content {
    internal interface ISendable<T> {
        String Sendername { get; set; }
        void SendContent(T sendingData);
        void SendCurrentContent(T sendingData);
    }
}