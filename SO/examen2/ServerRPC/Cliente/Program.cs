using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels;
using System.Runtime.Remoting.Channels.Tcp;
using Libreria;

namespace Cliente
{
    class Program
    {
        static void Main(string[] args)
        {
            TcpClientChannel chanel = new TcpClientChannel();
            ChannelServices.RegisterChannel(chanel, false);
            RemotingConfiguration.RegisterWellKnownClientType(
                typeof(Class1),"tcp://localhost:1235/calculadora");
            try
            {
                while (true)
                {
                    Class1 op = new Class1();
                    Console.WriteLine(op.Suma(4, 3));
                }

            }
            catch (Exception ex)
            {

                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
            
        }
    }
}
