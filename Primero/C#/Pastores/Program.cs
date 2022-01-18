using System;

namespace Pastores
{
    class Program
    {

        static void desarrollo_de_juego(ref bool FinJuego, ref int num_filas, ref int num_columnas, ref string[,] piedras, ref int jugador, ref string jugador1, ref string jugador2,
           ref int num_piedras)
        {
            while (FinJuego == false)
            {
                bool reiniciar_turno = true;

                while (reiniciar_turno == true)
                {
                    Console.Clear();

                    //Con esto imprimimos el tablero por pantalla
                    for (int i = 0; i < num_filas; ++i)
                    {
                        for (int j = 0; j < num_columnas; ++j)
                        {
                            Console.Write(piedras[i, j]);
                        }
                        Console.WriteLine(" ");
                    }

                    if (jugador == 1) //Con esto el jugador al que le toque elige la fila
                    {
                        Console.WriteLine("  ");
                        Console.WriteLine("Es el turno de " + jugador1);
                        Console.WriteLine("De qué fila quieres retirar las piedras?");
                    }
                    else
                    {
                        Console.WriteLine("  ");
                        Console.WriteLine("Es el turno de " + jugador2);
                        Console.WriteLine("De qué fila quieres retirar las piedras?");
                    }

                    int fila = Convert.ToInt32(Console.ReadLine());

                    if (fila < 1 || fila > num_filas) // en caso de error al elegir fila
                    {
                        Console.Clear();
                        Console.WriteLine("Esta fila no existe");
                        Console.ReadLine();
                    }
                    else
                    {
                        int restantes = 0;

                        for (int k = 0; k < num_columnas; ++k)
                        {
                            if (piedras[(fila - 1), k] == " O ")
                            {
                                ++restantes;
                            }
                        }

                        if (restantes < 1)
                        {
                            Console.Clear();
                            Console.WriteLine("Esta fila ya está vacía");
                            Console.ReadLine();
                        }
                        //El jugador al que le toque elige cuantas piedras retirar
                        else
                        {
                            Console.WriteLine("Cuántas piedras quieres retirar? ");
                            int retirar = Convert.ToInt32(Console.ReadLine());

                            if (retirar > restantes)
                            {//en cas de intentar retirar demasiadas piedras
                                Console.Clear();
                                Console.WriteLine("No quedan suficientes piedras en esta fila");
                                Console.ReadLine();
                            }
                            else
                            {//esto indica qué piedras están retiradas y por quien
                                for (int l = 0; l < retirar; ++l)
                                {
                                    if (jugador == 1)
                                    {
                                        piedras[(fila - 1), (l + (num_columnas - restantes))] = " 1 ";
                                    }
                                    else
                                    {
                                        piedras[(fila - 1), (l + (num_columnas - restantes))] = " 2 ";
                                    }
                                }

                                num_piedras = num_piedras - retirar;

                                reiniciar_turno = false;
                                //indica quien ha ganado cuando solo queda una piedra
                                if (num_piedras == 1)
                                {
                                    if (jugador == 1)
                                    {
                                        FinJuego = true;
                                        Console.Clear();
                                        Console.WriteLine("ENHORABUENA " + jugador1 + ", HAS GANADO!");
                                        Console.WriteLine("Pulsa ENTER para VOLVER al MENÚ PRINCIPAL");
                                        Console.ReadLine();
                                    }
                                    else
                                    {
                                        FinJuego = true;
                                        Console.Clear();
                                        Console.WriteLine("ENHORABUENA " + jugador2 + ", HAS GANADO!");
                                        Console.WriteLine("Pulsa ENTER para VOLVER al MENÚ PRINCIPAL");
                                        Console.ReadLine();
                                    }

                                }
                                //cambia de jugador cada turno
                                if (jugador == 1)
                                {
                                    jugador = 2;
                                }
                                else
                                {
                                    jugador = 1;
                                }
                            }
                        }
                    }
                }
            }
        }



        static void cambiar_tablero(ref int num_filas, ref int num_columnas)
        {
            Console.Clear();
            Console.WriteLine("·DIMENSIONES DEL TABLERO·");
            Console.WriteLine("Número de filas: ");
            num_filas = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Número de columnas: ");
            num_columnas = Convert.ToInt32(Console.ReadLine());
        }


        static void introducir_nombre_jugador(out string jugador1, out string jugador2)
        {
            Console.Write("Nombre del Jugador 1: ");
            jugador1 = Console.ReadLine();
            Console.Write("Nombre del Jugador 2: ");
            jugador2 = Console.ReadLine();
        }
        static void crear_tablero(ref int num_filas, ref int num_columnas, ref string[,] piedras)
        {
            for (int i = 0; i < num_filas; ++i)
            {
                for (int j = 0; j < num_columnas; ++j)
                {
                    piedras[i, j] = " O ";
                }
            }

        }
        static int MostrarMenu()
        {
            Console.Clear();// menu de inicio
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("| ·BIENVENIDO AL JUEGO DE LOS PASTORES· |");
            Console.WriteLine("-----------------------------------------");
            Console.WriteLine("Hecho por Daniel Fontecha, Javier Iregui y Félix Hernández");
            Console.WriteLine("  ");
            Console.WriteLine("Pulsa 1 para JUGAR");
            Console.WriteLine("Pulsa 2 para ver las INSTRUCCIONES");
            Console.WriteLine("Pulsa 3 para SALIR");
            Console.WriteLine("  ");

            return Convert.ToInt32(Console.ReadLine());
        }

        static void Jugar()
        {
            //Estas variables determinan el tamaño del tablero y se pueden cambiar dichas dimensiones ya que lo hemos
            // hecho con una matriz idimensional que aprendimos a usar buscando en un libro sobre c#
            int num_filas = 4;
            int num_columnas = 6;

            //Esta variable la usamos para que vuelva al menú de juego tras cambiar las proporciones del tablero
            bool volver_jugar = true;

            while (volver_jugar == true)
            {
                Console.Clear();// menu de juego
                Console.WriteLine("·JUGAR·");
                Console.WriteLine("  ");
                Console.WriteLine("Pulsa 1 para JUGAR ( " + num_filas + " X " + num_columnas + " )");
                Console.WriteLine("Pulsa 2 para CAMBIAR las DIMENSIONES del TABLERO");
                Console.WriteLine("Pulsa 3 para VOLVER al MENÚ PRINCIPAL");

                int opcion_jugar = Convert.ToInt32(Console.ReadLine());

                switch (opcion_jugar)
                {
                    case 1:

                        //Aqui creamos las variables que se van a usar durante el juego
                        Console.Clear();
                        int num_piedras = num_filas * num_columnas;
                        int jugador = 1;
                        string jugador1;
                        string jugador2;
                        volver_jugar = false;
                        string[,] piedras = new string[num_filas, num_columnas];
                        bool FinJuego = false;

                        //Aquí creamos el tablero
                        crear_tablero(ref num_filas, ref num_columnas, ref piedras);

                        //Aquí se introducen los nombres de los jugadores
                        introducir_nombre_jugador(out jugador1, out jugador2);

                        //Aquí se desarrolla el juego
                        desarrollo_de_juego(ref FinJuego, ref num_filas, ref num_columnas, ref piedras, ref jugador, ref jugador1, ref jugador2,
                         ref num_piedras);

                        break;

                    case 2:
                        //te permite cambiar las dimensiones del tablero
                        cambiar_tablero(ref num_filas, ref num_columnas);

                        break;

                    case 3:
                        //al poner en false esta variable ya no vuelve al menu de juego si no al principal
                        volver_jugar = false;

                        break;

                    default:
                        //para que no se pueda pulsar una opcion que no existe
                        Console.Clear();
                        Console.WriteLine("Esa no es una de las opciones");
                        Console.WriteLine("Pulsa ENTER para VOLVER");
                        Console.ReadLine();

                        break;
                }
            }
        }

        static void MostrarInstrucciones()
        {//muestra las instrucciones
            Console.Clear();
            Console.WriteLine("·INSTRUCCIONES·");
            Console.WriteLine("  ");
            Console.WriteLine("Los dos jugadores se irán turnando para quitar las piedras que quieran de");
            Console.WriteLine("una misma fila por turno. El objetivo del juego es hacer que el oponente tenga");
            Console.WriteLine("que retirar la última piedra.");
            Console.WriteLine("Al comenzar la partida podrás determinar las dimensiones del tablero.");
            Console.WriteLine("  ");
            Console.WriteLine("Pulsa ENTER para VOLVER al MENÚ");
            Console.ReadLine();
        }

        static void Main(string[] args)
        {
            bool volver_menu = true;//con esta variable se vuelve al menu principal cuando sea necesario

            while (volver_menu == true)
            {
                int opcion_menu = MostrarMenu();//llama a la funcion MostrarMenu para elegir una opcion para el switch

                switch (opcion_menu)
                {
                    case 1:

                        Jugar();//llama a la funcion jugar

                        break;

                    case 2:

                        MostrarInstrucciones();//Llama a la funcion MostrarInstrucciones

                        break;

                    case 3:
                        //Con esto se sale del juego al establecer el bool volver_menu en false
                        Console.Clear();
                        Console.WriteLine("GRACIAS POR JUGAR!");
                        Console.WriteLine("Pulsa ENTER para SALIR");
                        Console.ReadLine();

                        volver_menu = false;

                        break;

                    default:
                        //para que no se pueda elegir una opcion que no existe
                        Console.Clear();
                        Console.WriteLine("Esa no es una de las opciones");
                        Console.WriteLine("Pulsa ENTER para VOLVER al MENÚ");
                        Console.ReadLine();

                        break;
                }

            }
        }

    }
}
