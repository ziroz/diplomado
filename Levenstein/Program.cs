using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Levenstein
{
    class Program
    {
        static void Main(string[] args)
        {

            while (true)
            {


                Console.Write("Ingrese la cadena 1:  ");
                string cadena1 = Console.ReadLine();
                Console.Write("Ingrese la cadena 2:  ");
                string cadena2 = Console.ReadLine();

                modificaciones = new char[cadena1.Length + 1, cadena2.Length + 1];

                int distancia = LevenshteinDistance(cadena1, cadena2);
                Console.WriteLine("");
                Console.WriteLine("La cantidad de pasos es: " + distancia);

                pasos = 1;
                delete = 0;
                insert = 0;

                Console.WriteLine("");
                PintarPasos(cadena1, cadena2, cadena1.Length, cadena2.Length);
                Console.WriteLine("");
                Console.WriteLine("");

            }
        }

        public static int LevenshteinDistance(string cadena1, string cadena2)
        {
            // d es una tabla con m+1 renglones y n+1 columnas
            int length1 = cadena1.Length;
            int length2 = cadena2.Length;
            int[,] d = new int[length1 + 1, length2 + 1];

            // Verifica que exista algo que comparar
            if (length2 == 0) return length1;
            if (length1 == 0) return length2;

            // Llena la primera columna y la primera fila.
            for (int i = 0; i <= length1; i++)
            {
                d[i, 0] = i;
                modificaciones[i, 0] = 'E';
            }

            for (int j = 0; j <= length2; j++)
            {
                d[0, j] = j;
                modificaciones[0, j] = 'I';
            }

            /// i columnas, j Filas
            for (int i = 1; i <= length1; i++)
            {
                for (int j = 1; j <= length2; j++)
                {

                    var eliminacion = d[i - 1, j] + 1;
                    var insercion = d[i, j - 1] + 1;
                    var sustituion = d[i - 1, j - 1] + (cadena1[i - 1] == cadena2[j - 1] ? 0 : 1);

                    d[i, j] = System.Math.Min(System.Math.Min(eliminacion, insercion), sustituion);

                    if (d[i, j] == eliminacion)
                    {
                        modificaciones[i, j] = 'E';
                    }
                    else
                        if (d[i, j] == insercion)
                        {
                            modificaciones[i, j] = 'I';
                        }
                        else
                            if (cadena1[i - 1] != cadena2[j - 1])
                            {
                                modificaciones[i, j] = 'S';
                            }
                            else
                            {
                                modificaciones[i, j] = '0';
                            }
                }
            }

            return d[length1, length2];
        }

        private static char[,] modificaciones;
        private static int pasos, insert, delete;

        private static void PintarPasos(string s1, string s2, int i, int j)
        {
            if (modificaciones[i, j] == '0')
            {
                PintarPasos(s1, s2, i - 1, j - 1);
            }
            else
                if (modificaciones[i, j] == 'E')
                { 
                    PintarPasos(s1, s2, i - 1, j);
                    Console.WriteLine(string.Format("{0} Delete {1}", pasos++, (i + insert - delete)));
                    delete++;
                }
                else
                    if (modificaciones[i, j] == 'I')
                    {
                        if (j == 0) return;
                        PintarPasos(s1, s2, i, j - 1);
                        Console.WriteLine(string.Format("{0} Insert {1}, {2}", pasos++, j, s2[j - 1]));
                        insert++;
                    }
                    else if (modificaciones[i, j] == 'S')
                    {
                        if (j == 0) return;
                        PintarPasos(s1, s2, i - 1, j - 1);
                        Console.WriteLine(string.Format("{0} Replace {1}, {2}", pasos++, s2[j - 1], (i + insert - delete)));
                    }
        }
    }
}
