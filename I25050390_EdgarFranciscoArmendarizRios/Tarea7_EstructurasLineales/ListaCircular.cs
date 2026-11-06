

using System;

namespace EstructurasLineales
{
    /* 
     * CARACTERÍSTICAS:
     * 1. El último nodo apunta de regreso al primer nodo de la lista.
     * 2. Recorrido unidireccional continuo sin referencias nulas al final.
     * 3. Estructura ideal para ciclos infinitos controlados.
     * 
     * 3 APLICACIONES:
     * 1. Asignación de turnos cíclicos entre jugadores en videojuegos.
     * 2. Carrusel de anuncios o banners publicitarios continuos.
     * 3. Distribución equitativa de recursos en red.
     */
    public class NodoCircular
    {
        public int dato;
        public NodoCircular siguiente;
        public NodoCircular(int d) { dato = d; }
    }

    public class ListaCircular
    {
        private NodoCircular cabeza = null;
        private NodoCircular cola = null;

        public void Insertar(int d)
        {
            NodoCircular nuevo = new NodoCircular(d);
            if (cabeza == null)
            {
                cabeza = nuevo;
                cola = nuevo;
                cola.siguiente = cabeza; // Cierra el círculo
            }
            else
            {
                cola.siguiente = nuevo;
                cola = nuevo;
                cola.siguiente = cabeza; // Mantiene la circularidad
            }
            Console.WriteLine($"Insertado en lista circular: {d}");
        }

        public void MostrarPrimerosPasos()
        {
            if (cabeza == null) return;
            Console.WriteLine($"Cabeza: {cabeza.dato}, Apunta de vuelta a: {cola.siguiente.dato}");
        }

        public static void Ejecutar()
        {
            ListaCircular lista = new ListaCircular();
            lista.Insertar(1);
            lista.Insertar(2);
            lista.Insertar(3);
            lista.MostrarPrimerosPasos();
        }
    }
}

