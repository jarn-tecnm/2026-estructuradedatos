using System.Diagnostics;

/*
 * Comparación de Burbuja y Quicksort
 * Caso simulado: cantidad de residuos recolectados (en kg) por ruta de camión.
 *
 * - Cada método recibe una COPIA de los mismos datos.
 * - Se verifica el resultado contra Array.Sort (orden esperado).
 * - Se cuentan las comparaciones entre valores (no las de índices).
 * - El tiempo se mide con Stopwatch y se reporta en milisegundos (ms).
 */
internal static class Program
{
    // Contador global de comparaciones entre valores; se reinicia antes de cada método.
    private static long _comparaciones;

    // Toda comparación entre valores pasa por aquí para poder contarla.
    private static bool Menor(int a, int b)  { _comparaciones++; return a < b; }
    private static bool Mayor(int a, int b)  { _comparaciones++; return a > b; }

    // ---------------------------------------------------------------
    // Burbuja (con bandera: se detiene si una pasada no hizo intercambios)
    // ---------------------------------------------------------------
    private static void Burbuja(int[] a)
    {
        for (int pasada = 0; pasada < a.Length - 1; pasada++)
        {
            bool huboCambio = false;
            for (int j = 0; j < a.Length - 1 - pasada; j++)
            {
                if (Mayor(a[j], a[j + 1]))
                {
                    (a[j], a[j + 1]) = (a[j + 1], a[j]);
                    huboCambio = true;
                }
            }
            if (!huboCambio) break;
        }
    }

    // ---------------------------------------------------------------
    // Quicksort (pivote central, partición de Hoare).
    // Se recurre sobre la partición más pequeña y se itera sobre la
    // otra, para que la profundidad de la pila sea O(log n).
    // ---------------------------------------------------------------
    private static void Quicksort(int[] a, int bajo, int alto)
    {
        while (bajo < alto)
        {
            int pivote = a[bajo + (alto - bajo) / 2];
            int i = bajo, j = alto;

            while (i <= j)
            {
                while (Menor(a[i], pivote)) i++;
                while (Mayor(a[j], pivote)) j--;
                if (i <= j)
                {
                    (a[i], a[j]) = (a[j], a[i]);
                    i++;
                    j--;
                }
            }

            if (j - bajo < alto - i) { Quicksort(a, bajo, j); bajo = i; }
            else                     { Quicksort(a, i, alto); alto = j; }
        }
    }

    // ---------------------------------------------------------------
    // Utilidades
    // ---------------------------------------------------------------
    private static int[] GenerarAleatorios(int n, int semilla)
    {
        var rnd = new Random(semilla);               // semilla fija: resultados reproducibles
        var datos = new int[n];
        for (int i = 0; i < n; i++) datos[i] = rnd.Next(50, 5001); // kg por ruta
        return datos;
    }

    private static bool EstaOrdenado(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
            if (a[i - 1] > a[i]) return false;
        return true;
    }

    private record Resultado(string Escenario, string Metodo, long Comparaciones, double Ms, bool Correcto);

    private static Resultado Ejecutar(string escenario, string metodo, int[] original, int[] esperado)
    {
        int[] copia = (int[])original.Clone();       // cada método trabaja con su propia copia
        _comparaciones = 0;

        var sw = Stopwatch.StartNew();
        if (metodo == "Burbuja") Burbuja(copia);
        else                     Quicksort(copia, 0, copia.Length - 1);
        sw.Stop();

        bool correcto = EstaOrdenado(copia) && copia.SequenceEqual(esperado);
        return new Resultado(escenario, metodo, _comparaciones, sw.Elapsed.TotalMilliseconds, correcto);
    }

    private static void Main(string[] args)
    {
        int n = args.Length > 0 && int.TryParse(args[0], out int v) && v > 1 ? v : 5000;

        Console.WriteLine("=== Burbuja vs Quicksort: residuos recolectados por ruta (kg) ===");
        Console.WriteLine($"Cantidad de datos (n): {n:N0}   |   Tiempo reportado en milisegundos (ms)\n");

        // Muestra pequeña para ver el ordenamiento a simple vista
        int[] muestra = GenerarAleatorios(10, 7);
        int[] muestraB = (int[])muestra.Clone();
        int[] muestraQ = (int[])muestra.Clone();
        Burbuja(muestraB);
        Quicksort(muestraQ, 0, muestraQ.Length - 1);
        Console.WriteLine("Muestra (n = 10):");
        Console.WriteLine("  Original : " + string.Join(", ", muestra));
        Console.WriteLine("  Burbuja  : " + string.Join(", ", muestraB));
        Console.WriteLine("  Quicksort: " + string.Join(", ", muestraQ) + "\n");

        // Tres conjuntos: aleatorio, ascendente y descendente (mismos valores en los tres)
        int[] aleatorio = GenerarAleatorios(n, 42);
        int[] ascendente = (int[])aleatorio.Clone();
        Array.Sort(ascendente);
        int[] descendente = (int[])ascendente.Clone();
        Array.Reverse(descendente);

        var escenarios = new (string Nombre, int[] Datos)[]
        {
            ("Aleatorio",  aleatorio),
            ("Ascendente", ascendente),
            ("Descendente", descendente)
        };

        // Calentamiento para que la compilación JIT no distorsione la primera medición
        int[] calentamiento = GenerarAleatorios(200, 1);
        int[] esperadoCal = (int[])calentamiento.Clone();
        Array.Sort(esperadoCal);
        Ejecutar("Calentamiento", "Burbuja", calentamiento, esperadoCal);
        Ejecutar("Calentamiento", "Quicksort", calentamiento, esperadoCal);

        var resultados = new List<Resultado>();
        foreach (var (nombre, datos) in escenarios)
        {
            int[] esperado = (int[])datos.Clone();
            Array.Sort(esperado);                     // orden esperado de referencia

            resultados.Add(Ejecutar(nombre, "Burbuja", datos, esperado));
            resultados.Add(Ejecutar(nombre, "Quicksort", datos, esperado));
        }

        // Tabla de resultados
        string linea = new string('-', 78);
        Console.WriteLine(linea);
        Console.WriteLine($"{"Escenario",-13}{"Método",-11}{"Comparaciones",16}{"Tiempo (ms)",16}{"¿Correcto?",12}");
        Console.WriteLine(linea);
        foreach (var r in resultados)
        {
            Console.WriteLine($"{r.Escenario,-13}{r.Metodo,-11}{r.Comparaciones,16:N0}{r.Ms,16:F4}{(r.Correcto ? "Sí" : "NO"),12}");
        }
        Console.WriteLine(linea);

        Console.WriteLine(resultados.All(r => r.Correcto)
            ? "\nVerificación: todas las pruebas coinciden con el orden esperado."
            : "\nATENCIÓN: al menos una prueba NO produjo el orden esperado.");

        Console.WriteLine("\nNota: los tiempos varían entre equipos y ejecuciones; las comparaciones no.");
    }
}