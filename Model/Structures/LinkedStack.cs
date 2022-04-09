using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Structures
{
    public class LinkedStack<T>
    {
        class Node<T>
        {
            internal T Obj;

            internal Node<T>? Before;
            public Node(T obj, Node<T> before)
            {
                Before = before;
                Obj = obj;
            }
        }

        private Node<T>? Top = null;
        private int Size;

        public int GetSize()
        {
            return this.Size;
        }

        private bool IsEmpty()
        {
            return this.Size == 0;
        }

        public void Add(T obj)
        {
            Top = new Node<T>(obj, Top);
            Size++;
        }

        public T? Remove() 
        {
            if (this.IsEmpty()) 
            { 
                return null;
            }
            T exit = Top.Obj;
            return exit;
        }


    }
}
