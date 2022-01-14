using System;
namespace TheChristor.Core.Content {
    internal interface IReceivable<T> {
        String Receviername { get; set; }
        T ReceiveContent();
    }
}