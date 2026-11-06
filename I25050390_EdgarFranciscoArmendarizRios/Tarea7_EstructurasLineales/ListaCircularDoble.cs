

using System;

namespace EstructurasLineales
{
    /* 
     * CARACTERÍSTICAS:
     * 1. El último nodo apunta al primero y el primero apunta al último mediante doble enlace.
     * 2. Permite navegación infinita en ambas direcciones (adelante y atrás).
     * 3. No existen punteros `null` en los extremos.
     * 
     * 3 APLICACIONES:
     * 1. Menús interactivos circulares en interfaces gráficas o videojuegos.
     * 2. Buffer de control bidireccional en hardware.
     * 3. Listas de tareas en sistemas operativos de tiempo real.
     */
    public class NodoCircularDoble
    {
        public int dato;
        public NodoCircularDoble siguiente;
        public NodoCircularDoble anterior;
        public NodoCircularDoble(int d) { dato = d; }
    }

    public class ListaCircularDoble
    {
        private NodoCircularDoble inicio = null;

        public void Insertar(int d)
        {
            NodoCircularDoble nuevo = new NodoCircularDoble(d);
            if (inicio == null)
            {
                inicio = nuevo;
                inicio.siguiente = inicio;
                inicio.anterior = inicio;
            }
            else
            {
                NodoCircularDoble ultimo = inicio.anterior;
                ultimo.siguiente = nuevo;
                nuevo.anterior = ultimo;
                nuevo.siguiente = inicio;
                inicio.anterior = nuevo;
            }
            Console.WriteLine($"Insertado en lista circular doble: {d}");
        }

        public static void Ejecutar()
        {
            ListaCircularDoble lista = new ListaCircularDoble();
            lista.Insertar(10);
            lista.Insertar(20);
            Console.WriteLine("Lista circular doble operando correctamente.");
        }
    }
}





