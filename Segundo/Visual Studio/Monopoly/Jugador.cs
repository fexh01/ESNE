using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    public class Jugador
    {
        public int estaciones;
        public bool expulsado;
        public string nombre;
        public int casillaPosicion;
        public string casillaPosicionNombre;
        public bool salirCarcel;
        public int dinero;
        public int turnosParado;
        public Jugador(string name)
        {
            turnosParado = 0;
            estaciones = 0;
            nombre = name;
            dinero = 1500;
            casillaPosicion = 0;
            salirCarcel = false;
            expulsado = false;
        }

        public int TirarDado()
        {
            Dado dado = new Dado(2, 12);
            int numDado = dado.Tirar();

            Console.WriteLine("  ");
            Console.WriteLine("Has tirado los dados y ha saliado un " + numDado + "!");
            Console.WriteLine("Pulsa ENTER para MOVERTE");

                return numDado;
        }
    }
}
