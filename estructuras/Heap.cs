using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Proyecto_Estructuras
{
    public class Heap
    {

        public Nodo_Heap Raiz;
        public Nodo_Heap ultimodato;
        public List<Nodo_Heap> nodoshoja = new List<Nodo_Heap>();
        public List<int> alturadehojas = new List<int>();
        public int count;
        public Heap()
        {
            Raiz = null;
            ultimodato = Raiz;    
        }
        public void  Inserccion(Nodo_Heap ndato)
        {
            nodoshoja = new List<Nodo_Heap>();
            alturadehojas = new List<int>();
                        
            if(Raiz==null)
            {
                Raiz = ndato;
                Raiz.altura = 1;
                ultimodato = Raiz;
            }
            else
            {
                inserccionrecursiva(Raiz);
                int indice = 0;
                int menor = -1;
                menor = alturadehojas[0];
                for (int i = 1; i <= nodoshoja.Count-1; i++)
                {
                    if (alturadehojas[i]<menor)
                    {
                        menor = alturadehojas[i];
                        indice = i;
                    }
                    
                }
                if (nodoshoja[indice].Izquierdo==null)
                {
                    ndato.altura = nodoshoja[indice].altura + 1;
                    nodoshoja[indice].Izquierdo = ndato;
                    ndato.Padre = nodoshoja[indice];
                    ultimodato = ndato;

                }
                else 
                {
                    ndato.altura = nodoshoja[indice].altura + 1;
                    nodoshoja[indice].Derecho = ndato;
                    ndato.Padre = nodoshoja[indice];
                    ultimodato = ndato;
                }
            }
            subiendo(ultimodato);

        }
        public void subiendo(Nodo_Heap encuestion)
        {
            if(!(encuestion.Padre == null))
            {
                if (encuestion.Padre.prioridad < encuestion.prioridad)
                {
                   
                    Nodo_Heap aux2= new Nodo_Heap(encuestion.Padre.dato);
                    aux2.prioridad=encuestion.Padre.prioridad;
                    encuestion.Padre.dato = encuestion.dato;
                    encuestion.Padre.prioridad = encuestion.prioridad;
                    encuestion.dato = aux2.dato;
                    encuestion.prioridad = aux2.prioridad;
                    subiendo(encuestion.Padre);
                }
                else { }

            }
        
        }
        public void inserccionrecursiva(Nodo_Heap encuestion) 
        {
            bool comprobacion = eshojavirtual(encuestion);
            if (comprobacion)
            {
                Nodo_Heap auxiliar = null;
                auxiliar = encuestion;
                if (encuestion.Izquierdo!=null)
                {
                    auxiliar = null;
                    auxiliar = encuestion.Izquierdo;
                    nodoshoja.Add(auxiliar);
                    alturadehojas.Add(auxiliar.altura);
                }
                
                auxiliar = encuestion;
                nodoshoja.Add(auxiliar);
                alturadehojas.Add(auxiliar.altura);
                if (encuestion.Derecho != null)
                {
                    auxiliar = null;
                    auxiliar = encuestion.Derecho;
                    nodoshoja.Add(auxiliar);
                    alturadehojas.Add(auxiliar.altura);
                }
            }
            else
            {
                if (encuestion.Izquierdo!=null)
                {
                    inserccionrecursiva(encuestion.Izquierdo);
                }
                if (encuestion.Derecho != null)
                {
                    inserccionrecursiva(encuestion.Derecho);   
                }

            }
        
        }
        public bool eshojavirtual(Nodo_Heap encuestion) 
        {
            if (encuestion.Izquierdo==null||encuestion.Derecho==null)
            {
                return true;
            }
            else
            {
                return false;
            }
        
        }
        public int contarelementos() 
        {
             count = 0;
             contarrecursivo(Raiz);
             return count;
        }
        public void contarrecursivo(Nodo_Heap encuestion) 
        {
            count++;
            if (encuestion.Izquierdo!=null)
            {
                contarrecursivo(encuestion.Izquierdo);
            }
            if (encuestion.Derecho!=null)
            {
                contarrecursivo(encuestion.Derecho);
            }
        
        }
        public void Eliminacion() 
        {
            int contados = contarelementos();
            if (contarelementos() == 1)
            {
                Raiz = null;
            }
            else
            {
                Nodo_Heap auxiliar = null;
                auxiliar = new Nodo_Heap(Raiz.dato);
                auxiliar.prioridad = Raiz.prioridad;
                Raiz.dato = ultimodato.dato;
                Raiz.prioridad = ultimodato.prioridad;
                ultimodato.dato = auxiliar.dato;
                ultimodato.prioridad = auxiliar.prioridad;
                Nodo_Heap vater = ultimodato.Padre;
                if (vater.Derecho != null)
                {
                    vater.Derecho = null;
                }
                else
                {
                    vater.Izquierdo = null;
                }
                ultimodato = null;
                reinsertarraiz(Raiz);
                ubicarultimodato(Raiz);
            }

        }
        public void ubicarultimodato(Nodo_Heap encuestion)
        {
            nodoshoja = new List<Nodo_Heap>();
            alturadehojas = new List<int>();
            inserccionrecursiva(encuestion);
            int indice=0;
            int menor =alturadehojas[0];
             for (int i = 0; i <= nodoshoja.Count-1; i++)
                {
                    if (alturadehojas[i]<menor)
                    {
                        menor = alturadehojas[i];
                        indice = i;
                    }
                    
                }
             if (indice == 0)
             {
                 ultimodato = nodoshoja[nodoshoja.Count-1];
             }
             else
             {
                 ultimodato = nodoshoja[indice - 1];
             }

            }
        public void reinsertarraiz(Nodo_Heap encuestion) 
        {
          if (encuestion.Izquierdo==null && encuestion.Derecho==null)
          {
                
          }
          else
          {

            int factor = 0;
            if (encuestion.Izquierdo!=null && encuestion.Derecho!=null) 
            {
             factor = encuestion.Izquierdo.prioridad - encuestion.Derecho.prioridad;
            }
            else if (encuestion.Izquierdo == null)
            {
                factor = 0 - encuestion.Derecho.prioridad;
            }
            else
            {
                factor = encuestion.Izquierdo.prioridad;
            }
            
            if (factor >= 0)
            {
                if(encuestion.prioridad<encuestion.Izquierdo.prioridad)
                {
                    Nodo_Heap auxiliar = null;
                    auxiliar = new Nodo_Heap(encuestion.dato);
                    auxiliar.prioridad = encuestion.prioridad;
                    encuestion.dato = encuestion.Izquierdo.dato;
                    encuestion.prioridad = encuestion.Izquierdo.prioridad;
                    encuestion.Izquierdo.dato = auxiliar.dato;
                    encuestion.Izquierdo.prioridad = auxiliar.prioridad;
                    reinsertarraiz(encuestion.Izquierdo);
                }
                else
                {}

            }
            else 
            {
                if (encuestion.prioridad < encuestion.Derecho.prioridad)
                {
                    Nodo_Heap auxiliar = null;
                    auxiliar = new Nodo_Heap(encuestion.dato);
                    auxiliar.prioridad = encuestion.prioridad;
                    encuestion.dato = encuestion.Derecho.dato;
                    encuestion.prioridad = encuestion.Derecho.prioridad;
                    encuestion.Derecho.dato = auxiliar.dato;
                    encuestion.Derecho.prioridad = auxiliar.prioridad;
                    reinsertarraiz(encuestion.Derecho);
                }
                else
                { }
            }
        }
        
       }




    }
}
