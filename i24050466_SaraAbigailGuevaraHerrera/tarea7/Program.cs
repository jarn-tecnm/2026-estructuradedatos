
using System;

// ======================================================
// MENU PRINCIPAL
// ======================================================


class Program
{
    static void Main()
    {
        ColaCircular cola = new ColaCircular(10);
        Bicola bicola = new Bicola(10);
        ListaDoble listaDoble = new ListaDoble();
        ListaCircular listaCircular = new ListaCircular();
        ListaCircularDoble listaCircularDoble = new ListaCircularDoble();

        int opcion;

        do
        {
            Console.Clear();
            Console.WriteLine("===== ESTRUCTURAS DE DATOS =====");
            Console.WriteLine("1. Cola circular");
            Console.WriteLine("2. Bicola");
            Console.WriteLine("3. Lista doblemente enlazada");
            Console.WriteLine("4. Lista circular");
            Console.WriteLine("5. Lista circular doble");
            Console.WriteLine("6. Salir");
            Console.Write("Selecciona una estructura: ");

            opcion = LeerNumero();

            switch (opcion)
            {
                case 1: MenuCola(cola); break;
                case 2: MenuBicola(bicola); break;
                case 3: MenuDoble(listaDoble); break;
                case 4: MenuCircular(listaCircular); break;
                case 5: MenuCircularDoble(listaCircularDoble); break;
                case 6: Console.WriteLine("Programa finalizado."); break;
                default: Pausa("Opcion no valida."); break;
            }

        } while (opcion != 6);
    }

    static int LeerNumero()
    {
        int numero;
        while (!int.TryParse(Console.ReadLine(), out numero))
            Console.Write("Ingresa un numero valido: ");

        return numero;
    }

    static void Pausa(string mensaje = "")
    {
        Console.WriteLine(mensaje);
        Console.WriteLine("\nPresiona ENTER para continuar...");
        Console.ReadLine();
    }

    // ==================================================
    // MENU DE COLA CIRCULAR
    // ==================================================

    static void MenuCola(ColaCircular cola)

    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("===== COLA CIRCULAR =====");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Modificar");
            Console.WriteLine("3. Eliminar (desencolar)");
            Console.WriteLine("4. Mostrar");
            Console.WriteLine("5. Regresar");
            Console.Write("Selecciona una accion: ");

            op = LeerNumero();

            switch (op)
            {
                case 1:
                    Console.Write("Dato: ");
                    cola.Agregar(Console.ReadLine() ?? "");
                    break;

                case 2:
                    Console.Write("Posicion: ");
                    int p = LeerNumero();
                    Console.Write("Nuevo dato: ");
                    cola.Modificar(p, Console.ReadLine() ?? "");
                    break;

                case 3:
                    cola.Eliminar();
                    break;

                case 4:
                    cola.Mostrar();
                    break;
            }

            if (op != 5) Pausa();

        } while (op != 5);
    }

    // ==================================================
    // MENU DE BICOLA
    // ==================================================

    static void MenuBicola(Bicola bicola)
    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("===== BICOLA =====");
            Console.WriteLine("1. Agregar al inicio");
            Console.WriteLine("2. Agregar al final");
            Console.WriteLine("3. Eliminar del inicio");
            Console.WriteLine("4. Eliminar del final");
            Console.WriteLine("5. Modificar");
            Console.WriteLine("6. Mostrar");
            Console.WriteLine("7. Regresar");
            Console.Write("Selecciona una accion: ");

            op = LeerNumero();

            switch (op)
            {
                case 1:
                    Console.Write("Dato: ");
                    bicola.AgregarInicio(Console.ReadLine() ?? "");
                    break;

                case 2:
                    Console.Write("Dato: ");
                    bicola.AgregarFinal(Console.ReadLine() ?? "");
                    break;

                case 3: bicola.EliminarInicio(); break;
                case 4: bicola.EliminarFinal(); break;

                case 5:
                    Console.Write("Posicion: ");
                    int p = LeerNumero();
                    Console.Write("Nuevo dato: ");
                    bicola.Modificar(p, Console.ReadLine() ?? "");
                    break;

                case 6: bicola.Mostrar(); break;
            }

            if (op != 7) Pausa();

        } while (op != 7);
    }

    // ==================================================
    // MENU DE LISTA DOBLEMENTE ENLAZADA
    // ==================================================

    static void MenuDoble(ListaDoble lista)
    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("===== LISTA DOBLEMENTE ENLAZADA =====");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Modificar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Mostrar");
            Console.WriteLine("5. Regresar");
            Console.Write("Selecciona una accion: ");

            op = LeerNumero();

            switch (op)
            {
                case 1:
                    Console.Write("Dato: ");
                    lista.Agregar(Console.ReadLine() ?? "");
                    break;

                case 2:
                    Console.Write("Posicion: ");
                    int p = LeerNumero();
                    Console.Write("Nuevo dato: ");
                    lista.Modificar(p, Console.ReadLine() ?? "");
                    break;

                case 3:
                    Console.Write("Posicion a eliminar: ");
                    lista.Eliminar(LeerNumero());
                    break;

                case 4: lista.Mostrar(); break;
            }

            if (op != 5) Pausa();

        } while (op != 5);
    }

    // ==================================================
    // MENU DE LISTA CIRCULAR
    // ==================================================

    static void MenuCircular(ListaCircular lista)
    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("===== LISTA CIRCULAR =====");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Modificar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Mostrar");
            Console.WriteLine("5. Regresar");
            Console.Write("Selecciona una accion: ");

            op = LeerNumero();

            switch (op)
            {
                case 1:
                    Console.Write("Dato: ");
                    lista.Agregar(Console.ReadLine() ?? "");
                    break;

                case 2:
                    Console.Write("Posicion: ");
                    int p = LeerNumero();
                    Console.Write("Nuevo dato: ");
                    lista.Modificar(p, Console.ReadLine() ?? "");
                    break;

                case 3:
                    Console.Write("Posicion a eliminar: ");
                    lista.Eliminar(LeerNumero());
                    break;

                case 4: lista.Mostrar(); break;
            }

            if (op != 5) Pausa();

        } while (op != 5);
    }

    // ==================================================
    // MENU DE LISTA CIRCULAR DOBLE
    // ==================================================

    static void MenuCircularDoble(ListaCircularDoble lista)
    {
        int op;
        do
        {
            Console.Clear();
            Console.WriteLine("===== LISTA CIRCULAR DOBLE =====");
            Console.WriteLine("1. Agregar");
            Console.WriteLine("2. Modificar");
            Console.WriteLine("3. Eliminar");
            Console.WriteLine("4. Mostrar");
            Console.WriteLine("5. Regresar");
            Console.Write("Selecciona una accion: ");

            op = LeerNumero();

            switch (op)
            {
                case 1:
                    Console.Write("Dato: ");
                    lista.Agregar(Console.ReadLine() ?? "");
                    break;

                case 2:
                    Console.Write("Posicion: ");
                    int p = LeerNumero();
                    Console.Write("Nuevo dato: ");
                    lista.Modificar(p, Console.ReadLine() ?? "");
                    break;

                case 3:
                    Console.Write("Posicion a eliminar: ");
                    lista.Eliminar(LeerNumero());
                    break;

                case 4: lista.Mostrar(); break;
            }

            if (op != 5) Pausa();

        } while (op != 5);
    }
}

// ======================================================
// 1. COLA CIRCULAR
// ======================================================

/*
CARACTERISTICAS:
- Sigue el principio FIFO (primero en entrar, primero en salir).
- Utiliza un arreglo de tamaño fijo.
- El ultimo espacio se conecta con el primero.
- Reutiliza los espacios que quedan libres.

APLICACIONES:
1. Administracion de turnos.
2. Sistemas de impresion.
3. Procesamiento de tareas.

OPERACIONES:
Agregar: inserta al final.
Eliminar: retira el primer elemento.
Modificar: cambia un elemento por posicion.
*/

class ColaCircular
{
    string[] datos;
    int frente = 0, final = -1, cantidad = 0;

    public ColaCircular(int capacidad)
    {
        datos = new string[capacidad];
    }

    public void Agregar(string dato)
    {
        if (cantidad == datos.Length)
        {
            Console.WriteLine("La cola esta llena.");
            return;
        }

        final = (final + 1) % datos.Length;
        datos[final] = dato;
        cantidad++;

        Console.WriteLine("Dato agregado.");
    }

    public void Eliminar()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("La cola esta vacia.");
            return;
        }

        Console.WriteLine("Elemento eliminado: " + datos[frente]);
        frente = (frente + 1) % datos.Length;
        cantidad--;
    }

    public void Modificar(int posicion, string nuevo)
    {
        if (posicion < 1 || posicion > cantidad)
        {
            Console.WriteLine("Posicion incorrecta.");
            return;
        }

        int indice = (frente + posicion - 1) % datos.Length;
        datos[indice] = nuevo;
        Console.WriteLine("Dato modificado.");
    }

    public void Mostrar()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("Cola vacia.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
            Console.WriteLine(datos[(frente + i) % datos.Length]);
    }
}

// ======================================================
// 2. BICOLA
// ======================================================

/*
CARACTERISTICAS:
- Permite insertar por ambos extremos.
- Permite eliminar por ambos extremos.
- Tambien se conoce como deque.
- Puede trabajar con un arreglo circular.

APLICACIONES:
1. Historial de navegacion.
2. Administracion de tareas.
3. Sistemas de atencion y turnos.
*/

class Bicola
{
    string[] datos;
    int frente = 0, cantidad = 0;

    public Bicola(int capacidad)
    {
        datos = new string[capacidad];
    }

    public void AgregarInicio(string dato)
    {
        if (cantidad == datos.Length)
        {
            Console.WriteLine("Bicola llena.");
            return;
        }

        frente = (frente - 1 + datos.Length) % datos.Length;
        datos[frente] = dato;
        cantidad++;
        Console.WriteLine("Agregado al inicio.");
    }

    public void AgregarFinal(string dato)
    {
        if (cantidad == datos.Length)
        {
            Console.WriteLine("Bicola llena.");
            return;
        }

        int indice = (frente + cantidad) % datos.Length;
        datos[indice] = dato;
        cantidad++;
        Console.WriteLine("Agregado al final.");
    }

    public void EliminarInicio()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("Bicola vacia.");
            return;
        }

        Console.WriteLine("Eliminado: " + datos[frente]);
        frente = (frente + 1) % datos.Length;
        cantidad--;
    }

    public void EliminarFinal()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("Bicola vacia.");
            return;
        }

        int indice = (frente + cantidad - 1) % datos.Length;
        Console.WriteLine("Eliminado: " + datos[indice]);
        cantidad--;
    }

    public void Modificar(int posicion, string nuevo)
    {
        if (posicion < 1 || posicion > cantidad)
        {
            Console.WriteLine("Posicion incorrecta.");
            return;
        }

        datos[(frente + posicion - 1) % datos.Length] = nuevo;
        Console.WriteLine("Dato modificado.");
    }

    public void Mostrar()
    {
        if (cantidad == 0)
        {
            Console.WriteLine("Bicola vacia.");
            return;
        }

        for (int i = 0; i < cantidad; i++)
            Console.WriteLine(datos[(frente + i) % datos.Length]);
    }
}

// ======================================================
// NODO PARA LISTA DOBLEMENTE ENLAZADA
// ======================================================

class NodoDoble
{
    public string Dato;
    public NodoDoble? Anterior, Siguiente;

    public NodoDoble(string dato)
    {
        Dato = dato;
    }
}

// ======================================================
// 3. LISTA DOBLEMENTE ENLAZADA
// ======================================================

/*
CARACTERISTICAS:
- Cada nodo contiene un dato.
- Tiene un enlace al nodo anterior y otro al siguiente.
- Se puede recorrer en ambas direcciones.
- No necesita un tamaño fijo.

APLICACIONES:
1. Historial de navegacion.
2. Listas de reproduccion.
3. Navegacion entre imagenes.
*/

class ListaDoble
{
    NodoDoble? inicio, fin;

    public void Agregar(string dato)
    {
        NodoDoble nuevo = new NodoDoble(dato);

        if (inicio == null)
            inicio = fin = nuevo;
        else
        {
            fin!.Siguiente = nuevo;
            nuevo.Anterior = fin;
            fin = nuevo;
        }

        Console.WriteLine("Dato agregado.");
    }

    public void Modificar(int posicion, string nuevo)
    {
        NodoDoble? actual = inicio;

        for (int i = 1; actual != null && i < posicion; i++)
            actual = actual.Siguiente;

        if (actual == null)
        {
            Console.WriteLine("Posicion incorrecta.");
            return;
        }

        actual.Dato = nuevo;
        Console.WriteLine("Dato modificado.");
    }

    public void Eliminar(int posicion)
    {
        NodoDoble? actual = inicio;

        for (int i = 1; actual != null && i < posicion; i++)
            actual = actual.Siguiente;

        if (actual == null)
        {
            Console.WriteLine("Posicion incorrecta.");
            return;
        }

        if (actual.Anterior != null)
            actual.Anterior.Siguiente = actual.Siguiente;
        else
            inicio = actual.Siguiente;

        if (actual.Siguiente != null)
            actual.Siguiente.Anterior = actual.Anterior;
        else
            fin = actual.Anterior;

        Console.WriteLine("Dato eliminado.");
    }

    public void Mostrar()
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacia.");
            return;
        }

        NodoDoble? actual = inicio;

        while (actual != null)
        {
            Console.Write(actual.Dato + " <-> ");
            actual = actual.Siguiente;
        }

        Console.WriteLine("NULL");
    }
}

// ======================================================
// NODO PARA LISTA CIRCULAR
// ======================================================

class NodoCircular
{
    public string Dato;
    public NodoCircular? Siguiente;

    public NodoCircular(string dato)
    {
        Dato = dato;
    }
}

// ======================================================
// 4. LISTA CIRCULAR
// ======================================================

/*
CARACTERISTICAS:
- El ultimo nodo apunta al primero.
- No tiene un final NULL.
- Permite recorrer los elementos continuamente.
- Sus nodos se conectan en forma de circulo.

APLICACIONES:
1. Turnos de jugadores.
2. Reproduccion continua de canciones.
3. Planificacion de procesos.
*/

class ListaCircular
{
    NodoCircular? ultimo;

    public void Agregar(string dato)
    {
        NodoCircular nuevo = new NodoCircular(dato);

        if (ultimo == null)
        {
            ultimo = nuevo;
            nuevo.Siguiente = nuevo;
        }
        else
        {
            nuevo.Siguiente = ultimo.Siguiente;
            ultimo.Siguiente = nuevo;
            ultimo = nuevo;
        }

        Console.WriteLine("Dato agregado.");
    }

    public void Modificar(int posicion, string nuevo)
    {
        if (ultimo == null || posicion < 1)
        {
            Console.WriteLine("Posicion incorrecta.");
            return;
        }

        NodoCircular actual = ultimo.Siguiente!;

        for (int i = 1; i < posicion; i++)
        {
            if (actual == ultimo)
            {
                Console.WriteLine("Posicion incorrecta.");
                return;
            }

            actual = actual.Siguiente!;
        }

        actual.Dato = nuevo;
        Console.WriteLine("Dato modificado.");
    }

    public void Eliminar(int posicion)
    {
        if (ultimo == null || posicion < 1)
        {
            Console.WriteLine("Lista vacia o posicion incorrecta.");
            return;
        }

        NodoCircular actual = ultimo.Siguiente!;
        NodoCircular anterior = ultimo;
        int i = 1;

        while (i < posicion && actual != ultimo)
        {
            anterior = actual;
            actual = actual.Siguiente!;
            i++;
        }

        if (i != posicion)
        {
            Console.WriteLine("Posicion incorrecta.");
            return;
        }

        if (actual == ultimo && actual == ultimo.Siguiente)
            ultimo = null;
        else
        {
            anterior.Siguiente = actual.Siguiente;

            if (actual == ultimo)
                ultimo = anterior;
        }

        Console.WriteLine("Dato eliminado.");
    }

    public void Mostrar()
    {
        if (ultimo == null)
        {
            Console.WriteLine("Lista vacia.");
            return;
        }

        NodoCircular actual = ultimo.Siguiente!;

        do
        {
            Console.Write(actual.Dato + " -> ");
            actual = actual.Siguiente!;
        }
        while (actual != ultimo.Siguiente);

        Console.WriteLine("(Regresa al inicio)");
    }
}

// ======================================================
// NODO PARA LISTA CIRCULAR DOBLE
// ======================================================

class NodoCircularDoble
{
    public string Dato;
    public NodoCircularDoble? Siguiente, Anterior;

    public NodoCircularDoble(string dato)
    {
        Dato = dato;
    }
}

// ======================================================
// 5. LISTA CIRCULAR DOBLE
// ======================================================

/*
CARACTERISTICAS:
- Cada nodo tiene un enlace anterior y siguiente.
- El ultimo nodo se conecta con el primero.
- El primero tambien se conecta con el ultimo.
- Permite recorrer la lista en ambos sentidos.

APLICACIONES:
1. Reproduccion de musica en bucle.
2. Carruseles de imagenes.
3. Navegacion entre diapositivas.
*/

class ListaCircularDoble
{
    NodoCircularDoble? inicio;

    public void Agregar(string dato)
    {
        NodoCircularDoble nuevo = new NodoCircularDoble(dato);

        if (inicio == null)
        {
            inicio = nuevo;
            nuevo.Siguiente = nuevo;
            nuevo.Anterior = nuevo;
        }
        else
        {
            NodoCircularDoble ultimo = inicio.Anterior!;

            nuevo.Siguiente = inicio;
            nuevo.Anterior = ultimo;

            ultimo.Siguiente = nuevo;
            inicio.Anterior = nuevo;
        }

        Console.WriteLine("Dato agregado.");
    }

    public void Modificar(int posicion, string nuevo)
    {
        if (inicio == null || posicion < 1)
        {
            Console.WriteLine("Posicion incorrecta.");
            return;
        }

        NodoCircularDoble actual = inicio;

        for (int i = 1; i < posicion; i++)
        {
            actual = actual.Siguiente!;

            if (actual == inicio)
            {
                Console.WriteLine("Posicion incorrecta.");
                return;
            }
        }

        actual.Dato = nuevo;
        Console.WriteLine("Dato modificado.");
    }

    public void Eliminar(int posicion)
    {
        if (inicio == null || posicion < 1)
        {
            Console.WriteLine("Lista vacia o posicion incorrecta.");
            return;
        }

        NodoCircularDoble actual = inicio;

        for (int i = 1; i < posicion; i++)
        {
            actual = actual.Siguiente!;

            if (actual == inicio)
            {
                Console.WriteLine("Posicion incorrecta.");
                return;
            }
        }

        if (actual.Siguiente == actual)
            inicio = null;
        else
        {
            actual.Anterior!.Siguiente = actual.Siguiente;
            actual.Siguiente!.Anterior = actual.Anterior;

            if (actual == inicio)
                inicio = actual.Siguiente;
        }

        Console.WriteLine("Dato eliminado.");
    }

    public void Mostrar()
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacia.");
            return;
        }

        NodoCircularDoble actual = inicio;

        do
        {
            Console.Write(actual.Dato + " <-> ");
            actual = actual.Siguiente!;
        }
        while (actual != inicio);

        Console.WriteLine("(Regresa al inicio)");
    }
}