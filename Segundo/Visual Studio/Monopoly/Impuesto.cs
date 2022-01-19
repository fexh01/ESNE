using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Impuesto : Casilla
    {
        int precio;

        public Impuesto(int num, string name, int prec) : base(num, name)
        {
            comprable = false;
            precio = prec;
        }

        public override void Caer(Jugador caido)
        {
            caido.dinero = caido.dinero - precio;
            Console.WriteLine("Pagas " + precio + " euros de impuestos");
            Console.WriteLine("Pulsa ENTER para CONTINUAR");
            Console.ReadLine();
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
