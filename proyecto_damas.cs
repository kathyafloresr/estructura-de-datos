using System;
using System.IO;
using System.Threading;
using System.Diagnostics;

class Damas
{
    const int N = 8;
    const string ARCH = "partida.txt";

    // Segundos que tiene cada jugador para completar su turno
    const int TIEMPO_TURNO = 20;

    // 0 = vacio
    // 1 = jugador 1
    // 2 = jugador 2
    // 3 = rey jugador 1
    // 4 = rey jugador 2
    static int[,] tab = new int[N, N];

    // Jugador que tiene el turno
    static int jug = 1;

    // Resultado de un turno
    enum Resultado { Normal, Rendido, Tiempo }

    // MENU
    static void Main()
    {
        int op = 0;
        while (op != 3)
        {
            Console.Clear();
            Console.WriteLine("===== DAMAS INGLESAS =====");
            Console.WriteLine("1. Nueva partida");
            Console.WriteLine("2. Reproducir partida");
            Console.WriteLine("3. Salir");
            Console.Write("Opcion: ");
            int.TryParse(Console.ReadLine(), out op);
            if (op == 1)
                Nueva();
            if (op == 2)
                Rep();
        }
    }

    // EMPEZAR PARTIDA
    static void Nueva()
    {
        Crear();
        jug = 1;
        // Crea un archivo nuevo
        File.WriteAllText(ARCH, "INICIO\n");
        while (true)
        {
            Console.Clear();
            Ver();
            Console.WriteLine("\nTurno del jugador " + jug);
            // Si no puede mover, pierde
            if (!Puede(jug))
            {
                Console.WriteLine("No puedes mover.");
                Console.WriteLine("Gana el jugador " + Otro());
                Fin(Otro());
                break;
            }

            Resultado r = Turno();

            // El jugador se rindio
            if (r == Resultado.Rendido)
            {
                Console.Clear();
                Ver();
                Console.WriteLine("\nEl jugador " + jug + " se rindio.");
                Console.WriteLine("Gana el jugador " + Otro());
                Guarda_Rendicion(jug);
                Fin(Otro());
                break;
            }

            // Se le acabo el tiempo, pierde el turno (no el juego)
            if (r == Resultado.Tiempo)
            {
                Console.WriteLine("\n¡Se acabo el tiempo! El jugador " + jug + " pierde su turno.");
                Guarda_Tiempo(jug);
                Console.ReadKey();
                jug = Otro();
                continue;
            }

            // Cambia de jugador
            jug = Otro();
            // Si ya no tiene piezas, pierde
            if (!Tiene(jug))
            {
                Console.Clear();
                Ver();
                Console.WriteLine("\nJugador " + jug + " se quedo sin piezas.");
                Console.WriteLine("Gana el jugador " + Otro());
                Fin(Otro());
                break;
            }
        }
        Console.WriteLine("\nPartida guardada.");
        Console.ReadKey();
    }

    // CREAR TABLERO
    static void Crear()
    {
        // Vaciar tablero
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
                tab[i, j] = 0;
        }
        // Jugador 2
        for (int i = 0; i < 3; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if ((i + j) % 2 != 0)
                    tab[i, j] = 2;
            }
        }
        // Jugador 1
        for (int i = 5; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if ((i + j) % 2 != 0)
                    tab[i, j] = 1;
            }
        }
    }

    // MOSTRAR TABLERO
    static void Ver()
    {
        Console.WriteLine("   1 2 3 4 5 6 7 8");
        for (int i = 0; i < N; i++)
        {
            Console.Write((i + 1) + "  ");
            for (int j = 0; j < N; j++)
            {
                char p = '.';
                // Jugador 1
                if (tab[i, j] == 1)
                {
                    p = 'X';
                    Console.ForegroundColor = ConsoleColor.Red;
                }
                // Jugador 2
                else if (tab[i, j] == 2)
                {
                    p = 'O';
                    Console.ForegroundColor = ConsoleColor.Blue;
                }
                // Reyes
                else if (tab[i, j] == 3)
                {
                    p = 'K';
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else if (tab[i, j] == 4)
                {
                    p = 'Q';
                    Console.ForegroundColor = ConsoleColor.Magenta;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Gray;
                }
                Console.Write(p + " ");
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        Console.WriteLine("\nX = Jugador 1");
        Console.WriteLine("O = Jugador 2");
        Console.WriteLine("K = Rey jugador 1");
        Console.WriteLine("Q = Rey jugador 2");
    }

    // MUESTRA UNA LISTA DE OPCIONES Y DEJA ELEGIR CON LAS FLECHAS
    // Arriba/Abajo mueve el ">", ENTER elige, R se rinde.
    // Devuelve Resultado.Normal y el indice elegido en "elegido",
    // o Resultado.Rendido / Resultado.Tiempo si paso alguna de esas cosas.
    static Resultado ElegirOpcion(string[] opciones, out int elegido, Stopwatch cron)
    {
        int sel = 0;
        bool dibujar = true;
        while (true)
        {
            if (dibujar)
            {
                Console.Clear();
                Ver();
                Console.WriteLine();
                for (int i = 0; i < opciones.Length; i++)
                    Console.WriteLine((i == sel ? "> " : "  ") + opciones[i]);
                Console.WriteLine("\nFlechas arriba/abajo: moverte   ENTER: elegir   R: rendirte");
                dibujar = false;
            }

            int restante = TIEMPO_TURNO - (int)cron.Elapsed.TotalSeconds;
            if (restante <= 0)
            {
                elegido = -1;
                return Resultado.Tiempo;
            }

            if (Console.KeyAvailable)
            {
                ConsoleKeyInfo t = Console.ReadKey(true);
                if (t.Key == ConsoleKey.R)
                {
                    elegido = -1;
                    return Resultado.Rendido;
                }
                if (t.Key == ConsoleKey.UpArrow)
                {
                    sel = (sel - 1 + opciones.Length) % opciones.Length;
                    dibujar = true;
                }
                else if (t.Key == ConsoleKey.DownArrow)
                {
                    sel = (sel + 1) % opciones.Length;
                    dibujar = true;
                }
                else if (t.Key == ConsoleKey.Enter)
                {
                    elegido = sel;
                    return Resultado.Normal;
                }
            }
            else
            {
                // Actualiza el tiempo en la misma linea (sin borrar la pantalla)
                Console.Write("\rTiempo restante: " + restante + "s   ");
                Thread.Sleep(100);
            }
        }
    }

    // HACER UN TURNO (con flechas, rendicion y tiempo)
    static Resultado Turno()
    {
        bool comer = HayCom();
        int[] filas = new int[24];
        int[] cols = new int[24];
        int total = 0;
        // Buscar fichas que se puedan mover
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (Jug(tab[i, j]) != jug)
                    continue;
                bool puede;
                if (comer)
                    puede = Come(i, j);
                else
                    puede = MovDir(i, j, -1) ||
                            MovDir(i, j, 1);
                if (puede)
                {
                    filas[total] = i;
                    cols[total] = j;
                    total++;
                }
            }
        }

        Stopwatch cron = Stopwatch.StartNew();

        // Armar la lista de fichas disponibles
        string[] opcionesFichas = new string[total];
        for (int i = 0; i < total; i++)
        {
            opcionesFichas[i] = "Ficha en (" + (filas[i] + 1) + "," + (cols[i] + 1) + ")";
            if (comer)
                opcionesFichas[i] += " [DEBE COMER]";
        }

        // Elegir ficha
        int elegido;
        Resultado r = ElegirOpcion(opcionesFichas, out elegido, cron);
        if (r != Resultado.Normal)
            return r;

        int f = filas[elegido];
        int c = cols[elegido];

        // Elegir direccion (y encadenar capturas si hay)
        while (true)
        {
            bool izq;
            bool der;
            if (comer)
            {
                izq = ComeDir(f, c, -1);
                der = ComeDir(f, c, 1);
            }
            else
            {
                izq = MovDir(f, c, -1);
                der = MovDir(f, c, 1);
            }

            // Armar opciones de direccion
            int nDir = (izq ? 1 : 0) + (der ? 1 : 0);
            string[] opcionesDir = new string[nDir];
            int[] lados = new int[nDir];
            int idx = 0;
            if (izq)
            {
                opcionesDir[idx] = "Izquierda";
                lados[idx] = -1;
                idx++;
            }
            if (der)
            {
                opcionesDir[idx] = "Derecha";
                lados[idx] = 1;
                idx++;
            }

            int elegidoDir;
            Resultado r2 = ElegirOpcion(opcionesDir, out elegidoDir, cron);
            if (r2 != Resultado.Normal)
                return r2;

            int lado = lados[elegidoDir];

            int f2;
            int c2;
            // SI ES CAPTURA
            if (comer)
            {
                f2 = f + (jug == 1 ? -2 : 2);
                c2 = c + lado * 2;
                Comer(f, c, f2, c2);
                Rey(f2, c2);
                Guarda("C", f, c, f2, c2);
            }
            // MOVIMIENTO NORMAL
            else
            {
                f2 = f + (jug == 1 ? -1 : 1);
                c2 = c + lado;
                tab[f2, c2] = tab[f, c];
                tab[f, c] = 0;
                Rey(f2, c2);
                Guarda("M", f, c, f2, c2);
                return Resultado.Normal;
            }

            // Revisar si puede seguir comiendo con la misma ficha
            if (!Come(f2, c2))
                return Resultado.Normal;

            Console.Clear();
            Ver();
            Console.WriteLine("\n¡PUEDES SEGUIR COMIENDO!");
            Console.ReadKey(true);

            f = f2;
            c = c2;
        }
    }

    // REVISA SI PUEDE MOVERSE
    static bool MovDir(int f, int c, int lado)
    {
        if (Jug(tab[f, c]) != jug)
            return false;
        int p = tab[f, c];
        // Los reyes pueden ir hacia arriba o abajo
        if (p == 3 || p == 4)
        {
            return Mov(f, c, f - 1, c + lado) ||
                   Mov(f, c, f + 1, c + lado);
        }
        int nf = f + (p == 1 ? -1 : 1);
        int nc = c + lado;
        return Mov(f, c, nf, nc);
    }

    // REVISA SI PUEDE COMER
    static bool ComeDir(int f, int c, int lado)
    {
        if (Jug(tab[f, c]) != jug)
            return false;
        int p = tab[f, c];
        // El rey puede comer hacia ambos lados
        if (p == 3 || p == 4)
        {
            return PuedeComer(f, c, f - 2, c + lado * 2) ||
                   PuedeComer(f, c, f + 2, c + lado * 2);
        }
        int nf = f + (p == 1 ? -2 : 2);
        return PuedeComer(f, c, nf, c + lado * 2);
    }

    // REVISA SI LA CASILLA ESTA LIBRE
    static bool Mov(int f1, int c1, int f2, int c2)
    {
        if (f2 < 0 || f2 >= N ||
            c2 < 0 || c2 >= N)
            return false;
        return tab[f2, c2] == 0;
    }

    // REVISA SI PUEDE HACER UNA CAPTURA
    static bool PuedeComer(int f1, int c1, int f2, int c2)
    {
        // Revisar limites
        if (f2 < 0 || f2 >= N ||
            c2 < 0 || c2 >= N)
            return false;
        // La casilla final debe estar vacia
        if (tab[f2, c2] != 0)
            return false;
        int p = tab[f1, c1];
        int df = f2 - f1;
        int dc = c2 - c1;
        // La captura debe avanzar 2 casillas
        if (Math.Abs(df) != 2 ||
            Math.Abs(dc) != 2)
            return false;
        // Las fichas normales solo avanzan hacia adelante
        if (p == 1 && df != -2)
            return false;
        if (p == 2 && df != 2)
            return false;
        // Buscar la ficha que esta en medio
        int mf = (f1 + f2) / 2;
        int mc = (c1 + c2) / 2;
        int enemigo = tab[mf, mc];
        // Debe haber una ficha enemiga
        return enemigo != 0 &&
               Jug(enemigo) != jug;
    }

    // REVISA SI PUEDE COMER
    static bool Come(int f, int c)
    {
        return PuedeComer(f, c, f - 2, c - 2) ||
               PuedeComer(f, c, f - 2, c + 2) ||
               PuedeComer(f, c, f + 2, c - 2) ||
               PuedeComer(f, c, f + 2, c + 2);
    }

    // HACE UNA CAPTURA
    static void Comer(int f1, int c1, int f2, int c2)
    {
        // Buscar la ficha del medio
        int mf = (f1 + f2) / 2;
        int mc = (c1 + c2) / 2;
        // Mover la ficha
        tab[f2, c2] = tab[f1, c1];
        tab[f1, c1] = 0;
        // Quitar la ficha comida
        tab[mf, mc] = 0;
    }

    // CONVERTIR EN REY
    static void Rey(int f, int c)
    {
        if (tab[f, c] == 1 && f == 0)
            tab[f, c] = 3;
        if (tab[f, c] == 2 && f == 7)
            tab[f, c] = 4;
    }

    // SABER DE QUE JUGADOR ES
    static int Jug(int p)
    {
        if (p == 1 || p == 3)
            return 1;
        if (p == 2 || p == 4)
            return 2;
        return 0;
    }

    // CAMBIAR DE JUGADOR
    static int Otro()
    {
        return jug == 1 ? 2 : 1;
    }

    // REVISA SI TODAVIA TIENE PIEZAS
    static bool Tiene(int j)
    {
        for (int i = 0; i < N; i++)
        {
            for (int c = 0; c < N; c++)
            {
                if (Jug(tab[i, c]) == j)
                    return true;
            }
        }
        return false;
    }

    // REVISA SI PUEDE HACER ALGUN MOVIMIENTO
    static bool Puede(int j)
    {
        for (int i = 0; i < N; i++)
        {
            for (int c = 0; c < N; c++)
            {
                if (Jug(tab[i, c]) != j)
                    continue;
                if (Come(i, c))
                    return true;
                if (MovDir(i, c, -1) ||
                    MovDir(i, c, 1))
                    return true;
            }
        }
        return false;
    }

    // REVISA SI HAY QUE COMER
    static bool HayCom()
    {
        for (int i = 0; i < N; i++)
        {
            for (int j = 0; j < N; j++)
            {
                if (Jug(tab[i, j]) == jug &&
                    Come(i, j))
                    return true;
            }
        }
        return false;
    }

    // GUARDAR MOVIMIENTO
    static void Guarda(string tipo, int f1, int c1, int f2, int c2)
    {
        File.AppendAllText(
            ARCH,
            tipo + "|" + jug + "|" + f1 + "|" + c1 + "|" + f2 + "|" + c2 + "\n");
    }

    // GUARDAR RENDICION
    static void Guarda_Rendicion(int j)
    {
        File.AppendAllText(ARCH, "R|" + j + "\n");
    }

    // GUARDAR PERDIDA DE TURNO POR TIEMPO
    static void Guarda_Tiempo(int j)
    {
        File.AppendAllText(ARCH, "T|" + j + "\n");
    }

    // GUARDAR GANADOR
    static void Fin(int gana)
    {
        File.AppendAllText(
            ARCH,
            "FIN|" + gana + "\n");
    }

    // REPRODUCIR PARTIDA
    static void Rep()
    {
        // Revisar si existe la partida
        if (!File.Exists(ARCH))
        {
            Console.WriteLine("No hay partida guardada.");
            Console.ReadKey();
            return;
        }
        // Leer partida
        string[] lineas = File.ReadAllLines(ARCH);
        // Empezar desde el tablero original
        Crear();
        // Hacer cada movimiento guardado
        foreach (string linea in lineas)
        {
            string[] d = linea.Split('|');

            // Rendicion
            if (d[0] == "R")
            {
                Console.Clear();
                Ver();
                Console.WriteLine("\nJugador " + d[1] + " se rindio.");
                Console.ReadKey();
                continue;
            }
            // Perdio el turno por tiempo
            if (d[0] == "T")
            {
                Console.Clear();
                Ver();
                Console.WriteLine("\nJugador " + d[1] + " perdio su turno por tiempo.");
                Thread.Sleep(800);
                continue;
            }
            // Ignorar INICIO, FIN y cualquier otro tipo
            if (d[0] != "M" && d[0] != "C")
                continue;

            int f1 = int.Parse(d[2]);
            int c1 = int.Parse(d[3]);
            int f2 = int.Parse(d[4]);
            int c2 = int.Parse(d[5]);
            // Mover ficha
            tab[f2, c2] = tab[f1, c1];
            tab[f1, c1] = 0;
            // Si fue captura, quitar ficha
            if (d[0] == "C")
            {
                int mf = (f1 + f2) / 2;
                int mc = (c1 + c2) / 2;
                tab[mf, mc] = 0;
            }
            // Revisar rey
            Rey(f2, c2);
            Console.Clear();
            Console.WriteLine(
                "Jugador " + d[1] + (d[0] == "C" ? " COME" : " MUEVE"));
            Console.WriteLine("De (" + (f1 + 1) + "," + (c1 + 1) + ")" + " a (" + (f2 + 1) + "," + (c2 + 1) + ")");
            Console.WriteLine();
            Ver();
            // Esperar antes del siguiente movimiento
            Thread.Sleep(800);
        }
        Console.WriteLine("\nReproduccion terminada.");
        Console.ReadKey();
    }
}
