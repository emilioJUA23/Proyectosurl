using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio2
{
    public class NodoDato<T> :IComparable where  T:IComparable
    {
        public T Dato { get;  set; }
        
        public NodoDato<T> Izquierda { get; set; }
        public NodoDato<T> Derecha { get; set; }
        public int altura;

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;

            NodoDato<T> otherNodoDato = obj as NodoDato<T>;
            if (otherNodoDato != null)
                return this.Dato.CompareTo(otherNodoDato.Dato);
            else
                throw new ArgumentException("Object is not a NodoDato");
        }
        public NodoDato(T dato)
        {
            Dato = dato;
            altura = 0;
            
        }
        public int calcularaltura() 
        {
            
            if (Izquierda == null && Derecha == null)
            {
                altura = 1;
            }
            else 
            {
                
                if(Izquierda==null)
                {
                    Derecha.calcularaltura();
                    altura = Derecha.altura + 1;
                }
                else
                {
                    if (Derecha == null)
                    {
                        Izquierda.calcularaltura();
                        altura = Izquierda.altura + 1;
                    }

                    else 
                    {
                        Izquierda.calcularaltura();
                        Derecha.calcularaltura();
                        if (Derecha.altura >= Izquierda.altura)
                        {
                            altura = Derecha.altura + 1;
                        }
                        else
                        {
                            altura = Izquierda.altura + 1;
                        }
                    }

                }
               
                
            }
            
            return altura;
        }
        
       
       
    }
}
