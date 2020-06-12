using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.IO;

namespace Server
{
    public class Server
    {
    
        private Socket osluckujuciSocket;
        public List<Thread> nitiKlijenata = new List<Thread>();
        public bool PokreniServer()
        {
            try
            {
                osluckujuciSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                osluckujuciSocket.Bind(new IPEndPoint(IPAddress.Parse("127.0.0.1"), 20000));
                ThreadStart nitOsluskivanja = Osluskuj;
                new Thread(nitOsluskivanja).Start();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
        List<Socket> ksoketi = new List<Socket>();
        public void Osluskuj()
        {
            try
            {
                while (true)
                {
                    osluckujuciSocket.Listen(8);
                    Socket klijentskiSocket = osluckujuciSocket.Accept();
                    NetworkStream tok = new NetworkStream(klijentskiSocket);
                   
                    NitKlijenta nk = new NitKlijenta(tok);
                    nitiKlijenata = nk.nitiKlijenata;
                    ksoketi.Add(klijentskiSocket);
                }
            }
            catch (Exception)
            {
            }
        }

        public bool ZaustaviServer()
        {
            try
            {

                
                for (int i = 0; i < nitiKlijenata.Count; i++)
                {
                    try
                    {
                        
                        nitiKlijenata[i].Interrupt();
                    }
                    catch (IOException)
                    {
                    }
                }
                for(int i = 0;i< ksoketi.Count; i++)
                {
                    ksoketi[i].Close();
                }
                osluckujuciSocket.Close();
                

                return true;
            }
            catch (Exception e)
            {
                String s = e.Message;
                return false;
            }
        }
    }
}
