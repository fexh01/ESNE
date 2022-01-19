using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace Entrega2_FelixHernandez_JavierIregui
{
    class Juego
    {
        int choise;
        bool volvermenu = true;
        int menu;


        public Juego()
        {

            while (volvermenu == true)
            {
                Console.Clear();// menu de inicio
                Console.WriteLine("---------------------------------");
                Console.WriteLine("| ·Bienvenido a Beat the Beast· |");
                Console.WriteLine("---------------------------------");
                Console.WriteLine("");
                Console.WriteLine("Hecho por Félix Hernández Muñoz-Yusta");
                Console.WriteLine("");
                Console.WriteLine("Pulsa 1 para JUGAR");
                Console.WriteLine("Pulsa 2 para ver las INSTRUCCIONES");
                Console.WriteLine("Pulsa 3 para SALIR");
                Console.WriteLine("");

                try
                {
                    menu = Convert.ToInt32(Console.ReadLine());
                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fallo en la insercion de variable");
                    Console.WriteLine("");
                    Console.Write("Intentelo de nuevo");
                }

                switch (menu)
                {
                    case 1:

                        volvermenu = false;
                        MenuP();

                        break;

                    case 2:

                        Instrucciones();

                        break;

                    case 3:

                        Console.WriteLine("");
                        Console.WriteLine("Fin del programa"); //finalizador del programa
                        volvermenu = false;
                        Console.WriteLine(" ");
                        Console.WriteLine("Presione ENTER para finalizar");
                        Console.ReadKey();

                        break;

                    default:

                        Console.WriteLine("Error, introduce el parametro correcto"); // en caso de error

                        break;
                }

            }
        }
        void Instrucciones()// instrucciones del juego
        {
            Console.Clear();
            Console.WriteLine("Instrucciones del juego :");
            Console.WriteLine(" ");
            Console.WriteLine("Este juego se basa en la elección de opciones");
            Console.WriteLine("Tendrá que seleccionar las opciones con los numeros del 1 al 9");
            Console.WriteLine("Solo se permitira introducir los números asignados, si no, se tendrá que volver a introducir el número");
            Console.WriteLine("Con estas opciones, tendrá que ir avanzando en el mundo eligiendo entre las diferentes opciones disponibles");

            Console.WriteLine(" ");
            Console.WriteLine("Presione ENTER para volver al menu");
            Console.ReadKey();
        }


        void MenuP()// menu de seleccion del personaje
        {


            Console.Clear();
            Console.WriteLine("Bienvenidos a una partida de :");
            Console.WriteLine("");
            Console.WriteLine("--------------------");
            Console.WriteLine("| ·Beat the Beast· |");
            Console.WriteLine("--------------------");
            Console.WriteLine("");

            Console.WriteLine("Seleccione su personaje");
            Console.WriteLine("1 - Arthur");
            Console.WriteLine("2 - Randvi");
            Console.Write("Seleccione con los botones 1 o 2:  ");

            bool seleccion_personaje = true;



            while (seleccion_personaje == true)
            {
                try
                {
                    choise = Convert.ToInt32(Console.ReadLine());

                }
                catch (FormatException)
                {
                    Console.WriteLine("");
                    Console.WriteLine("Fallo en la insercion de variable");
                    Console.WriteLine("");
                    Console.Write("Intentelo de nuevo: ");

                }



                if (choise == 1)
                {

                    Personaje Arthur = new Personaje(17, 20, 0, "Arthur");
                    Partida partida = new Partida(Arthur);


                    seleccion_personaje = false;
                }
                else if (choise == 2)
                {

                    Personaje Randvi = new Personaje(15, 25, 0, "Randvi");
                    Partida partida = new Partida(Randvi);



                    seleccion_personaje = false;
                }
                else
                {
                    Console.WriteLine("");
                    Console.Write("Parametro incorrecto, intentelo de nuevo: ");
                }
            }


        }
    }
}
