using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class LocationReporter : IObserver<string>
    {
        private IDisposable unsubscriber;
        private string instName;

        public LocationReporter(string name) {

            this.instName = name;
        }

        public virtual void Subscribe(IObservable<string> provider)
        {
            if(provider != null)
            {
                unsubscriber = provider.Subscribe(this);
            }
        }

        public virtual void Unsubscribe()
        {
            unsubscriber.Dispose();
        }

        public virtual void OnCompleted()
        {
            this.Unsubscribe();
        }

        public virtual void OnError(Exception e)
        {
            throw e;
        }

        public virtual void OnNext(string loc)
        {
            Console.WriteLine(loc);
        }
    }
}
 