using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Helpers.Math
{
    /// <inheritdoc cref="ICollection{T}" />
    public sealed class SortedLinkedList<T> : ICollection<T> 
        where T : IComparable<T>, IEquatable<T>
    {
        /// <summary>
        /// Порядок сортировки
        /// </summary>
        public enum SortingOrder
        {
            /// <summary>
            /// По возрастанию
            /// </summary>
            Ascending,

            /// <summary>
            /// По убыванию
            /// </summary>
            Descending
        }

        public sealed class Node<TValue> : IComparable<Node<TValue>>, IComparable, IEquatable<Node<TValue>>
            where TValue : IComparable<TValue>, IEquatable<TValue>
        {
            public Node<TValue> Next;

            public Node<TValue> Previous;

            public readonly TValue Value;

            public Node(TValue value, Node<TValue> previous = null, Node<TValue> next = null)
            {
                Value = value;
                Next = next;
                Previous = previous;
            }

            public override String ToString() => $"{Value}";

            public Int32 CompareTo(Node<TValue> other)
            {
                if (other is null)
                    return 1;
                return ReferenceEquals(this, other) ? 0 : Value.CompareTo(other.Value);
            }

            public Int32 CompareTo(Object obj)
            {
                if (!(obj is Node<TValue>))
                    throw new ArgumentException($"Object must be of type {nameof(Node<TValue>)}");
                return CompareTo((Node<TValue>)obj);
            }

            #region operators

            public static Boolean operator <(Node<TValue> left, Node<TValue> right)
            {
                return Comparer<Node<TValue>>.Default.Compare(left, right) < 0;
            }

            public static Boolean operator >(Node<TValue> left, Node<TValue> right)
            {
                return Comparer<Node<TValue>>.Default.Compare(left, right) > 0;
            }

            public static Boolean operator <=(Node<TValue> left, Node<TValue> right)
            {
                return Comparer<Node<TValue>>.Default.Compare(left, right) <= 0;
            }

            public static Boolean operator >=(Node<TValue> left, Node<TValue> right)
            {
                return Comparer<Node<TValue>>.Default.Compare(left, right) >= 0;
            }

            #endregion

            public Boolean Equals(Node<TValue> other)
            {
                if (other is null)
                    return false;
                return ReferenceEquals(this, other) || Value.Equals(other.Value);
            }

            public override Boolean Equals(Object obj)
            {
                return obj is Node<TValue> node && Equals(node);
            }

            public override Int32 GetHashCode()
            {
                return Value.GetHashCode();
            }
        }

        public Node<T> First { get; private set; }

        public Node<T> Last { get; private set; }

        public SortingOrder Order { get; }

        private readonly Action<T, T> collisionResolving;

        #region .ctors

        public SortedLinkedList(SortingOrder order = SortingOrder.Ascending, Action<T, T> action = null)
        {
            Order = order;
            collisionResolving = action;
        }

        public SortedLinkedList(SortingOrder order = SortingOrder.Ascending, Action<T, T> action = null, params T[] values)
        {
            Order = order;
            collisionResolving = action;

            foreach (var value in values)
                Add(value);
        }

        public SortedLinkedList(IEnumerable<T> values, SortingOrder order = SortingOrder.Ascending, Action<T, T> action = null)
        {
            Order = order;
            collisionResolving = action;

            foreach (var value in values)
                Add(value);
        }

        #endregion

        public override String ToString() => $"{{{String.Join("; ", this)}}}";

        public Int32 Count { get; private set; }

        public Boolean IsReadOnly { get; } = false;

        public Boolean IsEmpty => Count == 0;

        /// <summary>
        /// Insert <code>element</code> after <code>current</code> to the collection.
        /// </summary>
        /// <param name="element">Inserted element into collection.</param>
        /// <param name="current">Element of collection after which <code>element</code> will be inserted.</param>
        private static void InsertAfter(Node<T> element, Node<T> current)
        {
            var next = current.Next;
            if (next != null)
                next.Previous = element;
            current.Next = element;
            element.Previous = current;
            element.Next = next;
        }

        private static void InsertBefore(Node<T> element, Node<T> current)
        {
            var previous = current.Previous;
            if (previous != null)
                previous.Next = element;
            current.Previous = element;
            element.Next = current;
            element.Previous = previous;
        }

        public void Add(T value)
        {
            var node = new Node<T>(value);
            if (IsEmpty)
            {
                First = Last = node;
            }
            else
            {
                Func<Node<T>, Node<T>, Boolean> rule;
                switch (Order)
                {
                    case SortingOrder.Ascending:
                        rule = (x, y) => x < y;
                        break;

                    case SortingOrder.Descending:
                        rule = (x, y) => x > y;
                        break;

                    default:
                        throw new InvalidOperationException();
                }

                var current = SkipWhile(node, rule);
                if (current.Next is null)
                {
                    InsertAfter(current, node);
                }
                else
                {
                    if (current.Equals(node))
                        collisionResolving?.Invoke(node.Value, current.Value);
                    else
                        InsertBefore(node, current);
                }
            }

            Count++;
        }

        private Node<T> SkipWhile(Node<T> node, Func<Node<T>, Node<T>, Boolean> breakRule)
        {
            var current = First;
            while (!breakRule(current, node) && !(current.Next is null))
                current = current.Next;
            return current;
        }

        public Boolean Remove(T item)
        {
            Count--;
            return true;
        }

        public void Clear()
        {
            foreach (var element in this)
                Remove(element);
        }

        public Boolean Contains(T item)
        {
            throw new NotImplementedException();
        }

        public void CopyTo(T[] array, Int32 arrayIndex)
        {
            throw new NotImplementedException();
        }

        public IEnumerator<T> GetEnumerator()
        {
            var current = First;
            while (current.Next != null)
            {
                yield return current.Value;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}