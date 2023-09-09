using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
  // public static List<string> onlineUsers = new List<string>();

    public  class Client
    {
        public static List<string> clientsUserNames = new List<string>()
        {
             "Ali",
                "Ahmed",
                "Ola",
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
        public static List<string> onlineUsers = new List<string>();

        public event EventHandler<string> MsgReceived;
        TcpClient tcpClient;
        StreamReader streamReader;
        StreamWriter streamWriter;
        public string OnlineUserName { get; set; }
        
        public Client(TcpClient _tcpClient)
        {
            this.tcpClient = _tcpClient;
            NetworkStream networkStream = tcpClient.GetStream();
            /// (BinaryReader & BinaryWriter)  Same as (StreamReader & StreamWriter)

            //BinaryReader binaryReader = new BinaryReader(networkStream);
            //BinaryWriter binaryWriter = new BinaryWriter(networkStream);
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;

            ReadMsgs();
        }

        public void SendMsg(string msg)
        {
            streamWriter.WriteLine(msg);
        }
        
        private async void ReadMsgs()
        {
            while (true)
            {
                string msg = await streamReader.ReadLineAsync();
                chkMsgs(msg);
                
                
                
                if (MsgReceived != null)
                    MsgReceived(this, msg);
                
            }
        }

        private void chkMsgs(string? msg)
        {
            if (msg.StartsWith("###") && msg.EndsWith("###"))
                UserCredinitials(msg);
            else if (msg.StartsWith("#ONLINE#") && msg.EndsWith("#ONLINE#"))
                OnlineuserMsg(msg);
            else
            {
                SendMsg(msg);
            }
        }

        private void OnlineuserMsg(string msg)
        {
            var user = msg[8..^8];
            SendMsg($"#ONLINE#{user}");
        }

        private void UserCredinitials(string credinitials )
        {
            if(credinitials != null)
            {
                foreach (string username in clientsUserNames)
                {
                    if($"###{username.ToLower()}#123###"== credinitials)
                    {
                        onlineUsers.Add(username);

                        SendMsg("$$$Login Successfully$$$");
                        
                        break;
                    }
                    else
                    {
                        SendMsg("$$$Try Again$$$");

                    }
                }
            }
        }
    }
}
