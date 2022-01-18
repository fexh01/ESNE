using System;
using System.IO;

namespace Amigo_invisible
{
    class Program
    {
        static void Main(string[] args)
        {
            int numeronombres = 0;
            // arrays 
            string[] lista = new string[30]; // lista que recoje los nombres
            string[] listarandom = new string[30]; // lista que los da mezclados
            int[] parejas = new int[15];
            int numparejas = 0;

            bool volvermenu = true;
            while (volvermenu == true) // para que repita el menu al acabar una opcion
            {
                // menu del juego
                Console.Clear();
                Console.WriteLine("Juego del amigo invisible:");
                Console.WriteLine("Introducir nombres -> Pulse 1");
                Console.WriteLine("¡Amigo Invisible! -> Pulse 2");
                Console.WriteLine("Salir -> Pulse 3");

                int menu = Convert.ToInt32(Console.ReadLine());

                switch (menu)
                {
                    case 1:
                        Console.Clear();
                        Console.WriteLine("Bienvenido al modo de seleccion. Porfavor, indique como desea jugar: ");
                        Console.WriteLine("Si desea jugar de uno en uno, pulse -> 1");
                        Console.WriteLine("Si desea jugar en parejas, pulse -> 2");

                        int modo = Convert.ToInt32(Console.ReadLine());

                        if (modo == 1)
                        {
                            recoger_nombres(ref numeronombres, ref lista);//funcion que recoje los nombres individuales
                        }else if (modo == 2)
                        {
                            recoger_nombres_pareja(ref numeronombres, ref numparejas, ref lista, ref parejas);
                        }
                        else
                        {
                            Console.WriteLine("Error, introduce el parametro correcto"); // en caso de error
                        }
                        
                        break;

                    case 2:

                        mezclar_nombres(ref numeronombres, ref lista, ref listarandom); // funcion que mezcla los nombres y los pone de forma circular

                        break;

                    case 3:

                        Console.WriteLine("Fin del programa"); //finalizador del programa
                        volvermenu = false;
                        Console.ReadKey();

                        break;
                 
                    default:

                        Console.WriteLine("Error, introduce el parametro correcto"); // en caso de error

                        break;
                }
            }



        }
        static void recoger_nombres(ref int numeronombres, ref string[] lista)
        {
            bool pedirnombres = true; //el usuario tiene que introducir los nombres de los jugadores
            Console.WriteLine("Introducir los nombres de los jugadores");
            while (numeronombres <= 31 && pedirnombres == true)
            {
                Console.Clear();
                Console.WriteLine("Introducir nombre del jugador " + (numeronombres + 1));
                lista[numeronombres] = Console.ReadLine();
                Console.WriteLine("¿Quieres añadir otro nombre?"); // cuando ya no quieres introducir mas nombres 
                Console.WriteLine("Si -> Pulse 1 \n No -> Pulse 2");
                int confirmacion = Convert.ToInt32(Console.ReadLine());
                if (confirmacion == 1)
                {
                    pedirnombres = true;
                }
                else if (confirmacion == 2)
                {
                    pedirnombres = false;
                }
                else
                {
                    Console.WriteLine("Error mantengase en los parametros preestablecidos"); //en caso de teclear la instruccion incorrecta
                }

                if (numeronombres < 31)
                {
                    ++numeronombres;
                }
                else if (numeronombres > 31)
                {
                    Console.WriteLine("Ya no se pueden añadir mas nombres");
                }
            }
        }
        static void recoger_nombres_pareja(ref int numeronombres, ref int numparejas, ref string[] lista, ref int[] parejas)
        {

            // aqui se guardan los nombres de las parejas
            parejas[numparejas] = numeronombres;

            Console.Clear();
            Console.WriteLine("Introducir el nombre del primer miembro de la pareja");
            lista[numeronombres] = Console.ReadLine();
            ++numeronombres;
            Console.WriteLine("Introducir el nombre del segundo miembro de la pareja");
            lista[numeronombres] = Console.ReadLine();
            ++numeronombres;

        }
        static void mezclar_nombres(ref int numeronombres, ref string[] lista, ref string[] listarandom)
        {
            Console.Clear();
            for (int i = 0; i < numeronombres; ++i)
            {
                bool usado = false;

                do
                {
                    //bool esPareja = false;

                    Random desordenar = new Random(); // desordenar nombres
                    int numrandom = desordenar.Next(0, numeronombres);

                    /*for (int j = 0; j < num_parejas; ++j)
                    {
                        if(num_random == parejas[j])                     // esta es la parte las parejas, pero despues de intentarlo durante horas no he consegido acercarme mas que esto 
                        {                                                // te lo dejo aqui expuesto para que veas los avances que tenia
                            esPareja = true;
                        }
                    }*/

                    if (lista[numrandom] == "usado" /*|| esPareja*/)
                    {
                        usado = true;
                    }
                    else
                    {
                        usado = false;
                        listarandom[i] = lista[numrandom];
                        lista[numrandom] = "usado";
                    }

                } while (usado);
            }

            Console.WriteLine(listarandom[numeronombres - 1] + " le regala a " + listarandom[0]);
            for (int i = 0; i < numeronombres - 1; i++)
            {
                Console.WriteLine(listarandom[i] + " le regala a " + listarandom[(i + 1)]);
            }
            Console.WriteLine(" ");
            Console.WriteLine("Presione entter para volver atras");
            Console.ReadKey();


        }

    }
}
