using System;

namespace MenuRecursivoApp
{
    class Program
    {
        static void Main(string[] args)
        {
            MostrarMenuPrincipal();
        }

        static void MostrarMenuPrincipal()
        {
            Console.Clear();
            Console.WriteLine("======================================");
            Console.WriteLine("======= MENÚ PRINCIPAL RECURSIVO =====");
            Console.WriteLine("======================================");
            Console.WriteLine("1. Menú de Opciones Interactivo");
            Console.WriteLine("2. Algoritmo de Multiplicación Recursiva");
            Console.WriteLine("3. Salir del programa");
            Console.WriteLine("--------------------------------------");
            Console.Write("Seleccione una opción: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    Console.Clear();
                    EjecutarProgramaMenu();
                    break;
                case "2":
                    Console.Clear();
                    EjecutarProgramaMultiplicacion();
                    break;
                case "3":
                    Console.WriteLine("\n¡Gracias por usar el programa! Saliendo...");
                    return; // Finaliza la ejecución del Main
                default:
                    Console.WriteLine("\n[Error] Opción inválida. Presione cualquier tecla para intentar de nuevo.");
                    Console.ReadKey();
                    MostrarMenuPrincipal(); // Recursividad para reintentar
                    break;
            }
        }
        #region PROGRAMA 1: Menú Interactivo con Submenú Final
        static void EjecutarProgramaMenu()
        {
            MostrarMenu();
            MenuFinal();
        }
        static void MostrarMenu()
        {
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("=========== MENU DE OPCIONES===========");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine("|1. Opción 1                         |");
            Console.WriteLine("|2. Opción 2                         |");
            Console.WriteLine("|3. Opción 3                         |");
            Console.WriteLine("|4. Opción 4                         |");
            Console.WriteLine("|5. Volver al Menú Principal         |");
            Console.WriteLine("--------------------------------------");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1": Console.WriteLine("Usted seleccionó la opción 1"); break;
                case "2": Console.WriteLine("Usted seleccionó la opción 2"); break;
                case "3": Console.WriteLine("Usted seleccionó la opción 3"); break;
                case "4": Console.WriteLine("Usted seleccionó la opción 4"); break;
                case "5":
                    Console.WriteLine("Volviendo al Menú Principal...");
                    MostrarMenuPrincipal();
                    return;
                default:
                    Console.WriteLine("Opción inválida. Por favor, seleccione una opción del menú.");
                    break;
            }
            Console.WriteLine("--------------------------------------");

            // Caso recursivo del menú si no elige salir
            if (opcion != "5")
            {
                MostrarMenu();
            }
        }
        static void MenuFinal()
        {
            Console.WriteLine("\n=========== OPCIONES FINALES ==========");
            Console.WriteLine("1. Volver al menú de opciones");
            Console.WriteLine("2. Volver al Menú Principal");
            Console.WriteLine("3. Salir del programa");
            Console.WriteLine("======================================");
            Console.Write("Seleccione una opción: ");
            
            string opcion = Console.ReadLine();
            
            switch (opcion)
            {
                case "1":
                    MostrarMenu();
                    MenuFinal();
                    break;
                case "2":
                    MostrarMenuPrincipal();
                    break;
                case "3":
                    Console.WriteLine("Saliendo del programa...");
                    return;
                default:
                    Console.WriteLine("Opción inválida. Intente de nuevo.");
                    MenuFinal();
                    break;
            }
        }
        #endregion

        #region PROGRAMA 2: Multiplicación por Sumas Sucesivas (Recursivo)
        static void EjecutarProgramaMultiplicacion()
        {
            Console.WriteLine("\n--- Multiplicación por Recursividad ---");
            Console.Write("Introduce el primer número (a): ");
            int a = int.Parse(Console.ReadLine());

            Console.Write("Introduce el segundo número (b): ");
            int b = int.Parse(Console.ReadLine());

            int resultado = MultiplicarRecursivo(a, b);
            Console.WriteLine($"\nEl resultado de {a} x {b} es: {resultado}\n");

            Console.WriteLine("¿Qué deseas hacer ahora?");
            Console.WriteLine("1. Realizar otra multiplicación");
            Console.WriteLine("2. Volver al Menú Principal");
            Console.Write("Seleccione una opción: ");
            string opcion = Console.ReadLine();

            if (opcion == "1")
            {
                EjecutarProgramaMultiplicacion(); 
            }
            else
            {
                MostrarMenuPrincipal();
            }
        }
        static int MultiplicarRecursivo(int a, int b)
        {
            if (b == 0)
            {
                return 0;
            }
            else if (b > 0)
            {
                return a + MultiplicarRecursivo(a, b - 1);
            }
            else
            {
                return -MultiplicarRecursivo(a, -b);
            }
        }
       #endregion
    }
}