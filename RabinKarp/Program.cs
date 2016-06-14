using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RabinKarp
{
    class Program
    {

        private const ulong Q = 100007;
        private const ulong D = 256;
        static Dictionary<string, string> diccionario = new Dictionary<string, string>();
        static bool encontrada = false;
        static List<string> cadenaFinal = new List<string>();

        static void Main(string[] args)
        {

            string cadenaCifrada, line;
            cadenaCifrada = line = string.Empty;


            using (StreamReader sr = new StreamReader("rabin.txt"))
            {
                while ((line = sr.ReadLine()) != null)
                {
                    if (string.IsNullOrEmpty(cadenaCifrada))
                    {
                        cadenaCifrada = line;
                    }
                    else
                        if (!diccionario.ContainsKey(line))
                        {
                            diccionario.Add(line, ReverseString(line).ToLower());
                        }
                }
            }

            BuscarPrimeraPalabra(cadenaCifrada);

            if (cadenaFinal.Count > 0)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("El mensaje es: " + string.Join(" ", cadenaFinal));
            }else{
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("No fue posible descifrar el mensaje");
            }

            Console.ReadLine();
        }

        static void BuscarPrimeraPalabra(string subCadenaCifrada)
        {
            var diccionarioFiltrado = diccionario.Where(m => m.Value[0] == subCadenaCifrada[0] && m.Value.Length <= subCadenaCifrada.Length).ToDictionary(m => m.Key, m => m.Value);

            for (int i = 0; i < diccionarioFiltrado.Count; i++)
            {
                var element = diccionarioFiltrado.ElementAt(i);

                if(CompareStrings(element.Value, subCadenaCifrada.Substring(0, element.Value.Length))){

                    //agregamos la palabra a la cadena final
                    cadenaFinal.Add(element.Key);

                    //si encontramos la última palabra nos salimos de todo
                    if (subCadenaCifrada.Length == element.Value.Length)
                    {
                        encontrada = true;
                        break;
                    }
                    else
                    {
                        //ahora buscamos la siguiente palabra
                        BuscarPrimeraPalabra(subCadenaCifrada.Substring(element.Value.Length));
                    }

                    if (encontrada)
                    {
                        break;
                    }
                    else
                    {//Si no encontramos la palabra removemos esta ya que fue un falso positivo y continuamos buscando
                        cadenaFinal.Remove(element.Key);
                    }
                }
            }
        }

        public static bool CompareStrings(string A, string B)
        {
            ulong siga = 0;
            ulong sigb = 0;

            for (int i = 0; i < B.Length; ++i)
            {
                siga = (siga * D + (ulong)A[i]) % Q;
                sigb = (sigb * D + (ulong)B[i]) % Q;
            }

            return siga == sigb;
        }

        public static string ReverseString(string s)
        {
            char[] arr = s.ToCharArray();
            Array.Reverse(arr);
            return new string(arr);
        }
    }
}
