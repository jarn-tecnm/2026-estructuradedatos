using System;
class Program
{
    static void Main()
    {
        Console.WriteLine("======Menu======");
        Console.WriteLine("1. Calcular Factorial");
        Console.WriteLine("2. Calcular Fibonacci");
        Console.Write("Elige una opción (1 o 2): ");

        string opcion = Console.ReadLine();

        if( opcion == "1")
        {
            Console.Write("Ingresa un número para calcular su factorial: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"El factorial de {num} es: {Factorial.CalcularFactorial(num)}");
        }
        else if( opcion == "2")
        {
            Console.Write("Ingresa un número para calcular su Fibonacci: ");
            int num = int.Parse(Console.ReadLine());
            Console.WriteLine($"El Fibonacci de {num} es: {Fibonacci.FibonacciRecursivo(num)}");
        }
        else
        {
            Console.WriteLine("Opción no válida.");
        }
         
        
    }
}

    


