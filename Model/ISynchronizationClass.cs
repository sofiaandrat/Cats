using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    interface ISynchronizationClass
    {
        void SetThread(ref Thread newThread);
    }
}
