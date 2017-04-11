using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace PruebaAutomatas
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        FileStream archivo;
        StreamWriter archivito;
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {

                //si no se ha elegido un archvo se termina el metodo

                if (adfarchivo.ShowDialog() != System.Windows.Forms.DialogResult.OK)
                {

                }
                else
                {
                    string nombreArchivo = Path.GetFullPath(adfarchivo.FileName);
                    archivo = new FileStream(nombreArchivo, FileMode.OpenOrCreate);
                    string ruta = Path.ChangeExtension(nombreArchivo, "aut");
                     archivito = new StreamWriter(ruta);
                     while (leercaracter(c)!='\0'.ToString())
                     {
                         if (leercaracter(c)==" "||leercaracter(c)=="\n"||leercaracter(c)=="\r"||leercaracter(c)=="\t")
                         {
                             c++;
                         }
                         else
                         {
                             string auc=tomatoken();
                             archivito.WriteLine(auc);
                         }
                        
                     }
                     listBox1.Items.Add("se termino de leer el archivo con exito");
                     archivito.Close();
                }
            }
            catch (Exception ex)
            {

                listBox1.Items.Add(ex.Message);
            }

        }




        public string leercaracter(int position)
        {
            string aux = " ";
            int a = Encoding.Default.GetBytes(aux).Length;
            byte[] bufferr = new byte[a];
            bufferr = Encoding.Default.GetBytes(" ");
            string nodo = null;
            byte[] buffer = new byte[a];
            int posicion = (position * a);
            archivo.Seek(posicion, SeekOrigin.Begin);
            archivo.Read(buffer, 0, a);
            nodo = Encoding.Default.GetString(buffer).ToLower();
            return nodo;
        }

        string letra1 = "97..122+97..122+95";
        string digito1 = "48..57";
        string charset1 = "32..254";
        public bool Econjunto(string menge, string chr)
        {
            string[] dom = menge.Split('+');
            char C = chr[0];
            bool semaforo = false;
            int mayor = 0;
            int menor = 0;
            for (int i = 0; i < dom.Length; i++)
            {
                if (dom[i].Contains(".."))
                {
                    int pos = dom[i].IndexOf('.');
                    mayor = Convert.ToInt32(dom[i].Substring(pos + 2, dom[i].Length - (pos + 2)));
                    menor = Convert.ToInt32(dom[i].Substring(0, pos));
                    if (mayor >= (int)C && menor <= (int)C)
                    {
                        semaforo = true;
                        break;
                    }
                }
                else
                {
                    mayor = Convert.ToInt32(dom[i]);
                    menor = Convert.ToInt32(dom[i]);
                    if (mayor == (int)C)
                    {
                        semaforo = true;
                        break;
                    }
                }
            }
            return semaforo;
        }

        int c = 0;
        public string tomatoken()
        {
            string palabra = "";
            int estadoMayor = 0;
            bool error = false;
            bool salir = false;
            string letr = "";
            while (letr != null && salir != true)
            {
                letr = leercaracter(c);
                switch (estadoMayor)
                {
                    case 0:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 1;
                            palabra = palabra + letr;
                        }
                        else if (Econjunto(letra1, letr))
                        {
                            estadoMayor = 2;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                            error = true;
                            palabra = palabra + letr;
                            c++;
                        }
                        break;

                    case 1:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 1;
                            palabra = palabra + letr;
                        }
                        else if (letr.CompareTo(".") == 0)
                        {
                            estadoMayor = 3;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                        }
                        break;

                    case 2:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 4;
                            palabra = palabra + letr;
                        }
                        else if (Econjunto(letra1, letr))
                        {
                            estadoMayor = 4;
                            palabra = palabra + letr;
                        }
                        else if (letr.CompareTo(":") == 0)
                        {
                            estadoMayor = 5;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                        }
                        break;

                    case 3:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 6;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                            error = true;
                        }
                        break;

                    case 4:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 4;
                            palabra = palabra + letr;
                        }
                        else if (Econjunto(letra1, letr))
                        {
                            estadoMayor = 4;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                        }
                        break;

                    case 5:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 5;
                            palabra = palabra + letr;
                        }
                        else if (Econjunto(letra1, letr))
                        {
                            estadoMayor = 5;
                            palabra = palabra + letr;
                        }
                        else if (letr.CompareTo("\\")==0)
                        {
                            estadoMayor = 5;
                            palabra = palabra + letr;
                        }
                        else if (letr.CompareTo(" ") == 0)
                        {
                            estadoMayor = 5;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                        }
                        break;

                    case 6:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 6;
                            palabra = palabra + letr;
                        }
                        else if (letr.CompareTo(".") == 0)
                        {
                            estadoMayor = 7;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                            error = true;
                        }
                        break;

                    case 7:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 8;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                            error = true;
                        }
                        break;

                    case 8:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 8;
                            palabra = palabra + letr;
                        }
                        else if (letr.CompareTo(".") == 0)
                        {
                            estadoMayor = 9;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                            error = true;
                        }
                        break;

                    case 9:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 10;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                            error = true;
                        }
                        break;

                    case 10:
                        if (Econjunto(digito1, letr))
                        {
                            estadoMayor = 10;
                            palabra = palabra + letr;
                        }
                        else
                        {
                            salir = true;
                        }
                        break;

                    default:
                        salir = true;
                        break;
                }
                c++;
            }
            c--;
            if (error == true)
            {
                return palabra + " palabra no perteneciente a ningun token ";
            }
            else
            {
                switch (estadoMayor)
                {
                    case 0:
                        error = true;
                        return palabra + "error por estado de no aceptacion";

                    case 1:
                        return palabra + "=" + "1";

                    case 2:
                        if (palabra.CompareTo("connect") == 0)
                        {
                            estadoMayor = 3;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("send") == 0)
                        {
                            estadoMayor = 4;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("list") == 0)
                        {
                            estadoMayor = 5;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("connected") == 0)
                        {
                            estadoMayor = 6;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("sender") == 0)
                        {
                            estadoMayor = 7;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("dir") == 0)
                        {
                            estadoMayor = 8;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("kill") == 0)
                        {
                            estadoMayor = 9;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("user") == 0)
                        {
                            estadoMayor = 10;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else
                        {
                            return palabra + "=" + "2";
                        }

                    case 3:
                        error = true;
                        return palabra + "error por estado de no aceptacion";

                    case 4:
                        if (palabra.CompareTo("connect") == 0)
                        {
                            estadoMayor = 3;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("send") == 0)
                        {
                            estadoMayor = 4;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("list") == 0)
                        {
                            estadoMayor = 5;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("connected") == 0)
                        {
                            estadoMayor = 6;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("sender") == 0)
                        {
                            estadoMayor = 7;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("dir") == 0)
                        {
                            estadoMayor = 8;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("kill") == 0)
                        {
                            estadoMayor = 9;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else if (palabra.CompareTo("user") == 0)
                        {
                            estadoMayor = 10;
                            return palabra + "=" + estadoMayor.ToString();
                        }
                        else
                        {
                            return palabra + "=" + "2";
                        }

                    case 5:
                        return palabra + "=" + "11";

                    case 6:
                        error = true;
                        return palabra + "error por estado de no aceptacion";

                    case 7:
                        error = true;
                        return palabra + "error por estado de no aceptacion";

                    case 8:
                        error = true;
                        return palabra + "error por estado de no aceptacion";

                    case 9:
                        error = true;
                        return palabra + "error por estado de no aceptacion";

                    case 10:
                        return palabra + "=" + "12";

                    default:
                        return palabra + " error desconocido";
                }
            }
        }


































    }
}
