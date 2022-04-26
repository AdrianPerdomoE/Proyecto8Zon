using Proyecto8Zon.Model.Entities;
using Proyecto8Zon.Model.Structures;

namespace Proyecto8Zon.Model.Menus
{
    public class MenuTransportadores: Menu
    {
        LinkedQueue<Transportador> ColaTransportadores;

        public MenuTransportadores (LinkedQueue<Transportador> colaTransportadores)
        {
            this.ColaTransportadores = colaTransportadores;

            bool seguirMenuTrasportadores = true;

            while (seguirMenuTrasportadores)
            {
                Console.Clear();
                Console.WriteLine(ColaTransportadores);
                int opcionMenuCompradores = ObtenerOpcionMenu("Ingresa 1 para añadir un transportador\nIngrese 2 para editar un transportador\nIngrese 0 para regresar al inicio", 2);
                switch (opcionMenuCompradores)
                {
                    case 1:
                        AñadirTransportador();
                        break;
                    case 2:
                        EditarTransportador();
                        break;
                    case 0:
                        seguirMenuTrasportadores = false;
                        break;
                }
            }
        }

        private void AñadirTransportador()
        {
            Console.Clear();
            string nombre = ObtenerEntrada("Ingrese nombre del trasportador");
            string id = ObtenerEntrada("Ingrese id del transportador");
            Transportador nuevoTransportador = new(nombre,id);
            bool añadirCidudades = true;
            while (añadirCidudades)
            {
                Console.Clear();
                string ciudad = ObtenerEntrada("Ingrese Ciudad donde presta servicio el transportador");
                nuevoTransportador.AñadirCiudad(ciudad);
                Console.Clear();
                Console.WriteLine("Ingrese 0 si No desea seguir añadiendo ciudades");
                int seguir = ObtenerEntradaInt();
                if(seguir == 0)
                {
                    añadirCidudades = false;
                }
            }
            ColaTransportadores.Add(nuevoTransportador);
        }
        private void EditarTransportador()
        {
            Console.Clear();

            bool seguirEditandoTransportador = true;

            if (ColaTransportadores.IsEmpty())
            {
                Console.WriteLine("No hay trasportadores registrados");
                Console.ReadLine();

                return;
            }

            int numeroTransportador = ObtenerOpcionMenu("Ingrese el # del vendedor que desea editar", ColaTransportadores.GetSize() - 1);

            Transportador transportadorActual = ColaTransportadores.Get(numeroTransportador);

            while (seguirEditandoTransportador)
            {
                Console.Clear();

                Console.WriteLine(transportadorActual);

               

                int OpcionEdicion = ObtenerOpcionMenu("Ingrese 1 si desea cambiar el nombre del comprador\nIngrese 2 si desea cambiar el id del comprador\nIngrese 3 si desea añadir una ciudad\nIngrese 4 si desea eliminar una ciudad\nIngrese 5 si desea eliminar el transportador\nIngrese 0 si desea salir del modo edición", 5);
                switch (OpcionEdicion)
                {
                    case 0:
                        seguirEditandoTransportador = false;
                        break;
                    case 1:
                        Console.Clear();
                        string nuevoNombre = ObtenerEntrada("Ingrese el nuevo nombre del transportador");
                        transportadorActual.Nombre = nuevoNombre;
                        break;
                    case 2:
                        Console.Clear();
                        string nuevoId = ObtenerEntrada("Ingrese el nuevo id del transportador");
                        transportadorActual.Id = nuevoId;
                        break;
                    case 3:
                        Console.Clear();
                        string nuevaCiudad = ObtenerEntrada("Ingrese la nueva ciudad a agregar");
                        transportadorActual.AñadirCiudad(nuevaCiudad);
                        break;
                    case 4:
                        Console.Clear();
                        int ciudadEliminar = ObtenerOpcionMenu("Ingrese # de la ciudad que desea eliminar", transportadorActual.ciudades.GetSize() - 1);
                        transportadorActual.EliminarCiudad(ciudadEliminar);
                        break;
                    case 5:
                        Console.Clear();
                        ColaTransportadores.Remove(numeroTransportador);
                        seguirEditandoTransportador = false;
                        break;
                }
            }
        }
    }
}
