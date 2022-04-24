using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class Envio
    {
        Transportador Transportador;

        Pedido Pedido;

       public LinkedStack<Product> productos = new();
        public Envio(Transportador transportador, Pedido pedido)
        {
            Pedido = pedido;
            Transportador = transportador;  
        }
        public override string ToString()
        {
            return $"Transporte:{Transportador}\nPedido: {Pedido}";
        }
    }
}
