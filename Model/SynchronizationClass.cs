using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Model
{
    public class SynchronizationClass:ISynchronizationClass
    {
        private List<Thread> threads;
        public SynchronizationClass() { }
        public void SetThread(ref Thread newThread)
        {
            this.threads.Add(newThread);
        }
    }
}
