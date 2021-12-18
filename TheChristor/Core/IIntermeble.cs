using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChristor.Core {
    internal interface ISendable<Type> {
        String SenderName { get; }
        void SendContent(Type savingData);
        void SendCurrentContent(Type savingData);
    }

    internal interface IReceivable<Type> {
        String RecevierName { get; }
        Type ReceiveContent();
    }

    internal interface IIntermeble<Type> : IReceivable<Type>, ISendable<Type> {}
}