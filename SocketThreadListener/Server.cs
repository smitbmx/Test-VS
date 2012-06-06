using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.Sockets;
using System.Net;
using System.Threading;

namespace ClientServerPerson
{
    public class Server
    {
        private TcpListener tcpListener;
        private Thread listenThread;

        public Server()
        {
            IPAddress ipAd = IPAddress.Any;// Parse("127.0.0.1");
            this.tcpListener = new TcpListener(ipAd, 8001);
            this.listenThread = new Thread(new ThreadStart(ListenForClients));
            this.listenThread.Start();
            Console.WriteLine("Server is started");
        }

        private void ListenForClients()
        {
            this.tcpListener.Start();

            while (true)
            {
                //blocks until a client has connected to the server
                Socket socket = tcpListener.AcceptSocket();

                //create a thread to handle communication 
                //with connected client
                Thread clientThread = new Thread(new ParameterizedThreadStart(HandleClientComm));
                clientThread.Start(socket);
            }
        }

        private void HandleClientComm(object client)
        {
            Socket localSocket = (Socket)client;

            Console.WriteLine("Connection accepted from " + localSocket.RemoteEndPoint);

            byte[] b = new byte[8000];
            int k = localSocket.Receive(b);
            Console.WriteLine("Recieved...");
            for (int i = 0; i < k; i++)
                Console.Write(Convert.ToChar(b[i]));

            ASCIIEncoding asen = new ASCIIEncoding();
            localSocket.Send(asen.GetBytes("The string was recieved by the server."));
            Console.WriteLine("\nSent Acknowledgement");


            string allString = string.Empty;
            for (int i = 0; i < k; i++)
            {
                allString += Convert.ToChar(b[i]);
                Console.Write(Convert.ToChar(b[i]));
            }

            string[] arr = allString.Split(';');

            Person p = new Person();
            p.Name = arr[2];
            p.LastName = arr[3];
            p.Age = Convert.ToInt32(arr[4]);
            p.Phone = arr[5];
            PList pList = new PList();

            pList.pList.Add(p);
            if (arr[1] == "save")
            {
                pList.Save(arr[0]);
            }
            if (arr[1] == "load")
            {
                pList.Load(arr[0]);
                allString = string.Empty;

                for (int i = 0; i < pList.pList.Count; i++)
                {
                    allString += string.Concat(pList.pList[i].Name, ";", pList.pList[i].LastName, ";", pList.pList[i].Age, ";", pList.pList[i].Phone, "$");
                }

                ASCIIEncoding asen1 = new ASCIIEncoding();
                localSocket.Send(asen1.GetBytes(allString));
            }


            localSocket.Close();
        }
    }
}
