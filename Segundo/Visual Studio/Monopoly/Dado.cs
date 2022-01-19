using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JuegoConsola
{
    class Dado
    {
        private int resultado;

        //Estas dos variables para las que recibirá valores en el constructor están 
        //para que esta clase se pueda reutilizar y crear un dado con cualquier rango
        //..................................
        private int min;
        private int max;
        //..................................

        private Random dado = new Random();

        //Constructor con el que se especifica el rango del dado
        public Dado(int minimo, int maximo)
        {
            min = minimo;
            max = maximo;

        }

        //Función que sirve para tirar el dado, al usar el mínimo y el máximo 
        //en el next se le añade un +1 para que sea más intuitivo usarlo
        public int Tirar()
        {
            resultado = dado.Next(min, max+1);
            return resultado;
        }
    }
}
