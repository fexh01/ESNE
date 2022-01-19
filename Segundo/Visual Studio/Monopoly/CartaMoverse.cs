using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class CartaMoverse : InterfazCartas
    {
        void InterfazCartas.SacarCarta(int numero, Jugador afectado)
        {
            int posicionOriginal = afectado.casillaPosicion;
            afectado.casillaPosicion = (afectado.casillaPosicion + numero) % 40;
            Console.WriteLine("Avanzas " + numero + " casillas");

            if (posicionOriginal > afectado.casillaPosicion && numero != 10)
            {
                afectado.dinero = afectado.dinero + 200;
                Console.WriteLine("Pasas por la casilla de SALIDA y RECIBES 200 euros");
            }
            else if (numero == 10)
            {
                afectado.turnosParado = 2;
            }

            Console.WriteLine("Pulsa ENTER para CONTINUAR");
            Console.ReadLine();
        }
    }
}
