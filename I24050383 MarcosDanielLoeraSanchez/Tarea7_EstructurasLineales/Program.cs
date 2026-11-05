using System;

namespace Estructuras_de_Datos
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
                Console.WriteLine("========= MENÚ PRINCIPAL - ESTRUCTURAS ===========");
                Console.WriteLine("==================================================");
                Console.WriteLine("1. Cola Circular");
                Console.WriteLine("2. Bicola (Cola de Doble Extremo)");
                Console.WriteLine("3. Lista Doblemente Enlazada");
                Console.WriteLine("4. Lista Circular");
                Console.WriteLine("5. Lista Circular Doble");
                Console.WriteLine("6. Salir");
                Console.WriteLine("==================================================");
                Console.Write("Seleccione una opción: ");

                string opcion = Console.ReadLine();
                switch (opcion)
                {
                    case "1":
                        MenuColaCircular();
                        break;
                    case "2":
                        MenuBicola();
                        break;
                    case "3":
                        MenuListaaDoble();
                        break;
                    case "4":
                        MenuListaCircular();
                        break;
                    case "5":
                        MenuListaCircularDoble();
                        break;
                    case "6":
                        Console.WriteLine("\nSaliendo del programa...");
                        return;
                    default:
                        Console.WriteLine("\nOpción inválida. Presione una tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        #region 1. Cola Circular
        /*
         * ==========================================
         * ESTRUCTURA: Cola Circular
         * ==========================================
         * CARACTERÍSTICAS:
         * - Utiliza un arreglo de tamaño fijo donde el último elemento se conecta conceptualmente con el primero formando un círculo.
         * - Reutiliza el espacio de los elementos eliminados cuando los índices alcanzan el límite del arreglo, optimizando la memoria disponible.
         * - Gestiona punteros o índices de 'frente' y 'fin' junto con un contador de elementos para controlar desbordamientos.
         * 
         * APLICACIONES:
         * 1. Buffers de datos en streaming o procesamiento de audio/video en tiempo real (evita pérdida de datos con flujo continuo).
         * 2. Planificación de procesos en sistemas operativos (Round Robin) para asignar tiempo de CPU equitativamente.
         * 3. Manejo de colas de impresión o buffers de entrada/salida en periféricos con memoria limitada.
         * ==========================================
         */
        class ColaCircular
        {
            private string[] arreglo;
            private int frente;
            private int fin;
            private int capacidad;
            private int count;

            public ColaCircular(int capacidad)
            {
                this.capacidad = capacidad;
                arreglo = new string[capacidad];
                frente = 0;
                fin = -1;
                count = 0;
            }

            public bool EstaLlena() => count == capacidad;
            public bool EstaVacia() => count == 0;

            public void Enqueue(string elemento)
            {
                if (EstaLlena())
                {
                    Console.WriteLine("\nLa cola circular está llena.");
                    return;
                }
                fin = (fin + 1) % capacidad;
                arreglo[fin] = elemento;
                count++;
                Console.WriteLine($"\nElemento '{elemento}' agregado con éxito.");
            }

            public string Dequeue()
            {
                if (EstaVacia())
                {
                    return null;
                }
                string elemento = arreglo[frente];
                arreglo[frente] = null;
                frente = (frente + 1) % capacidad;
                count--;
                return elemento;
            }

            public void Mostrar()
            {
                if (EstaVacia())
                {
                    Console.WriteLine("\nLa cola circular está vacía.");
                    return;
                }
                Console.WriteLine("\nElementos en la Cola Circular (del frente al final):");
                for (int i = 0; i < count; i++)
                {
                    int indice = (frente + i) % capacidad;
                    Console.WriteLine($"[{indice}] -> {arreglo[indice]}");
                }
            }
        }

        static void MenuColaCircular()
        {
            ColaCircular cola = new ColaCircular(5);
            while (true)
            {
                Console.WriteLine("\n--- MENÚ COLA CIRCULAR (Capacidad: 5) ---");
                Console.WriteLine("1. Enqueue (Agregar)");
                Console.WriteLine("2. Dequeue (Quitar)");
                Console.WriteLine("3. Mostrar elementos");
                Console.WriteLine("4. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                string op = Console.ReadLine();
                if (op == "1")
                {
                    Console.Write("Ingrese el elemento a agregar: ");
                    cola.Enqueue(Console.ReadLine());
                }
                else if (op == "2")
                {
                    string quitado = cola.Dequeue();
                    Console.WriteLine(quitado != null ? $"\nElemento atendido/quitado: {quitado}" : "\nLa cola circular está vacía.");
                }
                else if (op == "3")
                {
                    cola.Mostrar();
                }
                else if (op == "4")
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Opción inválida.");
                }
            }
        }
        #endregion

        #region 2. Bicola (Cola de Doble Extremo)
        /*
         * ==========================================
         * ESTRUCTURA: Bicola (Deque - Double-Ended Queue)
         * ==========================================
         * CARACTERÍSTICAS:
         * - Permite la inserción y eliminación de elementos tanto por el extremo frontal como por el extremo trasero.
         * - Combina y generaliza las propiedades operativas de una pila (LIFO) y una cola (FIFO) en una sola estructura.
         * - Puede implementarse de manera eficiente mediante arreglos circulares redimensionables o listas doblemente enlazadas.
         * 
         * APLICACIONES:
         * 1. Historial de navegación web o funciones de deshacer/rehacer (Undo/Redo) donde se ingresan y extraen datos por ambos extremos.
         * 2. Algoritmos de robo de trabajo (*work-stealing*) en programación concurrente y multiprocesamiento.
         * 3. Algoritmos de optimización de ventana deslizante (*sliding window*) para procesar sub-arreglos o flujos de datos.
         * ==========================================
         */
        class Bicola
        {
            private System.Collections.Generic.LinkedList<string> lista = new System.Collections.Generic.LinkedList<string>();

            public void InsertarFrente(string elemento)
            {
                lista.AddFirst(elemento);
                Console.WriteLine($"\nElemento '{elemento}' insertado al frente.");
            }

            public void InsertarFinal(string elemento)
            {
                lista.AddLast(elemento);
                Console.WriteLine($"\nElemento '{elemento}' insertado al final.");
            }

            public string QuitarFrente()
            {
                if (lista.Count == 0) return null;
                string val = lista.First.Value;
                lista.RemoveFirst();
                return val;
            }

            public string QuitarFinal()
            {
                if (lista.Count == 0) return null;
                string val = lista.Last.Value;
                lista.RemoveLast();
                return val;
            }

            public void Mostrar()
            {
                if (lista.Count == 0)
                {
                    Console.WriteLine("\nLa bicola está vacía.");
                    return;
                }
                Console.WriteLine("\nElementos en la Bicola (Frente -> Final):");
                foreach (var item in lista)
                {
                    Console.WriteLine(item);
                }
            }
        }

        static void MenuBicola()
        {
            Bicola bicola = new Bicola();
            while (true)
            {
                Console.WriteLine("\n--- MENÚ BICOLA (Deque) ---");
                Console.WriteLine("1. Insertar al frente");
                Console.WriteLine("2. Insertar al final");
                Console.WriteLine("3. Quitar del frente");
                Console.WriteLine("4. Quitar del final");
                Console.WriteLine("5. Mostrar elementos");
                Console.WriteLine("6. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                string op = Console.ReadLine();
                if (op == "1")
                {
                    Console.Write("Ingrese elemento: ");
                    bicola.InsertarFrente(Console.ReadLine());
                }
                else if (op == "2")
                {
                    Console.Write("Ingrese elemento: ");
                    bicola.InsertarFinal(Console.ReadLine());
                }
                else if (op == "3")
                {
                    string q = bicola.QuitarFrente();
                    Console.WriteLine(q != null ? $"\nQuitado del frente: {q}" : "\nBicola vacía.");
                }
                else if (op == "4")
                {
                    string q = bicola.QuitarFinal();
                    Console.WriteLine(q != null ? $"\nQuitado del final: {q}" : "\nBicola vacía.");
                }
                else if (op == "5")
                {
                    bicola.Mostrar();
                }
                else if (op == "6")
                {
                    break;
                }
            }
        }
        #endregion

        #region 3. Lista Doblemente Enlazada
        /*
         * ==========================================
         * ESTRUCTURA: Lista Doblemente Enlazada
         * ==========================================
         * CARACTERÍSTICAS:
         * - Cada nodo contiene un dato y dos punteros: uno hacia el nodo siguiente y otro hacia el nodo anterior.
         * - Permite el recorrido bidireccional (hacia adelante y hacia atrás) de manera eficiente sin requerir índices numéricos fijos.
         * - Facilita la inserción y eliminación dinámica de nodos en cualquier posición si se dispone de una referencia directa al nodo.
         * 
         * APLICACIONES:
         * 1. Implementación de cachés de reemplazo de páginas (como LRU - Least Recently Used) en sistemas de bases de datos y memoria.
         * 2. Navegación en historiales complejos de aplicaciones (ej. álbumes de fotos, visores de documentos con avance y retroceso).
         * 3. Listas de reproducción de reproductores multimedia donde se permite saltar a la pista anterior o siguiente de forma directa.
         * ==========================================
         */
        class NodoDoble
        {
            public string Valor;
            public NodoDoble Siguiente;
            public NodoDoble Anterior;

            public NodoDoble(string valor)
            {
                Valor = valor;
                Siguiente = null;
                Anterior = null;
            }
        }

        class ListaDoblementeEnlazada
        {
            private NodoDoble cabeza;
            private NodoDoble cola;

            public void Agregar(string valor)
            {
                NodoDoble nuevo = new NodoDoble(valor);
                if (cabeza == null)
                {
                    cabeza = cola = nuevo;
                }
                else
                {
                    cola.Siguiente = nuevo;
                    nuevo.Anterior = cola;
                    cola = nuevo;
                }
                Console.WriteLine($"\nElemento '{valor}' agregado a la lista doble.");
            }

            public void MostrarAdelante()
            {
                if (cabeza == null)
                {
                    Console.WriteLine("\nLa lista está vacía.");
                    return;
                }
                Console.WriteLine("\nRecorrido hacia adelante (Cabeza -> Cola):");
                NodoDoble actual = cabeza;
                while (actual != null)
                {
                    Console.Write($"[{actual.Valor}] <-> ");
                    actual = actual.Siguiente;
                }
                Console.WriteLine("NULL");
            }

            public void MostrarAtras()
            {
                if (cola == null)
                {
                    Console.WriteLine("\nLa lista está vacía.");
                    return;
                }
                Console.WriteLine("\nRecorrido hacia atrás (Cola -> Cabeza):");
                NodoDoble actual = cola;
                while (actual != null)
                {
                    Console.Write($"[{actual.Valor}] <-> ");
                    actual = actual.Anterior;
                }
                Console.WriteLine("NULL");
            }
        }

        static void MenuListaaDoble()
        {
            ListaDoblementeEnlazada lista = new ListaDoblementeEnlazada();
            while (true)
            {
                Console.WriteLine("\n--- MENÚ LISTA DOBLEMENTE ENLAZADA ---");
                Console.WriteLine("1. Agregar elemento");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                string op = Console.ReadLine();
                if (op == "1")
                {
                    Console.Write("Ingrese valor: ");
                    lista.Agregar(Console.ReadLine());
                }
                else if (op == "2")
                {
                    lista.MostrarAdelante();
                }
                else if (op == "3")
                {
                    lista.MostrarAtras();
                }
                else if (op == "4")
                {
                    break;
                }
            }
        }
        #endregion

        #region 4. Lista Circular
        /*
         * ==========================================
         * ESTRUCTURA: Lista Circular (Singly Circular Linked List)
         * ==========================================
         * CARACTERÍSTICAS:
         * - Similar a una lista enlazada simple, pero el puntero `siguiente` del último nodo apunta de regreso a la cabeza en lugar de `null`.
         * - No existe un fin definitivo; el recorrido puede continuar indefinidamente dando vueltas en bucle por toda la estructura.
         * - Ideal para manejar colecciones donde se requiere un acceso continuo y rotativo a los elementos.
         * 
         * APLICACIONES:
         * 1. Planificadores de tareas en sistemas operativos (Round Robin) para asignar turnos rotativos a procesos concurrentes.
         * 2. Simulación de juegos de mesa por turnos o gestión de jugadores en partidas multijugador cíclicas.
         * 3. Buffers circulares basados en nodos enlazados para flujos continuos de datos o procesamiento en anillos.
         * ==========================================
         */
        class NodoCircular
        {
            public string Valor;
            public NodoCircular Siguiente;

            public NodoCircular(string valor)
            {
                Valor = valor;
                Siguiente = null;
            }
        }

        class ListaCircular
        {
            private NodoCircular cabeza;
            private NodoCircular cola;

            public void Agregar(string valor)
            {
                NodoCircular nuevo = new NodoCircular(valor);
                if (cabeza == null)
                {
                    cabeza = nuevo;
                    cola = nuevo;
                    cola.Siguiente = cabeza;
                }
                else
                {
                    cola.Siguiente = nuevo;
                    cola = nuevo;
                    cola.Siguiente = cabeza;
                }
                Console.WriteLine($"\nElemento '{valor}' agregado a la lista circular.");
            }

            public void Mostrar(int limiteVueltas = 10)
            {
                if (cabeza == null)
                {
                    Console.WriteLine("\nLa lista circular está vacía.");
                    return;
                }
                Console.WriteLine("\nRecorrido de la Lista Circular (mostrando ciclo):");
                NodoCircular actual = cabeza;
                int contador = 0;
                do
                {
                    Console.Write($"[{actual.Valor}] -> ");
                    actual = actual.Siguiente;
                    contador++;
                    if (contador >= limiteVueltas) break;
                } while (actual != cabeza);
                Console.WriteLine("(retorna a la cabeza)");
            }
        }

        static void MenuListaCircular()
        {
            ListaCircular lista = new ListaCircular();
            while (true)
            {
                Console.WriteLine("\n--- MENÚ LISTA CIRCULAR ---");
                Console.WriteLine("1. Agregar elemento");
                Console.WriteLine("2. Mostrar elementos");
                Console.WriteLine("3. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                string op = Console.ReadLine();
                if (op == "1")
                {
                    Console.Write("Ingrese valor: ");
                    lista.Agregar(Console.ReadLine());
                }
                else if (op == "2")
                {
                    lista.Mostrar();
                }
                else if (op == "3")
                {
                    break;
                }
            }
        }
        #endregion

        #region 5. Lista Circular Doble
        /*
         * ==========================================
         * ESTRUCTURA: Lista Circular Doble (Doubly Circular Linked List)
         * ==========================================
         * CARACTERÍSTICAS:
         * - Combina los atributos de las listas doblemente enlazadas y las listas circulares.
         * - Cada nodo posee punteros al nodo siguiente y al anterior. El puntero `siguiente` del último nodo apunta a la cabeza, y el `anterior` de la cabeza apunta al último nodo.
         * - Permite la navegación bidireccional continua sin fin en ambos sentidos.
         * 
         * APLICACIONES:
         * 1. Carruseles de imágenes o galerías de visualización infinita en interfaces gráficas de usuario.
         * 2. Reproductores multimedia con bucle de reproducción continuo (ciclar pistas hacia adelante o hacia atrás indefinidamente).
         * 3. Representación de estructuras espaciales continuas, tableros circulares o simulaciones físicas en videojuegos.
         * ==========================================
         */
        class NodoCircularDoble
        {
            public string Valor;
            public NodoCircularDoble Siguiente;
            public NodoCircularDoble Anterior;

            public NodoCircularDoble(string valor)
            {
                Valor = valor;
                Siguiente = null;
                Anterior = null;
            }
        }

        class ListaCircularDoble
        {
            private NodoCircularDoble cabeza;
            private NodoCircularDoble cola;

            public void Agregar(string valor)
            {
                NodoCircularDoble nuevo = new NodoCircularDoble(valor);
                if (cabeza == null)
                {
                    cabeza = nuevo;
                    cola = nuevo;
                    cabeza.Siguiente = cabeza;
                    cabeza.Anterior = cabeza;
                }
                else
                {
                    cola.Siguiente = nuevo;
                    nuevo.Anterior = cola;
                    nuevo.Siguiente = cabeza;
                    cabeza.Anterior = nuevo;
                    cola = nuevo;
                }
                Console.WriteLine($"\nElemento '{valor}' agregado a la lista circular doble.");
            }

            public void MostrarAdelante(int limite = 10)
            {
                if (cabeza == null)
                {
                    Console.WriteLine("\nLa lista circular doble está vacía.");
                    return;
                }
                Console.WriteLine("\nRecorrido hacia adelante (Ciclo):");
                NodoCircularDoble actual = cabeza;
                int contador = 0;
                do
                {
                    Console.Write($"[{actual.Valor}] <-> ");
                    actual = actual.Siguiente;
                    contador++;
                    if (contador >= limite) break;
                } while (actual != cabeza);
                Console.WriteLine("(retorna al inicio)");
            }

            public void MostrarAtras(int limite = 10)
            {
                if (cola == null)
                {
                    Console.WriteLine("\nLa lista circular doble está vacía.");
                    return;
                }
                Console.WriteLine("\nRecorrido hacia atrás (Ciclo inverso):");
                NodoCircularDoble actual = cola;
                int contador = 0;
                do
                {
                    Console.Write($"[{actual.Valor}] <-> ");
                    actual = actual.Anterior;
                    contador++;
                    if (contador >= limite) break;
                } while (actual != cola);
                Console.WriteLine("(retorna al final)");
            }
        }

        static void MenuListaCircularDoble()
        {
            ListaCircularDoble lista = new ListaCircularDoble();
            while (true)
            {
                Console.WriteLine("\n--- MENÚ LISTA CIRCULAR DOBLE ---");
                Console.WriteLine("1. Agregar elemento");
                Console.WriteLine("2. Mostrar hacia adelante");
                Console.WriteLine("3. Mostrar hacia atrás");
                Console.WriteLine("4. Regresar al menú principal");
                Console.Write("Seleccione una opción: ");

                string op = Console.ReadLine();
                if (op == "1")
                {
                    Console.Write("Ingrese valor: ");
                    lista.Agregar(Console.ReadLine());
                }
                else if (op == "2")
                {
                    lista.MostrarAdelante();
                }
                else if (op == "3")
                {
                    lista.MostrarAtras();
                }
                else if (op == "4")
                {
                    break;
                }
            }
        }
        #endregion
    }
}
