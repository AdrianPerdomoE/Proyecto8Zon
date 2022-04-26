using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Structures
{
    public class LinkedQueue<T> where T : class?
    {
        class Node<T>
        {
            internal Node<T>? Next;

            internal Node<T>? Before;

            internal T Obj;
            public Node(Node<T> before, Node<T> next, T obj)
            {
                Next = next;
                Before = before;
                Obj = obj;
            }

        }

        private Node<T>? First = null;

        private Node<T>? Last = null;

        private int Size = 0;


        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> actual = First;
            int counter = 0;
            while (actual != null)
            {
                sb.Append($"#{counter} {actual.Obj}");
                actual = actual.Before;
                counter++;
            }
            return sb.ToString();
        }
        public bool IsEmpty() { return Size == 0; }
        public void Add(T obj)
        {
            if (IsEmpty())
            {
                Last = First = new Node<T>(null, null, obj);
                Size++;
                return;
            }
            Node<T> newNode = new Node<T>(null, Last, obj);
            Last.Before = newNode;
            Last = newNode;
            Size++;
        }

        public T Remove()
        {
            if (IsEmpty())
            {
                return null;
            }
            T exit = First.Obj;
            if (Size == 1)
            {
                First = null;
                Last = null;
                Size--;
                return exit;
            }
            
            First = First.Before;
            First.Next = null;
            Size--;
            return exit;
        }
        public T Get(int index)
        {
            if (index < 0 || index >= Size)
            {
                return null;
            }
            if (index < Size / 2)
            {
                Node<T> actualNode =First;
                for (int i = 0; i < index; i++)
                {
                    actualNode = actualNode.Before;
                }
                return actualNode.Obj;
            }
            else
            {
                Node<T> actualNode = Last;
                int newIndex = Size - index - 1;
                for (int i = 0; i < newIndex; i++)
                {
                    actualNode = actualNode.Next;
                }
                return actualNode.Obj;
            }
        }

        public int GetSize()
        {
            return Size;
        }
        public T Remove(int index)
        {
            if (IsEmpty())
            {
                return null;
            }
            if(index < 0 || index >= Size)
            {
                return null;
            }
            if (index == 0)
            {
                return Remove();
            }
            if (index == Size - 1)
            {
                Node<T> actualNode = Last;
                Last = actualNode.Next;
                Last.Before = null;
                actualNode.Next = null;
                Size--;
                return actualNode.Obj;
            }
            if (index < Size / 2)
            {
                Node<T> actualNode = First;
                for (int i = 0; i < index; i++)
                {
                    actualNode = actualNode.Before;
                }
                T exit = actualNode.Obj;
                actualNode.Next.Before = actualNode.Before;
                actualNode.Before.Next = actualNode.Next;
                Size--;
                return exit;
            }
            else
            {
                Node<T> actualNode = Last;
                int newIndex = Size - index - 1;
                for (int i = 0; i < newIndex; i++)
                {
                    actualNode = actualNode.Next;
                }
                T exit = actualNode.Obj;
                actualNode.Next.Before = actualNode.Before;
                actualNode.Before.Next = actualNode.Next;
                Size--;
                return exit;
            }

        }

    }
}
