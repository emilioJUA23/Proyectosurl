using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Proyecto_Estructuras.Huffman
{
     public class ListaDeSimbolos
    {
         public List<string> simbolos = new List<string>();
         public List<decimal> prioridad = new List<decimal>();
         public string descomprimido;
         public List<string> separados = new List<string>();
         public ListaDeSimbolos(string Descomprimido) 
         {
           this.descomprimido=Descomprimido;
         
         }
         public void generarlistado() 
         {
             separados = new List<string>();
             foreach(char c in descomprimido)
             {
                 separados.Add(c.ToString());
             }
         }
         public void  contadordeocurrencias()
         {
             generarlistado();
             string auxiliar;
             int contador;
             int i;
             while (separados.Count>0)
             {
                 auxiliar = separados[0];
                 contador = 0;
                 i = 0;
                 while ( i <= separados.Count - 1)
                 {
                     if (auxiliar == separados[i])
                     {
                         contador++;
                         separados.RemoveAt(i);
                     }
                     else
                     {
                         i++;
                     }


                 }
                 simbolos.Add(auxiliar);
                 decimal auxxxx =Convert.ToDecimal( contador) / Convert.ToDecimal(descomprimido.Length);
                 prioridad.Add(auxxxx);

             }
            

         }



    }
}
