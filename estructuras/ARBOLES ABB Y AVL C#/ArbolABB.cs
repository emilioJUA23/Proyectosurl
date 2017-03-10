using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace laboratorio2
{
    interface ArbolBase  
    {
        int busqueda(string s,ref bool d,string tipo);
        string mostrarpostorder();
        string mostrarinorder();
        string mostrarpreorder();
    }
    
    public  class ArbolABB<T>:ArbolBase where T:IComparable
    {
        public NodoDato<T> raiz;
       public  string ordenados = null;

        public ArbolABB() 
        {
            raiz = null;
        }

        public NodoDato<T> crearnuevonodo(T agregar)
        {
            NodoDato<T> nuevonodo = null;
            nuevonodo = new NodoDato<T>(agregar);
            return nuevonodo;
        }

        public virtual int busqueda(string s,ref bool d,string tipo)
        {
            dynamic dato;
            int a = 0;
            d = false;
            switch (tipo)
            {
                case "INTEGER":
                    dato = Convert.ToInt32(s);
                    T ddato = (T)dato;
                    a = buscar(raiz, ddato, ref d);
                    break;
                case "STRING":
                    dato = s;
                    T dddato = (T)dato;
                    a = buscar(raiz, dddato, ref d);
                    break;
                case "PERSONA":
                    dato = new Persona("","","",Convert.ToInt32(s),"","","");
                    T ddddato = (T)dato;
                    a = buscar(raiz, ddddato, ref d);
                    break;
                case "PRODUCTO":
                    dato = new Producto("", Convert.ToInt32(s),"","");
                    T dddddato = (T)dato;
                    a = buscar(raiz, dddddato, ref d);
                    break;
            }
            
            
            return a;
        }

        public int buscar(NodoDato<T> comparacion, T s,ref bool u) 
        {
            int z = 0;
            if (comparacion == null)
            {
                
            }
            else
            {
               
                if (comparacion.Dato.CompareTo(s)==0)
                {
                    u = true;
                }
                else
                {
                    if (comparacion.Dato.CompareTo(s) >= 1)
                    {

                        z = buscar(comparacion.Izquierda, s,ref u) + 1;
                   

                    }
                    else
                    {

                        z = buscar(comparacion.Derecha, s, ref u) + 1;
                       
                    }
                }
            }
            
            
            return z;       
        }

        public virtual void meterdato(T agregar)
        {

            raiz = agregardato(agregar, raiz);

        }

        public virtual NodoDato<T> agregardato(T agregar, NodoDato<T> comparar)
        {

            //NodoDato<T> nuevonodo = new NodoDato<T>(agregar);


            if (comparar == null)
            {
                comparar = crearnuevonodo(agregar);
            }
            else
            {
                int a = comparar.Dato.CompareTo(agregar);
             if (a>=0)
            {

                comparar.Izquierda = agregardato(agregar, comparar.Izquierda);

            }
            else
            {

                comparar.Derecha = agregardato(agregar, comparar.Derecha);


            }
            
            }


            return comparar;

        }

        public virtual void sacardato(T agregar)
        {

            raiz = eliminardato(agregar, raiz);

        }

        public virtual NodoDato<T> eliminardato(T agregar, NodoDato<T> comparacion)
        {

            if (comparacion == null)
            {
                //throw new Exception("no existe numero en el arbol");
            }
            else
            {
                int a = comparacion.Dato.CompareTo(agregar);
                if (a == 0)
                {
                    if (comparacion.Izquierda == null && comparacion.Derecha == null)
                    {
                        comparacion = null;
                    }
                    else
                    {
                        if (comparacion.Izquierda == null && comparacion.Derecha != null)
                        {
                            comparacion = comparacion.Derecha;
                            comparacion.Derecha = null;
                        }
                        else
                        {
                            if (comparacion.Izquierda != null && comparacion.Derecha == null)
                            {
                                comparacion = comparacion.Izquierda;
                                comparacion.Izquierda = null;
                            }
                            else
                            {
                                NodoDato<T> aux = comparacion.Izquierda;
                                while (aux.Derecha != null)
                                {
                                    aux = aux.Derecha; 
                                }
                                comparacion.Dato = aux.Dato;
                                eliminardato(aux.Dato, aux);


                            }
                        }



                    }
                }
                else
                {
                    if (a<=1)
                    {

                        comparacion.Izquierda = eliminardato(agregar, comparacion.Izquierda);

                    }
                    else
                    {

                        comparacion.Derecha = eliminardato(agregar, comparacion.Derecha);

                    }
                }
            }
            return comparacion;

        }

        public string mostrar(NodoDato<T> analizar)
        {
            NodoDato<T> actualNodo = analizar ;
            string contenido;
            contenido = "";

            
                contenido = contenido + "\n" + actualNodo.Dato.ToString()+",";
       
            




            return contenido;

        }

        public string mostrarpostorder()
        {
            ordenados = null;
            mostrarpost(raiz);
            return ordenados;
        }

        public string mostrarpost(NodoDato<T> analizar)
        {

            if (analizar == null)
            {

            }
            else
            {
                mostrarpost(analizar.Izquierda);
                mostrarpost(analizar.Derecha);
                ordenados = ordenados + mostrar(analizar);
            }


            return ordenados;

        }

        public string mostrarpreorder()
        {
            ordenados = null;
            mostrarpre(raiz);
            return ordenados;
        }

        public string mostrarpre(NodoDato<T> analizar)
        {

            if (analizar == null)
            {

            }
            else
            {
                ordenados = ordenados + mostrar(analizar);
                mostrarpre(analizar.Izquierda);
                mostrarpre(analizar.Derecha);
            }


            return ordenados;

        }

        public string mostrarinorder()
        {
            ordenados = null;
            mostrarin(raiz);
            return ordenados;
        }

        public string mostrarin(NodoDato<T> analizar)
        {

            if (analizar == null)
            {

            }
            else
            {
                mostrarin(analizar.Izquierda);
                ordenados = ordenados + mostrar(analizar);
                mostrarin(analizar.Derecha);
            }


            return ordenados;

        }





    }
}
