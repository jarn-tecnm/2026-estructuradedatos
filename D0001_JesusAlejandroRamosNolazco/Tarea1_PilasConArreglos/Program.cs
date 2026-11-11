using System;

class Program
{
    static void Main()
    {

        Console.WriteLine("¿Cuántos números quieres guardar?");

        if(!int.TryParse(Console.ReadLine(), out int n) || n < 1 || n > 1000000)
        {
            Console.WriteLine("Escribe un número entre 1 y 1,000,000");
            return;
        }

        int[] numeros = new int[n];
        long suma = 0;
        int iteraciones = 0;

        for(int i = 0; i < n; i++)
        {
            numeros[i] = i + 1;
            suma += numeros[i];

            // Contador agregado para explicar el trabajo del ciclo.
            iteraciones++;
        }

        // Cada elemento int ocupa 4 bytes
        long memoriaDatos = (long)n * sizeof(int);

        Console.WriteLine("\n--- RESULTADOS ---");
        Console.WriteLine($"Cantidad de números: {n:N0}");
        Console.WriteLine($"Suma: {suma:N0}");
        Console.WriteLine($"Iteraciones del ciclo: {iteraciones:N0}");

        Console.WriteLine("\n--- MEMORIA DE LOS ELEMENTOS ---");
        Console.WriteLine($"{n:N0} elementos x 4 bytes = {memoriaDatos:N0} bytes");
        Console.WriteLine($"Equivalente: {memoriaDatos / 1024.0:N2} KiB");

        Console.WriteLine("\n--- COMPLEJIDAD ---");
        Console.WriteLine($"Tiempo: O(n), porque el ciclo se repite n veces");
        Console.WriteLine($"Espacios: O(n), porque el arreglo contiene n elementos");
    }
    
}
