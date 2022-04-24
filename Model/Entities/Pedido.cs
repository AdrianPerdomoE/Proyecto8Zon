using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Entities
{
    public class Pedido
    {
        public bool Enviado { get; set; }

        public Comprador Comprador { get; set; }

        public ShoppingCar ShoppingCar { get; set; }

        public Pedido(Comprador comprador, ShoppingCar shoppingCar)
        {
            Comprador = comprador;
            ShoppingCar = shoppingCar;
            Enviado = false;
        }

        public void ConfirmarEnvio()
        {
            Enviado=true;
        }
        public override string ToString()
        {
            string enviado;
            if (Enviado)
            {
                enviado = "Enviado";
            }
            else
            {
                enviado = "No enviado";
            }
            return $"{Comprador} \nPedido {enviado}:{ShoppingCar}";
        }
    }
}
