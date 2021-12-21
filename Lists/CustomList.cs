using System.Collections.Generic;
using System.Collections;
using System;

namespace SimpleAlgorithmsApp
{
    public class Node<T>
    {
        public T data { get; set; }
        public Node<T> next;
        public Node<T> prev;

        public Node(T data)
        {
            this.data = data;
        }
    }

    public class CustomList<T> : IEnumerable<T>
    {
        class CustomEnumerator : IEnumerator<T>
        {
            CustomList<T> list;
            Node<T> currNode;
            Node<T> first;
            public CustomEnumerator(CustomList<T> list)
            {
                this.list = list;
                Node<T> prevBegin = new Node<T>(default);
                prevBegin.next = list.begin;
                first = prevBegin;
                currNode = prevBegin;
            }

            public object Current => currNode.data;

            T IEnumerator<T>.Current => currNode.data;

            public void Dispose()
            {}

            public bool MoveNext()
            {
                if (currNode.next != null)
                {
                    currNode = currNode.next;
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                currNode = first;
            }
        }

        Node<T> begin;
        Node<T> end;
        public int Length { get; set; }

        // добавление элемента
        public void Add(T data)
        {
            Node<T> node = new Node<T>(data);

            if (begin == null)
            {
                begin = node;
            }
            else
            {
                end.next = node;
                node.prev = end;
            }
            end = node;
            Length++;
        }

        public void InsertAfter(int index, T data)
        {
            if (Length == 1)
            {
                Add(data);
                return;
            }

            Node<T> curr = begin;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                curr = curr.next;
            }
            Node<T> newNode = new Node<T>(data);
            if (curr.next != null)
            {
                var next = curr.next;
                next.prev = newNode;
                newNode.next = next;
            }
            curr.next = newNode;
            newNode.prev = curr;
            Length++;
        }

        public void InsertBefore(int index, T data)
        {
            Node<T> curr = begin;
            for (int i = 0; i < index; i++)
            {
                if (curr.next == null)
                {
                    throw new ArgumentOutOfRangeException();
                }
                curr = curr.next;
            }

            Node<T> newNode = new Node<T>(data);
            if (curr == begin)
            {
                begin = newNode;
            }

            
            if (curr.prev != null)
            {
                var prev = curr.prev;
                prev.next = newNode;
                newNode.prev = prev;
            }
            curr.prev = newNode;
            newNode.next = curr;
            Length++;
        }

        public void AddFirst(T data)
        {
            Node<T> node = new Node<T>(data);
            Node<T> temp = begin;
            node.next = temp;
            begin = node;
            if (Length == 0)
                end = begin;
            else
                temp.prev = node;
            Length++;
        }
        public T First()
        {
            return begin.data;
        }
        public bool Remove(T data)
        {
            Node<T> current = begin;

            while (current != null)
            {
                if (current.data.Equals(data))
                {
                    break;
                }
                current = current.next;
            }
            if (current != null)
            {
                // если узел не последний
                if (current.next != null)
                {
                    current.next.prev = current.prev;
                }
                else
                {
                    // если последний, переустанавливаем end
                    end = current.prev;
                }

                // если узел не первый
                if (current.prev != null)
                {
                    current.prev.next = current.next;
                }
                else
                {
                    // если первый, переустанавливаем begin
                    begin = current.next;
                }
                Length--;
                return true;
            }
            return false;
        }
        public bool IsEmpty { get { return Length == 0; } }
        public void Clear()
        {
            begin = null;
            end = null;
            Length = 0;
        }
        public bool Contains(T data)
        {
            Node<T> current = begin;
            while (current != null)
            {
                if (current.data.Equals(data))
                    return true;
                current = current.next;
            }
            return false;
        }
        public IEnumerator GetEnumerator()
        {
            return new CustomEnumerator(this);
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new CustomEnumerator(this);
        }
    }
}