using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class Comprador
    {
        public ShoppingCar CarritoCompra { get;}

        public string Nombre;

        public string Telefono;

        public string Id;

        public string Correo;

        public Comprador(string nombre, string telefono, string id, string correo)
        {
            Nombre = nombre;
            Telefono = telefono;
            Id = id;
            Correo = correo;
            CarritoCompra = new ShoppingCar();
        }
        public override string ToString()
        {
            return $"Nombre:{Nombre} Id:{Id}$ Telefono: {Telefono}";
        }
    }
}
