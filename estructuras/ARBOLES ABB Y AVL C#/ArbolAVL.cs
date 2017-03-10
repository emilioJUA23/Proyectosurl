using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio2
{
    class ArbolAVL<T>:ArbolABB<T> where T:IComparable
    {

     public override void meterdato(T agregar)
     {
 	    base.meterdato(agregar);
        raiz=llamarbalanceo(raiz);
     }

     public override void sacardato(T agregar)
     {
 	 base.sacardato(agregar);
         raiz=llamarbalanceo(raiz);
     }
    

     public int necesitobalanceo(NodoDato<T> padre) 
     {
         raiz.calcularaltura();
         int a=0;
         if (padre.Izquierda == null && padre.Derecha == null) 
         {
             a = 0;
         }
         else if(padre.Izquierda == null && padre.Derecha != null)
         {
             a = 0 - padre.Derecha.altura;
         }
         else if (padre.Izquierda != null && padre.Derecha == null)
         {
             a = padre.Izquierda.altura;
         }
         else if (padre.Izquierda != null && padre.Derecha != null)
         {
             a = padre.Izquierda.altura - padre.Derecha.altura;
         }

         return a;
     }

     public NodoDato<T> llamarbalanceo(NodoDato<T> inicio)
        {


            if (inicio.Izquierda != null) 
            {
                inicio.Izquierda = llamarbalanceo(inicio.Izquierda); 
            }

            if (inicio.Derecha != null)
            { 
                inicio.Derecha = llamarbalanceo(inicio.Derecha); 
            }
            int a = necesitobalanceo(inicio);
            if (a >= -1 && a <= 1)
            {
            }
            else 
            {
                if (a > 1)
                {
                    int b = necesitobalanceo(inicio.Izquierda);
                    if (b < 0)
                    {

                        inicio = rotarizquierdaderecha(inicio);
                    }
                    else 
                    {
                        inicio = rotarderecha(inicio);
                    }

                }
                else 
                {
                    int c = necesitobalanceo(inicio.Derecha);
                    if (c > 0)
                    {
                        inicio = rotarderechaizquierda(inicio);
                    }
                    else
                    {
                        inicio = rotarizquierda(inicio);
                    }
                }
                        
            }

            return inicio;
        }

     public NodoDato<T> rotarizquierda(NodoDato<T> desbalanceado)
        {
            NodoDato<T> aux;
            aux = desbalanceado.Derecha;
            desbalanceado.Derecha = aux.Izquierda;
            aux.Izquierda = desbalanceado;
            return aux;

        }

     public NodoDato<T> rotarderecha(NodoDato<T> desbalanceado)
        {
                NodoDato<T> aux;
                aux = desbalanceado.Izquierda;
                desbalanceado.Izquierda = aux.Derecha;
                aux.Derecha = desbalanceado;
            
                return aux;

        }

     public NodoDato<T> rotarderechaizquierda(NodoDato<T> desbalanceado)
        {
            NodoDato<T> aux;
            desbalanceado.Derecha=rotarderecha(desbalanceado.Derecha);
            aux = rotarizquierda(desbalanceado);
            return aux;

        }

     public NodoDato<T> rotarizquierdaderecha(NodoDato<T> desbalanceado)
        {
            NodoDato<T> aux;
            desbalanceado.Izquierda = rotarizquierda(desbalanceado.Izquierda);
            aux = rotarderecha(desbalanceado);
            return aux;
        }

     public void calcularaltura()
        {
            raiz.calcularaltura();
        }

     public override int busqueda(string s, ref bool d,string tipo)
     {
         return base.busqueda(s, ref d,tipo);
     }
    }
}
