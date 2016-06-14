using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hash
{
    class Program
    {
        static void Main(string[] args)
        {

        }

        private static string Hash(string cadena)
        {
            if (cadena.Length == 0) return string.Empty;
                
            
            int primeraLetra = Convert.ToInt32(cadena[0]);

            if (cadena.Length == 1) return (primeraLetra % 255).ToString();

            int ultimaLetra = Convert.ToInt32(cadena[cadena.Length-1]);

            return ((primeraLetra + ultimaLetra) % 255).ToString();
        }
    }
}
