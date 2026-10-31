//Ejemplo 2: Secuencia de numeros de Fibonacci
// Esta serie numerica es un ejemplo tipico de cumplimiento de dos propiedades generales, de todo procedimiento recursivo
// La serie de fibonacci es:
// 0,0,1,1,2,3,5,8,13,21,34,55,89,144...
// El termino inicial es 0, el segundo termino es 1 y a partir de ahi cada termino es la suma de los terminos precedentes
// exepto 0 y 1.
// La serie puede ser definida de manera recursiva como:
// fibonacci(n) = n si n = 0 o n = 1
// fibonacci(n) = fibonacci(n-2) + fibonacci(n-1) para n > 1

// Esta definicion recursiva hace referencia a ella misma dos veces. Y la condicion para que dejen de hacerse llamadas recursivas
// es que n sea 0 o 1. La llamada recursiva se hace en terminos menores de n, n-2, por lo que se va acercando a los valores 
// de los que depende la terminacion.

public class Fibonacci {
    public static int FibonacciRecursivo(int n) {
        //caso base
        if (n <= 1) {
            return n;
        }
        //caso recursivo
        return FibonacciRecursivo(n - 1) + FibonacciRecursivo(n - 2);
    }

    
}
