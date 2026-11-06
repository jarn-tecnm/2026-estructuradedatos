

using System;
using System.Collections.Generic;

namespace EstructurasLineales
{
    /* 
     * CARACTERÍSTICAS:
     * 1. Permite inserción y eliminación por ambos extremos (frente y final).
     * 2. Actúa de forma flexible como Pila (LIFO) o Cola (FIFO).
     * 3. No requiere posiciones fijas de tamaño predefinido.
     * 
     * 3 APLICACIONES:
     * 1. Historial de navegación web (avanzar y retroceder páginas).
     * 2. Algoritmos de verificación de palíndromos.
     * 3. Gestión de caché para datos de acceso reciente.
     */
    public class Bicola
    {
        private LinkedList<int> datos = new LinkedList<int>();

        public void InsertarFrente(int v)
        {
            datos.AddFirst(v);
            Console.WriteLine($"Insertado al frente: {v}");
        }

        public void InsertarFinal(int v)
        {
            datos.AddLast(v);
            Console.WriteLine($"Insertado al final: {v}");
        }

        public void EliminarFrente()
        {
            if (datos.Count > 0)
            {
                Console.WriteLine($"Eliminado del frente: {datos.First.Value}");
                datos.RemoveFirst();
            }
        }

        public static void Ejecutar()
        {
            Bicola bicola = new Bicola();
            bicola.InsertarFinal(100);
            bicola.InsertarFrente(200);
            bicola.EliminarFrente();
        }
    }
}