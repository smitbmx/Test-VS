using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Threading;
using System.Net;

namespace ClientServerPerson
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Server s = new Server();
            }
            catch
            {
                Console.WriteLine("ERROR START SERVER");
            }
        }
    }




}
