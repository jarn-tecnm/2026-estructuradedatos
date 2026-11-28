using System;
using System.Diagnostics;

namespace Tarea5_2_BurbujaVsQuicksort
{
    class ResultadoPrueba
    {
        public string Escenario { get; set; } = "";
        public string Metodo { get; set; } = "";
        public long Comparaciones { get; set; }
        public double TiempoMs { get; set; }
        public double TiempoUs { get; set; }
        public bool OrdenCorrecto { get; set; }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Caso de estudio: 10,000 mediciones de temperatura (°C) registradas por sensores industriales
            const int cantidadDatos = 10000;
            Console.WriteLine("===================================================================================");
            Console.WriteLine("   COMPARATIVA DE ORDENAMIENTO: BURBUJA VS QUICKSORT (MEDICIONES DE TEMPERATURA)");
            Console.WriteLine($"   Total de registros por prueba: {cantidadDatos:N0} lecturas (°C)");
            Console.WriteLine("===================================================================================\n");

            // Generar los tres conjuntos base de datos
            double[] datosAleatorios = GenerarTemperaturasAleatorias(cantidadDatos, semilla: 42);
            double[] datosAscendentes = (double[])datosAleatorios.Clone();
            Array.Sort(datosAscendentes);

            double[] datosDescendentes = (double[])datosAscendentes.Clone();
            Array.Reverse(datosDescendentes);

            // Calentamiento breve del JIT para evitar sesgos en la primera medición
            double[] warmup = { 25.4, 19.1, 31.0, 22.8 };
            OrdenarBurbuja((double[])warmup.Clone(), out _);
            OrdenarQuicksort((double[])warmup.Clone(), out _);

            // Ejecutar pruebas sobre copias exactas de los mismos datos
            ResultadoPrueba[] resultados = new ResultadoPrueba[]
            {
                EjecutarPrueba("1. Aleatorio",   "Burbuja",   datosAleatorios),
                EjecutarPrueba("1. Aleatorio",   "Quicksort", datosAleatorios),
                EjecutarPrueba("2. Ascendente",  "Burbuja",   datosAscendentes),
                EjecutarPrueba("2. Ascendente",  "Quicksort", datosAscendentes),
                EjecutarPrueba("3. Descendente", "Burbuja",   datosDescendentes),
                EjecutarPrueba("3. Descendente", "Quicksort", datosDescendentes)
            };

            // Resumen en tabla
            ImprimirTablaResultados(resultados);

            // Interpretación y justificación
            ImprimirAnalisisYJustificacion();
        }

        static double[] GenerarTemperaturasAleatorias(int n, int semilla)
        {
            Random rnd = new Random(semilla);
            double[] datos = new double[n];
            for (int i = 0; i < n; i++)
            {
                // Temperaturas simuladas entre 15.00 °C y 45.00 °C
                datos[i] = Math.Round(15.0 + rnd.NextDouble() * 30.0, 2);
            }
            return datos;
        }

        static ResultadoPrueba EjecutarPrueba(string escenario, string metodo, double[] datosOriginales)
        {
            // Se usa una copia independiente para garantizar exactamente los mismos datos de entrada
            double[] copiaDatos = (double[])datosOriginales.Clone();
            long comparaciones = 0;

            Stopwatch cronometro = Stopwatch.StartNew();
            if (metodo == "Burbuja")
            {
                OrdenarBurbuja(copiaDatos, out comparaciones);
            }
            else
            {
                OrdenarQuicksort(copiaDatos, out comparaciones);
            }
            cronometro.Stop();

            double tiempoMs = cronometro.Elapsed.TotalMilliseconds;
            double tiempoUs = cronometro.Elapsed.TotalMicroseconds;
            bool ordenado = EstaOrdenadoAscendente(copiaDatos);

            return new ResultadoPrueba
            {
                Escenario = escenario,
                Metodo = metodo,
                Comparaciones = comparaciones,
                TiempoMs = tiempoMs,
                TiempoUs = tiempoUs,
                OrdenCorrecto = ordenado
            };
        }

        // --- ALGORITMO 1: BUBBLE SORT (BURBUJA) ---
        static void OrdenarBurbuja(double[] arr, out long comparaciones)
        {
            comparaciones = 0;
            int n = arr.Length;
            bool huboIntercambio;

            for (int i = 0; i < n - 1; i++)
            {
                huboIntercambio = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    comparaciones++;
                    if (arr[j] > arr[j + 1])
                    {
                        double temp = arr[j];
                        arr[j] = arr[j + 1];
                        arr[j + 1] = temp;
                        huboIntercambio = true;
                    }
                }
                // Optimización: si no hubo intercambios en la pasada, el arreglo ya está ordenado
                if (!huboIntercambio)
                    break;
            }
        }

        // --- ALGORITMO 2: QUICKSORT (CON PIVOTE MEDIANA DE TRES) ---
        static void OrdenarQuicksort(double[] arr, out long comparaciones)
        {
            comparaciones = 0;
            if (arr.Length > 1)
            {
                QuicksortRecursivo(arr, 0, arr.Length - 1, ref comparaciones);
            }
        }

        static void QuicksortRecursivo(double[] arr, int izquierda, int derecha, ref long comparaciones)
        {
            if (izquierda >= derecha)
                return;

            int indicePivote = Particionar(arr, izquierda, derecha, ref comparaciones);
            QuicksortRecursivo(arr, izquierda, indicePivote - 1, ref comparaciones);
            QuicksortRecursivo(arr, indicePivote + 1, derecha, ref comparaciones);
        }

        static int Particionar(double[] arr, int izquierda, int derecha, ref long comparaciones)
        {
            // Selección de pivote usando mediana de tres (evita desbordamiento de pila O(n^2) en datos ordenados)
            int medio = izquierda + (derecha - izquierda) / 2;
            if (arr[medio] < arr[izquierda]) Intercambiar(arr, izquierda, medio);
            if (arr[derecha] < arr[izquierda]) Intercambiar(arr, izquierda, derecha);
            if (arr[medio] < arr[derecha]) Intercambiar(arr, medio, derecha);

            double pivote = arr[derecha];
            int i = izquierda - 1;

            for (int j = izquierda; j < derecha; j++)
            {
                comparaciones++;
                if (arr[j] <= pivote)
                {
                    i++;
                    Intercambiar(arr, i, j);
                }
            }

            Intercambiar(arr, i + 1, derecha);
            return i + 1;
        }

        static void Intercambiar(double[] arr, int a, int b)
        {
            if (a == b) return;
            double temp = arr[a];
            arr[a] = arr[b];
            arr[b] = temp;
        }

        // Verificación de integridad del ordenamiento
        static bool EstaOrdenadoAscendente(double[] arr)
        {
            for (int i = 0; i < arr.Length - 1; i++)
            {
                if (arr[i] > arr[i + 1])
                    return false;
            }
            return true;
        }

        static void ImprimirTablaResultados(ResultadoPrueba[] resultados)
        {
            Console.WriteLine("-----------------------------------------------------------------------------------");
            Console.WriteLine($"| {"Orden Inicial",-14} | {"Algoritmo",-10} | {"Comparaciones",15} | {"Tiempo (ms)",12} | {"Tiempo (µs)",12} | {"¿Ordenado?",-10} |");
            Console.WriteLine("-----------------------------------------------------------------------------------");

            foreach (var r in resultados)
            {
                string estado = r.OrdenCorrecto ? "Sí (OK)" : "Error";
                Console.WriteLine($"| {r.Escenario,-14} | {r.Metodo,-10} | {r.Comparaciones,15:N0} | {r.TiempoMs,12:F4} | {r.TiempoUs,12:F1} | {estado,-10} |");
            }

            Console.WriteLine("-----------------------------------------------------------------------------------\n");
        }

        static void ImprimirAnalisisYJustificacion()
        {
            Console.WriteLine("INTERPRETACIÓN DE RESULTADOS Y ELECCIÓN PARA EL CASO DE ESTUDIO:");
            Console.WriteLine("1. Escenario Aleatorio y Descendente: Burbuja realiza cerca de n*(n-1)/2 comparaciones");
            Console.WriteLine("   (~50 millones para 10,000 datos, complejidad O(n^2)), tardando decenas o cientos de");
            Console.WriteLine("   milisegundos. Quicksort reduce las comparaciones a ~150,000 (complejidad O(n log n)),");
            Console.WriteLine("   completando la tarea en menos de 2 milisegundos.");
            Console.WriteLine("2. Escenario Ascendente: Gracias a la bandera de parada temprana, Burbuja detecta que");
            Console.WriteLine("   no hubo intercambios en la primera pasada (n - 1 comparaciones, O(n)). Sin embargo,");
            Console.WriteLine("   en sensores reales las lecturas nunca llegan estrictamente ordenadas.");
            Console.WriteLine("3. Elección: Para ordenar mediciones de temperatura en tiempo real o por lotes se elige");
            Console.WriteLine("   QUICKSORT (con pivote mediana de tres), ya que ofrece un rendimiento estable y");
            Console.WriteLine("   escalable O(n log n) en cualquier distribución sin degradarse ante datos invertidos.");
        }
    }
}