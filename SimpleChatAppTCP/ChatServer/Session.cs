using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    public class Session
    {
        public static List<string> RegisterdUsers = new List<string>() {
                "Server",
                "Ali",
                "Ola",
                "Ahmed",
                "Nour",
                "Mike",
                "Salma",
                "Mazen",
                "Walid",
                "Mayar",
                "Hani",
               "Hamdy",
                "Mahmoud",
                "Mourad",
               "Yasmin",
                "Safa",
                "Nourhan",
                "Nouran",
                "Naira",
                "Asmaa",
                "Eman",
                "Emad",
                "Eyad",
                "Eslam",
                "Mohamed",
                "Tarek"
            };
        public static bool IsServer;
        public event EventHandler<Message> MsgReceived;
        

        TcpClient tcpClient;
        StreamReader streamReader;
        StreamWriter streamWriter;
        public static List<Message> SessionRecievedMsgs=new List<Message>();


        
        public static List<string> OfflineUsers = new List<string>();

        public static List<string> OnlineUsers = new List<string>();

        public string UserName { get; set; }
        



        public Session(TcpClient _tcpClient)
        {
             
            
            //this.UserName = _userName; 
            this.tcpClient = _tcpClient;
            NetworkStream networkStream = tcpClient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;

           

            ReadMsgs();
        }
        public Session(string UserName)
        {
            this.UserName = UserName;
        }



        
       

       
        private async void ReadMsgs()
        {
            while (true)
            {
                string _packet = await streamReader.ReadLineAsync();
                Message ReceivedMsg = new Message(_packet);
                SessionRecievedMsgs.Add(ReceivedMsg);
                
                



                if (MsgReceived != null)
                    MsgReceived(this,ReceivedMsg);

            }
        }

        public void SendMsg(Message _message)
        {
            
            streamWriter.WriteLine(_message.Packet);
        }

        
        



    
    }
}
