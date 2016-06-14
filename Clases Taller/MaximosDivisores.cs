using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MaximosMultiplos
{
    class Program
    {
        static void Main(string[] args)
        {

            int numero = -1;
            int pasoActual = 0;
            Queue<int> ColaValores = new Queue<int>();
            Queue<int> CantidadPasosCola = new Queue<int>();

            Console.WriteLine("Ingrese número a evaluar: ");
            string cadena = Console.ReadLine();

            ColaValores.Enqueue(Convert.ToInt32(cadena));
            CantidadPasosCola.Enqueue(0);

            numero = ColaValores.Peek();

            while (numero != 0)
            {

                pasoActual = CantidadPasosCola.Peek() + 1;

                ColaValores.Enqueue(numero - 1);
                CantidadPasosCola.Enqueue(pasoActual);

                if (ObtenerDivisorMaximo(numero) != -1)
                {
                    ColaValores.Enqueue(ObtenerDivisorMaximo(numero));
                    CantidadPasosCola.Enqueue(pasoActual);
                }
                ColaValores.Dequeue();
                CantidadPasosCola.Dequeue();
                numero = ColaValores.Peek();
            }

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine(CantidadPasosCola.Peek());
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine("Precione enter para cerrar la ventana...");
            Console.Read();

        }
        public static int ObtenerDivisorMaximo(int n)
        {

            int mayor = -1;
            int a;
            for (int i = (int)(Math.Sqrt(n)); i >= 2; i--)
            {
                if (n % i == 0)
                {

                    a = n / i;
                    if (a > i)
                    {
                        return a;
                    }
                    else
                    {
                        return i;
                    }
                }

            }

            return mayor;
        }

    }
}
