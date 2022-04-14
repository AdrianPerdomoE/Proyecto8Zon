using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class Transportador
    {
        public MyLinkedList<string> ciudades { get;}

        public string Nombre;

        public string Id;

        public Transportador(string nombre, string id)
        {
            ciudades = new MyLinkedList<string>();
            Nombre = nombre;
            Id = id;
        }
         public void AñadirCiudad(string ciudad)
        {
            for (int i = 0; i < ciudades.GetSize(); i++)
            {
                if(ciudades.Get(i) == ciudad)
                {
                    return;
                }
            }
            ciudades.Add(ciudad);
        }
    }
}
