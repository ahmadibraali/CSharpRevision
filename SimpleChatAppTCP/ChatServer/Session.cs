using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ChatServer
{
    internal class Session
    {

        public event EventHandler<string> MsgReceived;

        TcpClient tcpClient;
        StreamReader streamReader;
        StreamWriter streamWriter;
        List<Message> SessionRecievedMsgs;
        
        public static List<User> RegisteredUsers;
        public static List<User> OnlineUsers;


        public Session(TcpClient _tcpClient)
        {
            this.tcpClient = _tcpClient;
            NetworkStream networkStream = tcpClient.GetStream();
            streamReader = new StreamReader(networkStream);
            streamWriter = new StreamWriter(networkStream);
            streamWriter.AutoFlush = true;
            RegisteredUsers = InitilizeRegisteredUsers();
            

        }

        private async void ReadMsgs()
        {
            while (true)
            {
                string _packet = await streamReader.ReadLineAsync();
                Message ReceivedMsg = new Message(_packet);
                SessionRecievedMsgs.Add(new Message(_packet));




                if (MsgReceived != null)
                    MsgReceived(this,ReceivedMsg.CoreMsg );

            }
        }
      

        /// <summary>
        /// ParameterLess Function That Return All Registered Users In The Server 
        /// As a Database for Authentication and check Credinitial in Very Simple Way
        /// 
        /// </summary>
        /// <returns>
        /// Return a List of Users 
        /// </returns>
        private List<User> InitilizeRegisteredUsers()
        {   List<User> users = new List<User>();
            List<string> Usernames= new List<string>()
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
            string _password = "123";
            foreach (var username in Usernames)
            {
                users.Add(new User(username, _password));
            }
            return users;

        }
    }
}
