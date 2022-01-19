using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class CartaPagos : InterfazCartas
    {
        void InterfazCartas.SacarCarta(int numero, Jugador afectado)
        {
            afectado.dinero = afectado.dinero + numero;
            if(numero < 0)
            {
                Console.WriteLine("Pagas una multa de " + numero + " euros");
            }
            else
            {
                Console.WriteLine("Recibes " + numero + " euros");
            }
            Console.WriteLine("Pulsa ENTER para CONTINUAR");
            Console.ReadLine();
        }
    }
}
