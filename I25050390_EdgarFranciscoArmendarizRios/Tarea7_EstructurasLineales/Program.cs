

using System;

namespace EstructurasLineales
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=== EJECUCIÓN DE OPERACIONES - TAREA 7 ===\n");

            Console.WriteLine("--- 1. COLA CIRCULAR ---");
            ColaCircular.Ejecutar();

            Console.WriteLine("\n--- 2. BICOLA ---");
            Bicola.Ejecutar();

            Console.WriteLine("\n--- 3. LISTA DOBLEMENTE ENLAZADA ---");
            ListaDoblementeEnlazada.Ejecutar();

            Console.WriteLine("\n--- 4. LISTA CIRCULAR ---");
            ListaCircular.Ejecutar();

            Console.WriteLine("\n--- 5. LISTA CIRCULAR DOBLE ---");
            ListaCircularDoble.Ejecutar();
        }
    }
}
