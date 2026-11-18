
using System;
using System.Collections.Generic;

namespace ArbolGeneral
{
    class NodoGeneral
    {
        public string Dato;
        public List<NodoGeneral> Hijos;

        public NodoGeneral(string dato)
        {
            Dato = dato;
            Hijos = new List<NodoGeneral>();
        }
    }

    class NodoBinario
    {
        public int Dato;
        public NodoBinario Izquierdo;
        public NodoBinario Derecho;

        public NodoBinario(int dato)
        {
            Dato = dato;
            Izquierdo = null;
            Derecho = null;
        }
    }

    class Program
    {
        static NodoGeneral raizGeneral = null;
        static NodoBinario raizBinario = null;
        static NodoBinario raizBusqueda = null;

        static Dictionary<string, List<string>> grafo =
            new Dictionary<string, List<string>>();

        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        // MENU PRINCIPAL

        static void MenuPrincipal()
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("===== ESTRUCTURAS NO LINEALES =====");
                Console.WriteLine("1. Arboles");
                Console.WriteLine("2. Grafos");
                Console.WriteLine("3. Salir del programa");
                Console.Write("\nElige una opcion: ");

                string opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuArboles();
                        break;

                    case "2":
                        MenuGrafos();
                        break;

                    case "3":
                        Console.WriteLine("Saliendo del programa...");
                        continuar = false;
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // MENU DE ARBOLES

        static void MenuArboles()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENU DE ARBOLES =====");
                Console.WriteLine("1. Arbol General");
                Console.WriteLine("2. Arbol Binario");
                Console.WriteLine("3. Arbol Binario de Busqueda");
                Console.WriteLine("4. Regresar");
                Console.Write("\nElige una opcion: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        MenuGeneral();
                        break;

                    case "2":
                        MenuBinario();
                        break;

                    case "3":
                        MenuBusqueda();
                        break;

                    case "4":
                        break;

                    default:
                        Console.WriteLine("Opcion no valida.");
                        Console.ReadKey();
                        break;
                }

            } while (opcion != "4");
        }

        // ARBOL GENERAL

        static void MenuGeneral()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== ARBOL GENERAL =====");
                Console.WriteLine("1. Crear raiz");
                Console.WriteLine("2. Agregar hijo");
                Console.WriteLine("3. Mostrar arbol");
                Console.WriteLine("4. Regresar");
                Console.Write("\nElige una opcion: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa la raiz: ");
                        raizGeneral = new NodoGeneral(Console.ReadLine());
                        break;

                    case "2":
                        if (raizGeneral == null)
                        {
                            Console.WriteLine("Primero crea la raiz.");
                            break;
                        }

                        Console.Write("Ingresa el padre: ");
                        string padre = Console.ReadLine();

                        NodoGeneral encontrado =
                            BuscarGeneral(raizGeneral, padre);

                        if (encontrado != null)
                        {
                            Console.Write("Ingresa el hijo: ");
                            encontrado.Hijos.Add(
                                new NodoGeneral(Console.ReadLine()));
                        }
                        else
                        {
                            Console.WriteLine("No se encontro el padre.");
                        }
                        break;

                    case "3":
                        if (raizGeneral == null)
                            Console.WriteLine("El arbol esta vacio.");
                        else
                            MostrarGeneral(raizGeneral, 0);
                        break;
                }

                if (opcion != "4")
                    Console.ReadKey();

            } while (opcion != "4");
        }

        static NodoGeneral BuscarGeneral(
            NodoGeneral nodo, string dato)
        {
            if (nodo.Dato == dato)
                return nodo;

            foreach (NodoGeneral hijo in nodo.Hijos)
            {
                NodoGeneral encontrado =
                    BuscarGeneral(hijo, dato);

                if (encontrado != null)
                    return encontrado;
            }

            return null;
        }

        static void MostrarGeneral(NodoGeneral nodo, int nivel)
        {
            Console.WriteLine(
                new string(' ', nivel * 4) + nodo.Dato);

            foreach (NodoGeneral hijo in nodo.Hijos)
                MostrarGeneral(hijo, nivel + 1);
        }

        // ARBOL BINARIO

        static void MenuBinario()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== ARBOL BINARIO =====");
                Console.WriteLine("1. Crear raiz");
                Console.WriteLine("2. Agregar hijo izquierdo");
                Console.WriteLine("3. Agregar hijo derecho");
                Console.WriteLine("4. Mostrar arbol");
                Console.WriteLine("5. Regresar");
                Console.Write("\nElige una opcion: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa la raiz: ");
                        raizBinaria = new NodoBinario(
                            int.Parse(Console.ReadLine()));
                        break;

                    case "2":
                        if (raizBinaria == null)
                        {
                            Console.WriteLine("Primero crea la raiz.");
                            break;
                        }

                        Console.Write("Ingresa el hijo izquierdo: ");
                        raizBinaria.Izquierdo = new NodoBinario(
                            int.Parse(Console.ReadLine()));
                        break;

                    case "3":
                        if (raizBinaria == null)
                        {
                            Console.WriteLine("Primero crea la raiz.");
                            break;
                        }

                        Console.Write("Ingresa el hijo derecho: ");
                        raizBinaria.Derecho = new NodoBinario(
                            int.Parse(Console.ReadLine()));
                        break;

                    case "4":
                        if (raizBinaria == null)
                            Console.WriteLine("El arbol esta vacio.");
                        else
                            MostrarBinario(raizBinaria, 0);
                        break;
                }

                if (opcion != "5")
                    Console.ReadKey();

            } while (opcion != "5");
        }

        static void MostrarBinario(NodoBinario nodo, int nivel)
        {
            if (nodo == null)
                return;

            Console.WriteLine(
                new string(' ', nivel * 4) + nodo.Dato);

            MostrarBinario(nodo.Izquierdo, nivel + 1);
            MostrarBinario(nodo.Derecho, nivel + 1);
        }

        // ARBOL BINARIO DE BUSQUEDA

        static void MenuBusqueda()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== ARBOL BINARIO DE BUSQUEDA =====");
                Console.WriteLine("1. Insertar dato");
                Console.WriteLine("2. Mostrar en orden");
                Console.WriteLine("3. Buscar dato");
                Console.WriteLine("4. Regresar");
                Console.Write("\nElige una opcion: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Ingresa un numero: ");
                        int dato = int.Parse(Console.ReadLine());

                        raizBusqueda = Insertar(raizBusqueda, dato);
                        break;

                    case "2":
                        Console.WriteLine("Recorrido en orden:");
                        InOrden(raizBusqueda);
                        Console.WriteLine();
                        break;

                    case "3":
                        Console.Write("Numero a buscar: ");
                        int buscar = int.Parse(Console.ReadLine());

                        if (Buscar(raizBusqueda, buscar))
                            Console.WriteLine("Dato encontrado.");
                        else
                            Console.WriteLine("Dato no encontrado.");
                        break;
                }

                if (opcion != "4")
                    Console.ReadKey();

            } while (opcion != "4");
        }

        static NodoBinario Insertar(NodoBinario nodo, int dato)
        {
            if (nodo == null)
                return new NodoBinario(dato);

            if (dato < nodo.Dato)
                nodo.Izquierdo = Insertar(nodo.Izquierdo, dato);

            else if (dato > nodo.Dato)
                nodo.Derecho = Insertar(nodo.Derecho, dato);

            return nodo;
        }

        static void InOrden(NodoBinario nodo)
        {
            if (nodo != null)
            {
                InOrden(nodo.Izquierdo);
                Console.Write(nodo.Dato + " ");
                InOrden(nodo.Derecho);
            }
        }

        static bool Buscar(NodoBinario nodo, int dato)
        {
            if (nodo == null)
                return false;

            if (nodo.Dato == dato)
                return true;

            if (dato < nodo.Dato)
                return Buscar(nodo.Izquierdo, dato);

            return Buscar(nodo.Derecho, dato);
        }

        // MENU DE GRAFOS

        static void MenuGrafos()
        {
            string opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== MENU DE GRAFOS =====");
                Console.WriteLine("1. Agregar vertice");
                Console.WriteLine("2. Conectar vertices");
                Console.WriteLine("3. Mostrar grafo");
                Console.WriteLine("4. Regresar");
                Console.Write("\nElige una opcion: ");

                opcion = Console.ReadLine();

                switch (opcion)
                {
                    case "1":
                        Console.Write("Nombre del vertice: ");
                        string vertice = Console.ReadLine();

                        if (!grafo.ContainsKey(vertice))
                        {
                            grafo.Add(vertice, new List<string>());
                            Console.WriteLine("Vertice agregado.");
                        }
                        else
                        {
                            Console.WriteLine("El vertice ya existe.");
                        }
                        break;

                    case "2":
                        Console.Write("Vertice de origen: ");
                        string origen = Console.ReadLine();

                        Console.Write("Vertice de destino: ");
                        string destino = Console.ReadLine();

                        if (grafo.ContainsKey(origen) &&
                            grafo.ContainsKey(destino))
                        {
                            grafo[origen].Add(destino);
                            grafo[destino].Add(origen);

                            Console.WriteLine("Conexion agregada.");
                        }
                        else
                        {
                            Console.WriteLine(
                                "Uno o ambos vertices no existen.");
                        }
                        break;

                    case "3":
                        MostrarGrafo();
                        break;
                }

                if (opcion != "4")
                    Console.ReadKey();

            } while (opcion != "4");
        }

        static void MostrarGrafo()
        {
            if (grafo.Count == 0)
            {
                Console.WriteLine("El grafo esta vacio.");
                return;
            }

            Console.WriteLine("\n===== CONEXIONES DEL GRAFO =====");

            foreach (var vertice in grafo)
            {
                Console.Write(vertice.Key + " -> ");

                foreach (string conexion in vertice.Value)
                {
                    Console.Write(conexion + " ");
                }

                Console.WriteLine();
            }
        }
    }
}
