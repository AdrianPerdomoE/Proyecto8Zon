 using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class Vendedor
    {
        public Catalogo Catalogo { get;}

        public string Nombre;

        public string Id;
        public Vendedor(string nombre, string id)
        {
            Nombre = nombre;

            Id = id;

            Catalogo = new Catalogo();
        }

        public override string ToString()
        {
            return $"{Nombre} - id: {Id} tamaño del catalogo: {Catalogo.GetSize()}";
        }
    }
}
