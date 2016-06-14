using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Parentesis
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Ingrese el texto que desea validar los paréntesis: ");
            string cadena = Console.ReadLine();

            string retorno = VerificarParentesis(cadena);

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(retorno);
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Precione enter para cerrar la ventana...");
            Console.Read();
        }

        static string VerificarParentesis(string cadena)
        {

            Queue<string> colaParentesis = new Queue<string>();
            for (int i = 0; i < cadena.Length; i++)
            {
                char caracter = cadena[i];

                if (caracter == '(')
                {
                    colaParentesis.Enqueue("(");
                }
                else
                    if (caracter == ')')
                    {

                        if (colaParentesis.Count > 0)
                        {
                            colaParentesis.Dequeue();
                        }
                        else
                        {
                            return "Parentesis de Cierre no Coincide, Pos " + i;
                        }

                    }
            }

            if (colaParentesis.Count > 0)
            {
                return "Se quedaron parentesis abiertos, Paréntesis # " + colaParentesis.Count;
            }

            return "Los parentesis de la cadena estan correctos";

        }
    }
}
