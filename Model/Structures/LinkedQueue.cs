using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Structures
{
    public class LinkedQueue<T>
    {
        class Node<T>
        {
            internal Node<T> Next;

            internal Node<T> Before;

            internal T Obj;
            public Node(Node<T> before, Node<T> next, T obj)
            {
                Next = next;
                Before = before;
                Obj = obj;
            }
        }

        private Node<T> First = null;

        private Node<T> Last = null;

        private int Size;

        public bool IsEmpty() { return Size == 0; }
        public void Add(T obj) 
        {
            if (IsEmpty())
            {
                 Last = First = new Node<T>(null,null,obj);
                Size++;
                return;
            }
            Node<T> newNode= new Node<T>(null, Last, obj);
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
            T  exit = First.Obj;
            First = First.Before;
            First.Next = null;
            Size--; 
            return exit;
        }

    }
}
