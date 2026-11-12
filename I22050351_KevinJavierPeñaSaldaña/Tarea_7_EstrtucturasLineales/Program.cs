using System;
using System.Text;

namespace EstructuraBicola
{
    // Nodo doblemente enlazado
    public class Nodo<T>
    {
        public T Dato;
        public Nodo<T> Anterior;
        public Nodo<T> Siguiente;

        public Nodo(T dato)
        {
            Dato = dato;
        }
    }

    /*
     * ============================================================
     * BICOLA (DEQUE - Double Ended Queue)
     * ============================================================
     *
     * CARACTERÍSTICAS DE LA ESTRUCTURA DE DATOS
     * ------------------------------------------------------------
     * 1. Es una estructura lineal y dinámica: los elementos se
     *    almacenan de forma secuencial y su tamaño puede crecer o
     *    disminuir en tiempo de ejecución.
     *
     * 2. Doble extremo: permite insertar y eliminar elementos tanto
     *    por el FRENTE como por el FINAL. Es una generalización de
     *    la pila (LIFO) y de la cola (FIFO), por lo que puede
     *    comportarse como cualquiera de las dos.
     *
     * 3. Operaciones en los extremos en tiempo constante O(1):
     *    InsertarFrente, InsertarFinal, EliminarFrente,
     *    EliminarFinal, VerFrente y VerFinal.
     *
     * 4. Acceso secuencial: para buscar un elemento intermedio
     *    (Contiene) hay que recorrer la estructura, es decir O(n).
     *    No permite acceso directo por índice.
     *
     * 5. Implementación con lista doblemente enlazada: cada nodo
     *    guarda referencias al nodo Anterior y Siguiente, lo que
     *    evita desplazar elementos al insertar o eliminar y
     *    aprovecha la memoria según se necesite.
     *    (También puede implementarse con un arreglo circular.)
     *
     * 6. Variantes comunes:
     *    - Bicola de entrada restringida: solo se inserta por un
     *      extremo, pero se elimina por ambos.
     *    - Bicola de salida restringida: se inserta por ambos
     *      extremos, pero solo se elimina por uno.
     *
     * 7. Estados importantes: bicola vacía (Cantidad == 0) y, en la
     *    versión con arreglo, bicola llena. Eliminar o consultar
     *    estando vacía debe manejarse (aquí lanza excepción).
     *
     * EJEMPLOS DE APLICACIONES
     * ------------------------------------------------------------
     * 1. Historial de navegación / función "Deshacer-Rehacer":
     *    se agregan acciones nuevas por un extremo y se descartan
     *    las más antiguas por el otro cuando se llega a un límite
     *    de historial, además de poder retroceder por el extremo
     *    reciente (comportamiento de pila).
     *
     * 2. Algoritmo de "robo de trabajo" (work stealing) en
     *    planificadores de tareas y sistemas multihilo: cada hilo
     *    toma tareas de su propio extremo de la bicola y otros
     *    hilos "roban" tareas desde el extremo opuesto, logrando
     *    balancear la carga de trabajo.
     *
     * 3. Verificación de palíndromos: se insertan los caracteres
     *    de una cadena en la bicola y se comparan extrayendo al
     *    mismo tiempo el primero y el último; si todos coinciden,
     *    la cadena es un palíndromo.
     *
     * Otras aplicaciones: ventana deslizante (máximo en subarreglos),
     * búsqueda en anchura 0-1 (0-1 BFS) y buffers de datos circulares.
     * ============================================================
     */

    // Bicola (Deque): inserción y eliminación por ambos extremos
    public class Bicola<T>
    {
        private Nodo<T> frente;
        private Nodo<T> final;
        public int Cantidad { get; private set; }

        public bool EstaVacia => Cantidad == 0;

        // Inserta al frente
        public void InsertarFrente(T dato)
        {
            var nuevo = new Nodo<T>(dato);
            if (EstaVacia)
            {
                frente = final = nuevo;
            }
            else
            {
                nuevo.Siguiente = frente;
                frente.Anterior = nuevo;
                frente = nuevo;
            }
            Cantidad++;
        }

        // Inserta al final
        public void InsertarFinal(T dato)
        {
            var nuevo = new Nodo<T>(dato);
            if (EstaVacia)
            {
                frente = final = nuevo;
            }
            else
            {
                nuevo.Anterior = final;
                final.Siguiente = nuevo;
                final = nuevo;
            }
            Cantidad++;
        }

        // Elimina y devuelve el elemento del frente
        public T EliminarFrente()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La bicola está vacía.");

            T dato = frente.Dato;
            frente = frente.Siguiente;

            if (frente == null)
                final = null;
            else
                frente.Anterior = null;

            Cantidad--;
            return dato;
        }

        // Elimina y devuelve el elemento del final
        public T EliminarFinal()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La bicola está vacía.");

            T dato = final.Dato;
            final = final.Anterior;

            if (final == null)
                frente = null;
            else
                final.Siguiente = null;

            Cantidad--;
            return dato;
        }

        // Consulta sin eliminar
        public T VerFrente()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La bicola está vacía.");
            return frente.Dato;
        }

        public T VerFinal()
        {
            if (EstaVacia)
                throw new InvalidOperationException("La bicola está vacía.");
            return final.Dato;
        }

        public void Vaciar()
        {
            frente = final = null;
            Cantidad = 0;
        }

        public bool Contiene(T dato)
        {
            var actual = frente;
            while (actual != null)
            {
                if (Equals(actual.Dato, dato))
                    return true;
                actual = actual.Siguiente;
            }
            return false;
        }

        public override string ToString()
        {
            if (EstaVacia) return "[ vacía ]";

            var sb = new StringBuilder("FRENTE <-> ");
            var actual = frente;
            while (actual != null)
            {
                sb.Append($"[{actual.Dato}]");
                if (actual.Siguiente != null) sb.Append(" <-> ");
                actual = actual.Siguiente;
            }
            sb.Append(" <-> FINAL");
            return sb.ToString();
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            var bicola = new Bicola<int>();
            int opcion;

            do
            {
                Console.Clear();
                Console.WriteLine("===== BICOLA (DEQUE) =====");
                Console.WriteLine($"Elementos: {bicola.Cantidad}");
                Console.WriteLine(bicola);
                Console.WriteLine();
                Console.WriteLine("1. Insertar al frente");
                Console.WriteLine("2. Insertar al final");
                Console.WriteLine("3. Eliminar del frente");
                Console.WriteLine("4. Eliminar del final");
                Console.WriteLine("5. Ver frente");
                Console.WriteLine("6. Ver final");
                Console.WriteLine("7. Buscar elemento");
                Console.WriteLine("8. Vaciar bicola");
                Console.WriteLine("0. Salir");
                Console.Write("\nElige una opción: ");

                if (!int.TryParse(Console.ReadLine(), out opcion))
                    opcion = -1;

                try
                {
                    switch (opcion)
                    {
                        case 1:
                            bicola.InsertarFrente(LeerEntero("Valor a insertar al frente: "));
                            Console.WriteLine("Elemento insertado al frente.");
                            break;
                        case 2:
                            bicola.InsertarFinal(LeerEntero("Valor a insertar al final: "));
                            Console.WriteLine("Elemento insertado al final.");
                            break;
                        case 3:
                            Console.WriteLine($"Eliminado del frente: {bicola.EliminarFrente()}");
                            break;
                        case 4:
                            Console.WriteLine($"Eliminado del final: {bicola.EliminarFinal()}");
                            break;
                        case 5:
                            Console.WriteLine($"Frente: {bicola.VerFrente()}");
                            break;
                        case 6:
                            Console.WriteLine($"Final: {bicola.VerFinal()}");
                            break;
                        case 7:
                            int buscado = LeerEntero("Valor a buscar: ");
                            Console.WriteLine(bicola.Contiene(buscado)
                                ? "El elemento SÍ está en la bicola."
                                : "El elemento NO está en la bicola.");
                            break;
                        case 8:
                            bicola.Vaciar();
                            Console.WriteLine("Bicola vaciada.");
                            break;
                        case 0:
                            Console.WriteLine("Saliendo...");
                            break;
                        default:
                            Console.WriteLine("Opción no válida.");
                            break;
                    }
                }
                catch (InvalidOperationException ex)
                {
                    Console.WriteLine($"Error: {ex.Message}");
                }

                if (opcion != 0)
                {
                    Console.WriteLine("\nPresiona una tecla para continuar...");
                    Console.ReadKey();
                }

            } while (opcion != 0);
        }

        static int LeerEntero(string mensaje)
        {
            int valor;
            Console.Write(mensaje);
            while (!int.TryParse(Console.ReadLine(), out valor))
            {
                Console.Write("Entrada inválida. Intenta de nuevo: ");
            }
            return valor;
        }
    }
}