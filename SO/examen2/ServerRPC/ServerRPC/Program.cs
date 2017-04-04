using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Channels.Tcp;


namespace ServerRPC
{
    class Program
    {
        static void Main(string[] args)
        {
            RemotingConfiguration.RegisterWellKnownServiceType(
            typeof(Libreria.Class1),"calculadora", 
            WellKnownObjectMode.SingleCall);
            TcpChannel chnl = new TcpChannel(1235);
            Console.WriteLine("estamos escuchando");
            Console.ReadKey();
        }
    }
}
