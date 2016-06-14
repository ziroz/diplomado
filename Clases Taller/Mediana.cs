using LibreriaClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mediana
{
    class Program
    {
        public static Queue<Nodo> NodosLibres = new Queue<Nodo>();

        static void Main(string[] args)
        {

            int valor = 0;

            Nodo raiz = null;

            while (valor != -1)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("Ingrese el nuevo valor: (-1 para terminar)");
                string valoringresado = Console.ReadLine();

                if(int.TryParse(valoringresado, out valor)){

                    if (raiz == null)
                    {
                        raiz = new Nodo(valor);
                        //agregamos el elemento como nodolibre
                        NodosLibres.Enqueue(raiz);
                    }
                    else
                    {
                        var nodoLibre = NodosLibres.Peek();

                        if (nodoLibre.nodoIzquierdo == null)
                        {
                            nodoLibre.nodoIzquierdo = new Nodo(valor, nodoLibre);
                            //agregamos el elemento izq como nodolibre
                            NodosLibres.Enqueue(nodoLibre.nodoIzquierdo);
                        }else
                            if (nodoLibre.nodoDerecho == null)
                            {
                                nodoLibre.nodoDerecho = new Nodo(valor, nodoLibre);
                                //agregamos el elemento der como nodolibre
                                NodosLibres.Enqueue(nodoLibre.nodoDerecho);
                                //eliminamos el nodo libre ya que estan ocupadas sus ramas
                                NodosLibres.Dequeue();
                            }
                    }

                    Console.WriteLine("La nueva mediana es: " + raiz.Mediana);

                }

                raiz.ImprimirArbol();

            }

        }
    }
}
