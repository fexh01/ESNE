using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class CasillaCarta : Casilla
    {
        int precio;
        Random rndMoverse = new Random();
        Random rndTipo = new Random();
        Random rndPagos = new Random();

        public CasillaCarta(int num, string name) : base(num, name)
        {
            comprable = false;
            precio = 0;
            tipo = "Carta";
        }

        public override void Caer(Jugador caido)
        {
            Console.WriteLine("Sacas una carta y...");
            int tipo = rndTipo.Next(1, 4);
            switch (tipo)
            {
                case 1:
                    int numCarcel = 1;
                    InterfazCartas cartaCarcel = new CartaCarcel();
                    cartaCarcel.SacarCarta(numCarcel,caido);
                    break;
                case 2:
                    int numMoverse = rndMoverse.Next(0, 39);
                    InterfazCartas cartaMoverse = new CartaMoverse();
                    cartaMoverse.SacarCarta(numMoverse, caido);
                    break;
                case 3:
                    int pago = 50 * (rndPagos.Next(-10, 10));
                    InterfazCartas cartaPagos = new CartaPagos();
                    cartaPagos.SacarCarta(pago, caido);
                    break;
            }
        }

        public override int GetAlquiler()
        {
            return 0;

        }

        public override Jugador GetDueño()
        {
            return null;
        }

        public override void SetDueño(Jugador compra)
        {

        }

        public override string GetNombre()
        {
            return this.nombre;
        }

        public override bool GetComprable()
        {
            return this.comprable;
        }

        public override int GetPrecio()
        {
            return this.precio;
        }

        public override void SetEdificios()
        {

        }
    }
}
