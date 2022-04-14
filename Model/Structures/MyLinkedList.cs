using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Structures
{
    public class MyLinkedList <T> where T : class?
    {
         class Node<T> 
        {
            internal T Obj;
           
            internal Node<T>? Next;
           
            internal Node<T>? Previous;  
            public Node(Node<T> previous, Node<T> next, T obj)
            {
                Obj = obj;

                Next = next;

                Previous = previous;
            }
        }

        private Node<T>? Head = null;

        private Node<T>? Tail = null;

        private int Size { get; set; }

        public int GetSize()
        {
            return Size;
        }
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            Node<T> actual = Head;
            while (actual != null)
            {
                sb.Append($"{actual.Obj} ");
                actual = actual.Previous;
            }
            return sb.ToString();
        }
        public bool IsEmpty()
        {
            return Size == 0;
        }
        public void Add(T obj)
        {
            if (IsEmpty())
            {
                Tail = Head = new Node<T>(null, null, obj);
                Size++;
                return;
            }
            Node<T> newNode = new Node<T>(null, Tail, obj);
            Tail.Previous = newNode;
            Tail = newNode;
            Size++;
        }
        public void Add(T obj, int index)
        {
            if (index >= Size || index < 0)
            {
                return;
            }
            if (index < Size / 2)
            {
                Node<T> actualNode = Head;
                for (int i = 0; i < index; i++)
                {
                    actualNode = actualNode.Previous;
                }
                Node<T> newNode = new Node<T>(actualNode, actualNode.Next, obj);
                Size++;

                if (newNode.Next == null)
                {
                    Head = newNode;
                    actualNode.Next = newNode;
                }
                else
                {
                    actualNode.Next.Previous = newNode;
                    actualNode.Next = newNode;
                }

            }
            else
            {
                Node<T> actualNode = Tail;
                int newIndex = Size - index - 1;
                for (int i = 0; i < newIndex; i++)
                {
                    actualNode = actualNode.Next;
                }
                Node<T> newNode = new Node<T>(actualNode, actualNode.Next, obj);
                actualNode.Next.Previous = newNode;
                actualNode.Next = newNode;
                Size++;
            }
        }

        public T Get(int index)
        {
            if (index < 0 || index >= Size)
            {
                return null;
            }
            if (index < Size / 2)
            {
                Node<T> actualNode = Head;
                for (int i = 0; i < index; i++)
                {
                    actualNode = actualNode.Previous;
                }
                return actualNode.Obj;
            }
            else
            {
                Node<T> actualNode = Tail;
                int newIndex = Size - index - 1;
                for (int i = 0; i < newIndex; i++)
                {
                    actualNode = actualNode.Next;
                }
                return actualNode.Obj;
            }
        }

        public T? Remove(int index)
        {
            if (index < 0 || index >= Size)
            {
                return null;
            }
            if (index == 0)
            {
                Node<T> actualNode = Head;
                Head = actualNode.Previous;
                Head.Next = null;
                actualNode.Previous = null;
                Size--;
                return actualNode.Obj;
            }
            if (index == Size - 1)
            {
                Node<T> actualNode = Tail;
                Tail = actualNode.Next;
                Tail.Previous = null;
                actualNode.Next = null;
                Size--;
                return actualNode.Obj;
            }
            if (index < Size / 2)
            {
                Node<T> actualNode = Head;
                for (int i = 0; i < index; i++)
                {
                    actualNode = actualNode.Previous;
                }
                T exit = actualNode.Obj;
                actualNode.Next.Previous = actualNode.Previous;
                actualNode.Previous.Next = actualNode.Next;
                Size--;
                return exit;
            }
            else
            {
                Node<T> actualNode = Tail;
                int newIndex = Size - index - 1;
                for (int i = 0; i < newIndex; i++)
                {
                    actualNode = actualNode.Next;
                }
                T exit = actualNode.Obj;
                actualNode.Next.Previous = actualNode.Previous;
                actualNode.Previous.Next = actualNode.Next;
                Size--;
                return exit;
            }

        }
    }
}
