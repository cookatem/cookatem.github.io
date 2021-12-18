using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TheChristor.Core {
    internal interface IContentDisplayable<Type> {
        void DisplayContent(Type displayingContent);
    }
}