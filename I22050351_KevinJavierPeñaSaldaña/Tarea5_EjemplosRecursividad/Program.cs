using System;
using System.Collections.Generic;
using System.Text;

namespace EjemplosRecursividad
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("=== EJEMPLOS DE RECURSIVIDAD EN C# ===\n");

            // 1. Factorial
            Console.WriteLine("1) Factorial");
            int n = 5;
            Console.WriteLine($"   {n}! = {Factorial(n)}\n");

            // 2. Fibonacci
            Console.WriteLine("2) Serie de Fibonacci (primeros 10 términos)");
            Console.Write("   ");
            for (int i = 0; i < 10; i++)
                Console.Write(Fibonacci(i) + " ");
            Console.WriteLine("\n");

            // 3. Suma de dígitos
            Console.WriteLine("3) Suma de los dígitos de un número");
            int numero = 98765;
            Console.WriteLine($"   La suma de los dígitos de {numero} es {SumaDigitos(numero)}\n");

            // 4. Invertir una cadena
            Console.WriteLine("4) Invertir una cadena");
            string texto = "Recursividad";
            Console.WriteLine($"   \"{texto}\" invertida: \"{Invertir(texto)}\"\n");

            // 5. Palíndromo
            Console.WriteLine("5) Verificar palíndromo");
            string[] palabras = { "anitalavalatina", "recursividad", "reconocer" };
            foreach (string p in palabras)
                Console.WriteLine($"   \"{p}\" es palíndromo: {EsPalindromo(p, 0, p.Length - 1)}");
            Console.WriteLine();

            // 6. Búsqueda binaria recursiva
            Console.WriteLine("6) Búsqueda binaria");
            int[] arreglo = { 2, 5, 8, 12, 16, 23, 38, 45, 56, 72, 91 };
            int buscado = 23;
            int pos = BusquedaBinaria(arreglo, buscado, 0, arreglo.Length - 1);
            Console.WriteLine(pos >= 0
                ? $"   El número {buscado} se encontró en la posición {pos}\n"
                : $"   El número {buscado} no se encontró\n");

            // 7. Torres de Hanói
            Console.WriteLine("7) Torres de Hanói con 3 discos");
            int movimientos = 0;
            Hanoi(3, 'A', 'C', 'B', ref movimientos);
            Console.WriteLine($"   Total de movimientos: {movimientos}\n");

            // 8. Permutaciones de una cadena
            Console.WriteLine("8) Permutaciones de \"ABC\"");
            var resultado = new List<string>();
            Permutaciones("", "ABC", resultado);
            Console.WriteLine("   " + string.Join(", ", resultado) + "\n");

            Console.WriteLine("Presiona cualquier tecla para salir...");
            Console.ReadKey();
        }

        // 1. n! = n * (n-1)!   |   caso base: 0! = 1
        static long Factorial(int n)
        {
            if (n <= 1) return 1;
            return n * Factorial(n - 1);
        }

        // 2. F(n) = F(n-1) + F(n-2)   |   casos base: F(0)=0, F(1)=1
        static int Fibonacci(int n)
        {
            if (n == 0) return 0;
            if (n == 1) return 1;
            return Fibonacci(n - 1) + Fibonacci(n - 2);
        }

        // 3. Suma el último dígito + la suma del resto del número
        static int SumaDigitos(int n)
        {
            if (n < 10) return n;
            return (n % 10) + SumaDigitos(n / 10);
        }

        // 4. Última letra + inversión del resto
        static string Invertir(string s)
        {
            if (s.Length <= 1) return s;
            return s[s.Length - 1] + Invertir(s.Substring(0, s.Length - 1));
        }

        // 5. Compara extremos y avanza hacia el centro
        static bool EsPalindromo(string s, int inicio, int fin)
        {
            if (inicio >= fin) return true;
            if (char.ToLower(s[inicio]) != char.ToLower(s[fin])) return false;
            return EsPalindromo(s, inicio + 1, fin - 1);
        }

        // 6. Divide el arreglo ordenado a la mitad en cada llamada
        static int BusquedaBinaria(int[] arr, int valor, int izq, int der)
        {
            if (izq > der) return -1; // no encontrado

            int medio = (izq + der) / 2;
            if (arr[medio] == valor) return medio;

            if (valor < arr[medio])
                return BusquedaBinaria(arr, valor, izq, medio - 1);
            else
                return BusquedaBinaria(arr, valor, medio + 1, der);
        }

        // 7. Mueve n-1 discos al auxiliar, el mayor al destino y luego n-1 al destino
        static void Hanoi(int n, char origen, char destino, char auxiliar, ref int contador)
        {
            if (n == 0) return;

            Hanoi(n - 1, origen, auxiliar, destino, ref contador);
            contador++;
            Console.WriteLine($"   Mover disco {n} de {origen} a {destino}");
            Hanoi(n - 1, auxiliar, destino, origen, ref contador);
        }

        // 8. Fija una letra y permuta el resto
        static void Permutaciones(string prefijo, string resto, List<string> resultado)
        {
            if (resto.Length == 0)
            {
                resultado.Add(prefijo);
                return;
            }

            for (int i = 0; i < resto.Length; i++)
            {
                string nuevoResto = resto.Substring(0, i) + resto.Substring(i + 1);
                Permutaciones(prefijo + resto[i], nuevoResto, resultado);
            }
        }
    }
}
