using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StockExchangeOnIObservable
{
    class StockTicker : IObservable<StockTicker>
    {
        private StockExchange _stockExchange;

        List<IObserver<StockTicker>> observers = new List<IObserver<StockTicker>>();

        public StockExchange StockExchange
        {
            get { return _stockExchange; }
            set
            {
                _stockExchange = value;
                Notify(this);
            }
        }

        private void Notify(StockTicker ticker)
        {
            foreach (var observer in observers)
                observer.OnNext(ticker);
                
        }

        public IDisposable Subscribe(IObserver<StockTicker> observer)
        {
            if(!observers.Contains( observer))
                observers.Add(observer);
            return new Unsubscriber(observers, observer);
        }

        private class Unsubscriber : IDisposable
        {
            private List<IObserver<StockTicker>> _observers;
            private IObserver<StockTicker> _observer;


            public Unsubscriber(List<IObserver<StockTicker>> observers, IObserver<StockTicker> observer)
            {
                _observers = observers;
                _observer = observer;
            }


            public void Dispose()
            {
                if (_observers.Contains(_observer) && _observer != null)
                    _observers.Remove(_observer);
            }
        }
    }
}
