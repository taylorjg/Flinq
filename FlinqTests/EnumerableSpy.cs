using System.Collections;
using System.Collections.Generic;

namespace FlinqTests
{
    public class EnumerableSpy<T> : IEnumerable<T>
    {
        private readonly IEnumerable<T> _sequence;
        private readonly Dictionary<EnumeratorSpy, IEnumerator<T>> _enumerators = new Dictionary<EnumeratorSpy, IEnumerator<T>>();

        public EnumerableSpy(IEnumerable<T> sequence)
        {
            _sequence = sequence;
            ResetCallCounts();
        }

        public IEnumerator<T> GetEnumerator()
        {
            NumCallsToGetEnumerator++;
            var enumeratorSpy = new EnumeratorSpy(this);
            var enumerator = _sequence.GetEnumerator();
            AddSpyToRealEnumeratorMapping(enumeratorSpy, enumerator);
            return enumeratorSpy;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public int NumCallsToGetEnumerator { get; private set; }
        public int NumCallsToMoveNext { get; private set; }
        public int NumCallsToCurrent { get; private set; }
        public int NumCallsToReset { get; private set; }
        public int NumCallsToDispose { get; private set; }

        public void ResetCallCounts()
        {
            NumCallsToGetEnumerator = 0;
            NumCallsToMoveNext = 0;
            NumCallsToCurrent = 0;
            NumCallsToReset = 0;
            NumCallsToDispose = 0;
        }

        private bool MoveNext(EnumeratorSpy enumeratorSpy)
        {
            NumCallsToMoveNext++;
            return GetRealEnumerator(enumeratorSpy).MoveNext();
        }

        private void Reset(EnumeratorSpy enumeratorSpy)
        {
            NumCallsToReset++;
            GetRealEnumerator(enumeratorSpy).Reset();
        }

        private T GetCurrent(EnumeratorSpy enumeratorSpy)
        {
            NumCallsToCurrent++;
            return GetRealEnumerator(enumeratorSpy).Current;
        }

        private void Dispose(EnumeratorSpy enumeratorSpy)
        {
            NumCallsToDispose++;
            var enumerator = GetRealEnumerator(enumeratorSpy);
            RemoveSpyToRealEnumeratorMapping(enumeratorSpy);
            enumerator.Dispose();
        }

        private void AddSpyToRealEnumeratorMapping(EnumeratorSpy enumeratorSpy, IEnumerator<T> enumerator)
        {
            _enumerators.Add(enumeratorSpy, enumerator);
        }

        private void RemoveSpyToRealEnumeratorMapping(EnumeratorSpy enumeratorSpy)
        {
            _enumerators.Remove(enumeratorSpy);
        }

        private IEnumerator<T> GetRealEnumerator(EnumeratorSpy enumeratorSpy)
        {
            return _enumerators[enumeratorSpy];
        }

        private class EnumeratorSpy : IEnumerator<T>
        {
            private readonly EnumerableSpy<T> _enumerableSpy;

            public EnumeratorSpy(EnumerableSpy<T> enumerableSpy)
            {
                _enumerableSpy = enumerableSpy;
            }

            public bool MoveNext()
            {
                return _enumerableSpy.MoveNext(this);
            }

            public void Reset()
            {
                _enumerableSpy.Reset(this);
            }

            public T Current
            {
                get { return _enumerableSpy.GetCurrent(this); }
            }

            object IEnumerator.Current
            {
                get { return Current; }
            }

            public void Dispose()
            {
                _enumerableSpy.Dispose(this);
            }
        }
    }
}
