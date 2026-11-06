
using System;

class Program
{
    // Metodo principal
    static void Main()
    {
        int opcion;

        do
        {
            Console.Clear();

            Console.WriteLine("===== MENU DE RECURSIVIDAD =====");
            Console.WriteLine("1. Factorial de un numero");
            Console.WriteLine("2. Cuenta regresiva");
            Console.WriteLine("3. Invertir una cadena");
            Console.WriteLine("4. Sumar numeros del 1 hasta N");
            Console.WriteLine("5. Calcular potencia de un numero");
            Console.WriteLine("6. Salir");

            Console.Write("\nElige una opcion: ");
            opcion = Convert.ToInt32(Console.ReadLine());

            switch (opcion)
            {
                case 1:
                    // Solicita un numero y calcula su factorial
                    Console.Write("Escribe un numero: ");
                    int num = Convert.ToInt32(Console.ReadLine());//Convert.ToInt32: convierte lo escrito en un número entero.

                    if (num < 0)
                        Console.WriteLine("No se aceptan numeros negativos.");
                    else
                        Console.WriteLine("Factorial: " + Factorial(num));
                    break;

                case 2:
                    // Realiza una cuenta regresiva
                    Console.Write("Escribe un numero: ");
                    int cuenta = Convert.ToInt32(Console.ReadLine());

                    CuentaRegresiva(cuenta);
                    break;

                case 3:
                    // Invierte el texto escrito
                    Console.Write("Escribe una palabra: ");
                    string palabra = Console.ReadLine();

                    Console.WriteLine("Cadena invertida: " +
                        Invertir(palabra));
                    break;

                case 4:
                    // Suma todos los numeros desde 1 hasta N
                    Console.Write("Escribe un numero: ");
                    int suma = Convert.ToInt32(Console.ReadLine());

                    if (suma < 0)
                        Console.WriteLine("Escribe un numero positivo.");
                    else
                        Console.WriteLine("Resultado: " + Sumar(suma));
                    break;

                case 5:
                    // Calcula la potencia de un numero
                    Console.Write("Escribe la base: ");
                    int baseNum = Convert.ToInt32(Console.ReadLine());

                    Console.Write("Escribe el exponente: ");
                    int exponente = Convert.ToInt32(Console.ReadLine());

                    if (exponente < 0)
                        Console.WriteLine("Usa un exponente positivo.");
                    else
                        Console.WriteLine("Resultado: " +
                            Potencia(baseNum, exponente));
                    break;

                case 6:
                    Console.WriteLine("Programa finalizado.");
                    break;

                default:
                    Console.WriteLine("Opcion no valida, favor de intentarlo de nuevo con una opcion valida.");
                    break;
            }

            if (opcion != 6)
            {
                Console.WriteLine("\nPresiona una tecla para continuar...");
                Console.ReadKey();
            }

        } while (opcion != 6);
    }

    // 1. Calcula el factorial de un numero
    static int Factorial(int n)
    {
        if (n == 0 || n == 1)
            return 1; // Caso base si se cumple, devuelve 1 y termina la recursividad.

        return n * Factorial(n - 1);//multiplica el número por el resultado de volver a llamar al mismo método con un número menor.
    }

    // 2. Muestra una cuenta regresiva
    static void CuentaRegresiva(int n)
    {
        if (n < 0)
            return; // Caso base

        Console.WriteLine(n);

        

        CuentaRegresiva(n - 1);
    }

    // 3. Invierte una cadena de texto
    static string Invertir(string texto)
    {
        if (texto.Length <= 1)//texto.Substring(1)obtiene el texto quitando su primer carácter
            return texto; // Caso base

        return Invertir(texto.Substring(1)) + texto[0];//: vuelve a llamar al método con el resto de la palabra y coloca la primera letra al final.
    }

    // 4. Suma los numeros desde 1 hasta N
    static int Sumar(int n)
    {
        if (n == 0)
            return 0; // Caso base

        return n + Sumar(n - 1);//suma el número actual con el resultado de volver a llamar al método con un número menor.
    }

    // 5. Calcula la potencia de un numero
    static int Potencia(int numero, int exponente)//crea un método que recibe la base y el exponente.
    {
        if (exponente == 0)
            return 1; // Caso base

        return numero * Potencia(numero, exponente - 1);//Después multiplica la base por sí misma, reduciendo el exponente en uno en cada llamada, hasta llegar a cero
    }
}

//La recursividad es una técnica de programación en la que un método se llama a sí mismo
//  para resolver un problema. Cada vez que se repite, el problema se acerca a una solución 
// hasta llegar a un caso base, que es la condición que detiene las llamadas.