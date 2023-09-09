using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.StartPanel;

namespace ChatServer
{
    public enum UserTypes
    {
        Client = 1,
        Server = 2,

    }
    public enum Userstatus
    {
        Online = 1,
        Offline = 2,

    }

    internal class User
    {
        public static List<User> Registerdusers = new List<User>() {
                new User("Server","123"),
                new User("Ali","123"),
                new User("Ola","123"),
                new User("Ahmed","123"),
                new User("Nour","123"),
                new User("Mike","123"),
                new User("Salma","123"),
                new User("Mazen","123"),
                new User("Walid","123"),
                new User("Mayar","123"),
                new User("Hani","123"),
                new User("Hamdy","123"),
                new User("Mahmoud","123"),
                new User("Mourad","123"),
                new User("Yasmin","123"),
                new User("Safa","123"),
                new User("Nourhan","123"),
                new User("Nouran","123"),
                new User("Naira","123"),
                new User("Asmaa","123"),
                new User("Eman","123"),
                new User("Emad","123"),
                new User("Eyad","123"),
                new User("Eslam","123"),
                new User("Mohamed","123"),
                new User("Tarek","123"),
            };



        public event EventHandler<Message> MsgHadSent;
        public event EventHandler<User> UserIsActive;

        public string UserName { get; set; }
        public string Password { get; set; }



        public List<Message> AllMessages { get; set; }
        public List<Message> SentMessages { get; set; }
        public List<Message> ReceivedMessages { get; set; }
        public UserTypes UserType { get; set; }
        public Userstatus UserStatus { get; set; }
        /*public User CurrentUser { get; set; }*/

        public User(string _userName, string _password, bool server) : this(_userName, _password)
        {
            if (!server)
                this.UserType = UserTypes.Client;
            else
                this.UserType = UserTypes.Server;
        }
        public User(string _userName, string _password, UserTypes _userType) : this(_userName, _password)
        {

            UserStatus = Userstatus.Online;
            UserType = _userType;

        }
        public User(string _userName, string _password)
        {
            UserName = _userName;
            Password = _password;
           // this.UserType= checkClientServer();
            bool registeredUser = CheckCredinials();
            if (registeredUser) LoginSuccessfully();
            else InvalidCredinitials();
            
            
            //UserStatus = Userstatus.Offline;

        }

        private bool CheckCredinials()
        {
            bool authenticated = false;
            foreach(User _user in Registerdusers)
            {
               authenticated = _user.Equals(this);
                if (authenticated)
                {
                    //LoginSuccessfully();
                    return true;
                    
                }

            }
            return false;
         }

        private void InvalidCredinitials()
        {
            /// # TO DO SomeThing

        }
        /// <summary>
        /// Handling UserState Which Used To Register Online User 
        /// Using EventHandler To Get a Notification  when User is Online 
        /// Session Will Receive a state of Current Online user
        /// To View Them In all Sessions 
        /// </summary>
        private void LoginSuccessfully()
        {
            this.UserStatus = Userstatus.Online;
            this.UserType = UserTypes.Client;
            //CurrentUser = this;

            if(UserIsActive != null)
            {
                UserIsActive(this,this);
            }
            

        }
        /// <summary>
        /// Sending Or Receiving Message Function as I Call as User I Can be Sender Or Receiver
        /// </summary>
        /// <param name="_message">Message To Be Sent</param>
        /// <param name="_user">The Other Client Who Is Sending Or Receiving Message To Me </param>
        /// <param name="send">bool Check To Know Who Is the Sender Or Receiver User</param>
        /// <example> <see>if user1 is sending <pararef>Message</pararef> to <pararef>user2</pararef> and sending check is true <pararef>true</pararef></see>
        /// <code> user1.IsSendingOrReceivingMessage(Message,user2,true)</code>
        /// </example>
        public void IsSendingOrReceivingMessage(Message _message, User _user, bool send)
        {
            if (send)
                SendMsgToAnthor(_message, _user, this);
            else
                SendMsgToAnthor(_message, this, _user);
        }
        /// <summary>
        /// To Send Message to Receive it in sending Or Receiving Message in User Session
        /// </summary>
        /// <param name="_message">Message To Be Sent</param>
        /// <param name="_receiver">Receiver User </param>
        /// <param name="_sender">Sender User</param>
        private void SendMsgToAnthor(Message _message, User _receiver, User _sender)
        {
            _message.From = _sender;
            _message.To = _receiver;
            _sender.AllMessages.Add(_message);
            _sender.SentMessages.Add(_message);
            _receiver.AllMessages.Add(_message);
            _receiver.ReceivedMessages.Add(_message);

            if (MsgHadSent != null)
                MsgHadSent(this, _message);
        }


        /// <summary>
        /// Overriding Equallity Functions  
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool value for the state of of being Equal credinitials  "Authenticated Users"</returns>
        public override bool Equals(object? obj)
        {
            var other = obj as User;
            if (other == null) return false;
            else
            {
                return (this.UserName == other.UserName && this.Password == other.Password);
            }


        }

        /// <summary>
        /// Overriding Equallity Operator Functions  
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool value for the state of of being Equal credinitials  "Authenticated Users"</returns>
        public static bool operator==(User user1,User user2)=> user1.Equals(user2);

        /// <summary>
        /// Overriding Not Equality Operator Functions  
        /// </summary>
        /// <param name="obj"></param>
        /// <returns>bool value for the state of of being Not Equal credinitials  "Authenticated Users"</returns>
        public static bool operator!=(User user1, User user2)=> !(user1.Equals(user2));

    }
}
