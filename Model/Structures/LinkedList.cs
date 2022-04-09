using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Structures
{
    public class LinkedList<T>
    {
        class Node<T>
        {
            internal T Obj;
           
            internal Node<T> Next;
           
            internal Node<T> Previous;  
            public Node(Node<T> previous, Node<T> next, T obj)
            {
                Obj = obj;

                Next = next;

                Previous = previous;
            }
        }

        private Node<T> Head;

        private Node<T> Tail;

        public int Size { get;}

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
            Node<T> newNode= new Node<T>(null, Tail , obj);
            Tail.Previous = newNode;
            Tail = newNode;
            Size++;
        }
        public void Add(T obj, int index)
        {
            if(index >= Size || index < 0)
            {
                return;
            }
            if (index < Size / 2)
            {
                Node<T> actualNode = Head;
                for(int i = 0; i < index ; i++)
                {
                    actualNode = actualNode.Previous;
                }
                Node<T> newNode = new Node<T>(actualNode,actualNode.Next,obj);
                Size++;
                
                if(newNode.Next == null)
                {
                    Head = newNode;
                    actualNode.Next = newNode;
                }
                else
                {
                    actualNode.Next.Previous = newNode;
                    actualNode.Next=newNode;
                }

            }
            else
            {
                Node<T> actualNode = Tail;
                int newIndex = Size - index;
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
            if(index < 0 || index >= Size)
            {
                return null;
            }
            if(index < Size / 2)
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
                int newIndex = Size - index;
                for (int i = 0; i < newIndex; i++)
                {
                    actualNode = actualNode.Next;
                }
                return actualNode.Obj;
            }   
        }

        public T Remove(int index)
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
                T exit = actualNode.Obj;
                actualNode.Next.Previous = actualNode.Previous;
                actualNode.Previous.Next = actualNode.Next;

                return exit;
            }
            else
            {
                Node<T> actualNode = Tail;
                int newIndex = Size - index;
                for (int i = 0; i < newIndex; i++)
                {
                    actualNode = actualNode.Next;
                }
                T exit = actualNode.Obj;
                actualNode.Next.Previous = actualNode.Previous;
                actualNode.Previous.Next = actualNode.Next;
                return exit;
            }

           
        }
    }
}
