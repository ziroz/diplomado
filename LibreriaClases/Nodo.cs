using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibreriaClases
{
    public class Nodo : IComparable
    {
        public Nodo(int valor, Nodo parent)
            : this(valor)
        {
            nodoPadre = parent;
            Balancear();
        }
        
        public Nodo(int valor, Nodo izq, Nodo der)
            : this(valor)
        {
            this.nodoIzquierdo = izq;
            this.nodoDerecho = der;
        }
        public Nodo(int valor)
        {
            this.value = valor;
        }

        public int value { get; set; }
        public Nodo nodoIzquierdo { get; set; }
        public Nodo nodoDerecho { get; set; }
        public Nodo nodoPadre { get; set; }

        public int CompareTo(object obj)
        {
            Nodo valueCompare = (Nodo)obj;
            if (valueCompare.value > this.value) return 1;
            if (valueCompare.value < this.value) return -1;
            return 0;
        }

        public void ImprimirArbol()
        {
            ImprimirArbol(this, "");
        }

        private void ImprimirArbol(Nodo arbol, string indent)
        {
            if (arbol.nodoIzquierdo != null)
            {
                ImprimirArbol(arbol.nodoIzquierdo, indent + "\t");
            }

            if (arbol.Mediana != 0)
            {
            Console.WriteLine(indent + arbol.value + " - " + arbol.Mediana);
            }
            else
            {
                Console.WriteLine(indent + arbol.value);
            }
            if (arbol.nodoDerecho != null)
            {
                ImprimirArbol(arbol.nodoDerecho, indent + "\t");
            }
        }

        public float Mediana
        {
            get
            {

                if (nodoDerecho != null && nodoIzquierdo != null)
                {
                    return Math.Min(nodoIzquierdo.Mediana, nodoDerecho.Mediana);
                }else
                    if (nodoIzquierdo != null)
                    {
                        return (nodoIzquierdo.value + value) / 2F;
                    }
                    else
                    {
                        return value;
                    }
            }
        }

        public void Balancear()
        {
            if (nodoPadre != null)
            {
                //Si mi padre es mayor debemos cambiar
                if (this.CompareTo(nodoPadre) == 1)
                {
                    int valueTemp = nodoPadre.value;
                    nodoPadre.value = this.value;
                    this.value = valueTemp;
                    nodoPadre.Balancear();
                }
            }
        }
    }
}
