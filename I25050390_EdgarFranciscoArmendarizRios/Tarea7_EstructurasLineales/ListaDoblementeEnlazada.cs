

using System;

namespace EstructurasLineales
{
    /* 
     * CARACTERÍSTICAS:
     * 1. Cada nodo contiene un valor y dos punteros: Siguiente y Anterior.
     * 2. Permite recorrer la lista en ambas direcciones.
     * 3. Facilita la eliminación dinámica de nodos de manera eficiente.
     * 
     * 3 APLICACIONES:
     * 1. Listas de reproducción musicales (canción siguiente y anterior).
     * 2. Funcionalidad de Deshacer y Rehacer (Undo/Redo) en editores.
     * 3. Visores de galerías de imágenes.
     */
    public class NodoDoble
    {
        public int dato;
        public NodoDoble siguiente;
        public NodoDoble anterior;
        public NodoDoble(int d) { dato = d; }
    }

    public class ListaDoblementeEnlazada
    {
        private NodoDoble inicio;

        public void Insertar(int d)
        {
            NodoDoble nuevo = new NodoDoble(d);
            if (inicio == null)
            {
                inicio = nuevo;
            }
            else
            {
                NodoDoble actual = inicio;
                while (actual.siguiente != null) actual = actual.siguiente;
                actual.siguiente = nuevo;
                nuevo.anterior = actual;
            }
            Console.WriteLine($"Insertado en lista doble: {d}");
        }

        public void Mostrar()
        {
            NodoDoble actual = inicio;
            Console.Write("Recorrido: ");
            while (actual != null)
            {
                Console.Write($"{actual.dato} <-> ");
                actual = actual.siguiente;
            }
            Console.WriteLine("null");
        }

        public static void Ejecutar()
        {
            ListaDoblementeEnlazada lista = new ListaDoblementeEnlazada();
            lista.Insertar(5);
            lista.Insertar(15);
            lista.Insertar(25);
            lista.Mostrar();
        }
    }
}
