using System;
using System.Collections.Generic;

namespace Estructuras_No_Lineales
{
    class Program
    {
        static void Main(string[] args)
        {
            MenuPrincipal();
        }

        static void MenuPrincipal()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("==================================================");
                Console.WriteLine("========= MENÚ PRINCIPAL - NO LINEALES ===========");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Árbol Binario de Búsqueda (ABB)");
                Console.WriteLine("2. Grafo (Lista de Adyacencia)");
                Console.WriteLine("3. Salir");
                Console.WriteLine("==================================================");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuArbolBinario();
                        break;
                    case "2":
                        MenuGrafo();
                        break;
                    case "3":
                        Console.WriteLine("\nSaliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("\nOpción inválida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region 1. Árbol Binario de Búsqueda
        /*
         * ==========================================
         * ESTRUCTURA: Árbol Binario de Búsqueda (ABB)
         * ==========================================
         * CARACTERÍSTICAS:
         * - Estructura jerárquica no lineal donde cada nodo tiene como máximo dos hijos (izquierdo y derecho).
         * - Mantiene un orden estricto: los valores menores a la raíz van al subárbol izquierdo y los mayores al derecho.
         * - Permite búsquedas, inserciones y eliminaciones muy eficientes (O(log n) en promedio).
         * 
         * APLICACIONES:
         * 1. Índices de bases de datos para realizar consultas y ordenamientos rápidos de grandes volúmenes de información.
         * 2. Autocompletado y diccionarios, utilizando variaciones como árboles Trie para buscar prefijos de palabras.
         * 3. Evaluación de expresiones matemáticas y sintaxis en compiladores e intérpretes.
         * ==========================================
         */
        class NodoArbol
        {
            public int Valor;
            public NodoArbol Izquierdo;
            public NodoArbol Derecho;

            public NodoArbol(int valor)
            {
                Valor = valor;
                Izquierdo = null;
                Derecho = null;
            }
        }

        class ArbolBinario
        {
            private NodoArbol raiz;

            public void Insertar(int valor)
            {
                raiz = InsertarRecursivo(raiz, valor);
                Console.WriteLine($"\nElemento '{valor}' insertado en el árbol.");
            }

            private NodoArbol InsertarRecursivo(NodoArbol nodo, int valor)
            {
                if (nodo == null)
                {
                    return new NodoArbol(valor);
                }

                if (valor < nodo.Valor)
                {
                    nodo.Izquierdo = InsertarRecursivo(nodo.Izquierdo, valor);
                }
                else if (valor > nodo.Valor)
                {
                    nodo.Derecho = InsertarRecursivo(nodo.Derecho, valor);
                }
                else
                {
                    Console.WriteLine($"\nEl valor '{valor}' ya existe en el árbol. No se admiten duplicados.");
                }

                return nodo;
            }

            public void MostrarInOrder()
            {
                if (raiz == null)
                {
                    Console.WriteLine("\nEl árbol está vacío.");
                    return;
                }

                Console.WriteLine("\nRecorrido In-Order (Izquierda -> Raíz -> Derecha):");
                RecorrerInOrder(raiz);
                Console.WriteLine(); // Salto de línea final
            }

            private void RecorrerInOrder(NodoArbol nodo)
            {
                if (nodo != null)
                {
                    RecorrerInOrder(nodo.Izquierdo);
                    Console.Write($"[{nodo.Valor}] ");
                    RecorrerInOrder(nodo.Derecho);
                }
            }
        }

        static void MenuArbolBinario()
        {
            ArbolBinario arbol = new ArbolBinario();
            while (true)
            {
                Console.WriteLine("\n--- MENÚ ÁRBOL BINARIO DE BÚSQUEDA ---");
                Console.WriteLine("1. Insertar elemento (entero)");
                Console.WriteLine("2. Mostrar recorrido In-Order (Ordenado)");
                Console.WriteLine("3. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                string op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Console.Write("Ingrese un número entero: ");
                        if (int.TryParse(Console.ReadLine(), out int valor))
                        {
                            arbol.Insertar(valor);
                        }
                        else
                        {
                            Console.WriteLine("\nEntrada inválida. Debe ingresar un número entero.");
                        }
                        break;
                    case "2":
                        arbol.MostrarInOrder();
                        break;
                    case "3":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
        #endregion

        #region 2. Grafo (Lista de Adyacencia)
        /*
         * ==========================================
         * ESTRUCTURA: Grafo (Lista de Adyacencia)
         * ==========================================
         * CARACTERÍSTICAS:
         * - Conjunto de nodos (vértices) conectados por enlaces (aristas). Puede ser dirigido o no dirigido.
         * - La lista de adyacencia es altamente eficiente en memoria para grafos dispersos, mapeando cada vértice a una lista de sus vecinos.
         * - A diferencia del árbol, un grafo puede contener ciclos y nodos desconectados.
         * 
         * APLICACIONES:
         * 1. Redes sociales: Para modelar usuarios (vértices) y sus relaciones o amistades (aristas).
         * 2. Sistemas de enrutamiento y mapas GPS (Google Maps): Para encontrar el camino más corto entre dos ubicaciones.
         * 3. Topologías de red y telecomunicaciones para analizar la distribución y cuellos de botella de los datos.
         * ==========================================
         */
        class Grafo
        {
            private Dictionary<string, List<string>> adyacencias;

            public Grafo()
            {
                adyacencias = new Dictionary<string, List<string>>();
            }

            public void AgregarVertice(string vertice)
            {
                if (string.IsNullOrWhiteSpace(vertice))
                {
                    Console.WriteLine("\nEl nombre del vértice no puede estar vacío.");
                    return;
                }

                if (!adyacencias.ContainsKey(vertice))
                {
                    adyacencias[vertice] = new List<string>();
                    Console.WriteLine($"\nVértice '{vertice}' agregado con éxito.");
                }
                else
                {
                    Console.WriteLine($"\nEl vértice '{vertice}' ya existe en el grafo.");
                }
            }

            public void AgregarArista(string origen, string destino)
            {
                if (adyacencias.ContainsKey(origen) && adyacencias.ContainsKey(destino))
                {
                    // Evitar aristas duplicadas en este ejemplo simple
                    if (!adyacencias[origen].Contains(destino))
                    {
                        adyacencias[origen].Add(destino);
                        
                        // Si el grafo es NO dirigido, agregamos la relación bidireccional
                        if (!adyacencias[destino].Contains(origen) && origen != destino)
                        {
                            adyacencias[destino].Add(origen);
                        }

                        Console.WriteLine($"\nArista agregada conectando '{origen}' con '{destino}'.");
                    }
                    else
                    {
                        Console.WriteLine($"\nYa existe una conexión directa entre '{origen}' y '{destino}'.");
                    }
                }
                else
                {
                    Console.WriteLine("\nError: Uno o ambos vértices no existen. Debe crearlos primero.");
                }
            }

            public void MostrarGrafo()
            {
                if (adyacencias.Count == 0)
                {
                    Console.WriteLine("\nEl grafo está vacío.");
                    return;
                }

                Console.WriteLine("\nEstructura del Grafo (Lista de Adyacencia):");
                foreach (var vertice in adyacencias)
                {
                    Console.Write($"[{vertice.Key}] -> ");
                    if (vertice.Value.Count > 0)
                    {
                        Console.WriteLine(string.Join(", ", vertice.Value));
                    }
                    else
                    {
                        Console.WriteLine("No tiene conexiones");
                    }
                }
            }
        }

        static void MenuGrafo()
        {
            Grafo grafo = new Grafo();
            while (true)
            {
                Console.WriteLine("\n--- MENÚ GRAFO NO DIRIGIDO ---");
                Console.WriteLine("1. Agregar Vértice (Nodo)");
                Console.WriteLine("2. Agregar Arista (Conexión)");
                Console.WriteLine("3. Mostrar Grafo");
                Console.WriteLine("4. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                string op = Console.ReadLine();
                switch (op)
                {
                    case "1":
                        Console.Write("Ingrese el nombre/valor del vértice: ");
                        grafo.AgregarVertice(Console.ReadLine());
                        break;
                    case "2":
                        Console.Write("Ingrese el vértice de origen: ");
                        string origen = Console.ReadLine();
                        Console.Write("Ingrese el vértice de destino: ");
                        string destino = Console.ReadLine();
                        grafo.AgregarArista(origen, destino);
                        break;
                    case "3":
                        grafo.MostrarGrafo();
                        break;
                    case "4":
                        return;
                    default:
                        Console.WriteLine("Opción inválida.");
                        break;
                }
            }
        }
        #endregion
    }
}