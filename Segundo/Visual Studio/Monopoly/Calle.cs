using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Calle : Casilla
    {
        int precio;
        private int alquilerOriginal;
        private int alquiler;
        private Jugador dueño;

        public Calle(int num, string name, int prec, int alqui) : base(num, name)
        {
            edificios = 0;
            tipo = "Calle";
            precio = prec;
            comprable = true;
            alquiler = alqui;
            alquilerOriginal = alqui;
        }

        public override void Caer(Jugador caido)
        {
            if (dueño == caido)
            {
                if(edificios < 5)
                {
                    int construir = 0;
                    Console.WriteLine("Esta casilla ya es tuya...");
                    Console.WriteLine("Pulsa 1 para CONSTRUIR una CASA por 200 euros");
                    Console.WriteLine("Pulsa 2 para PASAR el TURNO");
                    while (!int.TryParse(Console.ReadLine(), out construir) || construir < 1 || construir > 2)
                    {
                        Console.WriteLine("Valor incorrecto, inserte de nuevo: ");
                    }
                    if (construir == 1)
                    {
                        ++edificios;
                        caido.dinero = caido.dinero - 200;
                        Console.WriteLine("Acabas de CONSTRUIR un EDIFICIO");
                        Console.WriteLine("Esta propiedad ahora tiene " + edificios + " edificio(s)!");
                        Console.WriteLine("Los edificios suben el alquiler que otros jugadores tienen que pagar si caen aquí");
                        Console.WriteLine("Pulsa ENTER para CONTINUAR");
                        Console.ReadLine();
                    }
                }
                else
                {
                    Console.WriteLine("Esta casilla es tuya pero ya has construído el máximo de edificios");
                    Console.WriteLine("Pulsa ENTER para CONTINUAR");
                    Console.ReadLine();
                }
                
            }
            else if (dueño == null)
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
                }
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
            switch (edificios)
            {
                case 0:
                    alquiler = alquilerOriginal * 1;
                    break;
                case 1:
                    alquiler = alquilerOriginal * 2;
                    break;
                case 2:
                    alquiler = alquilerOriginal * 5;
                    break;
                case 3:
                    alquiler = alquilerOriginal * 10;
                    break;
                case 4:
                    alquiler = alquilerOriginal * 15;
                    break;
                case 5:
                    alquiler = alquilerOriginal * 20;
                    break;
            }
            return alquiler;
        }

        public override void SetEdificios()
        {
            edificios++;
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
    }
}
