
using System;
using System.Diagnostics;
using System.IO;

class NodoVideo
{
    public string Nombre;
    public string Ruta;
    public NodoVideo Siguiente;
    public NodoVideo Anterior;

    public NodoVideo(string nombre, string ruta)
    {
        Nombre = nombre;
        Ruta = ruta;
    }
}

class ListaCircularDoble
{
    private NodoVideo inicio;
    private NodoVideo actual;

    // Registrar videos en la lista
    public void RegistrarVideo(string nombre, string ruta)
    {
        NodoVideo nuevo = new NodoVideo(nombre, ruta);

        if (inicio == null)
        {
            inicio = nuevo;
            actual = nuevo;

            nuevo.Siguiente = nuevo;
            nuevo.Anterior = nuevo;
        }
        else
        {
            NodoVideo ultimo = inicio.Anterior;

            ultimo.Siguiente = nuevo;
            nuevo.Anterior = ultimo;

            nuevo.Siguiente = inicio;
            inicio.Anterior = nuevo;
        }
    }

    // Pasar al siguiente video
    public void Siguiente()
    {
        if (actual != null)
        {
            actual = actual.Siguiente;
            Console.WriteLine("Video: " + actual.Nombre);
        }
    }

    // Regresar al video anterior
    public void Anterior()
    {
        if (actual != null)
        {
            actual = actual.Anterior;
            Console.WriteLine("Video: " + actual.Nombre);
        }
    }

    // Mostrar todos los videos
    public void MostrarLista()
    {
        if (inicio == null)
        {
            Console.WriteLine("Lista vacía.");
            return;
        }

        NodoVideo temporal = inicio;

        do
        {
            if (temporal == actual)
                Console.WriteLine("-> " + temporal.Nombre);
            else
                Console.WriteLine("   " + temporal.Nombre);

            temporal = temporal.Siguiente;

        } while (temporal != inicio);
    }

    // Reproducir el video actual
    public void Reproducir()
    {
        if (actual == null)
        {
            Console.WriteLine("No hay videos.");
            return;
        }

        if (File.Exists(actual.Ruta))
        {
            Process.Start(new ProcessStartInfo
            {
                FileName = actual.Ruta,
                UseShellExecute = true
            });

            Console.WriteLine("Reproduciendo: " + actual.Nombre);
        }
        else
        {
            Console.WriteLine("No se encontró el archivo: " + actual.Ruta);
        }
    }
}

class Program
{
    static void Main()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        ListaCircularDoble reproductor = new ListaCircularDoble();

        // Videos registrados directamente en el código
        reproductor.RegistrarVideo(
            "Video 1",
            @"C:\Users\Hp 245 G8\Desktop\VideoChido\RedSunintheSky.mp4");

        reproductor.RegistrarVideo(
            "Video 2",
            @"C:\Users\Hp 245 G8\Desktop\VideoChido\Video2.mp4");

        reproductor.RegistrarVideo(
            "Video 3",
            @"C:\Users\Hp 245 G8\Desktop\VideoChido\Video3.mp4");

        bool salir = false;

        while (!salir)
        {
            Console.WriteLine("////////////////////////////////");
            Console.WriteLine("       VIDEO JUGADOR");
            Console.WriteLine("////////////////////////////////");
            Console.WriteLine("1. Русский (Ruso)");
            Console.WriteLine("2. Español (Español)");
            Console.WriteLine("3. Salir");
            Console.WriteLine("////////////////////////////////");
            Console.Write("Выберите язык / Seleccione idioma: ");

            string elegirIdioma = Console.ReadLine();

            switch (elegirIdioma)
            {
                case "1":
                    MenuRuso(reproductor);
                    break;

                case "2":
                    MenuEspanol(reproductor);
                    break;

                case "3":
                    salir = true;
                    Console.WriteLine("Programa cerrado.");
                    break;

                default:
                    Console.WriteLine("Idioma no válido.");
                    break;
            }
        }
    }

    // Menú en ruso
    static void MenuRuso(ListaCircularDoble reproductor)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n===== ВИДЕОПЛЕЕР =====");
            Console.WriteLine("1. Воспроизвести видео");
            Console.WriteLine("2. Следующее видео");
            Console.WriteLine("3. Предыдущее видео");
            Console.WriteLine("4. Список видео");
            Console.WriteLine("5. Выход");
            Console.Write("Выберите опцию: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    reproductor.Reproducir();
                    break;

                case "2":
                    reproductor.Siguiente();
                    break;

                case "3":
                    reproductor.Anterior();
                    break;

                case "4":
                    reproductor.MostrarLista();
                    break;

                case "5":
                    continuar = false;
                    Console.WriteLine("Возвращение в главное меню...");
                    break;

                default:
                    Console.WriteLine("Неверный вариант.");
                    break;
            }
        }
    }

    // Menú en español
    static void MenuEspanol(ListaCircularDoble reproductor)
    {
        bool continuar = true;

        while (continuar)
        {
            Console.WriteLine("\n===== REPRODUCTOR DE VIDEOS =====");
            Console.WriteLine("1. Reproducir video");
            Console.WriteLine("2. Siguiente video");
            Console.WriteLine("3. Video anterior");
            Console.WriteLine("4. Lista de videos");
            Console.WriteLine("5. Salir");
            Console.Write("Seleccione una opcion: ");

            string opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    reproductor.Reproducir();
                    break;

                case "2":
                    reproductor.Siguiente();
                    break;

                case "3":
                    reproductor.Anterior();
                    break;

                case "4":
                    reproductor.MostrarLista();
                    break;

                case "5":
                    continuar = false;
                    Console.WriteLine("Regresando al menú principal...");
                    break;

                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }
    }
}
