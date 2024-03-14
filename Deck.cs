using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace C_II_1stAssignment
{
    internal class Deck<T> where T : struct , IComparable<T>
    {
        private Queue<T> _currentDeck = new Queue<T>();
        private Queue<T> _discardPile = new Queue<T>();

        private readonly uint _deckSize;

        public Deck(uint size) 
        {
            _deckSize = size;

            for (int i = 0; i < size; i++)
            {
                _currentDeck.Enqueue(new T());
            }
        }

        public void Shuffle()
        {
            List<T> holder = new List<T>(_currentDeck);
            _currentDeck.Clear();

            for (int i = 0; i < holder.Count; i++)
            {
                int rnd = Random.Shared.Next(holder.Count -1);

                _currentDeck.Enqueue(holder[rnd]);
                holder.RemoveAt(rnd);
            }
        }

        public void ReShuffle()
        {
            foreach (T item in _discardPile)
            {
                _currentDeck.Enqueue(item);
            }

            Shuffle();
        }

        public bool TryDraw()
        {
            if (_currentDeck.Count == 0)
                return false;

            _discardPile.Enqueue(_currentDeck.Dequeue());
            return true;
        }

        public T Peek()
        {
            return _currentDeck.Peek();
        }

        public uint Size()
        {
            return _deckSize;
        }

        public uint Remaining()
        {
            return (uint)_currentDeck.Count;
        }
    }
}
