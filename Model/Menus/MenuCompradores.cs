using Proyecto8Zon.Model.Entities;
using Proyecto8Zon.Model.Structures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proyecto8Zon.Model.Menus
{
    public class MenuCompradores : Menu
    {
        MyLinkedList<Comprador> ListaCompradores;

        public MenuCompradores(MyLinkedList<Comprador> listaCompradores)
        {
            this.ListaCompradores = listaCompradores;

            bool seguirMenuCompradores = true;

            while (seguirMenuCompradores)
            {
                Console.Clear();
                Console.WriteLine(ListaCompradores);
                int opcionMenuCompradores = ObtenerOpcionMenu("Ingresa 1 para añadir un comprador\nIngrese 2 para editar un comprador\nIngrese 0 para regresar al inicio",2);
                switch (opcionMenuCompradores)
                {
                    case 1:
                        AñadirComprador();
                        break;
                    case 2:
                        EditarComprador();
                        break;
                    case 0:
                        seguirMenuCompradores = false;
                        break;
                }
            }
        }

        private void AñadirComprador()
        {
            Console.Clear();
            string nombre = ObtenerEntrada("Ingrese nombre del comprador");
            string telefono = ObtenerEntrada("Ingrese telefono del comprador");
            string id = ObtenerEntrada("Ingrese id del comprador");
            string correo = ObtenerEntrada("Ingrese correo del comprador");
            string ciudad = ObtenerEntrada("Ingrese ciudad del comprador");
            Comprador nuevoComprador = new(nombre,telefono,id,correo,ciudad);
            ListaCompradores.Add(nuevoComprador);   
        }
        private void EditarComprador()
        {
            Console.Clear();

            bool SeguirEditandoComprador = true;

            if (ListaCompradores.IsEmpty())
            {
                Console.WriteLine("No hay compradores registrados");
                Console.ReadLine();

                return;
            }

            int numeroComprador = ObtenerOpcionMenu("Ingrese el # del comprador que desea editar", ListaCompradores.GetSize() - 1);

                Comprador compradorActual = ListaCompradores.Get(numeroComprador);

            while (SeguirEditandoComprador)
            {
                Console.Clear();

                Console.WriteLine(compradorActual);

                Console.WriteLine($"Items en el carrito: \n{compradorActual.CarritoCompra}");

                int OpcionEdicion = ObtenerOpcionMenu("Ingrese 1 si desea cambiar el nombre del comprador\nIngrese 2 si desea cambiar el id del comprador\nIngrese 3 si desea cambiar el telefono del comprador\nIngrese 4 si desea cambiar el correo del comprador\nIngrese 5 si desea cambiar la ciudad del comprador\nIngrese 6 si desea eliminar el comprador\nIngrese 7 para editar el carrito de compras\nIngrese 0 si desea salir del modo edición", 7);
                switch (OpcionEdicion)
                {
                    case 0:
                        SeguirEditandoComprador = false;
                        break;
                    case 1:
                        Console.Clear();
                        string nuevoNombre = ObtenerEntrada("Ingrese el nuevo nombre del comprador");
                        compradorActual.Nombre = nuevoNombre;
                        break;
                    case 2:
                        Console.Clear();
                        string nuevoId = ObtenerEntrada("Ingrese el nuevo id del comprador");
                        compradorActual.Id = nuevoId;
                        break;
                    case 3:
                        Console.Clear();
                        string nuevoTelefono = ObtenerEntrada("Ingrese el nuevo telefono del comprador");
                        compradorActual.Telefono = nuevoTelefono;
                        break;
                    case 4:
                        Console.Clear();
                        string nuevoCorreo = ObtenerEntrada("Ingrese el nuevo correo del comprador");
                        compradorActual. Correo = nuevoCorreo;
                        break;
                    case 5:
                        Console.Clear();
                        string nuevaCidad = ObtenerEntrada("Ingrese la nueva del comprador");
                        compradorActual.Ciudad = nuevaCidad;
                        break;
                    case 6:
                        Console.Clear();
                        ListaCompradores.Remove(numeroComprador);
                        SeguirEditandoComprador = false;
                        break;
                    case 7:
                        if (compradorActual.CarritoCompra.IsEmpty())
                        {
                            Console.Clear();
                            Console.WriteLine("No hay productos en el carrito de compra para poder editar");
                            Console.ReadLine();
                            break;
                        }
                        MenuCarrito menuCarrito = new(compradorActual.CarritoCompra);
                        break;
                }
            }
        }
    }
}
