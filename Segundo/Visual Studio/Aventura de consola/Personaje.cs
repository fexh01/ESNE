using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.IO;

namespace Entrega2_FelixHernandez_JavierIregui
{
    class Personaje
    {
        public int vida;
        public int oro;
        public int arma;
        public string nombre;

        public Personaje(int vida_, int oro_, int arma_, string nombre_)
        {
            vida = vida_;
            oro = oro_;
            arma = arma_;
            nombre = nombre_;
        }


        public void Ataque()
        {
            Random rnd = new Random();
            int daño = rnd.Next(1, 11);

            Console.WriteLine("-- " + nombre + " ha provocado un daño de " + daño + " --");
            Console.WriteLine("");

        }

        public void Curar()
        {

            Console.WriteLine("");
            Console.WriteLine("-- " + nombre + " ha recuperado 4 puntos de vida --");
            vida = vida + 4;
            Console.WriteLine("");
            Thread.Sleep(800);
            Console.WriteLine("-- " + nombre + " tiene " + vida + " puntos de vida --");
            Thread.Sleep(2000);
            Console.WriteLine("");
        }

    }
}
