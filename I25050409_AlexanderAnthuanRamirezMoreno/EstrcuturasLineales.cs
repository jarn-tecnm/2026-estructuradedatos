
using System;

// ======================================================
// 1. COLA CIRCULAR
// ======================================================

/*
CARACTERISTICAS:
- Sigue el principio FIFO (primero en entrar, primero en salir).
- El último espacio se conecta con el primero.
- Permite reutilizar los espacios vacíos del arreglo.
- Tiene un tamaño fijo.

APLICACIONES:
1. Administración de trabajos de impresión.
2. Gestión de paquetes de datos en redes.
3. Sistemas de atención por turnos.
*/

class ColaCircular
{
    private int[] datos;
    private int frente;
    private int final;
    private int cantidad;

    public ColaCircular(int capacidad)
    {
        datos = new int[capacidad];
        frente = 0;
        final = -1;
        cantidad = 0;
    }

    // Insertar elemento
    public void Enqueue(int valor)
    {
        if (cantidad == datos.Length)
        {
            Console.WriteLine("La cola está llena.");
            return;
        }

        final = (final + 1) % datos.Length;
        datos[final] = valor;
        cantidad++;

        Console.WriteLine("Elemento agregado: " + valor);
    }

    // Eliminar primer elemento
    public void Dequeue()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("La cola está vacía.");
            return;
        }

        Console.WriteLine("Elemento eliminado: " + datos[frente]);

        frente = (frente + 1) % datos.Length;
        cantidad--;
    }

    // Consultar primer elemento
    public void Peek()
    {
        if (cantidad > 0)
            Console.WriteLine("Primer elemento: " + datos[frente]);
        else
            Console.WriteLine("La cola está vacía.");
    }

    // Mostrar elementos
    public void Mostrar()
    {
        Console.Write("Cola circular: ");

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write(datos[(frente + i) % datos.Length] + " ");
        }

        Console.WriteLine();
    }
}


// ======================================================
// 2. BICOLA (COLA DE DOBLE EXTREMO)
// ======================================================

/*
CARACTERISTICAS:
- Permite insertar elementos por ambos extremos.
- Permite eliminar elementos por ambos extremos.
- Puede trabajar como una cola o una pila.
- También se conoce como Deque.

APLICACIONES:
1. Historial de navegación.
2. Administración de tareas prioritarias.
3. Algoritmos de búsqueda y recorrido.
*/

class Bicola
{
    private int[] datos;
    private int frente;
    private int final;
    private int cantidad;

    public Bicola(int capacidad)
    {
        datos = new int[capacidad];
        frente = 0;
        final = -1;
        cantidad = 0;
    }

    // Insertar por el frente
    public void InsertarFrente(int valor)
    {
        if (cantidad == datos.Length)
        {
            Console.WriteLine("La bicola está llena.");
            return;
        }

        frente = (frente - 1 + datos.Length) % datos.Length;
        datos[frente] = valor;

        if (cantidad == 0)
            final = frente;

        cantidad++;
        Console.WriteLine("Agregado al frente: " + valor);
    }

    // Insertar por el final
    public void InsertarFinal(int valor)
    {
        if (cantidad == datos.Length)
        {
            Console.WriteLine("La bicola está llena.");
            return;
        }

        final = (final + 1) % datos.Length;
        datos[final] = valor;

        if (cantidad == 0)
            frente = final;

        cantidad++;
        Console.WriteLine("Agregado al final: " + valor);
    }

    // Eliminar por el frente
    public void EliminarFrente()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("La bicola está vacía.");
            return;
        }

        Console.WriteLine("Eliminado del frente: " + datos[frente]);
        frente = (frente + 1) % datos.Length;
        cantidad--;
    }

    // Eliminar por el final
    public void EliminarFinal()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("La bicola está vacía.");
            return;
        }

        Console.WriteLine("Eliminado del final: " + datos[final]);
        final = (final - 1 + datos.Length) % datos.Length;
        cantidad--;
    }

    // Mostrar elementos
    public void Mostrar()
    {
        Console.Write("Bicola: ");

        for (int i = 0; i < cantidad; i++)
        {
            Console.Write(datos[(frente + i) % datos.Length] + " ");
        }

        Console.WriteLine();
    }
}


// ======================================================
// 3. LISTA DOBLEMENTE ENLAZADA
// ======================================================

/*
CARACTERISTICAS:
- Cada nodo contiene un dato.
- Cada nodo tiene una referencia al siguiente y al anterior.
- Permite recorrer la lista en ambas direcciones.
- Facilita insertar y eliminar elementos.

APLICACIONES:
1. Navegación hacia adelante y atrás.
2. Reproductores de música.
3. Historial de operaciones (deshacer y rehacer).
*/

class ListaDoble
{
    private class Nodo
    {
        public int dato;
        public Nodo siguiente;
        public Nodo anterior;

        public Nodo(int valor)
        {
            dato = valor;
        }
    }

    private Nodo cabeza;
    private Nodo cola;

    // Insertar al inicio
    public void InsertarInicio(int valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (cabeza == null)
        {
            cabeza = cola = nuevo;
        }
        else
        {
            nuevo.siguiente = cabeza;
            cabeza.anterior = nuevo;
            cabeza = nuevo;
        }
    }

    // Insertar al final
    public void InsertarFinal(int valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (cola == null)
        {
            cabeza = cola = nuevo;
        }
        else
        {
            cola.siguiente = nuevo;
            nuevo.anterior = cola;
            cola = nuevo;
        }
    }

    // Eliminar el primer nodo
    public void EliminarInicio()
    {
        if (cabeza == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.WriteLine("Eliminado: " + cabeza.dato);

        cabeza = cabeza.siguiente;

        if (cabeza == null)
            cola = null;
        else
            cabeza.anterior = null;
    }

    // Buscar un elemento
    public void Buscar(int valor)
    {
        Nodo actual = cabeza;

        while (actual != null)
        {
            if (actual.dato == valor)
            {
                Console.WriteLine("Elemento encontrado: " + valor);
                return;
            }

            actual = actual.siguiente;
        }

        Console.WriteLine("Elemento no encontrado.");
    }

    // Recorrer hacia adelante
    public void MostrarAdelante()
    {
        Nodo actual = cabeza;

        Console.Write("Lista doble: ");

        while (actual != null)
        {
            Console.Write(actual.dato + " ");
            actual = actual.siguiente;
        }

        Console.WriteLine();
    }

    // Recorrer hacia atrás
    public void MostrarAtras()
    {
        Nodo actual = cola;

        Console.Write("Recorrido inverso: ");

        while (actual != null)
        {
            Console.Write(actual.dato + " ");
            actual = actual.anterior;
        }

        Console.WriteLine();
    }
}


// ======================================================
// 4. LISTA CIRCULAR
// ======================================================

/*
CARACTERISTICAS:
- El último nodo apunta nuevamente al primero.
- No tiene un final marcado con null.
- Permite recorrer los elementos repetidamente.
- Puede implementarse utilizando nodos enlazados.

APLICACIONES:
1. Reproducción continua de canciones.
2. Turnos de jugadores en videojuegos.
3. Planificación de procesos del sistema operativo.
*/

class ListaCircular
{
    private class Nodo
    {
        public int dato;
        public Nodo siguiente;

        public Nodo(int valor)
        {
            dato = valor;
        }
    }

    private Nodo ultimo;

    // Insertar al final
    public void Insertar(int valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (ultimo == null)
        {
            ultimo = nuevo;
            nuevo.siguiente = nuevo;
        }
        else
        {
            nuevo.siguiente = ultimo.siguiente;
            ultimo.siguiente = nuevo;
            ultimo = nuevo;
        }
    }

    // Eliminar el primer elemento
    public void EliminarInicio()
    {
        if (ultimo == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo primero = ultimo.siguiente;

        Console.WriteLine("Eliminado: " + primero.dato);

        if (primero == ultimo)
            ultimo = null;
        else
            ultimo.siguiente = primero.siguiente;
    }

    // Buscar elemento
    public void Buscar(int valor)
    {
        if (ultimo == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = ultimo.siguiente;

        do
        {
            if (actual.dato == valor)
            {
                Console.WriteLine("Elemento encontrado: " + valor);
                return;
            }

            actual = actual.siguiente;

        } while (actual != ultimo.siguiente);

        Console.WriteLine("Elemento no encontrado.");
    }

    // Mostrar elementos
    public void Mostrar()
    {
        if (ultimo == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = ultimo.siguiente;

        Console.Write("Lista circular: ");

        do
        {
            Console.Write(actual.dato + " ");
            actual = actual.siguiente;

        } while (actual != ultimo.siguiente);

        Console.WriteLine();
    }
}


// ======================================================
// 5. LISTA CIRCULAR DOBLE
// ======================================================

/*
CARACTERISTICAS:
- Cada nodo tiene una referencia al siguiente y al anterior.
- El último nodo se conecta con el primero.
- El primer nodo también se conecta con el último.
- Permite recorrer la estructura en ambas direcciones.

APLICACIONES:
1. Carruseles de imágenes.
2. Reproductores de música con repetición.
3. Navegación entre elementos de una interfaz.
*/

class ListaCircularDoble
{
    private class Nodo
    {
        public int dato;
        public Nodo siguiente;
        public Nodo anterior;

        public Nodo(int valor)
        {
            dato = valor;
        }
    }

    private Nodo inicio;

    // Insertar al final
    public void Insertar(int valor)
    {
        Nodo nuevo = new Nodo(valor);

        if (inicio == null)
        {
            inicio = nuevo;
            nuevo.siguiente = nuevo;
            nuevo.anterior = nuevo;
        }
        else
        {
            Nodo ultimo = inicio.anterior;

            nuevo.siguiente = inicio;
            nuevo.anterior = ultimo;

            ultimo.siguiente = nuevo;
            inicio.anterior = nuevo;
        }
    }

    // Eliminar el primer elemento
    public void EliminarInicio()
    {
        if (inicio == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Console.WriteLine("Eliminado: " + inicio.dato);

        if (inicio.siguiente == inicio)
        {
            inicio = null;
        }
        else
        {
            Nodo ultimo = inicio.anterior;

            inicio = inicio.siguiente;
            inicio.anterior = ultimo;
            ultimo.siguiente = inicio;
        }
    }

    // Buscar elemento
    public void Buscar(int valor)
    {
        if (inicio == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = inicio;

        do
        {
            if (actual.dato == valor)
            {
                Console.WriteLine("Elemento encontrado: " + valor);
                return;
            }

            actual = actual.siguiente;

        } while (actual != inicio);

        Console.WriteLine("Elemento no encontrado.");
    }

    // Recorrer hacia adelante
    public void MostrarAdelante()
    {
        if (inicio == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = inicio;

        Console.Write("Circular doble adelante: ");

        do
        {
            Console.Write(actual.dato + " ");
            actual = actual.siguiente;

        } while (actual != inicio);

        Console.WriteLine();
    }

    // Recorrer hacia atrás
    public void MostrarAtras()
    {
        if (inicio == null)
        {
            Console.WriteLine("La lista está vacía.");
            return;
        }

        Nodo actual = inicio.anterior;

        Console.Write("Circular doble atrás: ");

        do
        {
            Console.Write(actual.dato + " ");
            actual = actual.anterior;

        } while (actual != inicio.anterior);

        Console.WriteLine();
    }
}


// ======================================================
// PROGRAMA PRINCIPAL
// ======================================================

class Program
{
    static void Main()
    {
        Console.WriteLine("===== 1. COLA CIRCULAR =====");

        ColaCircular cola = new ColaCircular(5);
        cola.Enqueue(10);
        cola.Enqueue(20);
        cola.Enqueue(30);
        cola.Mostrar();
        cola.Peek();
        cola.Dequeue();
        cola.Mostrar();


        Console.WriteLine("\n===== 2. BICOLA =====");

        Bicola bicola = new Bicola(5);
        bicola.InsertarFinal(10);
        bicola.InsertarFinal(20);
        bicola.InsertarFrente(5);
        bicola.Mostrar();
        bicola.EliminarFrente();
        bicola.EliminarFinal();
        bicola.Mostrar();


        Console.WriteLine("\n===== 3. LISTA DOBLEMENTE ENLAZADA =====");

        ListaDoble listaDoble = new ListaDoble();
        listaDoble.InsertarInicio(20);
        listaDoble.InsertarFinal(30);
        listaDoble.InsertarInicio(10);
        listaDoble.MostrarAdelante();
        listaDoble.MostrarAtras();
        listaDoble.Buscar(20);
        listaDoble.EliminarInicio();
        listaDoble.MostrarAdelante();


        Console.WriteLine("\n===== 4. LISTA CIRCULAR =====");

        ListaCircular listaCircular = new ListaCircular();
        listaCircular.Insertar(10);
        listaCircular.Insertar(20);
        listaCircular.Insertar(30);
        listaCircular.Mostrar();
        listaCircular.Buscar(20);
        listaCircular.EliminarInicio();
        listaCircular.Mostrar();


        Console.WriteLine("\n===== 5. LISTA CIRCULAR DOBLE =====");

        ListaCircularDoble circularDoble = new ListaCircularDoble();
        circularDoble.Insertar(10);
        circularDoble.Insertar(20);
        circularDoble.Insertar(30);
        circularDoble.MostrarAdelante();
        circularDoble.MostrarAtras();
        circularDoble.Buscar(20);
        circularDoble.EliminarInicio();
        circularDoble.MostrarAdelante();

        Console.WriteLine("\n===== FIN DEL PROGRAMA =====");
    }
}
