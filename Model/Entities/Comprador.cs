using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class Comprador
    {
        public ShoppingCar CarritoCompra { get; set;}

        public string Nombre;

        public string Telefono;

        public string Id;

        public string Correo;

        public string Ciudad;
        public Comprador(string nombre, string telefono, string id, string correo, string ciudad)
        {
            Nombre = nombre;
            Telefono = telefono;
            Id = id;
            Correo = correo;
            Ciudad = ciudad;
            CarritoCompra = new ShoppingCar();
        }
        public override string ToString()
        {
            return $"Nombre:{Nombre} Id:{Id} Ciudad:{Ciudad} Telefono: {Telefono}";
        }
        public void RenovarCarro()
        {
            CarritoCompra = new();
        }
    }
}
