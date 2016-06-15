using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Kmp
{
    class Program
    {
        static List<string> Diccionario = new List<string>();
        static List<string> Palindromas = new List<string>();


        static void Main(string[] args)
        {
            using (StreamReader sr = new StreamReader("kmp.txt"))
            {
                string line;
                while ((line = sr.ReadLine()) != null)
                {
                    Diccionario.Add(line);
                }
            }

            int totalPalindromas = 0;

            foreach (var item in Diccionario)
            {
                //si solo es de una letra de una vez la ponemos como palindroma
                if (item.Length == 1)
                {
                    totalPalindromas++;
                }
                else
                {
                    //agregamos como posibles palindromas la cadena invertida, la cadena invertida desde [1] y la cadena invertida hasta [length-1]
                    //ya que estas palabras siempre harán palindromas la palabra
                    Palindromas.Add(ReverseString(item.Substring(0, item.Length - 1)));
                    Palindromas.Add(ReverseString(item.Substring(1, item.Length - 1)));
                    Palindromas.Add(ReverseString(item));
                }

                //buscamos los prefijos con los que puede hacerse palindroma la palabra
                for (int i = item.Length - 2; i >= 1; --i)
                {
                    int size = item.Length - i;

                    //si el substring es palindromo quiere decir que el resto de la cadena invertida 
                    //hace la cadena palindroma
                    if (CheckPalindrome(item.Substring(i, size)))
                    {
                        Palindromas.Add(ReverseString(item.Substring(0, item.Length - size)));
                    }
                }

                //buscamos los sufijos con los que puede hacerse palindroma la palabra
                for (int i = 1; i < item.Length - 2; ++i)
                {
                    //si el substring es palindromo quiere decir que el resto de la cadena invertida 
                    //hace la cadena palindroma
                    if (CheckPalindrome(item.Substring(0, i+1)))
                    {
                        Palindromas.Add(ReverseString(item.Substring(i, item.Length - (item.Length - i))));
                    }
                }
            }

            //juntamos el diccionario en una sola cadena para facilitar la busqueda
            string cadenaCompleta = "*" + string.Join("*", Diccionario) + "*";

            string format = "*{0}*";

            foreach (var item in Palindromas)
            {
                //si en la cadena completa esta la posible palindroma entonces totalPalindromas++
                if (SearchString(cadenaCompleta, string.Format(format, item)).Length > 0)
                {
                    totalPalindromas++;
                }
            }

            Console.WriteLine("Total Palindromas: " + totalPalindromas);

            Console.ReadLine();
        }

        static bool CheckPalindrome(string cadena)
        {
            int mitadCadena = cadena.Length / 2;

            //aplicar hash
            return cadena.Substring(0, mitadCadena) == ReverseString(cadena.Substring(mitadCadena + (cadena.Length%2==0?0:1)));
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }

        public static int[] SearchString(string cadenaCompleta, string busqueda)
        {
            List<int> retVal = new List<int>();
            ulong siga = 0;
            ulong sigb = 0;
            ulong Q = 100007;
            ulong D = 256;

            for (int i = 0; i < busqueda.Length; ++i)
            {
                siga = (siga * D + (ulong)cadenaCompleta[i]) % Q;
                sigb = (sigb * D + (ulong)busqueda[i]) % Q;
            }

            if (siga == sigb)
                retVal.Add(0);

            ulong pow = 1;

            for (int k = 1; k <= busqueda.Length - 1; ++k)
                pow = (pow * D) % Q;

            for (int j = 1; j <= cadenaCompleta.Length - busqueda.Length; ++j)
            {
                siga = (siga + Q - pow * (ulong)cadenaCompleta[j - 1] % Q) % Q;
                siga = (siga * D + (ulong)cadenaCompleta[j + busqueda.Length - 1]) % Q;

                if (siga == sigb)
                    if (cadenaCompleta.Substring(j, busqueda.Length) == busqueda)
                        retVal.Add(j);
            }

            return retVal.ToArray();
        }

    }
}
