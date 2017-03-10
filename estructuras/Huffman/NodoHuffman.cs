using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Proyecto_Estructuras.Huffman
{
     public class NodoHuffman:IComparable
    {
         public decimal prioridad;
         public string simbolo;
         public NodoHuffman izquierdo;
         public NodoHuffman derecho;
         public int rutateorica;
         public int altura;
         public string rutareal;
         public NodoHuffman(decimal Prioridad,string Simbolo) 
         {
             simbolo = Simbolo;
             prioridad = Prioridad;
             derecho = null;
             izquierdo = null;
             rutateorica = 0;
         }

         public int CompareTo(object obj)
         {
             if (obj == null) return 1;

             NodoHuffman otherNodoDato = obj as NodoHuffman;
             if (otherNodoDato != null)
                 return this.prioridad.CompareTo(otherNodoDato.prioridad);
             else
                 throw new ArgumentException("Object is not a NodoDato");
         }
         public void  corregirruta()
         {
             rutareal = Convert.ToString(rutateorica, 2);
             rutareal = rutareal.PadLeft(altura, '0');
         }
    }
}
