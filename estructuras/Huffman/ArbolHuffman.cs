using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Segundo_Proyecto_Estructuras.Huffman
{
     public  class ArbolHuffman
     {

         #region atributos
         public NodoHuffman raiz;
         public List<string> simbolos = new List<string>();
         public List<decimal> ocurrenciaporcentual;
         List<NodoHuffman> nodosarbol = new List<NodoHuffman>();
         public string comprimido;
         public string contenido;
         public Dictionary<string, string> paracomprimir= new Dictionary<string,string>() ;
         public Dictionary<string, string> paradescomprimir= new Dictionary<string,string>();
         public List<NodoHuffman> nodoshoja = new List<NodoHuffman>();
         public Int32 ArrayLenght;
         public byte[] arreglobytes;
         #endregion
         public ArbolHuffman(string contenido) 
         {
             this.contenido = contenido;
             ListaDeSimbolos nsimbolo = new ListaDeSimbolos(contenido);
             nsimbolo.contadordeocurrencias();
             List<string> Simbolos = nsimbolo.simbolos;
             List<decimal> ocurrencia = nsimbolo.prioridad;
             simbolos = Simbolos;
             ocurrenciaporcentual = ocurrencia;
             for (int i = 0; i < simbolos.Count; i++)
             {
                 NodoHuffman aux = new NodoHuffman(ocurrenciaporcentual[i],simbolos[i]);
                 nodosarbol.Add(aux);
             }
             generararbol();
             seteoaltura();
             crearruta();
             generarlista();
             generardiccionarios();
             
         }

         public ArbolHuffman(Dictionary<string,string> enviado,byte[] Cmprimido,int largo) 
         {
             paradescomprimir = enviado;
             arreglobytes = Cmprimido;
             ArrayLenght = largo;
             generarstringadescomrpimir();
         }

         public void generararbol()
         {

             while (nodosarbol.Count>1)
             {
                 nodosarbol.Sort();
                 decimal nprioridad = nodosarbol[0].prioridad + nodosarbol[1].prioridad;
                 NodoHuffman aux1 = new NodoHuffman(nprioridad,"");
                 aux1.izquierdo = nodosarbol[0];
                 aux1.derecho = nodosarbol[1];
                 nodosarbol.RemoveAt(0);
                 nodosarbol.RemoveAt(0);
                 nodosarbol.Add(aux1);

                 
             }
             raiz = nodosarbol[0];


         }

         public void generarobjetoamandar() 
         {

             byte[] arreglo;
             List<byte> blista = new List<byte>();
             int compresslenght = comprimido.Length;
             compresslenght = compresslenght % 8;
             compresslenght = 8 - compresslenght;
             for (int i = 0; i <compresslenght; i++)
             {
                 comprimido = comprimido + "0";
             }
             string auxcomprimido = comprimido;
             int largoaaray = comprimido.Length / 8;
             string numero = "";
             while (auxcomprimido.Length!=0)
             {
                 numero = auxcomprimido.Substring(0, 8);
                 auxcomprimido = auxcomprimido.Substring(8, auxcomprimido.Length - 8);
                 int aux1 = Convert.ToInt32(numero, 2);
                 byte nuevobyte=Convert.ToByte(aux1);
                 blista.Add(nuevobyte);
             }
             arreglo=new byte[blista.Count];
             for (int i = 0; i < blista.Count; i++)
             {
                 arreglo[i] = blista[i];   
             }
             arreglobytes = arreglo;

         }

         public void generarstringadescomrpimir() 
         {
             comprimido = "";
             string aux = "";
             for (int i = 0; i < arreglobytes.Length; i++)
             {
                
                 int xaux = Convert.ToInt32(arreglobytes[i]);

                 string daux = Convert.ToString(xaux,2);
                 daux = daux.PadLeft(8, '0');
                 comprimido = comprimido + daux;
             }
             comprimido = comprimido.Substring(0,ArrayLenght);    
         
         }

         public void crearruta() 
         {
             raiz.rutateorica = 0;
             crearrecrsivo(raiz);
         
         }

         public void crearrecrsivo(NodoHuffman encuestion) 
         {
             bool necesito = eshoja(encuestion);
             if (!necesito)
             {
                 encuestion.corregirruta();
                 encuestion.izquierdo.rutateorica = encuestion.rutateorica * 2;
                 encuestion.derecho.rutateorica=(encuestion.rutateorica*2)+1;
                 crearrecrsivo(encuestion.izquierdo);
                 crearrecrsivo(encuestion.derecho);
             }
             else
             {
                 encuestion.corregirruta();
             }
         
         }

         public void comprimir() 
         {
             foreach (char c in contenido)
             {
                 string aux = c.ToString();
                 comprimido = comprimido + paracomprimir[aux];
             }
             ArrayLenght = comprimido.Length;
             generarobjetoamandar();
            
         
         }

         public void descomprimir() 
         {
             contenido = "";
             string acumulativo = "";
             int posicion = 0;
             while (comprimido.Length>0)
             {
                 acumulativo = acumulativo + comprimido[posicion];
                 if (paradescomprimir.ContainsKey(acumulativo))
                 {
                     contenido = contenido + paradescomprimir[acumulativo];
                     acumulativo = "";
                     comprimido = comprimido.Substring(posicion+1,comprimido.Length-(posicion+1));
                     posicion = 0;
                 }
                 else
                 {
                     posicion++;
                 }
             }

         
         }

         public void seteoaltura() 
         {
            raiz.altura=0;
            seteorecursivo(raiz);
         }

         public void seteorecursivo(NodoHuffman encuestion) 
         {
             bool condicion = eshoja(encuestion);
             if (condicion)
             {

             }
             else 
             {
                 encuestion.izquierdo.altura = encuestion.altura + 1;
                 encuestion.derecho.altura = encuestion.altura + 1;
                 seteorecursivo(encuestion.derecho);
                 seteorecursivo(encuestion.izquierdo);
             }
         
         }

         public bool eshoja(NodoHuffman encuestion) 
         {
             bool retornado = false;
             if (encuestion.izquierdo == null && encuestion.derecho == null)
             {
                 retornado = true;
             }
             else { }
             return retornado;
         }

         public void generarlista() 
         {
             nodoshoja = new List<NodoHuffman>();
             generarlistarecursivo(raiz);
         
         }

         public void generarlistarecursivo(NodoHuffman encuestion) 
         {
             bool esHoja = eshoja(encuestion);
             if (esHoja)
             {
                 nodoshoja.Add(encuestion);
             }
             else
             {
                 generarlistarecursivo(encuestion.izquierdo);
                 generarlistarecursivo(encuestion.derecho);
             }
         
         }

         public void generardiccionarios() 
         {
             paracomprimir = new Dictionary<string, string>();
             paradescomprimir = new Dictionary<string, string>();
             foreach (NodoHuffman  c  in nodoshoja)
             {
                 paradescomprimir.Add(c.rutareal, c.simbolo);
                 paracomprimir.Add(c.simbolo,c.rutareal);
                 
             }
         
         }


    }
}
