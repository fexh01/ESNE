using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    public abstract class Casilla
    {
        protected int numero;
        protected string nombre;
        protected bool comprable;
        public string tipo;
        public int edificios;

        public abstract void Caer(Jugador caido);
        public abstract void SetEdificios();
        public abstract string GetNombre();
        public abstract bool GetComprable();
        public abstract int GetPrecio();
        public abstract int GetAlquiler();
        public abstract Jugador GetDueño();
        public abstract void SetDueño(Jugador compra);

        public Casilla(int num, string name)
        {
            numero = num;
            nombre = name;
        }
    }
}
