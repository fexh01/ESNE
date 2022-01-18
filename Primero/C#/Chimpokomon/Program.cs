using System;

namespace Chimpokomon
{
    class Program
    {
        static void Main(string[] args)
        {
            bool volvermenu = true;

			int chimpokomon = 11;
			int cuentadiametros;
			bool buscadiametros = false;
			int[] chimpokomonesnivel = new int[chimpokomon];
			chimpokomonesnivel[1] = 1;
			chimpokomonesnivel[2] = 105;
			chimpokomonesnivel[3] = 125;
			string[] chimpokomonesnombres = new string[chimpokomon];
			chimpokomonesnombres[1] = "Magikart";
			chimpokomonesnombres[2] = "Punkachu";
			chimpokomonesnombres[3] = "Shurmander";

			Console.WriteLine("Bienvenido a Chimpokomon");
            Console.WriteLine("¿Listo para convertirte en el mejor entrenador?");
            Console.WriteLine("Ahora debes escojer una de estas opciones");
            while (volvermenu == true)// bool para que se repita el menu
            {
                Console.WriteLine("Pulsa 1 -> Para introducir el diametro de la Chimpokobola");
                Console.WriteLine("Pulsa 2 -> Para crear un nuevo Chimpokomon");
                Console.WriteLine("Pulsa 3 -> Para crear una nueva bola");
                Console.WriteLine("Pulsa 4 -> Para finalizar el programa");
                int menu = Convert.ToInt32(Console.ReadLine());


               

                switch (menu)
                {
                    case 1:
                        Console.WriteLine("Introduce el diametro de la chimpokobola en centimetros");
                        int diametro = Convert.ToInt32(Console.ReadLine());
                        
                        for (cuentadiametros = 0;cuentadiametros < chimpokomonesnivel.Length && !buscadiametros; ++cuentadiametros)
                        {
                            if (chimpokomonesnivel[chimpokomon] == diametro)
                            {
                                Console.WriteLine("Podrias atrapar un " + chimpokomonesnombres[diametro]);
                                buscadiametros = true;
                            }
                        }

                        Console.WriteLine("Con el diametro que has introducido podrias capturar a :" );




                        break;
                    case 2:
                        int chimpos = 0;
                        Console.WriteLine("Introduce el nombre del nuevo Chimpokomon");
                        chimpokomonesnombres[4 + chimpos] = Console.ReadLine();
                        Console.WriteLine("Introdice el nivel del nuevo Chimpokomon");
                        chimpokomonesnivel[4 + chimpos] = Convert.ToInt32(Console.ReadLine());

                        break;
                    case 3:



                        break;
                    case 4://salida del juego
                        Console.Clear();
                        Console.WriteLine("Esperamos verte pronto entrenador\nPulsa Enter para salir");
                        Console.ReadLine();
                        volvermenu = false;
                        break;
                    default://en caso de error este ayudara al usuario
                        Console.WriteLine("Mantente el los valores indicados porfavor");
                        Console.ReadLine();
                        break;
                }
            }
        }
    }
}
