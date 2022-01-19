using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class CartaCarcel : InterfazCartas
    {
        void InterfazCartas.SacarCarta(int numero, Jugador afectado)
        {
            if(numero == 1)
            {
                afectado.salirCarcel = true;
            }

            Console.WriteLine("Has sacado una CARTA para SALIR DE LA CÁRCEL");
            Console.WriteLine("Pulsa ENTER para CONTINUAR");
            Console.ReadLine();
        }
    }
}
