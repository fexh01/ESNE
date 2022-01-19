using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Compañia : Casilla
    {
        private int precio;
        private Jugador dueño;
        private int alquiler;

        public Compañia(int num, string name, int prec, int alqui) : base(num, name)
        {
            dueño = null;
            comprable = true;
            precio = prec;
            alquiler = alqui;
        }

        public override void Caer(Jugador caido)
        {
            if(dueño == null)
            {
                int comprar = 0;
                Console.WriteLine("Esta casilla no es de nadie");
                Console.WriteLine("Pulsa 1 para COMPRAR por " + precio + " euros") ;
                Console.WriteLine("Pulsa 2 para PASAR el TURNO");
                while (!int.TryParse(Console.ReadLine(), out comprar) || comprar < 1 || comprar > 2)
                {
                    Console.WriteLine("Valor incorrecto, inserte de nuevo: ");
                }
                if (comprar == 1)
                {
                    SetDueño(caido);
                    caido.dinero = caido.dinero - precio;
                    Console.WriteLine("Ahora esta casilla es tuya");
                    Console.WriteLine("Pulsa ENTER PARA CONTINUAR");
                    Console.ReadLine();
                }
            }
            else if (dueño == caido)
            {
                Console.WriteLine("Esta casilla ya es tuya");
                Console.WriteLine("Pulsa ENTER PARA CONTINUAR");
                Console.ReadLine();
            }
            else
            {
                dueño.dinero = dueño.dinero + GetAlquiler();
                caido.dinero = caido.dinero - GetAlquiler();
                Console.WriteLine("Esta casilla es de " + dueño.nombre);
                Console.WriteLine("Le pagas " + GetAlquiler() + " euros");
                Console.WriteLine("Pulsa ENTER para CONTINUAR");
                Console.ReadLine();
            }
        }

        public override int GetAlquiler()
        {
            return alquiler;
        }
        
        public override Jugador GetDueño()
        {
            return dueño;
        }

        public override void SetDueño(Jugador compra)
        {
            dueño = compra;
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