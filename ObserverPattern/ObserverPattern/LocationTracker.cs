using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObserverPattern
{
    class LocationTracker : IObservable<string>
    {

        private List<IObserver<string>> observers;

        public LocationTracker()
        {
            this.observers = new List<IObserver<string>>();
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            if(!observers.Contains(observer))
            {
                this.observers.Add(observer);
            }

            return new Unsubscriber(this.observers, observer);
        }

        public class Unsubscriber : IDisposable
        {
            private List<IObserver<string>> observers;
            private IObserver<string> observer;
            public Unsubscriber(List<IObserver<string>> observers, IObserver<string> observer)
            {
                this.observers = observers;
                this.observer = observer;
            }

            public void Dispose()
            {
                if(this.observer != null && this.observers.Contains(this.observer))
                {
                    this.observers.Remove(this.observer);
                }
            }
        }

        public void TrackLocation(string loc)
        {
            foreach(var observer in observers)
            {
                if(loc == null)
                {
                    observer.OnError(new Exception("sorry but this is not a value and you suck"));
                } else
                {
                    observer.OnNext(loc);
                }
            }
        }
        
        public void EndTransmission()
        {
            foreach(var observer in observers)
            {
                if(observers.Contains(observer))
                {
                    observer.OnCompleted();
                }
            }

            observers.Clear();
        }
    }
}
