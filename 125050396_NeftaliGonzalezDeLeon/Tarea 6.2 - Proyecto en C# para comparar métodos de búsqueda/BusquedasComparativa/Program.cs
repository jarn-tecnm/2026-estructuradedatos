using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;

namespace BusquedasComparativa
{
    // Representa el registro asociado a la clave entera
    class RegistroAlumbrado
    {
        public int Folio { get; set; }
        public string Colonia { get; set; }
        public string Falla { get; set; }

        public RegistroAlumbrado(int folio, string colonia, string falla)
        {
            Folio = folio;
            Colonia = colonia;
            Falla = falla;
        }

        public override string ToString() => $"[Folio: {Folio} | {Colonia} - {Falla}]";
    }

    // Tabla Hash sencilla con manejo de colisiones por Encadenamiento Separado (Separate Chaining)
    class TablaHash
    {
        private readonly List<RegistroAlumbrado>[] _cubetas;
        public int Capacidad { get; }
        public int ColisionesAlInsertar { get; private set; }

        public TablaHash(int capacidad)
        {
            Capacidad = capacidad;
            _cubetas = new List<RegistroAlumbrado>[capacidad];
            for (int i = 0; i < capacidad; i++)
            {
                _cubetas[i] = new List<RegistroAlumbrado>();
            }
        }

        // Función Hash modular: calcula el índice dentro del arreglo
        public int FuncionHash(int clave)
        {
            return Math.Abs(clave) % Capacidad;
        }

        public void Insertar(RegistroAlumbrado registro)
        {
            int indice = FuncionHash(registro.Folio);

            // Si la cubeta ya tiene elementos, ocurre una colisión
            if (_cubetas[indice].Count > 0)
            {
                ColisionesAlInsertar++;
            }

            _cubetas[indice].Add(registro);
        }

        public RegistroAlumbrado? Buscar(int clave, out int comparaciones)
        {
            comparaciones = 0;
            int indice = FuncionHash(clave);

            // Recorre únicamente los elementos dentro de la cubeta calculada
            foreach (var registro in _cubetas[indice])
            {
                comparaciones++;
                if (registro.Folio == clave)
                {
                    return registro;
                }
            }

            return null;
        }

        // Obtiene una clave que esté en una cubeta con 2 o más elementos (caso de colisión comprobado)
        public int ObtenerClaveConColision()
        {
            for (int i = 0; i < Capacidad; i++)
            {
                if (_cubetas[i].Count > 1)
                {
                    // Devuelve el último elemento de la cubeta (requiere recorrer la cadena)
                    return _cubetas[i][^1].Folio;
                }
            }
            return -1;
        }

        public void MostrarEstadoCubetas()
        {
            Console.WriteLine("\n--- DISTRIBUCIÓN DE LA TABLA HASH (Capacidad: " + Capacidad + ") ---");
            for (int i = 0; i < Capacidad; i++)
            {
                string contenido = _cubetas[i].Count == 0
                    ? "(vacío)"
                    : string.Join(" -> ", _cubetas[i].Select(r => r.Folio));
                string marcaColision = _cubetas[i].Count > 1 ? "  <-- [COLISIÓN]" : "";
                Console.WriteLine($"Cubeta [{i:D2}]: {contenido}{marcaColision}");
            }
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;

            // 1. Generar 20 claves únicas aleatorias
            int cantidadRegistros = 20;
            List<RegistroAlumbrado> datosOriginales = GenerarRegistrosUnicos(cantidadRegistros);

            Console.WriteLine("=== CLAVES GENERADAS (ORDEN DE LLEGADA) ===");
            Console.WriteLine(string.Join(", ", datosOriginales.Select(r => r.Folio)));

            // 2. Preparación previa: Copia ordenada para Búsqueda Binaria
            Stopwatch swOrdenar = Stopwatch.StartNew();
            List<RegistroAlumbrado> datosOrdenados = datosOriginales
                .OrderBy(r => r.Folio)
                .ToList();
            swOrdenar.Stop();

            Console.WriteLine("\n=== COPIA ORDENADA (PARA BÚSQUEDA BINARIA) ===");
            Console.WriteLine(string.Join(", ", datosOrdenados.Select(r => r.Folio)));

            // 3. Preparación previa: Construcción de Tabla Hash (capacidad 13 para forzar colisiones)
            Stopwatch swHash = Stopwatch.StartNew();
            TablaHash tablaHash = new TablaHash(capacidad: 13);
            foreach (var registro in datosOriginales)
            {
                tablaHash.Insertar(registro);
            }
            swHash.Stop();

            tablaHash.MostrarEstadoCubetas();
            Console.WriteLine($"\nTotal de colisiones registradas al construir la tabla: {tablaHash.ColisionesAlInsertar}");

            // 4. Selección de casos de prueba (Presente normal, Presente con colisión, Ausente)
            int clavePresente = datosOriginales[0].Folio;
            int claveConColision = tablaHash.ObtenerClaveConColision();
            int claveAusente = 9999; // Fuera del rango generado (1000 - 8999)

            Console.WriteLine("\n==========================================================================");
            Console.WriteLine("                COMPARATIVA DE CONSULTAS (NÚMERO DE COMPARACIONES)");
            Console.WriteLine("==========================================================================");
            Console.WriteLine($"{"Caso de Prueba",-28} | {"Clave",-6} | {"Secuencial",-10} | {"Binaria",-8} | {"Hash",-6}");
            Console.WriteLine(new string('-', 74));

            EjecutarPrueba("1. Presente (sin colisión)", clavePresente, datosOriginales, datosOrdenados, tablaHash);
            EjecutarPrueba("2. Presente (CON colisión)", claveConColision, datosOriginales, datosOrdenados, tablaHash);
            EjecutarPrueba("3. Ausente (no existe)", claveAusente, datosOriginales, datosOrdenados, tablaHash);

            Console.WriteLine(new string('-', 74));

            // 5. Costo del trabajo previo (Preparación)
            Console.WriteLine("\n=== COSTO DE TRABAJO PREVIO (PREPARACIÓN) ===");
            Console.WriteLine($"Tiempo para ordenar copia (Búsqueda Binaria): {swOrdenar.Elapsed.TotalMilliseconds:F4} ms");
            Console.WriteLine($"Tiempo para construir Tabla Hash:             {swHash.Elapsed.TotalMilliseconds:F4} ms");

            // 6. Conclusión y justificación para el reporte / exposición
            Console.WriteLine("\n=== ANÁLISIS Y JUSTIFICACIÓN ===");
            Console.WriteLine("- 1 sola consulta: Conviene Búsqueda Secuencial O(n), porque ordenar o crear");
            Console.WriteLine("  la tabla hash cuesta más tiempo previo que recorrer la lista una única vez.");
            Console.WriteLine("- Muchas consultas: Conviene Tabla Hash O(1) promedio (o Binaria O(log n) si se");
            Console.WriteLine("  requieren rangos ordenados), ya que el costo inicial se amortiza rápidamente.");
            Console.WriteLine("- Método elegido: TABLA HASH, porque localiza folios de alumbrado al instante");
            Console.WriteLine("  en 1 o 2 comparaciones incluso cuando el padrón crece a miles de reportes.");

            Console.WriteLine("\n¿Deseas consultar algún folio manualmente? (Escribe el número o Presiona la tecla 'Enter' para salir): ");
            string? entrada = Console.ReadLine();
            if (int.TryParse(entrada, out int folioManual))
            {
                EjecutarPrueba("Consulta manual", folioManual, datosOriginales, datosOrdenados, tablaHash);
            }
        }

        static RegistroAlumbrado? BusquedaSecuencial(List<RegistroAlumbrado> lista, int clave, out int comparaciones)
        {
            comparaciones = 0;
            foreach (var registro in lista)
            {
                comparaciones++;
                if (registro.Folio == clave)
                {
                    return registro;
                }
            }
            return null;
        }

        static RegistroAlumbrado? BusquedaBinaria(List<RegistroAlumbrado> listaOrdenada, int clave, out int comparaciones)
        {
            comparaciones = 0;
            int izquierda = 0;
            int derecha = listaOrdenada.Count - 1;

            while (izquierda <= derecha)
            {
                int medio = izquierda + (derecha - izquierda) / 2;
                comparaciones++;

                if (listaOrdenada[medio].Folio == clave)
                {
                    return listaOrdenada[medio];
                }
                if (listaOrdenada[medio].Folio < clave)
                {
                    izquierda = medio + 1;
                }
                else
                {
                    derecha = medio - 1;
                }
            }
            return null;
        }

        static void EjecutarPrueba(
            string nombreCaso,
            int clave,
            List<RegistroAlumbrado> originales,
            List<RegistroAlumbrado> ordenados,
            TablaHash tablaHash)
        {
            var resSec = BusquedaSecuencial(originales, clave, out int compSec);
            var resBin = BusquedaBinaria(ordenados, clave, out int compBin);
            var resHash = tablaHash.Buscar(clave, out int compHash);

            string estado = resHash != null ? "Encontrado" : "NO EXISTE";
            Console.WriteLine($"{nombreCaso,-28} | {clave,-6} | {compSec,-10} | {compBin,-8} | {compHash,-6} ({estado})");
        }

        static List<RegistroAlumbrado> GenerarRegistrosUnicos(int cantidad)
        {
            Random random = new Random();
            HashSet<int> clavesUsadas = new HashSet<int>();
            List<RegistroAlumbrado> lista = new List<RegistroAlumbrado>();

            string[] colonias = { "Zona Centro", "Col. Guadalupe", "Col. Tecnológico", "Fracc. Las Flores", "Col. Obrera" };
            string[] fallas = { "Luminaria apagada", "Parpadeo intermitente", "Poste dañado", "Fotocelda averiada" };

            while (lista.Count < cantidad)
            {
                int folio = random.Next(1000, 9000);
                if (clavesUsadas.Add(folio))
                {
                    string colonia = colonias[random.Next(colonias.Length)];
                    string falla = fallas[random.Next(fallas.Length)];
                    lista.Add(new RegistroAlumbrado(folio, colonia, falla));
                }
            }
            return lista;
        }
    }
}