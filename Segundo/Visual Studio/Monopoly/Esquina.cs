using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Esquina : Casilla
    {
        int precio;

        public Esquina(int num, string name) : base(num, name)
        {
            comprable = false;
            precio = 0;
        }

        public override void Caer(Jugador caido)
        {
            switch (caido.casillaPosicion)
            {
                case 10:
                    caido.turnosParado = 2;
                    Console.WriteLine("Has caído en la CÁRCEL, pierdes 2 TURNOS");
                    Console.WriteLine("Pulsa ENTER para CONTINUAR");
                    Console.ReadLine();
                    break;
                case 20:
                    Console.WriteLine("Estás en el PARKING GRATUITO");
                    Console.WriteLine("Pulsa ENTER para CONTINUAR");
                    Console.ReadLine();
                    break;
                case 30:
                    caido.turnosParado = 2;
                    caido.casillaPosicion = 10;
                    Console.WriteLine("Vas a la CÁRCEL 2 turnos");
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
