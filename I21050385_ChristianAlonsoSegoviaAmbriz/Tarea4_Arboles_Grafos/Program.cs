using System;
using System.Collections.Generic;

class Program
{
    static void Main()
    {
        // Árbol binario de búsqueda
        var arbol = new ArbolBinarioBusqueda();
        foreach (int numero in new[] { 5,78, 100, 15, 20, 4, 8, 3, 10, 1, 6, 14 })
            arbol.Insertar(numero);

        Console.Write("Árbol en orden: ");
        arbol.ImprimirEnOrden();
        Console.WriteLine($"\n¿Contiene 6? {arbol.Contiene(6)}");

        // Grafo no dirigido
        var grafo = new Grafo();
        grafo.AgregarArista("A", "B");
        grafo.AgregarArista("A", "C");
        grafo.AgregarArista("B", "D");
        grafo.AgregarArista("C", "D");

        Console.WriteLine("Recorrido del grafo: " +
            string.Join(" -> ", grafo.RecorrerDesde("A")));
    }
}

class ArbolBinarioBusqueda
{
    private Nodo? raiz;

    public void Insertar(int valor) => raiz = Insertar(raiz, valor);

    private Nodo Insertar(Nodo? nodo, int valor)
    {
        if (nodo == null) return new Nodo(valor);

        if (valor < nodo.Valor)
            nodo.Izquierdo = Insertar(nodo.Izquierdo, valor);
        else if (valor > nodo.Valor)
            nodo.Derecho = Insertar(nodo.Derecho, valor);

        return nodo;
    }

    public bool Contiene(int valor)
    {
        var actual = raiz;
        while (actual != null)
        {
            if (actual.Valor == valor) return true;
            actual = valor < actual.Valor ? actual.Izquierdo : actual.Derecho;
        }
        return false;
    }

    public void ImprimirEnOrden() => ImprimirEnOrden(raiz);

    private void ImprimirEnOrden(Nodo? nodo)
    {
        if (nodo == null) return;
        ImprimirEnOrden(nodo.Izquierdo);
        Console.Write($"{nodo.Valor} ");
        ImprimirEnOrden(nodo.Derecho);
    }

    private class Nodo(int valor)
    {
        public int Valor { get; } = valor;
        public Nodo? Izquierdo { get; set; }
        public Nodo? Derecho { get; set; }
    }
}

class Grafo
{
    private readonly Dictionary<string, List<string>> conexiones = new();

    public void AgregarArista(string a, string b)
    {
        if (!conexiones.ContainsKey(a)) conexiones[a] = new List<string>();
        if (!conexiones.ContainsKey(b)) conexiones[b] = new List<string>();

        conexiones[a].Add(b);
        conexiones[b].Add(a); // La conexión funciona en ambos sentidos.
    }

    public List<string> RecorrerDesde(string inicio)
    {
        var recorrido = new List<string>();
        if (!conexiones.ContainsKey(inicio)) return recorrido;

        var visitados = new HashSet<string> { inicio };
        var cola = new Queue<string>();
        cola.Enqueue(inicio);

        while (cola.Count > 0)
        {
            string actual = cola.Dequeue();
            recorrido.Add(actual);

            foreach (string vecino in conexiones[actual])
                if (visitados.Add(vecino))
                    cola.Enqueue(vecino);
        }

        return recorrido;
    }
}