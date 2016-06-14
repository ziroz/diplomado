using LibreriaClases;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace AlturaArbik
{
    class Program
    {
        static void Main(string[] args)
        {
            Nodo raiz = new Nodo(10);

            raiz.nodoDerecho = new Nodo(20)
                {
                    nodoDerecho = new Nodo(10)
                    {
                        nodoIzquierdo = new Nodo(50)
                        {
                            nodoDerecho = new Nodo(10)
                        },
                        nodoDerecho = new Nodo(20)
                        {
                            nodoIzquierdo = new Nodo(0)
                            {
                                nodoDerecho = new Nodo(1)
                                {
                                    nodoIzquierdo = new Nodo(50)
                                    {
                                        nodoDerecho = new Nodo(10)
                                    },
                                }
                            },
                            nodoDerecho = new Nodo(20)
                        
                        }
                    },
                    nodoIzquierdo = new Nodo(0)
                    {
                        nodoDerecho = new Nodo(1)
                    }
                };

            raiz.nodoIzquierdo = new Nodo(20)
            {
                nodoDerecho = new Nodo(10)
                {
                    nodoIzquierdo = new Nodo(50)
                    {
                        nodoDerecho = new Nodo(10)
                    },
                    nodoDerecho = new Nodo(20)
                    {
                        nodoIzquierdo = new Nodo(0)
                        {
                            nodoDerecho = new Nodo(1)
                            {
                                nodoIzquierdo = new Nodo(50)
                                {
                                    nodoDerecho = new Nodo(10)
                                },
                            }
                        },
                        nodoDerecho = new Nodo(20)
                        {
                            nodoIzquierdo = new Nodo(50)
                            {
                                nodoDerecho = new Nodo(10)
                            },
                            nodoDerecho = new Nodo(20)
                            {
                                nodoIzquierdo = new Nodo(0)
                                {
                                    nodoDerecho = new Nodo(1)
                                    {
                                        nodoIzquierdo = new Nodo(50)
                                        {
                                            nodoDerecho = new Nodo(10)
                                        },
                                    }
                                },
                                nodoDerecho = new Nodo(20)

                            }
                        }

                    }
                },
                nodoIzquierdo = new Nodo(0)
                {
                    nodoDerecho = new Nodo(1)
                }
            };
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("El alto del Arbol es: " + AlturaNodo(raiz, 0).ToString());

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
            raiz.ImprimirArbol();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Precione enter para cerrar la ventana...");
            Console.Read();
        }

        static int AlturaNodo(Nodo raiz, int alto)
        {

            int altoIzquierdo = alto;
            int altoDerecho = alto;

            if (raiz.nodoIzquierdo != null)
            {
                altoIzquierdo = AlturaNodo(raiz.nodoIzquierdo, alto + 1);
            }

            if (raiz.nodoDerecho != null)
            {
                altoDerecho = AlturaNodo(raiz.nodoDerecho, alto + 1);
            }

            return Math.Max(altoDerecho, altoIzquierdo);
        }

    }
}
