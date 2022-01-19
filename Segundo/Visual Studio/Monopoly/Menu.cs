using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Menu
    {
        //Contienen las letras en ASCII para los títulos
        //..............................
        private string logo = @"
 __  __  ____  _   _  ____  _____   ____  _  __     __
|  \/  |/ __ \| \ | |/ __ \|  __ \ / __ \| | \ \   / /
| \  / | |  | |  \| | |  | | |__) | |  | | |  \ \_/ / 
| |\/| | |  | | . ` | |  | |  ___/| |  | | |   \   /  
| |  | | |__| | |\  | |__| | |    | |__| | |____| |   
|_|  |_|\____/|_| \_|\____/|_|     \____/|______|_|   

";
        private string creditos = @"
  _____              _ _ _            
/ ____ |            | (_) |
| |     _ __ ___  __| |_| |_ ___  ___ 
| |    | '__/ _ \/ _` | | __/ _ \/ __|
| |____| | |  __/ (_| | | || (_) \__ \
 \_____|_|  \___|\__,_|_|\__\___/|___/


           REALIZADO POR

           Javier Iregui
                y
          Félix Hernández
";
        //..............................

        //Muestra el logo del juego
        private void PrintLogo()
        {
            Console.WriteLine(logo);
        }

        //Muestra los créditos
        private void PrintCreditos()
        {
            Console.Clear();
            Console.WriteLine(creditos);
            Console.WriteLine("");
            Console.WriteLine("");
            Console.WriteLine("Pulsa ENTER para VOLVER");
            Console.ReadLine();
            AccionesMenu();
        }

        //Sale del programa
        private void Exit()
        {
            System.Environment.Exit(0);
        }

        //Recoge el número de jugadores de la partida, guarda sus nombres
        //y crea un objeto de la clase Partida dando comienzo al juego
        //EXCEPCIONES
        private void ComenzarPartida()
        {
            Console.Clear();
            PrintLogo();
            int numJugadores;
            Console.WriteLine("Cuantos JUGADORES vais a ser? (2-8)");
            while (!int.TryParse(Console.ReadLine(), out numJugadores) || numJugadores < 2 || numJugadores > 8)
            {
                Console.WriteLine("Valor incorrecto, inserte de nuevo: ");
            }

            Console.Clear();
            string[] listaNombres = new string[numJugadores];
            for (int i = 0; i < numJugadores; i++)
            {
                PrintLogo();
                Console.WriteLine("Introduce el NOMBRE del JUGADOR " + (i+1) );
                listaNombres[i] = Console.ReadLine();
                Console.Clear();
            }

            Partida juego = new Partida(numJugadores, listaNombres);
            AccionesMenu();
        }

        //Recibe lo que el usuario selecciona desde el menu
        //EXCEPCIONES
        private int SeleccionMenu()
        {
            int opcionMenu;
            Console.Clear();

            PrintLogo();
            Console.WriteLine("Pulsa 1 para JUGAR");
            Console.WriteLine("Pulsa 2 para VER los CRÉDITOS");
            Console.WriteLine("Pulsa 3 para SALIR");

            while (!int.TryParse(Console.ReadLine(), out opcionMenu) || opcionMenu < 1 || opcionMenu > 3)
            {
                Console.Write("Valor incorrecto, inserte de nuevo: ");
            }

            return opcionMenu;
        }

        //Realiza lo que le pida el usuario desde el menu
        private void AccionesMenu()
        {
            int opcionMenu = SeleccionMenu();

            switch (opcionMenu)
            {
                case 1:
                    ComenzarPartida();

                    break;

                case 2:
                    PrintCreditos();

                    break;

                case 3:
                    Exit();

                    break;
            }
        }

        //Constructor del menu
        public Menu()
        {
            PrintLogo();
            Console.WriteLine("PULSA ENTER PARA CONTINUAR");
            Console.ReadKey();

            AccionesMenu();
        }
    }
}
