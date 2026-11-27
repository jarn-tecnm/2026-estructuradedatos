using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

namespace BusquedaFolios
{
    // Registro simulado: reporte de alumbrado público identificado por un folio entero.
    class Reporte
    {
        public int Folio;
        public string Colonia;
        public string Falla;
    }

    // Nodo de la lista enlazada que forma cada cubeta (encadenamiento separado).
    class NodoHash
    {
        public Reporte Dato;
        public NodoHash Siguiente;
    }

    // Tabla hash sencilla: función de división + encadenamiento para las colisiones.
    class TablaHash
    {
        private readonly NodoHash[] cubetas;
        public int Tamano { get { return cubetas.Length; } }

        public TablaHash(int tamano)
        {
            cubetas = new NodoHash[tamano];
        }

        // Función hash (método de la división): posición = clave mod m.
        // Con m primo se reparten mejor las claves. Las claves son enteros positivos.
        public int Hash(int clave)
        {
            return clave % cubetas.Length;
        }

        // Inserta al inicio de la cadena de la cubeta. Devuelve true si hubo colisión
        // (la cubeta ya tenía al menos un elemento). Como las claves son únicas no se
        // compara nada al insertar.
        public bool Insertar(Reporte r)
        {
            int pos = Hash(r.Folio);
            bool colision = cubetas[pos] != null;
            cubetas[pos] = new NodoHash { Dato = r, Siguiente = cubetas[pos] };
            return colision;
        }

        // Busca recorriendo solo la cadena de su cubeta; cuenta cada clave comparada.
        public Reporte Buscar(int clave, out int comparaciones)
        {
            comparaciones = 0;
            NodoHash actual = cubetas[Hash(clave)];
            while (actual != null)
            {
                comparaciones++;
                if (actual.Dato.Folio == clave) return actual.Dato;
                actual = actual.Siguiente;
            }
            return null;
        }

        public List<int> Cadena(int pos)
        {
            var lista = new List<int>();
            for (NodoHash n = cubetas[pos]; n != null; n = n.Siguiente) lista.Add(n.Dato.Folio);
            return lista;
        }

        public int LongitudCadena(int pos)
        {
            int c = 0;
            for (NodoHash n = cubetas[pos]; n != null; n = n.Siguiente) c++;
            return c;
        }
    }

    static class Buscadores
    {
        // Búsqueda secuencial: revisa elemento por elemento (no requiere orden).
        public static Reporte Secuencial(Reporte[] datos, int clave, out int comparaciones)
        {
            comparaciones = 0;
            for (int i = 0; i < datos.Length; i++)
            {
                comparaciones++;
                if (datos[i].Folio == clave) return datos[i];
            }
            return null;
        }

        // Búsqueda binaria: requiere el arreglo ordenado por Folio.
        // Convención: cada vuelta del ciclo cuenta como 1 comparación (comparación de tres vías).
        public static Reporte Binaria(Reporte[] ordenado, int clave, out int comparaciones)
        {
            comparaciones = 0;
            int ini = 0, fin = ordenado.Length - 1;
            while (ini <= fin)
            {
                int medio = ini + (fin - ini) / 2;
                comparaciones++;
                int c = clave.CompareTo(ordenado[medio].Folio);
                if (c == 0) return ordenado[medio];
                if (c < 0) fin = medio - 1; else ini = medio + 1;
            }
            return null;
        }
    }

    class Caso
    {
        public string Nombre;
        public int Clave;
        public Caso(string nombre, int clave) { Nombre = nombre; Clave = clave; }
    }

    class Program
    {
        const int N = 1000;            // cantidad de reportes
        const int M = 1009;            // tamaño de la tabla hash (número primo)
        const int CLAVE_MIN = 10000;   // rango de folios
        const int CLAVE_MAX = 99999;
        const int SEMILLA = 2026;      // semilla fija: los resultados se pueden repetir

        static string[] colonias = { "Centro", "Guadalupe", "Los Pinos", "Nueva Era", "Hidalgo", "Roma", "Jardines", "Zona Industrial" };
        static string[] fallas = { "Luminaria apagada", "Poste dañado", "Cableado expuesto", "Luz intermitente", "Foco fundido" };

        static double Micros(long ticks)
        {
            return ticks * 1000000.0 / Stopwatch.Frequency;
        }

        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            var rnd = new Random(SEMILLA);

            // 1) Claves únicas generadas aleatoriamente (HashSet garantiza que no se repitan)
            var usadas = new HashSet<int>();
            var datos = new Reporte[N];
            int k = 0;
            while (k < N)
            {
                int folio = rnd.Next(CLAVE_MIN, CLAVE_MAX + 1);
                if (!usadas.Add(folio)) continue;
                datos[k++] = new Reporte
                {
                    Folio = folio,
                    Colonia = colonias[rnd.Next(colonias.Length)],
                    Falla = fallas[rnd.Next(fallas.Length)]
                };
            }

            Console.WriteLine("=== BÚSQUEDA DE REPORTES DE ALUMBRADO POR FOLIO ===");
            Console.WriteLine("Reportes: {0} | Rango de folios: {1}-{2} | Semilla: {3} | Tabla hash: {4} posiciones",
                N, CLAVE_MIN, CLAVE_MAX, SEMILLA, M);

            // 2) Preparación: copia ordenada (binaria) y tabla hash (mismas claves)
            long compOrden = 0;
            long t0 = Stopwatch.GetTimestamp();
            Reporte[] ordenado = (Reporte[])datos.Clone();
            Array.Sort(ordenado, (a, b) => { compOrden++; return a.Folio.CompareTo(b.Folio); });
            long tOrden = Stopwatch.GetTimestamp() - t0;

            var tabla = new TablaHash(M);
            int colisionesInsercion = 0;
            t0 = Stopwatch.GetTimestamp();
            foreach (Reporte r in datos)
                if (tabla.Insertar(r)) colisionesInsercion++;
            long tHash = Stopwatch.GetTimestamp() - t0;

            // Verificación de que la copia quedó ordenada
            for (int i = 1; i < N; i++)
                if (ordenado[i - 1].Folio >= ordenado[i].Folio)
                {
                    Console.WriteLine("ERROR: la copia no quedó ordenada.");
                    return;
                }

            Console.WriteLine();
            Console.WriteLine("--- Preparación previa ---");
            Console.WriteLine("Secuencial : ninguna (usa el arreglo original)");
            Console.WriteLine("Binaria    : ordenar copia -> {0} comparaciones, {1:F1} µs", compOrden, Micros(tOrden));
            Console.WriteLine("Hash       : {0} inserciones (0 comparaciones de claves), {1:F1} µs", N, Micros(tHash));

            // 3) Estadísticas de la tabla hash
            int vacias = 0, maxCadena = 0, posMax = 0, ocupadas = 0;
            for (int p = 0; p < M; p++)
            {
                int l = tabla.LongitudCadena(p);
                if (l == 0) vacias++;
                else ocupadas++;
                if (l > maxCadena) { maxCadena = l; posMax = p; }
            }
            Console.WriteLine();
            Console.WriteLine("--- Tabla hash (h(clave) = clave % {0}) ---", M);
            Console.WriteLine("Factor de carga: {0:F2} | Posiciones ocupadas: {1} | Vacías: {2}", (double)N / M, ocupadas, vacias);
            Console.WriteLine("Inserciones que chocaron con un elemento existente: {0} | Cadena más larga: {1} (posición {2})",
                colisionesInsercion, maxCadena, posMax);

            // 4) Casos de prueba
            var cadenaMax = tabla.Cadena(posMax);
            int claveCabeza = cadenaMax[0];
            int claveCola = cadenaMax[cadenaMax.Count - 1];

            int minimo = ordenado[0].Folio, maximo = ordenado[N - 1].Folio;
            int ausenteEntre = 0;
            while (true)
            {
                ausenteEntre = rnd.Next(minimo + 1, maximo);
                if (!usadas.Contains(ausenteEntre)) break;
            }
            int ausenteColision = -1;
            for (int c = CLAVE_MIN; c <= CLAVE_MAX; c++)
                if (c % M == posMax && !usadas.Contains(c)) { ausenteColision = c; break; }

            var casos = new List<Caso>
            {
                new Caso("Presente: primero del arreglo", datos[0].Folio),
                new Caso("Presente: elemento central", datos[N / 2].Folio),
                new Caso("Presente: último del arreglo", datos[N - 1].Folio),
                new Caso("Presente: folio menor", minimo),
                new Caso("Presente: folio mayor", maximo),
                new Caso("Presente: colisión (cabeza de cadena)", claveCabeza),
                new Caso("Presente: colisión (final de cadena)", claveCola),
                new Caso("Ausente: menor que todos", minimo - 1),
                new Caso("Ausente: mayor que todos", maximo + 1),
                new Caso("Ausente: valor intermedio", ausenteEntre),
                new Caso("Ausente: cae en cadena con colisión", ausenteColision)
            };

            Console.WriteLine();
            Console.WriteLine("--- Resultados por caso (comparaciones de claves) ---");
            Console.WriteLine("{0,-40}{1,7}{2,12}{3,6}{4,6}{5,6}{6,7}", "Caso", "Clave", "Resultado", "Sec", "Bin", "Hash", "Pos");
            bool todoCoincide = true;
            foreach (Caso c in casos)
            {
                int cs, cb, ch;
                Reporte rs = Buscadores.Secuencial(datos, c.Clave, out cs);
                Reporte rb = Buscadores.Binaria(ordenado, c.Clave, out cb);
                Reporte rh = tabla.Buscar(c.Clave, out ch);
                bool coincide = (rs == null) == (rb == null) && (rb == null) == (rh == null)
                                && (rs == null || (rs.Folio == c.Clave && rb.Folio == c.Clave && rh.Folio == c.Clave));
                if (!coincide) todoCoincide = false;
                Console.WriteLine("{0,-40}{1,7}{2,12}{3,6}{4,6}{5,6}{6,7}",
                    c.Nombre, c.Clave, rs != null ? "Encontrado" : "No existe", cs, cb, ch, tabla.Hash(c.Clave));
            }
            Console.WriteLine("Los tres métodos coinciden en todos los casos: {0}", todoCoincide ? "Sí" : "NO");

            // 5) Detalle de la colisión
            Console.WriteLine();
            Console.WriteLine("--- Detalle de colisión en la posición {0} ---", posMax);
            Console.WriteLine("Folios que comparten posición ({0}): {1}", cadenaMax.Count, string.Join(" -> ", cadenaMax));
            Console.WriteLine("Para encontrar {0} se recorre la cadena desde su cabeza hasta llegar a él;", claveCola);
            Console.WriteLine("para confirmar que {0} no existe se recorre la cadena completa.", ausenteColision);

            // 6) Muchas consultas: costo de preparación vs costo por consulta
            const int QMAX = 10000;
            var consultas = new int[QMAX];
            for (int i = 0; i < QMAX; i++)
            {
                if (i % 2 == 0) consultas[i] = datos[rnd.Next(N)].Folio;   // presentes
                else
                {
                    int a;
                    do { a = rnd.Next(CLAVE_MIN, CLAVE_MAX + 1); } while (usadas.Contains(a));
                    consultas[i] = a;                                      // ausentes
                }
            }

            int[] cantidades = { 1, 10, 100, 1000, 10000 };
            Console.WriteLine();
            Console.WriteLine("--- Muchas consultas (50% presentes, 50% ausentes) ---");
            Console.WriteLine("Total = preparación + consultas. Hash: la preparación son {0} inserciones, se suman como {0} operaciones.", N);
            Console.WriteLine("{0,8}{1,14}{2,14}{3,14}{4,12}{5,12}{6,12}", "Consultas", "Sec total", "Bin total", "Hash total", "Sec/cons", "Bin/cons", "Hash/cons");

            long acumSec = 0, acumBin = 0, acumHash = 0;
            int ruptBin = -1, ruptHash = -1;
            int idx = 0;
            long tSec = 0, tBin = 0, tHashQ = 0;
            foreach (int q in cantidades)
            {
                for (; idx < q; idx++)
                {
                    int c1, c2, c3;
                    long s = Stopwatch.GetTimestamp();
                    Buscadores.Secuencial(datos, consultas[idx], out c1);
                    long e1 = Stopwatch.GetTimestamp();
                    Buscadores.Binaria(ordenado, consultas[idx], out c2);
                    long e2 = Stopwatch.GetTimestamp();
                    tabla.Buscar(consultas[idx], out c3);
                    long e3 = Stopwatch.GetTimestamp();
                    tSec += e1 - s; tBin += e2 - e1; tHashQ += e3 - e2;
                    acumSec += c1; acumBin += c2; acumHash += c3;
                    if (ruptBin < 0 && compOrden + acumBin < acumSec) ruptBin = idx + 1;
                    if (ruptHash < 0 && N + acumHash < acumSec) ruptHash = idx + 1;
                }
                Console.WriteLine("{0,8}{1,14}{2,14}{3,14}{4,12:F1}{5,12:F1}{6,12:F2}",
                    q, acumSec, compOrden + acumBin, N + acumHash,
                    (double)acumSec / q, (double)acumBin / q, (double)acumHash / q);
            }
            Console.WriteLine();
            Console.WriteLine("Con la misma serie de consultas, la binaria (incluyendo el ordenamiento) supera a la secuencial desde la consulta #{0}", ruptBin);
            Console.WriteLine("y el hash (incluyendo las {0} inserciones) la supera desde la consulta #{1}.", N, ruptHash);
            Console.WriteLine("Tiempo acumulado de las {0} consultas (solo búsqueda): Sec {1:F0} µs | Bin {2:F0} µs | Hash {3:F0} µs",
                QMAX, Micros(tSec), Micros(tBin), Micros(tHashQ));
            Console.WriteLine("(El tiempo incluye el costo de medir con Stopwatch en cada consulta; es solo orientativo.)");
        }
    }
}
