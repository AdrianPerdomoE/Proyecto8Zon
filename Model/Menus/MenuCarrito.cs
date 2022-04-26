using Proyecto8Zon.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Menus
{
    public class MenuCarrito: Menu
    {
        ShoppingCar Carrito;
        public MenuCarrito(ShoppingCar shoppingCar)
        {
            Carrito = shoppingCar;
            bool SeguirEditarCarrito = true;
            while (SeguirEditarCarrito)
            {
                Console.Clear();
                Console.WriteLine(Carrito);
                int OpcionCarrito = ObtenerOpcionMenu("Ingrese 1 si desea reducir la cantidad de un producto\ningrese 2 si desea eliminar un producto del carrito\nIngrese 3 para vaciar el carrito compra\nIngrese 0 para salir el menu de edicion", 3);
                switch (OpcionCarrito)
                {
                    case 1:
                        Console.Clear();
                        int numeroProducto = ObtenerOpcionMenu("Ingrese # del producto al cual desea reducir la cantidad", Carrito.GetSize())-1;
                        Console.Clear();
                        Console.WriteLine("Ingrese cantidad que desea retirar");
                        int cantidad = ObtenerEntradaInt();
                        while(cantidad < 0 || cantidad > Carrito.CantidadItem(numeroProducto))
                        {
                            Console.Clear();
                            Console.WriteLine("Cantidad ingresada sobrepasa la cantidad en el carrito o es un valor no adecuado");
                            Console.WriteLine("Ingrese cantidad que desea retirar");
                            cantidad = ObtenerEntradaInt();
                        }
                        Carrito.sacarItem(numeroProducto,cantidad);
                        break;
                    case 2:
                        Console.Clear();
                        int numeroProductoEliminar = ObtenerOpcionMenu("Ingrese # del producto al cual desea reducir la cantidad", Carrito.GetSize()-1);
                        Carrito.EliminarItem(numeroProductoEliminar);
                        break;
                    case 3:
                        Console.Clear();
                        Carrito.Vaciar();
                        Console.WriteLine("Carrito vaciado correctamente");
                        Console.ReadLine();
                        Console.Clear();
                        SeguirEditarCarrito = false;
                        break;
                    case 0:
                        SeguirEditarCarrito = false;
                        break;

                }
            }
        }
    }
}
