// La recursión es básicamente cuando una función se llama a sí misma para resolver un problema. 
// Es como decirle a alguien "para llegar a tu casa, primero llega a tu casa". 
// Pero en realidad tiene mucho sentido cuando lo ves en acción.
// La clave está en dividir un problema grande en pedacitos más pequeños, 
// como pelar una cebolla capa por capa hasta llegar al centro. Cada "capa" es una versión más pequeña del mismo problema.

// //Elementos que no pueden faltar (nunca)
// Para que una función recursiva funcione y no se vuelva loca, necesita estos tres elementos:
// Caso base: El momento donde dice "ok, ya llegué, aquí paro"
// Caso recursivo: Donde se llama a sí misma con una versión más pequeña del problema
// Progresión: Cada llamada tiene que acercarte más al final, no alejarte

// Ejemplo 1: Calcular el factorial de un número
public class Factorial
{
   public static int CalcularFactorial(int n) {
        //caso base
        if (n <= 1) {
            return 1;
        }
        //caso recursivo
        return n * CalcularFactorial(n - 1);
    }
}
 