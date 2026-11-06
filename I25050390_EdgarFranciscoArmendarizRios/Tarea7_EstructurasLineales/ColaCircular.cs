


using System;

namespace EstructurasLineales
{
    /* 
     * CARACTERÍSTICAS:
     * 1. El último elemento se conecta con el primero formando un anillo o círculo.
     * 2. Utiliza la política FIFO (First In, First Out).
     * 3. Reutiliza posiciones libres al desencolar sin desperdiciar espacio.
     * 
     * 3 APLICACIONES:
     * 1. Buffers de audio/video en servicios de streaming.
     * 2. Gestión de turnos de atención en impresoras o servidores.
     * 3. Planificación de procesos en sistemas operativos (Round Robin).
     */
    public class ColaCircular
    {
        private int[] elementos;
        private int frente, finalCola, tamanoMax, contador;

        public ColaCircular(int capacidad)
        {
            tamanoMax = capacidad;
            elementos = new int[tamanoMax];
            frente = 0;
            finalCola = -1;
            contador = 0;
        }

        public void Encolar(int valor)
        {
            if (contador == tamanoMax)
            {
                Console.WriteLine("Cola circular llena.");
                return;
            }
            finalCola = (finalCola + 1) % tamanoMax;
            elementos[finalCola] = valor;
            contador++;
            Console.WriteLine($"Encolado: {valor}");
        }

        public void Desencolar()
        {
            if (contador == 0)
            {
                Console.WriteLine("Cola circular vacía.");
                return;
            }
            Console.WriteLine($"Desencolado: {elementos[frente]}");
            frente = (frente + 1) % tamanoMax;
            contador--;
        }

        public static void Ejecutar()
        {
            ColaCircular cola = new ColaCircular(3);
            cola.Encolar(10);
            cola.Encolar(20);
            cola.Encolar(30);
            cola.Desencolar();
            cola.Encolar(40); // Demuestra la circularidad reutilizando espacio
        }
    }
}