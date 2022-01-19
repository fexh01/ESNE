using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Estacion : Casilla
    {
        int precio;
        int alquiler;
        Jugador dueño;

        public Estacion(int num, string name) : base(num, name)
        {
            comprable = true;
            precio = 200;
            alquiler = 25;
        }

        public override void Caer(Jugador caido)
        {
            if (dueño == null)
            {
                int comprar = 0;
                Console.WriteLine("Esta casilla no es de nadie");
                Console.WriteLine("Pulsa 1 para COMPRAR por " + precio + " euros");
                Console.WriteLine("Pulsa 2 para PASAR el TURNO");
                while (!int.TryParse(Console.ReadLine(), out comprar) || comprar < 1 || comprar > 2)
                {
                    Console.WriteLine("Valor incorrecto, inserte de nuevo: ");
                }
                if (comprar == 1)
                {
                    SetDueño(caido);
                    caido.dinero = caido.dinero - precio;
                    caido.estaciones++;
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
            alquiler = Convert.ToInt32(alquiler * dueño.estaciones);
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
